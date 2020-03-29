using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client
{
	class Client
	{
        static public void HandleConnection()
        {

            try
            {
                TcpClient client = new TcpClient(IPAddress.Loopback.ToString(), 1234);

                string message = ReadMessage(client);
                Console.WriteLine(message);

                Random random = new Random();
                SendMessage(client, random.Next(1, 10).ToString());

                message = ReadMessage(client);
                Console.WriteLine(message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.ReadLine();
            }
        }

        public static void SendMessage(TcpClient client, string message)
        {
            byte[] bytes = new byte[256];
            NetworkStream networkStream = client.GetStream();
            bytes = Encoding.ASCII.GetBytes(message);
            networkStream.Write(bytes, 0, bytes.Length);
        }

        public static string ReadMessage(TcpClient client)
        {
            byte[] bytes = new byte[256];
            NetworkStream networkStream = client.GetStream();
            networkStream.Read(bytes, 0, bytes.Length);
            string message = Encoding.ASCII.GetString(bytes);
            return message;
        }
    }
}
