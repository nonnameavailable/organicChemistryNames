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

        public MoleculeNamer(int[][] grid)
        {
            this.grid = grid;
        }

        public void setMoleculeName(Form1 form)
        {
            update();
            List<TypedString> halogenNP = halogensNamePart();
            string ylGroupsNP = ylGroupsNamePart();
            string stemNP = Element.carbonStems[longestCC.Count];
            List<TypedString> bondsNP = bondsNamePart();

            foreach (TypedString ts in halogenNP)
            {
                string txt = ylGroupsNP == "" && halogenNP.IndexOf(ts) == halogenNP.Count - 1 ? ts.Text.Substring(0, ts.Text.Length - 1) : ts.Text;
                form.AppendNameRTB(txt, new Font("Arial", 24), Element.fontColorMap[ts.Type], Element.backgroundColorMap[ts.Type]);
            }
            form.AppendNameRTB(ylGroupsNP, new Font("Arial", 24), Element.fontColorMap[Element.C], Element.backgroundColorMap[Element.C]);
            form.AppendNameRTB(stemNP, new Font("Arial", 24), Element.fontColorMap[Element.C], Element.backgroundColorMap[Element.C]);
            foreach (TypedString ts in bondsNP)
            {
                form.AppendNameRTB(ts.Text, new Font("Arial", 24), Element.fontColorMap[Element.C], Element.backgroundColorMap[Element.C]);
            }
        }

        //private List<Element> getYlCarbons()
        //{
        //    return extrasPositions.TryGetValue;
        //}
        private string ylGroupsNamePart()
        {
            string result = "";
            if (extrasPositions.TryGetValue(4, out List<Element> carbonsList))
            {
                Dictionary<string, List<Element>> ylGroups = new Dictionary<string, List<Element>>();
                foreach (Element e in carbonsList)
                {
                    YlGroupNamer ygn = new YlGroupNamer(grid, e);
                    ygn.update();
                    ylGroups.AddToList(ygn.moleculeName(), e);
                }
                foreach (KeyValuePair<string, List<Element>> kvp in ylGroups)
                {
                    result += IP.listToString(kvp.Value, ",") + "-" + Element.counters[kvp.Value.Count] + kvp.Key + "-";
                }
                if (ylGroups.Count > 0)
                {
                    result = result.Substring(0, result.Length - 1);
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
            return result;
        }

        private List<TypedString> bondsNamePart()
        {
            List<TypedString> result = new List<TypedString>();
            if (bondsPositions.Count == 0) result.Add(new TypedString("an", Element.C));
            foreach (KeyValuePair<int, List<Element>> kvp in bondsPositions)
            {
                bool onlySingleBonds = kvp.Key == 1 && bondsPositions.Count == 1;
                bool singleBond = kvp.Key == 1;
                if (onlySingleBonds)
                {
                    result.Add(new TypedString("an", Element.C));
                }
                else if (!singleBond)
                {
                    List<Element> positions = bondsPositions[kvp.Key];
                    string name = Element.counters[positions.Count] + Element.elementNames[kvp.Key];
                    bool includePositions = longestCC.Count > 2;
                    result.Add(new TypedString((includePositions ?  ("-" + IP.listToString(positions, ",") + "-") : "") + name, Element.C));
                }
            }
            return result;
        }
        private void update()
        {
            longestCC = NH.longestCarbonChain(grid);
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

        public struct TypedString
        { 
            public TypedString(string text, int type)
            {
                Text = text;
                Type = type;
            }
            public string Text { get; }
            public int Type { get; }
        }
    }
}
