using System;
using System.Collections.Generic;
using System.Linq;

namespace kata_string_calculator
{
    public class StringCalculator
    {
        public static int Add(string numbers)
        {
            if (numbers.Length == 0) return 0;
            if (!numbers.StartsWith("//")) return SumNumbers(numbers, new List<string>());
            if (numbers[2] == '[')
            {
                var delimiters = GetDelimiters(numbers);
                var numbersWithoutDelimiter = numbers.Substring(numbers.IndexOf(']') + 2);
                return SumNumbers(numbersWithoutDelimiter, delimiters);
            }
            else
            {
                var delimiter = numbers[2].ToString();
                var numbersWithoutDelimiter = numbers.Substring(4);
                return SumNumbers(numbersWithoutDelimiter, new List<string> { delimiter });
            }

        }

        private static int SumNumbers(string numbers, IEnumerable<string> customDelimiters)
        {
            var delimiters = new List<string> { ",", "\n" }.Concat(customDelimiters);
            return numbers.Split(delimiters.ToArray(), System.StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .Sum();
        }

        private static IEnumerable<string> GetDelimiters(string numbers)
        {
            var defaultDelimiters = new List<string>() { ",", "\n" };
            if (!numbers.StartsWith("//")) return defaultDelimiters;
            if (numbers[2] == '[')
            {
                var delimiter = numbers.Substring(3, numbers.IndexOf(']') - 3);
                defaultDelimiters.Add(delimiter);
            }
            else
            {
                var delimiter = numbers[2].ToString();
                defaultDelimiters.Add(delimiter);
            }

            return defaultDelimiters;
        }
    }
}