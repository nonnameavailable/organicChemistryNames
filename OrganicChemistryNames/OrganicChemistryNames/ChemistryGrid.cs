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
            testInit();
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
                e.draw(g, SqSize);
            }
            return result;
        }

        public void addElement(int x, int y, int type)
        {
            grid[y][x] = type;
        }

        private void testInit()
        {
            
        }
    }
}
