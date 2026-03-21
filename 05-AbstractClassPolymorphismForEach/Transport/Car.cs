using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _05_AbstractClassPolymorphismForEach.Transport
{
    internal class Car : Vehicle
    {
        public int _DoorsCount;
        public int _TrunkCapacity;
        public bool _IsAutomatic;
        public int _MaxSpeed;
        public bool distance;

        public Car()
        {
            
        }

        public Car(int DoorsCount):this()
        {
            _DoorsCount = DoorsCount;
        }

        public Car(int DoorsCount, int TrunkCapacity) : this(DoorsCount)
        {
            _TrunkCapacity = TrunkCapacity;
        }

        public Car(int DoorsCount, int TrunkCapacity, bool IsAutomatic) : this(DoorsCount, TrunkCapacity)
        {
            _IsAutomatic = IsAutomatic;
        }

        public Car(int DoorsCount, int TrunkCapacity, bool IsAutomatic, int MaxSpeed) : this(DoorsCount, TrunkCapacity, IsAutomatic)
        {
            _MaxSpeed = MaxSpeed;
        }

        public string ShowCarInfo()
        {
            return $"Brand: {_Brand}, Model: {_Model}, Year: {_Year}, DoorsCount: {_DoorsCount}, TrunkCapacity: {_TrunkCapacity}, _IsAutomatic: {_IsAutomatic}, _MaxSpeed: {_MaxSpeed}";
        }

        public double carCalculateFuelCost(double distance)
        {
            double serf = 25;
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
