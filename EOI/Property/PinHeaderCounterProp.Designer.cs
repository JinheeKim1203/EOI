namespace EOI.Property
{
    partial class PinHeaderCounterProp
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.picContour = new System.Windows.Forms.PictureBox();
            this.lblContour = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picContour)).BeginInit();
            this.SuspendLayout();
            // 
            // picContour
            // 
            this.picContour.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.picContour.Location = new System.Drawing.Point(15, 64);
            this.picContour.Name = "picContour";
            this.picContour.Size = new System.Drawing.Size(317, 183);
            this.picContour.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picContour.TabIndex = 0;
            this.picContour.TabStop = false;
            // 
            // lblContour
            // 
            this.lblContour.AutoSize = true;
            this.lblContour.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblContour.Location = new System.Drawing.Point(11, 28);
            this.lblContour.Name = "lblContour";
            this.lblContour.Size = new System.Drawing.Size(193, 20);
            this.lblContour.TabIndex = 1;
            this.lblContour.Text = "윤곽선 감지 이미지";
            // 
            // PinHeaderCounterProp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblContour);
            this.Controls.Add(this.picContour);
            this.Name = "PinHeaderCounterProp";
            this.Size = new System.Drawing.Size(348, 366);
            ((System.ComponentModel.ISupportInitialize)(this.picContour)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picContour;
        private System.Windows.Forms.Label lblContour;
    }
}
