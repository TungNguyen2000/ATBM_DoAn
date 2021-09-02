using Oracle.ManagedDataAccess.Client;

namespace ATBM
{
	internal class DBUtils
	{
		public static OracleConnection GetDBConnection()
		{
			string[] datasource = { "localhost", "1521" };
			string database = "PDB1";
			string username = "SYS";
			string password = "12122000";
			return DBSQLServerUtils.GetOracleConnection(datasource, database, username, password);
		}
	}
}