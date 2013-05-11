using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace TfsAutomation.Report
{
    public abstract class AbstractDefaultReporter : IReporter
    {
       
        public abstract void Init(TestContext testContext);
        public abstract void Close();
        public void Report(string title)
        {
            Report(title, "");
        }

        public void Report(string title, string message)
        {
            Report(title, message, UnitTestOutcome.Passed);
        }

        public void Report(string title, UnitTestOutcome status)
        {
            Report(title, "",status);
        }
        public void Report(string title, string message, UnitTestOutcome status)
        {
            Report(title, message, false, status);
        }
        public void Report(string title, string message, bool bold, UnitTestOutcome status)
        {
            Report(title, message, false, status, DateTime.Now);

        }
        public abstract void Report(string title, string message, bool bold, UnitTestOutcome status, DateTime time);


        public void Report(string title, Exception exception)
        {
            Report(title, exception.Message, UnitTestOutcome.Error);
        }  
        
      

        public abstract void AddLink(string title, FileStream file);
        

        //void Report(Exception exception);
        public abstract void Step(string stepDescription);

    }
}
