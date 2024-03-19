using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrganicChemistryNames
{
    static class MoleculeNamer
    {
        public static string moleculeName(int[][] grid)
        {
            string result = "";
            List<Element> longestCC = longestCarbonChain(grid);
            MessageBox.Show(longestCC.Count.ToString());
            Dictionary<int, int> extrasCounts = new Dictionary<int, int>();
            Dictionary<int, List<int>> extrasPositions = new Dictionary<int, List<int>>();
            for(int i = 0; i < longestCC.Count; i++)
            {
                Element c = longestCC[i];
                List<Element> neighbors = neighboringElements(c.X, c.Y, grid, Element.ALL);
                foreach(Element ne in neighbors)
                {
                    if(!elementIsInList(ne, longestCC))
                    {
                        extrasCounts.Increment(ne.Type);
                        extrasPositions.AddToList(ne.Type, i + 1);
                    }
                }
            }
            foreach(KeyValuePair<int, int> kvp in extrasCounts)
            {
                //result += Element.characterMap[kvp.Key] + " : " + kvp.Value + " x positions: " + IP.listToString(extrasPositions[kvp.Key], ",") + Environment.NewLine;
                List<int> positions = extrasPositions[kvp.Key];
                string name = Element.counters[positions.Count] + Element.elementNames[kvp.Key];
                result += IP.listToString(positions, ",") + "-" + name + "-";
            }
            if (result.Length > 0)
            {
                result = result.Substring(0, result.Length - 1);
            }

            result += Element.carbonStems[longestCC.Count] + Element.elementNames[1]; //THE 1 IS TEMPORARY
            return result;
        }
        public static List<Element> longestCarbonChain(int[][] grid)
        {
            List<Element> result = new List<Element>();
            List<Crawler> swarm = new List<Crawler>();
            foreach(Element ec in endCarbons(grid))
            {
                swarm.Add(new Crawler(ec.X, ec.Y));
            }

            for(int i = 0; i < 50; i++)
            {
                for (int j = 0; j < swarm.Count; j++)
                {
                    Crawler cc = swarm[j];
                    cc.move(grid, swarm);
                }
            }

            int longestPath = 0;
            foreach(Crawler cr in swarm)
            {
                if (cr.Path.Count > longestPath)
                {
                    longestPath = cr.Path.Count;
                    result = cr.Path;
                }

            }
            return result;
        }
        public static List<Element> endCarbons(int[][] grid)
        {
            List<Element> result = new List<Element>();
            List<Element> allCarbs = listOfElements(Element.C, grid);
            if (allCarbs.Count == 1) return allCarbs;
            foreach (Element c in allCarbs)
            {
                if (neighboringElements(c.X, c.Y, grid, Element.C).Count == 1) result.Add(c);
            }
            return result;
        }

        public static List<Element> neighboringElements(int x, int y, int[][] grid, int type)
        {
            List<Element> result = new List<Element>();
            int maxX = grid[0].Length - 1;
            int maxY = grid.Length - 1;
            if (x + 2 < maxX && (grid[y][x + 2] == type || type  == Element.ALL) && grid[y][x + 1] > 0)
            {
                result.Add(new Element(x + 2, y, grid[y][x + 2]));
            }
            if (y - 2 > 0 && (grid[y - 2][x] == Element.C || type == Element.ALL) && grid[y - 1][x] > 0)
            {
                result.Add(new Element(x, y - 2, grid[y - 2][x]));
            }
            if (y + 2 < maxY && (grid[y + 2][x] == Element.C || type == Element.ALL) && grid[y + 1][x] > 0)
            {
                result.Add(new Element(x, y + 2, grid[y + 2][x]));
            }
            if (x - 2 > 0 && (grid[y][x - 2] == Element.C || type == Element.ALL) && grid[y][x - 1] > 0)
            {
                result.Add(new Element(x - 2, y, grid[y][x - 2]));
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
        private static bool elementIsInList(Element e, List<Element> list)
        {
            foreach(Element le in list)
            {
                if (le.Equals(e)) return true;
            }
            return false;
        }
    }
}
