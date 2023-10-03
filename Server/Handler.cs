using TTMC.Auram;
using TTMC.Debris;
using TTMC.Tools;
using System.Net.Sockets;
using System.Text;

namespace Listener
{
	internal class Handler : Handle
	{
		private Database database;
		public Handler(Database database)
		{
			this.database = database;
		}
		public override Packet? Message(Packet packet, NetworkStream stream)
		{
			switch (packet.id)
			{
				// Version
				case 0:
					Version? version = Program.version;
					return new Packet()
					{
						id = 0,
						data = version != null ? Encoding.UTF8.GetBytes(version.ToString()) : new byte[0]
					};
				// Get value
				case 1:
					string key1 = Encoding.UTF8.GetString(packet.data);
					byte[]? bytes = database.Get<byte[]>(key1);
					return new Packet()
					{
						id = 1,
						data = bytes ?? new byte[0]
					};
				// Set value
				case 2:
					List<byte> data = packet.data.ToList();
					string key2 = Engine.GetString(data.ToArray());
					data.RemoveRange(0, Engine.PrefixedString(key2).Length);
					string value = Encoding.UTF8.GetString(data.ToArray());
					database.Set(key2, value);
					break;
				// Add value
				case 3:
					List<byte> list = packet.data.ToList();
					string key3 = Engine.GetString(list.ToArray());
					list.RemoveRange(0, Engine.PrefixedString(key3).Length);
					string text = Encoding.UTF8.GetString(list.ToArray());
					bool addCheck = database.Add(key3, text);
					return new Packet()
					{
						id = 3,
						data = BitConverter.GetBytes(addCheck)
					};
				// Remove value
				case 4:
					string key4 = Encoding.UTF8.GetString(packet.data);
					bool removeCheck = database.Remove(key4);
					return new Packet()
					{
						id = 4,
						data = BitConverter.GetBytes(removeCheck)
					};
				// Keys list
				case 5:
					return new Packet()
					{
						id = 5,
						data = Engine.SerializeStringArray(database.keys)
					};
				// Save database
				case 6:
					string key6 = Encoding.UTF8.GetString(packet.data);
					database.Save(string.IsNullOrEmpty(key6) ? Program.path : key6);
					break;
				// Load database
				case 7:
					string key7 = Encoding.UTF8.GetString(packet.data);
					database.Load(string.IsNullOrEmpty(key7) ? Program.path : key7);
					break;
				case 8:
				// Clear database
					database.Clear();
					break;
				default:
					return null;
			}
			return null;
		}
	}
}