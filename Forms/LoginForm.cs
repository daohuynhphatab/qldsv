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
            AuthService auth = new AuthService();

            int userId;
            var role = auth.Login(txtUser.Text, txtPass.Text, out userId);

            if (role != null)
            {
                if (role == "admin")
                {
                    AdminForm f = new AdminForm();
                    f.Show();
                }
                else
                {
                    TeacherForm f = new TeacherForm(userId);
                    f.Show();
                }
                this.Hide();
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SearchForm f = new SearchForm();
            f.Show();
            this.Hide();
        }
    }
}
