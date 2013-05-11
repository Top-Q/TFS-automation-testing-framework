using Microsoft.VisualStudio.TestTools.UnitTesting;
using TfsAutomation.Report;
using TfsAutomation.Test;
using TfsAutomation.ListenerManager;

namespace TfsAutomationCore.Tests
{
    [TestClass]
    public abstract class AbstractTestCaseExample : BaseTest
    {
        [AssemblyInitialize]
        public static void AssemblyInitiaize(TestContext testContext)
        {
            TestListenerManagerImpl.Instance.AddListener(new TestContextReporter());
            TestListenerManagerImpl.Instance.Init(testContext);
            //TestListenerManagerImpl.Instance.addListener(new HtmlReporter());
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            TestListenerManagerImpl.Instance.Close();
        }
    }
}
