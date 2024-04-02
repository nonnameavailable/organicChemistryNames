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
        public const int O = 10;
        public const int ALL = -2;

        public static string[] characterMap = new string[] { "", "―", "═", "≡", "C", "H", "Cl", "F", "Br", "I", "O" };
        public static int[] maxBondMap = new int[] { -1, 0, 0, 0, 4, 1, 1, 1, 1, 1, 2 };

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
            Color.White, // iodine
            Color.Black
        };
        public static Color[] backgroundColorMap = new Color[]
        {
            Color.White, // empty
            Color.LightGray, // single bond
            Color.LightBlue, // double bond
            Color.Crimson, // triple bond
            Color.Black, // carbon
            Color.White, // hydrogen
            Color.PaleGreen, // chlorine
            Color.LightYellow, // fluor
            Color.DarkRed, // bromine
            Color.DarkViolet, // iodine
            Color.LightBlue
        };

        public static string[] carbonStems = new string[] {"", "meth", "eth", "prop", "but", "pent", "hex", "hept", "okt", "non", "dek",
            "undek", "dodek", "tridek", "tetradek", "pentadek", "hexadek", "heptadek", "oktadek", "nonadek", "ikos" };
        public static string[] counters = new string[] { "", "", "di", "tri", "tetra", "penta", "hexa", "hepta", "okta", "nona", "deka",
        "undeka", "dodeka", "trideka", "tetradeka", "pentadeka", "hexadeka", "heptadeka", "oktadeka", "nonadeka", "ikosa"};
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
        public static string[] elementNames = new string[] { "", "an", "en", "yn", "methyl", "", "chlor", "fluor", "brom", "jod", "oxygen_lol" };

        public Element(int x, int y, int type)
        {
            Type = type;
            X = x;
            Y = y;
            CarbonChainConnection = -1;
        }

        public int Type { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int CarbonChainConnection { get; set; }

        public void draw(Graphics g, int sqSize, bool isRotated, Color backgroundColor, Color textColor, Color gridColor)
        {
            Bitmap miniImage = new Bitmap(sqSize, sqSize);
            Graphics mg = Graphics.FromImage(miniImage);
            if (isRotated) mg.RotateTransform(90);

            string txt = characterMap[Type];
            Font textFont = IP.fontToFitRect(txt, sqSize, sqSize, "Arial");

            int xc = X * sqSize;
            int yc = Y * sqSize;

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
            g.DrawImage(miniImage, X * sqSize, Y * sqSize);
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
            if (X + 2 < maxX && (grid[Y][X + 2] == type || type == Element.ALL) && grid[Y][X + 1] > 0)
            {
                result.Add(new Element(X + 2, Y, grid[Y][X + 2]));
            }
            if (Y - 2 > 0 && (grid[Y - 2][X] == type || type == Element.ALL) && grid[Y - 1][X] > 0)
            {
                result.Add(new Element(X, Y - 2, grid[Y - 2][X]));
            }
            if (Y + 2 < maxY && (grid[Y + 2][X] == type || type == Element.ALL) && grid[Y + 1][X] > 0)
            {
                result.Add(new Element(X, Y + 2, grid[Y + 2][X]));
            }
            if (X - 2 > 0 && (grid[Y][X - 2] == type || type == Element.ALL) && grid[Y][X - 1] > 0)
            {
                result.Add(new Element(X - 2, Y, grid[Y][X - 2]));
            }
            return result;
        }
        public List<Element> neighboringBonds(int[][] grid)
        {
            List<Element> result = new List<Element>();
            if (grid[Y][X + 1] > 0 && grid[Y][X + 1] <= 3)
            {
                result.Add(new Element(X + 1, Y, grid[Y][X + 1]));
            }
            if (grid[Y - 1][X] > 0 && grid[Y - 1][X] <= 3)
            {
                result.Add(new Element(X, Y - 1, grid[Y - 1][X]));
            }
            if (grid[Y + 1][X] > 0 && grid[Y + 1][X] <= 3)
            {
                result.Add(new Element(X, Y + 1, grid[Y + 1][X]));
            }
            if (grid[Y][X - 1] > 0 && grid[Y][X - 1] <= 3)
            {
                result.Add(new Element(X - 1, Y, grid[Y][X - 1]));
            }
            return result;
        }

        public bool hasDoubleBond(int [][] grid)
        {
            foreach(Element e in neighboringBonds(grid))
            {
                if(e.Type == Element.DOUBLE_BOND)
                {
                    return true;
                }
            }
            return false;
        }

        public Element bondBetween(Element e, int[][] grid)
        {
            int xC = (e.X - X) / 2 + X;
            int yC = (e.Y - Y) / 2 + Y;
            Element result = new Element(xC, yC, grid[yC][xC]);
            return result;
        }

        public bool isAlcohol(int[][] grid)
        {
            return Type == Element.O && !hasDoubleBond(grid);
        }

        public bool isAldehydeCarbon(int[][] grid)
        {
            List<Element> nC = neighboringElements(grid, Element.C);
            List<Element> nO = neighboringElements(grid, Element.O);
            return Type == Element.C && nC.Count <= 1 && nO.Count == 1 && nO[0].hasDoubleBond(grid);
        }

        public bool isAldehydeOxygen(int[][] grid)
        {
            List<Element> neighbors = neighboringElements(grid, Element.C);
            if (neighbors.Count == 0) return false;
            return Type == Element.O && hasDoubleBond(grid) && neighbors[0].neighboringElements(grid, Element.C).Count <= 1;
        }

        public bool isKetone(int[][] grid)
        {
            List<Element> neighbors = neighboringElements(grid, Element.C);
            if (neighbors.Count == 0) return false;
            return Type == Element.O && hasDoubleBond(grid) && neighbors[0].neighboringElements(grid, Element.C).Count == 2;
        }
    }
}
