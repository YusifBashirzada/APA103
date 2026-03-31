using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _09_UpcastingDowncastingExplicitImplicit.Models
{
    public class Car : Vehicle
    {
        public int NumberOfDoors { get; set; }
        public int TrunkCapacity { get; set; }

        public override void GetVehicleInfo()
        {
            Console.WriteLine($"This is Car, NumberOfDoors: {NumberOfDoors} TrunkCapacity: {TrunkCapacity}");
        }
    }
}
