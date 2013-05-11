using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TfsAutomation.Adaptors
{
    public abstract class AdaptorImpl : AnalyzerImpl
    {

        public abstract void Init();


        public abstract void Close();
    
    }
}
