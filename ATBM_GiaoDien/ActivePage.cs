using Oracle.ManagedDataAccess.Client;
using SoftCircuits;
using System;
using System.Data;
using System.Windows.Forms;

namespace ATBM_GiaoDien
{
    public partial class ActivePage : Form
    {
        public static DataGridViewRow chosenUser = Global.GetCurrentUser();

        private void Load_Data()
        {
            string username = Global.GetCurrentUserName();
            string pass = Global.GetCurrentPassword();
            using (OracleConnection con = DBUtils.GetDBConnection(username, pass))
            {
                con.Open();
                OracleCommand cmd = new OracleCommand("SELECT * FROM HOSPITAL_MANAGE.CHAMCONG", con);

                OracleDataAdapter oda = new OracleDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                con.Close();
                DataSet ds = new DataSet();
                oda.Fill(ds);
                if (ds.Tables.Count > 0)
                {
                    ChamCongGridView.DataSource = ds.Tables[0].DefaultView;
                }
            }

            using (OracleConnection con = DBUtils.GetDBConnection(username, pass))
            {
                con.Open();
                OracleCommand cmd = new OracleCommand("SELECT SYS_CONTEXT('EMPLOYEE_CTX', 'JOB_ROLE') FROM DUAL", con);
                OracleDataReader reader = cmd.ExecuteReader();

                string job_role = "";

                try
                {
                    while (reader.Read())
                        job_role = reader.GetString(0);
                }
                catch (Exception ex) { job_role = " "; };
                
                if (job_role == "NV bán thu?c")
                {
                    cmd = new OracleCommand("SELECT * FROM HOSPITAL_MANAGE.BANTHUOC_CTDONTHUOC", con);
                    OracleDataAdapter oda = new OracleDataAdapter(cmd);
                    cmd.ExecuteNonQuery();
                    DataSet ds = new DataSet();
                    oda.Fill(ds);
                    if (ds.Tables.Count > 0)
                    {
                        ListBenhNhan.DataSource = ds.Tables[0].DefaultView;
                    }
                }
                else if (job_role == "?i?u ph?i")
                {
                    cmd = new OracleCommand("SELECT * FROM HOSPITAL_MANAGE.BENHNHAN", con);
                    OracleDataAdapter oda = new OracleDataAdapter(cmd);
                    cmd.ExecuteNonQuery();
                    DataSet ds = new DataSet();
                    oda.Fill(ds);
                    if (ds.Tables.Count > 0)
                    {
                        ListBenhNhan.DataSource = ds.Tables[0].DefaultView;
                    }
                }
                else if (job_role == "NV tài v?")
                {
                    cmd = new OracleCommand("SELECT * FROM HOSPITAL_MANAGE.TAIVU_DICHVU", con);
                    OracleDataAdapter oda = new OracleDataAdapter(cmd);
                    cmd.ExecuteNonQuery();
                    DataSet ds = new DataSet();
                    oda.Fill(ds);
                    if (ds.Tables.Count > 0)
                    {
                        ListBenhNhan.DataSource = ds.Tables[0].DefaultView;
                    }
                }
                else if (username == "SYS")
                {
                    cmd = new OracleCommand("SELECT * FROM HOSPITAL_MANAGE.BENHNHAN", con);
                    OracleDataAdapter oda = new OracleDataAdapter(cmd);
                    cmd.ExecuteNonQuery();
                    DataSet ds = new DataSet();
                    oda.Fill(ds);
                    if (ds.Tables.Count > 0)
                    {
                        ListBenhNhan.DataSource = ds.Tables[0].DefaultView;
                    }
                }
                else if (job_role == "Bác s?")
                {
                    cmd = new OracleCommand("SELECT * FROM HOSPITAL_MANAGE.BACSI_BENHNHAN", con);
                    OracleDataAdapter oda = new OracleDataAdapter(cmd);
                    cmd.ExecuteNonQuery();
                    DataSet ds = new DataSet();
                    oda.Fill(ds);
                    if (ds.Tables.Count > 0)
                    {
                        ListBenhNhan.DataSource = ds.Tables[0].DefaultView;
                    }
                }

               

                if (job_role == "?i?u ph?i")
                {
                    cmd = new OracleCommand("SELECT * FROM HOSPITAL_MANAGE.HOSO_DICHVU", con);
                    OracleDataAdapter oda = new OracleDataAdapter(cmd);
                    cmd.ExecuteNonQuery();
                    DataSet ds = new DataSet();
                    oda.Fill(ds);
                    if (ds.Tables.Count > 0)
                    {
                        DieuPhoiBNView.DataSource = ds.Tables[0].DefaultView;
                    }
                }
                else if (job_role == "Bác s?")
                {
                    cmd = new OracleCommand("SELECT * FROM HOSPITAL_MANAGE.BACSI_BENHNHAN", con);
                    OracleDataAdapter oda = new OracleDataAdapter(cmd);
                    cmd.ExecuteNonQuery();
                    DataSet ds = new DataSet();
                    oda.Fill(ds);
                    if (ds.Tables.Count > 0)
                    {
                        SearchBN.DataSource = ds.Tables[0].DefaultView;
                    }
                }
                else if (job_role == "NV K? toán")
                {
                    cmd = new OracleCommand("select * from hospital_manage.luong_nv_ketoan", con);
                    OracleDataAdapter oda = new OracleDataAdapter(cmd);
                    cmd.ExecuteNonQuery();
                    DataSet ds = new DataSet();
                    oda.Fill(ds);
                    if (ds.Tables.Count > 0)
                    {
                        nhanvienketoan_gridview.DataSource = ds.Tables[0].DefaultView;
                    }
                }

                con.Close();
            }
        }



