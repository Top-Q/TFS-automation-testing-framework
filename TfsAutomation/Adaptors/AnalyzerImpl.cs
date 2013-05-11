using System;
using TfsAutomation.Report;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TfsAutomation.ListenerManager;

namespace TfsAutomation.Adaptors
{
    public class AnalyzerImpl: IAnalyzer
    {
        protected readonly IReporter report = TestListenerManagerImpl.Instance;

        private object _lastResponse;

        public object LastResponse
        {
            get { return _lastResponse; }
            set { _lastResponse = value; }
        }

        public void Analyze(IAnalyzerParameter analyzerParameter)
        {
            Analyze(analyzerParameter, false);
        }

        public void Analyze(IAnalyzerParameter analyzerParameter, bool silent)
        {
            Analyze(analyzerParameter, silent, false, null, null);
        }

        public void Analyze(IAnalyzerParameter analyzerParameter, bool silent, bool showAsInconclusive)
        {
            Analyze(analyzerParameter, silent, showAsInconclusive, null, null);
        }

        public void Analyze(IAnalyzerParameter parameter, bool silent, bool showAsInconclusive, string successMessage, string failMessage)
        {
            if (null == parameter)
            {
                //TODO: Set the correct exception
                throw new Exception("Analyzer parameter can't be null");
            }

            parameter.Message = null;

            parameter.Title = null;

            parameter.Status = false;

            try
            {
                if (_lastResponse != null)
                {
                    Type t = parameter.GetResultToAnalyzeType();

                    if (t != null && !t.IsAssignableFrom(_lastResponse.GetType()))
                    {
                        parameter.Title = "Use of wrong analyzer";
                        parameter.Message = "The analyzer that you used requires input in " + t.Name
                                + " type, but the object to analyze is of " + _lastResponse.GetType().Name
                                + " type.";
                        parameter.Status = false;
                    }
                    else
                    {
                        parameter.ResultToAnalyze = _lastResponse;
                        parameter.Analyze();
                    }
                }
                else
                { // if the test against is null
                    parameter.Title = "The object to analyze is null";
                    parameter.Message = "The object to analyze is null, please check that you run the analyze method on the right object";
                    parameter.Status = false;
                }
                if (!silent || (!parameter.Status))
                {
                    UnitTestOutcome status = UnitTestOutcome.Passed;
                    string title = successMessage ?? parameter.Title;
                    if (!parameter.Status)
                    {
                        title = failMessage ?? parameter.Title;
                        if (showAsInconclusive)
                        {
                            status = UnitTestOutcome.Inconclusive;
                        }
                        else
                        {
                            status = UnitTestOutcome.Failed;
                        }
                    }
                    report.Report(title, parameter.Message, status);
                }
            }
            catch (Exception)
            {
                if (!silent)
                {
                    //TODO: Add the exception
                    report.Report("Analyze proccess failed");
                }
            }
        }

        public bool IsAnalyzeSuccessful(IAnalyzerParameter analyzerParameter)
        {
            throw new NotImplementedException();
        }

        public void SetThrowException(bool throwException)
        {
            throw new NotImplementedException();
        }
    }
}
