using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_ObjectClassConstructorInheritanceThisvsBase.Models
{
    internal class Administrator:Person
    {
        public string Position;
        public string Department;
        public int AccessLevel;

        public Administrator()
        {

        }

        public Administrator(string Position, string Department, int AccessLevel):this()
        {
            this.Position = Position;
            this.Department = Department;
            this.AccessLevel = AccessLevel;
        }

        public string ShowAdminInfo()
        {
            return $"Name: {FirstName} Surname: {LastName} Email: {Email} Position: {Position} Department: {Department} AccesLevel: {AccessLevel}";
        }

        public string GrantAccess(Student student) {
            return ($"{FirstName} {LastName} granted access to {student.FirstName} {student.LastName}");
        }
    }
}
