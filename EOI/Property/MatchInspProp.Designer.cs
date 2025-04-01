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
            this.flwTeachList = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDeleteTeachImage = new System.Windows.Forms.Button();
            this.btnUndoDeleteTeachImage = new System.Windows.Forms.Button();
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
            this.grpMatch.Controls.Add(this.flwTeachList);
            this.grpMatch.Controls.Add(this.btnDeleteTeachImage);
            this.grpMatch.Controls.Add(this.btnUndoDeleteTeachImage);
            this.grpMatch.Location = new System.Drawing.Point(4, 4);
            this.grpMatch.Margin = new System.Windows.Forms.Padding(4);
            this.grpMatch.Name = "grpMatch";
            this.grpMatch.Padding = new System.Windows.Forms.Padding(4);
            this.grpMatch.Size = new System.Drawing.Size(520, 695);
            this.grpMatch.TabIndex = 0;
            this.grpMatch.TabStop = false;
            this.grpMatch.Text = "패턴매칭";
            // 
            // picTeachImage
            // 
            this.picTeachImage.Location = new System.Drawing.Point(13, 170);
            this.picTeachImage.Margin = new System.Windows.Forms.Padding(4);
            this.picTeachImage.Name = "picTeachImage";
            this.picTeachImage.Size = new System.Drawing.Size(240, 216);
            this.picTeachImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picTeachImage.TabIndex = 7;
            this.picTeachImage.TabStop = false;
            // 
            // txtMatchCount
            // 
            this.txtMatchCount.Location = new System.Drawing.Point(124, 105);
            this.txtMatchCount.Margin = new System.Windows.Forms.Padding(4);
            this.txtMatchCount.Name = "txtMatchCount";
            this.txtMatchCount.Size = new System.Drawing.Size(70, 28);
            this.txtMatchCount.TabIndex = 5;
            // 
            // lbMatchCount
            // 
            this.lbMatchCount.AutoSize = true;
            this.lbMatchCount.Location = new System.Drawing.Point(13, 110);
            this.lbMatchCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMatchCount.Name = "lbMatchCount";
            this.lbMatchCount.Size = new System.Drawing.Size(86, 18);
            this.lbMatchCount.TabIndex = 4;
            this.lbMatchCount.Text = "매칭 갯수";
            // 
            // lbScore
            // 
            this.lbScore.AutoSize = true;
            this.lbScore.Location = new System.Drawing.Point(10, 68);
            this.lbScore.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbScore.Name = "lbScore";
            this.lbScore.Size = new System.Drawing.Size(98, 18);
            this.lbScore.TabIndex = 2;
            this.lbScore.Text = "매칭스코어";
            // 
            // txtExtendY
            // 
            this.txtExtendY.Location = new System.Drawing.Point(230, 18);
            this.txtExtendY.Margin = new System.Windows.Forms.Padding(4);
            this.txtExtendY.Name = "txtExtendY";
            this.txtExtendY.Size = new System.Drawing.Size(70, 28);
            this.txtExtendY.TabIndex = 1;
            // 
            // txtScore
            // 
            this.txtScore.Location = new System.Drawing.Point(124, 63);
            this.txtScore.Margin = new System.Windows.Forms.Padding(4);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(70, 28);
            this.txtScore.TabIndex = 1;
            // 
            // txtExtendX
            // 
            this.txtExtendX.Location = new System.Drawing.Point(124, 18);
            this.txtExtendX.Margin = new System.Windows.Forms.Padding(4);
            this.txtExtendX.Name = "txtExtendX";
            this.txtExtendX.Size = new System.Drawing.Size(70, 28);
            this.txtExtendX.TabIndex = 1;
            // 
            // lbX
            // 
            this.lbX.AutoSize = true;
            this.lbX.Location = new System.Drawing.Point(204, 27);
            this.lbX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbX.Name = "lbX";
            this.lbX.Size = new System.Drawing.Size(18, 18);
            this.lbX.TabIndex = 0;
            this.lbX.Text = "x";
            // 
            // lbExtent
            // 
            this.lbExtent.AutoSize = true;
            this.lbExtent.Location = new System.Drawing.Point(10, 32);
            this.lbExtent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbExtent.Name = "lbExtent";
            this.lbExtent.Size = new System.Drawing.Size(80, 18);
            this.lbExtent.TabIndex = 0;
            this.lbExtent.Text = "확장영역";
            // 
            // flwTeachList
            // 
            this.flwTeachList.AutoScroll = true;
            this.flwTeachList.Location = new System.Drawing.Point(270, 170);
            this.flwTeachList.Name = "flwTeachList";
            this.flwTeachList.Size = new System.Drawing.Size(240, 216);
            this.flwTeachList.TabIndex = 8;
            // 
            // btnDeleteTeachImage
            // 
            this.btnDeleteTeachImage.Location = new System.Drawing.Point(270, 400);
            this.btnDeleteTeachImage.Name = "btnDeleteTeachImage";
            this.btnDeleteTeachImage.Size = new System.Drawing.Size(240, 32);
            this.btnDeleteTeachImage.TabIndex = 9;
            this.btnDeleteTeachImage.Text = "선택 티칭 이미지 삭제";
            this.btnDeleteTeachImage.Click += new System.EventHandler(this.btnDeleteTeachImage_Click);
            // 
            // btnUndoDeleteTeachImage
            // 
            this.btnUndoDeleteTeachImage.Location = new System.Drawing.Point(377, 438);
            this.btnUndoDeleteTeachImage.Name = "btnUndoDeleteTeachImage";
            this.btnUndoDeleteTeachImage.Size = new System.Drawing.Size(133, 30);
            this.btnUndoDeleteTeachImage.TabIndex = 10;
            this.btnUndoDeleteTeachImage.Text = "삭제 취소";
            this.btnUndoDeleteTeachImage.Click += new System.EventHandler(this.btnUndoDeleteTeachImage_Click);
            // 
            // MatchInspProp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpMatch);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MatchInspProp";
            this.Size = new System.Drawing.Size(528, 703);
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
        private System.Windows.Forms.FlowLayoutPanel flwTeachList;
        private System.Windows.Forms.Button btnDeleteTeachImage;
        private System.Windows.Forms.Button btnUndoDeleteTeachImage;
    }
}
