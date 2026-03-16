using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_ObjectClassConstructorInheritanceThisvsBase.Models
{
    internal class Person
    {
        public string FirstName;
        public string LastName;
        public int Age;
        public string Email;
        public string Id;

        public Person()
        {
            
        }

        public Person(string FirstName):this()
        {
            this.FirstName = FirstName;
        }

        public Person(string FirstName, string LastName):this(FirstName)
        {
            this.LastName = LastName;
        }

        public Person(string FirstName, string LastName, int Age) : this(FirstName, LastName)
        {
            this.Age = Age;
        }

        public Person(string FirstName, string LastName, int Age, string Email) : this(FirstName, LastName, Age)
        {
            this.Email = Email;
        }

        public Person(string FirstName, string LastName, int Age, string Email, string Id) : this(FirstName, LastName, Age, Email)
        {
            this.Id = Id;
        }

        public string GetFullName(string FirstName, string LastName)
        {
            return $"{FirstName}{LastName}";
        }

        public void ShowBasicInfo(string FirstName, string LastName, int Age, string Email)
        {
            Console.WriteLine($"Name: {FirstName}");
            Console.WriteLine($"Surname: {LastName}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Email: {Email}");
        }
    }
}
