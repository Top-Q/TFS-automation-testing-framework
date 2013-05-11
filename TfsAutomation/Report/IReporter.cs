using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace TfsAutomation.Report
{
   

    public interface IReporter
    {      
        void Init(TestContext testContext);
        void Close();
        void Report(string title);
        void Report(string title, string message);                
        void Report(string title, string message, UnitTestOutcome status);
        void Report(string title, UnitTestOutcome status);
        void Report(string title, string message,bool bold, UnitTestOutcome status);
        void Report(string title, string message, bool bold,UnitTestOutcome status,DateTime time);
        void Report(string title, Exception exception);
        //void ReportHtml(string title, string html, UnitTestOutcome status);

        void AddLink(string title, FileStream file);
        //void AddLink(string title, string filePath);

        //void Report(Exception exception);
        void Step(string stepDescription);
    }
}
