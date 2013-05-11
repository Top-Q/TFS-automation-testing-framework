using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TfsAutomation.Adaptors;

namespace TfsAutomation.AnalyzerParameters
{
    public abstract class AbstractAnalyzerParameter : IAnalyzerParameter
    {
        private object resultToAnalyze;
        private string title;
        private bool status;
        private string message;
        
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                message = value;
            }
        }

        public bool Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }

        public virtual object ResultToAnalyze
        {
          
            set
            {
                resultToAnalyze = value;
            }
        }

        public virtual Type GetResultToAnalyzeType()
        {
            return new Object().GetType();
            
        }

        public abstract void Analyze();
       
    }
}
