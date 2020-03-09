using System;
using PoC.Stryker.TempJudge.Domain;

namespace PoC.Stryker.TempJudge
{
    class Program
    {
        static void Main()
        {
            string response;
            TempMonitor monitor = null;
            var tempEvaluator = new TempEvaluator();

            Console.WriteLine("Welcome to the Temperature Judge! (type 'exit' to terminate)");
            do
            {
                Console.WriteLine("\nHow's the weather today?");
                response = Console.ReadLine();

                try
                {
                    monitor = response switch
                    {
                        "warm"
                        => tempEvaluator.GetMonitorBasedOnExpression(Temp.Warm),

                        "chill"
                        => tempEvaluator.GetMonitorBasedOnExpression(Temp.Chill),

                        "cold"
                        => tempEvaluator.GetMonitorBasedOnExpression(Temp.Cold),

                        "freezing"
                        => tempEvaluator.GetMonitorBasedOnExpression(Temp.Freezing),

                        _ => throw new ArgumentOutOfRangeException()
                    };
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Expression not recognized.");
                }

                if (monitor == null) continue;

                // Eval against real temperature
                var realTemp = new Random().Next(0, 50);
                var verdict = tempEvaluator.IsExpressionAccurate(monitor, realTemp);
                Console.WriteLine($"Actual temperature is {verdict.ActualTemp}");

                // Judgment!
                var judgment = verdict.Value ? "You are right." : "You are exaggerating.";
                Console.WriteLine(judgment);

            } while (response != "exit");

            Console.ReadKey();
        }
    }
}
