using System.Drawing;
using System.Windows.Forms;
using QLDSV.Utils;

namespace QLDSV.Forms
{
    partial class ManageTeacherForm
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
            this.dgvTeachers = new DataGridView();
            this.pnlTeacher = new Panel();
            this.lblName = new Label();
            this.txtName = new TextBox();
            this.lblUser = new Label();
            this.cbUser = new ComboBox();
            this.btnAddTeacher = new RoundedButton();
            this.btnEditTeacher = new RoundedButton();
            this.btnDeleteTeacher = new RoundedButton();
            
            this.SuspendLayout();

            this.dgvTeachers.Dock = DockStyle.Fill;
            this.dgvTeachers.BackgroundColor = Color.White;
            this.dgvTeachers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvTeachers.CellClick += new DataGridViewCellEventHandler(this.dgvTeachers_CellClick);
            
            this.pnlTeacher.Dock = DockStyle.Right;
            this.pnlTeacher.Width = 300;
            this.pnlTeacher.BackColor = Color.FromArgb(240, 244, 248);
            
            // Name
            this.lblName.Text = "Họ và tên Giảng viên:";
            this.lblName.Location = new Point(20, 30);
            this.lblName.AutoSize = true;
            this.txtName.Location = new Point(20, 55);
            this.txtName.Width = 260;
            
            // User liên kết
            this.lblUser.Text = "Tài khoản liên kết (Username):";
            this.lblUser.Location = new Point(20, 100);
            this.lblUser.AutoSize = true;
            this.cbUser.Location = new Point(20, 125);
            this.cbUser.Width = 260;
            this.cbUser.DropDownStyle = ComboBoxStyle.DropDownList;
            
            this.btnAddTeacher.Text = "➕ Thêm GV";
            this.btnAddTeacher.BackColor = Color.FromArgb(74, 144, 226);
            this.btnAddTeacher.Location = new Point(20, 200);
            this.btnAddTeacher.Size = new Size(125, 45);
            this.btnAddTeacher.Click += new System.EventHandler(this.btnAddTeacher_Click);
            
            this.btnEditTeacher.Text = "✏ Sửa GV";
            this.btnEditTeacher.BackColor = Color.FromArgb(74, 144, 226);
            this.btnEditTeacher.Location = new Point(155, 200);
            this.btnEditTeacher.Size = new Size(125, 45);
            this.btnEditTeacher.Click += new System.EventHandler(this.btnEditTeacher_Click);
            
            this.btnDeleteTeacher.Text = "🗑 Xóa GV";
            this.btnDeleteTeacher.BackColor = Color.FromArgb(239, 83, 80);
            this.btnDeleteTeacher.Location = new Point(20, 260);
            this.btnDeleteTeacher.Size = new Size(260, 45);
            this.btnDeleteTeacher.Click += new System.EventHandler(this.btnDeleteTeacher_Click);
            
            this.pnlTeacher.Controls.Add(lblName);
            this.pnlTeacher.Controls.Add(txtName);
            this.pnlTeacher.Controls.Add(lblUser);
            this.pnlTeacher.Controls.Add(cbUser);
            this.pnlTeacher.Controls.Add(btnAddTeacher);
            this.pnlTeacher.Controls.Add(btnEditTeacher);
            this.pnlTeacher.Controls.Add(btnDeleteTeacher);
            
            // ManageTeacherForm
            this.ClientSize = new Size(800, 450);
            this.Controls.Add(this.dgvTeachers);
            this.Controls.Add(this.pnlTeacher);
            this.Font = new Font("Segoe UI", 10F);
            this.Name = "ManageTeacherForm";
            this.Text = "Quản lý Giảng viên";
            this.StartPosition = FormStartPosition.CenterScreen;
            
            this.ResumeLayout(false);
        }

        private DataGridView dgvTeachers;
        private Panel pnlTeacher;
        private Label lblName, lblUser;
        private TextBox txtName;
        private ComboBox cbUser;
        private RoundedButton btnAddTeacher, btnEditTeacher, btnDeleteTeacher;
    }
}
