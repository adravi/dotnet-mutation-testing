﻿using System;
using PoC.Stryker.TempJudge.v2.Domain;

namespace PoC.Stryker.TempJudge.v2
{
    class Program
    {
        static void Main(string[] args)
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
                    switch (response)
                    {
                        case "warm":
                            monitor = tempEvaluator.GetMonitorBasedOnExpression(Temp.Warm);
                            break;
                        case "chill":
                            monitor = tempEvaluator.GetMonitorBasedOnExpression(Temp.Chill);
                            break;
                        case "cold":
                            monitor = tempEvaluator.GetMonitorBasedOnExpression(Temp.Cold);
                            break;
                        case "freezing":
                            monitor = tempEvaluator.GetMonitorBasedOnExpression(Temp.Freezing);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                            break;
                    }
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