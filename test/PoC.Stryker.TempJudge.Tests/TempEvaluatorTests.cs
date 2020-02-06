using PoC.Stryker.TempJudge.Domain;
using Xunit;

namespace PoC.Stryker.TempJudge.Tests
{
    public class TempEvaluatorTests
    {
        [Fact]
        public void GetMonitorBasedOnExpression_ReturnsRightMinMaxValues_GivenExpressionWarm()
        {
            // Given
            var evaluator = new TempEvaluator();
            
            // When
            var monitor = evaluator.GetMonitorBasedOnExpression(Temp.Warm);

            // Assert
            Assert.True(monitor.MinTemp == 30);
            Assert.True(monitor.MaxTemp == 45);
        }

        [Fact]
        public void GetMonitorBasedOnExpression_ReturnsRightMinMaxValues_GivenExpressionChill()
        {
            // Given
            var evaluator = new TempEvaluator();
            
            // When
            var monitor = evaluator.GetMonitorBasedOnExpression(Temp.Chill);

            // Assert
            Assert.True(monitor.MinTemp == 16);
            Assert.True(monitor.MaxTemp == 30);
        }

        [Fact]
        public void GetMonitorBasedOnExpression_ReturnsRightMinMaxValues_GivenExpressionCold()
        {
            // Given
            var evaluator = new TempEvaluator();
            
            // When
            var monitor = evaluator.GetMonitorBasedOnExpression(Temp.Cold);

            // Assert
            Assert.True(monitor.MinTemp == 6);
            Assert.True(monitor.MaxTemp == 15);
        }

        [Fact]
        public void GetMonitorBasedOnExpression_ReturnsRightMinMaxValues_GivenExpressionFreezing()
        {
            // Given
            var evaluator = new TempEvaluator();
            
            // When
            var monitor = evaluator.GetMonitorBasedOnExpression(Temp.Freezing);

            // Assert
            Assert.True(monitor.MinTemp == 0);
            Assert.True(monitor.MaxTemp == 5);
        }

        [Fact]
        public void IsExpressionAccurate_VerdictValueIsCorrect_GivenMonitorWarm()
        {
            // Given
            var evaluator = new TempEvaluator();
            var monitor = evaluator.GetMonitorBasedOnExpression(Temp.Warm);

            // When
            var verdictExpectedTrue = evaluator.IsExpressionAccurate(monitor, 31);
            var verdictExpectedFalse = evaluator.IsExpressionAccurate(monitor, 46);

            // Assert
            Assert.True(verdictExpectedTrue.Value);
            Assert.False(verdictExpectedFalse.Value);
        }

        [Fact]
        public void IsExpressionAccurate_VerdictValueIsCorrect_GivenMonitorChill()
        {
            // Given
            var evaluator = new TempEvaluator();
            var monitor = evaluator.GetMonitorBasedOnExpression(Temp.Chill);

            // When
            var verdictExpectedTrue = evaluator.IsExpressionAccurate(monitor, 17);
            var verdictExpectedFalse = evaluator.IsExpressionAccurate(monitor, 31);

            // Assert
            Assert.True(verdictExpectedTrue.Value);
            Assert.False(verdictExpectedFalse.Value);
        }

        [Fact]
        public void IsExpressionAccurate_VerdictValueIsCorrect_GivenMonitorCold()
        {
            // Given
            var evaluator = new TempEvaluator();
            var monitor = evaluator.GetMonitorBasedOnExpression(Temp.Cold);

            // When
            var verdictExpectedTrue = evaluator.IsExpressionAccurate(monitor, 7);
            var verdictExpectedFalse = evaluator.IsExpressionAccurate(monitor, 16);

            // Assert
            Assert.True(verdictExpectedTrue.Value);
            Assert.False(verdictExpectedFalse.Value);
        }

        [Fact]
        public void IsExpressionAccurate_VerdictValueIsCorrect_GivenMonitorFreezing()
        {
            // Given
            var evaluator = new TempEvaluator();
            var monitor = evaluator.GetMonitorBasedOnExpression(Temp.Freezing);

            // When
            var verdictExpectedTrue = evaluator.IsExpressionAccurate(monitor, 1);
            var verdictExpectedFalse = evaluator.IsExpressionAccurate(monitor, 6);

            // Assert
            Assert.True(verdictExpectedTrue.Value);
            Assert.False(verdictExpectedFalse.Value);
        }
    }
}
