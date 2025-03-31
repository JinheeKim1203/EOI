namespace EOI.Property
{
    partial class MatchInspProp
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
                txtExtendX.Leave -= OnUpdateValue;
                txtExtendY.Leave -= OnUpdateValue;
                txtScore.Leave -= OnUpdateValue;
                txtMatchCount.Leave -= OnUpdateValue;

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
            this.grpMatch = new System.Windows.Forms.GroupBox();
            this.picTeachImage = new System.Windows.Forms.PictureBox();
            this.txtMatchCount = new System.Windows.Forms.TextBox();
            this.lbMatchCount = new System.Windows.Forms.Label();
            this.lbScore = new System.Windows.Forms.Label();
            this.txtExtendY = new System.Windows.Forms.TextBox();
            this.txtScore = new System.Windows.Forms.TextBox();
            this.txtExtendX = new System.Windows.Forms.TextBox();
            this.lbX = new System.Windows.Forms.Label();
            this.lbExtent = new System.Windows.Forms.Label();
            this.grpMatch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTeachImage)).BeginInit();
            this.SuspendLayout();
            // 
            // grpMatch
            // 
            this.grpMatch.Controls.Add(this.picTeachImage);
            this.grpMatch.Controls.Add(this.txtMatchCount);
            this.grpMatch.Controls.Add(this.lbMatchCount);
            this.grpMatch.Controls.Add(this.lbScore);
            this.grpMatch.Controls.Add(this.txtExtendY);
            this.grpMatch.Controls.Add(this.txtScore);
            this.grpMatch.Controls.Add(this.txtExtendX);
            this.grpMatch.Controls.Add(this.lbX);
            this.grpMatch.Controls.Add(this.lbExtent);
            this.grpMatch.Location = new System.Drawing.Point(3, 4);
            this.grpMatch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpMatch.Name = "grpMatch";
            this.grpMatch.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpMatch.Size = new System.Drawing.Size(338, 331);
            this.grpMatch.TabIndex = 0;
            this.grpMatch.TabStop = false;
            this.grpMatch.Text = "패턴매칭";
            // 
            // picTeachImage
            // 
            this.picTeachImage.Location = new System.Drawing.Point(13, 133);
            this.picTeachImage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.picTeachImage.Name = "picTeachImage";
            this.picTeachImage.Size = new System.Drawing.Size(192, 180);
            this.picTeachImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picTeachImage.TabIndex = 7;
            this.picTeachImage.TabStop = false;
            // 
            // txtMatchCount
            // 
            this.txtMatchCount.Location = new System.Drawing.Point(99, 88);
            this.txtMatchCount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMatchCount.Name = "txtMatchCount";
            this.txtMatchCount.Size = new System.Drawing.Size(57, 25);
            this.txtMatchCount.TabIndex = 5;
            // 
            // lbMatchCount
            // 
            this.lbMatchCount.AutoSize = true;
            this.lbMatchCount.Location = new System.Drawing.Point(10, 91);
            this.lbMatchCount.Name = "lbMatchCount";
            this.lbMatchCount.Size = new System.Drawing.Size(72, 15);
            this.lbMatchCount.TabIndex = 4;
            this.lbMatchCount.Text = "매칭 갯수";
            // 
            // lbScore
            // 
            this.lbScore.AutoSize = true;
            this.lbScore.Location = new System.Drawing.Point(8, 56);
            this.lbScore.Name = "lbScore";
            this.lbScore.Size = new System.Drawing.Size(82, 15);
            this.lbScore.TabIndex = 2;
            this.lbScore.Text = "매칭스코어";
            // 
            // txtExtendY
            // 
            this.txtExtendY.Location = new System.Drawing.Point(184, 15);
            this.txtExtendY.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtExtendY.Name = "txtExtendY";
            this.txtExtendY.Size = new System.Drawing.Size(57, 25);
            this.txtExtendY.TabIndex = 1;
            // 
            // txtScore
            // 
            this.txtScore.Location = new System.Drawing.Point(99, 52);
            this.txtScore.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(57, 25);
            this.txtScore.TabIndex = 1;
            // 
            // txtExtendX
            // 
            this.txtExtendX.Location = new System.Drawing.Point(99, 15);
            this.txtExtendX.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtExtendX.Name = "txtExtendX";
            this.txtExtendX.Size = new System.Drawing.Size(57, 25);
            this.txtExtendX.TabIndex = 1;
            // 
            // lbX
            // 
            this.lbX.AutoSize = true;
            this.lbX.Location = new System.Drawing.Point(163, 22);
            this.lbX.Name = "lbX";
            this.lbX.Size = new System.Drawing.Size(16, 15);
            this.lbX.TabIndex = 0;
            this.lbX.Text = "x";
            // 
            // lbExtent
            // 
            this.lbExtent.AutoSize = true;
            this.lbExtent.Location = new System.Drawing.Point(8, 26);
            this.lbExtent.Name = "lbExtent";
            this.lbExtent.Size = new System.Drawing.Size(67, 15);
            this.lbExtent.TabIndex = 0;
            this.lbExtent.Text = "확장영역";
            // 
            // MatchInspProp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpMatch);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MatchInspProp";
            this.Size = new System.Drawing.Size(342, 339);
            this.grpMatch.ResumeLayout(false);
            this.grpMatch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTeachImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpMatch;
        private System.Windows.Forms.TextBox txtExtendY;
        private System.Windows.Forms.TextBox txtExtendX;
        private System.Windows.Forms.Label lbX;
        private System.Windows.Forms.Label lbExtent;
        private System.Windows.Forms.Label lbScore;
        private System.Windows.Forms.TextBox txtScore;
        private System.Windows.Forms.TextBox txtMatchCount;
        private System.Windows.Forms.Label lbMatchCount;
        private System.Windows.Forms.PictureBox picTeachImage;
    }
}
