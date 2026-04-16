using System;
using System.Linq;
using System.Windows.Forms;
using QLDSV.Models;
using System.Drawing;
using Microsoft.EntityFrameworkCore;

namespace QLDSV.Forms
{
    public partial class ManageSubjectGroupForm : Form
    {
        private QldsvContext context;
        private SubjectGroup selectedGroup = null;

        public ManageSubjectGroupForm()
        {
            InitializeComponent();
            context = new QldsvContext();
            
            FormatGrid(dgvGroups);
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
            dgvGroups.DataSource = context.SubjectGroups
                .AsNoTracking()
                .Include(sg => sg.Subject)
                .Include(sg => sg.Teacher)
                    .ThenInclude(t => t.User)
                .Include(sg => sg.Class)
                .Select(sg => new { 
                    sg.Id, 
                    SubjectName = sg.Subject != null ? sg.Subject.Name : "N/A",
                    TeacherName = (sg.Teacher != null && sg.Teacher.User != null) ? sg.Teacher.User.Username : "N/A",
                    ClassName = sg.Class != null ? sg.Class.Name : "N/A"
                }).ToList();
        }

        private void LoadComboBoxes()
        {
            cbSubject.DataSource = context.Subjects.ToList();
            cbSubject.DisplayMember = "Name";
            cbSubject.ValueMember = "Id";

            cbTeacher.DataSource = context.Teachers.Include(t=>t.User).ToList();
            cbTeacher.DisplayMember = "Id"; // fallback
            // Try to show username
            // Show teacher actual name
            var teacherList = context.Teachers.AsNoTracking().Select(t => new { 
                t.Id, 
                DisplayName = t.Name 
            }).ToList();
            cbTeacher.DataSource = teacherList;
            cbTeacher.DisplayMember = "DisplayName";
            cbTeacher.ValueMember = "Id";

            cbClass.DataSource = context.Classes.AsNoTracking().ToList();
            cbClass.DisplayMember = "Name";
            cbClass.ValueMember = "Id";

            cbSubject.SelectedIndex = -1;
            cbTeacher.SelectedIndex = -1;
            cbClass.SelectedIndex = -1;

            cbClass.SelectedIndexChanged += (s, e) => LoadStudentsInClass();
        }

        private void LoadStudentsInClass()
        {
            if (cbClass.SelectedValue is int classId)
            {
                dgvStudentsInClass.DataSource = context.Students
                    .AsNoTracking()
                    .Where(s => s.ClassId == classId)
                    .Select(s => new { s.Mssv, s.Name })
                    .ToList();
            }
            else
            {
                dgvStudentsInClass.DataSource = null;
            }
        }

        private void dgvGroups_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int id = (int)dgvGroups.Rows[e.RowIndex].Cells["Id"].Value;
                selectedGroup = context.SubjectGroups.Find(id);
                if (selectedGroup != null)
                {
                    cbSubject.SelectedValue = selectedGroup.SubjectId;
                    cbTeacher.SelectedValue = selectedGroup.TeacherId;
                    cbClass.SelectedValue = selectedGroup.ClassId;
                }
            }
        }
        
        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            if(cbSubject.SelectedValue == null || cbTeacher.SelectedValue == null || cbClass.SelectedValue == null) 
            {
                MessageBox.Show("Vui lòng chọn đầy đủ Môn, Giảng viên và Lớp");
                return;
            }

            var sg = new SubjectGroup { 
                SubjectId = (int)cbSubject.SelectedValue,
                TeacherId = (int)cbTeacher.SelectedValue,
                ClassId = (int)cbClass.SelectedValue
            };
            context.SubjectGroups.Add(sg);
            context.SaveChanges();
            LoadData();
            MessageBox.Show("Tạo Nhóm môn học thành công");
        }

        private void btnEditGroup_Click(object sender, EventArgs e)
        {
            if (selectedGroup == null) return;
            selectedGroup.SubjectId = (int)cbSubject.SelectedValue;
            selectedGroup.TeacherId = (int)cbTeacher.SelectedValue;
            selectedGroup.ClassId = (int)cbClass.SelectedValue;
            
            context.SaveChanges();
            LoadData();
            MessageBox.Show("Sửa Nhóm môn học thành công");
        }

        private void btnDeleteGroup_Click(object sender, EventArgs e)
        {
            if (selectedGroup == null) return;
            var confirmResult = MessageBox.Show("Xóa nhóm này sẽ ảnh hưởng đến điểm số liên quan. Bạn có chắc chắn?", "Cảnh báo", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                context.SubjectGroups.Remove(selectedGroup);
                context.SaveChanges();
                selectedGroup = null;
                LoadData();
                MessageBox.Show("Xóa Nhóm môn học thành công");
            }
        }
    }
}
