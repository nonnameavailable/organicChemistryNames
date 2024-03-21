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
        private int[][] grid;
        private List<Element> longestCC;
        private List<Element> lccBonds;
        private Dictionary<int, List<int>> extrasPositions;
        private Dictionary<int, List<int>> bondsPositions;
        private static List<int> elementOrderList = new List<int>() { 8, 6, 7, 9, 4 };
        public MoleculeNamer(int[][] grid)
        {
            this.grid = grid;
            update();
        }

        public string moleculeName(int[][] grid)
        {
            string result = "";
            result += extrasNamePart();
            if (result.Length > 0)
            {
                result = result.Substring(0, result.Length - 1);
            }

            result += Element.carbonStems[longestCC.Count]; // stem name
            result += bondsNamePart();

            return result;
        }

        private string extrasNamePart()
        {
            string result = "";
            foreach (int i in elementOrderList)
            {
                extrasPositions.TryGetValue(i, out List<int> positions);
                if (positions != null && positions.Count > 0)
                {
                    string name = Element.counters[positions.Count] + Element.elementNames[i];
                    result += IP.listToString(positions, ",") + "-" + name + "-";
                }

            }
            return result;
            //foreach (KeyValuePair<int, List<int>> kvp in extrasPositions)
            //{
            //    List<int> positions = extrasPositions[kvp.Key];
            //    string name = Element.counters[positions.Count] + Element.elementNames[kvp.Key];
            //    result += IP.listToString(positions, ",") + "-" + name + "-";
            //}
        }

        private string bondsNamePart()
        {
            string result = "";
            if (bondsPositions.Count == 0) result += "an";
            foreach (KeyValuePair<int, List<int>> kvp in bondsPositions)
            {
                bool onlySingleBonds = kvp.Key == 1 && bondsPositions.Count == 1;
                bool singleBond = kvp.Key == 1;
                if (onlySingleBonds)
                {
                    result += "an";
                }
                else if (!singleBond)
                {
                    List<int> positions = bondsPositions[kvp.Key];
                    string name = Element.counters[positions.Count] + Element.elementNames[kvp.Key];
                    result += "-" + IP.listToString(positions, ",") + "-" + name;
                }
            }
            return result;
        }
        private void update()
        {
            longestCC = NH.longestCarbonChain(grid);
            lccBonds = NH.longestCCBonds(longestCC, grid);

            extrasPositions = new Dictionary<int, List<int>>();
            bondsPositions = new Dictionary<int, List<int>>();
            for (int i = 0; i < longestCC.Count; i++)
            {
                Element c = longestCC[i];
                List<Element> neighbors = c.neighboringElements(grid, Element.ALL);
                foreach (Element ne in neighbors)
                {
                    if (!ne.isInList(longestCC))
                    {
                        extrasPositions.AddToList(ne.Type, i + 1);
                    }
                }

                if (i < longestCC.Count - 1)
                {
                    bondsPositions.AddToList(lccBonds[i].Type, i + 1);
                }
            }
        }

    }
}
