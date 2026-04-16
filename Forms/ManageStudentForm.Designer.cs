using System.Drawing;
using System.Windows.Forms;
using QLDSV.Utils;

namespace QLDSV.Forms
{
    partial class ManageStudentForm
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
            this.dgvStudents = new DataGridView();
            this.pnlStudent = new Panel();
            this.lblMSSV = new Label();
            this.txtMSSV = new TextBox();
            this.lblName = new Label();
            this.txtName = new TextBox();
            this.lblClass = new Label();
            this.cbClass = new ComboBox();
            this.lblUser = new Label();
            this.cbUser = new ComboBox();
            this.btnAddStudent = new RoundedButton();
            this.btnEditStudent = new RoundedButton();
            this.btnDeleteStudent = new RoundedButton();
            
            this.SuspendLayout();

            this.dgvStudents.Dock = DockStyle.Fill;
            this.dgvStudents.BackgroundColor = Color.White;
            this.dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvStudents.CellClick += new DataGridViewCellEventHandler(this.dgvStudents_CellClick);
            
            this.pnlStudent.Dock = DockStyle.Right;
            this.pnlStudent.Width = 300;
            this.pnlStudent.BackColor = Color.FromArgb(240, 244, 248);
            
            // MSSV
            this.lblMSSV.Text = "Mã số sinh viên (MSSV):";
            this.lblMSSV.Location = new Point(20, 20);
            this.lblMSSV.AutoSize = true;
            this.txtMSSV.Location = new Point(20, 45);
            this.txtMSSV.Width = 260;
            
            // Tên
            this.lblName.Text = "Họ và tên:";
            this.lblName.Location = new Point(20, 80);
            this.lblName.AutoSize = true;
            this.txtName.Location = new Point(20, 105);
            this.txtName.Width = 260;
            
            // Lớp
            this.lblClass.Text = "Lớp học:";
            this.lblClass.Location = new Point(20, 140);
            this.lblClass.AutoSize = true;
            this.cbClass.Location = new Point(20, 165);
            this.cbClass.Width = 260;
            this.cbClass.DropDownStyle = ComboBoxStyle.DropDownList;

            // User liên kết
            this.lblUser.Text = "Tài khoản liên kết (Username):";
            this.lblUser.Location = new Point(20, 200);
            this.lblUser.AutoSize = true;
            this.cbUser.Location = new Point(20, 225);
            this.cbUser.Width = 260;
            this.cbUser.DropDownStyle = ComboBoxStyle.DropDownList;
            
            this.btnAddStudent.Text = "➕ Thêm SV";
            this.btnAddStudent.BackColor = Color.FromArgb(74, 144, 226);
            this.btnAddStudent.Location = new Point(20, 280);
            this.btnAddStudent.Size = new Size(125, 40);
            this.btnAddStudent.Click += new System.EventHandler(this.btnAddStudent_Click);
            
            this.btnEditStudent.Text = "✏ Sửa SV";
            this.btnEditStudent.BackColor = Color.FromArgb(74, 144, 226);
            this.btnEditStudent.Location = new Point(155, 280);
            this.btnEditStudent.Size = new Size(125, 40);
            this.btnEditStudent.Click += new System.EventHandler(this.btnEditStudent_Click);
            
            this.btnDeleteStudent.Text = "🗑 Xóa SV";
            this.btnDeleteStudent.BackColor = Color.FromArgb(239, 83, 80);
            this.btnDeleteStudent.Location = new Point(20, 330);
            this.btnDeleteStudent.Size = new Size(260, 40);
            this.btnDeleteStudent.Click += new System.EventHandler(this.btnDeleteStudent_Click);
            
            this.pnlStudent.Controls.Add(lblMSSV);
            this.pnlStudent.Controls.Add(txtMSSV);
            this.pnlStudent.Controls.Add(lblName);
            this.pnlStudent.Controls.Add(txtName);
            this.pnlStudent.Controls.Add(lblClass);
            this.pnlStudent.Controls.Add(cbClass);
            this.pnlStudent.Controls.Add(lblUser);
            this.pnlStudent.Controls.Add(cbUser);
            this.pnlStudent.Controls.Add(btnAddStudent);
            this.pnlStudent.Controls.Add(btnEditStudent);
            this.pnlStudent.Controls.Add(btnDeleteStudent);
            
            // ManageStudentForm
            this.ClientSize = new Size(900, 500);
            this.Controls.Add(this.dgvStudents);
            this.Controls.Add(this.pnlStudent);
            this.Font = new Font("Segoe UI", 10F);
            this.Name = "ManageStudentForm";
            this.Text = "Quản lý Sinh viên";
            this.StartPosition = FormStartPosition.CenterScreen;
            
            this.ResumeLayout(false);
        }

        private DataGridView dgvStudents;
        private Panel pnlStudent;
        private Label lblMSSV, lblName, lblClass, lblUser;
        private TextBox txtMSSV, txtName;
        private ComboBox cbClass, cbUser;
        private RoundedButton btnAddStudent, btnEditStudent, btnDeleteStudent;
    }
}
