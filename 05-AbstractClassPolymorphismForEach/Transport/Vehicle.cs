using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_AbstractClassPolymorphismForEach.Transport
{
    public abstract class Vehicle
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

        public abstract string GetVehicleInfo();

        public abstract void ShowBasicInfo();


    }
}
