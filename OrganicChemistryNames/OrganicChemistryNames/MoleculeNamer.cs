using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Specialized;

namespace OrganicChemistryNames
{
    static class MoleculeNamer
    {
        public static string moleculeName(int[][] grid)
        {
            List<Element> longestCC = longestCarbonChain(grid);
            List<Element> lccBonds = longestCCBonds(longestCC, grid);

            Dictionary<int, List<int>> extrasPositions = new Dictionary<int, List<int>>();
            Dictionary<int, List<int>> bondsPositions = new Dictionary<int, List<int>>();
            List<int> elementOrderList = new List<int>() {8, 6, 7, 9, 4};


            for (int i = 0; i < longestCC.Count; i++)
            {
                Element c = longestCC[i];
                List<Element> neighbors = c.neighboringElements(grid, Element.ALL);
                foreach(Element ne in neighbors)
                {
                    if(!ne.isInList(longestCC))
                    {
                        extrasPositions.AddToList(ne.Type, i + 1);
                    }
                }

                if(i < longestCC.Count - 1)
                {
                    bondsPositions.AddToList(lccBonds[i].Type, i + 1);
                }
            }
            //BUILD THE NAME
            string result = "";
            foreach(int i in elementOrderList)
            {
                extrasPositions.TryGetValue(i, out List<int> positions);
                if(positions != null && positions.Count > 0)
                {
                    string name = Element.counters[positions.Count] + Element.elementNames[i];
                    result += IP.listToString(positions, ",") + "-" + name + "-";
                }

            }
            //foreach (KeyValuePair<int, List<int>> kvp in extrasPositions)
            //{
            //    List<int> positions = extrasPositions[kvp.Key];
            //    string name = Element.counters[positions.Count] + Element.elementNames[kvp.Key];
            //    result += IP.listToString(positions, ",") + "-" + name + "-";
            //}
            if (result.Length > 0)
            {
                result = result.Substring(0, result.Length - 1);
            }

            result += Element.carbonStems[longestCC.Count]; // stem name

            if (bondsPositions.Count == 0) result += "an";
            foreach (KeyValuePair<int, List<int>> kvp in bondsPositions)
            {
                bool onlySingleBonds = kvp.Key == 1 && bondsPositions.Count == 1;
                bool singleBond = kvp.Key == 1;
                if (onlySingleBonds)
                {
                    result += "an";
                } else if(!singleBond)
                {
                    List<int> positions = bondsPositions[kvp.Key];
                    string name = Element.counters[positions.Count] + Element.elementNames[kvp.Key];
                    result += "-" + IP.listToString(positions, ",") + "-" + name;
                }
            }
            return result;
        }
        public static List<Element> longestCarbonChain(int[][] grid)
        {
            List<Swarm> swarms = new List<Swarm>();
            foreach (Element ec in endCarbons(grid))
            {
                swarms.Add(new Swarm(ec.X, ec.Y, grid));
            }
            if (swarms.Count == 0) return new List<Element>();

            List<Element> result = swarms[0].LongestPath;
            foreach (Swarm sw in swarms)
            {
                if (sw.LongestPath.Count > result.Count) result = sw.LongestPath;
            }
            return result;
        }
        private static List<Element> endCarbons(int[][] grid)
        {
            List<Element> result = new List<Element>();
            List<Element> allCarbs = listOfElements(Element.C, grid);
            if (allCarbs.Count == 1) return allCarbs;
            foreach (Element c in allCarbs)
            {
                if (c.neighboringElements(grid, Element.C).Count == 1) result.Add(c);
            }
            return result;
        }

        private static List<Element> listOfElements(int type, int[][] grid)
        {
            int width = grid[0].Length;
            int height = grid.Length;
            List<Element> result = new List<Element>();
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    int val = grid[j][i];
                    if (val == type || type == Element.ALL) result.Add(new Element(i, j, val));
                }
            }
            return result;
        }

        private static List<Element> longestCCBonds(List<Element> longestCC, int[][] grid)
        {
            List<Element> result = new List<Element>();
            if (longestCC.Count < 2) return result;
            for(int i = 0; i < longestCC.Count - 1; i++)
            {
                Element currentCarbon = longestCC[i];
                Element nextCarbon = longestCC[i + 1];
                result.Add(currentCarbon.bondBetween(nextCarbon, grid));
            }
            return result;
        }
    }
}
