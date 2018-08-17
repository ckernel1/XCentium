namespace XCentium.CodeExample.Libraries.WordCollector.Blacklist
{
    public class NullBlacklist : IBlacklist
    {
        public bool Countains(string word)
        {
            return false;
        }

        public int Count
        {
            get { return 0; }
        }
    }
}
