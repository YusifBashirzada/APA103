using _04_AccessModifiresEncupsulationNamespace.Models;


namespace _04_AccessModifiresEncupsulationNamespace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Student student = new Student("Huseyin");
            //student.name = "Huseyin";

            //Console.WriteLine(student.name);

            //student.GetInfo();

            Plane plane = new Plane();

            plane.Capacity = 46;

            Console.WriteLine(plane.Capacity);
          
        }
    }
}
