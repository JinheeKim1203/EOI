using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EOI.Algorithm;
using OpenCvSharp;
using EOI.Core;
using System.Security.Policy;
using System.IO;
using System.Xml.Serialization;
using EOI.Setting;
using System.Xml.Linq;
using EOI.Inspect;
using System.Windows.Forms;
using System.Drawing;

namespace EOI.Teach
{
    //#MATCH PROP#3 InspWindow 클래스 추가, ROI 관리 및 검사를 처리하는 클래스
    //검사 알고리즘를 관리하는 클래스

    public class InspWindow
    {
        //템플릿 매칭 이미지
        private Mat _teachingImage;

        public InspWindowType InspWindowType { get; set; }

        //#MODEL SAVE#5 모델 저장을 위한 Serialize를 위해서, prvate set -> set으로 변경
        //public string Name {  get; private set; }
        public string Name { get; set; }
        public string UID { get; set; }

        private Rect _windowArea = new Rect();

        public Rect WindowArea
        {
            get
            {
                return _windowArea;
            }
            set
            {
                _windowArea = value;
                InspArea = _windowArea;
            }
        }
        public Rect InspArea { get; set; }
        
        //#HN#
        //public System.Drawing.Rectangle ExpandRect { get; set; }
        public InspWindowType Type { get; set; }
        public bool IsTeach { get; set; } = false;
        public List<InspWindow> InspWindowList { get; set; } = new List<InspWindow>();



        //#ABSTRACT ALGORITHM#9 개별 변수로 있던, MatchAlgorithm과 BlobAlgorithm을
        //InspAlgorithm으로 추상화하여 리스트로 관리하도록 변경

        //#MODEL SAVE#6 Xml Serialize를 위해서, Element을 명확하게 알려줘야 함
        [XmlElement("InspAlgorithm")]
      
        public List<InspAlgorithm> AlgorithmList { get; set; } = new List<InspAlgorithm>();
        //부모-자식 관계를 위한 변수 추가
        [XmlIgnore] 
        public InspWindow Parent { get; set; }

        [XmlElement("ChildWindow")]
        [XmlIgnore]
        public List<InspWindow> Children { get; set; } = new List<InspWindow>();

        public List<InspResult> InspResultList { get; set; } = new List<InspResult>();

        [XmlIgnore]
        public Mat WindowImage { get; set; }

        // **jh 티칭 이미지 리스트 (이미지뷰에서 ROI 크롭 후 저장되는 리스트)
        [XmlIgnore]
        public List<Bitmap> TeachImageList { get; set; } = new List<Bitmap>();

        public bool IsPatternLearn { get; set; } = false;

        public InspWindow()
        {
        }

        public InspWindow(InspWindowType windowType, string name)
        {
            InspWindowType = windowType;
            Name = name;
        }

        public bool SetTeachingImage(Mat image, System.Drawing.Rectangle rect)
        {
            _teachingImage = new Mat(image, new Rect(rect.X, rect.Y, rect.Width, rect.Height));
            return true;
        }

        // **jh TeachImageList에 이미지 추가
        public void AddTeachImage(Bitmap bitmap)
        {
            if (bitmap == null) return;
            TeachImageList.Add(new Bitmap(bitmap)); // 깊은 복사로 추가
        }

        //#MATCH PROP#4 템플릿 매칭 이미지 로딩
        public bool PatternLearn()
        {
            if (IsPatternLearn == true)
                return true;

            foreach (var algorithm in AlgorithmList)
            {
                if (algorithm.InspectType != InspectType.InspMatch)
                    continue;

                MatchAlgorithm matchAlgo = (MatchAlgorithm)algorithm;

                if (WindowImage != null)
                {
                    Mat tempImage = new Mat();
                    if (WindowImage.Type() == MatType.CV_8UC3)
                        Cv2.CvtColor(WindowImage, tempImage, ColorConversionCodes.BGR2GRAY);
                    else
                        tempImage = WindowImage;

                    matchAlgo.SetTemplateImage(tempImage);
                }
            }

            IsPatternLearn = true;

            return true;
        }

        //#ABSTRACT ALGORITHM#10 타입에 따라 알고리즘을 추가하는 함수
        public bool AddInspAlgorithm(InspectType inspType)
        {
            InspAlgorithm inspAlgo = null;

            switch (inspType)
            {
                case InspectType.InspBinary:
                    inspAlgo = new BlobAlgorithm();
                    break;
                case InspectType.InspMatch:
                    inspAlgo = new MatchAlgorithm();
                    break;
                case InspectType.PinHeaderCounter: // **추가**
                    inspAlgo = new PinHeaderCounter();
                    break;
                case InspectType.ICLeadCounter: // **추가** CHB
                    inspAlgo = new ICLeadCounter();
                    break;
            }

            if (inspAlgo is null)
                return false;

            // jh ⛳ MatchAlgorithm이면 LinkedWindow 설정
            if (inspAlgo is MatchAlgorithm matchAlgo)
            {
                matchAlgo.LinkedWindow = this;
            }

            AlgorithmList.Add(inspAlgo);

            return true;
        }


        //#ABSTRACT ALGORITHM#11 알고리즘을 리스트로 관리하므로, 필요한 타입의 알고리즘을 찾는 함수
        public InspAlgorithm FindInspAlgorithm(InspectType inspType)
        {
            return AlgorithmList.Find(algo => algo.InspectType == inspType);
        }

        //#ABSTRACT ALGORITHM#12 클래스 내에서, 인자로 입력된 타입의 알고리즘을 검사하거나,
        ///모든 알고리즘을 검사하는 옵션을 가지는 검사 함수
        public virtual bool DoInspect(InspectType inspType)
        {
            foreach (var inspAlgo in AlgorithmList)
            {
                if (inspAlgo.InspectType == inspType || inspType == InspectType.InspNone)
                    inspAlgo.DoInspect();
            }

            return true;
        }

