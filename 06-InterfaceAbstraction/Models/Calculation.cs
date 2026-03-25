using _06_InterfaceAbstraction.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_InterfaceAbstraction.Models
{
    public class Calculation : ICalculation
    {
        public void Calculate()
        {
            Console.WriteLine("A ededini daxil edin:");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("B ededini daxil edin:");
            int b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Edilmeli olan emeli daxil edin(+, -, *, /):");
            char op = Convert.ToChar(Console.ReadLine());

            switch (op)
            {
                case '+':
                    Console.WriteLine("Netice: " + (a + b));
                    break;
                case '-':
                    Console.WriteLine("Netice: " + (a - b));
                    break;
                case '*':
                    Console.WriteLine("Netice: " +  (a * b));
                    break;
                case '/':
                    if (b != 0) Console.WriteLine("Netice: " + (a / b));
                    else Console.WriteLine("0-a bolme yoxdur!");
                    break;
                default:
                    Console.WriteLine("Duzgun emel daxil edin");
                    break;
            }
        }
    }
}
