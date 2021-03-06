﻿using System.Diagnostics.CodeAnalysis;

namespace TempJudge.Domain
{
    [ExcludeFromCodeCoverage]
    public class TempMonitor
    {
        public int MinTemp { get; }
        public int MaxTemp { get; }

        public TempMonitor(int min, int max)
        {
            MinTemp = min;
            MaxTemp = max;
        }
    }
}
