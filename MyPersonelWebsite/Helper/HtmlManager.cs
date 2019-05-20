using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using System.Text;

namespace MyPersonelWebsite.Helper
{
    public static class HtmlManager
    {
        public static string CreateHtml(string Content, string filename, string folderpath, IHostingEnvironment env)
        {
            if (string.IsNullOrEmpty(Content) || string.IsNullOrEmpty(folderpath)) { return null; }

            try
            {
                string path = env.WebRootPath + "\\" + folderpath;
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                using (FileStream fs = File.Create(path + filename + ".html"))
                {
                    Byte[] info = new UTF8Encoding(true).GetBytes(Content);
                    fs.Write(info, 0, info.Length);
                    return folderpath + filename + ".html";
                }
            }
            catch { }
            return null;
        }

        public static void WriteHtml(string localfilepath, string content, IHostingEnvironment env)
        {
            string path = env.WebRootPath + "\\" + localfilepath;
            if (!System.IO.File.Exists(path))
                return;

            File.WriteAllText(path, content);
        }


        public static string ReadHtml(string localfilepath, IHostingEnvironment env)
        {
            string path = env.WebRootPath + "\\" + localfilepath;
            if (!System.IO.File.Exists(path))
                return null;
            return System.IO.File.ReadAllText(path);
        }

        public static void DeleteHtml(string localfilepath, IHostingEnvironment env)
        {
            string path = env.WebRootPath + "\\" + localfilepath;
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
        }
    }

}
