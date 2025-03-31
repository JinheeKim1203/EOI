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
    public class PinHeaderCounter : InspAlgorithm
    {
        public string result { get;  set; } = "";

        //[XmlIgnore]
        //public Mat ResultImage { get;  set; } // **추가**

        [XmlIgnore] // xml은 모든것을 저장하려는 성격이기 때문에 Mat정보는 저장할 필요가 없으므로 이렇게 해야 함.
        private Mat _resultImage = null; // **추가**
        public int pinCount = 0;

        public Mat GetResultImage()
        {
           return _resultImage;
        }

        public PinHeaderCounter()
        {
            InspectType = InspectType.PinHeaderCounter;
        }

        //public string result = null;

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

            _resultImage = targetImage.Clone(); // 결과 이미지 저장

            pinCount = matchedRects.Count;
        
            result = pinCount != 4 ? "불량" : "양품";
            Console.WriteLine(result);

            // 필요 시 디버깅 이미지 표시 (운영 버전에서는 주석 처리 가능)
            foreach (var r in matchedRects)
                Cv2.Rectangle(targetImage, r, Scalar.Red, 2);
            //Cv2.ImShow("Detected Pins", _resultImage);
            //Cv2.WaitKey();

            
            //prop.SetReturnImg(_resultImage, result);


            return true;
        }
    }
}
