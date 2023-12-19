using Xunit;

namespace kata_string_calculator
{
    public class StringCalculatorShould
    {
        [Fact]
        public void ignore_empty()
        {
            Assert.Equal(new StringCalculator().Add(""), 0);
        }
    }
}