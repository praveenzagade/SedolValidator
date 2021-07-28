using MnG.SedolChecker.Interfaces;

namespace MnG.SedolChecker.Implementations
{
    public class InputLengthValidator : IInputValidator
    {
        public bool IsValid(string source)
        {
            return !(string.IsNullOrWhiteSpace(source) ||
                     source.Length != 7);
        }
    }
}