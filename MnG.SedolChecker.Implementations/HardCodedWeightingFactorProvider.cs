using MnG.SedolChecker.Interfaces;
using System.Collections.Generic;

namespace MnG.SedolChecker.Implementations
{
    public class HardCodedWeightingFactorProvider : IWeightingFactorProvider
    {
        public Dictionary<int, int> GetWeightingFactor()
        {
            return new Dictionary<int, int>()
            {
                { 1, 1},
                { 2, 3},
                { 3, 1},
                { 4, 7},
                { 5, 3},
                { 6, 9},
                { 7, 1}
            };
        }
    }
}