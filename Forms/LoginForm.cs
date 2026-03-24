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
            var conn = DB.GetConnection();
            conn.Open();

            string query = "SELECT * FROM users WHERE username=@u AND password=@p";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@u", txtUsername.Text);
            cmd.Parameters.AddWithValue("@p", txtPassword.Text);

            var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                string role = reader["role"].ToString();
                string subject_id = reader["subject_id"].ToString();

                if (role == "teacher")
                {
                    TeacherForm f = new TeacherForm(subject_id);
                    f.Show();
                }
                else
                {
                    MessageBox.Show("Admin chưa làm 😏");
                }

                this.Hide();
            }
            else
            {
                MessageBox.Show("Sai tài khoản!");
            }

            conn.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StudentForm f = new StudentForm();
            f.Show();
        }
    }
}
