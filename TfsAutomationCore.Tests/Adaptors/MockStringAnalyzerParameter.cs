using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TfsAutomation.AnalyzerParameters;

namespace TfsAutomationCore.Tests.Adaptors
{
    class MockStringAnalyzerParameter : AbstractAnalyzerParameter

    {
        public override void Analyze()
        {
            Status = true;
           //Do nothing
        }

        public override Type GetResultToAnalyzeType()
        {
            return new String(new char[]{}).GetType();

        }
    }
}
