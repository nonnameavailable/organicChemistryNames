using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
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
            grid = new ChemistryGrid(30, 20, 50);
            canvas = grid.renderedGrid();
            mainPictureBox.Image = canvas;

            int buttonSize = (int)(elementFLP.Width * 0.8);
            for(int i = 1; i < Element.characterMap.Length; i++)
            {
                ElementButton eb = new ElementButton(i);
                eb.Width = buttonSize;
                eb.Height = buttonSize;
                if (i == Element.C) eb.IsPainting = true;
                elementFLP.Controls.Add(eb);
            }

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

            string mName = MoleculeNamer.moleculeName(grid.Grid);
            NameRTB.Text = "";
            AppendNameRTB(mName, new Font("Arial", 24), Color.Black, Color.Beige);
            mainPictureBox.Image = grid.renderedGrid();
        }

        private int paintingType()
        {
            foreach(Control c in elementFLP.Controls)
            {
                ElementButton eb = (ElementButton)c;
                if (eb.IsPainting)
                {
                    return eb.Type;
                }
            }
            return 0;
        }

        private void AppendNameRTB(string text, Font selfont, Color color, Color bcolor)
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
    }
}
