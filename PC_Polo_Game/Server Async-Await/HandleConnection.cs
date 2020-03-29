using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server_Async_Await
{
	class HandleConnection
	{
		public TcpClient client;
		public List<Client> listOfCLients = new List<Client>();
		public string clientNumber;
		public string value;

		int counter = 0;

		public async Task StartListener()
		{
			var listener = new TcpListener(IPAddress.Loopback, 1234);
			listener.Start();
			Console.WriteLine("--Server started--");
			while (counter++ < 2)
			{
				clientNumber = counter.ToString();
				var tcpClient = await listener.AcceptTcpClientAsync();
				client = tcpClient;
				Console.WriteLine("Client ID[" + Convert.ToString(counter) + "] connected!");
				FirstPresent(tcpClient);


				Client storedClient = new Client
				{
					client = this.client,
					value = this.value,
					clientNumber = counter.ToString()
				};
				listOfCLients.Add(storedClient);				
			}

			WhoWin game = new WhoWin();
			game.Winner(listOfCLients[0], listOfCLients[1]);

			listener.Stop();
			Console.WriteLine("--Server stoped--");
			Console.ReadLine();
		}

		private void FirstPresent(TcpClient tcpClient)
		{
			SendMessage(tcpClient, "Your ID is:" + clientNumber + ". Game is started!");
		
			string message = ReadMessage(tcpClient);
			Console.WriteLine("Client ID[" + counter + "] sent " + message);
			value = message;
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
