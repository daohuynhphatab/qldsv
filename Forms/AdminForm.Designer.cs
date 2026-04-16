using System.Drawing;
using System.Windows.Forms;
using QLDSV.Utils;

namespace QLDSV.Forms
{
    partial class AdminForm
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
            pnlTop = new Panel();
            btnLogout = new RoundedButton();
            lblTitle = new Label();
            btnManageUsers = new RoundedButton();
            btnManageClasses = new RoundedButton();
            btnManageSubjects = new RoundedButton();
            btnManageStudents = new RoundedButton();
            btnManageTeachers = new RoundedButton();
            btnManageGroups = new RoundedButton();
            btnReport = new RoundedButton();
            pnlTop.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.White;
            pnlTop.Controls.Add(btnLogout);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(800, 60);
            pnlTop.TabIndex = 8;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(239, 83, 80);
            btnLogout.BorderRadius = 20;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(650, 10);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(130, 40);
            btnLogout.TabIndex = 0;
            btnLogout.Text = "🚪 Đăng xuất";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(33, 37, 41);
            lblTitle.Location = new Point(0, 100);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(800, 40);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "BẢNG ĐIỀU KHIỂN QUẢN TRỊ VIÊN";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnManageUsers
            // 
            btnManageUsers.BackColor = Color.FromArgb(74, 144, 226);
            btnManageUsers.BorderRadius = 20;
            btnManageUsers.FlatStyle = FlatStyle.Flat;
            btnManageUsers.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnManageUsers.ForeColor = Color.White;
            btnManageUsers.Location = new Point(50, 160);
            btnManageUsers.Name = "btnManageUsers";
            btnManageUsers.Size = new Size(220, 120);
            btnManageUsers.TabIndex = 1;
            btnManageUsers.Text = "👤 Quản lý User";
            btnManageUsers.UseVisualStyleBackColor = false;
            btnManageUsers.Click += btnManageUsers_Click;
            // 
            // btnManageClasses
            // 
            btnManageClasses.BackColor = Color.FromArgb(80, 200, 120);
            btnManageClasses.BorderRadius = 20;
            btnManageClasses.FlatStyle = FlatStyle.Flat;
            btnManageClasses.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnManageClasses.ForeColor = Color.White;
            btnManageClasses.Location = new Point(290, 160);
            btnManageClasses.Name = "btnManageClasses";
            btnManageClasses.Size = new Size(220, 120);
            btnManageClasses.TabIndex = 2;
            btnManageClasses.Text = "🏫 Quản lý Lớp";
            btnManageClasses.UseVisualStyleBackColor = false;
            btnManageClasses.Click += btnManageClasses_Click;
            // 
            // btnManageSubjects
            // 
            btnManageSubjects.BackColor = Color.FromArgb(155, 89, 182);
            btnManageSubjects.BorderRadius = 20;
            btnManageSubjects.FlatStyle = FlatStyle.Flat;
            btnManageSubjects.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnManageSubjects.ForeColor = Color.White;
            btnManageSubjects.Location = new Point(50, 300);
            btnManageSubjects.Name = "btnManageSubjects";
            btnManageSubjects.Size = new Size(220, 120);
            btnManageSubjects.TabIndex = 3;
            btnManageSubjects.Text = "📚 Quản lý Môn";
            btnManageSubjects.UseVisualStyleBackColor = false;
            btnManageSubjects.Click += btnManageSubjects_Click;
            // 
            // btnManageStudents
            // 
            btnManageStudents.BackColor = Color.FromArgb(243, 156, 18);
            btnManageStudents.BorderRadius = 20;
            btnManageStudents.FlatStyle = FlatStyle.Flat;
            btnManageStudents.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnManageStudents.ForeColor = Color.White;
            btnManageStudents.Location = new Point(530, 160);
            btnManageStudents.Name = "btnManageStudents";
            btnManageStudents.Size = new Size(220, 120);
            btnManageStudents.TabIndex = 4;
            btnManageStudents.Text = "🎓 Quản lý SV";
            btnManageStudents.UseVisualStyleBackColor = false;
            btnManageStudents.Click += btnManageStudents_Click;
            // 
            // btnManageTeachers
            // 
            btnManageTeachers.BackColor = Color.FromArgb(41, 128, 185);
            btnManageTeachers.BorderRadius = 20;
            btnManageTeachers.FlatStyle = FlatStyle.Flat;
            btnManageTeachers.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnManageTeachers.ForeColor = Color.White;
            btnManageTeachers.Location = new Point(290, 300);
            btnManageTeachers.Name = "btnManageTeachers";
            btnManageTeachers.Size = new Size(220, 120);
            btnManageTeachers.TabIndex = 5;
            btnManageTeachers.Text = "👨‍🏫 Quản lý GV";
            btnManageTeachers.UseVisualStyleBackColor = false;
            btnManageTeachers.Click += btnManageTeachers_Click;
            // 
            // btnManageGroups
            // 
            btnManageGroups.BackColor = Color.FromArgb(52, 73, 94);
            btnManageGroups.BorderRadius = 20;
            btnManageGroups.FlatStyle = FlatStyle.Flat;
            btnManageGroups.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnManageGroups.ForeColor = Color.White;
            btnManageGroups.Location = new Point(530, 300);
            btnManageGroups.Name = "btnManageGroups";
            btnManageGroups.Size = new Size(220, 120);
            btnManageGroups.TabIndex = 6;
            btnManageGroups.Text = "👥 Nhóm Môn";
            btnManageGroups.UseVisualStyleBackColor = false;
            btnManageGroups.Click += btnManageGroups_Click;
            // 
            // btnReport
            // 
            btnReport.BackColor = Color.FromArgb(231, 76, 60);
            btnReport.BorderRadius = 20;
            btnReport.FlatStyle = FlatStyle.Flat;
            btnReport.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnReport.ForeColor = Color.White;
            btnReport.Location = new Point(290, 443);
            btnReport.Name = "btnReport";
            btnReport.Size = new Size(220, 100);
            btnReport.TabIndex = 7;
            btnReport.Text = "📊 Báo cáo điểm";
            btnReport.UseVisualStyleBackColor = false;
            btnReport.Click += btnReport_Click;
            // 
            // AdminForm
            // 
            ClientSize = new Size(800, 600);
            Controls.Add(lblTitle);
            Controls.Add(btnManageUsers);
            Controls.Add(btnManageClasses);
            Controls.Add(btnManageSubjects);
            Controls.Add(btnManageStudents);
            Controls.Add(btnManageTeachers);
            Controls.Add(btnManageGroups);
            Controls.Add(btnReport);
            Controls.Add(pnlTop);
            Font = new Font("Segoe UI", 10F);
            Name = "AdminForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dashboard Quản trị";
            FormClosing += AdminForm_FormClosing;
            pnlTop.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Panel pnlTop;
        private RoundedButton btnLogout;
        private Label lblTitle;
        private RoundedButton btnManageUsers;
        private RoundedButton btnManageClasses;
        private RoundedButton btnManageSubjects;
        private RoundedButton btnManageStudents;
        private RoundedButton btnManageTeachers;
        private RoundedButton btnManageGroups;
        private RoundedButton btnReport;
    }
}
