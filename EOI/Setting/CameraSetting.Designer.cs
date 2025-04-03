namespace EOI.Setting
{
    partial class CameraSetting
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
            this.lbCameraType = new System.Windows.Forms.Label();
            this.cbCameraType = new System.Windows.Forms.ComboBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbCameraType
            // 
            this.lbCameraType.AutoSize = true;
            this.lbCameraType.Location = new System.Drawing.Point(20, 45);
            this.lbCameraType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCameraType.Name = "lbCameraType";
            this.lbCameraType.Size = new System.Drawing.Size(104, 18);
            this.lbCameraType.TabIndex = 0;
            this.lbCameraType.Text = "카메라 종류";
            // 
            // cbCameraType
            // 
            this.cbCameraType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCameraType.FormattingEnabled = true;
            this.cbCameraType.Location = new System.Drawing.Point(127, 40);
            this.cbCameraType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbCameraType.Name = "cbCameraType";
            this.cbCameraType.Size = new System.Drawing.Size(200, 26);
            this.cbCameraType.TabIndex = 1;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(377, 276);
            this.btnApply.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(130, 39);
            this.btnApply.TabIndex = 2;
            this.btnApply.Text = "적용";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // CameraSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.cbCameraType);
            this.Controls.Add(this.lbCameraType);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "CameraSetting";
            this.Size = new System.Drawing.Size(551, 374);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbCameraType;
        private System.Windows.Forms.ComboBox cbCameraType;
        private System.Windows.Forms.Button btnApply;
    }
}
