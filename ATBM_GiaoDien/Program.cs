using Oracle.ManagedDataAccess.Client;
using System;
using System.Windows.Forms;

namespace ATBM_GiaoDien
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            OracleConnection conn = DBUtils.GetDBConnection("SYS", "110");
            try { conn.Open(); }
            catch (Exception e)
            { Console.WriteLine("Getting Connection ..."); };
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LogIn());
        }
    }
}
