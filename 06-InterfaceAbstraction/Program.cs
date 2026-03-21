using _06_InterfaceAbstraction.Models;

namespace _06_InterfaceAbstraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculation calculation = new Calculation();

            calculation.Calculate();
        }
    }
}
