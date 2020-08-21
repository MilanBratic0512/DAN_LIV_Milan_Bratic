using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak_1
{
    class Tractor : MotorVehicle
    {
        public double TireSize { get; set; }
        public int Wheelbase { get; set; }
        public string Drive { get; set; }

        public override void Go()
        {
            base.Go();
        }

        public override void Stop()
        {
            base.Stop();
        }
    }
}
