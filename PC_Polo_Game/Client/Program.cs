using System;
using System.Threading;

namespace Client
{
	class Program
	{
		static void Main(string[] args)
		{
            new Thread(delegate ()
            {
                Thread.CurrentThread.IsBackground = true;
                Client.HandleConnection();
            }).Start();

            new Thread(delegate ()
            {
                Thread.CurrentThread.IsBackground = true;
                Client.HandleConnection();
            }).Start();
            Console.ReadLine();
        }
	}
}
