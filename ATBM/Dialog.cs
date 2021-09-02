using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Windows.Forms;

namespace ATBM
{
	public partial class Dialog : Form
	{
		public void getPhanQuyen()
		{
			using (OracleConnection con = DBUtils.GetDBConnection())
			{
				OracleCommand cmd = new OracleCommand("PR_SelectPrivsOfUser", con)
				{
					CommandType = CommandType.StoredProcedure
				};
				DataGridViewRow selected = Global.GetCurrentUser();
				if (selected == null)
				{
					return;
				}
				user_name.Text = selected.Cells[0].Value.ToString();
				cmd.Parameters.Add("USERNAME", OracleDbType.Varchar2).Value = user_name.Text.ToString();
				cmd.Parameters.Add("SYS_REFCURSOR", OracleDbType.RefCursor, ParameterDirection.Output);
				con.Open();
				OracleDataAdapter oda = new OracleDataAdapter(cmd);
				cmd.ExecuteNonQuery();
				con.Close();
				DataSet ds = new DataSet();
				oda.Fill(ds);
				if (ds.Tables.Count > 0)
				{
					dataGridView1.DataSource = ds.Tables[0].DefaultView;
				}
			}
		}

		public void getRole()
		{
			using (OracleConnection con = DBUtils.GetDBConnection())
			{
				DataGridViewRow selected = Global.GetCurrentUser();
				OracleCommand cmd = new OracleCommand("SELECT * FROM DBA_ROLE_PRIVS WHERE GRANTEE = '" + selected.Cells[0].Value.ToString() + "'", con)
				{
					CommandType = CommandType.Text
				};
				if (Global.GetCurrentUser() == null)
				{
					return;
				}
				user_name.Text = Global.GetCurrentUser().Cells[0].Value.ToString();
				con.Open();
				OracleDataAdapter oda = new OracleDataAdapter(cmd);
				cmd.ExecuteNonQuery();
				con.Close();
				DataSet ds = new DataSet();
				oda.Fill(ds);
				if (ds.Tables.Count > 0)
				{
					dataGridView1.DataSource = ds.Tables[0].DefaultView;
				}
			}
		}

		public Dialog(string type)
		{
			InitializeComponent();
			if (type == "role")
			{
				getRole();
			}

			if (type == "phanquyen")
			{
				getPhanQuyen();
			}
		}
	}
}