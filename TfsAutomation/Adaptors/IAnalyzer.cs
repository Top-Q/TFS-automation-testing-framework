using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TfsAutomation.Adaptors
{
    public interface IAnalyzer
    {
        /// <summary>
        /// The object to analyze.
        /// </summary>
        object LastResponse { get; }

        /// <summary>
        /// Analyzes the result. Reports to the reporter.
        /// </summary>
        /// 
        /// <param name="assertParameter"></param>
        /// <param name="e">Exception will be thrown if analysis was fail</param>
        void Analyze(IAnalyzerParameter analyzerParameter);

        /// <summary>
        /// Analyzes the result. Reports to the reporter.
        /// Send AssertException if analyze fails.
        /// 
        /// </summary>
        /// <exception cref="AssertionException">Throws if assertion fails</exception>
        /// <param name="assertParameter">AssertParameter will be used in analisis</param>
        /// <param name="silence">Will not report anything in case of success</param>
        ///     
        void Analyze(IAnalyzerParameter analyzerParameter, bool silent);
        

        void Analyze(IAnalyzerParameter analyzerParameter, bool silent, bool showAsWarning);


        void Analyze(IAnalyzerParameter parameter, bool silent, bool showAsWarning, string successMessage, string failMessage);

        /// <summary>
        /// Analyses the result
        /// </summary>
        /// <param name="assertParameter"></param>
        /// <returns>true if and only if assertion was successful</returns>

        bool IsAnalyzeSuccessful(IAnalyzerParameter analyzerParameter);

        /// <summary>
        /// If set to false an exception will not be thrown
        /// </summary>
        /// <param name="throwException"></param>
        void SetThrowException(bool throwException);
    }
}
