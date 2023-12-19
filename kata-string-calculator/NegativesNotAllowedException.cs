using System;

namespace kata_string_calculator
{
    public class NegativesNotAllowedException : ArgumentOutOfRangeException
    {
        public NegativesNotAllowedException(string message) : base(message)
        {
        }
    }
}