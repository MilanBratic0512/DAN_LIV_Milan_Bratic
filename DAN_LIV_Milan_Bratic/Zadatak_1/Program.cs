using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Zadatak_1
{
    class Program
    {

        static Random r = new Random();

        static void Main(string[] args)
        {
            Truck truck1 = new Truck();
            Truck truck2 = new Truck();

            Tractor tractor1 = new Tractor();
            Tractor tractor2 = new Tractor();

            Car car1 = new Car();
            car1.RegNumber = "NS123AB";
            Car car2 = new Car();
            car2.RegNumber = "BG987BC";

            List<Truck> trucks = new List<Truck> { truck1, truck2 };
            List<Tractor> tractors = new List<Tractor> { tractor1, tractor2 };
            List<Car> cars = new List<Car> { car1, car2 };

            Stopwatch s = new Stopwatch();

            s.Start();
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine(s.ElapsedMilliseconds / 1000);
            }
            s.Stop();
            

            foreach (var car in cars)
            {
                car.SetToStart();
                car.RemainingFuel = 100;
                car.fuelConsumptionPerSecond = r.Next(6, 9);
            }
            Car car3 = new Car();
            car3.Color = "orange";
            car3.Manufacturer = "Golf";
            car3.RegNumber = "NI456CD";
            car3.fuelConsumptionPerSecond = r.Next(6, 9);
            car3.RemainingFuel = 100;
            car3.SetToStart();

            Thread t1 = new Thread(() => car1.ToRace());
            Thread t2 = new Thread(() => car2.ToRace());
            Thread t3 = new Thread(() => car3.ToRace());
            Thread semaphore = new Thread(() => Car.Semaphore());

            semaphore.Start();
            t1.Start();
            t2.Start();
            t3.Start();

            Console.ReadLine();
        }
    }
}
