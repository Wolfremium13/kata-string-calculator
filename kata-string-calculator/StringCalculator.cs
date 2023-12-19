using System.Collections.Generic;
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
                return SumNumbers(numbersWithoutDelimiter, new[] { delimiter });
            }
            return SumNumbers(numbers, new char[] { });
        }

        private static int SumNumbers(string numbers, IEnumerable<char> customDelimiters)
        {
            var delimiters = new[] { ',', '\n' }.Concat(customDelimiters).ToArray();
            return numbers.Split(delimiters).Aggregate(0, (a, b) => a + int.Parse(b));
        }
    }
}