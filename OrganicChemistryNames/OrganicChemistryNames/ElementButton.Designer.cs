
namespace OrganicChemistryNames
{
    partial class ElementButton
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SelectButton = new System.Windows.Forms.Button();
            this.backCB = new OrganicChemistryNames.ColorButton();
            this.fontCB = new OrganicChemistryNames.ColorButton();
            this.SuspendLayout();
            // 
            // SelectButton
            // 
            this.SelectButton.Location = new System.Drawing.Point(3, 3);
            this.SelectButton.Name = "SelectButton";
            this.SelectButton.Size = new System.Drawing.Size(69, 67);
            this.SelectButton.TabIndex = 0;
            this.SelectButton.Text = "ElemText";
            this.SelectButton.UseVisualStyleBackColor = true;
            this.SelectButton.Click += new System.EventHandler(this.SelectButton_Click);
            // 
            // backCB
            // 
            this.backCB.Color = System.Drawing.SystemColors.Control;
            this.backCB.Location = new System.Drawing.Point(78, 38);
            this.backCB.Name = "backCB";
            this.backCB.Size = new System.Drawing.Size(31, 32);
            this.backCB.TabIndex = 2;
            // 
            // fontCB
            // 
            this.fontCB.Color = System.Drawing.SystemColors.Control;
            this.fontCB.Location = new System.Drawing.Point(78, 3);
            this.fontCB.Name = "fontCB";
            this.fontCB.Size = new System.Drawing.Size(31, 32);
            this.fontCB.TabIndex = 1;
            // 
            // ElementButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.backCB);
            this.Controls.Add(this.fontCB);
            this.Controls.Add(this.SelectButton);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ElementButton";
            this.Size = new System.Drawing.Size(113, 73);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SelectButton;
        private ColorButton fontCB;
        private ColorButton backCB;
    }
}
