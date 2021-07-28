using MnG.SedolChecker.Interfaces;

namespace MnG.SedolChecker.Implementations
{
    public class UserDefinedSedolValidator : IInputValidator
    {
        public bool IsValid(string source)
        {
            return !string.IsNullOrWhiteSpace(source) && source.StartsWith('9');
        }
    }
}