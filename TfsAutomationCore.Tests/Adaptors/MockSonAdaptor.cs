using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TfsAutomation.Adaptors;

namespace TfsAutomationCore.Tests.Adaptors
{
    public class MockSonAdaptor : AdaptorImpl
    {

        public string Host
        { get; set; }

        public override void Init()
        {

        }

        public override void Close()
        {
        }


             
    }
}
