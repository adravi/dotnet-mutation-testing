using System;
using TempJudge.Domain;

namespace TempJudge
{
    public class TempEvaluator
    {       
        public Tuple<int, bool> IsExpressionAccurate(TempMonitor tempMonitor, int actualTempValue)
        {
            var isValueInThreshold = (actualTempValue >= tempMonitor.MinTemp) && (actualTempValue <= tempMonitor.MaxTemp);
            return new Tuple<int, bool>(actualTempValue, isValueInThreshold);
        }
    }
}
