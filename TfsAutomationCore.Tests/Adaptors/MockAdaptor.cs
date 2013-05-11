using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TfsAutomation.Adaptors;
using System.Xml.Serialization;

namespace TfsAutomationCore.Tests.Adaptors
{
    public class MockAdaptor : AdaptorImpl
    {

        public string Host
        { get; set; }

        public MockSonAdaptor Son
        { get; set; }


        public override void Init()
        {
            report.Report("In adaptor init");
        }

        public override void Close()
        {
            report.Report("In adaptor close");
        }
    }
}
