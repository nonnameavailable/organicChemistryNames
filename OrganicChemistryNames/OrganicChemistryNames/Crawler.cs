using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrganicChemistryNames
{
    class Crawler
    {
        private int x;
        private int y;
        private int counter;
        private List<Element> path;
        private bool canMove;
        public Crawler(int x, int y)
        {
            this.x = x;
            this.y = y;
            path = new List<Element>();
            path.Add(new Element(x, y, Element.C));
            canMove = true;
        }

        public void move(int[][] grid, List<Crawler> swarm)
        {
            if (!canMove) return;
            List<Element> neighboringCarbons = MoleculeNamer.neighboringCarbons(x, y, grid);
            int neighborCount = neighboringCarbons.Count;
            Element lastPath = path.Count > 1 ? path[path.Count - 2] : path.Last();
            bool lastPathIsOnlyNeighbor = neighborCount == 1 && lastPath.Equals(neighboringCarbons[0]);
            bool shouldSpawn = neighboringCarbons.Count > 2;
            if (lastPathIsOnlyNeighbor)
            {
                canMove = false;
                return;
            }
            if (shouldSpawn)
            {
                foreach(Element e in neighboringCarbons)
                {
                    if (!e.Equals(lastPath))
                    {
                        Crawler cr = new Crawler(e.X, e.Y);
                        cr.Path = pathCopy();
                        cr.Path.Add(new Element(e.X, e.Y, Element.C));
                        swarm.Add(cr);
                    }
                }
                canMove = false;
                return;
            }
            Element c = neighboringCarbons[0].Equals(lastPath) ? neighboringCarbons[1] : neighboringCarbons[0];
            path.Add(c);
            x = c.X;
            y = c.Y;
        }

        private List<Element> pathCopy()
        {
            List<Element> result = new List<Element>();
            foreach(Element e in path)
            {
                result.Add(new Element(e.X, e.Y, e.Type));
            }
            return result;
        }

        private string listToString(List<Element> list)
        {
            string result = Environment.NewLine;
            foreach(Element e in list)
            {
                result += e.X + " x " + e.Y + System.Environment.NewLine;
            }
            return result;
        }

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int Counter { get => counter; set => counter = value; }
        public List<Element> Path { get => path; set => path = value; }
        public bool CanMove { get => canMove; set => canMove = value; }
    }
}
