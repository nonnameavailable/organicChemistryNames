﻿using System;
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
    public partial class ElementButton : UserControl
    {
        private int type;
        private bool isPainting;
        public ElementButton(int type)
        {
            InitializeComponent();

            this.type = type;
            this.Resize += ElementButton_Resize;
            backCB.Color = Element.backgroundColorMap[type];
            fontCB.Color = Element.fontColorMap[type];
            repaint();
        }

        private void ElementButton_Resize(object sender, EventArgs e)
        {
            repaint();
        }

        public void repaint()
        {
            string elemText = Element.characterMap[type];
            Font selectButtonFont = IP.fontToFitRectSmaller(elemText, Width, Height, "Arial");
            SelectButton.Font = selectButtonFont;
            SelectButton.Text = elemText;
            SelectButton.BackColor = backCB.Color;
            SelectButton.ForeColor = fontCB.Color;
        }

        public int Type { get => type; set => type = value; }
        public bool IsPainting { get => isPainting; set => isPainting = value; }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            foreach(ElementButton eb in Parent.Controls)
            {
                if (!this.Equals(eb))
                {
                    eb.IsPainting = false;
                }
                IsPainting = true;
            }
        }
        public Color BgColor { get => backCB.Color; }
        public Color FontColor { get => fontCB.Color; }
    }
}
