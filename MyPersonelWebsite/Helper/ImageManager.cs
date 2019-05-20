using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyPersonelWebsite.Helper
{
    public static class ImageManager
    {
        public static string UploadImage(IFormFile file, string fileformat, string folderpath, IHostingEnvironment env)
        {
            if (file.Length > 0 && (
                file.ContentType == "image/jpeg" ||
                file.ContentType == "image/png"
            ))
            {
                try
                {
                    string path = env.WebRootPath + "\\" + folderpath;
                    string filename = fileformat + file.FileName.Substring(file.FileName.LastIndexOf('.'));

                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (FileStream filestream = System.IO.File.Create(path + filename))
                    {
                        file.CopyTo(filestream);
                        filestream.Flush();
                        return folderpath + filename;
                    }
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public static void DeleteImage(string localfilepath, IHostingEnvironment env)
        {
            string path = env.WebRootPath + "\\" + localfilepath;
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
        }
    }
}
