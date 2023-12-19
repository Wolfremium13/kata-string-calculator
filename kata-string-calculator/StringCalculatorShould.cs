using Xunit;

namespace kata_string_calculator
{
    public class StringCalculatorShould
    {
        [Fact]
        public void ignore_empty()
        {
            Assert.Equal(StringCalculator.Add(""), 0);
        }
        
        [Fact]
        public void ignore_empty_spaces()
        {
            Assert.Equal(StringCalculator.Add(" "), 0);
        }

        [Fact]
        public void give_the_same_number()
        {
            Assert.Equal(StringCalculator.Add("1"), 1);
            Assert.Equal(StringCalculator.Add("2"), 2);
        }

        [Fact]
        public void sum_numbers()
        {
            Assert.Equal(StringCalculator.Add("1,2"), 3);
            Assert.Equal(StringCalculator.Add("2,3,5"), 10);
        }

        [Fact]
        public void sum_using_new_lines()
        {
            Assert.Equal(StringCalculator.Add("2\n3\n5"), 10);
        }

        [Fact]
        public void sum_using_custom_delimiters()
        {
            Assert.Equal(StringCalculator.Add("//;\n2;3;5"), 10);
            Assert.Equal(StringCalculator.Add("//;\n2;3;5\n7"), 17);
        }

        [Fact]
        public void sum_using_custom_delimiters_of_any_length()
        {
            Assert.Equal(StringCalculator.Add("//[***]\n2***3***5"), 10);
        }

        [Fact]
        public void sum_using_multiple_custom_delimiters()
        {
            Assert.Equal(StringCalculator.Add("//[*][%]\n2*3%5"), 10);
        }

        [Fact]
        public void not_allow_negatives()
        {
            Assert.Throws<NegativesNotAllowedException>(() => StringCalculator.Add("-1"));
            Assert.Throws<NegativesNotAllowedException>(() => StringCalculator.Add("-1,2"));
            Assert.Throws<NegativesNotAllowedException>(() => StringCalculator.Add("-1,-2"));
        }
    }
}