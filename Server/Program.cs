using System.Reflection;
using TTMC.Auram;
using TTMC.Debris;
using TTMC.Tools;

namespace Listener
{
	class Program
	{
		public static string path = "Database.auram";
		public static Version? version = Assembly.GetExecutingAssembly().GetName().Version;
		static void Main(string[] args)
		{
			Console.Clear();
			Console.Title = "Auram Server";
			Debug.Print("████████████████████████████████████████████████████████████████████████\n██▀▄─██▄─██─▄█▄─▄▄▀██▀▄─██▄─▀█▀─▄███─▄▄▄▄█▄─▄▄─█▄─▄▄▀█▄─█─▄█▄─▄▄─█▄─▄▄▀█\n██─▀─███─██─███─▄─▄██─▀─███─█▄█─████▄▄▄▄─██─▄█▀██─▄─▄██▄▀▄███─▄█▀██─▄─▄█\n▀▄▄▀▄▄▀▀▄▄▄▄▀▀▄▄▀▄▄▀▄▄▀▄▄▀▄▄▄▀▄▄▄▀▀▀▄▄▄▄▄▀▄▄▄▄▄▀▄▄▀▄▄▀▀▀▄▀▀▀▄▄▄▄▄▀▄▄▀▄▄▀\n", ConsoleColor.Red);
			Debug.Print("Auram Server", ConsoleColor.Red, false);
			Debug.Print(" by TTMC Corporation ", ConsoleColor.DarkGray, false);
			Debug.Print("TheBlueLines", ConsoleColor.Blue);
			Debug.Print("Version: v0.3 BEAM\n", ConsoleColor.Cyan);
			Database database = new Database(File.Exists(path) ? path : null);
			Handler handler = new(database);
			Server server = new(13000, handler);
			Engine.InsertDate();
			Debug.OK("Server started! (Port: 13000)");
		}
	}
}