using MnG.SedolChecker.Interfaces;

namespace MnG.SedolChecker.Implementations
{
    public class InputDataCleaner : IDataCleaner
    {
        public string Clean(string source)
        {
            return source?.Trim().ToUpperInvariant();
        }
    }
}