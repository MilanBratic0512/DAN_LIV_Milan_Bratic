using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak_1
{
    abstract class MotorVehicle
    {
        public double EngineDisplacement { get; set; }
        public int Weight { get; set; }
        public string Category { get; set; }
        public string EngineType { get; set; }
        public string Color { get; set; }
        public int EngineNumber { get; set; }

        public virtual void Go()
        {
            Console.WriteLine("The vehicle started");
        }

        public virtual void Stop() { }
    }
}
