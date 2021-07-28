namespace MnG.SedolChecker.Interfaces
{
    public interface ICheckSumProvider
    {
        int GetCheckSum(string source);
    }
}