using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Server_Thread_Delegate
{
	class HandleClient
	{
        public TcpClient client;
        public string clientNumber;
        public string value;

        public HandleClient(TcpClient client, string clientNumber)
        {
            this.client = client;
            this.clientNumber = clientNumber;

            Thread thread = new Thread(FirstPresent);
            thread.Start();
            Thread.Sleep(1000);
        }
        private void FirstPresent()
        {

            try
            {
                SendMessage(client, "Your ID is:" + clientNumber + ". Game is started!");

                string message = ReadMessage(client);
                Console.WriteLine("Client ID[" + clientNumber + "] sent " + message);

                value = message;
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
