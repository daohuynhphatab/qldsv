using System;
using System.Linq;
using System.Windows.Forms;
using QLDSV.Models;
using System.Drawing;

namespace QLDSV.Forms
{
    public partial class ManageClassForm : Form
    {
        private QldsvContext context;
        private Class selectedClass = null;

        public ManageClassForm()
        {
            InitializeComponent();
            context = new QldsvContext();
            
            FormatGrid(dgvClasses);
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
            dgvClasses.DataSource = context.Classes.Select(c => new { c.Id, c.Name }).ToList();
        }

        private void dgvClasses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int id = (int)dgvClasses.Rows[e.RowIndex].Cells["Id"].Value;
                selectedClass = context.Classes.Find(id);
                if (selectedClass != null)
                {
                    txtClassName.Text = selectedClass.Name;
                }
            }
        }
        
        private void btnAddClass_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtClassName.Text)) return;
            var c = new Class { Name = txtClassName.Text };
            context.Classes.Add(c);
            context.SaveChanges();
            LoadData();
            MessageBox.Show("Thêm Lớp thành công");
        }

        private void btnEditClass_Click(object sender, EventArgs e)
        {
            if (selectedClass == null) return;
            selectedClass.Name = txtClassName.Text;
            context.SaveChanges();
            LoadData();
            MessageBox.Show("Sửa Lớp thành công");
        }

        private void btnDeleteClass_Click(object sender, EventArgs e)
        {
            if (selectedClass == null) return;
            context.Classes.Remove(selectedClass);
            context.SaveChanges();
            selectedClass = null;
            LoadData();
            MessageBox.Show("Xóa Lớp thành công");
        }
    }
}
