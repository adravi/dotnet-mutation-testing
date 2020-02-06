using System.Diagnostics.CodeAnalysis;

namespace PoC.Stryker.TempJudge.v2.Domain
{
    [ExcludeFromCodeCoverage]
    public struct TempVerdict
    {
        public int ActualTemp;
        public bool Value;
    }
}
