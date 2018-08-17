using System;
using System.Collections.Generic;
using System.Text;
using XCentium.CodeExample.Libraries.WordCollector.Extractors;

namespace XCentium.CodeExample.Libraries.WordCollector.TextAnalyses
{
    public class ProgressBar : IProgressIndicator
    {
        

        public ProgressBar()
        {
            
        }

    

        public virtual int Maximum
        {
            get;set;
        }

        public int CurrentValue { get; set; }

        public virtual void Increment(int value)
        {
            ++CurrentValue;
        }

        public void Reset()
        {
            CurrentValue = 0;
        }
    }
}
