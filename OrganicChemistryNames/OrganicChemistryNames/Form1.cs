using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace OrganicChemistryNames
{
    public partial class Form1 : Form
    {
        private Bitmap canvas;
        private ChemistryGrid grid;
        public Form1()
        {
            InitializeComponent();
            grid = new ChemistryGrid(30, 20, 50, this);
            canvas = grid.renderedGrid();
            mainPictureBox.Image = canvas;

            for (int i = 1; i < Element.characterMap.Length; i++)
            {
                ElementButton eb = new ElementButton(i);
                if (i == Element.C) eb.IsPainting = true;
                elementFLP.Controls.Add(eb);
            }

        }

        public void repaint()
        {
            mainPictureBox.Image = grid.renderedGrid();
        }

        private void mainPictureBox_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            int x = me.X / grid.SqSize;
            int y = me.Y / grid.SqSize;
            try
            {
                if (me.Button == MouseButtons.Left)
                {
                    grid.addElement(x, y, paintingType());
                }
                else if (me.Button == MouseButtons.Right)
                {
                    grid.addElement(x, y, 0);
                }
            }
            catch (IndexOutOfRangeException)
            {
                //do nothing
            }
            NameRTB.Text = "";
            MoleculeNamer mn = new MoleculeNamer(grid.Grid, 0);
            mn.setMoleculeName(this);
            repaint();
        }

        private int paintingType()
        {
            foreach (Control c in elementFLP.Controls)
            {
                ElementButton eb = (ElementButton)c;
                if (eb.IsPainting)
                {
                    return eb.Type;
                }
            }
            return 0;
        }

        public void AppendNameRTB(string text, Font selfont, Color color, Color bcolor)
        {
            // append the text to the RichTextBox control
            RichTextBox box = NameRTB;
            int start = box.TextLength;
            box.AppendText(text);
            int end = box.TextLength;

            // select the new text
            box.Select(start, end - start);
            // set the attributes of the new text
            box.SelectionColor = color;
            box.SelectionFont = selfont;
            box.SelectionBackColor = bcolor;
            // unselect
            box.Select(end, 0);

            // only required for multi line text to scroll to the end
            box.ScrollToCaret();
        }

        public List<Color> BgColorList
        { 
            get
            {
                List<Color> result = new List<Color>();
                result.Add(emptyCB.Color);
                foreach(ElementButton eb in elementFLP.Controls)
                {
                    result.Add(eb.BgColor);
                }
                return result;
            }
        }
        public List<Color> FontColorList
        {
            get
            {
                List<Color> result = new List<Color>();
                result.Add(gridCB.Color);
                foreach (ElementButton eb in elementFLP.Controls)
                {
                    result.Add(eb.FontColor);
                }
                return result;
            }
        }

        public Color IndexColor { get => indexCB.Color; }
    }
}
