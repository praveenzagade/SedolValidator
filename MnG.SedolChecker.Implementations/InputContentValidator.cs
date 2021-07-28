using MnG.SedolChecker.Interfaces;
using System.Linq;

namespace MnG.SedolChecker.Implementations
{
    public class InputContentValidator : IInputValidator
    {
        public bool IsValid(string source)
        {
            return !string.IsNullOrWhiteSpace(source) && source.All(c => char.IsLetterOrDigit(c));
        }
    }
}