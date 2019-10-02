using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class StringCalculator
    {
        private string _input;
        private readonly int _defaultNumber = 0;
        private readonly string _openDelimiter = "[";
        private readonly string _closeDelimiter = "]";
        private readonly string _customDelimiterFlag = "//";
        readonly string[] _defaultDelimiter = new string[] { ",", "\n" };
        public StringCalculator(string input)
        {
            _input = input;
        }

        public string CalculateSum()
        {
            if (string.IsNullOrEmpty(_input)) return $"{_defaultNumber}";
            var delimiters = _input.StartsWith(_customDelimiterFlag) 
                ? GetCustomDelimiter()
                : _defaultDelimiter;
            var numbers = _input.Split(delimiters, StringSplitOptions.None);
            var parsedNumbers = numbers.Select(x => ParseNumber(x)).ToList();
            CheckForNegativeNumbers(parsedNumbers);
            return string.Join("+", parsedNumbers) + $" = {parsedNumbers.Sum()}";
        }

        private string[] GetCustomDelimiter()
        {
            var delimiters = new List<string>();
            // Multiple characters or multiple custom delimiters
            if (_input.Contains(_customDelimiterFlag + _openDelimiter))
            {
                _input = _input.Remove(0, _input.IndexOf(_customDelimiterFlag) + 2);
                while (_input.IndexOf("\n") > 1)
                {
                    // Remove first bracket
                    _input = _input.Remove(0, 1);
                    delimiters.Add(_input.Substring(0, _input.IndexOf(_closeDelimiter)));
                    _input = _input.Remove(0, _input.IndexOf(_closeDelimiter) + 1);
                }
                _input = _input.Remove(0, _input.IndexOf("\n") + 1);
            }
            // Single character custom delimiter
            else
            {
                delimiters.Add(_input[2].ToString());
            }
            return delimiters.ToArray();
        }

        private void CheckForNegativeNumbers(List<int> numbers)
        {
            if (numbers.Any(x => x < 0))
            {
                throw new ArgumentOutOfRangeException($"Unable to process negative numbers: {string.Join(", ", numbers.Where(x => x < 0))}");
            }
        }
        
        private int ParseNumber(string number)
        {
            try
            {
                return (int.TryParse(number.Trim(), out var result) && result < 1000) 
                    ? result
                    : _defaultNumber;
            }
            catch
            { 
                return _defaultNumber;
            }
        }
    }
}
