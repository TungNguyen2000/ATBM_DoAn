using System.Windows.Forms;

namespace ATBM
{
	internal static class Global
	{
		private static DataGridViewRow currentUser = null;

		public static DataGridViewRow GetCurrentUser()
		{
			return currentUser;
		}

		public static void SetCurrentUser(DataGridViewRow value)
		{
			currentUser = value;
		}
	}
}