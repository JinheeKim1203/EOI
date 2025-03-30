using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using OpenCvSharp;
using EOI.Core;
using EOI.Teach;
using System.Security.Policy;
using EOI.Property;

// **추가** 
namespace EOI.Algorithm
{
    internal class PinHeaderCounter : InspAlgorithm
    {
        public Mat ResultImage { get; private set; } // **추가**
        public PinHeaderCounterProp UIProp { get; set; } // **추가**
        public PinHeaderCounter()
        {
            InspectType = InspectType.PinHeaderCounter;
        }

        public override bool DoInspect()
        {
            ResetResult();

            if (_srcImage == null)
                return false;

            Mat targetImage = _srcImage[InspRect];

            Mat grayImage = new Mat();
            if (targetImage.Type() == MatType.CV_8UC3)
                Cv2.CvtColor(targetImage, grayImage, ColorConversionCodes.BGR2GRAY);
            else
                grayImage = targetImage;
            
            Mat binary = new Mat();
            Cv2.Threshold(grayImage, binary, 100, 255, ThresholdTypes.Binary);

            Cv2.FindContours(binary, out Point[][] contours, out _, RetrievalModes.External, ContourApproximationModes.ApproxSimple);

            List<Rect> matchedRects = new List<Rect>();
            foreach (var contour in contours)
            {
                var rect = Cv2.BoundingRect(contour);
                if (rect.Width < 30 && rect.Height > 70)
                {
                    matchedRects.Add(rect);
                }
            }

            foreach (var r in matchedRects)
                Cv2.Rectangle(targetImage, r, Scalar.Red, 2);

            ResultImage = targetImage.Clone(); // 결과 이미지 저장

            int pinCount = matchedRects.Count;
        
            Console.WriteLine(pinCount != 4 ? "불량" : "양품");

            // 필요 시 디버깅 이미지 표시 (운영 버전에서는 주석 처리 가능)
            foreach (var r in matchedRects)
                Cv2.Rectangle(targetImage, r, Scalar.Red, 2);
            Cv2.ImShow("Detected Pins", ResultImage);
            Cv2.WaitKey();

            //UIProp?.SetImage(targetImage);

            return true;
        }
    }
}
