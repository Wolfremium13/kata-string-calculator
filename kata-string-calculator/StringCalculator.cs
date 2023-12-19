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
            var delimiters = GetDelimiters(numbers);
            var numbersWithoutDelimiter = RemoveDelimiters(numbers);
            return SumNumbers(numbersWithoutDelimiter, delimiters);
        }

        private static int SumNumbers(string numbers, IEnumerable<string> customDelimiters)
        {
            var delimiters = new List<string> { ",", "\n" }.Concat(customDelimiters);
            return numbers.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .Sum();
        }

        private static string RemoveDelimiters(string numbers)
        {
            return numbers.StartsWith("//") ? numbers.Substring(numbers.IndexOf('\n') + 1) : numbers;
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