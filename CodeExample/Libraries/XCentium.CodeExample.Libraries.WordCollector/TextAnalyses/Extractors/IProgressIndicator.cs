namespace XCentium.CodeExample.Libraries.WordCollector.Extractors
{
    public interface IProgressIndicator
    {
        int Maximum { get; set; }
        void Increment(int value);
        int CurrentValue { get; set; }
        void Reset();
    }
}
