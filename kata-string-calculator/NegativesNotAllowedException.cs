using System;

namespace kata_string_calculator
{
    public class NegativesNotAllowedException : Exception
    {
        public NegativesNotAllowedException(string message) : base(message)
        {
        }
    }
}