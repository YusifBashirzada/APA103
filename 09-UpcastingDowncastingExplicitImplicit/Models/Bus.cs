using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_UpcastingDowncastingExplicitImplicit.Models
{
    public class Bus : Vehicle
    {
        public int SeatingCapacity { get; set; }
        public string DriverName { get; set; }
        public string RouteNumber { get; set; }
     
       

        public override void GetVehicleInfo()
        {
            Console.WriteLine($"This is bus, Seating Capacity: {SeatingCapacity} Driver Name: {DriverName} Route Number: {RouteNumber}");
        }
    }
}
