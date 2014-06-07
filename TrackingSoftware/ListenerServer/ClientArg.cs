using System;
using System.Net.Sockets;
namespace ListenerServer {
    public class ClientArg {
        // client serial number
        public int ClientSerial { get; private set; }

        // client socket
        public TcpClient ClientSocket { get; private set; }

        public ClientArg(int n, TcpClient client) {
            ClientSerial = n;
            ClientSocket = client;
        }
    }
}
