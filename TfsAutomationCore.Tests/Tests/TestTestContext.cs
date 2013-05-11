using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TfsAutomation.Test;

namespace TfsAutomationCore.Tests.Tests
{
    [TestClass]
    public class TestTestContext : BaseTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Console.WriteLine(TestContext.ToString());
            TestContext.Properties.Add("one", "Itai");

        }

        [TestMethod]
        public void TestMethod2()
        {
           
            Console.WriteLine(TestContext.ToString());
        }
    }
}
