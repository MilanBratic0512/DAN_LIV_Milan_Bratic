using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak_1
{
    class Truck : MotorVehicle
    {
        public double LoadCapacity { get; set; }
        public double Height { get; set; }
        public int NumberOfSeats { get; set; }

        public override void Go()
        {
            base.Go();
        }

        public override void Stop()
        {
            base.Stop();
        }

        public void Load() { }

        public void Unload() { }
    }
}
