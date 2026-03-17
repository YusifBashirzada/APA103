using _04_AccessModifiresEncupsulationNamespace.Models;
using System;

namespace Domain
{
    public class Admin:Person
    {
        public static void Check(string name):base(name)
        {
            //Person person = new Person();
        }
    }
}
