using Oracle.ManagedDataAccess.Client;
using SoftCircuits;
using System;
using System.Data;
using System.Windows.Forms;

namespace ATBM
{
	public partial class Form1 : Form
	{
		public static DataGridViewRow chosenUser = Global.GetCurrentUser();

		private void LoadData()
		{
			using (OracleConnection con = DBUtils.GetDBConnection())

			{
				OracleCommand cmd = new OracleCommand("LIST_USERS", con)
				{
					CommandType = CommandType.StoredProcedure
				};
				cmd.Parameters.Add("SYS_REFCURSOR", OracleDbType.RefCursor, ParameterDirection.Output);
				con.Open();
				OracleDataAdapter oda = new OracleDataAdapter(cmd);
				cmd.ExecuteNonQuery();
				con.Close();
				DataSet ds = new DataSet();
				oda.Fill(ds);
				if (ds.Tables.Count > 0)
				{
					User_List.DataSource = ds.Tables[0].DefaultView;
				}

				cmd = new OracleCommand("SELECT * FROM DBA_ROLES", con);
				con.Open();
				oda = new OracleDataAdapter(cmd);
				cmd.ExecuteNonQuery();
				con.Close();
				ds = new DataSet();
				oda.Fill(ds);
				if (ds.Tables.Count > 0)
				{
					role_comboBox.DataSource = ds.Tables[0].DefaultView;
					role_comboBox.DisplayMember = "ROLE";
					role_comboBox.ValueMember = "ROLE_ID";
					role_comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
				}

				cmd = new OracleCommand("SELECT * FROM all_tables", con);
				con.Open();
				oda = new OracleDataAdapter(cmd);
				cmd.ExecuteNonQuery();
				con.Close();
				ds = new DataSet();
				oda.Fill(ds);
				if (ds.Tables.Count > 0)
				{
					Table_ComboBox.DataSource = ds.Tables[0].DefaultView;
					Table_ComboBox.DisplayMember = "TABLE_NAME";
					Table_ComboBox.ValueMember = "TABLE_NAME";
					Table_ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
				}
			}
		}

		public Form1()
		{
			InitializeComponent();
			LoadData();
			ComboboxItem item1 = new ComboboxItem();
			ComboboxItem item2 = new ComboboxItem();
			ComboboxItem item3 = new ComboboxItem();
			ComboboxItem item4 = new ComboboxItem();
			item1.Text = "SELECT";
			item1.Value = "SELECT";
			item2.Text = "UPDATE";
			item2.Value = "UPDATE";
			item3.Text = "INSERT";
			item3.Value = "INSERT";
			item4.Text = "DELETE";
			item4.Value = "DELETE";
			Priv_ComboBox.Items.Add(item1);
			Priv_ComboBox.Items.Add(item2);
			Priv_ComboBox.Items.Add(item3);
			Priv_ComboBox.Items.Add(item4);
			no_Grant_Option.Checked = true;
		}

		private void label1_Click(object sender, EventArgs e)
		{
		}

		private void Form1_Load(object sender, EventArgs e)
		{
		}

		private void label5_Click(object sender, EventArgs e)
		{
		}

		private void label4_Click(object sender, EventArgs e)
		{
		}

