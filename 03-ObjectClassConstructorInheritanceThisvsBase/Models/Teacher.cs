using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_ObjectClassConstructorInheritanceThisvsBase.Models
{
    internal class Teacher:Person
    {
        public string Department;
        public string MainSubject;
        public decimal BaseSalary;
        public int ExperienceYears;

        public Teacher()
        {

        }

        public Teacher(string Department) : this() 
        {
            Department = Department;
        }

        public Teacher(string Department, string MainSubject) : this(Department)
        {
            MainSubject = MainSubject;
        }

        public Teacher(string Department, string MainSubject, decimal BaseSalary) : this(Department, MainSubject)
        {
            BaseSalary = BaseSalary;
        }

        public Teacher(string Department, string MainSubject, decimal BaseSalary, int ExperienceYears) : this(Department, MainSubject, BaseSalary)
        {
            ExperienceYears = ExperienceYears;
        }

        public string ShowTeacherInfo()
        {
            return $"Teacher Department: {Department} Teacher MainSubject: {MainSubject} Teacher Salary: {BaseSalary} Teacher ExperienceYears:{ExperienceYears}";
        }

        public int CalculateSalary()
        {
            int netice = Convert.ToInt32(BaseSalary) + (ExperienceYears * 50);
            return netice;
        }


    }
}
