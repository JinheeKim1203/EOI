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
            lblStatus.Text = _pinHeaderCounter.result;
        }
    }
}
