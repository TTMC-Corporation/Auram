using System.Text;
using TTMC.Tools;

namespace Beat
{
	public class Terminal
	{
		public static bool Run = true;
		public static void Execute(string command)
		{
			string[] nzx = command.Split(' ');
			if (nzx.Length > 0)
			{
				switch (nzx[0].ToLower())
				{
					case "get":
						if (nzx.Length == 2)
						{
							byte[] data = Program.database.Get(nzx[1]);
							Debug.OK(nzx[1] + " is " + Encoding.UTF8.GetString(data));
							return;
						}
						Debug.Error("Usage: get <key>");
						return;
					case "set":
						if (nzx.Length == 3)
						{
							Program.database.Set(nzx[1], nzx[2]);
							Debug.OK(nzx[1] + " is now " + nzx[2]);
							return;
						}
						Debug.Error("Usage: set <key> <value>");
						return;
					case "remove":
						if (nzx.Length == 2)
						{
							bool check = Program.database.Remove(nzx[1]);
							Debug.Print(check ? nzx[1] + " successfully removed" : "Failed to remove" + nzx[1], check ? ConsoleColor.Green : ConsoleColor.Red);
							return;
						}
						Debug.Error("Usage: remove <key>");
						return;
					case "save":
						Program.database.Save(string.Empty);
						Debug.OK("Database saved!");
						return;
					case "load":
						Program.database.Load(string.Empty);
						Debug.OK("Database loaded!");
						return;
					case "keys":
						Debug.OK("Keys in the database:");
						foreach (string key in Program.database.keys)
						{
							Debug.Comment(key);
						}
						return;
				}
			}
			Debug.Error("Unknown command");
		}
		public static void DoWork()
		{
			while (Run)
			{
				Console.ForegroundColor = ConsoleColor.Blue;
				Console.Write(" » ");
				string? message = Console.ReadLine();
				if (message == null)
				{
					Program.database.Disconnect();
					Debug.Error("PROGRAM EXITED");
					Run = false;
					Environment.Exit(0);
				}
				else if (message == string.Empty)
				{
					Debug.Print(" « Command can't be empty", ConsoleColor.DarkGray);
				}
				else
				{
					if (message.ToUpper() == "EXIT")
					{
						Program.database.Disconnect();
						Debug.Error("PROGRAM EXITED");
						Run = false;
						Environment.Exit(0);
					}
					else if (message.ToUpper() == "CLEAR" || message.ToUpper() == "RESET")
					{
						Program.Intro();
						Debug.Print("Connected to Auram server at " + Program.address + ":" + Program.port, ConsoleColor.Yellow);
					}
					if (message.ToUpper().StartsWith("RUN"))
					{
						if (message.Length == 3)
						{
							Debug.Print($" « Usage: RUN <SCRIPT>\n « Example: RUN {Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\demo.script", ConsoleColor.DarkGray);
						}
						else
						{
							string path = message[4..];
							Console.WriteLine(path);
							if (File.Exists(path))
							{
								foreach (string line in File.ReadLines(path))
								{
									Execute(line);
								}
							}
							else
							{
								Debug.Error("FILE NOT FOUND");
							}
						}
					}
					else if (message.Split(' ')[0].ToUpper() == "CONNECT")
					{
						if (message.Split(' ').Length == 2)
						{
							string[] x = message.Split(' ');
							string[] y = x[1].Split(':');
							if (y.Length == 1)
							{
								try
								{
									Program.Intro();
									Program.database.Disconnect();
									Program.database.Connect(y[0], ushort.Parse(y[1]));
									Console.ForegroundColor = ConsoleColor.Green;
									Console.WriteLine(" « CONNECTED");
									Program.address = y[0];
									Program.port = ushort.Parse(y[1]);
								}
								catch
								{
									Console.ForegroundColor = ConsoleColor.DarkGray;
									Console.WriteLine(" « Can't connect to server at " + y[0] + ":" + Program.port);
								}
							}
							else
							{
								try
								{
									Program.Intro();
									Program.database.Disconnect();
									Program.database.Connect(y[0], ushort.Parse(y[1]));
									Console.ForegroundColor = ConsoleColor.Green;
									Console.WriteLine(" « CONNECTED");
									Program.address = y[0];
									Program.port = ushort.Parse(y[1]);
								}
								catch
								{
									Console.ForegroundColor = ConsoleColor.DarkGray;
									Console.WriteLine(" « Can't connect to server at " + y[0] + ":" + y[1]);
								}
							}
						}
						else
						{
							Console.ForegroundColor = ConsoleColor.DarkGray;
							Console.WriteLine(" « Usage: CONNECT <SERVER:PORT>\n « Example: CONNECT " + Program.address + ":" + Program.port);
						}
					}
					else
					{
						Console.ForegroundColor = ConsoleColor.DarkGray;
						Console.Write(" « ");
						Execute(message);
					}
					Console.ForegroundColor = ConsoleColor.Gray;
				}
			}
			Program.database.Disconnect();
		}
	}
}