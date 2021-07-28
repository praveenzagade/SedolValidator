using MnG.SedolChecker.Interfaces;
using System;

namespace MnG.SedolChecker.Implementations
{
    public class InputCheckSumValidator : IInputValidator
    {
        private readonly ICheckSumProvider _CheckSumProvider;

        public InputCheckSumValidator(ICheckSumProvider checkSumProvider)
        {
            _CheckSumProvider = checkSumProvider;
        }

        public bool IsValid(string source)
        {
            int sumIncludingCheckdigit = _CheckSumProvider.GetCheckSum(source) + Int32.Parse(char.ToString(source[^1]));

            return sumIncludingCheckdigit % 10 == 0;
        }
    }
}