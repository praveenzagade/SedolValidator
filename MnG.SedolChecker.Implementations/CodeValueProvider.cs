using MnG.SedolChecker.Interfaces;

namespace MnG.SedolChecker.Implementations
{
    public class CodeValueProvider : IValueProvider
    {
        private readonly IValueProvider _AlphabetCodeValueProvider;

        public CodeValueProvider(IValueProvider alphabetCodeValueProvider)
        {
            _AlphabetCodeValueProvider = alphabetCodeValueProvider;
        }

        public int GetValue(char source)

        {
            int retValue = 0;
            if (char.IsNumber(source))
            {
                if (!int.TryParse(char.ToString(source), out retValue))
                {
                    retValue = 0;
                }
            }
            else if (char.IsLetter(source))
            {
                retValue = _AlphabetCodeValueProvider.GetValue(char.ToUpper(source));
            }
            return retValue;
        }
    }
}