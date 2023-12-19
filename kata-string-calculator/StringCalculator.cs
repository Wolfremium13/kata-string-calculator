using System;
using System.Collections.Generic;
using System.Linq;

namespace kata_string_calculator
{
    public class StringCalculator
    {
        public static int Add(string givenText)
        {
            if (givenText.Trim().Length == 0) return 0;
            var delimiter = Delimiter.From(givenText);
            var numbers =
                delimiter.RemoveDelimitersFrom(givenText)
                    .Split(delimiter.GetDelimiters(), StringSplitOptions.RemoveEmptyEntries)
                    .Where(n =>
                        {
                            const int maximumNumberAllowed = 1000;
                            return int.TryParse(n, out var number) && number <= maximumNumberAllowed;
                        }
                    )
                    .Select(int.Parse).ToList();
            if (numbers.Any(n => n < 0)) throw new NegativesNotAllowedException("Negatives not allowed");
            return numbers.Sum();
        }
    }
}