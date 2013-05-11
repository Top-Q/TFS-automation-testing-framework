using Microsoft.VisualStudio.TestTools.UnitTesting;
using TfsAutomation.ListenerManager;
using TfsAutomation.Report;
using TfsAutomation.Adaptors;


namespace TfsAutomation.Test
{
    public class BaseTest 
    {
        protected IReporter Report = TestListenerManagerImpl.Instance;

        protected AdaptorsManager AdaptorsManager = AdaptorsManager.Instance;
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; protected set; }


        [TestInitialize]
        public void TfsAutomationTestInitalize()
        {
            TestListenerManagerImpl.Instance.StartTest(TestContext);
        }

        [TestCleanup]
        public void TfsAutomationTestCleanup()
        {
            TestListenerManagerImpl.Instance.EndTest(TestContext);
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            

            TestListenerManagerImpl.Instance.
        }





      

        // assablmy init // move this out the another class - system class 
           }
}