        private void Tab_control()
        {
            string username = Global.GetCurrentUserName();
            string pass = Global.GetCurrentPassword();
            using (OracleConnection con = DBUtils.GetDBConnection(username, pass))
            {
                con.Open();
                OracleCommand cmd = new OracleCommand("SELECT SYS_CONTEXT('EMPLOYEE_CTX', 'JOB_ROLE') FROM DUAL", con);
                OracleDataReader reader = cmd.ExecuteReader();

                string job_role = "";
                // giấu tab Benh nhan đi nếu người dùng không phải là bán thuốc, tài vụ, điều phối, bác sĩ, sys
                try
                {
                    while (reader.Read())
                        job_role = reader.GetString(0);
                }
                catch (Exception ex) { job_role = " "; };

                if (job_role != "NV bán thu?c" && job_role != "?i?u ph?i" && job_role != "NV tài v?" && username != "SYS" && job_role != "Bác s?")
                {
                    add.TabPages.Remove(tabPage2);
                }
                // giấu tab Điều phối nếu không phải Tiếp viên

                if (job_role != "?i?u ph?i")
                {
                    add.TabPages.Remove(tabPage3);
                    TiepTanBenhNhan.Visible = false;
                }
                else
                {
                    cmd = new OracleCommand("SELECT MABN, HOTEN FROM HOSPITAL_MANAGE.benhnhan", con);
                    OracleDataAdapter oda = new OracleDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    oda.Fill(ds);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ComboboxItem item = new ComboboxItem();
                        item.Text = ds.Tables[0].Rows[i][1].ToString();
                        item.Value = ds.Tables[0].Rows[i][0].ToString();
                        HSBN_MABN.Items.Add(item);
                    }

                    cmd = new OracleCommand("SELECT manv, hoten FROM HOSPITAL_MANAGE.list_doctor", con);
                    oda = new OracleDataAdapter(cmd);
                    ds = new DataSet();
                    oda.Fill(ds);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ComboboxItem item = new ComboboxItem();
                        item.Text = ds.Tables[0].Rows[i][1].ToString();
                        item.Value = ds.Tables[0].Rows[i][0].ToString();
                        combobox_bs_dieuphoi.Items.Add(item);
                        combo_BS_HSBN.Items.Add(item);
                    }

                    cmd = new OracleCommand("SELECT makb FROM HOSPITAL_MANAGE.hoso_dichvu", con);
                    oda = new OracleDataAdapter(cmd);
                    ds = new DataSet();
                    oda.Fill(ds);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                       
                        dieuphoi_makb.Items.Add(ds.Tables[0].Rows[i][0]);
                    }

