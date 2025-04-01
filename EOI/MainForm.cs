using EOI.Core;
using EOI.Setting;
using EOI.Teach;
using EOI.Util;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace EOI
{
    public partial class MainForm : Form
    {
        private void imageViewCCtrl_DiagramEntityEvent(object sender, DiagramEntityEventArgs e)
        {
            if (e.ActionType == EntityActionType.Move)
            {
                if (e.InspWindow.Type == InspWindowType.ID) // 기준 ROI만 처리
                {
                    int offsetX = e.OffsetMove.X;
                    int offsetY = e.OffsetMove.Y;

                    // 기준 ROI를 제외한 모든 ROI에 offset 적용
                    foreach (InspWindow win in Global.Inst.InspStage.CurModel.InspWindowList)
                    {
                        if (win == e.InspWindow) continue;

                        win.WindowArea = new OpenCvSharp.Rect(
                            win.WindowArea.X + offsetX,
                            win.WindowArea.Y + offsetY,
                            win.WindowArea.Width,
                            win.WindowArea.Height);
                    }

                    // ROI 다시 반영 (UI 업데이트)
                    //var updatedEntities = Global.Inst.InspStage.CurModel.CreateEntityList();
                    //var cameraForm = GetDockForm<CameraForm>();
                    //cameraForm?.SetEntities(updatedEntities); //ImageViewCCtrl에 다시 그리기 요청
                }
            }
        }


        private static DockPanel _dockPanel;

        public MainForm()
        {
            InitializeComponent();

            _dockPanel = new DockPanel
            {
                Dock = DockStyle.Fill
            };
            Controls.Add(_dockPanel);

            // Visual Studio 2015 테마 적용
            _dockPanel.Theme = new VS2015BlueTheme();

            LoadDockingWindows();

            Global.Inst.Initialize();

            this.FormClosed += MainForm_FormClosed;
        }

        private void LoadDockingWindows()
        {
            //#HN#
            var cameraForm = GetDockForm<CameraForm>();
            if (cameraForm != null)
            {
                // 3. 이벤트 연결
                cameraForm.ImageViewCCtrl.DiagramEntityEvent += imageViewCCtrl_DiagramEntityEvent;
            }
            else
            {
                // 예외 방지용 로그 또는 디버그 메시지
                Console.WriteLine("CameraForm을 찾을 수 없습니다.");
            }

            //도킹해제 금지 설정
            _dockPanel.AllowEndUserDocking = false;

            //메인폼 설정
            var cameraWindow = new CameraForm();
            cameraWindow.Show(_dockPanel, DockState.Document);

            //검사 결과창 30% 비율로 추가
            var resultWindow = new ResultForm();
            resultWindow.Show(cameraWindow.Pane, DockAlignment.Bottom, 0.3);

            //# MODEL TREE#3 검사 결과창 우측에 40% 비율로 모델트리 추가
            var modelTreeWindow = new ModelTreeForm();
            modelTreeWindow.Show(resultWindow.Pane, DockAlignment.Right, 0.4);

            //속성창 추가
            var propWindow = new PropertiesForm();
            propWindow.Show(_dockPanel, DockState.DockRight);

            //속성창과 같은탭에 추가하기
            var statisticWindow = new StatisticForm();
            statisticWindow.Show(_dockPanel, DockState.DockRight);

            propWindow.Activate();

            //로그창 50% 비율로 추가
            var logWindow = new LogForm();
            logWindow.Show(propWindow.Pane, DockAlignment.Bottom, 0.3);
        }

        //제네릭 함수 사용를 이용해 입력된 타입의 폼 객체 얻기
        public static T GetDockForm<T>() where T : DockContent
        {
            var findForm = _dockPanel.Contents.OfType<T>().FirstOrDefault();
            return findForm;
        }

        //#MODEL SAVE#4 아래 메뉴 추가 
        /*
            Model New : 신규 모델 생성
            Model Open : 모델 열기
            Model Save : 모델 저장
            Model Save As : 모델 다른 이름으로 저장
         */

        private void ModelNewMenuItem_Click(object sender, EventArgs e)
        {
            //신규 모델 추가를 위한 모델 정보를 받기 위한 창 띄우기
            NewModel newModel = new NewModel();
            newModel.ShowDialog();
        }

        private void ModelOpenMenuItem_Click(object sender, EventArgs e)
        {
            //모델 파일 열기
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "모델 파일 선택";
                openFileDialog.Filter = "Model Files|*.xml;";
                openFileDialog.Multiselect = false;
                openFileDialog.InitialDirectory = SettingXml.Inst.ModelDir;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    Global.Inst.InspStage.LoadModel(filePath);
                }
            }
        }
        private void ModelSaveMenuItem_Click(object sender, EventArgs e)
        {
            //모델 파일 저장
            Global.Inst.InspStage.SaveModel("");
        }

        private void ModelSaveAsMenuItem_Click(object sender, EventArgs e)
        {
            //다른이름으로 모델 파일 저장
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.InitialDirectory = SettingXml.Inst.ModelDir;
                saveFileDialog.Title = "모델 파일 선택";
                saveFileDialog.Filter = "Model Files|*.xml;";
                saveFileDialog.DefaultExt = "xml";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    Global.Inst.InspStage.SaveModel(filePath);
                }
            }
        }

        private void ImageLoadMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "이미지 파일 선택";
                openFileDialog.Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.png;*.gif";
                openFileDialog.Multiselect = false;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    Global.Inst.InspStage.SetImageBuffer(filePath);
                    Global.Inst.InspStage.CurModel.InspectImagePath = filePath;
                }
            }
        }

        private void ImageSaveMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "이미지 저장";
                saveFileDialog.Filter = "PNG 파일|*.png|JPEG 파일|*.jpg|Bitmap 파일|*.bmp";
                saveFileDialog.DefaultExt = "png";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    Global.Inst.InspStage.SaveCurrentImage(filePath);
                }
            }
        }

        //#SETUP#8 메인메뉴에 Setup 메뉴 추가하고, 아래 함수로 환경설정창 띄우기
        private void SetupMenuItem_Click(object sender, EventArgs e)
        {
            SLogger.Write($"환경설정창 열기");
            SetupForm setupForm = new SetupForm();
            setupForm.ShowDialog();
        }
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Global.Inst.Dispose();

            this.FormClosed -= MainForm_FormClosed;
        }
    }
}
