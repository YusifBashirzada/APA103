using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_AbstractClassPolymorphismForEach.Transport
{
    internal class Vehicle
    {
        public string _Brand;
        public string _Model;
        public int _Year;
        public string _PlateNumber;
        public double _FuelLevel = 100;

        public Vehicle()
        {
            
        }

        public Vehicle(string Brand):this()
        {
            _Brand = Brand;
        }

        public Vehicle(string Brand, string Model) : this(Brand)
        {
            _Model = Model;
        }

        public Vehicle(string Brand, string Model, int Year) : this(Brand, Model)
        {
            _Year = Year;
        }

        public Vehicle(string Brand, string Model, int Year, string PlateNumber) : this(Brand, Model, Year)
        {
            _PlateNumber = PlateNumber;
        }

        public Vehicle(string Brand, string Model, int Year, string PlateNumber, double FuelLevel) : this(Brand, Model, Year, PlateNumber)
        {
            _FuelLevel = FuelLevel;
        }

        public string GetVehicleInfo()
        {
            return $"{_Brand}{_Model}{_Year}{_PlateNumber}{_FuelLevel}";
        }

        public void ShowBasicInfo()
        {
            Console.WriteLine($"Brand: {_Brand}");
            Console.WriteLine($"Model: {_Model}");
            Console.WriteLine($"Year: {_Year}");
            Console.WriteLine($"PlateNumber: {_PlateNumber}");
            Console.WriteLine($"FuelLevel: {_FuelLevel}");
        }
    }
}
