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

        public int[] DispImgDims
        {
            get
            {
                double ratio = (double)canvas.Width / (double)mainPictureBox.Width;
                if ((double)canvas.Height / ratio > mainPictureBox.Height)
                {
                    ratio = (double)canvas.Height / (double)mainPictureBox.Height;
                }
                int w = (int)(canvas.Width / ratio);
                int h = (int)(canvas.Height / ratio);
                int[] result = new int[2];
                result[0] = w;
                result[1] = h;
                return result;
            }
        }

        private void mainPictureBox_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            int x = me.X / grid.SqSize;
            int y = me.Y / grid.SqSize;
            if (me.Button == MouseButtons.Left)
            {
                grid.addElement(x, y, paintingType());

            } else if(me.Button == MouseButtons.Right)
            {
                grid.addElement(x, y, 0);
            }

            
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
    }
}
