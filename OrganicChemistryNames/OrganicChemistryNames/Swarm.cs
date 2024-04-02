using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicChemistryNames
{
    class Swarm
    {
        private int[][] grid;
        private List<Crawler> children;
        private List<Element> lp;
        public Swarm(int x, int y, int[][] grid)
        {
            this.grid = grid;
            children = new List<Crawler>() { new Crawler(x, y) };
            lp = longestPath();
        }

        public List<Element> LongestPath { get => lp; }

        private List<Element> longestPath()
        {
            List<Element> result = children[0].Path;

            bool keepCrawling = true;
            while (keepCrawling)
            {
                keepCrawling = false;
                for (int i = 0; i < children.Count; i++)
                {
                    Crawler c = children[i];
                    if (c.move(grid, children))
                    {
                        keepCrawling = true;
                    } else
                    {
                        if (c.Path.Count > result.Count) result = c.Path;
                    }
                }
            }
            foreach(Crawler c in children)
            {
                if (c.Path.Last().isAldehydeCarbon(grid))
                {
                    return c.Path;
                }
            }
            return result;
        }
    }
}
