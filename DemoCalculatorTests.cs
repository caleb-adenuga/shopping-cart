using CalebAPI.Utilities;
using Xunit;

namespace CalebAPI.Tests
{
    public class DemoCalculatorTests
    {
        private DemoCalculator _calculator;

        public DemoCalculatorTests()
        {
            _calculator = new DemoCalculator();
        }

        [Fact]
        public void WhenAddingTwoPositiveNumbers_ItReturnsTheTotal()
        {
            var result = _calculator.Add(1, 3);
            Assert.Equal(4, result);
        }
    }
}