using _09_UpcastingDowncastingExplicitImplicit.Models;

namespace _09_UpcastingDowncastingExplicitImplicit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car() { Brand = "Toyota", Model = "Corolla", Year = 2022, PlateNumber = "10-BY-145", FuelLevel = 5, NumberOfDoors = 4, TrunkCapacity = 300 };
            Bus bus = new Bus() { Brand = "Mercedes", Model ="Sprinter", Year = 2021, PlateNumber = "55-YB-345", FuelLevel = 6, SeatingCapacity = 15, DriverName = "Huseyin", RouteNumber = "B13" };

            // UpCasting
            Vehicle vehicle = car;
            Vehicle vehicle1 = bus;

            // DownCasting
            //Car car1 = (Car)vehicle;
            Car car1 = vehicle1 as Car;
            //Bus bus1 = (Bus)vehicle1;
            Bus bus1 = vehicle1 as Bus;

            //Vehicle[] vehicles = { car, bus };

            //foreach(var vehicle in vehicles)
            //{
            //    Car car1 = vehicle as Car;
            //    if (vehicle is Car)
            //    {
            //        Car car2 = (Car)vehicle;
            //    }
            //}

            car.GetVehicleInfo();
            bus.GetVehicleInfo();
        }
    }
}
