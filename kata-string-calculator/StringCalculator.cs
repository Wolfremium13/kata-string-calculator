using System.Linq;

namespace kata_string_calculator
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (numbers.Length == 0) return 0;
            if (numbers.Contains(","))
            {
                var splitNumbers = numbers.Split(',');
                return splitNumbers.Aggregate(0, (current, splitNumber) => current + int.Parse(splitNumber));
            }
            return int.Parse(numbers);
        }
    }
}