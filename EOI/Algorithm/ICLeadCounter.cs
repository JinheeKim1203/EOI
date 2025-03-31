using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

// **추가** CHB
namespace EOI.Algorithm
{
    public class ICLeadCounter : InspAlgorithm
    {
        [XmlIgnore]
        public Mat ResultImage { get; private set; }

        public int icLeadCount = 0;

        public ICLeadCounter()
        {
            InspectType = InspectType.ICLeadCounter;
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

            // 블러 + 이진화 (리드선 강조)
            Cv2.GaussianBlur(grayImage, grayImage, new Size(3, 3), 0);
            Mat binary = new Mat();
            Cv2.Threshold(grayImage, binary, 80, 255, ThresholdTypes.BinaryInv);

            Cv2.FindContours(binary, out Point[][] contours, out _, RetrievalModes.External, ContourApproximationModes.ApproxSimple);

            List<Rect> leadRects = new List<Rect>();

            foreach (var contour in contours)
            {
                var rect = Cv2.BoundingRect(contour);

                // 리드선: 좁고 길쭉한 형태 (IC칩 옆 다리)
                if (rect.Width >= 2 && rect.Width <= 10 && rect.Height >= 2 && rect.Height <= 20)
                {
                    leadRects.Add(rect);
                }
            }

            // 정렬 (왼쪽→오른쪽 or 위→아래 순)
            leadRects = leadRects.OrderBy(r => r.X).ThenBy(r => r.Y).ToList();

            // 시각화
            foreach (var r in leadRects)
                Cv2.Rectangle(targetImage, r, Scalar.Red, 2);

            ResultImage = targetImage.Clone();

            // 결과 표시
            icLeadCount = leadRects.Count;

            string resultText = $"{icLeadCount}, {(icLeadCount == 16 ? "양품" : "불량")}";            
            Console.Write(resultText);

            foreach (var r in leadRects)
                Cv2.Rectangle(targetImage, r, Scalar.Red, 2);
            // 디버그용 이미지 보기 (운영 시 주석)
            Cv2.ImShow("IC Lead Detection", ResultImage);
            Cv2.WaitKey();

            return true;
        }
    }
}
