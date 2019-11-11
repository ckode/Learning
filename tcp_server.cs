using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace SampleTCPServer {

    class Client {
        public Socket client;
        public 
    }
    class TelnetServer {
        int port = 2500;
        public const int buffer_size = 1024;
        
        IPAddress address = IPAddress.Any;
        TcpListener server = new TcpListener(address, port);
        
    }
}