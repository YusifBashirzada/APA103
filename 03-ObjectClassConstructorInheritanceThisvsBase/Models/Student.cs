using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_ObjectClassConstructorInheritanceThisvsBase.Models
{
    internal class Student:Person
    {
        public string StudentNumber;
        public string Faculty;
        public double GPA;
        public int Year;

        public Student() : base()
        {

        }

        public Student(string StudentNumber) : this()
        {
            StudentNumber = StudentNumber;
        }

        public Student(string StudentNumber, string Faculty) : this(StudentNumber)
        {
            Faculty = Faculty;
        }

        public Student(string StudentNumber, string Faculty, double GPA) : this(StudentNumber, Faculty)
        {
            GPA = GPA;
        }

        public Student(string StudentNumber, string Faculty, double GPA, int Year) : this(StudentNumber, Faculty, GPA)
        {
            Year = Year;
        }

        public string ShowStudentInfo()
        {
            return $"Student Number: {StudentNumber} Faculty:{Faculty} GPA:{GPA} Year:{Year}";
        }

        public double CalculateScholarship()
        {
            if(GPA >= 90.0)
            {
                return 500;
            }
            else if(GPA >= 80.0)
            {
                return 350;
            }
            else if(GPA >= 70.0) 
            {
                return 200;
            }
            else
            {
                return 0;
            }
        }
    }
}
