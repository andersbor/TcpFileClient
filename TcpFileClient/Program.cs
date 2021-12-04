using System;
using System.IO;
using System.Net.Sockets;

namespace TcpFileClient
{
    class Program
    {
        public const int Port = 14593;
        public const string Host = "127.0.0.1";
        private const string Filename = "c:\\temp\\shortvideo.mp4"; // "c:\\temp\\andersb.jpg";
        
        static void Main()
        {
            Console.WriteLine($"TCP file client. Server: ({Host}, {Port})");
            TcpClient socket = new TcpClient(Host, Port);
            NetworkStream ns = socket.GetStream();
            using (FileStream fileStream = new FileStream(Filename, FileMode.Open))
            {
                fileStream.CopyTo(ns);
            }
            socket.Close();
        }
    }
}