                    cmd = new OracleCommand("SELECT madv, tendv FROM HOSPITAL_MANAGE.dichvu", con);
                    oda = new OracleDataAdapter(cmd);
                    ds = new DataSet();
                    oda.Fill(ds);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ComboboxItem item = new ComboboxItem();
                        item.Text = ds.Tables[0].Rows[i][1].ToString();
                        item.Value = ds.Tables[0].Rows[i][0].ToString();
                        combobox_dvu_dieuphoi.Items.Add(item);
                    }
                }
                // giấu tab điều trị nếu không phải là Bác sĩ
                //hiển thị combobox và mà thuốc
                if (job_role != "Bác s?")
                {
                    add.TabPages.Remove(tabPage4);
                }
                else
                {
                    cmd = new OracleCommand("SELECT MATHUOC, TENTH FROM HOSPITAL_MANAGE.THUOC", con);
                    OracleDataAdapter oda = new OracleDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    oda.Fill(ds);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ComboboxItem item = new ComboboxItem();
                        item.Text = ds.Tables[0].Rows[i][1].ToString();
                        item.Value = ds.Tables[0].Rows[i][0].ToString();
                        thuoc_BN.Items.Add(item);
                    }

                    cmd = new OracleCommand("SELECT DISTINCT(MAKB) FROM HOSPITAL_MANAGE.BACSI_BENHNHAN", con);
                    oda = new OracleDataAdapter(cmd);
                    ds = new DataSet();
                    oda.Fill(ds);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        makb_BS.Items.Add(ds.Tables[0].Rows[i][0].ToString());
                        MAKB_assign_dv.Items.Add(ds.Tables[0].Rows[i][0].ToString());
                        comboBox_makb_cntt.Items.Add(ds.Tables[0].Rows[i][0].ToString());
                    }

                    cmd = new OracleCommand("SELECT MADV, TENDV FROM HOSPITAL_MANAGE.DICHVU", con);
                    oda = new OracleDataAdapter(cmd);
                    ds = new DataSet();
                    oda.Fill(ds);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ComboboxItem item = new ComboboxItem();
                        item.Text = ds.Tables[0].Rows[i][1].ToString();
                        item.Value = ds.Tables[0].Rows[i][0].ToString();
                        DichVu_assign.Items.Add(item);
                    }
                }

                // groupbox dịch vụ và hóa đơn cho tài vụ. nếu không phải tài vụ, xóa groupbox đi
                if (job_role == "NV tài v?")
                {
                    cmd = new OracleCommand("SELECT MADV, TENDV FROM HOSPITAL_MANAGE.DICHVU", con);
                    OracleDataAdapter oda = new OracleDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    oda.Fill(ds);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ComboboxItem item = new ComboboxItem();
                        item.Text = ds.Tables[0].Rows[i][1].ToString();
                        item.Value = ds.Tables[0].Rows[i][0].ToString();
                        comboBox1.Items.Add(item);
                    }

                    cmd = new OracleCommand("SELECT SOHD FROM HOSPITAL_MANAGE.HOADON", con);
                    oda = new OracleDataAdapter(cmd);
                    ds = new DataSet();
                    oda.Fill(ds);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ComboboxItem item = new ComboboxItem();
                        item.Text = ds.Tables[0].Rows[i][0].ToString();
                        item.Value = ds.Tables[0].Rows[i][0].ToString();
                        comboBox2.Items.Add(item);
                    }



                }
                else
                {
                    TaiVuInsertBox.Visible = false;
                }

                if (job_role != "NV K? toán")
                    add.TabPages.Remove(tabPage5);

                con.Close();
            }
        }

        public ActivePage()
        {
            InitializeComponent();
            Tab_control();
            Load_Data();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ChamCongGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OracleConnection con = DBUtils.GetDBConnection(Global.GetCurrentUserName(), Global.GetCurrentPassword()))
            {
                string madv = (comboBox1.SelectedItem as ComboboxItem).Value.ToString();
                string sohd = (comboBox2.SelectedItem as ComboboxItem).Value.ToString();
                string query = "INSERT INTO HOSPITAL_MANAGE.CHITIETHD(SOHD, MADV) VALUES (" + sohd + ", " + madv + ")";

                try
                {
                    OracleCommand cmd = new OracleCommand(query, con);
                    con.Open();
                    OracleDataAdapter oda = new OracleDataAdapter(cmd);
                    cmd.ExecuteNonQuery();
                    cmd = new OracleCommand("COMMIT", con);
                    oda = new OracleDataAdapter(cmd);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid value from boxes or duplicates");
                }
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void NgaySinhPicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void buttonInsertBN_Click(object sender, EventArgs e)
        {
            string username = Global.GetCurrentUserName();
            string pass = Global.GetCurrentPassword();
            using (OracleConnection con = DBUtils.GetDBConnection(username, pass))
            {
                con.Open();
                OracleCommand cmd = new OracleCommand("SELECT MAX(MABN) + 1 FROM HOSPITAL_MANAGE.BENHNHAN", con);
                OracleDataReader ord = cmd.ExecuteReader();
                string new_mabn = "";
                try
                {
                    while (ord.Read())
                        new_mabn = ord.GetInt64(0).ToString();
                }
                catch (Exception ex) { new_mabn = "0"; };

                string new_birth = NgaySinhPicker.Value.ToShortDateString();
                string new_name = textBox1.Text.ToString();
                string sdt = textBox3.Text.ToString();
                string address = textBox2.Text.ToString();
                string query = "INSERT INTO HOSPITAL_MANAGE.BENHNHAN (MABN, HOTEN, NGAYSINH,  ADDRESS, SDT) VALUES ( " + new_mabn + " , '" + new_name + "' , TO_DATE('" + new_birth + "' , 'MM/DD/YYYY') , '" + address + "' , '" + sdt + "')";
                cmd = new OracleCommand(query, con);
                OracleDataAdapter oda = new OracleDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                cmd = new OracleCommand("COMMIT", con);
                oda = new OracleDataAdapter(cmd);
                cmd.ExecuteNonQuery();

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                con.Close();
            }
        }

        private void buttonDeleteBN_Click(object sender, EventArgs e)
        {
            string username = Global.GetCurrentUserName();
            string pass = Global.GetCurrentPassword();
            using (OracleConnection con = DBUtils.GetDBConnection(username, pass))
            {
                con.Open();

                string new_birth = NgaySinhPicker.Value.ToShortDateString();
                string new_name = textBox1.Text.ToString();
                string sdt = textBox3.Text.ToString();
                string address = textBox2.Text.ToString();
                string query = "DELETE FROM HOSPITAL_MANAGE.BENHNHAN WHERE ";
                string add_query = (new_name == "") ? "" : ("HOTEN = '" + new_name + "'");
                query = query + add_query;
                add_query = (new_birth == "") ? "" : (" and NGAYSINH = TO_DATE('" + new_birth + "', 'MM/DD/YYYY') ");
                query = query + add_query;
                add_query = (sdt == "") ? "" : (" and SDT = '" + sdt + "'");
                query = query + add_query;
                add_query = (address == "") ? "" : (" AND ADDRESS = '" + address + "'");
                query = query + add_query;
                MessageBox.Show(query);
                try
                {
                    OracleCommand cmd = new OracleCommand(query, con);
                    OracleDataAdapter oda = new OracleDataAdapter(cmd);
                    cmd.ExecuteNonQuery();
                    cmd = new OracleCommand("commit", con);
                    oda = new OracleDataAdapter(cmd);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Specify at least HOTEN and NgaySinh benhnhan CORRECT");
                }
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                con.Close();
            }
        }

        private void buttonUpdateBN_Click(object sender, EventArgs e)
        {
            string username = Global.GetCurrentUserName();
            string pass = Global.GetCurrentPassword();
            using (OracleConnection con = DBUtils.GetDBConnection(username, pass))
            {
                con.Open();
                string new_birth = NgaySinhPicker.Value.ToShortDateString();
                string new_name = textBox1.Text.ToString();
                string sdt = textBox3.Text.ToString();
                string address = textBox2.Text.ToString();
                string query = "UPDATE HOSPITAL_MANAGE.BENHNHAN SET NGAYSINH = to_date('" + new_birth + "', 'MM/DD/YYYY')";
                string add_query = (new_name == "") ? "" : (", HOTEN = '" + new_name + "' ");
                query = query + add_query;
                add_query = (sdt == "") ? "" : (", SDT = '" + sdt + "' ");
                query = query + add_query;
                add_query = (address == "") ? "" : (", ADDRESS = '" + address + "'");
                query = query + add_query;
                query = query + " WHERE MABN = " + textBox4.Text.ToString();

                try
                {
                    OracleCommand cmd = new OracleCommand(query, con);
                    OracleDataAdapter oda = new OracleDataAdapter(cmd);
                    cmd.ExecuteNonQuery();
                    cmd = new OracleCommand("commit", con);
                    oda = new OracleDataAdapter(cmd);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("make sure to specify Mã bệnh Nhân");
                }
                con.Close();
            }
        }

        private void AddHSBN_Vutton_Click(object sender, EventArgs e)
        {

        }

        private void comboBox_MADV_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button_addHSDV_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }


        private void add_HSBN_Button_Click(object sender, EventArgs e)
        {
            string username = Global.GetCurrentUserName();
            string pass = Global.GetCurrentPassword();
            using (OracleConnection con = DBUtils.GetDBConnection(username, pass))
            {
                con.Open();
                OracleCommand cmd = new OracleCommand("SELECT MAX(MAKB) + 1 FROM hospital_manage.benhnhan_dichvu_TT", con);
                OracleDataReader odr = cmd.ExecuteReader();
                string new_makb = "";
                try
                {
                    while (odr.Read())
                        new_makb = odr.GetInt64(0).ToString();
                }
                catch (Exception ex) { new_makb = "0"; };

                string mabs = (combo_BS_HSBN.SelectedItem as ComboboxItem).Value.ToString();
                string mabn = (HSBN_MABN.SelectedItem as ComboboxItem).Value.ToString();
                string date = dateTimePicker1.Value.ToShortDateString();
                cmd = new OracleCommand("SELECT SYS_CONTEXT('EMPLOYEE_CTX', 'ID_NHANVIEN') FROM DUAL", con);
                odr = cmd.ExecuteReader();
                string matt = "";
                try
                {
                    while (odr.Read())
                        matt = odr.GetString(0);
                }
                catch (Exception ex) { matt = "null"; };

                string query = "INSERT INTO HOSPITAL_MANAGE.HOSOBN(MAKB, MABN, MABS, MATT, NGAYKHAM) VALUES (" + new_makb + ", " + mabn + ", " + mabs + ", " + matt + ", TO_DATE('" +
                    date + "', 'MM/DD/YYYY'))";
                try
                {
                    cmd = new OracleCommand(query, con);

                    cmd.ExecuteNonQuery();
                    cmd = new OracleCommand("commit", con);

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("có lỗi trong quá trình nhập");
                }
                cmd = new OracleCommand("SELECT * FROM HOSPITAL_MANAGE.TIEPTAN_BENHNHAN", con);
                OracleDataAdapter oda = new OracleDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                DataSet ds = new DataSet();
                oda.Fill(ds);
                if (ds.Tables.Count > 0)
                {
                    DieuPhoiBNView.DataSource = ds.Tables[0].DefaultView;
                }
                con.Close();
            }
        }

        private void ke_don_Click(object sender, EventArgs e)
        {
            string username = Global.GetCurrentUserName();
            string pass = Global.GetCurrentPassword();
            using (OracleConnection conn = DBUtils.GetDBConnection(username, pass))
            {
                conn.Open();
                string query = "";

                try
                {
                    string mathuoc = (thuoc_BN.SelectedItem as ComboboxItem).Value.ToString();
                    string makb = makb_BS.SelectedItem.ToString();
                    string sl = lieu_dung.Value.ToString();
                    string descript = textbox_descript.Text.ToString();
                    string lieu = choose_lieudung.Value.ToString();
                    query = "INSERT INTO HOSPITAL_MANAGE.chitietdonthuoc(MAKB,MATHUOC,SL,LIEUDUNG,DESCRIP) values (" + makb + ", '" + mathuoc + "', " + sl + ", '" + lieu + "', '" + descript + "')";

                    OracleCommand cmd = new OracleCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    cmd = new OracleCommand("commit", conn);
                    cmd.ExecuteNonQuery();
                    cmd = new OracleCommand("SELECT * FROM HOSPITAL_MANAGE.BACSI_BENHNHAN", conn);
                    OracleDataAdapter oda = new OracleDataAdapter(cmd);
                    cmd.ExecuteNonQuery();
                    DataSet ds = new DataSet();
                    oda.Fill(ds);
                    if (ds.Tables.Count > 0)
                    {
                        SearchBN.DataSource = ds.Tables[0].DefaultView;
                    }
                }
                catch (Exception ex) { MessageBox.Show("nhập đầy đủ thông tin"); }

                conn.Close();
            }
        }

        private void update_CTDT_button_Click(object sender, EventArgs e)
        {
            string username = Global.GetCurrentUserName();
            string pass = Global.GetCurrentPassword();
            using (OracleConnection conn = DBUtils.GetDBConnection(username, pass))
            {
                conn.Open();
                string query = "";

                try
                {
                    string mathuoc = (thuoc_BN.SelectedItem as ComboboxItem).Value.ToString();
                    string makb = makb_BS.SelectedItem.ToString();
                    string sl = lieu_dung.Value.ToString();
                    string descript = textbox_descript.Text.ToString();
                    string lieu = choose_lieudung.Value.ToString();
                    query = "select * from HOSPITAL_MANAGE.chitietdonthuoc where mathuoc = '" + mathuoc + "' and makb = " + makb;
                    OracleCommand cmd = new OracleCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    OracleDataAdapter oda = new OracleDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    oda.Fill(ds);

                    if (ds.Tables.Count > 0)
                    {
                        query = "UPDATE HOSPITAL_MANAGE.chitietdonthuoc SET ";
                        string add_query = (sl == "") ? "" : ("SL = " + sl + " ");
                        query = query + add_query;
                        add_query = (descript == "") ? "" : (", DESCRIP = " + descript + " ");
                        query = query + add_query;
                        add_query = (lieu == "") ? "" : (", LIEUDUNG = '" + lieu + "' ");
                        query = query + add_query;
                        query = query + " WHERE MAKB = " + makb + " and mathuoc = '" + mathuoc + "'";

                        cmd = new OracleCommand(query, conn);
                        cmd.ExecuteNonQuery();
                        cmd = new OracleCommand("commit", conn);
                        cmd.ExecuteNonQuery();
                        cmd = new OracleCommand("SELECT * FROM HOSPITAL_MANAGE.BACSI_BENHNHAN", conn);
                        oda = new OracleDataAdapter(cmd);
                        cmd.ExecuteNonQuery();
                        ds = new DataSet();
                        oda.Fill(ds);
                        if (ds.Tables.Count > 0)
                        {
                            SearchBN.DataSource = ds.Tables[0].DefaultView;
                        }
                    }
                    else { MessageBox.Show("không tồn tại"); }
                }
                catch (Exception ex) { MessageBox.Show("nhập đầy đủ thông tin"); }

                conn.Close();
            }
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void add_hsdv_BS_Click(object sender, EventArgs e)
        {
            string username = Global.GetCurrentUserName();
            string pass = Global.GetCurrentPassword();
            using (OracleConnection conn = DBUtils.GetDBConnection(username, pass))
            {
                conn.Open();
                try
                {
                    string dvu = (DichVu_assign.SelectedItem as ComboboxItem).Value.ToString();
                    string makb = MAKB_assign_dv.SelectedItem.ToString();
                    string query = "INSERT INTO HOSPITAL_MANAGE.HOSO_DICHVU(MAKB, MADV) VALUES (" + makb + ", " + dvu + ")";
                    OracleCommand cmd = new OracleCommand(query, conn);
                    cmd.ExecuteNonQuery();

                    cmd = new OracleCommand("SELECT * FROM HOSPITAL_MANAGE.BACSI_BENHNHAN", conn);
                    OracleDataAdapter oda = new OracleDataAdapter(cmd);
                    cmd.ExecuteNonQuery();
                    DataSet ds = new DataSet();
                    oda.Fill(ds);
                    if (ds.Tables.Count > 0)
                    {
                        SearchBN.DataSource = ds.Tables[0].DefaultView;
                    }

                }
                catch (Exception ex) { MessageBox.Show("INVALID INSERT VALUE OR DUPLICATES"); };
                conn.Close();
            }
        }

        private void BS_update_hsbn_button_Click(object sender, EventArgs e)
        {
            string username = Global.GetCurrentUserName();
            string pass = Global.GetCurrentPassword();
            using (OracleConnection conn = DBUtils.GetDBConnection(username, pass))
            {
                conn.Open();
                try 
                {
                    string makb = comboBox_makb_cntt.SelectedItem.ToString();
                    string tt = textBox_TTBN_BS.Text.ToString();
                    string kl = textBox_BSKL.Text.ToString();
                    string query = "UPDATE HOSPITAL_MANAGE.temp_hsbn_doctor SET ";
                    if (tt != "")
                    {
                        OracleCommand cmd1 = new OracleCommand(query + "TINHTRANG = '" + tt + "' where makb = " + makb, conn);
                        cmd1.ExecuteNonQuery();
                    }

                    if (kl != "")
                    {
                        OracleCommand cmd2 = new OracleCommand(query + "KETLUAN = '" + kl + "' where makb = " + makb, conn);
                        cmd2.ExecuteNonQuery();
                    }

                    OracleCommand cmd = new OracleCommand("SELECT * FROM HOSPITAL_MANAGE.BACSI_BENHNHAN", conn);
                    OracleDataAdapter oda = new OracleDataAdapter(cmd);
                    cmd.ExecuteNonQuery();
                    DataSet ds = new DataSet();
                    oda.Fill(ds);
                    if (ds.Tables.Count > 0)
                    {
                        SearchBN.DataSource = ds.Tables[0].DefaultView;
                    }
                }
                catch(Exception ex) { MessageBox.Show("invalid input data"); };
                conn.Close();
            }
        }

        private void button_dieuphoi_dvu_Click(object sender, EventArgs e)
        {
            string username = Global.GetCurrentUserName();
            string pass = Global.GetCurrentPassword();
            using (OracleConnection conn = DBUtils.GetDBConnection(username, pass))
            {
                conn.Open();
                string makb = dieuphoi_makb.SelectedItem.ToString();
                string dvu = (combobox_dvu_dieuphoi.SelectedItem as ComboboxItem).Value.ToString();
                string date = dateTimePicker_dieuphoi.Value.ToShortDateString();
                string bs = (combobox_bs_dieuphoi.SelectedItem as ComboboxItem).Value.ToString();
                string query = "update hospital_manage.hoso_dichvu set ";
 
                try 
                {
                    if(date != "")
                    {
                        OracleCommand cmd = new OracleCommand(query + " ngay = to_date('" + date + "', 'MM/DD/YYYY') where makb=" + makb + " and madv = " + dvu, conn);
                        cmd.ExecuteNonQuery();
                    }
                    
                    if (bs != "")
                    {
                        OracleCommand cmd = new OracleCommand(query + " nguoi_th = " + bs + " where makb = " + makb + " and madv = " + dvu, conn);
                        cmd.ExecuteNonQuery();
                    }
                } catch (Exception ex) { MessageBox.Show("Invalid input data"); };
                conn.Close();
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e){

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e){
            
        }
        private void comboBox_makb_cntt_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
