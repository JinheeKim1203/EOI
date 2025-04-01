using EOI.Core;
using EOI.Setting;
using EOI.Teach;
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
using WeifenLuo.WinFormsUI.Docking;

namespace EOI
{
    /*
    #MODEL TREE# - <<<ROI 티칭을 위한 모델트리 만들기>>> 
    다양한 타입의 ROI를 입력하고, 관리하기 위해, 계층 구조를 나타낼 수 있는
    TreeView 컨트롤을 이용해, ROI를 입력하는 기능 개발
    1) ModelTreeForm WindowForm 생성
    2) TreeView Control 추가
    3) name을 tvModelTree로 설정
    */

    //# MODEL TREE#1 디자인창에서 모델 생성 후 아래 코드 구현
    public partial class ModelTreeForm : DockContent
    {
        //개별 트리 노트에서 팝업 메뉴 보이기를 위한 메뉴
        private ContextMenuStrip _contextMenu;

        public ModelTreeForm()
        {
            InitializeComponent();

            //초기 트리 노트의 기본값은 "Root"
            tvModelTree.Nodes.Add("Root");

            // 컨텍스트 메뉴 초기화
            _contextMenu = new ContextMenuStrip();

            List<InspWindowType> windowTypeList;
            if (MachineType.SMT == SettingXml.Inst.MachineType) // **수정** 2025.03.31 CHB
            {
                windowTypeList = new List<InspWindowType> { InspWindowType.Package, InspWindowType.Chip, InspWindowType.PinHeaderCount, InspWindowType.ID, InspWindowType.ICLeadCount };
            }
            else
            {
                windowTypeList = new List<InspWindowType> { InspWindowType.Base, InspWindowType.Body, InspWindowType.Sub, InspWindowType.ID };
            }

            foreach (InspWindowType windowType in windowTypeList)
                _contextMenu.Items.Add(new ToolStripMenuItem(windowType.ToString(), null, AddNode_Click) { Tag = windowType });
        }

        private void tvModelTree_MouseDown(object sender, MouseEventArgs e)
        {
            //Root 노드에서 마우스 오른쪽 버튼 클릭 시에, 팝업 메뉴 생성
            if (e.Button == MouseButtons.Right)
            {
                TreeNode clickedNode = tvModelTree.GetNodeAt(e.X, e.Y);
                if (clickedNode != null && clickedNode.Text == "Root")
                {
                    tvModelTree.SelectedNode = clickedNode;
                    _contextMenu.Show(tvModelTree, e.Location);
                }
            }
        }

        //팝업 메뉴에서, 메뉴 선택시 실행되는 함수
        private void AddNode_Click(object sender, EventArgs e)
        {
            if (tvModelTree.SelectedNode != null & sender is ToolStripMenuItem)
            {
                ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
                InspWindowType windowType = (InspWindowType)menuItem.Tag;
                AddNewROI(windowType);
            }
        }

        //imageViewer에 ROI 추가 기능 실행
        private void AddNewROI(InspWindowType inspWindowType)
        {
            CameraForm cameraForm = MainForm.GetDockForm<CameraForm>();
            if (cameraForm != null)
            {
                cameraForm.AddRoi(inspWindowType);
            }
        }

        //#MODEL#14 현재 모델 전체의 ROI를 트리 모델에 업데이트
        public void UpdateDiagramEntity()
        {
            //#HN# ->WinForms의 모든 UI 컨트롤은 **자신이 생성된 스레드(UI 스레드)**에서만 접근해야 하는데 다른 스레드로 실행되고 있는 코드가 tvModelTree를 조작하려 했기 때문에 예외가 발생 
            if (tvModelTree.InvokeRequired)
            {
                tvModelTree.Invoke(new MethodInvoker(UpdateDiagramEntity));
                return;
            }

            // tvModelTree는 이제 UI 스레드에서 안전하게 접근 가능
            tvModelTree.Nodes.Clear();
            // ... 기타 작업
            TreeNode rootNode = tvModelTree.Nodes.Add("Root");

            Model model = Global.Inst.InspStage.CurModel;
            List<InspWindow> windowList = model.InspWindowList;
            if (windowList.Count <= 0)
                return;

            foreach (InspWindow window in model.InspWindowList)
            {
                if (window is null)
                    continue;

                string uid = window.UID;

                TreeNode node = new TreeNode(uid);
                rootNode.Nodes.Add(node);
            }

            tvModelTree.ExpandAll();
        }
    }
}
