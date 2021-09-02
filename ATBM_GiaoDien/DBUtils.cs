using Oracle.ManagedDataAccess.Client;

namespace ATBM_GiaoDien
{
	internal class DBUtils
	{
		public static OracleConnection GetDBConnection(string username_use, string pass)
		{
			string[] datasource = { "localhost", "1521" };
			string database = "XEPDB1";
			string username = username_use;
			string password = pass;
			return DBSQLServerUtils.GetOracleConnection(datasource, database, username, password);
		}
		public static OracleConnection GetCDBConnection()
		{
			string adminTNS = "TNS_ADMIN = C:/Users/weare/Oracle/network/admin";
			string[] datasource = { "localhost", "1521" };
			string database = "XE";
			string username = "SYSTEM";
			string password = "12122000";
			return DBSQLServerUtils.GetRootConnection(adminTNS, datasource, username, password, database);
		}
	}
}