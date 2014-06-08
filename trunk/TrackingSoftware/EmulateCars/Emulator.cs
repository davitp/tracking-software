using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Timers;
using System.Net.Sockets;
using DataAccessLayer;
// emulating cars
// sending data from 
// cars to server
// coordinates, fuel and etc.
namespace EmulateCars {
    public class Emulator {

        // can read this value from internet
        // confing file to make values
        // configurable


        // server ip
        private const string serverIP = "localhost";

        // server port
        private const int port = 8435;

        // interval for data sending in milliseconds
        // 1 sec = 1000 msec
        private const double interval = 1000;
        // unit is car
        private const string unit = "car";
        // car ID's
        private static int[] cars;


        // connection
        private static TcpClient client;

       

        private static int carId;

        // locations
        private static double latitude;
        private static double longitude;
        // speed 
        private static int speed;
        private static double fuelLevel;
        private static bool changeOil;

        public Emulator() {

            var dataService = new EntityDataService(unit);
            // retrive ID's from db
            var carIds = dataService.ExecuteSet("GetIDs", null);

            // initialize car ID's
            int carsCnt = carIds.Count;
            cars = new int[carsCnt];
            for(int i = 0; i < carsCnt; i++)
                cars[i] = (int) carIds[i]["id"];

            
            // initialize start coordinates
            Random random = new Random(12435);
            latitude = random.NextDouble() / 588307;
            longitude = random.NextDouble() / 998017;

            

            speed = 0;
            changeOil = false;
            fuelLevel = 100.0;

            client = new TcpClient(serverIP, port);
            Console.WriteLine("-> Starting connection ... OK");
        }


        public void Main() {

            while(true) {
                Console.WriteLine("Enter car id to emulate: ");
                string carIdString = Console.ReadLine();
                // wh have carId
                carId = Convert.ToInt32(carIdString);
                bool br = false;
                // check for correctness
                foreach(int x in cars)
                    if(x == carId) {
                        br = true;
                        break;
                    }
                if(br)
                    break;
            }


            // OK. lets set timer... 
            Timer timer = new Timer(interval);
            timer.Elapsed += timer_Elapsed;

            // start emulate infinitly
            while(true)
                timer.Start();

        }


        // its time to send some info
        static void timer_Elapsed(object sender, ElapsedEventArgs e) {
            // implementing data sending
            var dataService = new EntityDataService(unit);


            // sending data as plain strings
            string bufferString;


            // buffer string is ready
            bufferString = String.Format("{0};{1};{2};{3};{4};{5};{6}",
                carId, fuelLevel,
                latitude, longitude,
                speed, changeOil,
                DateTime.Now.ToBinary()
                );



            byte[] buffer = Encoding.UTF8.GetBytes(bufferString);
            //if(BitConverter.IsLittleEndian)
            //    Array.Reverse(buffer);

            // send buffer
            client.Client.SendBufferSize = buffer.Length;
            client.Client.Send(buffer);
        
            // change car data
            if(speed < 60)
                speed += 8;
            else if(speed > 70)
                speed -= 15;
            else
                speed += 4;

            Random random = new Random(56788765);
            latitude += random.NextDouble();
            longitude += random.NextDouble();

            double fuelDecrement = random.NextDouble() / 1000;
            fuelLevel -= fuelDecrement;

        }


    }
}
