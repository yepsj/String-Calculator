using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var stringCalculator = new StringCalculator(Console.ReadLine());
                Console.WriteLine(stringCalculator.CalculateSum());
            }
        }
    }
}
