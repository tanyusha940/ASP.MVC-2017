using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ASP.MVC_2017.Helpers
{
    public class UploadImageHelper
    {
        public string UploadImageToCloud(HttpPostedFileBase image, DirectoryInfo directory)
        {
            string fName = image.FileName;
            if (image != null && image.ContentLength > 0)
            {
                var originalDirectory = new DirectoryInfo(string.Format("{0}Images\\WallImages", directory));
                string pathString = System.IO.Path.Combine(originalDirectory.ToString(), "imagepath");
                var fileName1 = Path.GetFileName(image.FileName);
                bool isExists = Directory.Exists(pathString);
                if (!isExists)
                    Directory.CreateDirectory(pathString);
                var path = string.Format("{0}\\{1}", pathString, image.FileName);
                image.SaveAs(path);
                return path;
            }
            return null;
        }
    }
}