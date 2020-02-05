using System;
using PoC.Stryker.TempJudge.Domain;

namespace PoC.Stryker.TempJudge
{
    public static class TempEvaluator
    {
        public static TempMonitor GetMonitorBasedOnExpression(Temp tempExpression)
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

        public static TempVerdict IsExpressionAccurate(TempMonitor monitor)
        {
            var realTempValue = new Random().Next(0, 45);
            var isValueInThreshold = (realTempValue >= monitor.MinTemp) && (realTempValue <= monitor.MaxTemp);

            return new TempVerdict
            {
                ActualTemp = realTempValue,
                Value = isValueInThreshold
            };
        }
    }
}
