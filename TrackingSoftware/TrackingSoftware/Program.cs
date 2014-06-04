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
            var car = repo.GetById(1);
            
            Console.WriteLine("Id: {0},  Color: {1}, Manufacturer: {2}, Model: {3}", 
                car.Id, car.Color, car.Manufacturer, car.Model);

            


            Console.WriteLine("End!");
            Console.ReadKey();
        }
    }
}
