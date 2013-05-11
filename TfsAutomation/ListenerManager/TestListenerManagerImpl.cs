using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TfsAutomation.Adaptors;
using TfsAutomation.Report;
using System.IO;
using System.Collections.Generic;

namespace TfsAutomation.ListenerManager
{
    public class TestListenerManagerImpl : AbstractDefaultReporter, ITestListener
    {
        private static readonly TestListenerManagerImpl instance = new TestListenerManagerImpl();
        private UnitTestOutcome _saveTestStatusIfFailed = UnitTestOutcome.Passed;

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static TestListenerManagerImpl()
        {
        }

        private TestListenerManagerImpl()
        {
        }

        public static TestListenerManagerImpl Instance
        {
            get { return instance; }
        }

        #region Observer pattern implementation

        private HashSet<Object> listeners = new HashSet<Object>();

        public void AddListener(Object listener)
        {
            listeners.Add(listener);
        }

        public void RemoveListener(Object listener)
        {
            listeners.Remove(listener);
        }

        #endregion


        #region IReporter implementation

        

        public override void Init(TestContext testContext)
        {
            foreach (var listener in listeners)
            {
                if (listener is IReporter)
                {
                    ((IReporter) listener).Init(testContext);
                }

            }
        }

        public override void Close()
        {
            foreach (var listener in listeners)
            {
                if (listener is IReporter)
                {
                    ((IReporter) listener).Close();
                }
            }
        }

        public override void Report(string title, string message, bool bold, UnitTestOutcome status, DateTime time)
        {
            if (status.Equals(UnitTestOutcome.Failed) || status.Equals(UnitTestOutcome.Error))
                _saveTestStatusIfFailed = status;

            foreach (var listener in listeners)
            {
                if (listener is IReporter)
                {
                    ((IReporter) listener).Report(title, message, bold, status, time);
                }
            }

        }

        public override void AddLink(string title, FileStream file)
        {
            foreach (var listener in listeners)
            {
                if (listener is IReporter)
                {
                    ((IReporter) listener).AddLink(title, file);
                }
            }
        }

        public override void Step(string stepDescription)
        {
            foreach (var listener in listeners)
            {
                if (listener is IReporter)
                {
                    ((IReporter) listener).Step(stepDescription);
                }
            }
        }

        #endregion

        #region ITestListener implementation

        public void AddFailure(TestContext testContext)
        {
        }

        public void AddError(TestContext testContext)
        {
        }

        public void StartTest(TestContext testContext)
        {
            _saveTestStatusIfFailed = UnitTestOutcome.Passed;
            foreach (var listener in listeners.OfType<ITestListener>())
            {
                (listener).StartTest(testContext);
            }
        }

        public void EndTest(TestContext testContext)
        {
            foreach (var listener in listeners.OfType<ITestListener>())
            {
                (listener).EndTest(testContext);
            }
            if (IsTestFailed())
                Assert.Fail("Test was failed see Test Result Details");
        }

        public void EndExecution()
        {
            foreach (var listener in listeners.OfType<AdaptorImpl>())
            {
                (listener).Close();
            }

        }

        public void StartExecution()
        {
            throw new NotImplementedException();
        }

        private bool IsTestFailed()
        {
            return _saveTestStatusIfFailed.Equals(UnitTestOutcome.Error) || _saveTestStatusIfFailed.Equals(UnitTestOutcome.Failed);
        }

        #endregion

    }
}
