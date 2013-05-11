using System.Collections.Generic;
using System.IO;
using System.Text;

namespace POC
{
    class FileAccessUtils
    {
        private const int StreamBufferSize = 4096;

        public void CreateFile()
        {
        }

        public void DeleteFile()
        {
        }

        public void WriteToFile(string fileName, string text, bool append)
        {
            if (!append)
            {
                if (File.Exists(fileName))
                    File.Delete(fileName);
            }
            var fs = File.Create(fileName, StreamBufferSize);
            var info = new UTF8Encoding(true).GetBytes(text);
            if (fs.CanWrite)
            {
                fs.Write(info, 0, info.Length);
            }
            fs.Flush();
            fs.Close();
        }

        public List<string> ReadFromFileToList(string fileName)
        {
            if (!File.Exists(fileName))
                return null;
            var retList = new List<string>();
            var sr = File.OpenText(fileName);
            string s;
            while ((s = sr.ReadLine()) != null)
            {
                retList.Add(s);
            }
            return retList;
        }

        public string ReadFromFile(string fileName)
        {
            var strBuilder = new StringBuilder();
            var fs = File.OpenRead(fileName);

            var b = new byte[1024];
            var temp = new UTF8Encoding(true);
            while (fs.Read(b, 0, b.Length) > 0)
            {
                strBuilder.Append(temp.GetString(b));
                //Console.WriteLine(temp.GetString(b));
            }
            return strBuilder.ToString();
        }

        /// <summary>
        /// Get random string of 11 characters
        /// </summary>
        /// <returns>Random string</returns>
        public static string GetRandomString()
        {
            var path = Path.GetRandomFileName();
            path = path.Replace(".", "");
            return path;
        }

    }
}
