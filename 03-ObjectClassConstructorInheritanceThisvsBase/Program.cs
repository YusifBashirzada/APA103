using _03_ObjectClassConstructorInheritanceThisvsBase.Models;

namespace _03_ObjectClassConstructorInheritanceThisvsBase
{
    internal class Program
    {
        static void Main(string[] args)
        {
             
            Person person = new Person();

            Console.WriteLine(person.GetFullName("Yusif", "Besirzade")); 
            person.ShowBasicInfo("Yusif", "Besirzade", 20, "yusifbesirzade@gmail.com");

            Student student1 = new Student()
            {
                FirstName = "Yusif",
                LastName = "Besirzade",
                Age = 20,
                Email = "yusif@mail.com",
                Id = "S001",
                StudentNumber = "A101",
                Faculty = "IT",
                GPA = 88.5,
                Year = 2
            };

            Student student2 = new Student()
            {
                FirstName = "Huseyin",
                LastName = "Velizade",
                Age = 22,
                Email = "huseyin@mail.com",
                Id = "S0021",
                StudentNumber = "A201",
                Faculty = "IT",
                GPA = 92.0,
                Year = 3
            };

            Student student3 = new Student()
            {
                FirstName = "Veli",
                LastName = "Velizade",
                Age = 24,
                Email = "veli@mail.com",
                Id = "S004",
                StudentNumber = "A133",
                Faculty = "IT",
                GPA = 68.5,
                Year = 4
            };

            Console.WriteLine(student1.ShowStudentInfo() + " Student GPA: " + student1.CalculateScholarship() + " AZN");
            Console.WriteLine(student2.ShowStudentInfo() + " Student GPA: " + student2.CalculateScholarship() + " AZN");
            Console.WriteLine(student3.ShowStudentInfo() + " Student GPA: " + student3.CalculateScholarship() + " AZN");

            Teacher teacher1 = new Teacher()
            {
                FirstName = "Samir",
                LastName = "Huseynov",
                Age = 35,
                Email = "samir@mail.com",
                Id = "T001",
                Department = "Mathematics",
                MainSubject = "Algebra",
                BaseSalary = 800,
                ExperienceYears = 15
            };

            Teacher teacher2 = new Teacher()
            {
                FirstName = "Leyla",
                LastName = "Mammadova",
                Age = 30,
                Email = "leyla@mail.com",
                Id = "T002",
                Department = "Physics",
                MainSubject = "Mechanics",
                BaseSalary = 700,
                ExperienceYears = 8
            };


            Console.WriteLine(teacher1.ShowTeacherInfo() + " Teacher Salary: " + teacher1.CalculateSalary() + " AZN");
            Console.WriteLine(teacher2.ShowTeacherInfo() + " Teacher Salary: " + teacher2.CalculateSalary() + " AZN");


            Administrator admin1 = new Administrator()
            {
                FirstName = "Leyla",
                LastName = "Hesenova",
                Age = 40,
                Email = "admin@mail.com",
                Id = "A001",
                Position = "Dekan",
                Department = "IT",
                AccessLevel = 5
            };

            Console.WriteLine(admin1.ShowAdminInfo());
            Console.WriteLine(admin1.GrantAccess(student1));

            Console.WriteLine( "Telebelerin Teqaudlerinin Cemi: " + (student1.CalculateScholarship() + student2.CalculateScholarship() + student3.CalculateScholarship()) + " AZN" );
            Console.WriteLine( "Muellimlerin Maaslarinin Cemi: " + (teacher1.CalculateSalary() + teacher2.CalculateSalary()) + " AZN" );
        }
    }
}
