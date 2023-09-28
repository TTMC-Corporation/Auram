using System.Net.Sockets;
using TTMC.Debris;

namespace TTMC.Auram
{
	internal class Handler : Handle
	{
		public Packet? packet = null;
		public override Packet? Message(Packet packet, NetworkStream stream)
		{
			this.packet = packet;
			return null;
		}
	}
}