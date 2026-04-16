using System;
using System.Drawing;
using System.Windows.Forms;

namespace QLDSV.Forms
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            var form = new ManageUserForm();
            form.ShowDialog();
        }

        private void btnManageClasses_Click(object sender, EventArgs e)
        {
            var form = new ManageClassForm();
            form.ShowDialog();
        }

        private void btnManageSubjects_Click(object sender, EventArgs e)
        {
            var form = new ManageSubjectForm();
            form.ShowDialog();
        }

        private void btnManageStudents_Click(object sender, EventArgs e)
        {
            var form = new ManageStudentForm();
            form.ShowDialog();
        }

        private void btnManageTeachers_Click(object sender, EventArgs e)
        {
            var form = new ManageTeacherForm();
            form.ShowDialog();
        }

        private void btnManageGroups_Click(object sender, EventArgs e)
        {
            var form = new ManageSubjectGroupForm();
            form.ShowDialog();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            var form = new ReportForm();
            form.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AdminForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
        }
    }
}
