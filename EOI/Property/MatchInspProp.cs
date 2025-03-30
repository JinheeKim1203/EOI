using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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


        public MatchInspProp()
        {
            InitializeComponent();

            txtExtendX.Leave += OnUpdateValue;
            txtExtendY.Leave += OnUpdateValue;
            txtScore.Leave += OnUpdateValue;
            txtMatchCount.Leave += OnUpdateValue;

            // **jh : 티칭 이미지 리스트
            this.flwTeachList.AutoScroll = true;
            this.flwTeachList.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.flwTeachList.WrapContents = false;
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

            RefreshTeachImageList();  // ← **jh : 리스트 초기화

            Mat teachImage = _matchAlgo.GetTemplateImage();
            if (teachImage != null && !teachImage.Empty())
            {
                Bitmap bmpImage = BitmapConverter.ToBitmap(teachImage);
                picTeachImage.Image = bmpImage;
            }
        }

        //**jh : 티칭 이미지 리스트 갱신
        private void RefreshTeachImageList()
        {
            flwTeachList.Controls.Clear();

            List<Mat> templates = _matchAlgo.GetTemplateImages();
            if (templates == null || templates.Count == 0)
                return;

            for (int i = 0; i < templates.Count; i++)
            {
                int capturedIndex = i;  // ✅ 이걸로 대체

                PictureBox pic = new PictureBox();
                pic.Width = 60;
                pic.Height = 60;
                pic.SizeMode = PictureBoxSizeMode.Zoom;
                pic.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(templates[i]);
                pic.BorderStyle = BorderStyle.FixedSingle;
                pic.Margin = new Padding(3);

                // 클릭 시 대표 이미지로
                pic.Click += (s, e) =>
                {
                    picTeachImage.Image = pic.Image;
                };

                // 우클릭 시 삭제
                pic.MouseDown += (s, e) =>
                {
                    if (e.Button == MouseButtons.Right)
                    {
                        var result = MessageBox.Show("이 티칭 이미지를 삭제할까요?", "삭제 확인", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            templates.RemoveAt(capturedIndex);  // ✅ capturedIndex 사용
                            _matchAlgo.SetTemplateImages(templates); // 템플릿 갱신

                            // ✅ 디스크도 동기화
                            Define.SaveTemplateImages(_matchAlgo.OwnerWindow?.UID, templates);

                            RefreshTeachImageList();                 // 다시 그리기
                            PropertyChanged?.Invoke(this, null);     // 변경 알림
                        }
                    }
                };

                flwTeachList.Controls.Add(pic);
            }

            // 대표 이미지 초기화
            if (templates.Count > 0)
                picTeachImage.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(templates[0]);
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


    }
}
