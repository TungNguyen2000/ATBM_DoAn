using Oracle.ManagedDataAccess.Client;
using System;
using System.Windows;

namespace ATBM
{
	internal class DBSQLServerUtils
	{
		public static OracleConnection GetOracleConnection(string[] datasource, string database, string username, string password)
		{
			try
			{
				string ConString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=" + datasource[0] + ")(PORT=" + datasource[1] + ")))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=" + database + ")));User Id=" + username + ";Password=" + password + ";" + "DBA Privilege=SYSDBA;";

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