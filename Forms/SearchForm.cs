using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class SearchForm : Form
    {
        public SearchForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        }
        // Tìm kiếm sinh viên theo mã sinh viên rồi hiển thị form thông tin sinh viên
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string IdSearch = txtStudentId.Text;
            if (string.IsNullOrEmpty(IdSearch))
            {
                MessageBox.Show("Vui lòng nhập mã sinh viên");
                return;
            }
            new StudentForm(IdSearch).Show();
            this.Hide();
        }

        private void SearchForm_Load(object sender, EventArgs e)
        {

        }

        private void SearchForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
        }
    }
}
