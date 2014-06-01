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


            Console.WriteLine("End!");
            Console.ReadKey();
        }
    }
}
