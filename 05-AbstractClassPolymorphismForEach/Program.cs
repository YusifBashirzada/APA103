using _05_AbstractClassPolymorphismForEach.Transport;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;

namespace _05_AbstractClassPolymorphismForEach
{
    public class Program
       {
        public static void Main(string[] args)
        {

            Car car1 = new Car()
            {
                _Brand = "Audi",
                _Model = "A6",
                _Year = 2024,
                _DoorsCount = 4,
                _TrunkCapacity = 520,
                _IsAutomatic = true,
                _MaxSpeed = 230,
                _FuelLevel = 100
            };

            Car car2 = new Car()
            {
                _Brand = "BMW",
                _Model = "X5",
                _Year = 2022,
                _DoorsCount = 5,
                _TrunkCapacity = 600,
                _IsAutomatic = true,
                _MaxSpeed = 240,
                _FuelLevel = 100
            };

            Car car3 = new Car()
            {
                _Brand = "Toyota",
                _Model = "Corolla",
                _Year = 2020,
                _DoorsCount = 4,
                _TrunkCapacity = 450,
                _IsAutomatic = false,  
                _MaxSpeed = 180,
                _FuelLevel = 100
            };

            Console.WriteLine(car1.GetVehicleInfo());

            Console.WriteLine("Esas Melumatlar:");
            car1.ShowBasicInfo();

            Console.WriteLine();

            Console.WriteLine("Avtomobil Masini Melumatlari:");
            Console.WriteLine($"1) {car1.ShowCarInfo()}");
            Console.WriteLine($"2) {car2.ShowCarInfo()}");
            Console.WriteLine($"3) {car3.ShowCarInfo()}");
            Console.Write($"Avtomobil Yanacaq xerci: {car1.carCalculateFuelCost(500)} AZN");

            Console.WriteLine();
            Console.WriteLine();

            Motorcycle motorcycle1 = new Motorcycle()
            {
                _Brand = "Harley-Davidson",
                _Model = "Street 750",
                _Year = 2021,
                _EngineCapacity = 750,
                _HasSidecar = false,
                _MaxSpeed = 180,
                _Type = "Cruiser",
                _FuelLevel = 100
            };

            Motorcycle motorcycle2 = new Motorcycle()
            {
                _Brand = "Yamaha",
                _Model = "MT-07",
                _Year = 2023,
                _EngineCapacity = 689,
                _HasSidecar = false,
                _MaxSpeed = 200,
                _Type = "Sport",
                _FuelLevel = 100
            };

            Console.WriteLine("Motosiklet  Masini Melumatlari:");
            Console.WriteLine($"1) {motorcycle1.ShowMotorcycleInfo()}");
            Console.WriteLine($"2) {motorcycle2.ShowMotorcycleInfo()}");
            Console.Write($"Moto Yanacaq Xerci: {motorcycle1.motoCalculateFuelCost(300)} AZN");

            Console.WriteLine();
            Console.WriteLine();

            Truck truck1 = new Truck()
            {
                _Brand = "Volvo",
                _Model = "FH16",
                _Year = 2023,
                _CargoCapacity = 20000, 
                _AxleCount = 3,
                _CurrentLoad = 15000,   
                _MaxSpeed = 120,         
                _IsAutomatic = true,
                _FuelLevel = 100
            };

            Truck truck2 = new Truck()
            {
                _Brand = "Scania",
                _Model = "R500",
                _Year = 2022,
                _CargoCapacity = 18000,
                _AxleCount = 2,
                _CurrentLoad = 10000,
                _MaxSpeed = 110,
                _IsAutomatic = false,
                _FuelLevel = 100
            };

            Console.WriteLine("Yuk Masini Melumatlari:");
            Console.WriteLine($"1) {truck1.ShowTruckInfo()}");
            Console.WriteLine($"2) {truck2.ShowTruckInfo()}");
            Console.WriteLine($"Truck Yanacaq xerci: {truck1.truckCalculateFuelCost(800)} AZN");
             
            Console.WriteLine($"Trucka 5 Ton Yuk elave olundu ve Neticede: {truck1.AddLoad(5)} Ton");

            Console.WriteLine("Statistika");
            Console.Write("Umumi Neqliyyat Sayi:");
            Console.Write(7);
            Console.WriteLine();
            Console.Write("Orta Max Suret:");
            Console.Write((truck1._MaxSpeed + truck2._MaxSpeed + car1._MaxSpeed + car2._MaxSpeed + car3._MaxSpeed + motorcycle1._MaxSpeed + motorcycle2._MaxSpeed)/7);
            Console.WriteLine();
            Console.WriteLine($"En Bahali Yanacaq Xerci olan neqliyyat Truckdir - {truck1.truckCalculateFuelCost(800)} AZN");


        }
    }
   
}
