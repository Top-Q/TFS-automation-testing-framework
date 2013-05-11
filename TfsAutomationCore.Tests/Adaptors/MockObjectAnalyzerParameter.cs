using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TfsAutomation.AnalyzerParameters;

namespace TfsAutomationCore.Tests.Adaptors
{
    class MockObjectAnalyzerParameter : AbstractAnalyzerParameter

    {
        public override void Analyze()
        {
            Status = true;
           //Do nothing
        }
    }
}
