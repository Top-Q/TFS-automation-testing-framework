using System;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TfsAutomation.ListenerManager;

namespace TfsAutomation.Report
{
    public class TestContextReporter : AbstractDefaultReporter, ITestListener
    {
        private TestContext _testContext;
        
        #region ITestListener
        public void AddFailure(TestContext testContext)
        {
        }

        public  void AddError(TestContext testContext)
        {
        }

        public void StartTest(TestContext testContext)
        {
            _testContext = testContext;
        }

        public void EndTest(TestContext testContext)
        {
        }
        #endregion

        public override void Report(string title, string message, bool bold, UnitTestOutcome status, DateTime time)
        {
            WriteToTestContext(FormatReportString(title, message, status, time));
        }

        public override void AddLink(string title, FileStream file)
        {
            throw new NotImplementedException();
        }

        private string FormatReportString(string title, string message, UnitTestOutcome status, DateTime time)
        {
            var tmp = time.ToShortTimeString() +
                         (status == UnitTestOutcome.InProgress ? "" : " " + status.ToString("G").ToUpper()) +
                         (string.IsNullOrEmpty(title) ? "" : " " + title);
            var stringBulder = new StringBuilder(tmp);
            if (!string.IsNullOrEmpty(message))
            {
                stringBulder.AppendLine("");
                stringBulder.AppendLine(message);
            }
            return stringBulder.ToString();
        }

        private void WriteToTestContext(string message)
        {
            if (null != _testContext)
            {
                _testContext.WriteLine("{0}",message); 
            }
        
        }


        public override void Init(TestContext testContext)
        {
            
        }

        public override void Close()
        {
          
        }





        public override void Step(string stepDescription)
        {
            
        }
    }
}
