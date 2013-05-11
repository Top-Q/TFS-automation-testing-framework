using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TfsAutomation.Adaptors;
using TfsAutomation.AnalyzerParameters;
using TfsAutomationCore.Tests.Adaptors;


namespace TfsAutomation
{
    [TestClass]
    public class AnalyzersImplTests
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



        [TestMethod]
        public void TestAllowsToAnalyzeInhritentFrom()
        {
                     
            //Given
            AnalyzerImpl analyzer = new AnalyzerImpl();
            analyzer.LastResponse = new String(new char[] {});
            MockObjectAnalyzerParameter parameter = new MockObjectAnalyzerParameter();

            //When
            analyzer.Analyze(parameter);

            //Then
            Assert.AreEqual(true, parameter.Status);
        }

        [TestMethod]
        public void TestNotAllowsToAnalyzeInhritentFrom()
        {

            //Given
            AnalyzerImpl analyzer = new AnalyzerImpl();
            analyzer.LastResponse = new Object();
            MockStringAnalyzerParameter parameter = new MockStringAnalyzerParameter();

            //When
            analyzer.Analyze(parameter);

            //Then
            Assert.AreEqual(false, parameter.Status);
        }

    }
}