		private void User_List_SelectionChanged(object sender, EventArgs e)
		{
			if (User_List.CurrentCell != null)
			{
				DataGridViewRow selectedUser = User_List.Rows[User_List.CurrentCell.RowIndex];
				Global.SetCurrentUser(selectedUser);
				input_USERNAME.Text = selectedUser.Cells[0].Value.ToString();
				CREATE_LABEL.Text = selectedUser.Cells[2].Value.ToString();
				no_ExpirePass.Checked = true;
				no_LockAccount.Checked = true;
				yes_ExpirePass.Checked = false;
				yes_lockAccount.Checked = false;
				input_PASSWORD.Text = "";
				if (Global.GetCurrentUser() != null)
				{
					using (OracleConnection con = DBUtils.GetDBConnection())
					{
						try
						{
							OracleCommand cmd = con.CreateCommand();
							cmd.CommandText = "SELECT * FROM DBA_ROLE_PRIVS WHERE GRANTEE = '" + Global.GetCurrentUser().Cells[0].Value.ToString() + "'";
							cmd.CommandType = CommandType.Text;
							Console.WriteLine(cmd.CommandText.ToString());
							con.Open();
							OracleDataAdapter oda = new OracleDataAdapter(cmd);
							cmd.ExecuteNonQuery();
							con.Close();
							DataSet ds = new DataSet();
							oda.Fill(ds);
							if (ds.Tables.Count > 0)
							{
								User_Role.DataSource = ds.Tables[0].DefaultView;
								User_Role.DisplayMember = "GRANTED_ROLE";
								User_Role.ValueMember = "GRANTED_ROLE";
								User_Role.DropDownStyle = ComboBoxStyle.DropDownList;
							}
						}
						catch (Exception EX)
						{
							MessageBox.Show(EX.ToString(), "Lỗi", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
						}
					}
				}
			}
		}

		private void Alter_Click(object sender, EventArgs e)
		{
			using (OracleConnection con = DBUtils.GetDBConnection())
			{
				string pass = input_PASSWORD.Text.ToString() == "" ? "" : " identified by " + input_PASSWORD.Text.ToString();
				string lockString = yes_lockAccount.Checked ? " lock " : " unlock ";
				string passwordExpire = yes_ExpirePass.Checked ? " password expire " : "";
				string command = "alter user " + input_USERNAME.Text.ToString() + pass + " account " + lockString + passwordExpire;
				Console.WriteLine(command);

				OracleCommand cmd = new OracleCommand(command, con);
				try
				{
					con.Open();
					OracleDataAdapter oda = new OracleDataAdapter(cmd);
					cmd.ExecuteNonQuery();
					con.Close();
					alter_user_result.Text = "Thành công";
					MessageBox.Show("Chỉnh sửa user thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				catch (Exception EX)
				{
					MessageBox.Show(EX.ToString(), "Lỗi", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
				}
			}
		}

		private void Delete_Click(object sender, EventArgs e)
		{
			string selectedUser = Global.GetCurrentUser()?.Cells[0]?.Value?.ToString();
			using (OracleConnection con = DBUtils.GetDBConnection())
			{
				OracleCommand cmd = new OracleCommand("DROP_USER", con)
				{
					CommandType = CommandType.StoredProcedure
				};
				Console.WriteLine(selectedUser);
				cmd.Parameters.Add("USER_NAME", OracleDbType.Varchar2).Value = selectedUser;
				try
				{
					con.Open();
					OracleDataAdapter oda = new OracleDataAdapter(cmd);
					cmd.ExecuteNonQuery();
					con.Close();
					LoadData();
					MessageBox.Show("Xóa user thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				catch (Exception EX)
				{
					MessageBox.Show(EX.ToString(), "Lỗi", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
				}
			}
		}

		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		private void label8_Click(object sender, EventArgs e)
		{
		}

		private void Create_Click(object sender, EventArgs e)
		{
			string username = "";
			string password = "";
			if (CreateUserDialog.Show("Tạo mới user", "Nhập vào username", ref username
				) == DialogResult.OK)
			{
				if (CreateUserDialog.Show("Tạo mới user", "Nhập vào mật khẩu", ref password
			   ) == DialogResult.OK)
				{
					using (OracleConnection con = DBUtils.GetDBConnection())
					{
						string command1 = "create user " + username + " identified by \"" + password + "\" default tablespace system";
						string command2 = "grant resource, connect to " + username;
						string command3 = "GRANT ALTER SESSION, CREATE ANY TABLE, CREATE CLUSTER, CREATE DATABASE LINK, CREATE MATERIALIZED VIEW, CREATE SYNONYM, CREATE TABLE, CREATE VIEW, CREATE SESSION, UNLIMITED TABLESPACE TO " + username;
						try
						{
							OracleCommand cmd1 = new OracleCommand(command1, con);
							OracleCommand cmd2 = new OracleCommand(command2, con);
							OracleCommand cmd3 = new OracleCommand(command3, con);
							con.Open();
							cmd1.ExecuteNonQuery();
							cmd2.ExecuteNonQuery();
							cmd3.ExecuteNonQuery();
							con.Close();
							LoadData();
							MessageBox.Show("Tạo mới user thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
						}
						catch (Exception EX)
						{
							MessageBox.Show(EX.ToString(), "Lỗi", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
						}
					}
				}
			}
		}

		private void no_LockAccount_CheckedChanged(object sender, EventArgs e)
		{
			yes_lockAccount.Checked = !no_LockAccount.Checked;
		}

		private void no_ExpirePass_CheckedChanged(object sender, EventArgs e)
		{
			yes_ExpirePass.Checked = !no_ExpirePass.Checked;
		}

		private void yes_lockAccount_CheckedChanged(object sender, EventArgs e)
		{
			no_LockAccount.Checked = !yes_lockAccount.Checked;
		}

		private void yes_ExpirePass_CheckedChanged(object sender, EventArgs e)
		{
			no_ExpirePass.Checked = !yes_ExpirePass.Checked;
		}

		private void groupBox2_Enter(object sender, EventArgs e)
		{
		}

		private void label8_Click_1(object sender, EventArgs e)
		{
		}

		private void Set_Role_Click(object sender, EventArgs e)
		{
			string username = Global.GetCurrentUser() != null ? Global.GetCurrentUser().Cells[0].Value.ToString() : "";
			try
			{
				using (OracleConnection con = DBUtils.GetDBConnection())
				{
					string command = "GRANT " + role_comboBox.Text.ToString() + " TO " + username;
					OracleCommand cmd = new OracleCommand("GRANT " + role_comboBox.Text.ToString() + " TO " + username, con);
					con.Open();
					cmd.ExecuteNonQuery();
					con.Close();
					LoadData();
					MessageBox.Show("Đặt role cho user thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			catch (Exception Exc)
			{
				MessageBox.Show(Exc.ToString(), "Lỗi", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
				throw;
			}
		}

		private void Add_Role_Click(object sender, EventArgs e)
		{
			string rolename = "";
			string password = "";
			if (CreateUserDialog.Show("Tạo mới role", "Nhập vào rolename", ref rolename
				) == DialogResult.OK)
			{
				if (CreateUserDialog.Show("Tạo mới role", "Nhập vào mật khẩu", ref password
			   ) == DialogResult.OK)
				{
					using (OracleConnection con = DBUtils.GetDBConnection())
					{
						string alterPassword = password == "" ? "" : " identified by " + "\"" + password + "\"";
						Console.WriteLine(alterPassword);
						string command1 = "CREATE ROLE " + rolename + alterPassword;
						Console.WriteLine(command1);

						try
						{
							OracleCommand cmd1 = new OracleCommand(command1, con);
							con.Open();
							cmd1.ExecuteNonQuery();
							con.Close();
							LoadData();
							MessageBox.Show("Tạo mới role thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
						}
						catch (Exception EX)
						{
							MessageBox.Show(EX.ToString(), "Lỗi", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
						}
					}
				}
			}
		}

		private void Alter_Role_Click(object sender, EventArgs e)
		{
		}

		private void Delete_Role_Click(object sender, EventArgs e)
		{
			string rolename = "";
			if (CreateUserDialog.Show("Xóa role", "Nhập vào rolename", ref rolename
				) == DialogResult.OK)
			{
				using (OracleConnection con = DBUtils.GetDBConnection())
				{
					try
					{
						OracleCommand cmd1 = new OracleCommand("drop role " + rolename, con);
						con.Open();
						cmd1.ExecuteNonQuery();
						con.Close();
						LoadData();
						MessageBox.Show("Xóa role thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					catch (Exception EX)
					{
						MessageBox.Show(EX.ToString(), "Lỗi", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
					}
				}
			}
		}

		private void groupBox2_Enter_1(object sender, EventArgs e)
		{
		}

		private void no_Grant_Option_CheckedChanged(object sender, EventArgs e)
		{
			yes_Grant_Option.Checked = !no_Grant_Option.Checked;
		}

		private void yes_Grant_Option_CheckedChanged(object sender, EventArgs e)
		{
			no_Grant_Option.Checked = !yes_Grant_Option.Checked;
		}

		private void Priv_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (Priv_ComboBox.Text == "SELECT" || Priv_ComboBox.Text == "UPDATE")
			{
				Column_ComboBox.Text = "";
				Column_ComboBox.Enabled = false;
			}
			else
			{
				Column_ComboBox.Enabled = true;
			}
		}

		private void Priv_To_User_Click(object sender, EventArgs e)
		{
			try
			{
				using (OracleConnection con = DBUtils.GetDBConnection())
				{
					OracleCommand cmd = new OracleCommand("GRANT_PRIV_TO", con)
					{
						CommandType = CommandType.StoredProcedure
					};
					DataGridViewRow selected = Global.GetCurrentUser();
					if (selected == null)
					{
						return;
					}
					cmd.Parameters.Add("USENAME", OracleDbType.NVarchar2).Value = selected.Cells[0].Value.ToString();
					cmd.Parameters.Add("PRIV", OracleDbType.NVarchar2).Value = Priv_ComboBox.Text.ToString();
					cmd.Parameters.Add("TABLENAME", OracleDbType.NVarchar2).Value = Table_ComboBox.Text.ToString();
					cmd.Parameters.Add("CO", OracleDbType.NVarchar2).Value = Column_ComboBox.Text.ToString() == "" ? null : Column_ComboBox.Text.ToString();
					cmd.Parameters.Add("GOPTION", OracleDbType.Int16).Value = yes_Grant_Option.Checked ? 1 : 0;
					con.Open();
					cmd.ExecuteNonQuery();
					con.Close();

					MessageBox.Show("Cấp quyền thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
			}
		}

		private void Table_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			using (OracleConnection con = DBUtils.GetDBConnection())
			{
				OracleCommand cmd = new OracleCommand("SELECT * FROM all_tab_columns where table_name='" + Table_ComboBox.Text + "'", con);
				con.Open();
				OracleDataAdapter oda = new OracleDataAdapter(cmd);
				cmd.ExecuteNonQuery();
				con.Close();
				DataSet ds = new DataSet();
				oda.Fill(ds);
				if (ds.Tables.Count > 0)
				{
					Column_ComboBox.DataSource = ds.Tables[0].DefaultView;
					Column_ComboBox.DisplayMember = "COLUMN_NAME";
					Column_ComboBox.ValueMember = "COLUMN_NAME";
					Column_ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
				}
			}
		}

		private void Revoke_Priv_Click(object sender, EventArgs e)
		{
			try
			{
				using (OracleConnection con = DBUtils.GetDBConnection())
				{
					OracleCommand cmd = new OracleCommand("PR_REVOKE", con)
					{
						CommandType = CommandType.StoredProcedure
					};
					DataGridViewRow selected = Global.GetCurrentUser();
					if (selected == null)
					{
						return;
					}
					cmd.Parameters.Add("USERNAME", OracleDbType.NVarchar2).Value = selected.Cells[0].Value.ToString();
					cmd.Parameters.Add("PRIV", OracleDbType.NVarchar2).Value = Priv_ComboBox.Text.ToString();
					cmd.Parameters.Add("TABLENAME", OracleDbType.NVarchar2).Value = Table_ComboBox.Text.ToString();
					con.Open();
					cmd.ExecuteNonQuery();
					con.Close();
					MessageBox.Show("Hủy quyền thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
			}
		}

		private void View_User_Priv_Click(object sender, EventArgs e)
		{
			Dialog dialog = new Dialog("phanquyen");
			dialog.Show();
		}

		private void View_User_Role_Click(object sender, EventArgs e)
		{
			Dialog dialog = new Dialog("role");
			dialog.Show();
		}

		private void User_Role_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				using (OracleConnection con = DBUtils.GetDBConnection())
				{
					OracleCommand cmd = new OracleCommand("REVOKE " + User_Role.Text.ToString() + " from " + input_USERNAME.Text, con);
					con.Open();
					cmd.ExecuteNonQuery();
					con.Close();
					MessageBox.Show("Hủy role thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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