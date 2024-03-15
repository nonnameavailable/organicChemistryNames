using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

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

        public static Color gridColor = Color.FromArgb(220, 220, 220);
        public static string[] characterMap = new string[] { "", "―", "═", "≡", "C", "H", "Cl", "F", "Br", "I" };
        public static int[] maxBondMap = new int[] { -1, 0, 0, 0, 4, 1, 1, 1, 1};
        public static Color[] fontColorMap = new Color[] { Color.White, Color.Black, Color.Black, Color.Black, Color.Black, Color.Black, Color.Blue, Color.Blue, Color.Blue, Color.Blue };
        public static Color[] backgroundColorMap = new Color[] { Color.White, Color.White, Color.White, Color.White, Color.White, Color.White, Color.White, Color.White, Color.White, Color.White };

        private int type;
        private int x;
        private int y;
        private string text;

        public Element(int x, int y, int type)
        {
            this.type = type;
            this.x = x;
            this.y = y;
        }

        public int Type { get => type; set => type = value; }
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }

        public void draw(Graphics g, int sqSize, bool isRotated)
        {
            Bitmap miniImage = new Bitmap(sqSize, sqSize);
            Graphics mg = Graphics.FromImage(miniImage);
            if (isRotated) mg.RotateTransform(90);

            Color textColor = fontColorMap[type];
            Color backgroundColor = backgroundColorMap[type];
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
    }
}
