namespace kata_string_calculator
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (numbers.Length > 0)
            {
                return int.Parse(numbers);
            }

            return 0;
        }
    }
}