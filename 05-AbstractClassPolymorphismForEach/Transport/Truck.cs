using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_AbstractClassPolymorphismForEach.Transport
{
    internal class Truck:Vehicle
    {
        public double _CargoCapacity;
        public int _AxleCount;
        public double _CurrentLoad;
        public int _MaxSpeed;
        internal bool _IsAutomatic;

        public string ShowTruckInfo()
        {
            return $"Brand: {_Brand}, Model: {_Model}, Year: {_Year}, {_CargoCapacity}, {_AxleCount}, {_CurrentLoad}, {_MaxSpeed}, {_IsAutomatic}";
        }

        public double AddLoad(double distance)
        {
            return _CurrentLoad += distance;
        }

        public double truckCalculateFuelCost(double distance)
        {
            double serf = 25 + (_CurrentLoad * 2);
            double cost = (distance / 100) * serf * 1.80;
            return cost;
        }

        
    }
}
