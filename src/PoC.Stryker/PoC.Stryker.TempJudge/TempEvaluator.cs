using System;
using PoC.Stryker.TempJudge.Domain;

namespace PoC.Stryker.TempJudge
{
    public class TempEvaluator
    {
        public TempMonitor GetMonitorBasedOnExpression(Temp tempExpression)
        {
            return tempExpression switch
            {
                Temp.Warm 
                => new TempMonitor(30, 45),
                
                Temp.Chill
                => new TempMonitor(16, 30),
                
                Temp.Cold
                => new TempMonitor(6, 15),
                
                Temp.Freezing
                => new TempMonitor(0, 5),
                
                _ => throw new ArgumentException(message: "Invalid Enum Value", paramName: nameof(tempExpression)),
            };
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
