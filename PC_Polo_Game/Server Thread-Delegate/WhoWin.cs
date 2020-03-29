using System;


namespace Server_Thread_Delegate
{
	class WhoWin
	{
		public static void Winner(Client client1, Client client2)
		{
			try
			{
				if (int.Parse(client1.value) > int.Parse(client2.value))
				{
					HandleClient.SendMessage(client1.client, "The winner is client ID[" + client1.clientNumber + "]!");
					HandleClient.SendMessage(client2.client, "The winner is client ID[" + client1.clientNumber + "]!");
				}
				else if (int.Parse(client2.value) > int.Parse(client1.value))
				{
					HandleClient.SendMessage(client1.client, "The winner is client ID[" + client2.clientNumber + "]!");
					HandleClient.SendMessage(client2.client, "The winner is client ID[" + client2.clientNumber + "]!");
				}
				else
				{
					HandleClient.SendMessage(client1.client, "DRAW");
					HandleClient.SendMessage(client2.client, "DRAW");
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
