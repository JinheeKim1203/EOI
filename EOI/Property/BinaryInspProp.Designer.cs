namespace EOI.Property
{
    partial class BinaryInspProp
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
                if (trackBarLower != null)
                    trackBarLower.ValueChanged -= OnValueChanged;

                if (trackBarUpper != null)
                    trackBarUpper.ValueChanged -= OnValueChanged;

                if (txtAreaMin != null)
                    txtAreaMin.Leave -= OnFilterChanged;

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
            this.grpBinary = new System.Windows.Forms.GroupBox();
            this.chkShowBinary = new System.Windows.Forms.CheckBox();
            this.chkInvert = new System.Windows.Forms.CheckBox();
            this.chkHighlight = new System.Windows.Forms.CheckBox();
            this.trackBarUpper = new System.Windows.Forms.TrackBar();
            this.trackBarLower = new System.Windows.Forms.TrackBar();
            this.grpFilter = new System.Windows.Forms.GroupBox();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.lbCount = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtHeightMax = new System.Windows.Forms.TextBox();
            this.txtWidthMax = new System.Windows.Forms.TextBox();
            this.txtAreaMax = new System.Windows.Forms.TextBox();
            this.txtHeightMin = new System.Windows.Forms.TextBox();
            this.lbHeight = new System.Windows.Forms.Label();
            this.txtWidthMin = new System.Windows.Forms.TextBox();
            this.lbWidth = new System.Windows.Forms.Label();
            this.txtAreaMin = new System.Windows.Forms.TextBox();
            this.lbArea = new System.Windows.Forms.Label();
            this.txtIteration = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkShowDeNoise = new System.Windows.Forms.CheckBox();
            this.grpBinary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarUpper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLower)).BeginInit();
            this.grpFilter.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBinary
            // 
            this.grpBinary.Controls.Add(this.chkShowBinary);
            this.grpBinary.Controls.Add(this.chkInvert);
            this.grpBinary.Controls.Add(this.chkHighlight);
            this.grpBinary.Controls.Add(this.trackBarUpper);
            this.grpBinary.Controls.Add(this.trackBarLower);
            this.grpBinary.Location = new System.Drawing.Point(3, 4);
            this.grpBinary.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpBinary.Name = "grpBinary";
            this.grpBinary.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpBinary.Size = new System.Drawing.Size(286, 215);
            this.grpBinary.TabIndex = 0;
            this.grpBinary.TabStop = false;
            this.grpBinary.Text = "이진화";
            // 
            // chkShowBinary
            // 
            this.chkShowBinary.AutoSize = true;
            this.chkShowBinary.Location = new System.Drawing.Point(143, 156);
            this.chkShowBinary.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkShowBinary.Name = "chkShowBinary";
            this.chkShowBinary.Size = new System.Drawing.Size(74, 19);
            this.chkShowBinary.TabIndex = 5;
            this.chkShowBinary.Text = "이진화";
            this.chkShowBinary.UseVisualStyleBackColor = true;
            this.chkShowBinary.CheckedChanged += new System.EventHandler(this.chkBinaryOnly_CheckedChanged);
            // 
            // chkInvert
            // 
            this.chkInvert.AutoSize = true;
            this.chkInvert.Location = new System.Drawing.Point(26, 185);
            this.chkInvert.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkInvert.Name = "chkInvert";
            this.chkInvert.Size = new System.Drawing.Size(59, 19);
            this.chkInvert.TabIndex = 4;
            this.chkInvert.Text = "반전";
            this.chkInvert.UseVisualStyleBackColor = true;
            this.chkInvert.CheckedChanged += new System.EventHandler(this.chkInvert_CheckedChanged);
            // 
            // chkHighlight
            // 
            this.chkHighlight.AutoSize = true;
            this.chkHighlight.Checked = true;
            this.chkHighlight.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHighlight.Location = new System.Drawing.Point(26, 156);
            this.chkHighlight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkHighlight.Name = "chkHighlight";
            this.chkHighlight.Size = new System.Drawing.Size(84, 19);
            this.chkHighlight.TabIndex = 3;
            this.chkHighlight.Text = "Highlight";
            this.chkHighlight.UseVisualStyleBackColor = true;
            this.chkHighlight.CheckedChanged += new System.EventHandler(this.chkHighlight_CheckedChanged);
            // 
            // trackBarUpper
            // 
            this.trackBarUpper.Location = new System.Drawing.Point(26, 92);
            this.trackBarUpper.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.trackBarUpper.Maximum = 255;
            this.trackBarUpper.Name = "trackBarUpper";
            this.trackBarUpper.Size = new System.Drawing.Size(250, 56);
            this.trackBarUpper.TabIndex = 1;
            this.trackBarUpper.Value = 255;
            // 
            // trackBarLower
            // 
            this.trackBarLower.Location = new System.Drawing.Point(26, 29);
            this.trackBarLower.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.trackBarLower.Maximum = 255;
            this.trackBarLower.Name = "trackBarLower";
            this.trackBarLower.Size = new System.Drawing.Size(250, 56);
            this.trackBarLower.TabIndex = 0;
            // 
            // grpFilter
            // 
            this.grpFilter.Controls.Add(this.txtCount);
            this.grpFilter.Controls.Add(this.lbCount);
            this.grpFilter.Controls.Add(this.label5);
            this.grpFilter.Controls.Add(this.label3);
            this.grpFilter.Controls.Add(this.label1);
            this.grpFilter.Controls.Add(this.txtHeightMax);
            this.grpFilter.Controls.Add(this.txtWidthMax);
            this.grpFilter.Controls.Add(this.txtAreaMax);
            this.grpFilter.Controls.Add(this.txtHeightMin);
            this.grpFilter.Controls.Add(this.lbHeight);
            this.grpFilter.Controls.Add(this.txtWidthMin);
            this.grpFilter.Controls.Add(this.lbWidth);
            this.grpFilter.Controls.Add(this.txtAreaMin);
            this.grpFilter.Controls.Add(this.lbArea);
            this.grpFilter.Location = new System.Drawing.Point(5, 240);
            this.grpFilter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpFilter.Size = new System.Drawing.Size(285, 170);
            this.grpFilter.TabIndex = 1;
            this.grpFilter.TabStop = false;
            this.grpFilter.Text = "필터";
            // 
            // txtCount
            // 
            this.txtCount.Location = new System.Drawing.Point(82, 125);
            this.txtCount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(65, 25);
            this.txtCount.TabIndex = 5;
            // 
            // lbCount
            // 
            this.lbCount.AutoSize = true;
            this.lbCount.Location = new System.Drawing.Point(23, 129);
            this.lbCount.Name = "lbCount";
            this.lbCount.Size = new System.Drawing.Size(46, 15);
            this.lbCount.TabIndex = 4;
            this.lbCount.Text = "Count";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(154, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "~";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(154, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "~";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(154, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "~";
            // 
            // txtHeightMax
            // 
            this.txtHeightMax.Location = new System.Drawing.Point(177, 90);
            this.txtHeightMax.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtHeightMax.Name = "txtHeightMax";
            this.txtHeightMax.Size = new System.Drawing.Size(62, 25);
            this.txtHeightMax.TabIndex = 2;
            // 
            // txtWidthMax
            // 
            this.txtWidthMax.Location = new System.Drawing.Point(177, 56);
            this.txtWidthMax.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtWidthMax.Name = "txtWidthMax";
            this.txtWidthMax.Size = new System.Drawing.Size(62, 25);
            this.txtWidthMax.TabIndex = 2;
            // 
            // txtAreaMax
            // 
            this.txtAreaMax.Location = new System.Drawing.Point(177, 22);
            this.txtAreaMax.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAreaMax.Name = "txtAreaMax";
            this.txtAreaMax.Size = new System.Drawing.Size(62, 25);
            this.txtAreaMax.TabIndex = 2;
            // 
            // txtHeightMin
            // 
            this.txtHeightMin.Location = new System.Drawing.Point(82, 90);
            this.txtHeightMin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtHeightMin.Name = "txtHeightMin";
            this.txtHeightMin.Size = new System.Drawing.Size(65, 25);
            this.txtHeightMin.TabIndex = 1;
            // 
            // lbHeight
            // 
            this.lbHeight.AutoSize = true;
            this.lbHeight.Location = new System.Drawing.Point(23, 94);
            this.lbHeight.Name = "lbHeight";
            this.lbHeight.Size = new System.Drawing.Size(48, 15);
            this.lbHeight.TabIndex = 0;
            this.lbHeight.Text = "Height";
            // 
            // txtWidthMin
            // 
            this.txtWidthMin.Location = new System.Drawing.Point(82, 56);
            this.txtWidthMin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtWidthMin.Name = "txtWidthMin";
            this.txtWidthMin.Size = new System.Drawing.Size(65, 25);
            this.txtWidthMin.TabIndex = 1;
            // 
            // lbWidth
            // 
            this.lbWidth.AutoSize = true;
            this.lbWidth.Location = new System.Drawing.Point(23, 60);
            this.lbWidth.Name = "lbWidth";
            this.lbWidth.Size = new System.Drawing.Size(44, 15);
            this.lbWidth.TabIndex = 0;
            this.lbWidth.Text = "Width";
            // 
            // txtAreaMin
            // 
            this.txtAreaMin.Location = new System.Drawing.Point(82, 22);
            this.txtAreaMin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAreaMin.Name = "txtAreaMin";
            this.txtAreaMin.Size = new System.Drawing.Size(65, 25);
            this.txtAreaMin.TabIndex = 1;
            // 
            // lbArea
            // 
            this.lbArea.AutoSize = true;
            this.lbArea.Location = new System.Drawing.Point(23, 26);
            this.lbArea.Name = "lbArea";
            this.lbArea.Size = new System.Drawing.Size(36, 15);
            this.lbArea.TabIndex = 0;
            this.lbArea.Text = "Area";
            // 
            // txtIteration
            // 
            this.txtIteration.Location = new System.Drawing.Point(88, 27);
            this.txtIteration.Name = "txtIteration";
            this.txtIteration.Size = new System.Drawing.Size(157, 25);
            this.txtIteration.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 447);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Iteration";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkShowDeNoise);
            this.groupBox1.Controls.Add(this.txtIteration);
            this.groupBox1.Location = new System.Drawing.Point(5, 417);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(285, 135);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "침식,팽창";
            // 
            // chkShowDeNoise
            // 
            this.chkShowDeNoise.AutoSize = true;
            this.chkShowDeNoise.Location = new System.Drawing.Point(24, 74);
            this.chkShowDeNoise.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkShowDeNoise.Name = "chkShowDeNoise";
            this.chkShowDeNoise.Size = new System.Drawing.Size(129, 19);
            this.chkShowDeNoise.TabIndex = 5;
            this.chkShowDeNoise.Text = "침식,팽창 적용";
            this.chkShowDeNoise.UseVisualStyleBackColor = true;
            this.chkShowDeNoise.CheckedChanged += new System.EventHandler(this.chkDeNoiseOnly_CheckedChanged);
            // 
            // BinaryInspProp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.grpFilter);
            this.Controls.Add(this.grpBinary);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "BinaryInspProp";
            this.Size = new System.Drawing.Size(310, 578);
            this.grpBinary.ResumeLayout(false);
            this.grpBinary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarUpper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLower)).EndInit();
            this.grpFilter.ResumeLayout(false);
            this.grpFilter.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBinary;
        private System.Windows.Forms.TrackBar trackBarUpper;
        private System.Windows.Forms.TrackBar trackBarLower;
        private System.Windows.Forms.CheckBox chkHighlight;
        private System.Windows.Forms.CheckBox chkInvert;
        private System.Windows.Forms.GroupBox grpFilter;
        private System.Windows.Forms.TextBox txtAreaMin;
        private System.Windows.Forms.Label lbArea;
        private System.Windows.Forms.CheckBox chkShowBinary;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHeightMax;
        private System.Windows.Forms.TextBox txtWidthMax;
        private System.Windows.Forms.TextBox txtAreaMax;
        private System.Windows.Forms.TextBox txtHeightMin;
        private System.Windows.Forms.Label lbHeight;
        private System.Windows.Forms.TextBox txtWidthMin;
        private System.Windows.Forms.Label lbWidth;
        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.Label lbCount;
        private System.Windows.Forms.TextBox txtIteration;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkShowDeNoise;
    }
}
