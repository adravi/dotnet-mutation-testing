using System;
using TempJudge.Domain;

namespace TempJudge
{
    public class TempMonitorFactory
    {
        public TempMonitor GetTempMonitor(TempCategory tempCategory)
        {
            return tempCategory switch
            {
                TempCategory.Warm     => new TempMonitor(30, 45),
                TempCategory.Fresh    => new TempMonitor(16, 30),
                TempCategory.Cold     => new TempMonitor(6, 15),
                TempCategory.Freezing => new TempMonitor(0, 5),

                _ => throw new ArgumentOutOfRangeException(message: "Invalid Temperature Expresion", paramName: nameof(tempCategory)),
            };
        }
    }
}
