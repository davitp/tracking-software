using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;

namespace TrackingSoftware
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Build success!");
            Console.WriteLine("Using Repo ... ");

            CarRepository repo = new CarRepository();
            var cars = repo.GetAll();
            foreach(var car in cars) {
                Console.WriteLine("Id: {0}, DeviceId: {1}, Color: {2}, Manufacturer: {3}, Model: {4}", 
                    car.Id, car.CarDeviceId, car.Color, car.Manufacturer, car.Model);

            }


            Console.WriteLine("End!");
            Console.ReadKey();
        }
    }
}
