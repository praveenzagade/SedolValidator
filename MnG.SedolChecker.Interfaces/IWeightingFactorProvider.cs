using System.Collections.Generic;

namespace MnG.SedolChecker.Interfaces
{
    public interface IWeightingFactorProvider
    {
        Dictionary<int, int> GetWeightingFactor();
    }
}