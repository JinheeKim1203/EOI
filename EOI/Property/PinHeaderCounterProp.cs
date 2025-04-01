using EOI.Algorithm;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EOI.Property
{
    public partial class PinHeaderCounterProp : UserControl
    {
        public event EventHandler<EventArgs> PropertyChanged;

        PinHeaderCounter _pinHeaderCounter = null;
        public PinHeaderCounterProp()
        {
            InitializeComponent();           
            //this.picContour.SizeMode = PictureBoxSizeMode.Zoom;
            //this.Controls.Add(this.picContour);
            //this.Controls.Add(this.lblStatus);
        }

        public void SetAlgorithm(PinHeaderCounter pinHeaderCounter)
        {
            _pinHeaderCounter = pinHeaderCounter;
            // ✅ 여기서 이벤트를 연결해줘야 자동 반응
            _pinHeaderCounter.ImageChanged += (s, e) => SetProperty(); // **jh
            SetProperty();
        }

        public void SetProperty()
        {
            if (_pinHeaderCounter is null)
                return;

            //lblStatus.Text = _pinHeaderCounter.result;

            Mat pinHeaderImage = _pinHeaderCounter.GetResultImage();
            if (pinHeaderImage != null)
            {
                Bitmap bmpImage = BitmapConverter.ToBitmap(pinHeaderImage);
                picContour.Image = bmpImage;
                SetResult();
            }
        }

        public void SetResult()
        {
            // 안전하게 UI 스레드에서 실행
            if (lblStatus.InvokeRequired)
            {
                lblStatus.Invoke(new Action(() => lblStatus.Text = _pinHeaderCounter.result));
                lblStatus.Invoke(new Action(() => lblPinCounter.Text = Convert.ToString(_pinHeaderCounter.pinCount)));
            }
            else
            {
                lblStatus.Text = _pinHeaderCounter.result; ;
                lblPinCounter.Text = Convert.ToString(_pinHeaderCounter.pinCount);
            }
            //lblStatus.Text = _pinHeaderCounter.result;
        }
    }
}
