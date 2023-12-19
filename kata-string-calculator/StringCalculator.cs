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
                var splitNumbers = numbersWithoutDelimiter.Split(delimiter);
                return splitNumbers.Aggregate(0, (current, splitNumber) => current + int.Parse(splitNumber));
            }

            if (numbers.Contains(",") || numbers.Contains("\n"))
            {
                var splitNumbers = numbers.Split(',', '\n');
                return splitNumbers.Aggregate(0, (current, splitNumber) => current + int.Parse(splitNumber));
            }

            return int.Parse(numbers);
        }
    }
}