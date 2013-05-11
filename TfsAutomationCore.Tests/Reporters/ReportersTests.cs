using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;

namespace TfsAutomationCore.Tests.Reporters
{
    [TestClass]
    public class ReportersTests : AbstractTestCaseExample
    {
        [TestMethod]
        public void TestReportFailed()
        {
            Report.Report("This is my report");
            Report.Report("title", "message", UnitTestOutcome.Failed);
        }

        [TestMethod]
        public void TestReportError()
        {
            Report.Report("This is my report for error");
            Report.Report("title", "error message", UnitTestOutcome.Error);
        }

        [TestMethod]
        public void TestReportException()
        {
            Report.Report("This is my report for error");
            Report.Report("Exception", new Exception("exception message with {this sybol}"));
        }

        [TestMethod]
        public void HtmlReporterTest()
        {
            const string clickOnLoginButton = "Click on Login button";
            Report.Report(clickOnLoginButton);
            const string loginIsNotInModule = "Login is not in module";
            Report.Report(loginIsNotInModule, UnitTestOutcome.Failed);
            var htmlResult = new System.IO.StreamReader(TestContext.ResultsDirectory + "\\result.html");
            string line;
            while ((line = htmlResult.ReadLine()) != null)
            {

            }

            htmlResult.Close();
        }
    }
}
