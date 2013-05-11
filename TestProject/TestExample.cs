using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TfsAutomation.Test;


namespace TestProject
{
    /// <summary>
    /// Summary description for TestExample
    /// </summary>
    [TestClass]
    public class TestExample : BaseTest
    {
        public TestExample()
        {
        }

        [TestMethod]
        public void FailTest()
        {
            Report.Report("This Test should Fail");
            Assert.IsNotNull(null);
        }

        [TestMethod]
        public void PassTest()
        {
            Report.Report("This Test should Pass");
            Assert.IsNotNull("Liel");
        }


        [TestMethod]
        public void FailReport()
        {
            Report.Report("This Test should Fail",TfsAutomation.Report.ReportStatus.Fail);
            
        }

        [TestMethod]
        public void ErrorReport()
        {
            Report.Report("This Test should be with Error", TfsAutomation.Report.ReportStatus.Error);

        }

        [TestMethod]
        public void PassReport()
        {
            Report.Report("This Test should Pass", TfsAutomation.Report.ReportStatus.Pass);

        }

        [TestMethod]
        public void WarningReport()
        {
            Report.Report("This Test should be with Warning", TfsAutomation.Report.ReportStatus.Warning);

        }
    }
}
