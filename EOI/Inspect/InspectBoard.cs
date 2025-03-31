using EOI.Algorithm;
using EOI.Property;
using EOI.Teach;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace EOI.Inspect
{
    public class InspectBoard
    {
        public InspectBoard()
        {
        }

        public bool Inspect(InspWindow window)
        {
            if (window is null)
                return false;

            if (window.InspWindowType == Core.InspWindowType.Group)
            {
                GroupWindow group = (GroupWindow)window;
                if (!InspectWindowList(group.Members))
                    return false;
            }
            else
            {
                if (!InspectWindow(window))
                    return false;
            }

            return true;
        }

        private bool InspectWindow(InspWindow window)
        {
            window.ResetInspResult();
            foreach (InspAlgorithm algo in window.AlgorithmList)
            {
                //if (algo.IsUse == false)
                //    continue;

                if (!algo.DoInspect())
                    return false;

                string resultInfo = string.Join("\r\n", algo.ResultString);

                InspResult inspResult = new InspResult
                {
                    ObjectID = window.UID,
                    InspType = algo.InspectType,
                    IsDefect = algo.IsDefect,
                    ResultInfos = resultInfo
                };

                switch (algo.InspectType)
                {
                    case InspectType.InspMatch:
                        MatchAlgorithm matchAlgo = algo as MatchAlgorithm;
                        inspResult.ResultValue = $"{matchAlgo.OutScore}";
                        break;
                    case InspectType.InspBinary:
                        BlobAlgorithm blobAlgo = algo as BlobAlgorithm;
                        inspResult.ResultValue = $"{blobAlgo.OutBlobCount}/{blobAlgo.BlobCount}";
                        break;
                    case InspectType.PinHeaderCounter: // **추가**
                        PinHeaderCounter pinHeaderCounter = algo as PinHeaderCounter;                       
                        inspResult.ResultValue = $"{pinHeaderCounter.pinCount}";
                        break;
                    case InspectType.ICLeadCounter: // **추가**
                        ICLeadCounter icLeadCounter = algo as ICLeadCounter;
                        inspResult.ResultValue = $"{icLeadCounter.icLeadCount}";
                        break;
                }

                List<Rect> resultArea = new List<Rect>();
                int resultCnt = algo.GetResultRect(out resultArea);
                inspResult.ResultRectList = resultArea;

                window.AddInspResult(inspResult);
            }

            return true;
        }

        public bool InspectWindowList(List<InspWindow> windowList)
        {
            if (windowList.Count <= 0)
                return false;

            //ID 윈도우가 매칭알고리즘이 있고, 검사가 되었다면, 오프셋을 얻는다.
            Point alignOffset = new Point(0, 0);
            InspWindow idWindow = windowList.Find(w => w.InspWindowType == Core.InspWindowType.ID);
            if (idWindow != null)
            {
                MatchAlgorithm matchAlgo = (MatchAlgorithm)idWindow.FindInspAlgorithm(InspectType.InspMatch);
                if (matchAlgo != null && matchAlgo.IsUse)
                {
                    if (!InspectWindow(idWindow))
                        return false;

                    if (matchAlgo.IsInspected)
                    {
                        alignOffset = matchAlgo.GetOffset();
                        idWindow.InspArea = idWindow.WindowArea + alignOffset;
                    }
                }
            }

            foreach (InspWindow window in windowList)
            {
                //모든 윈도우에 오프셋 반영
                window.SetInspOffset(alignOffset);
                if (!InspectWindow(window)) // 여기에 DoInspect()함수가 호출되어 알고리즘 검사가 적용됨.
                    return false;
            }

            return true;
        }
    }
}