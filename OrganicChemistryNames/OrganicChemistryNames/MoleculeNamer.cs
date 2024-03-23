using System;
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

        public int CarbonChainConnection { get => carbonConnection; set => carbonConnection = value; }
        public MoleculeNamer(int[][] grid, int depth)
        {
            this.grid = grid;
            this.depth = depth;
        }
        public MoleculeNamer(int[][] grid, int depth, Element startCarbon, int carbonConnection)
        {
            this.grid = grid;
            this.depth = depth;
            this.startCarbon = startCarbon;
            this.carbonConnection = carbonConnection;
        }

        public void setMoleculeName(Form1 form)
        {
            foreach(TypedString ts in MoleculeNameTypedList)
            {
                form.AppendNameRTB(ts.Text, new Font("Arial", 24), Element.fontColorMap[ts.Type], Element.backgroundColorMap[ts.Type]);
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

        //public List<TypedString> MoleculeNameTypedList
        //{
        //    get
        //    {
        //        update();
        //        List<TypedString> result = halogensNamePart();
        //        result.Add(new TypedString(ylGroupsNamePart(), Element.C));
        //        result.Add(new TypedString(Element.carbonStems[longestCC.Count], Element.C));
        //        result = result.Concat(bondsNamePart()).ToList();
        //        return result;
        //    }

        //}

        //private string ylGroupsNamePart()
        //{
        //    string result = "";
        //    if (extrasPositions.TryGetValue(4, out List<Element> carbonsList))
        //    {
        //        Dictionary<string, List<Element>> ylGroups = new Dictionary<string, List<Element>>();
        //        foreach (Element e in carbonsList)
        //        {
        //            YlGroupNamer ygn = new YlGroupNamer(grid, depth + 1, e);
        //            ygn.update();
        //            ylGroups.AddToList(ygn.moleculeName(), e);
        //        }
        //        foreach (KeyValuePair<string, List<Element>> kvp in ylGroups)
        //        {
        //            result += IP.listToString(kvp.Value, ",") + "-" + Element.counters[kvp.Value.Count] + kvp.Key + "-";
        //        }
        //        if (ylGroups.Count > 0)
        //        {
        //            result = result.Substring(0, result.Length - 1);
        //        }
        //    }
        //    return result;
        //}
        public List<TypedString> MoleculeNameTypedList
        {
            get
            {
                update();
                List<TypedString> result = halogensNamePart();
                result = result.Concat(ylGroupsNamePart()).ToList();
                result.Add(new TypedString(Element.carbonStems[longestCC.Count], Element.C));
                result = result.Concat(bondsNamePart()).ToList();
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
                int counter = 0;
                foreach (KeyValuePair<string, List<MoleculeNamer>> kvp in ylGroups)
                {
                    string startHyphen = counter == 0 ? "" : "-";
                    result.Add(new TypedString(startHyphen + IP.listToString(kvp.Value, ",") + "-" + Element.counters[kvp.Value.Count], Element.C));
                    result = result.Concat(kvp.Value[0].MoleculeNameTypedList).ToList();
                    counter++;
                }
            }
            return result;
        }
        private List<TypedString> halogensNamePart()
        {
            List<TypedString> result = new List<TypedString>();
            extrasPositions.TryGetValue(Element.C, out List<Element> ylgroups);
            foreach (int i in halogenOrderList)
            {
                extrasPositions.TryGetValue(i, out List<Element> positions);
                if (positions != null && positions.Count > 0)
                {
                    string name = Element.counters[positions.Count] + Element.elementNames[i];
                    bool hidePositions = longestCC.Count < 2 || (longestCC.Count == 2 && positions.Count == 1 && extrasPositions.Count == 1);
                    result.Add(new TypedString((hidePositions ? "" : (IP.listToString(positions, ",") + "-")) + name + "-", i));
                }
            }
            if(result.Count > 0)
            {
                TypedString lastTS = result[result.Count - 1];
                lastTS.Text = lastTS.Text.Substring(0, lastTS.Text.Length - 1);
                result[result.Count - 1] = lastTS;
            }

            return result;
        }

        private List<TypedString> bondsNamePart()
        {
            string ending = depth == 0 ? "an" : "yl";
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
                    string name = Element.counters[positions.Count] + Element.elementNames[kvp.Key] + yl;
                    bool includePositions = longestCC.Count > 2;
                    result.Add(new TypedString((includePositions ?  ("-" + IP.listToString(positions, ",") + "-") : "") + name, Element.C));
                }
            }
            return result;
        }
        private void update()
        {
            if(depth == 0)
            {
                longestCC = NH.longestCarbonChain(grid);
            } else
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
