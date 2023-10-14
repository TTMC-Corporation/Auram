using TTMC.Auram;
using TTMC.Tools;

namespace Beat
{
	internal class Program
	{
		public static string address = "127.0.0.1";
		public static ushort port = 13000;
		public static Database database = new();
		public static void Intro()
		{
			Console.Clear();
			Console.Title = "Auram Beat";
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("████████████████████████████████████████████████████████████\n██▀▄─██▄─██─▄█▄─▄▄▀██▀▄─██▄─▀█▀─▄███▄─▄─▀█▄─▄▄─██▀▄─██─▄─▄─█\n██─▀─███─██─███─▄─▄██─▀─███─█▄█─█████─▄─▀██─▄█▀██─▀─████─███\n▀▄▄▀▄▄▀▀▄▄▄▄▀▀▄▄▀▄▄▀▄▄▀▄▄▀▄▄▄▀▄▄▄▀▀▀▄▄▄▄▀▀▄▄▄▄▄▀▄▄▀▄▄▀▀▄▄▄▀▀\n");
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write("Auram Beat");
			Console.ForegroundColor = ConsoleColor.DarkGray;
			Console.Write(" by TTMC Corporation ");
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine("TheBlueLines");
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine("Version: v0.5 IGNIS\n");
		}
		static void Main(string[] args)
		{
			Intro();
			try
			{
				database.Connect();
				Debug.Print("Connected to Auram server at " + address + ":" + port, ConsoleColor.Yellow);
				Terminal.DoWork();
			}
			catch
			{
				Debug.Error("Failed to connect to Auram server at " + address + ":" + "port");
			}
		}
	}
}