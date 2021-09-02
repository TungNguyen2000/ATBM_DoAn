namespace ATBM
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.View_User_Priv = new System.Windows.Forms.Button();
			this.Revoke_Priv = new System.Windows.Forms.Button();
			this.Priv_To_User = new System.Windows.Forms.Button();
			this.no_Grant_Option = new System.Windows.Forms.CheckBox();
			this.yes_Grant_Option = new System.Windows.Forms.CheckBox();
			this.label12 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.Column_ComboBox = new System.Windows.Forms.ComboBox();
			this.Table_ComboBox = new System.Windows.Forms.ComboBox();
			this.Priv_ComboBox = new System.Windows.Forms.ComboBox();
			this.Role = new System.Windows.Forms.GroupBox();
			this.User_Role = new System.Windows.Forms.ComboBox();
			this.label8 = new System.Windows.Forms.Label();
			this.Delete_Role = new System.Windows.Forms.Button();
			this.Add_Role = new System.Windows.Forms.Button();
			this.View_User_Role = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.Set_Role = new System.Windows.Forms.Button();
			this.role_comboBox = new System.Windows.Forms.ComboBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.no_ExpirePass = new System.Windows.Forms.CheckBox();
			this.no_LockAccount = new System.Windows.Forms.CheckBox();
			this.yes_ExpirePass = new System.Windows.Forms.CheckBox();
			this.yes_lockAccount = new System.Windows.Forms.CheckBox();
			this.alter_user_result = new System.Windows.Forms.Label();
			this.Alter = new System.Windows.Forms.Button();
			this.input_PASSWORD = new System.Windows.Forms.TextBox();
			this.input_USERNAME = new System.Windows.Forms.TextBox();
			this.CREATE_LABEL = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.User_name = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.Delete = new System.Windows.Forms.Button();
			this.Create = new System.Windows.Forms.Button();
			this.User_List = new System.Windows.Forms.DataGridView();
			this.USERNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.COMMON = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ORACLE_MAINTAINED = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.USER_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.CREATED = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.label1 = new System.Windows.Forms.Label();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.Role.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.User_List)).BeginInit();
			this.SuspendLayout();
			// 
			// tabPage2
			// 
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(765, 400);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Logging";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(15, 12);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(773, 426);
			this.tabControl1.TabIndex = 9;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.groupBox2);
			this.tabPage1.Controls.Add(this.Role);
			this.tabPage1.Controls.Add(this.groupBox1);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.Delete);
			this.tabPage1.Controls.Add(this.Create);
			this.tabPage1.Controls.Add(this.User_List);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(765, 400);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Phân quyền";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.View_User_Priv);
			this.groupBox2.Controls.Add(this.Revoke_Priv);
			this.groupBox2.Controls.Add(this.Priv_To_User);
			this.groupBox2.Controls.Add(this.no_Grant_Option);
			this.groupBox2.Controls.Add(this.yes_Grant_Option);
			this.groupBox2.Controls.Add(this.label12);
			this.groupBox2.Controls.Add(this.label11);
			this.groupBox2.Controls.Add(this.label10);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Controls.Add(this.Column_ComboBox);
			this.groupBox2.Controls.Add(this.Table_ComboBox);
			this.groupBox2.Controls.Add(this.Priv_ComboBox);
			this.groupBox2.Location = new System.Drawing.Point(486, 217);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(273, 177);
			this.groupBox2.TabIndex = 22;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Phân quyền";
			this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter_1);
			// 
			// View_User_Priv
			// 
			this.View_User_Priv.Location = new System.Drawing.Point(79, 147);
			this.View_User_Priv.Name = "View_User_Priv";
			this.View_User_Priv.Size = new System.Drawing.Size(188, 24);
			this.View_User_Priv.TabIndex = 5;
			this.View_User_Priv.Text = "Xem thông tin phân quyền của user";
			this.View_User_Priv.UseVisualStyleBackColor = true;
			this.View_User_Priv.Click += new System.EventHandler(this.View_User_Priv_Click);
			// 
			// Revoke_Priv
			// 
			this.Revoke_Priv.Location = new System.Drawing.Point(188, 119);
			this.Revoke_Priv.Name = "Revoke_Priv";
			this.Revoke_Priv.Size = new System.Drawing.Size(79, 23);
			this.Revoke_Priv.TabIndex = 4;
			this.Revoke_Priv.Text = "Hủy quyền";
			this.Revoke_Priv.UseVisualStyleBackColor = true;
			this.Revoke_Priv.Click += new System.EventHandler(this.Revoke_Priv_Click);
			// 
			// Priv_To_User
			// 
			this.Priv_To_User.Location = new System.Drawing.Point(79, 118);
			this.Priv_To_User.Name = "Priv_To_User";
			this.Priv_To_User.Size = new System.Drawing.Size(103, 23);
			this.Priv_To_User.TabIndex = 3;
			this.Priv_To_User.Text = "Cấp quyền";
			this.Priv_To_User.UseVisualStyleBackColor = true;
			this.Priv_To_User.Click += new System.EventHandler(this.Priv_To_User_Click);
			// 
			// no_Grant_Option
			// 
			this.no_Grant_Option.AutoSize = true;
			this.no_Grant_Option.Location = new System.Drawing.Point(223, 41);
			this.no_Grant_Option.Name = "no_Grant_Option";
			this.no_Grant_Option.Size = new System.Drawing.Size(40, 17);
			this.no_Grant_Option.TabIndex = 2;
			this.no_Grant_Option.Text = "No";
			this.no_Grant_Option.UseVisualStyleBackColor = true;
			this.no_Grant_Option.CheckedChanged += new System.EventHandler(this.no_Grant_Option_CheckedChanged);
			// 
			// yes_Grant_Option
			// 
			this.yes_Grant_Option.AutoSize = true;
			this.yes_Grant_Option.Location = new System.Drawing.Point(173, 41);
			this.yes_Grant_Option.Name = "yes_Grant_Option";
			this.yes_Grant_Option.Size = new System.Drawing.Size(44, 17);
			this.yes_Grant_Option.TabIndex = 2;
			this.yes_Grant_Option.Text = "Yes";
			this.yes_Grant_Option.UseVisualStyleBackColor = true;
			this.yes_Grant_Option.CheckedChanged += new System.EventHandler(this.yes_Grant_Option_CheckedChanged);
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(7, 94);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(26, 13);
			this.label12.TabIndex = 1;
			this.label12.Text = "Cột:";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(7, 45);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(68, 13);
			this.label11.TabIndex = 1;
			this.label11.Text = "Grant option:";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(7, 67);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(35, 13);
			this.label10.TabIndex = 1;
			this.label10.Text = "Bảng:";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(7, 19);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(34, 13);
			this.label9.TabIndex = 1;
			this.label9.Text = "Lệnh:";
			// 
			// Column_ComboBox
			// 
			this.Column_ComboBox.FormattingEnabled = true;
			this.Column_ComboBox.Location = new System.Drawing.Point(79, 91);
			this.Column_ComboBox.Name = "Column_ComboBox";
			this.Column_ComboBox.Size = new System.Drawing.Size(188, 21);
			this.Column_ComboBox.TabIndex = 0;
			// 
			// Table_ComboBox
			// 
			this.Table_ComboBox.FormattingEnabled = true;
			this.Table_ComboBox.Location = new System.Drawing.Point(79, 64);
			this.Table_ComboBox.Name = "Table_ComboBox";
			this.Table_ComboBox.Size = new System.Drawing.Size(188, 21);
			this.Table_ComboBox.TabIndex = 0;
			this.Table_ComboBox.SelectedIndexChanged += new System.EventHandler(this.Table_ComboBox_SelectedIndexChanged);
			// 
			// Priv_ComboBox
			// 
			this.Priv_ComboBox.FormattingEnabled = true;
			this.Priv_ComboBox.Location = new System.Drawing.Point(79, 16);
			this.Priv_ComboBox.Name = "Priv_ComboBox";
			this.Priv_ComboBox.Size = new System.Drawing.Size(188, 21);
			this.Priv_ComboBox.TabIndex = 0;
			this.Priv_ComboBox.SelectedIndexChanged += new System.EventHandler(this.Priv_ComboBox_SelectedIndexChanged);
			// 
			// Role
			// 
			this.Role.Controls.Add(this.User_Role);
			this.Role.Controls.Add(this.label8);
			this.Role.Controls.Add(this.Delete_Role);
			this.Role.Controls.Add(this.Add_Role);
			this.Role.Controls.Add(this.View_User_Role);
			this.Role.Controls.Add(this.button1);
			this.Role.Controls.Add(this.Set_Role);
			this.Role.Controls.Add(this.role_comboBox);
			this.Role.Location = new System.Drawing.Point(280, 217);
			this.Role.Name = "Role";
			this.Role.Size = new System.Drawing.Size(200, 177);
			this.Role.TabIndex = 21;
			this.Role.TabStop = false;
			this.Role.Text = "Role";
			this.Role.Enter += new System.EventHandler(this.groupBox2_Enter);
			// 
			// User_Role
			// 
			this.User_Role.FormattingEnabled = true;
			this.User_Role.Location = new System.Drawing.Point(6, 47);
			this.User_Role.Name = "User_Role";
			this.User_Role.Size = new System.Drawing.Size(89, 21);
			this.User_Role.TabIndex = 23;
			this.User_Role.Text = "UserRole";
			this.User_Role.SelectedIndexChanged += new System.EventHandler(this.User_Role_SelectedIndexChanged);
			// 
			// label8
			// 
			this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label8.Location = new System.Drawing.Point(0, 91);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(200, 2);
			this.label8.TabIndex = 22;
			// 
			// Delete_Role
			// 
			this.Delete_Role.Location = new System.Drawing.Point(101, 138);
			this.Delete_Role.Name = "Delete_Role";
			this.Delete_Role.Size = new System.Drawing.Size(91, 23);
			this.Delete_Role.TabIndex = 3;
			this.Delete_Role.Text = "Xóa role";
			this.Delete_Role.UseVisualStyleBackColor = true;
			this.Delete_Role.Click += new System.EventHandler(this.Delete_Role_Click);
			// 
			// Add_Role
			// 
			this.Add_Role.Location = new System.Drawing.Point(7, 138);
			this.Add_Role.Name = "Add_Role";
			this.Add_Role.Size = new System.Drawing.Size(88, 23);
			this.Add_Role.TabIndex = 3;
			this.Add_Role.Text = "Thêm role";
			this.Add_Role.UseVisualStyleBackColor = true;
			this.Add_Role.Click += new System.EventHandler(this.Add_Role_Click);
			// 
			// View_User_Role
			// 
			this.View_User_Role.Location = new System.Drawing.Point(6, 105);
			this.View_User_Role.Name = "View_User_Role";
			this.View_User_Role.Size = new System.Drawing.Size(186, 27);
			this.View_User_Role.TabIndex = 2;
			this.View_User_Role.Text = "Xem user role";
			this.View_User_Role.UseVisualStyleBackColor = true;
			this.View_User_Role.Click += new System.EventHandler(this.View_User_Role_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(101, 46);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(89, 22);
			this.button1.TabIndex = 1;
			this.button1.Text = "Xóa role user";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// Set_Role
			// 
			this.Set_Role.Location = new System.Drawing.Point(101, 22);
			this.Set_Role.Name = "Set_Role";
			this.Set_Role.Size = new System.Drawing.Size(89, 22);
			this.Set_Role.TabIndex = 1;
			this.Set_Role.Text = "Đặt role user";
			this.Set_Role.UseVisualStyleBackColor = true;
			this.Set_Role.Click += new System.EventHandler(this.Set_Role_Click);
			// 
			// role_comboBox
			// 
			this.role_comboBox.FormattingEnabled = true;
			this.role_comboBox.Location = new System.Drawing.Point(6, 22);
			this.role_comboBox.Name = "role_comboBox";
			this.role_comboBox.Size = new System.Drawing.Size(89, 21);
			this.role_comboBox.TabIndex = 0;
			this.role_comboBox.Text = "SystemRole";
			// 
			// groupBox1
			// 
			this.groupBox1.BackColor = System.Drawing.Color.White;
			this.groupBox1.Controls.Add(this.no_ExpirePass);
			this.groupBox1.Controls.Add(this.no_LockAccount);
			this.groupBox1.Controls.Add(this.yes_ExpirePass);
			this.groupBox1.Controls.Add(this.yes_lockAccount);
			this.groupBox1.Controls.Add(this.alter_user_result);
			this.groupBox1.Controls.Add(this.Alter);
			this.groupBox1.Controls.Add(this.input_PASSWORD);
			this.groupBox1.Controls.Add(this.input_USERNAME);
			this.groupBox1.Controls.Add(this.CREATE_LABEL);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.User_name);
			this.groupBox1.Location = new System.Drawing.Point(9, 217);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(264, 177);
			this.groupBox1.TabIndex = 20;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Thông tin";
			// 
			// no_ExpirePass
			// 
			this.no_ExpirePass.AutoSize = true;
			this.no_ExpirePass.Location = new System.Drawing.Point(202, 95);
			this.no_ExpirePass.Name = "no_ExpirePass";
			this.no_ExpirePass.Size = new System.Drawing.Size(40, 17);
			this.no_ExpirePass.TabIndex = 30;
			this.no_ExpirePass.Text = "No";
			this.no_ExpirePass.UseVisualStyleBackColor = true;
			this.no_ExpirePass.CheckedChanged += new System.EventHandler(this.no_ExpirePass_CheckedChanged);
			// 
			// no_LockAccount
			// 
			this.no_LockAccount.AutoSize = true;
			this.no_LockAccount.Location = new System.Drawing.Point(202, 72);
			this.no_LockAccount.Name = "no_LockAccount";
			this.no_LockAccount.Size = new System.Drawing.Size(40, 17);
			this.no_LockAccount.TabIndex = 29;
			this.no_LockAccount.Text = "No";
			this.no_LockAccount.UseVisualStyleBackColor = true;
			this.no_LockAccount.CheckedChanged += new System.EventHandler(this.no_LockAccount_CheckedChanged);
			// 
			// yes_ExpirePass
			// 
			this.yes_ExpirePass.AutoSize = true;
			this.yes_ExpirePass.Location = new System.Drawing.Point(143, 95);
			this.yes_ExpirePass.Name = "yes_ExpirePass";
			this.yes_ExpirePass.Size = new System.Drawing.Size(44, 17);
			this.yes_ExpirePass.TabIndex = 28;
			this.yes_ExpirePass.Text = "Yes";
			this.yes_ExpirePass.UseVisualStyleBackColor = true;
			this.yes_ExpirePass.CheckedChanged += new System.EventHandler(this.yes_ExpirePass_CheckedChanged);
			// 
			// yes_lockAccount
			// 
			this.yes_lockAccount.AutoSize = true;
			this.yes_lockAccount.Location = new System.Drawing.Point(143, 72);
			this.yes_lockAccount.Name = "yes_lockAccount";
			this.yes_lockAccount.Size = new System.Drawing.Size(44, 17);
			this.yes_lockAccount.TabIndex = 27;
			this.yes_lockAccount.Text = "Yes";
			this.yes_lockAccount.UseVisualStyleBackColor = true;
			this.yes_lockAccount.CheckedChanged += new System.EventHandler(this.yes_lockAccount_CheckedChanged);
			// 
			// alter_user_result
			// 
			this.alter_user_result.AutoSize = true;
			this.alter_user_result.Location = new System.Drawing.Point(8, 153);
			this.alter_user_result.Name = "alter_user_result";
			this.alter_user_result.Size = new System.Drawing.Size(0, 13);
			this.alter_user_result.TabIndex = 26;
			// 
			// Alter
			// 
			this.Alter.Location = new System.Drawing.Point(143, 148);
			this.Alter.Name = "Alter";
			this.Alter.Size = new System.Drawing.Size(100, 23);
			this.Alter.TabIndex = 13;
			this.Alter.Text = "Chỉnh sửa";
			this.Alter.UseVisualStyleBackColor = true;
			this.Alter.Click += new System.EventHandler(this.Alter_Click);
			// 
			// input_PASSWORD
			// 
			this.input_PASSWORD.Location = new System.Drawing.Point(143, 45);
			this.input_PASSWORD.Name = "input_PASSWORD";
			this.input_PASSWORD.Size = new System.Drawing.Size(100, 20);
			this.input_PASSWORD.TabIndex = 23;
			// 
			// input_USERNAME
			// 
			this.input_USERNAME.Location = new System.Drawing.Point(143, 19);
			this.input_USERNAME.Name = "input_USERNAME";
			this.input_USERNAME.Size = new System.Drawing.Size(100, 20);
			this.input_USERNAME.TabIndex = 23;
			// 
			// CREATE_LABEL
			// 
			this.CREATE_LABEL.AutoSize = true;
			this.CREATE_LABEL.Location = new System.Drawing.Point(140, 119);
			this.CREATE_LABEL.Name = "CREATE_LABEL";
			this.CREATE_LABEL.Size = new System.Drawing.Size(82, 13);
			this.CREATE_LABEL.TabIndex = 22;
			this.CREATE_LABEL.Text = "Không xác định";
			this.CREATE_LABEL.Click += new System.EventHandler(this.label8_Click);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(9, 119);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(72, 13);
			this.label7.TabIndex = 22;
			this.label7.Text = "Thời gian tạo:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(9, 48);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(55, 13);
			this.label5.TabIndex = 22;
			this.label5.Text = "Mật khẩu:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(9, 96);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(94, 13);
			this.label6.TabIndex = 21;
			this.label6.Text = "Mật khẩu hết hạn:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(9, 73);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(79, 13);
			this.label3.TabIndex = 21;
			this.label3.Text = "Khóa tài khoản";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(9, 22);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(68, 13);
			this.label4.TabIndex = 16;
			this.label4.Text = "Người dùng: ";
			// 
			// User_name
			// 
			this.User_name.AutoSize = true;
			this.User_name.Location = new System.Drawing.Point(105, 19);
			this.User_name.Name = "User_name";
			this.User_name.Size = new System.Drawing.Size(0, 13);
			this.User_name.TabIndex = 17;
			// 
			// label2
			// 
			this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label2.Location = new System.Drawing.Point(0, 212);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(765, 2);
			this.label2.TabIndex = 14;
			// 
			// Delete
			// 
			this.Delete.Location = new System.Drawing.Point(603, 186);
			this.Delete.Name = "Delete";
			this.Delete.Size = new System.Drawing.Size(75, 23);
			this.Delete.TabIndex = 12;
			this.Delete.Text = "Xóa";
			this.Delete.UseVisualStyleBackColor = true;
			this.Delete.Click += new System.EventHandler(this.Delete_Click);
			// 
			// Create
			// 
			this.Create.Location = new System.Drawing.Point(684, 186);
			this.Create.Name = "Create";
			this.Create.Size = new System.Drawing.Size(75, 23);
			this.Create.TabIndex = 11;
			this.Create.Text = "Tạo mới";
			this.Create.UseVisualStyleBackColor = true;
			this.Create.Click += new System.EventHandler(this.Create_Click);
			// 
			// User_List
			// 
			this.User_List.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.User_List.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
			this.USERNAME,
			this.COMMON,
			this.ORACLE_MAINTAINED,
			this.USER_ID,
			this.CREATED});
			this.User_List.Location = new System.Drawing.Point(9, 24);
			this.User_List.Name = "User_List";
			this.User_List.ReadOnly = true;
			this.User_List.Size = new System.Drawing.Size(750, 156);
			this.User_List.TabIndex = 10;
			this.User_List.SelectionChanged += new System.EventHandler(this.User_List_SelectionChanged);
			// 
			// USERNAME
			// 
			this.USERNAME.DataPropertyName = "USERNAME";
			this.USERNAME.HeaderText = "USERNAME";
			this.USERNAME.Name = "USERNAME";
			this.USERNAME.ReadOnly = true;
			// 
			// COMMON
			// 
			this.COMMON.DataPropertyName = "COMMON";
			this.COMMON.HeaderText = "THÔNG THƯỜNG";
			this.COMMON.Name = "COMMON";
			this.COMMON.ReadOnly = true;
			// 
			// ORACLE_MAINTAINED
			// 
			this.ORACLE_MAINTAINED.DataPropertyName = "ORACLE_MAINTAINED";
			this.ORACLE_MAINTAINED.HeaderText = "BẢO TRÌ BỞI ORACLE";
			this.ORACLE_MAINTAINED.Name = "ORACLE_MAINTAINED";
			this.ORACLE_MAINTAINED.ReadOnly = true;
			// 
			// USER_ID
			// 
			this.USER_ID.DataPropertyName = "USER_ID";
			this.USER_ID.HeaderText = "USER_ID";
			this.USER_ID.Name = "USER_ID";
			this.USER_ID.ReadOnly = true;
			// 
			// CREATED
			// 
			this.CREATED.DataPropertyName = "CREATED";
			this.CREATED.HeaderText = "NGÀY TẠO";
			this.CREATED.Name = "CREATED";
			this.CREATED.ReadOnly = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(6, 3);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(175, 18);
			this.label1.TabIndex = 9;
			this.label1.Text = "Danh sách người dùng";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.tabControl1);
			this.Name = "Form1";
			this.Text = "ADMIN PAGE";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.Role.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.User_List)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.GroupBox Role;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button Delete_Role;
		private System.Windows.Forms.Button Add_Role;
		private System.Windows.Forms.Button View_User_Role;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button Set_Role;
		private System.Windows.Forms.ComboBox role_comboBox;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox no_ExpirePass;
		private System.Windows.Forms.CheckBox no_LockAccount;
		private System.Windows.Forms.CheckBox yes_ExpirePass;
		private System.Windows.Forms.CheckBox yes_lockAccount;
		private System.Windows.Forms.Label alter_user_result;
		private System.Windows.Forms.Button Alter;
		private System.Windows.Forms.TextBox input_PASSWORD;
		private System.Windows.Forms.TextBox input_USERNAME;
		private System.Windows.Forms.Label CREATE_LABEL;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label User_name;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button Delete;
		private System.Windows.Forms.Button Create;
		private System.Windows.Forms.DataGridView User_List;
		private System.Windows.Forms.DataGridViewTextBoxColumn USERNAME;
		private System.Windows.Forms.DataGridViewTextBoxColumn COMMON;
		private System.Windows.Forms.DataGridViewTextBoxColumn ORACLE_MAINTAINED;
		private System.Windows.Forms.DataGridViewTextBoxColumn USER_ID;
		private System.Windows.Forms.DataGridViewTextBoxColumn CREATED;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox User_Role;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.ComboBox Priv_ComboBox;
		private System.Windows.Forms.Button Priv_To_User;
		private System.Windows.Forms.CheckBox no_Grant_Option;
		private System.Windows.Forms.CheckBox yes_Grant_Option;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.ComboBox Column_ComboBox;
		private System.Windows.Forms.ComboBox Table_ComboBox;
		private System.Windows.Forms.Button Revoke_Priv;
		private System.Windows.Forms.Button View_User_Priv;
	}
}

