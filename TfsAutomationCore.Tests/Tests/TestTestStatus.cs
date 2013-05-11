using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TfsAutomation.Test;

namespace TfsAutomationCore.Tests.Tests
{
    [TestClass]
    public class TestTestStatus: BaseTest
    {
        [TestMethod]
        public void TestFailure()
        {
            Report.Report("This is the test");
            throw new Exception("Failure");
        }

        [TestMethod]
        public void ChangeTestStatus()
        {
            Console.WriteLine("Before");
            try
            {
                Assert.IsNotNull(null);
            }
            catch (UnitTestAssertException e)
            {
                Console.WriteLine("Caught exception");
            }
            
            Console.WriteLine("After");
        }

        [TestCleanup]
        public void After()
        {
            UnitTestOutcome outCome = TestContext.CurrentTestOutcome;
            Console.WriteLine(outCome.ToString());
        }
    }
}