        public bool IsDefect()
        {
            foreach (InspAlgorithm algo in AlgorithmList)
            {
                if (!algo.IsInspected)
                    continue;

                if (algo.IsDefect)
                    return true;
            }
            return false;
        }


        public virtual bool OffsetMove(OpenCvSharp.Point offset)
        {
            Rect windowRect = WindowArea;
            windowRect.X += offset.X;
            windowRect.Y += offset.Y;
            WindowArea = windowRect;
            return true;
        }

        public bool SetInspOffset(OpenCvSharp.Point offset)
        {
            InspArea = WindowArea + offset;
            AlgorithmList.ForEach(algo => algo.InspRect = algo.TeachRect + offset);
            return true;
        }

        #region 부모 - 자식 관계 관리 메서드 추가

        public void AddChild(InspWindow child)
        {
            if (child == null || Children.Contains(child))
                return;

            child.Parent = this;
            Children.Add(child);
        }

        public bool RemoveChild(InspWindow child)
        {
            if (child == null || !Children.Contains(child))
                return false;

            child.Parent = null;
            if (!Children.Remove(child))
                return false;

            return true;
        }

        public InspWindow GetRoot()
        {
            InspWindow root = this;
            while (root.Parent != null)
                root = root.Parent;

            return root;
        }
        #endregion

        private int GetNextTeachIndex(string folderPath, string uid)
        {
            var files = Directory.GetFiles(folderPath, $"{uid}_T*.png");
            int maxIndex = 0;

            foreach (var file in files)
            {
                string name = Path.GetFileNameWithoutExtension(file);
                var match = System.Text.RegularExpressions.Regex.Match(name, $"{uid}_T(\\d+)");
                if (match.Success && int.TryParse(match.Groups[1].Value, out int index))
                {
                    maxIndex = Math.Max(maxIndex, index);
                }
            }

            return maxIndex + 1;
        }

        public virtual bool SaveInspWindow(Model curModel)
        {
            if (curModel is null)
                return false;

            // 삭제 예정 이미지가 있는지 확인
            foreach (var algo in AlgorithmList)
            {
                if (algo is MatchAlgorithm matchAlgo && matchAlgo.DeletedTemplateList.Count > 0)
                {
                    var result = MessageBox.Show(
                        "삭제 예정인 티칭 이미지가 있습니다.\n정말 삭제하고 저장하시겠습니까?",
                        "확인",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (result == DialogResult.No)
                        return false; // 저장 취소
                    break; // 하나만 확인하면 충분
                }
            }

            string imgDir = Path.Combine(Path.GetDirectoryName(curModel.ModelPath), "Images");
            if (!Directory.Exists(imgDir))
                Directory.CreateDirectory(imgDir);

            // MatchAlgorithm 이미지 삭제 + 리네이밍
            foreach (var algo in AlgorithmList)
            {
                if (algo is MatchAlgorithm matchAlgo)
                {
                    matchAlgo.CleanupTemplates(); // 삭제 예약 반영 + T001부터 정렬
                }
            }

            // TeachImageList 저장 (UID_T001.png, UID_T002.png ...)
            if (TeachImageList != null && TeachImageList.Count > 0)
            {
                for (int i = 0; i < TeachImageList.Count; i++)
                {
                    string fileName = $"{UID}_T{i + 1:D3}.png";
                    string savePath = Path.Combine(imgDir, fileName);
                    try
                    {
                        // 파일이 열려 있거나 이미 존재하는 경우 덮어쓰기 전에 삭제
                        if (File.Exists(savePath))
                            File.Delete(savePath);

                        using (Bitmap bmp = new Bitmap(TeachImageList[i])) // 복사본 생성
                        {
                            bmp.Save(savePath, System.Drawing.Imaging.ImageFormat.Png);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"이미지 저장 실패: {fileName}\n{ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            return true;
        }

        public virtual bool LoadInspWindow(Model curModel)
        {
            if (curModel is null)
                return false;

            string imgDir = Path.Combine(Path.GetDirectoryName(curModel.ModelPath), "Images");

            TeachImageList = new List<Bitmap>();  // ** jh ✅ 새로 초기화

            // 이미지 리스트 로딩 (UID_T*.png)
            var files = Directory.GetFiles(imgDir, $"{UID}_T*.png")
                                 .OrderBy(f => f)  // 정렬: T001, T002 순
                                 .ToList();

            foreach (var file in files)
            {
                try
                {
                    using (var bmp = new Bitmap(file))
                    {
                        TeachImageList.Add(new Bitmap(bmp));  // 복사본 저장
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"이미지 로딩 실패: {file}\n{ex.Message}");
                }
            }

            // 대표 WindowImage 설정
            if (TeachImageList.Count > 0)
            {
                WindowImage = OpenCvSharp.Extensions.BitmapConverter.ToMat(TeachImageList[0]);
            }

            // MatchAlgorithm의 템플릿 이미지로 설정
            foreach (InspAlgorithm algo in AlgorithmList)
            {
                if (algo is MatchAlgorithm matchAlgo && WindowImage != null)
                {
                    Mat gray = new Mat();
                    if (WindowImage.Type() == MatType.CV_8UC3)
                        Cv2.CvtColor(WindowImage, gray, ColorConversionCodes.BGR2GRAY);
                    else
                        gray = WindowImage;

                    matchAlgo.SetTemplateImage(gray);
                }
            }

            return true;
        }

        public void ResetInspResult()
        {
            InspResultList.Clear();
        }

        public void AddInspResult(InspResult inspResult)
        {
            InspResultList.Add(inspResult);
        }
    }
}
