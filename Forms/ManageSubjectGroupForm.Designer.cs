using System.Drawing;
using System.Windows.Forms;
using QLDSV.Utils;

namespace QLDSV.Forms
{
    partial class ManageSubjectGroupForm
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
            this.dgvGroups = new DataGridView();
            this.pnlGroup = new Panel();
            this.dgvStudentsInClass = new DataGridView();
            this.lblStudentList = new Label();
            this.lblSubject = new Label();
            this.cbSubject = new ComboBox();
            this.lblTeacher = new Label();
            this.cbTeacher = new ComboBox();
            this.lblClass = new Label();
            this.cbClass = new ComboBox();
            this.btnAddGroup = new RoundedButton();
            this.btnEditGroup = new RoundedButton();
            this.btnDeleteGroup = new RoundedButton();
            
            this.SuspendLayout();

            this.dgvGroups.Dock = DockStyle.Fill;
            this.dgvGroups.BackgroundColor = Color.White;
            this.dgvGroups.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvGroups.CellClick += new DataGridViewCellEventHandler(this.dgvGroups_CellClick);
            
            this.pnlGroup.Dock = DockStyle.Right;
            this.pnlGroup.Width = 350;
            this.pnlGroup.BackColor = Color.FromArgb(240, 244, 248);
            
            // lblStudentList
            this.lblStudentList.Text = "Danh sách sinh viên trong lớp:";
            this.lblStudentList.Location = new Point(20, 390);
            this.lblStudentList.AutoSize = true;
            this.lblStudentList.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

            // dgvStudentsInClass
            this.dgvStudentsInClass.Location = new Point(20, 415);
            this.dgvStudentsInClass.Size = new Size(310, 110);
            this.dgvStudentsInClass.BackgroundColor = Color.White;
            this.dgvStudentsInClass.ReadOnly = true;
            this.dgvStudentsInClass.RowHeadersVisible = false;
            this.dgvStudentsInClass.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Subject
            this.lblSubject.Text = "Chọn Môn học:";
            this.lblSubject.Location = new Point(20, 30);
            this.lblSubject.AutoSize = true;
            this.cbSubject.Location = new Point(20, 55);
            this.cbSubject.Width = 310;
            this.cbSubject.DropDownStyle = ComboBoxStyle.DropDownList;
            
            // Teacher
            this.lblTeacher.Text = "Chọn Giảng viên:";
            this.lblTeacher.Location = new Point(20, 100);
            this.lblTeacher.AutoSize = true;
            this.cbTeacher.Location = new Point(20, 125);
            this.cbTeacher.Width = 310;
            this.cbTeacher.DropDownStyle = ComboBoxStyle.DropDownList;
            
            // Class
            this.lblClass.Text = "Chọn Lớp học:";
            this.lblClass.Location = new Point(20, 170);
            this.lblClass.AutoSize = true;
            this.cbClass.Location = new Point(20, 195);
            this.cbClass.Width = 310;
            this.cbClass.DropDownStyle = ComboBoxStyle.DropDownList;
            
            this.btnAddGroup.Text = "➕ Tạo Nhóm";
            this.btnAddGroup.BackColor = Color.FromArgb(74, 144, 226);
            this.btnAddGroup.Location = new Point(20, 260);
            this.btnAddGroup.Size = new Size(150, 45);
            this.btnAddGroup.Click += new System.EventHandler(this.btnAddGroup_Click);
            
            this.btnEditGroup.Text = "✏ Sửa Nhóm";
            this.btnEditGroup.BackColor = Color.FromArgb(74, 144, 226);
            this.btnEditGroup.Location = new Point(180, 260);
            this.btnEditGroup.Size = new Size(150, 45);
            this.btnEditGroup.Click += new System.EventHandler(this.btnEditGroup_Click);
            
            this.btnDeleteGroup.Text = "🗑 Xóa Nhóm";
            this.btnDeleteGroup.BackColor = Color.FromArgb(239, 83, 80);
            this.btnDeleteGroup.Location = new Point(20, 320);
            this.btnDeleteGroup.Size = new Size(310, 45);
            this.btnDeleteGroup.Click += new System.EventHandler(this.btnDeleteGroup_Click);
            
            this.pnlGroup.Controls.Add(lblStudentList);
            this.pnlGroup.Controls.Add(dgvStudentsInClass);
            this.pnlGroup.Controls.Add(lblSubject);
            this.pnlGroup.Controls.Add(cbSubject);
            this.pnlGroup.Controls.Add(lblTeacher);
            this.pnlGroup.Controls.Add(cbTeacher);
            this.pnlGroup.Controls.Add(lblClass);
            this.pnlGroup.Controls.Add(cbClass);
            this.pnlGroup.Controls.Add(btnAddGroup);
            this.pnlGroup.Controls.Add(btnEditGroup);
            this.pnlGroup.Controls.Add(btnDeleteGroup);
            
            // ManageSubjectGroupForm
            this.ClientSize = new Size(1000, 550);
            this.Controls.Add(this.dgvGroups);
            this.Controls.Add(this.pnlGroup);
            this.Font = new Font("Segoe UI", 10F);
            this.Name = "ManageSubjectGroupForm";
            this.Text = "Quản lý Nhóm môn học (Giảng dạy)";
            this.StartPosition = FormStartPosition.CenterScreen;
            
            this.ResumeLayout(false);
        }

        private DataGridView dgvGroups;
        private DataGridView dgvStudentsInClass;
        private Panel pnlGroup;
        private Label lblSubject, lblTeacher, lblClass, lblStudentList;
        private ComboBox cbSubject, cbTeacher, cbClass;
        private RoundedButton btnAddGroup, btnEditGroup, btnDeleteGroup;
    }
}
