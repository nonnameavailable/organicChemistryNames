using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Specialized;

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

        public string moleculeName()
        {
            update();
            string halogenNP = halogensNamePart();
            string ylGroupsNP = ylGroupsNamePart();
            if (ylGroupsNP == "" && halogenNP != "") halogenNP = halogenNP.Substring(0, halogenNP.Length - 1);
            string stemNP = Element.carbonStems[longestCC.Count]; // stem name
            string bondsNP = bondsNamePart();

            return halogenNP + ylGroupsNP + stemNP + bondsNP;
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
        private string halogensNamePart()
        {
            string result = "";
            extrasPositions.TryGetValue(Element.C, out List<Element> ylgroups);
            foreach (int i in halogenOrderList)
            {
                extrasPositions.TryGetValue(i, out List<Element> positions);
                if (positions != null && positions.Count > 0)
                {
                    string name = Element.counters[positions.Count] + Element.elementNames[i];
                    bool hidePositions = longestCC.Count < 2 || (longestCC.Count == 2 && positions.Count == 1 && extrasPositions.Count == 1);
                    result += (hidePositions ? "" : (IP.listToString(positions, ",") + "-")) + name + "-";
                }
            }
            return result;
        }

        private string bondsNamePart()
        {
            string result = "";
            if (bondsPositions.Count == 0) result += "an";
            foreach (KeyValuePair<int, List<Element>> kvp in bondsPositions)
            {
                bool onlySingleBonds = kvp.Key == 1 && bondsPositions.Count == 1;
                bool singleBond = kvp.Key == 1;
                if (onlySingleBonds)
                {
                    result += "an";
                }
                else if (!singleBond)
                {
                    List<Element> positions = bondsPositions[kvp.Key];
                    string name = Element.counters[positions.Count] + Element.elementNames[kvp.Key];
                    bool includePositions = longestCC.Count > 2;
                    result += (includePositions ?  ("-" + IP.listToString(positions, ",") + "-") : "") + name;
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
        

    }
}
