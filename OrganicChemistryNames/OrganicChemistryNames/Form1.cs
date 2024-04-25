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
using System.Reflection;
namespace OrganicChemistryNames
{
    public partial class Form1 : Form
    {
        private Bitmap canvas;
        private ChemistryGrid grid;
        private PracticeGenerator pg;
        public Form1()
        {
            InitializeComponent();
            grid = new ChemistryGrid(40, 40, 50, this);
            pg = new PracticeGenerator(grid);
            canvas = grid.renderedGrid();
            mainPictureBox.Image = canvas;

            for (int i = 1; i < Element.characterMap.Length; i++)
            {
                ElementButton eb = new ElementButton(i);
                if (i == Element.C) eb.IsPainting = true;
                elementFLP.Controls.Add(eb);
            }
            Width = 1200;
            Height = 900;
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Delete)
            {
                grid.clearGrid();
                repaint();
            } else if (keyData == Keys.P)
            {
                IsInPracticeMode = !IsInPracticeMode;
                repaint();
            } else if(keyData == Keys.N)
            {
                if (IsInPracticeMode)
                {
                    pg.generatePractice();
                    grid.clearGrid();
                }
                repaint();
            } else if(keyData == Keys.U)
            {
                int[][] backup = IP.arrCopy(pg.ChemistryGrid.Grid);
                pg.ChemistryGrid.Grid = grid.Grid;
                grid.Grid = backup;
                repaint();
            } else if(keyData == Keys.H)
            {
                grid.drawHydrogens = !grid.drawHydrogens;
                repaint();
            }
            
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void repaint()
        {
            NameRTB.Text = "";
            if (IsInPracticeMode)
            {
                MoleculeNamer pmn = new MoleculeNamer(pg.ChemistryGrid.Grid, 0);
                pmn.setMoleculeName(this);
                AppendNameRTB(Environment.NewLine);
            }
            TrivialNames tn = new TrivialNames();
            MoleculeNamer mn = new MoleculeNamer(grid.Grid, 0);
            StatusLabel.Text = tn.NameAndUsage(mn.MoleculeNameSimpleString);
            mn.setMoleculeName(this);
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
                    grid.addElement(x, y, paintingType(), Element.SINGLE_BOND);
                }
                else if (me.Button == MouseButtons.Right)
                {
                    grid.addElement(x, y, 0, Element.SINGLE_BOND);
                }
            }
            catch (IndexOutOfRangeException)
            {
                //do nothing
            }
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
        public void AppendNameRTB(string text)
        {
            NameRTB.AppendText(text);
        }

        public List<Color> BgColorList
        {
            get
            {
                List<Color> result = new List<Color>();
                result.Add(emptyCB.Color);
                foreach (ElementButton eb in elementFLP.Controls)
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
        public int PracticeMinLCC { get => (int)minLCCNud.Value; set => minLCCNud.Value = value; }
        public int PracticeMaxLCC { get => (int)maxLCCNud.Value; set => maxLCCNud.Value = value; }
        public int PracticeMinSubLength { get => (int)minSubNud.Value; set => minSubNud.Value = value; }
        public int PracticeMaxSubLength { get => (int)maxSubNud.Value; set => maxSubNud.Value = value; }
        public int PracticeStartX { get => (int)startXNud.Value; set => startXNud.Value = value; }
        public int PracticeStartY { get => (int)startYNud.Value; set => startYNud.Value = value; }
        public int PracticeSubChance { get => (int)subChanceNud.Value; set => subChanceNud.Value = value; }
        public int PracticeBondChance { get => (int)bondChanceNud.Value; set => bondChanceNud.Value = value; }
        public int PracticeCarbonCount { get => (int)carbonCountNud.Value; set => carbonCountNud.Value = value; }
        public bool PracticeIncludeCarbons { get => includeCarbonCB.Checked; set => includeCarbonCB.Checked = value; }
        public bool PracticeIncludeHalogens { get => includeHalogensCB.Checked; set => includeHalogensCB.Checked = value; }
        public bool PracticeIncludeOxygen { get => includeOxygenCB.Checked; set => includeOxygenCB.Checked = value; }
        public bool PracticeGuaranteeCAcid { get => guaranteeCAcidCB.Checked; set => guaranteeCAcidCB.Checked = value; }
        public bool IsInPracticeMode { get; set; }

        private void minLCCNud_ValueChanged(object sender, EventArgs e)
        {
            if (minLCCNud.Value > maxLCCNud.Value) minLCCNud.Value = maxLCCNud.Value;
        }

        private void maxLCCNud_ValueChanged(object sender, EventArgs e)
        {
            if (maxLCCNud.Value < minLCCNud.Value) maxLCCNud.Value = minLCCNud.Value;
        }

        private void minSubNud_ValueChanged(object sender, EventArgs e)
        {
            if (minSubNud.Value > maxSubNud.Value) minSubNud.Value = maxSubNud.Value;
        }

        private void maxSubNud_ValueChanged(object sender, EventArgs e)
        {
            if (maxSubNud.Value < minSubNud.Value) maxSubNud.Value = minSubNud.Value;
        }
    }


}
