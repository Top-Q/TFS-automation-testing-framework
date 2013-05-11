using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TfsAutomationCore.Tests
{
    [TestClass]
    public class Sandbox
    {
        [TestMethod]
        public void TestDate()
        {
            
            Console.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
            Console.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
        }
    }
}
