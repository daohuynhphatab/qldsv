using System.Drawing;
using System.Windows.Forms;
using QLDSV.Utils;

namespace QLDSV.Forms
{
    partial class ManageUserForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvUsers = new DataGridView();
            this.pnlUser = new Panel();
            this.lblUsername = new Label();
            this.txtUsername = new TextBox();
            this.lblPassword = new Label();
            this.txtPassword = new TextBox();
            this.lblRole = new Label();
            this.cbRole = new ComboBox();
            this.btnAddUser = new RoundedButton();
            this.btnEditUser = new RoundedButton();
            this.btnDeleteUser = new RoundedButton();
            
            this.SuspendLayout();

            this.dgvUsers.Dock = DockStyle.Fill;
            this.dgvUsers.BackgroundColor = Color.White;
            this.dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.CellClick += new DataGridViewCellEventHandler(this.dgvUsers_CellClick);
            
            this.pnlUser.Dock = DockStyle.Right;
            this.pnlUser.Width = 300;
            this.pnlUser.BackColor = Color.FromArgb(240, 244, 248);
            
            this.lblUsername.Text = "Tên đăng nhập:";
            this.lblUsername.Location = new Point(20, 30);
            this.lblUsername.AutoSize = true;
            this.txtUsername.Location = new Point(20, 55);
            this.txtUsername.Width = 260;
            
            this.lblPassword.Text = "Mật khẩu:";
            this.lblPassword.Location = new Point(20, 90);
            this.lblPassword.AutoSize = true;
            this.txtPassword.Location = new Point(20, 115);
            this.txtPassword.Width = 260;
            
            this.lblRole.Text = "Phân quyền:";
            this.lblRole.Location = new Point(20, 150);
            this.lblRole.AutoSize = true;
            this.cbRole.Location = new Point(20, 175);
            this.cbRole.Width = 260;
            this.cbRole.Items.AddRange(new object[] { "admin", "teacher" });
            this.cbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            
            this.btnAddUser.Text = "➕ Thêm";
            this.btnAddUser.BackColor = Color.FromArgb(74, 144, 226);
            this.btnAddUser.Location = new Point(20, 230);
            this.btnAddUser.Size = new Size(125, 40);
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            
            this.btnEditUser.Text = "✏ Sửa";
            this.btnEditUser.BackColor = Color.FromArgb(74, 144, 226);
            this.btnEditUser.Location = new Point(155, 230);
            this.btnEditUser.Size = new Size(125, 40);
            this.btnEditUser.Click += new System.EventHandler(this.btnEditUser_Click);
            
            this.btnDeleteUser.Text = "🗑 Xóa";
            this.btnDeleteUser.BackColor = Color.FromArgb(239, 83, 80);
            this.btnDeleteUser.Location = new Point(20, 280);
            this.btnDeleteUser.Size = new Size(260, 40);
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            
            this.pnlUser.Controls.Add(lblUsername);
            this.pnlUser.Controls.Add(txtUsername);
            this.pnlUser.Controls.Add(lblPassword);
            this.pnlUser.Controls.Add(txtPassword);
            this.pnlUser.Controls.Add(lblRole);
            this.pnlUser.Controls.Add(cbRole);
            this.pnlUser.Controls.Add(btnAddUser);
            this.pnlUser.Controls.Add(btnEditUser);
            this.pnlUser.Controls.Add(btnDeleteUser);
            
            // ManageUserForm
            this.ClientSize = new Size(800, 450);
            this.Controls.Add(this.dgvUsers);
            this.Controls.Add(this.pnlUser);
            this.Font = new Font("Segoe UI", 10F);
            this.Name = "ManageUserForm";
            this.Text = "Quản lý User";
            this.StartPosition = FormStartPosition.CenterScreen;
            
            this.ResumeLayout(false);
        }

        private DataGridView dgvUsers;
        private Panel pnlUser;
        private Label lblUsername, lblPassword, lblRole;
        private TextBox txtUsername, txtPassword;
        private ComboBox cbRole;
        private RoundedButton btnAddUser, btnEditUser, btnDeleteUser;
    }
}
