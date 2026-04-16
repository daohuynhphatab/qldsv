using System;
using System.Linq;
using System.Windows.Forms;
using QLDSV.Models;
using System.Drawing;
using Microsoft.EntityFrameworkCore;

namespace QLDSV.Forms
{
    public partial class ManageTeacherForm : Form
    {
        private QldsvContext context;
        private Teacher selectedTeacher = null;

        public ManageTeacherForm()
        {
            InitializeComponent();
            context = new QldsvContext();
            
            FormatGrid(dgvTeachers);
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
            dgvTeachers.DataSource = context.Teachers
                .AsNoTracking()
                .Include(t => t.User)
                .Select(t => new { 
                    t.Id, 
                    t.Name, 
                    Username = t.User != null ? t.User.Username : "N/A"
                }).ToList();
        }

        private void LoadComboBoxes()
        {
            // Only show users with 'teacher' role
            cbUser.DataSource = context.Users
                .AsNoTracking()
                .Where(u => u.Role == "teacher")
                .ToList();
            cbUser.DisplayMember = "Username";
            cbUser.ValueMember = "Id";
            cbUser.SelectedIndex = -1;
        }

        private void dgvTeachers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int id = (int)dgvTeachers.Rows[e.RowIndex].Cells["Id"].Value;
                selectedTeacher = context.Teachers.Find(id);
                if (selectedTeacher != null)
                {
                    txtName.Text = selectedTeacher.Name;
                    cbUser.SelectedValue = selectedTeacher.UserId;
                }
            }
        }
        
        private void btnAddTeacher_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtName.Text)) 
            {
                MessageBox.Show("Vui lòng nhập Họ tên giảng viên");
                return;
            }

            var t = new Teacher { 
                Name = txtName.Text,
                UserId = (int?)cbUser.SelectedValue
            };
            context.Teachers.Add(t);
            context.SaveChanges();
            LoadData();
            MessageBox.Show("Thêm Giảng viên thành công");
        }

        private void btnEditTeacher_Click(object sender, EventArgs e)
        {
            if (selectedTeacher == null) return;
            selectedTeacher.Name = txtName.Text;
            selectedTeacher.UserId = (int?)cbUser.SelectedValue;
            
            context.SaveChanges();
            LoadData();
            MessageBox.Show("Sửa Giảng viên thành công");
        }

        private void btnDeleteTeacher_Click(object sender, EventArgs e)
        {
            if (selectedTeacher == null) return;
            var confirmResult = MessageBox.Show("Xóa giảng viên này sẽ ảnh hưởng đến các Nhóm môn họ đang dạy. Tiếp tục?", "Xác nhận xóa", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                context.Teachers.Remove(selectedTeacher);
                context.SaveChanges();
                selectedTeacher = null;
                LoadData();
                MessageBox.Show("Xóa Giảng viên thành công");
            }
        }
    }
}
