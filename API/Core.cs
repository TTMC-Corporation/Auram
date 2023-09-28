using System.Text;
using TTMC.Tools;

namespace TTMC.Auram
{
	internal class Core
	{
		internal static string codename = "AUR3";
		public static string GetKey(byte[] data)
		{
			int length = VarintBitConverter.ToInt32(data);
			byte[] lengthx = VarintBitConverter.GetVarintBytes(length);
			return Encoding.UTF8.GetString(data, lengthx.Length, length);
		}
		public static byte[] PrefixedKey(string text)
		{
			byte[] data = Encoding.UTF8.GetBytes(text);
			return Engine.Combine(VarintBitConverter.GetVarintBytes(data.Length), data);
		}
		public static byte[] GetValue(byte[] value)
		{
			List<byte> bytes = value.ToList();
			int length = VarintBitConverter.ToInt32(value);
			byte[] lengthx = VarintBitConverter.GetVarintBytes(length);
			return bytes.GetRange(lengthx.Length, length).ToArray();
		}
		public static byte[] PrefixedValue(byte[] value)
		{
			return Engine.Combine(VarintBitConverter.GetVarintBytes(value.Length), value);
		}
	}
}