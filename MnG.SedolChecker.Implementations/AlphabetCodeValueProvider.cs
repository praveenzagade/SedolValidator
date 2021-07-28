using MnG.SedolChecker.Interfaces;

namespace MnG.SedolChecker.Implementations
{
    public class AlphabetCodeValueProvider : IValueProvider
    {
        private const int offSet = 'A' - 1;

        /// <summary>
        /// Provides Sedol code value for the given alphabet
        /// </summary>
        /// <param name="source">Capital case alphabet i.e. ranging between A..Z</param>
        /// <returns>Sedol code value for the given alphabet</returns>
        public int GetValue(char source)
        {
            int retValue = 0;
            if (char.IsLetter(source))
            {
                //Being little considerate
                if (!char.IsUpper(source))
                {
                    source = char.ToUpper(source);
                }
                retValue = source - offSet + 9;
            }

            return retValue;
        }
    }
}