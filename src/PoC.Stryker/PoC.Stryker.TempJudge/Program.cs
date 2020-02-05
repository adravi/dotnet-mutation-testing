using System;
using PoC.Stryker.TempJudge.Domain;

namespace PoC.Stryker.TempJudge
{
    class Program
    {
        static void Main(string[] args)
        {
            string response;
            TempMonitor monitor = null;

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
                        => TempEvaluator.GetMonitorBasedOnExpression(Temp.Warm),

                        "chill"
                        => TempEvaluator.GetMonitorBasedOnExpression(Temp.Chill),

                        "cold"
                        => TempEvaluator.GetMonitorBasedOnExpression(Temp.Cold),

                        "freezing"
                        => TempEvaluator.GetMonitorBasedOnExpression(Temp.Freezing),

                        _ => throw new ArgumentOutOfRangeException()
                    };
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Expression not recognized.");
                }

                if (monitor == null) continue;

                // Eval against real temperature
                var verdict = TempEvaluator.IsExpressionAccurate(monitor);
                Console.WriteLine($"Actual temperature is {verdict.ActualTemp}");

                // Judgment!
                var judgment = verdict.Value ? "You are right." : "You are exaggerating.";
                Console.WriteLine(judgment);

            } while (response != "exit");

            Console.ReadKey();
        }
    }
}
