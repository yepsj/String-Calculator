using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class StringCalculator
    {
        private readonly string _input;
        public StringCalculator(string input)
        {
            _input = input;
        }

        public int CalculateSum()
        {
            if (string.IsNullOrEmpty(_input)) return 0;
            return _input.Split(',').Sum(x => ParseNumber(x));
        }

        private int ParseNumber(string number)
        {
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
