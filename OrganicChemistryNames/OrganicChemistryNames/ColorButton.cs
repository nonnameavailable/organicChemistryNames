using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrganicChemistryNames
{
    public partial class ColorButton : UserControl
    {
        public ColorButton(Color c)
        {
            InitializeComponent();
            Color = c;
        }
        public ColorButton()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color = colorDialog1.Color;
                ((Form1)FindForm()).repaint();
            }
        }
        public Color Color { get => button.BackColor; set => button.BackColor = value; }
    }
}
