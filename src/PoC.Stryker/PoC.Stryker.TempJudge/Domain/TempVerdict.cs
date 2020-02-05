using System.Diagnostics.CodeAnalysis;

namespace PoC.Stryker.TempJudge.Domain
{
    [ExcludeFromCodeCoverage]
    public struct TempVerdict
    {
        public int ActualTemp;
        public bool Value;
    }
}
