using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace QLDSV.Forms
{
    public partial class TeacherForm : Form
    {
        int teacherId;

        public TeacherForm(int userId)
        {
            InitializeComponent();
            teacherId = TeacherService.GetTeacherId(userId);
            LoadGroup();
            LoadStudents(Convert.ToInt32(cbGroup.SelectedValue));
        }
        //bắt đầu load form
        private void TeacherForm_Load(object sender, EventArgs e)
        {
            //load tên giáo viên
            string name = TeacherService.GetTeacherName(teacherId);
            textBox1.Text = name;
            //load môn học của giáo viên
            string subject = TeacherService.GetSubject(teacherId);
            textBox2.Text = subject;

        }
        private void LoadGroup()
        {
            var dt = TeacherService.GetGroups(teacherId);
            cbGroup.DisplayMember = "id";
            cbGroup.ValueMember = "id";
            cbGroup.DataSource = dt;
        }
        void LoadStudents(int groupId)
        {
            var dt = TeacherService.GetStudents(groupId);

            dgvDiem.DataSource = dt;
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvDiem.Rows)
            {
                if (row.IsNewRow) continue;
                int studentId = Convert.ToInt32(row.Cells["StudentID"].Value);
                int sgId = Convert.ToInt32(row.Cells["GroupID"].Value);
                object val = row.Cells["score"].Value;

                double score = 0;
                if (val != null && val != DBNull.Value && val.ToString() != "")
                {
                    score = Convert.ToDouble(val);
                }
                TeacherDB.SaveGrade(studentId, sgId, score);
            }
            MessageBox.Show("Grades saved successfully!");
        }

        private void cbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadStudents(Convert.ToInt32(cbGroup.SelectedValue));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();

            this.Close();
        }

        private void TeacherForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
        }
    }
}
