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
                if (numbers[2] == '[')
                {
                    var delimiter = numbers.Substring(3, numbers.IndexOf(']') - 3);
                    var numbersWithoutDelimiter = numbers.Substring(numbers.IndexOf(']') + 2);
                    return SumNumbers(numbersWithoutDelimiter, new[] { delimiter });
                }
                else
                {
                    var delimiter = numbers[2].ToString();
                    var numbersWithoutDelimiter = numbers.Substring(4);
                    return SumNumbers(numbersWithoutDelimiter, new[] { delimiter });
                }
            }

            return SumNumbers(numbers, new string[] { });
        }

        private static int SumNumbers(string numbers, string[] customDelimiters)
        {
            var delimiters = new List<string> { ",", "\n" }.Concat(customDelimiters);
            return numbers.Split(delimiters.ToArray(), System.StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .Sum();
        }
    }
}