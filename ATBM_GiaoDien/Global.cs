using System.Windows.Forms;

namespace ATBM_GiaoDien
{
    internal static class Global
    {
		private static DataGridViewRow currentUser = null;
		private static string username;
		private static string password;

		public static DataGridViewRow GetCurrentUser()
		{
			return currentUser;
		}

		public static void SetCurrentUser(DataGridViewRow value)
		{
			currentUser = value;
		}

		public static string GetCurrentUserName()
		{
			return username;
		}

		public static void SetCurrentUserName(string value)
		{
			username = value;
		}

		public static string GetCurrentPassword()
		{
			return password;
		}

		public static void SetCurrentPassword(string value)
		{
			password = value;
		}
	}
}
