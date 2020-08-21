using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Zadatak_1
{
    class Car : MotorVehicle
    {
        public static Random r = new Random();
        static AutoResetEvent are = new AutoResetEvent(false);
        static readonly object o = new object();

        public string RegNumber { get; set; }
        public int NumberOfDoors { get; set; }
        //public int EngineDisplacement { get; set; }
        public string TypeOfTransmision { get; set; }
        public string Manufacturer { get; set; }
        public int TrafficLicenseNumber { get; set; }
        public int fuelConsumptionPerSecond;

        private int remainingFuel;

        public int RemainingFuel
        {
            get
            {
                return remainingFuel;
            }
            set
            {
                if (RemainingFuel <= 100)
                {
                    remainingFuel = value;
                }
                else
                {
                    Console.WriteLine("You can fill up to 100 liters of fuel");
                }
            }
        }

        public override void Go()
        {
            Console.WriteLine("\tCar " + RegNumber + " started");
        }

        public override void Stop()
        {
            Console.WriteLine("\tCar" + " " + RegNumber + " stopped at a traffic light");
        }

        public void Repaint()
        {
            Color = "Red";
            TrafficLicenseNumber = r.Next(10000, 100000);
        }

        public void PostaviNaStart()
        {
            Console.WriteLine("The car {0} is set to start", RegNumber);
        }

        public void ToRace()
        {
            Stopwatch s = new Stopwatch();
            Stopwatch t = new Stopwatch();
            Stopwatch u = new Stopwatch();
            Stopwatch v = new Stopwatch();

            s.Start();
            while (s.ElapsedMilliseconds < 10000)
            {
                if (RemainingFuel > 0)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("The car {0} is moving", RegNumber);
                    RemainingFuel = RemainingFuel - fuelConsumptionPerSecond;
                }
                else
                {
                    Console.WriteLine("The car {0} run out of fuel", RegNumber);
                    return;
                }
            }
            s.Stop();

            Stop();
            are.WaitOne();

            t.Start();
            Go();
            while (t.ElapsedMilliseconds < 3000)
            {
                Thread.Sleep(1000);
                Console.WriteLine("The car {0} is moving", RegNumber);
                RemainingFuel = RemainingFuel - fuelConsumptionPerSecond;
            }
            t.Stop();

            lock (o)
            {
                if (RemainingFuel < 15)
                {
                    Console.WriteLine("\tThe car" + " " + RegNumber + " " + " stopped to refuel");
                    Console.WriteLine("\tThe car {0} was refueling.", RegNumber);
                    RemainingFuel = 100;
                }
            }

            v.Start();
            while (v.ElapsedMilliseconds < 7000)
            {
                if (RemainingFuel > 0)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("The car {0} is moving", RegNumber);
                    RemainingFuel = RemainingFuel - fuelConsumptionPerSecond;
                }
                else
                {
                    Console.WriteLine("The car {0} ran out of fuel", RegNumber);
                    return;
                }
            }
            v.Stop();

            Console.WriteLine("\n\t {0} finished the race!\n", RegNumber);
        }

        public static void Semaphore()
        {
            Stopwatch s = new Stopwatch();
            s.Start();
            while (s.ElapsedMilliseconds < 100000)
            {
                if (s.ElapsedMilliseconds % 2000 == 0)
                {
                    are.Set();
                }
                else
                {
                    are.Reset();
                }
            }
        }
    }
}
