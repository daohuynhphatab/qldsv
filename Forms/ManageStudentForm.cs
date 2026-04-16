using System;
using System.Linq;
using System.Windows.Forms;
using QLDSV.Models;
using System.Drawing;
using Microsoft.EntityFrameworkCore;

namespace QLDSV.Forms
{
    public partial class ManageStudentForm : Form
    {
        private QldsvContext context;
        private Student selectedStudent = null;

        public ManageStudentForm()
        {
            InitializeComponent();
            context = new QldsvContext();
            
            FormatGrid(dgvStudents);
            LoadData();
            LoadComboBoxes();
        }

        private void FormatGrid(DataGridView dgv)
        {
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.RowHeadersVisible = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.BorderStyle = BorderStyle.None;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 244, 248);
        }

        private void LoadData()
        {
            dgvStudents.DataSource = context.Students
                .Include(s => s.Class)
                .Select(s => new { 
                    s.Id, 
                    s.Mssv, 
                    s.Name, 
                    ClassName = s.Class != null ? s.Class.Name : "N/A",
                }).ToList();
        }

        private void LoadComboBoxes()
        {
            cbClass.DataSource = context.Classes.ToList();
            cbClass.DisplayMember = "Name";
            cbClass.ValueMember = "Id";

            // Only show users with 'student' role or no specific role yet if applicable, 
            // but since user wants only admin/teacher, maybe students don't have user accounts?
            // User said: "student chỉ có thể tra cứu điểm thông qua mssv".
            // This implies they don't necessarily login. 
            // However, the Student model has UserId. I'll allow linking to any user for now.
            cbUser.DataSource = context.Users.ToList();
            cbUser.DisplayMember = "Username";
            cbUser.ValueMember = "Id";
            cbUser.SelectedIndex = -1;
        }

        private void dgvStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int id = (int)dgvStudents.Rows[e.RowIndex].Cells["Id"].Value;
                selectedStudent = context.Students.Find(id);
                if (selectedStudent != null)
                {
                    txtMSSV.Text = selectedStudent.Mssv;
                    txtName.Text = selectedStudent.Name;
                    cbClass.SelectedValue = selectedStudent.ClassId;
                    //cbUser.SelectedValue = selectedStudent.UserId;
                }
            }
        }
        
        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtMSSV.Text) || string.IsNullOrEmpty(txtName.Text)) 
            {
                MessageBox.Show("Vui lòng nhập MSSV và Họ tên");
                return;
            }

            var s = new Student { 
                Mssv = txtMSSV.Text, 
                Name = txtName.Text,
                ClassId = (int?)cbClass.SelectedValue,
                UserId = (int?)cbUser.SelectedValue
            };
            context.Students.Add(s);
            context.SaveChanges();
            LoadData();
            MessageBox.Show("Thêm Sinh viên thành công");
        }

        private void btnEditStudent_Click(object sender, EventArgs e)
        {
            if (selectedStudent == null) return;
            selectedStudent.Mssv = txtMSSV.Text;
            selectedStudent.Name = txtName.Text;
            selectedStudent.ClassId = (int?)cbClass.SelectedValue;
            selectedStudent.UserId = (int?)cbUser.SelectedValue;
            
            context.SaveChanges();
            LoadData();
            MessageBox.Show("Sửa Sinh viên thành công");
        }

        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            if (selectedStudent == null) return;
            var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa sinh viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                context.Students.Remove(selectedStudent);
                context.SaveChanges();
                selectedStudent = null;
                LoadData();
                MessageBox.Show("Xóa Sinh viên thành công");
            }
        }
    }
}
