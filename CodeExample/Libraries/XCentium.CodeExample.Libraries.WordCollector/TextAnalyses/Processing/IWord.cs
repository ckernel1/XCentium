using System;

namespace XCentium.CodeExample.Libraries.WordCollector.Processing
{
    public interface IWord : IComparable<IWord>
    {
        string Text { get; }
        int Occurrences { get; }
        string GetCaption();
    }
}