
namespace ATBM_GiaoDien
{
    partial class DialogCheckFGA
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
            this.CheckFGAGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CheckFGAGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // CheckFGAGridView
            // 
            this.CheckFGAGridView.AllowUserToAddRows = false;
            this.CheckFGAGridView.AllowUserToDeleteRows = false;
            this.CheckFGAGridView.AllowUserToOrderColumns = true;
            this.CheckFGAGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CheckFGAGridView.Location = new System.Drawing.Point(5, 34);
            this.CheckFGAGridView.Name = "CheckFGAGridView";
            this.CheckFGAGridView.Size = new System.Drawing.Size(573, 221);
            this.CheckFGAGridView.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // DialogCheckFGA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 261);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CheckFGAGridView);
            this.Name = "DialogCheckFGA";
            this.Text = "DialogCheckFGA";
            ((System.ComponentModel.ISupportInitialize)(this.CheckFGAGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView CheckFGAGridView;
        private System.Windows.Forms.Label label1;
    }
}