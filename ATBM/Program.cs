using Oracle.ManagedDataAccess.Client;
using System;
using System.Windows.Forms;

namespace ATBM
{
	internal static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		private static void Main()
		{
			Console.WriteLine("Getting Connection ...");
			OracleConnection conn = DBUtils.GetDBConnection();

			try
			{
				Console.WriteLine("Openning Connection ...");

				conn.Open();

				Console.WriteLine("Connection successful!");
			}
			catch (Exception e)
			{
				Console.WriteLine("Error: " + e.Message);
			}

			Console.Read();
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
		}
	}
}