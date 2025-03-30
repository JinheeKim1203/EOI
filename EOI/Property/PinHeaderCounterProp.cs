using OpenCvSharp;
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
        public event EventHandler<FilterSelectedEventArgs> PropertyChanged;
        public PinHeaderCounterProp()
        {
            InitializeComponent();           
            this.picContour.SizeMode = PictureBoxSizeMode.Zoom;
            this.Controls.Add(this.picContour);
        }

        public void SetImage(Mat image)
        {
            if (image == null || image.Empty())
                return;

            Bitmap bmp = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(image);
            picContour.Image = bmp;
        }

        public void ShowDetectedPins(Mat image)
        {
            if (image == null || image.Empty()) return;

            Bitmap bitmap = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(image);
            picContour.Image = bitmap;
        }
    }
}
