using System;
using System.Collections.Generic;
using System.Linq;

namespace kata_string_calculator
{
    public class Delimiter
    {
        private readonly string _delimiter;
        private readonly List<string> _delimiters = new List<string>() { ",", "\n" };

        private Delimiter(string delimiter)
        {
            _delimiter = delimiter;
        }

        public IEnumerable<string> GetDelimiters()
        {
            if (_delimiter.Length == 0) return _delimiters.ToList();
            if (_delimiter.Contains("[") && _delimiter.Contains("]"))
            {
                return _delimiters.Concat(GetCustomDelimiters()).ToList();
            }
            return _delimiters.Concat(new List<string> { _delimiter.Substring(2) }).ToList();
        }

        private IEnumerable<string> GetCustomDelimiters()
        {
            var delimiter = _delimiter.Substring(2);
            var delimiters = delimiter.Split(new[] { "[", "]" }, StringSplitOptions.RemoveEmptyEntries);
            return delimiters;
        }

        public static Delimiter From(string numbers)
        {
            if (!numbers.StartsWith("//")) return new Delimiter("");
            var delimiter = numbers.Substring(0, numbers.IndexOf('\n'));
            return new Delimiter(delimiter);
        }
    }
}