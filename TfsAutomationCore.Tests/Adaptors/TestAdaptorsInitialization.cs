using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Xml.Serialization;
using TfsAutomation.Adaptors;


namespace TfsAutomationCore.Tests.Adaptors
{
    [TestClass]
    public class TestAdaptorsInitialization
    {
        [TestMethod]
        public void TestSimpleInstanciateAdaptor()
        {
           MockAdaptor adaptor = (MockAdaptor)AdaptorsManager.Instance.GetAdaptor("mock",typeof(MockAdaptor));
           Assert.IsNotNull(adaptor,"Failed to initanciate adaptor");
          

        }

        [TestMethod]
        public void TestInstanciateAdaptorTwice()
        {
            var stream = GetType().Assembly.GetManifestResourceStream("TfsAutomationCore.Tests.SUT.sut.xml");
            MockAdaptor adaptor = (MockAdaptor)AdaptorsManager.Instance.GetAdaptor("mock", typeof(MockAdaptor), stream);
            Assert.IsNotNull(adaptor, "Failed to initanciate adaptor");
            adaptor.Host = "New Host";
            adaptor = (MockAdaptor)AdaptorsManager.Instance.GetAdaptor("mock", typeof(MockAdaptor));
            Assert.AreEqual("New Host", adaptor.Host);




        }
    }
}
