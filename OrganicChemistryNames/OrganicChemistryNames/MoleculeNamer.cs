using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrganicChemistryNames
{
    class MoleculeNamer
    {
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
            foreach(Element c in listOfElements(Element.C, grid))
            {
                if (neighboringCarbons(c.X, c.Y, grid).Count == 1) result.Add(c);
            }
            return result;
        }

        public static List<Element> neighboringCarbons(int x, int y, int[][] grid)
        {
            List<Element> result = new List<Element>();
            int maxX = grid[0].Length - 1;
            int maxY = grid.Length - 1;
            if (x + 2 < maxX && grid[y][x + 2] == Element.C && grid[y][x + 1] > 0)
            {
                result.Add(new Element(x + 2, y, Element.C));
            }
            if (y - 2 > 0 && grid[y - 2][x] == Element.C && grid[y - 1][x] > 0)
            {
                result.Add(new Element(x, y - 2, Element.C));
            }
            if (y + 2 < maxY && grid[y + 2][x] == Element.C && grid[y + 1][x] > 0)
            {
                result.Add(new Element(x, y + 2, Element.C));
            }
            if (x - 2 > 0 && grid[y][x - 2] == Element.C && grid[y][x - 1] > 0)
            {
                result.Add(new Element(x - 2, y, Element.C));
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
                    if (val == type) result.Add(new Element(i, j, val));
                }
            }
            return result;
        }
    }
}
