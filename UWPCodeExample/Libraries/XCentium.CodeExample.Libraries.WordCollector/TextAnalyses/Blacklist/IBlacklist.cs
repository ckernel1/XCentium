namespace XCentium.CodeExample.Libraries.WordCollector.Blacklist
{
    public interface IBlacklist
    {
        bool Countains(string word);
        int Count { get; }
    }
}
