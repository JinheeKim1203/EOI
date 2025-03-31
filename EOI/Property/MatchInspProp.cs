using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EOI.Algorithm;
using EOI.Core;
using EOI.Teach;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using static System.Windows.Forms.MonthCalendar;

namespace EOI.Property
{
    /*
    #MATCH PROP# - <<<템플릿 매칭 개발>>> 
    설정된 ROI 이미지를 이용해, 유사한 이미지를 대상 이미지에서 찾는다.
    [확장영역]은 현재 구현되지 않았음
    [매칭스코어]는 템플릿 매칭 결과가 입력된 스코어보다 큰것만을 유효한 것으로 판단
    [매칭갯수]는 찾고자 하는 패턴의 갯수를 입력
     */
    public partial class MatchInspProp : UserControl
    {
        public event EventHandler<EventArgs> PropertyChanged;

        MatchAlgorithm _matchAlgo = null;

        private string _selectedTemplatePath;  // 👈 현재 선택된 이미지 경로 저장


        public MatchInspProp()
        {
            InitializeComponent();

            txtExtendX.Leave += OnUpdateValue;
            txtExtendY.Leave += OnUpdateValue;
            txtScore.Leave += OnUpdateValue;
            txtMatchCount.Leave += OnUpdateValue;
        }

        public void SetAlgorithm(MatchAlgorithm matchAlgo)
        {
            _matchAlgo = matchAlgo;
            SetProperty();
        }

        public void SetProperty()
        {
            if (_matchAlgo is null)
                return;

            OpenCvSharp.Size extendSize = _matchAlgo.ExtSize;
            int matchScore = _matchAlgo.MatchScore;
            int matchCount = _matchAlgo.MatchCount;

            txtExtendX.Text = extendSize.Width.ToString();
            txtExtendY.Text = extendSize.Height.ToString();
            txtScore.Text = matchScore.ToString();
            txtMatchCount.Text = matchCount.ToString();

            Mat teachImage = _matchAlgo.GetTemplateImage();
            if (teachImage != null)
            {
                Bitmap bmpImage = BitmapConverter.ToBitmap(teachImage);
                picTeachImage.Image = bmpImage;
            }

            // **jh
            RefreshTeachImageList();
        }

        private void OnUpdateValue(object sender, EventArgs e)
        {
            if (_matchAlgo == null)
                return;

            OpenCvSharp.Size extendSize = _matchAlgo.ExtSize;

            if (!int.TryParse(txtExtendX.Text, out extendSize.Width))
            {
                MessageBox.Show("숫자만 입력 가능합니다.");
                return;
            }

            if (!int.TryParse(txtExtendY.Text, out extendSize.Height))
            {
                MessageBox.Show("숫자만 입력 가능합니다.");
                return;
            }

            int score = _matchAlgo.MatchScore;
            if (!int.TryParse(txtScore.Text, out score))
            {
                MessageBox.Show("숫자만 입력 가능합니다.");
                return;
            };


            int matchCount = _matchAlgo.MatchCount;
            if (!int.TryParse(txtMatchCount.Text, out matchCount))
            {
                MessageBox.Show("숫자만 입력 가능합니다.");
                return;
            }

            _matchAlgo.ExtSize = extendSize;
            _matchAlgo.MatchScore = score;
            _matchAlgo.MatchCount = matchCount;

            PropertyChanged?.Invoke(this, null);
        }

        private Bitmap SafeLoadImage(string path)
        {
            using (var original = Image.FromFile(path))
            {
                return new Bitmap(original); // 복사본으로 썸네일 만들기
            }
        }

        // **jh
        private void RefreshTeachImageList()
        {
            flwTeachList.Controls.Clear();

            if (_matchAlgo?.LinkedWindow == null)
                return;

            string uid = _matchAlgo.LinkedWindow.UID;
            string modelPath = Global.Inst.InspStage.CurModel.ModelPath;
            if (string.IsNullOrEmpty(modelPath)) return;

            string imgDir = Path.Combine(Path.GetDirectoryName(modelPath), "Images");

            // ⛔ ROI가 없어도 Images 폴더는 없을 수 있음.없으면 그냥 return
            if (!Directory.Exists(imgDir))
                return;

            var files = Directory.GetFiles(imgDir, $"{uid}_T*.png");

            foreach (var file in files)
            {
                PictureBox thumb = new PictureBox();
                thumb.Image = SafeLoadImage(file); // ✅ 복사된 이미지 사용
                thumb.SizeMode = PictureBoxSizeMode.Zoom;
                thumb.Size = new System.Drawing.Size(60, 60);
                thumb.Margin = new Padding(5);
                thumb.Cursor = Cursors.Hand;
                thumb.Tag = file;
                thumb.Click += OnTeachThumbnailClick;

                flwTeachList.Controls.Add(thumb);
            }
        }

        // **jh
        private void OnTeachThumbnailClick(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            if (pb?.Tag is string path && File.Exists(path))
            {

                _selectedTemplatePath = path; // ✅ 경로 저장

                picTeachImage.Image?.Dispose();
                picTeachImage.Image = Image.FromFile(path);
            }
        }

        // **jh
        private void btnDeleteTeachImage_Click(object sender, EventArgs e)
        {
            // 🔐 먼저 경로가 저장돼 있는지 확인
            if (string.IsNullOrEmpty(_selectedTemplatePath) || !File.Exists(_selectedTemplatePath))
            {
                MessageBox.Show("삭제할 이미지를 먼저 선택하세요.");
                return;
            }

            try
            {
                // 이미지 해제 (파일 핸들 반환)
                picTeachImage.Image?.Dispose();
                picTeachImage.Image = null;

                // GC 처리 (강제 해제)
                GC.Collect();
                GC.WaitForPendingFinalizers();

                // 이미지 파일 삭제
                File.Delete(_selectedTemplatePath);

                // 경로 초기화
                _selectedTemplatePath = null;

                // 썸네일 갱신
                RefreshTeachImageList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"이미지 삭제 중 오류 발생: {ex.Message}");
            }
        }

        // **jh
        public static class ImageComparer
        {
            public static bool IsSameImage(Image img1, Image img2)
            {
                if (img1 == null || img2 == null) return false;
                if (img1.Width != img2.Width || img1.Height != img2.Height) return false;

                using (MemoryStream ms1 = new MemoryStream(), ms2 = new MemoryStream())
                {
                    img1.Save(ms1, System.Drawing.Imaging.ImageFormat.Png);
                    img2.Save(ms2, System.Drawing.Imaging.ImageFormat.Png);

                    byte[] b1 = ms1.ToArray();
                    byte[] b2 = ms2.ToArray();

                    return b1.SequenceEqual(b2);
                }
            }
        }
    }
}
