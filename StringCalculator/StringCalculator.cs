using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class StringCalculator
    {
        readonly string _input;
        readonly string[] _defaultDelimiter = new string[] { ",", "\n" };
        public StringCalculator(string input)
        {
            _input = input;
        }

        public int CalculateSum()
        {
            if (string.IsNullOrEmpty(_input)) return 0;
            var delimiters = _input.StartsWith("//") 
                ? GetCustomDelimiter() 
                : _defaultDelimiter;
            var numbers = _input.Split(delimiters, StringSplitOptions.None);
            CheckForNegativeNumbers(numbers);
            return numbers.Sum(x => ParseNumber(x));
        }

        private string[] GetCustomDelimiter()
        {
            var delimiter = _input.IndexOf("\n") != 3
                ? _defaultDelimiter
                : new string[] { _input[2].ToString() };
            _input.Remove(0, _input.IndexOf("\n"));
            return delimiter;

        }

        private void CheckForNegativeNumbers(string[] numbers)
        {
            var negativeNumbers = numbers.Where(x => ParseNumber(x) < 0);
            if (negativeNumbers.Any())
            {
                throw new ArgumentOutOfRangeException($"Unable to process negative numbers: {string.Join(", ", negativeNumbers)}");
            }
        }
        
        private int ParseNumber(string number)
        {
            try
            {
                return (int.TryParse(number.Trim(), out var result) && result < 1000) 
                    ? result
                    : 0;
            }
            catch
            {
                return 0;
            }
        }
    }
}
