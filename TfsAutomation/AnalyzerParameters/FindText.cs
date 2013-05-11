using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TfsAutomation.AnalyzerParameters
{
    public class FindText : AbstractAnalyzerParameter
    {
        public static readonly string SuccessMessage = "Text was found";
        public static readonly string FailureMessage = "Text was not found";
        
        private String _actualText;

        private readonly string _textToFind;

        public FindText(string textToFind)
        {
            this._textToFind = textToFind;
        }

        public override void Analyze()
        {
            if (null == _actualText)
            {
                Status = false;
                Title = "Text to analyze is null";
                return;
            }
            if (_actualText.Contains(_textToFind))
            {
                Status = true;
                Title = SuccessMessage;
            }
            else
            {
                Status = false;
                Title = FailureMessage;
            }
        }

        public override object ResultToAnalyze
        {
            set
            {
                if (null != value)
                {
                    _actualText = (String)value;
                }
                
            }
        }
        
        
        public override Type GetResultToAnalyzeType()
        {
            return "".GetType();

        }

        
    }
}
