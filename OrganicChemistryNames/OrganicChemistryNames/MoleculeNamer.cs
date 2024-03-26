﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Specialized;
using System.Drawing;

namespace OrganicChemistryNames
{
    class MoleculeNamer
    {
        protected int[][] grid;
        protected List<Element> longestCC;
        protected List<Element> lccBonds;
        protected Dictionary<int, List<Element>> extrasPositions;
        protected Dictionary<int, List<Element>> bondsPositions;
        protected static List<int> halogenOrderList = new List<int>() { 8, 6, 7, 9 };
        protected Element startCarbon;
        protected int depth;
        protected int carbonConnection;
        private bool hasHalogen;

        public int CarbonChainConnection { get => carbonConnection; set => carbonConnection = value; }
        protected bool HasHalogen { get => hasHalogen; set => hasHalogen = value; }
        public MoleculeNamer(int[][] grid, int depth)
        {
            this.grid = grid;
            this.depth = depth;
            hasHalogen = false;
        }
        public MoleculeNamer(int[][] grid, int depth, Element startCarbon, int carbonConnection)
        {
            this.grid = grid;
            this.depth = depth;
            this.startCarbon = startCarbon;
            this.carbonConnection = carbonConnection;
            hasHalogen = false;
        }

        public void setMoleculeName(Form1 form)
        {
            List<Color> bgColors = form.BgColorList;
            List<Color> fontColors = form.FontColorList;
            foreach(TypedString ts in MoleculeNameTypedList)
            {
                form.AppendNameRTB(ts.Text, new Font("Arial", 24), fontColors[ts.Type], bgColors[ts.Type]);
            }
        }

        public string MoleculeNameSimpleString
        {
            get
            {
                string result = "";
                foreach (TypedString ts in MoleculeNameTypedList)
                {
                    result += ts.Text;
                }
                return result;
            }

        }
        public List<TypedString> MoleculeNameTypedList
        {
            get
            {
                update();
                List<TypedString> halogens = halogensNamePart();
                List<TypedString> ylGroups = ylGroupsNamePart();
                TypedString stem = new TypedString(Element.carbonStems[longestCC.Count], Element.C);
                List<TypedString> bonds = bondsNamePart();

                if(ylGroups.Count == 0 && halogens.Count > 0)
                {
                    TypedString lastHalogen = halogens.Last();
                    lastHalogen.Text = lastHalogen.Text.Substring(0, lastHalogen.Text.Length - 1);
                    halogens[halogens.Count - 1] = lastHalogen;
                }

                List<TypedString> result = new List<TypedString>();
                result = result.Concat(halogens).ToList();
                result = result.Concat(ylGroups).ToList();
                result.Add(stem);
                result = result.Concat(bonds).ToList();
                return result;
            }
        }

        private List<TypedString> ylGroupsNamePart()
        {
            List<TypedString> result = new List<TypedString>();
            if (extrasPositions.TryGetValue(4, out List<Element> carbonsList))
            {
                Dictionary<string, List<MoleculeNamer>> ylGroups = new Dictionary<string, List<MoleculeNamer>>();
                foreach (Element e in carbonsList)
                {
                    MoleculeNamer mn = new MoleculeNamer(NH.gridWithoutList(grid, longestCC), depth + 1, e, e.CarbonChainConnection);
                    ylGroups.AddToList(mn.MoleculeNameSimpleString, mn);
                }
                int cntr = 0;
                foreach (KeyValuePair<string, List<MoleculeNamer>> kvp in ylGroups)
                {
                    List<TypedString> moleculeNameTypedList = kvp.Value[0].MoleculeNameTypedList;
                    string moleculeNameString = kvp.Key;
                    string startHyphen = cntr == 0 ? "" : "-";
                    bool isComplex = kvp.Value[0].HasHalogen || int.TryParse(moleculeNameString.Substring(0, 1), out _);
                    string leftPar = isComplex ? "(" : "";
                    string rightpar = isComplex ? ")" : "";
                    string counter = isComplex ? Element.complexCounters[kvp.Value.Count] : Element.counters[kvp.Value.Count];
                    string positions = IP.listToString(kvp.Value, ",");

                    string final = startHyphen + positions + "-" + counter + leftPar;

                    result.Add(new TypedString(final, Element.C));
                    result = result.Concat(kvp.Value[0].MoleculeNameTypedList).ToList();
                    result.Add(new TypedString(rightpar, Element.C));
                    cntr++;
                }
            }
            return result;
        }
        private List<TypedString> halogensNamePart()
        {
            List<TypedString> result = new List<TypedString>();
            foreach (int i in halogenOrderList)
            {
                extrasPositions.TryGetValue(i, out List<Element> positions);
                if (positions != null && positions.Count > 0)
                {
                    string name = Element.counters[positions.Count] + Element.elementNames[i];
                    bool hidePositions = longestCC.Count < 2 || (longestCC.Count == 2 && positions.Count == 1 && extrasPositions.Count == 1);
                    result.Add(new TypedString((hidePositions ? "" : (IP.listToString(positions, ",") + "-")) + name + "-", i));
                    HasHalogen = true;
                }
            }

            return result;
        }

