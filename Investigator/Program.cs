using System;
using System.Windows.Forms;

namespace Investigator
{
	internal static class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			ApplicationConfiguration.Initialize();
			Application.Run(new Base(args.Length > 0 ? args[0] : null));
		}
	}
}