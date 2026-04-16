using System;
using System.Linq;
using System.Windows.Forms;
using QLDSV.Models;
using System.Drawing;

namespace QLDSV.Forms
{
    public partial class ManageUserForm : Form
    {
        private QldsvContext context;
        private User selectedUser = null;

        public ManageUserForm()
        {
            InitializeComponent();
            context = new QldsvContext();
            
            FormatGrid(dgvUsers);
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
            dgvUsers.DataSource = context.Users
                .Where(u => u.Role == "admin" || u.Role == "teacher")
                .Select(u => new { u.Id, u.Username, u.Role, u.CreatedAt })
                .ToList();
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int id = (int)dgvUsers.Rows[e.RowIndex].Cells["Id"].Value;
                selectedUser = context.Users.Find(id);
                if (selectedUser != null)
                {
                    txtUsername.Text = selectedUser.Username;
                    txtPassword.Text = selectedUser.Password;
                    cbRole.Text = selectedUser.Role;
                }
            }
        }
        
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(cbRole.Text)) return;
            var u = new User { 
                Username = txtUsername.Text, 
                Password = txtPassword.Text, 
                Role = cbRole.Text, 
                CreatedAt = DateTime.Now 
            };
            context.Users.Add(u);
            context.SaveChanges();
            LoadData();
            MessageBox.Show("Thêm User thành công");
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            if (selectedUser == null) return;
            selectedUser.Username = txtUsername.Text;
            if(!string.IsNullOrEmpty(txtPassword.Text))
                selectedUser.Password = txtPassword.Text;
            selectedUser.Role = cbRole.Text;
            context.SaveChanges();
            LoadData();
            MessageBox.Show("Sửa User thành công");
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (selectedUser == null) return;
            context.Users.Remove(selectedUser);
            context.SaveChanges();
            selectedUser = null;
            LoadData();
            MessageBox.Show("Xóa User thành công");
        }
    }
}
