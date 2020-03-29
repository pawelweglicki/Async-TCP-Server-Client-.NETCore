using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace Server_Thread_Delegate
{
	class Program
	{
		static void Main(string[] args)
		{
            TcpClient client;
            int counter = 0;
            List<Client> listOfCLients = new List<Client>();

            var server = new TcpListener(IPAddress.Loopback, 1234);
            server.Start();
            Console.WriteLine("--Server Started--");

            while (counter++ < 2)
            {
                client = server.AcceptTcpClient();

                Console.WriteLine("Client ID[" + Convert.ToString(counter) + "] connected!");
                HandleClient handleClient = new HandleClient(client, counter.ToString());

                Client tcpClient = new Client
                {
                    client = client,
                    value = handleClient.value,
                    clientNumber = counter.ToString()
                };
                listOfCLients.Add(tcpClient);
            }

            WhoWin.Winner(listOfCLients[0], listOfCLients[1]);

            server.Stop();
            Console.WriteLine("--Server stoped--");
            Console.ReadLine();
        }
	}
}
