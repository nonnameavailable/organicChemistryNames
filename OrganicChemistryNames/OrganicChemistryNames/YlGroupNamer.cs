using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrganicChemistryNames
{
    class YlGroupNamer : MoleculeNamer
    {
        public YlGroupNamer(int[][] grid, Element startCarbon) : base(grid)
        {
            this.grid = grid;
            this.startCarbon = startCarbon;
        }
        public string moleculeName()
        {
            update();
            string result = "";
            result += extrasNamePart();

            result += Element.carbonStems[longestCC.Count]; // stem name
            result += bondsNamePart();

            return result;
        }

        private void update()
        {
            longestCC = NH.longestCarbonChain(grid);
            int[][] newGrid = NH.gridWithoutList(grid, longestCC);
            longestCC = NH.longestCarbonChain(newGrid, startCarbon);
            lccBonds = NH.longestCCBonds(longestCC, newGrid);
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
        private string bondsNamePart()
        {
            string result = "";
            if (bondsPositions.Count == 0) result += "yl";
            foreach (KeyValuePair<int, List<Element>> kvp in bondsPositions)
            {
                bool onlySingleBonds = kvp.Key == 1 && bondsPositions.Count == 1;
                bool singleBond = kvp.Key == 1;
                if (onlySingleBonds)
                {
                    result += "yl";
                }
                else if (!singleBond)
                {
                    List<Element> positions = bondsPositions[kvp.Key];
                    string name = Element.counters[positions.Count] + Element.elementNames[kvp.Key];
                    bool includePositions = longestCC.Count > 2;
                    result += (includePositions ?  ("-" + IP.listToString(positions, ",") + "-") : "") + name + "yl";
                }
            }
            return result;
        }
        private string extrasNamePart()
        {
            string result = "";
            foreach (int i in halogenOrderList)
            {
                extrasPositions.TryGetValue(i, out List<Element> positions);
                if (positions != null && positions.Count > 0)
                {
                    string name = Element.counters[positions.Count] + Element.elementNames[i];
                    result += IP.listToString(positions, ",") + "-" + name + "-";
                }
            }
            return result;
        }
    }
}
