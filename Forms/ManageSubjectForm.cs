using System;
using System.Linq;
using System.Windows.Forms;
using QLDSV.Models;
using System.Drawing;

namespace QLDSV.Forms
{
    public partial class ManageSubjectForm : Form
    {
        private QldsvContext context;
        private Subject selectedSubject = null;

        public ManageSubjectForm()
        {
            InitializeComponent();
            context = new QldsvContext();
            
            FormatGrid(dgvSubjects);
            LoadData();
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
            dgvSubjects.DataSource = context.Subjects.Select(s => new { s.Id, s.Name, s.Credits }).ToList();
        }

        private void dgvSubjects_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int id = (int)dgvSubjects.Rows[e.RowIndex].Cells["Id"].Value;
                selectedSubject = context.Subjects.Find(id);
                if (selectedSubject != null)
                {
                    txtSubjectName.Text = selectedSubject.Name;
                    txtSubjectCredits.Text = selectedSubject.Credits.ToString();
                }
            }
        }

        private void btnAddSubject_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtSubjectName.Text)) return;
            int.TryParse(txtSubjectCredits.Text, out int credits);
            var s = new Subject { Name = txtSubjectName.Text, Credits = credits };
            context.Subjects.Add(s);
            context.SaveChanges();
            LoadData();
            MessageBox.Show("Thêm Môn học thành công");
        }

        private void btnEditSubject_Click(object sender, EventArgs e)
        {
            if (selectedSubject == null) return;
            selectedSubject.Name = txtSubjectName.Text;
            int.TryParse(txtSubjectCredits.Text, out int credits);
            selectedSubject.Credits = credits;
            context.SaveChanges();
            LoadData();
            MessageBox.Show("Sửa Môn học thành công");
        }

        private void btnDeleteSubject_Click(object sender, EventArgs e)
        {
            if (selectedSubject == null) return;
            context.Subjects.Remove(selectedSubject);
            context.SaveChanges();
            selectedSubject = null;
            LoadData();
            MessageBox.Show("Xóa Môn học thành công");
        }
    }
}
