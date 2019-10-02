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
            var sum = 0;
            var index = 0;
            if (string.IsNullOrEmpty(_input)) return 0;
            foreach (var number in _input.Split(','))
            {
                sum += ParseNumber(number, index);
                index++;
            }
            return sum;
        }

        private int ParseNumber(string number, int index)
        {
            if (index >= 2) return 0;
            try
            {
                return int.TryParse(number.Trim(), out var result) ? result : 0;
            }
            catch
            {
                return 0;
            }
        }
    }
}
