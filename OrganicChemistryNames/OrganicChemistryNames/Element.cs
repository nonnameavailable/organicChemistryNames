using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace OrganicChemistryNames
{
    class Element
    {
        public const int EMPTY = 0;
        public const int SINGLE_BOND = 1;
        public const int DOUBLE_BOND = 2;
        public const int TRIPLE_BOND = 3;
        public const int C = 4;
        public const int H = 5;
        public const int Cl = 6;
        public const int F = 7;
        public const int Br = 8;
        public const int I = 9;
        public const int ALL = -2;

        public static string[] characterMap = new string[] { "", "―", "═", "≡", "C", "H", "Cl", "F", "Br", "I" };
        public static int[] maxBondMap = new int[] { -1, 0, 0, 0, 4, 1, 1, 1, 1, 1 };

        public static Color[] fontColorMap = new Color[]
        {
            Color.White, // empty
            Color.Black, // single bond
            Color.Black, // double bond
            Color.Black, // triple bond
            Color.White, // carbon
            Color.Black, // hydrogen
            Color.Black, // chlorine
            Color.Black, // fluor
            Color.White, // bromine
            Color.White // iodine
        };
        public static Color[] backgroundColorMap = new Color[]
        {
            Color.White, // empty
            Color.White, // single bond
            Color.White, // double bond
            Color.White, // triple bond
            Color.Black, // carbon
            Color.White, // hydrogen
            Color.PaleGreen, // chlorine
            Color.LightYellow, // fluor
            Color.DarkRed, // bromine
            Color.DarkViolet // iodine
        };

        public static string[] carbonStems = new string[] {"", "meth", "eth", "prop", "but", "pent", "hex", "hept", "okt", "non", "dek",
            "undek", "dodek", "tridek", "tetradek", "pentadek", "hexadek", "heptadek", "oktadek", "nonadek", "ikos" };
        public static string[] counters = new string[] { "", "", "di", "tri", "tetra", "penta", "hexa", "hepta", "okta", "nona", "deka"};
        public static string[] complexCounters = new string[] {
            "",
            "",
            "bis",
            "tris",
            "tetrakis",
            "pentakis",
            "hexakis",
            "heptakis",
            "octakis",
            "enneakis",
            "decakis",
            "undecakis",
            "dodecakis",
            "tridecakis",
            "tetradekakis",
            "pentadekakis",
            "hexadekakis",
            "heptadekakis",
            "octadekakis",
            "nonadekakis",
            "icosakis"
        };
        public static string[] elementNames = new string[] { "", "an", "en", "yn", "methyl", "", "chlor", "fluor", "brom", "jod" };


        private int type;
        private int x;
        private int y;
        private int carbonChainConnection;

        public Element(int x, int y, int type)
        {
            this.type = type;
            this.x = x;
            this.y = y;
            carbonChainConnection = -1;
        }

        public int Type { get => type; set => type = value; }
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int CarbonChainConnection { get => carbonChainConnection; set => carbonChainConnection = value; }

        public void draw(Graphics g, int sqSize, bool isRotated, Color backgroundColor, Color textColor, Color gridColor)
        {
            Bitmap miniImage = new Bitmap(sqSize, sqSize);
            Graphics mg = Graphics.FromImage(miniImage);
            if (isRotated) mg.RotateTransform(90);

            string txt = characterMap[type];
            Font textFont = IP.fontToFitRect(txt, sqSize, sqSize, "Arial");

            int xc = x * sqSize;
            int yc = y * sqSize;

            int ox = 0;
            int oy = isRotated ? -sqSize : 0;

            

            mg.FillRectangle(new SolidBrush(backgroundColor), ox, oy, sqSize, sqSize);
            mg.DrawRectangle(new Pen(gridColor, (int)(sqSize * 0.05)), ox, oy, sqSize, sqSize);
            mg.DrawString(txt, textFont, new SolidBrush(textColor), ox, oy);
            
            mg.Dispose();
            g.DrawImage(miniImage, xc, yc);
            miniImage.Dispose();
        }

        public void drawIndex(Graphics g, int sqSize, string indexText, Color fontColor)
        {
            Bitmap miniImage = new Bitmap(sqSize, sqSize);
            Graphics mg = Graphics.FromImage(miniImage);

            mg.DrawString(indexText, new Font("Arial", (float)(sqSize * 0.2), FontStyle.Bold), new SolidBrush(fontColor), 0, 0);

            mg.Dispose();
            g.DrawImage(miniImage, x * sqSize, y * sqSize);
            miniImage.Dispose();
        }

        public bool Equals(Element e)
        {
            return X == e.X && Y == e.Y;
        }
        public bool isInList(List<Element> list)
        {
            foreach (Element le in list)
            {
                if (Equals(le)) return true;
            }
            return false;
        }

        public List<Element> neighboringElements(int[][] grid, int type)
        {
            List<Element> result = new List<Element>();
            int maxX = grid[0].Length - 1;
            int maxY = grid.Length - 1;
            if (x + 2 < maxX && (grid[y][x + 2] == type || type == Element.ALL) && grid[y][x + 1] > 0)
            {
                result.Add(new Element(x + 2, y, grid[y][x + 2]));
            }
            if (y - 2 > 0 && (grid[y - 2][x] == type || type == Element.ALL) && grid[y - 1][x] > 0)
            {
                result.Add(new Element(x, y - 2, grid[y - 2][x]));
            }
            if (y + 2 < maxY && (grid[y + 2][x] == type || type == Element.ALL) && grid[y + 1][x] > 0)
            {
                result.Add(new Element(x, y + 2, grid[y + 2][x]));
            }
            if (x - 2 > 0 && (grid[y][x - 2] == type || type == Element.ALL) && grid[y][x - 1] > 0)
            {
                result.Add(new Element(x - 2, y, grid[y][x - 2]));
            }
            return result;
        }
        public List<Element> neighboringBonds(int[][] grid)
        {
            List<Element> result = new List<Element>();
            int maxX = grid[0].Length - 1;
            int maxY = grid.Length - 1;
            if (grid[y][x + 1] > 0 && grid[y][x + 1] <= 3)
            {
                result.Add(new Element(x + 1, y, grid[y][x + 1]));
            }
            if (grid[y - 1][x] > 0 && grid[y - 1][x] <= 3)
            {
                result.Add(new Element(x, y - 1, grid[y - 1][x]));
            }
            if (grid[y + 1][x] > 0 && grid[y + 1][x] <= 3)
            {
                result.Add(new Element(x, y + 1, grid[y + 1][x]));
            }
            if (grid[y][x - 1] > 0 && grid[y][x - 1] <= 3)
            {
                result.Add(new Element(x - 1, y, grid[y][x - 1]));
            }
            return result;
        }

        public Element bondBetween(Element e, int[][] grid)
        {
            int xC = (e.X - x) / 2 + x;
            int yC = (e.Y - y) / 2 + y;
            Element result = new Element(xC, yC, grid[yC][xC]);
            return result;
        }
    }
}
