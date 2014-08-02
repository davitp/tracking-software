using System;
using System.Threading;
using System.Net;
using System.Text;
using System.Net.Sockets;
using System.Collections.Generic;
using DataAccessLayer;

// implementing listener server
// that will wait for tcp connections
// from cars, revice data and send data to DB
namespace ListenerServer {
    public class Program {

        // unit for DB operations is car
        private const string unit = "car";


        // port of server
        private const int serverPort = 8435;

        static void Main(string[] args) {
            // TCP server socket
            // that listens serverPort for Any connection
            var serverSocket = new TcpListener(IPAddress.Any, serverPort);
            // prepare clientSocket
            TcpClient clientSocket = default(TcpClient);

            // serial number of connection
            int num = 0;
            serverSocket.Start();
            Console.WriteLine("-> Server is waiting for TCP connections on port {0}", serverPort);
            // start infinitly
            while(true) {
                // accept incoming connection
                clientSocket = serverSocket.AcceptTcpClient();
                num++; // increment connection counter
                /* For Debugging */
                Console.WriteLine("-> Accepted connection: {0} <-", num);
                // prepare client to serve
                ClientArg client = new ClientArg(num, clientSocket);
                // go and serve this client
                Thread serve = new Thread(new ParameterizedThreadStart(ServeClient));
                // start serve-thread
                serve.Start(client);
            }
            


        }

        /* serve client method for thread */
        private static void ServeClient(object obj) {
            // prepare argument
            ClientArg arg = (ClientArg) obj;
            // for debuging
            Console.WriteLine("-> Starting to serve: {0}", arg.ClientSerial);

            // prepare buffer
            byte[] buffer = new byte[1024];
            

            // serving until disconnecting
            while(arg.ClientSocket.Connected) {
                // read buffer
                int recivedBytes = 0;
                try {
                    recivedBytes = arg.ClientSocket.Client.Receive(buffer);
                } catch(Exception e) {
                    Console.WriteLine(e.Message);
                    break;
                }

                //if(BitConverter.IsLittleEndian)
                //    Array.Reverse(buffer);

                string sBuffer = Encoding.UTF8.GetString(buffer, 0, recivedBytes);
                

                // convert byte array into dictionary
                var convertedData = Protocol.ReciveData(sBuffer);

                /* debug recived result */
                Console.WriteLine("-> From client: {0}", arg.ClientSerial);
                //foreach(var r in convertedData)
                //    Console.Write("{0}: {1}, ", r.Key, r.Value);
                Console.WriteLine(sBuffer);
                Console.WriteLine();

                /* insert into DB */
                var dataService = new EntityDataService(unit);
                int rows = dataService.ExecuteNonQuery("InsertState", convertedData);
                
            }

        
        }
    }
}
