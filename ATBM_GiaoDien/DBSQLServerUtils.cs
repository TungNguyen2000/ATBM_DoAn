using Oracle.ManagedDataAccess.Client;
using System;
using System.Windows.Forms;

namespace ATBM_GiaoDien
{
	internal class DBSQLServerUtils
	{
		public static OracleConnection GetOracleConnection(string[] datasource, string database, string username, string password)
		{
			try
			{
				string ConString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=" + datasource[0] + ")(PORT=" + datasource[1] + ")))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=" + database + ")));User Id=" + username + ";Password=" + password + ";";
				if (username == "SYS") 
					ConString = ConString + "DBA Privilege=SYSDBA;";

				OracleConnection con = new OracleConnection(ConString);
				return con;
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.ToString());
			}
			return null;
		}
		public static OracleConnection GetRootConnection(string adminTNS, string[] dataSource, string username, string password, string database)
		{
			try
			{
				string ConString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=" + dataSource[0] + ")(PORT=" + dataSource[1] + ")))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=" + database + ")));User Id=" + username + ";Password=" + password + ";";

				//string ConString = adminTNS + ";USER ID=" + username + ";PASSWORD = " + password +" DATA SOURCE=" + dataSource[0] + ":" + dataSource[1] + "/" + database + ";PERSIST SECURITY INFO=True";
				OracleConnection con = new OracleConnection(ConString);
				return con;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
			return null;
		}
	}
}