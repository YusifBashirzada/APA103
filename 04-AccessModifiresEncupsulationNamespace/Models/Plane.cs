using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_AccessModifiresEncupsulationNamespace.Models
{
    public class Plane
    {
        public string _model;
        private int _capacity;

        public int Capacity 
        { 
            get { 
               if (_capacity > 45)
                {
                    Console.WriteLine("Can't carry people");
                }
               return _capacity;
            } 
            set {
                if(value > 45)
                {
                    Console.WriteLine("Please enter right value");
                }
                
                _capacity = value;
            } 
        }
    }
}
