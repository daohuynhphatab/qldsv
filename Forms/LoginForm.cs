using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDSV.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            int userId;
            string role = AuthService.Login(txtUser.Text, txtPass.Text, out userId);

            if (role == null)
            {
                MessageBox.Show("Sai tài khoản");
                return;
            }
            else if (role == "teacher")
                new TeacherForm(userId).Show();
 //           else
 //               new AdminForm().Show();

            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SearchForm f = new SearchForm();
            f.Show();
            this.Hide();
        }
    }
}
