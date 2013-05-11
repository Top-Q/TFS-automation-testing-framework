using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TfsAutomation.Adaptors;


namespace TfsAutomation.AnalyzerParameters
{
    [TestClass]
    public class AnalyzersTests
    {
        /// <summary>
        /// Given we have analyzer with text in the lastResponse object
        /// When we analyze the result with text that is included in the lastResponse text
        /// Then the analyze process is successful.
        /// </summary>
        [TestMethod]
        public void TestSuccessfulSimpleAnalyzing()        
        {
            //Given
            AnalyzerImpl analyzer = new AnalyzerImpl();
            analyzer.LastResponse = "This is some test text";
            FindText parameter = new FindText("some");


            //When
            analyzer.Analyze(parameter);

            //Then
            Assert.AreEqual(true,parameter.Status);
            Assert.AreEqual(FindText.SuccessMessage, parameter.Title);
        }


        /// <summary>
        /// Given we have analyzer with text in the lastResponse object
        /// When we analyze the result with text that is included in the lastResponse text
        /// Then the analyze process is successful.
        /// </summary>
        [TestMethod]
        public void TestFailureInSimpleAnalyzing()
        {
            //Given
            AnalyzerImpl analyzer = new AnalyzerImpl();
            analyzer.LastResponse = "This is some test text";
            FindText parameter = new FindText("other text");
            
            //When
            analyzer.Analyze(parameter);

            //Then
            Assert.AreEqual(false, parameter.Status);
            Assert.AreEqual(FindText.FailureMessage, parameter.Title);

        }
        public void TestGetResultToAnalyzeType()
        {

        }
    }
}
