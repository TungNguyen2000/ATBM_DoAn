using Oracle.ManagedDataAccess.Client;
using System;
using SoftCircuits;
using System.Data;
using System.Windows.Forms;

namespace ATBM_GiaoDien
{
    public partial class LogIn : Form
    {
        public static DataGridViewRow chosenUser = Global.GetCurrentUser();

        public LogIn()
        {
            InitializeComponent();
            LogInButton.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool excep = false;
            string pass = passwordBox.Text.ToString();
            string name = UsernameBox.Text.ToString();
            using (OracleConnection conn = DBUtils.GetDBConnection(name, pass))
            {
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid Username or Password");
                    excep = true;
                }
                if (excep == false)
                {
                    OracleCommand cmd = new OracleCommand("SELECT SYS_CONTEXT('USERENV', 'ISDBA') FROM DUAL", conn);
                    OracleDataReader odr = cmd.ExecuteReader();
                    string check_sys = "";
                    while (odr.Read())
                        check_sys = odr.GetString(0);
                    if (check_sys != "TRUE")
                    {
                        conn.Close();
                        Global.SetCurrentUserName(name);
                        Global.SetCurrentPassword(pass);
                        var frm = new ActivePage();
                        frm.Location = this.Location;
                        frm.StartPosition = FormStartPosition.Manual;
                        frm.FormClosing += delegate { this.Show(); };
                        frm.Show();
                        this.Hide();
                    }
                    else
                    {
                        conn.Close();
                        Global.SetCurrentUserName(name);
                        Global.SetCurrentPassword(pass);
                        var frm = new Form1();
                        frm.Location = this.Location;
                        frm.StartPosition = FormStartPosition.Manual;
                        frm.FormClosing += delegate { this.Show(); };
                        frm.Show();
                        this.Hide();
                    }
                }
                //this.Hide();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (UsernameBox.Text.ToString().Length != 0 && passwordBox.Text.ToString().Length != 0)
            {
                LogInButton.Enabled = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void passwordBox_TextChanged(object sender, EventArgs e)
        {
            if (UsernameBox.Text.ToString().Length != 0 && passwordBox.Text.ToString().Length != 0)
            {
                LogInButton.Enabled = true;
            }
        }
    }
}
