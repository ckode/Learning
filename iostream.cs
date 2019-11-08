using System;
using System.Text;
using System.IO;
using System.Threading;

/*
The following is learning the c# way to write to streams.  This will
be used for the network daemon for the game even though it's currently
just writing to a local file.
 */
namespace StreamsAndAsync {
    public class Program {
        static void Main(string[] args) {
            string testMessage = "Testing writing some arbitrary string to a stream";
            byte[] messageBytes = Encoding.UTF8.GetBytes(testMessage);
            using (Stream ioStream = new FileStream(@"stream_demo_file.out", FileMode.OpenOrCreate)) {
                if (ioStream.CanWrite) { ioStream.Write(messageBytes, 0, messageBytes.Length);
                }
            }
        }
    }
}