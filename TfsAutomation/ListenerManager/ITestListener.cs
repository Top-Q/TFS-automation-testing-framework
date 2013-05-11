using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TfsAutomation.ListenerManager
{
    public interface ITestListener
    {
        void AddFailure(TestContext testContext);

        void AddError(TestContext testContext);
        
        void StartTest(TestContext testContext);

        void EndTest(TestContext testContext);

        void EndExecution();

        void StartExecution();


    }
}
