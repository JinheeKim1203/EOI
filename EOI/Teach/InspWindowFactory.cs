using EOI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOI.Teach
{
    //#MODEL#2 InspWindow를 유니크한 이름으로 관리하기 위한, InspWindow 생성 클래스
    public class InspWindowFactory
    {
        #region Singleton Instance
        private static readonly Lazy<InspWindowFactory> _instance = new Lazy<InspWindowFactory>(() => new InspWindowFactory());

        public static InspWindowFactory Inst
        {
            get
            {
                return _instance.Value;
            }
        }
        #endregion

        //같은 타입의 일련번호 관리를 위한 딕셔너리
        private Dictionary<string, int> _windowTypeNo = new Dictionary<string, int>();

        public InspWindowFactory() { }

        //InspWindow를 생성하기 위해, 타입을 입력받아, 생성된 InspWindow 반환
        public InspWindow Create(InspWindowType windowType)
        {
            string name, prefix;
            if (!GetWindowName(windowType, out name, out prefix)) // InspWindowType이 없다면.
                return null;

            InspWindow inspWindow = null;

            if(InspWindowType.Group == windowType) // InspWindowType이 Group이라면.
                inspWindow = new GroupWindow(name); 
            else
                inspWindow = new InspWindow(windowType,name);

            if(inspWindow is null) 
                return null;

            if(!_windowTypeNo.ContainsKey(name)) 
                _windowTypeNo[name] = 0;

            int curID = _windowTypeNo[name];
            curID++; // 해당 ROI(InspWindow)의 개수가 증가.

            inspWindow.UID = string.Format("{0}_{1:D6}", prefix, curID); // 모델트리창에 쓰여짐.

            _windowTypeNo[name] = curID;

            AddInspAlgorithm(inspWindow); // 해당 InspWindowType(ROI)에 알고리즘을 추가.

            return inspWindow;
        }

        private bool AddInspAlgorithm(InspWindow inspWindow)
        {
            switch(inspWindow.InspWindowType)
            {
                case InspWindowType.Base:
                    inspWindow.AddInspAlgorithm(InspectType.InspMatch);
                    inspWindow.AddInspAlgorithm(InspectType.InspBinary);
                    break;
                case InspWindowType.Body:
                    inspWindow.AddInspAlgorithm(InspectType.InspMatch);
                    inspWindow.AddInspAlgorithm(InspectType.InspBinary);
                    break;
                case InspWindowType.Sub:
                    inspWindow.AddInspAlgorithm(InspectType.InspMatch);
                    inspWindow.AddInspAlgorithm(InspectType.InspBinary);
                    break;
                case InspWindowType.ID:
                    inspWindow.AddInspAlgorithm(InspectType.InspMatch);
                    break;
                case InspWindowType.Package:
                    //inspWindow.AddInspAlgorithm(InspectType.InspMatch);
                    inspWindow.AddInspAlgorithm(InspectType.InspBinary);
                    break;
                case InspWindowType.Chip:
                    inspWindow.AddInspAlgorithm(InspectType.InspMatch);
                    //inspWindow.AddInspAlgorithm(InspectType.InspBinary);
                    break;
                case InspWindowType.PinHeaderCount: //**수정**
                    //inspWindow.AddInspAlgorithm(InspectType.InspMatch);
                    //inspWindow.AddInspAlgorithm(InspectType.InspBinary);
                    inspWindow.AddInspAlgorithm(InspectType.PinHeaderCounter); //**추가** 이걸로 함
                    break;
                case InspWindowType.ICLeadCount:
                    //inspWindow.AddInspAlgorithm(InspectType.InspMatch);
                    inspWindow.AddInspAlgorithm(InspectType.ICLeadCounter); //**추가**
                    break;
            }

            return true;
        }

        //타입을 입력하면, 해당 타입의 이름과 UID 이름 반환
        private bool GetWindowName(InspWindowType windowType, out string name, out string prefix)
        {
            name = string.Empty;
            prefix = string.Empty;
            switch (windowType)
            {
                case InspWindowType.Global:
                    name = "Global";
                    prefix = "GLB";
                    break;
                case InspWindowType.Group:
                    name = "Group";
                    prefix = "GRP";
                    break;
                case InspWindowType.Base:
                    name = "Base";
                    prefix = "BAS";
                    break;
                case InspWindowType.Body:
                    name = "Body";
                    prefix = "BDY";
                    break;
                case InspWindowType.Sub:
                    name = "Sub";
                    prefix = "SUB";
                    break;
                case InspWindowType.ID:
                    name = "ID";
                    prefix = "ID";
                    break;
                case InspWindowType.Package:
                    name = "Package";
                    prefix = "PKG";
                    break;
                case InspWindowType.Chip:
                    name = "Chip";
                    prefix = "CHP";
                    break;
                case InspWindowType.PinHeaderCount://**추가**
                    name = "PinHeaderCount";
                    prefix = "PHC";
                    break;
                case InspWindowType.ICLeadCount: //**추가**
                    name = "ICLeadCount";
                    prefix = "ICL";
                    break;
                default:
                    return false;
            }
            return true;
        }

    }
}