        private List<TypedString> bondsNamePart()
        {
            string ending = depth == 0 ? "an" : "yl" + ideneEdene();
            List<TypedString> result = new List<TypedString>();
            if (bondsPositions.Count == 0) result.Add(new TypedString(ending, Element.C));
            foreach (KeyValuePair<int, List<Element>> kvp in bondsPositions)
            {
                bool onlySingleBonds = kvp.Key == 1 && bondsPositions.Count == 1;
                bool singleBond = kvp.Key == 1;
                if (onlySingleBonds)
                {
                    result.Add(new TypedString(ending, Element.C));
                }
                else if (!singleBond)
                {
                    List<Element> positions = bondsPositions[kvp.Key];
                    string yl = depth > 0 ? "yl" : "";
                    string name = Element.counters[positions.Count] + Element.elementNames[kvp.Key] + yl + ideneEdene();
                    bool includePositions = longestCC.Count > 2;
                    result.Add(new TypedString((includePositions ?  ("-" + IP.listToString(positions, ",") + "-") : "") + name, kvp.Key));
                }
            }
            return result;
        }
        private string ideneEdene()
        {
            if (depth == 0) return "";
            List<Element> scb = startCarbon.neighboringBonds(grid);
            string result = "";
            foreach(Element bond in scb)
            {
                Element dir = new Element(bond.X - startCarbon.X, bond.Y - startCarbon.Y, Element.SINGLE_BOND);
                int sX = startCarbon.X +  2 * dir.X;
                int sY = startCarbon.Y + 2 * dir.Y;
                if(grid[sY][sX] == 0)
                {
                    if(bond.Type == Element.DOUBLE_BOND)
                    {
                        result = "iden";
                    } else if(bond.Type == Element.TRIPLE_BOND)
                    {
                        result = "idyn";
                    }
                    
                }
            }
            return result;
        }
        private void update()
        {
            if (depth == 0)
            {
                longestCC = NH.longestCarbonChain(grid);
            }
            else
            {
                longestCC = NH.longestCarbonChain(grid, startCarbon);
            }

            lccBonds = NH.longestCCBonds(longestCC, grid);


            extrasPositions = new Dictionary<int, List<Element>>();
            bondsPositions = new Dictionary<int, List<Element>>();
            for (int i = 0; i < longestCC.Count; i++)
            {
                Element c = longestCC[i];
                List<Element> neighbors = c.neighboringElements(grid, Element.ALL);
                foreach (Element ne in neighbors)
                {
                    if (!ne.isInList(longestCC))
                    {
                        ne.CarbonChainConnection = i + 1;
                        extrasPositions.AddToList(ne.Type, ne);
                    }
                }

                if (i < longestCC.Count - 1)
                {
                    bondsPositions.AddToList(lccBonds[i].Type, lccBonds[i]);
                }
            }
        }
    }
    public struct TypedString
    {
        public TypedString(string text, int type)
        {
            Text = text;
            Type = type;
        }
        public string Text { get; set; }
        public int Type { get; }
    }
}
