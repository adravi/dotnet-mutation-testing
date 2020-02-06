using PoC.Stryker.TempJudge.v2.Domain;
using System;

namespace PoC.Stryker.TempJudge.v2
{
    public class TempEvaluator
    {
        public TempMonitor GetMonitorBasedOnExpression(Temp tempExpression)
        {
            switch (tempExpression)
            {
                case Temp.Warm:
                    return new TempMonitor(30, 45);
                case Temp.Chill:
                    return new TempMonitor(16, 30);
                case Temp.Cold:
                    return new TempMonitor(6, 15);
                case Temp.Freezing:
                    return new TempMonitor(0, 5);
                default:
                    throw new ArgumentException(message: "Invalid Enum Value", paramName: nameof(tempExpression));
            }
        }

        public TempVerdict IsExpressionAccurate(TempMonitor monitor, int realTempValue)
        {
            var isValueInThreshold = (realTempValue >= monitor.MinTemp) && (realTempValue <= monitor.MaxTemp);

            return new TempVerdict
            {
                ActualTemp = realTempValue,
                Value = isValueInThreshold
            };
        }
    }
}
