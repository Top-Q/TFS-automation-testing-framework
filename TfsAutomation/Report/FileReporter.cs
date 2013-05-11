using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TfsAutomation.Report
{
    public class FileReporter : AbstractDefaultReporter
    {
        private readonly StreamWriter _file;

        public FileReporter()
        {
            Directory.CreateDirectory("Logs");
            string path = string.Format("Logs\\loggerReporter{0}.txt", DateTime.Now);
            path = path.Replace("/", "");
            path = path.Replace(":", "");
            path = path.Replace(" ", "");
            _file = new StreamWriter(path);
        }

        public void Write(string message)
        {
            _file.WriteLine(message);
            Console.WriteLine(message);
        }

        public override void Init(TestContext testContext)
        {
        }

        public override void Close()
        {
            _file.Close();
        }

       

        public override void Report(string title, string message, bool bold, UnitTestOutcome status, DateTime time)
        {            
                Write(FormatReportString(title, message, status,time));

        }

     
        public override void AddLink(string title, FileStream file)
        {
            throw new NotImplementedException();
        }    
       

        private string FormatReportString(string title, string message, UnitTestOutcome status,DateTime time)
        {
            return time.ToString("HH:mm:ss") +
                (status == UnitTestOutcome.InProgress ? "" : " " + status.ToString("G").ToUpper()) +
                (title.Equals(null) || title.Equals("") ? "" : " " + title) +
                      (message.Equals(null) || message.Equals("") ? "" : "\n" + message + "\n");
        }

        public override void Step(string stepDescription)
        {
            throw new NotImplementedException();
        }
    }

    
}
