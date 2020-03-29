using System.Threading.Tasks;

namespace Server_Async_Await
{
	class Program
	{
		static async Task Main(string[] args)
		{
			HandleConnection connection = new HandleConnection();
			await connection.StartListener();
		}
	}
}
