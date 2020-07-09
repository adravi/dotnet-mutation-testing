using System;

namespace TempJudge
{
    class Program
    {
        static void Main()
        {
            string response;
            var tempExpressionParser = new TempExpressionParser();
            var tempEvaluator = new TempEvaluator();
            var tempMonitorFactory = new TempMonitorFactory();

            Console.WriteLine("Welcome to the Temperature Judge! (type 'exit' to terminate)");
            do
            {
                Console.WriteLine("\nHow's the weather today?");
                
                // Common expression about the weather
                response = Console.ReadLine().ToLowerInvariant();
                
                // Expression - Monitor
                var tempCategory = tempExpressionParser.ParseToTempCategory(response);
                var tempMonitor = tempMonitorFactory.GetTempMonitor(tempCategory);

                // Evaluate against actual temperature
                var actualTemp = new Random().Next(0, 50);
                
                // Get verdict
                var tempVerdict = tempEvaluator.IsExpressionAccurate(tempMonitor, actualTemp);
                Console.WriteLine($"Actual temperature is {tempVerdict.Item1}");

                // Judgment!
                var judgment = tempVerdict.Item2 ? "You are right." : "You are exaggerating.";
                Console.WriteLine(judgment);

            } while (response != "exit");

            Console.ReadKey();
        }
    }
}
