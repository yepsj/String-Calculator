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
        public StringCalculator(string input)
        {
            _input = input;
        }

        public int CalculateSum()
        {
            if (string.IsNullOrEmpty(_input)) return 0;
            var numbers = _input.Split(new string[] { ",", "\n" }, StringSplitOptions.None);
            CheckForNegativeNumbers(numbers);
            return numbers.Sum(x => ParseNumber(x));
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
