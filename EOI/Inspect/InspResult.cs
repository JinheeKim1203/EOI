﻿using EOI.Core;
using EOI.Teach;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace EOI.Inspect
{
    //#RESULT FORM#1 검사 결과를 저장하기 위한 클래스
    public class InspResult
    {
        //검사한 ROI 정보
        public InspWindow InspObject { get; set; }
        //ROI가 여러개 있을 때, 기준이 되는 ROI
        public string GroupID { get; set; }
        //실제 검사한 ROI
        public string ObjectID { get; set; }

        //검사한 ROI의 타입
        public InspWindowType ObjectType { get; set; }

        //검사한 알고리즘 타입
        public InspectType InspType { get; set; }
        //검사 결과 코드
        public int ErrorCode { get; set; }
        //결과가 불량인지 여부
        public bool IsDefect { get; set; }
        //결과 값(점수가 아닌 실제 값)
        public string ResultValue { get; set; }
        //세부적인 검사 결과
        public string ResultInfos { get; set; }

        //검사 결과로 찾은 불량 위치
        public List<Rect> ResultRectList { get; set; } = null;

        public InspResult()
        {
            InspObject = new InspWindow();
            GroupID = string.Empty;
            ObjectID = string.Empty;
            ObjectType = InspWindowType.None;
            ErrorCode = 0;
            IsDefect = false;
            ResultValue = "";
            ResultInfos = string.Empty;
        }

        public InspResult(InspWindow window, string baseID, string objectID, InspWindowType objectType)
        {
            InspObject = window;
            GroupID = baseID;
            ObjectID = objectID;
            ObjectType = objectType;
            ErrorCode = 0;
            IsDefect = false;
            ResultValue = "";
            ResultInfos = string.Empty;
        }
    }
}
