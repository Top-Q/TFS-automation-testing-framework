using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TfsAutomation.Adaptors;
using TfsAutomation.ListenerManager;
using TfsAutomation.Test;
using TfsAutomationCore.Tests.Adaptors;

namespace TfsAutomationCore.Tests.Tests
{
    [TestClass]
    public class WebDriverTest : BaseTest
    {
        private WebDriverAdaptor adaptor;

        [TestInitialize]
        public void Init()
        {

            var stream = File.OpenRead(@"C:\Users\liel_r\Dropbox\Top-Q\Projects\TFS\Tfs\trunk\TfsAutomationCore.Tests\SUT\sut.xml");
           // var stream = GetType().Assembly.GetManifestResourceStream(@"TfsAutomationCore.Tests\SUT\sut.xml");
            adaptor = (WebDriverAdaptor)AdaptorsManager.Instance.GetAdaptor("mock", typeof(WebDriverAdaptor), stream);

            if(adaptor.GetBrowserIsOpened() == false)
            {
                adaptor.Init();
            }
            
        }

        [TestCleanup]
        public void Close()
        {
            if(adaptor !=null)
            {
                adaptor.Close();
            }
        }

        [TestMethod]
        public void TestGoogle()
        {
            Assert.IsNotNull(adaptor, "Failed to initanciate adaptor");
            adaptor.driver.Navigate().GoToUrl(@"http://www.google.com");
        }

        [TestMethod]
        public void TestYahoo()
        {
            Assert.IsNotNull(adaptor, "Failed to initanciate adaptor");
            adaptor.driver.Navigate().GoToUrl(@"http://www.yahoo.com");
        }
    }
}
