using System;
using System.Net.Sockets;
using System.Text;

namespace Server_Async_Await
{
	class WhoWin
	{
		public void Winner(Client client1, Client client2)
		{
			try
			{
				if (int.Parse(client1.value) > int.Parse(client2.value))
				{
					HandleConnection.SendMessage(client1.client, "The winner is client ID[" + client1.clientNumber + "]!");
					HandleConnection.SendMessage(client2.client, "The winner is client ID[" + client1.clientNumber + "]!");
					
				}
				else if (int.Parse(client2.value) > int.Parse(client1.value))
				{
					HandleConnection.SendMessage(client1.client, "The winner is client ID[" + client2.clientNumber + "]!");
					HandleConnection.SendMessage(client2.client, "The winner is client ID[" + client2.clientNumber + "]!");
				}
				else
				{
					HandleConnection.SendMessage(client1.client, "DRAW!");
					HandleConnection.SendMessage(client2.client, "DRAW!");
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
				Console.ReadLine();
			}
		}
	}
}
