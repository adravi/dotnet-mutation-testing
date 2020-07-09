//using TempJudge.Domain;
//using Xunit;

//namespace TempJudge.Tests
//{
//    [Trait("TempEvaluator", "TempEvaluator Unit Tests")]
//    public class TempEvaluatorShould
//    {
//        [Fact]
//        public void GetMonitorBasedOnExpression_ReturnsRightMinMaxValues_GivenExpressionWarm()
//        {
//            // Arrange
//            var evaluator = new TempEvaluator();

//            // Act
//            var monitor = evaluator.GetMonitorBasedOnExpression(Temp.Warm);

//            // Assert
//            Assert.True(monitor.MinTemp == 30);
//            Assert.True(monitor.MaxTemp == 45);
//        }

//        [Fact]
//        public void GetMonitorBasedOnExpression_ReturnsRightMinMaxValues_GivenExpressionChill()
//        {
//            // Arrange
//            var evaluator = new TempEvaluator();

//            // Act
//            var monitor = evaluator.GetMonitorBasedOnExpression(Temp.Chill);

//            // Assert
//            Assert.True(monitor.MinTemp == 16);
//            Assert.True(monitor.MaxTemp == 30);
//        }

//        [Fact]
//        public void GetMonitorBasedOnExpression_ReturnsRightMinMaxValues_GivenExpressionCold()
//        {
//            // Arrange
//            var evaluator = new TempEvaluator();

//            // Act
//            var monitor = evaluator.GetMonitorBasedOnExpression(Temp.Cold);

//            // Assert
//            Assert.True(monitor.MinTemp == 6);
//            Assert.True(monitor.MaxTemp == 15);
//        }

//        [Fact]
//        public void GetMonitorBasedOnExpression_ReturnsRightMinMaxValues_GivenExpressionFreezing()
//        {
//            // Arrange
//            var evaluator = new TempEvaluator();

//            // Act
//            var monitor = evaluator.GetMonitorBasedOnExpression(Temp.Freezing);

//            // Assert
//            Assert.True(monitor.MinTemp == 0);
//            Assert.True(monitor.MaxTemp == 5);
//        }

//        [Fact]
//        public void IsExpressionAccurate_VerdictValueIsCorrect_GivenMonitorWarm()
//        {
//            // Arrange
//            var evaluator = new TempEvaluator();
//            var monitor = evaluator.GetMonitorBasedOnExpression(Temp.Warm);

//            // Act
//            var verdictExpectedTrue = evaluator.IsExpressionAccurate(monitor, 31);
//            var verdictExpectedFalse = evaluator.IsExpressionAccurate(monitor, 46);

//            // Assert
//            Assert.True(verdictExpectedTrue.Value);
//            Assert.False(verdictExpectedFalse.Value);
//        }

//        [Fact]
//        public void IsExpressionAccurate_VerdictValueIsCorrect_GivenMonitorChill()
//        {
//            // Arrange
//            var evaluator = new TempEvaluator();
//            var monitor = evaluator.GetMonitorBasedOnExpression(Temp.Chill);

//            // Act
//            var verdictExpectedTrue = evaluator.IsExpressionAccurate(monitor, 17);
//            var verdictExpectedFalse = evaluator.IsExpressionAccurate(monitor, 31);

//            // Assert
//            Assert.True(verdictExpectedTrue.Value);
//            Assert.False(verdictExpectedFalse.Value);
//        }

//        [Fact]
//        public void IsExpressionAccurate_VerdictValueIsCorrect_GivenMonitorCold()
//        {
//            // Arrange
//            var evaluator = new TempEvaluator();
//            var monitor = evaluator.GetMonitorBasedOnExpression(Temp.Cold);

//            // Act
//            var verdictExpectedTrue = evaluator.IsExpressionAccurate(monitor, 7);
//            var verdictExpectedFalse = evaluator.IsExpressionAccurate(monitor, 16);

//            // Assert
//            Assert.True(verdictExpectedTrue.Value);
//            Assert.False(verdictExpectedFalse.Value);
//        }

//        [Fact]
//        public void IsExpressionAccurate_VerdictValueIsCorrect_GivenMonitorFreezing()
//        {
//            // Arrange
//            var evaluator = new TempEvaluator();
//            var monitor = evaluator.GetMonitorBasedOnExpression(Temp.Freezing);

//            // Act
//            var verdictExpectedTrue = evaluator.IsExpressionAccurate(monitor, 1);
//            var verdictExpectedFalse = evaluator.IsExpressionAccurate(monitor, 6);

//            // Assert
//            Assert.True(verdictExpectedTrue.Value);
//            Assert.False(verdictExpectedFalse.Value);
//        }
//    }
//}
