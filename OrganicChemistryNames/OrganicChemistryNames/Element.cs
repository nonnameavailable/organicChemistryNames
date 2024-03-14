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

        public void draw(Graphics g, int sqSize)
        {
            Color textColor = fontColorMap[type];
            Color backgroundColor = backgroundColorMap[type];
            string txt = characterMap[type];
            Font textFont = IP.fontToFitRect(txt, sqSize, sqSize, "Arial");

            int xc = x * sqSize;
            int yc = y * sqSize;

            g.FillRectangle(new SolidBrush(backgroundColor), xc, yc, sqSize, sqSize);
            g.DrawRectangle(new Pen(gridColor, (int)(sqSize * 0.05)), xc, yc, sqSize, sqSize);
            g.DrawString(txt, textFont, new SolidBrush(textColor), xc, yc);
        }
    }
}
