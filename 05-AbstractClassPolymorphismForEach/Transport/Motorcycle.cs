using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_AbstractClassPolymorphismForEach.Transport
{
    internal class Motorcycle : Vehicle
    {
        public int _EngineCapacity;
        public bool _HasSidecar;
        public int _MaxSpeed;
        public string _Type;

        public Motorcycle()
        {
            
        }

        public Motorcycle(int EngineCapacity):this()
        {
            _EngineCapacity = EngineCapacity;
        }

        public Motorcycle(int EngineCapacity, bool HasSideCar) : this(EngineCapacity)
        {
            _HasSidecar = HasSideCar;
        }

        public Motorcycle(int EngineCapacity, bool HasSideCar, int MaxSpeed) : this(EngineCapacity, HasSideCar)
        {
            _MaxSpeed = MaxSpeed;
        }

        public Motorcycle(int EngineCapacity, bool HasSideCar, int MaxSpeed, string Type) : this(EngineCapacity, HasSideCar, MaxSpeed)
        {
            _Type = Type;
        }

        public string ShowMotorcycleInfo()
        {
            return $"Brand: {_Brand}, Model: {_Model}, Year: {_Year}, {_EngineCapacity}, {_HasSidecar}, {_MaxSpeed}, {_Type}";
        }


        public double motoCalculateFuelCost(double distance)
        {
            double serf = 15;   
            double cost = (distance / 100) * serf * 1.80;
            return cost;
        }

        public override string GetVehicleInfo()
        {
            return $"{_Brand}{_Model}{_Year}{_PlateNumber}{_FuelLevel}";
        }

        public override void ShowBasicInfo()
        {
            Console.WriteLine($"Brand: {_Brand}");
            Console.WriteLine($"Model: {_Model}");
            Console.WriteLine($"Year: {_Year}");
            Console.WriteLine($"PlateNumber: {_PlateNumber}");
            Console.WriteLine($"FuelLevel: {_FuelLevel}");
        }
    }
}
