using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
namespace ATBM_GiaoDien
{
    public partial class DialogCheckFGA : Form
    {
        public DialogCheckFGA(string policy_name)
        {
            InitializeComponent();
			label1.Text = policy_name;
			var policy_nameFGA = policy_name == "Theo dõi số lượng thuốc vượt quá 100" ? "TOO_MUCH_MEDICINE" : "UPDATE_HOSO_DICHVU";
			try
			{
				string currentusername = Global.GetCurrentUserName();
				string currentpass = Global.GetCurrentPassword();
				using (OracleConnection con = DBUtils.GetDBConnection(currentusername, currentpass))
				{
					OracleCommand cmd = new OracleCommand("SELECT * FROM DBA_FGA_AUDIT_TRAIL WHERE POLICY_NAME = '" + policy_nameFGA + "'", con);
					OracleDataAdapter oda = new OracleDataAdapter(cmd);
					con.Open();
					oda = new OracleDataAdapter(cmd);
					cmd.ExecuteNonQuery();
					con.Close();
					DataSet ds = new DataSet();
					oda.Fill(ds);
					if (ds.Tables.Count > 0)
					{
						CheckFGAGridView.DataSource = ds.Tables[0].DefaultView;
					}
				}
			}
			catch (Exception ee)
			{
				MessageBox.Show(ee.ToString(), "Lỗi", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

				throw;
			}

		}
	}
}
