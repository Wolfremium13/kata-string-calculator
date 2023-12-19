namespace kata_string_calculator
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (numbers.Length > 0)
            {
                if (numbers.Contains(","))
                {
                    var splitNumbers = numbers.Split(',');
                    return int.Parse(splitNumbers[0]) + int.Parse(splitNumbers[1]);
                }
                return int.Parse(numbers);
            }

            return 0;
        }
    }
}