using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Text;
using System.Collections.Generic;

namespace AsyncServer {

    public class Client {
        /*
         * class Client
         * 
         * if I understand this correctly, we will likely want to 
         * wrap this class object in a real client object for the 
         * mud server.  Then we can use that object to access this
         * object for sending a recieving to the player.
         * 
         * Just FYI.  The send and recieve methods are static 
         * methods and not a part of the actual class object.
         * 
         * streambuff is the main incoming buffer from the stream
         * limited to 1024 by BufferSize.  The async keeps reading
         * this and applying it to the StringBuilder "buffer"
         * 
         * buffer is the main storaged of incoming data until an
         * EOF (or in our case ^M) is found and the data is ready
         * to be send to the game for processing.
         */
        public Socket socket = null;
        public const int BufferSize = 1024;
        public byte[] streambuffer = new byte[BufferSize];
        public StringBuilder buffer = new StringBuilder();
		public int client_id;
    }

	public class AsyncSocketListener {
		/*
		 * class AsyncSocketListner
		 * 
		 */
        public static ManualResetEvent allDone = new ManualResetEvent(false);
        public AsyncSocketListener() { }
        public List<Client> players = new List<Client>();
        public int ClientCount = 0;
        
		// static
		public void StartListening(IPAddress ip, int port, int max_conns) { 
            byte[] bytes = new byte[1024];
            IPAddress _ip = ip;
            int _port = port;
            int _max_connections = max_conns;
            IPEndPoint _ep = new IPEndPoint(_ip, _port);

            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

			try {
                listener.Bind(_ep);
                listener.Listen(_max_connections);
                Console.WriteLine("Starting listener...");
				while (true) {
                    allDone.Reset();
                    listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);
                    allDone.WaitOne();
                }
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
        }
		// static
		public void AcceptCallback(IAsyncResult AsyncResult) {
            allDone.Set();
            Socket listener = (Socket)AsyncResult.AsyncState;
            Socket handler = listener.EndAccept(AsyncResult);
            Client client = new Client();
            ClientCount++;
            client.client_id = ClientCount;
            Console.WriteLine(String.Format("Assigned {0} to connecting client", ClientCount));
            players.Add(client);
            
            client.socket = handler;
            handler.BeginReceive(client.streambuffer, 0, Client.BufferSize, 0, new AsyncCallback(ReadCallback), client);
        }
		//static
		public void ReadCallback(IAsyncResult AsyncResult) {
            String content = String.Empty;
            Client client = (Client)AsyncResult.AsyncState;
            Socket handler = client.socket;
            int inputbuffer = handler.EndReceive(AsyncResult);

			if (inputbuffer > 0) {
                client.buffer.Append(Encoding.ASCII.GetString(client.streambuffer, 0, inputbuffer));
                content = client.buffer.ToString();
                if (content.IndexOf('\n') > -1) {
                    Console.WriteLine("Read {0} bytes from socket.\nData: {1}", content.Length, content);
                    String outstring = String.Format("Client #{0} said, {1}", client.client_id, content);
                    SendToAllPlayers(outstring);
                } else {
                    handler.BeginReceive(client.streambuffer, 0, Client.BufferSize, 0, new AsyncCallback(ReadCallback), client);
                }
            }
        }
		//static
		public void Send(Socket handler, String data) {
            byte[] databytes = Encoding.ASCII.GetBytes(data);
            handler.BeginSend(databytes, 0, databytes.Length, 0, new AsyncCallback(SendCallback), handler);
        }
		// static
		public void SendToAllPlayers(String data) {
			foreach (Client player in players) {
                Send(player.socket, data);
            }
        }
		// static
		private void SendCallback(IAsyncResult AsyncResult) {
			try {
                Socket handler = (Socket)AsyncResult.AsyncState;
                int bytessent = handler.EndSend(AsyncResult);
                Console.WriteLine("Sent {0} bytes to client.", bytessent);
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
        }
        public static int Main(String[] args) {
            AsyncSocketListener server = new AsyncSocketListener();
			if(server.players != null) {
				Console.WriteLine("It exists");
			}
            server.StartListening(IPAddress.Parse("0.0.0.0"), 23, 10);
            return 0;
        }
    }
}