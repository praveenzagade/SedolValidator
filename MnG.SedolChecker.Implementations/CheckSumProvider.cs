using MnG.SedolChecker.Interfaces;
using System;
using System.Collections.Generic;

namespace MnG.SedolChecker.Implementations
{
    public class CheckSumProvider : ICheckSumProvider
    {
        private readonly IValueProvider _CodeValueProvider;
        private readonly IWeightingFactorProvider _WeightingFactorProvider;

        private const int _SedolLength = 7;

        public CheckSumProvider(IValueProvider codeValueProvider,
                                IWeightingFactorProvider weightingFactorProvider)
        {
            _CodeValueProvider = codeValueProvider;
            _WeightingFactorProvider = weightingFactorProvider;
        }

        public int GetCheckSum(string source)
        {
            int index = 0;

            if (string.IsNullOrWhiteSpace(source)) return 0;

            source = source.Trim().ToUpper();

            Dictionary<int, int> charValues = new Dictionary<int, int>();
            foreach (char chr in source)
            {
                charValues.Add(++index, _CodeValueProvider.GetValue(chr));
            }
            return GetCheckSum(charValues, _WeightingFactorProvider.GetWeightingFactor());
        }

        private int GetCheckSum(Dictionary<int, int> charValues,
                                Dictionary<int, int> weightage)
        {
            int retValue = 0;
            int maxLength = Math.Min(charValues.Count, _SedolLength - 1);
            for (int index = 1; index <= maxLength; index++)
            {
                retValue += charValues[index] * weightage[index];
            }
            return retValue;
        }
    }
}