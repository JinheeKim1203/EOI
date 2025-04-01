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
            this.lblPin = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPinCounter = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picContour)).BeginInit();
            this.SuspendLayout();
            // 
            // picContour
            // 
            this.picContour.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.picContour.Location = new System.Drawing.Point(19, 77);
            this.picContour.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picContour.Name = "picContour";
            this.picContour.Size = new System.Drawing.Size(396, 220);
            this.picContour.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picContour.TabIndex = 0;
            this.picContour.TabStop = false;
            // 
            // lblContour
            // 
            this.lblContour.AutoSize = true;
            this.lblContour.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblContour.Location = new System.Drawing.Point(14, 34);
            this.lblContour.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblContour.Name = "lblContour";
            this.lblContour.Size = new System.Drawing.Size(228, 24);
            this.lblContour.TabIndex = 1;
            this.lblContour.Text = "윤곽선 감지 이미지";
            // 
            // lblPin
            // 
            this.lblPin.AutoSize = true;
            this.lblPin.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPin.Location = new System.Drawing.Point(14, 317);
            this.lblPin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPin.Name = "lblPin";
            this.lblPin.Size = new System.Drawing.Size(180, 24);
            this.lblPin.TabIndex = 1;
            this.lblPin.Text = "핀 헤더 상태 : ";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblStatus.Location = new System.Drawing.Point(202, 317);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(38, 24);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "??";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(15, 357);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "검사된 핀 갯수 : ";
            // 
            // lblPinCounter
            // 
            this.lblPinCounter.AutoSize = true;
            this.lblPinCounter.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPinCounter.Location = new System.Drawing.Point(228, 357);
            this.lblPinCounter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPinCounter.Name = "lblPinCounter";
            this.lblPinCounter.Size = new System.Drawing.Size(38, 24);
            this.lblPinCounter.TabIndex = 1;
            this.lblPinCounter.Text = "??";
            // 
            // PinHeaderCounterProp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblPinCounter);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPin);
            this.Controls.Add(this.lblContour);
            this.Controls.Add(this.picContour);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "PinHeaderCounterProp";
            this.Size = new System.Drawing.Size(435, 439);
            ((System.ComponentModel.ISupportInitialize)(this.picContour)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picContour;
        private System.Windows.Forms.Label lblContour;
        private System.Windows.Forms.Label lblPin;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPinCounter;
    }
}
