using System;
using System.Globalization;
using System.IO;
using System.Web.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TfsAutomation.ListenerManager;

namespace TfsAutomation.Report
{
    public class HtmlReporter : AbstractDefaultReporter, ITestListener
    {
        private string _currentFile;
        private HtmlTextWriter _navigationFile;
        private HtmlTextWriter _currentHtmlTest;
        private StringWriter _stringWriter;

        private const string NavigationTestClassName = "navigationTests";

        public override void Init(TestContext testContext)
        {
            _stringWriter = new StringWriter();
            _navigationFile = new HtmlTextWriter(_stringWriter);
            _navigationFile.AddAttribute(HtmlTextWriterAttribute.Class, NavigationTestClassName);
        }

        public override void Close()
        {
            //_navigationFile.RenderEndTag();
            // 1. Complete the navigation file
            // </div>
        }

        public override void Report(string title, string message, bool bold, UnitTestOutcome status, DateTime time)
        {
            const string timeStampclassName = "time_stamp";
            _currentHtmlTest.AddAttribute(HtmlTextWriterAttribute.Class, timeStampclassName);
            _currentHtmlTest.RenderBeginTag(HtmlTextWriterTag.Div);
            _currentHtmlTest.Write(time);
            _currentHtmlTest.RenderEndTag();

            
            // add a new report to the test
            // <div class="timestamp">time</div>
            // <div class="report_status_fail/worning/pass">
            _currentHtmlTest.AddAttribute(HtmlTextWriterAttribute.Class, status.ToString().ToLower());
            _currentHtmlTest.RenderBeginTag(HtmlTextWriterTag.Div);

            const string testReportClassName = "test_report";
            _currentHtmlTest.AddAttribute(HtmlTextWriterAttribute.Class, testReportClassName);
            _currentHtmlTest.Write(message);
            _currentHtmlTest.RenderEndTag();

            //      <div class="test_report"><b>message</b></div>
            // </div>

        }

        public override void AddLink(string title, FileStream file)
        {
            // add a new link to the _currentFile html file
            // <div class="link_to_file"><a href="file">title</a></div>
        }

        public override void Step(string stepDescription)
        {
            // add a new step to the existing test
            // <div class="test_step">description</div>
        }

        public void AddFailure(TestContext testContext)
        {
            // Check whether this is called from any place and if yes:
            // 1. Save for summary
        }

        public void AddError(TestContext testContext)
        {
            // Check whether this is called from any place and if yes:
            // 1. Save for summary
        }

        public void StartTest(TestContext testContext)
        {
            var stringWriter = new StringWriter();
            _currentHtmlTest = new HtmlTextWriter(stringWriter);


            // 1. Create a new html file with test name from : testContext.TestName
            // 2. Save in _currentFile            
        }

        public void EndTest(TestContext testContext)
        {
            // 1. Add to the beginning of the file the following summary
            // <div class="test_summary">
            //      <div>Title</div>
            //      <div>Duration</div>
            //      <div>Status</div>
            // </div>
            // 2. Add the name of the file to the navigation
        }
    }
}
