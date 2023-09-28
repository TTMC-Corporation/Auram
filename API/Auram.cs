using System.Text;
using TTMC.Debris;
using TTMC.Tools;

namespace TTMC.Auram
{
	public class Database
	{
		private string? thePath = null;
		private Client? client = null;
		private Handler? handler = null;
		private FileStream? stream = null;
		private Dictionary<string, Value> data = new();
		private Dictionary<string, byte[]> newData = new();
		public Database(string? path = null)
		{
			if (!string.IsNullOrEmpty(path))
			{
				Load(path);
			}
		}
		public string[] keys
		{
			get
			{
				if (client != null && handler != null)
				{
					Packet packet = new()
					{
						id = 5,
						data = new byte[0]
					};
					Packet? resp = SendPacket(packet);
					if (resp != null)
					{
						return Engine.DeserializeStringArray(resp.data);
					}
				}
				else
				{
					List<string> all = new();
					all.AddRange(data.Keys);
					all.AddRange(newData.Keys);
					return all.ToArray();
				}
				return new string[0];
			}
		}
		private Packet? SendPacket(Packet packet)
		{
			if (client != null && handler != null)
			{
				client.SendPacket(packet);
				while (handler.packet == null) { Thread.Sleep(10); }
				Packet resp = handler.packet;
				handler.packet = null;
				return resp;
			}
			return null;
		}
		public bool Add(string key, byte[] value)
		{
			if (client != null && handler != null)
			{
				Packet packet = new()
				{
					id = 3,
					data = Engine.Combine(Engine.PrefixedString(key), value)
				};
				Packet? resp = SendPacket(packet);
				if (resp != null)
				{
					return BitConverter.ToBoolean(resp.data);
				}
			}
			else
			{
				return newData.TryAdd(key, value);
			}
			return false;
		}
		public bool Add(string key, string value)
		{
			return Add(key, Encoding.UTF8.GetBytes(value));
		}
		public bool Add(string key, int value)
		{
			return Add(key, BitConverter.GetBytes(value));
		}
		public bool Add(string key, uint value)
		{
			return Add(key, BitConverter.GetBytes(value));
		}
		public bool Add(string key, short value)
		{
			return Add(key, BitConverter.GetBytes(value));
		}
		public bool Add(string key, ushort value)
		{
			return Add(key, BitConverter.GetBytes(value));
		}
		public bool Add(string key, long value)
		{
			return Add(key, BitConverter.GetBytes(value));
		}
		public bool Add(string key, ulong value)
		{
			return Add(key, BitConverter.GetBytes(value));
		}
		public bool Add(string key, Guid value)
		{
			return Add(key, value.ToByteArray());
		}
		public bool Add(string key, DateTime value)
		{
			return Add(key, value.ToBinary());
		}
		public void Set(string key, byte[] value)
		{
			if (client != null && handler != null)
			{
				Packet packet = new()
				{
					id = 2,
					data = Engine.Combine(Engine.PrefixedString(key), value)
				};
				client.SendPacket(packet);
			}
			else
			{
				newData[key] = value;
			}
		}
		public void Set(string key, string value)
		{
			Set(key, Encoding.UTF8.GetBytes(value));
		}
		public void Set(string key, int value)
		{
			Set(key, BitConverter.GetBytes(value));
		}
		public void Set(string key, uint value)
		{
			Set(key, BitConverter.GetBytes(value));
		}
		public void Set(string key, short value)
		{
			Set(key, BitConverter.GetBytes(value));
		}
		public void Set(string key, ushort value)
		{
			Set(key, BitConverter.GetBytes(value));
		}
		public void Set(string key, long value)
		{
			Set(key, BitConverter.GetBytes(value));
		}
		public void Set(string key, ulong value)
		{
			Set(key, BitConverter.GetBytes(value));
		}
		public void Set(string key, Guid value)
		{
			Set(key, value.ToByteArray());
		}
		public void Set(string key, DateTime value)
		{
			Set(key, value.ToBinary());
		}
		public byte[] Get(string key)
		{
			if (client != null && handler != null)
			{
				Packet packet = new()
				{
					id = 1,
					data = Encoding.UTF8.GetBytes(key)
				};
				Packet? resp = SendPacket(packet);
				if (resp != null)
				{
					return resp.data;
				}
			}
			else
			{
				if (newData.ContainsKey(key))
				{
					return newData[key];
				}
				if (stream != null && data.ContainsKey(key))
				{
					Value value = data[key];
					stream.Position = value.start;
					byte[] bytes = new byte[value.offset];
					stream.Read(bytes, 0, value.offset);
					return bytes;
				}
			}
			return new byte[0];
		}
		public T? Get<T>(string key)
		{
			if (typeof(T) == typeof(byte[]))
			{
				return (T)(object)Get(key);
			}
			if (typeof(T) == typeof(string))
			{
				return (T)(object)Encoding.UTF8.GetString(Get(key));
			}
			if (typeof(T) == typeof(int))
			{
				return (T)(object)BitConverter.ToInt32(Get(key));
			}
			if (typeof(T) == typeof(uint))
			{
				return (T)(object)BitConverter.ToUInt32(Get(key));
			}
			if (typeof(T) == typeof(short))
			{
				return (T)(object)BitConverter.ToInt16(Get(key));
			}
			if (typeof(T) == typeof(ushort))
			{
				return (T)(object)BitConverter.ToUInt16(Get(key));
			}
			if (typeof(T) == typeof(long))
			{
				return (T)(object)BitConverter.ToInt64(Get(key));
			}
			if (typeof(T) == typeof(ulong))
			{
				return (T)(object)BitConverter.ToUInt64(Get(key));
			}
			if (typeof(T) == typeof(Guid))
			{
				return (T)(object)new Guid(Get(key));
			}
			if (typeof(T) == typeof(DateTime))
			{
				return (T)(object)DateTime.FromBinary(BitConverter.ToInt64(Get(key)));
			}
			return default(T);
		}
		public bool Remove(string key)
		{
			if (client != null && handler != null)
			{
				Packet packet = new()
				{
					id = 4,
					data = Encoding.UTF8.GetBytes(key)
				};
				Packet? resp = SendPacket(packet);
				if (resp != null)
				{
					return BitConverter.ToBoolean(resp.data);
				}
			}
			else
			{
				return data.Remove(key) || newData.Remove(key);
			}
			return false;
		}
		public void Clear()
		{
			data.Clear();
			newData.Clear();
		}
		public void Save(string path)
		{
			if (client != null && handler != null)
			{
				Packet packet = new()
				{
					id = 6,
					data = Encoding.UTF8.GetBytes(path)
				};
				client.SendPacket(packet);
			}
			else
			{
				Stream fileStream = path == thePath && stream != null ? stream : File.Open(path, FileMode.OpenOrCreate);
				foreach (string key in data.Keys)
				{
					if (!newData.ContainsKey(key))
					{
						newData[key] = Get(key);
					}
				}
				List<byte> tree = new();
				List<byte> bytes = new();
				foreach (KeyValuePair<string, byte[]> temp in newData)
				{
					tree.AddRange(Engine.Combine(Encoding.UTF8.GetBytes(temp.Key), new byte[1]));
					tree.AddRange(BitConverter.GetBytes(12 + bytes.Count));
					tree.AddRange(BitConverter.GetBytes(temp.Value.Length));
					bytes.AddRange(temp.Value);
				}
				fileStream.Position = 0;
				fileStream.Write(Encoding.UTF8.GetBytes(Core.codename));
				fileStream.Write(BitConverter.GetBytes(newData.Count));
				fileStream.Write(BitConverter.GetBytes(12 + bytes.Count()));
				fileStream.Write(bytes.ToArray());
				fileStream.Write(tree.ToArray());
				fileStream.SetLength(12 + bytes.Count + tree.Count);
				fileStream.Close();
				thePath = path;
				stream = File.Open(path, FileMode.OpenOrCreate);
			}
		}
		public void Connect(string ip = "127.0.0.1", ushort port = 13000)
		{
			handler = new();
			client = new(ip, port, handler);
		}
		public bool Disconnect()
		{
			if (client != null)
			{
				handler = null;
				client.Disconnect();
				client = null;
				return true;
			}
			return false;
		}
		public void Load(string path)
		{
			if (client != null && handler != null)
			{
				Packet packet = new()
				{
					id = 7,
					data = Encoding.UTF8.GetBytes(path)
				};
				client.SendPacket(packet);
			}
			else
			{
				thePath = path;
				stream = File.Open(path, FileMode.OpenOrCreate);
				byte[] codename = new byte[4];
				stream.Read(codename, 0, 4);
				if (Encoding.UTF8.GetString(codename) != Core.codename)
				{
					throw new("Old version detected");
				}
				byte[] keysCountRaw = new byte[4];
				stream.Read(keysCountRaw, 0, 4);
				int keysCount = BitConverter.ToInt32(keysCountRaw);
				byte[] keysOffsetRaw = new byte[4];
				stream.Read(keysOffsetRaw, 0, 4);
				int keysOffset = BitConverter.ToInt32(keysOffsetRaw);
				stream.Position = keysOffset;
				for (int i = 0; i < keysCount; i++)
				{
					List<byte> list = new();
					while (true)
					{
						int x = stream.ReadByte();
						if (x == 0)
						{
							break;
						}
						list.Add((byte)x);
					}
					string name = Encoding.UTF8.GetString(list.ToArray());
					byte[] startRaw = new byte[4];
					stream.Read(startRaw, 0, 4);
					int start = BitConverter.ToInt32(startRaw);
					byte[] offsetRaw = new byte[4];
					stream.Read(offsetRaw, 0, 4);
					int offset = BitConverter.ToInt32(offsetRaw);
					Value value = new(start, offset);
					data[name] = value;
				}
			}
		}
	}
	public class Value
	{
		public int start { get; set; }
		public int offset { get; set; }
		public Value(int start, int offset)
		{
			this.start = start;
			this.offset = offset;
		}
	}
}