using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_AccessModifiresEncupsulationNamespace.Models
{
    public class Person
    {
        private protected string name;
        public string surname;

        public Person()
        {
            
        }

        public Person(string name)
        {
            this.name = name;
        }

        public void GetInfo()
        {
            Console.WriteLine($"{name}");
        }
    }
}
