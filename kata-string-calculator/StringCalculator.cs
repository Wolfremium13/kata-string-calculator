using System.Linq;

namespace kata_string_calculator
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (numbers.Length == 0) return 0;
            if (numbers.StartsWith("//"))
            {
                var delimiter = numbers[2];
                var numbersWithoutDelimiter = numbers.Substring(4);
                return SumNumbers(numbersWithoutDelimiter, new[] {delimiter});
            }

            if (numbers.Contains(",") || numbers.Contains("\n"))
            {
                return SumNumbers(numbers, new[] {',', '\n'});
            }

            return int.Parse(numbers);
        }

        private static int SumNumbers(string numbers, char[] delimiters)
        {
            return numbers.Split(delimiters).Aggregate(0, (a, b) => a + int.Parse(b));
        }
    }
}