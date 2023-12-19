using System;
using System.Collections.Generic;
using System.Linq;

namespace kata_string_calculator
{
    public class StringCalculator
    {
        public static int Add(string numbers)
        {
            if (numbers.Contains("-"))
            {
                var negatives = numbers.Split(new[] { ",", "\n" }, StringSplitOptions.RemoveEmptyEntries)
                    .Where(n => n.StartsWith("-")).ToList();
                throw new NegativesNotAllowedException($"Negatives not allowed: {string.Join(",", negatives)}");
            }

            if (numbers.Trim().Length == 0) return 0;
            var delimiter = Delimiter.From(numbers);
            var delimiters = delimiter.GetDelimiters();
            var numbersWithoutDelimiter = delimiter.RemoveDelimiters(numbers);
            return SumNumbers(numbersWithoutDelimiter, delimiters);
        }

        private static int SumNumbers(string numbers, IEnumerable<string> customDelimiters)
        {
            return numbers.Split(customDelimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).Where(n => n <= 1000)
                .Sum();
        }
    }
}