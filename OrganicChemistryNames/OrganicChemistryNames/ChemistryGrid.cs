using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace OrganicChemistryNames
{
    class ChemistryGrid
    {
        private int[][] grid;
        private int width;
        private int height;
        private int sqSize;

        public int SqSize { get => sqSize; }
        public int Width { get => width; }
        public int Height { get => height; }


        public ChemistryGrid(int width, int height, int sqSize)
        {
            grid = newGrid(width, height);
            this.sqSize = sqSize;
            this.width = width;
            this.height = height;
        }
        private int[][] newGrid(int width, int height)
        {
            int[][] result = new int[height][];
            for(int j = 0; j < height; j++)
            {
                result[j] = new int[width];
                for(int i = 0; i < width; i++)
                {
                    result[j][i] = 0;
                }
            }
            return result;
        }

        public Bitmap renderedGrid()
        {
            List<Element> elementList = new List<Element>();
            Bitmap result = new Bitmap(width * sqSize, height * sqSize);
            Graphics g = Graphics.FromImage(result);
            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    int x = i * sqSize;
                    int y = j * sqSize;
                    int val = grid[j][i];
                    if (val != 0) elementList.Add(new Element(i, j, val));
                    g.FillRectangle(new SolidBrush(Element.backgroundColorMap[val]), x, y, sqSize, sqSize);
                    g.DrawRectangle(new Pen(Element.gridColor, (int)(sqSize * 0.05)), x, y, sqSize, sqSize);
                }
            }
            foreach(Element e in elementList)
            {
                bool isVerticalBond = e.Type <= 3 && grid[e.Y][e.X + 1] == 0;
                e.draw(g, SqSize, isVerticalBond);
            }
            return result;
        }

        public void addElement(int x, int y, int type)
        {
            int currentElement = grid[y][x];
            int[] nbrDr = neighborDirection(x, y);

            bool emptyGrid = hasNoElements();
            bool hasNoNeighbors = nbrDr[2] == 0;
            bool hasMultipleNeighbors = nbrDr[2] > 1;
            bool clickingOnBond = currentElement > 0 && currentElement <= 3;
            bool typeIsBond = type > 0 && type <= 3;
            bool changingBonds = clickingOnBond && typeIsBond;
            bool elementOnBond = (currentElement > 0 && currentElement <= 3) && !typeIsBond;
            bool bondOnEmpty = typeIsBond && currentElement == 0;
            bool changingElements = currentElement > 3 && type > 3;

            int[][] gridBackup = IP.arrCopy(grid);

            if (type == 0 && !clickingOnBond)
            {
                clearGridPoint(x, y);
                return;
            }

            if ((elementOnBond || bondOnEmpty || hasNoNeighbors || hasMultipleNeighbors) && !emptyGrid && !changingElements) return;

            if (changingBonds || changingElements || emptyGrid)
            {
                grid[y][x] = type;
            }
            else
            {
                attachElement(x, y, type, nbrDr);
            }
            if (!gridIsValid())
            {
                grid = gridBackup;
            }

        }

        private void attachElement(int x, int y, int type, int[] direction)
        {
            grid[y][x] = Element.SINGLE_BOND;
            grid[y + direction[1]][x + direction[0]] = type;
        }

        private void clearGridPoint(int x, int y)
        {
            grid[y][x] = 0;
            grid[y + 1][x] = 0;
            grid[y - 1][x] = 0;
            grid[y][x + 1] = 0;
            grid[y][x - 1] = 0;
        }

        public int getElement(int x, int y)
        {
            return grid[y][x];
        }

        public int[] neighborDirection(int x, int y)
        {
            int[] result = new int[3];
            if(getElement(x, y - 1) > 3)
            {
                result[0] = 0;
                result[1] = 1;
                result[2]++;
            }
            if(getElement(x + 1, y) > 3)
            {
                result[0] = -1;
                result[1] = 0;
                result[2]++;
            }
            if (getElement(x, y + 1) > 3)
            {
                result[0] = 0;
                result[1] = -1;
                result[2]++;
            }
            if (getElement(x - 1, y) > 3)
            {
                result[0] = 1;
                result[1] = 0;
                result[2]++;
            }
            return result;
        }

        private bool hasNoElements()
        {
            for(int j = 0; j < height; j++)
            {
                for(int i = 0; i < width; i++)
                {
                    if (grid[j][i] != 0) return false;
                }
            }
            return true;
        }

        private bool gridIsValid()
        {
            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    int type = grid[j][i];
                    if (type > 3)
                    {
                        int bondCount = 0;
                        bondCount += grid[j - 1][i];
                        bondCount += grid[j][i + 1];
                        bondCount += grid[j + 1][i];
                        bondCount += grid[j][i - 1];
                        if (bondCount > Element.maxBondMap[type]) return false;
                    }
                }
            }
            return true;

        }
    }
}
