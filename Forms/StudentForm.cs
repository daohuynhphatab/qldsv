using QLDSV.Model;
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
    public partial class StudentForm : Form
    {
        string StudentId;
        public StudentForm(string IdSearch)
        {
            InitializeComponent();
            StudentId = IdSearch;
        }

        //load form thông tin sinh viên
        private void StudentForm_Load(object sender, EventArgs e)
        {

            // Hiển thị thông tin sinh viên lên form
            label8.Text = StudentId;

            string name = StudentService.GetStudentName(StudentId);
            label9.Text = name;

            string classes = StudentService.GetStudentClass(StudentId);
            label10.Text = classes;

            // Hiển thị điểm sinh viên lên textbox tương ứng
            Score s = StudentService.GetGrades(StudentId);

            textBox1.Text = s.LTQL.ToString();
            textBox2.Text = s.CSDL.ToString();
            textBox3.Text = s.MMT.ToString();
            textBox4.Text = s.Average.ToString("0.00");
        }

        private void StudentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SearchForm search = new SearchForm();
            search.Show();
        }
    }
}
