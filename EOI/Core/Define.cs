using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOI.Core
{
    public enum MachineType
    {
        None = 0,
        SMT,
        PCB,
        CABLE
    }

    //#MODEL#1 InspWindowType 정의
    public enum InspWindowType
    {
        None = 0,
        Global,
        Group,
        Base,
        Body,
        Sub,
        ID,
        Package,
        Chip,
        Pad
    }

    public static class Define
    {
        //**jh : ⏺️ 이미지 저장 폴더명
        public static readonly string TEMPLATE_FOLDER = "Images";

        /// <summary>
        /// 티칭 이미지 저장 (UID별 하위 폴더 t001.png, t002.png, ...)
        /// </summary>
        public static void SaveTemplateImages(string uid, List<Mat> templateList)
        {
            if (string.IsNullOrEmpty(uid) || templateList == null)
                return;

            string modelDir = Path.GetDirectoryName(Global.Inst.InspStage.CurModel.ModelPath);
            string imgDir = Path.Combine(modelDir, TEMPLATE_FOLDER, uid);

            if (Directory.Exists(imgDir))
            {
                var oldFiles = Directory.GetFiles(imgDir, "t*.png");
                foreach (var file in oldFiles)
                    File.Delete(file);
            }
            else
            {
                Directory.CreateDirectory(imgDir);
            }

            for (int i = 0; i < templateList.Count; i++)
            {
                string fileName = $"t{(i + 1).ToString("D3")}.png";
                string savePath = Path.Combine(imgDir, fileName);
                try
                {
                    Cv2.ImWrite(savePath, templateList[i]);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[SaveTemplateImages] 저장 실패: {savePath} - {ex.Message}");
                }
            }
        }

        /// <summary>
        /// 티칭 이미지 로드 (UID 폴더 내 t001.png ~ 순서대로)
        /// </summary>
        public static List<Mat> LoadTemplateImages(string uid)
        {
            List<Mat> templates = new List<Mat>();

            if (string.IsNullOrEmpty(uid))
                return templates;

            string modelDir = Path.GetDirectoryName(Global.Inst.InspStage.CurModel.ModelPath);
            string imgDir = Path.Combine(modelDir, TEMPLATE_FOLDER, uid);

            if (!Directory.Exists(imgDir))
                return templates;

            var files = Directory.GetFiles(imgDir, "t*.png").OrderBy(f => f).ToList();

            foreach (var file in files)
            {
                Mat img = Cv2.ImRead(file);
                if (img != null && !img.Empty())
                    templates.Add(img);
            }

            return templates;
        }
    }
}
