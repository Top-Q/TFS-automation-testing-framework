using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TfsAutomation.Adaptors
{
    public interface IAnalyzerParameter
    {
        /// <summary>
        /// Title to be displayed in the report. This field is mandatory
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// Message to be displayed. If the message is not null the 'title' 
        /// will perform as link that when clicked will display the message.
        /// </summary>
        string Message { get; set; }

        /// <summary>
        /// The result of the assertion process. 
        /// </summary>
        bool Status { get; set; }

        /// <summary>
        /// Will be set by the framework with the actual object to analyze.
        /// </summary>
        object ResultToAnalyze { set; }

        /// <summary>
        /// Returns the result object type this assert object is deisgned to assert.
        /// </summary>
        Type GetResultToAnalyzeType();

        /// <summary>
        /// Starts the assertion process
        /// </summary>
        void Analyze();
    }
}
