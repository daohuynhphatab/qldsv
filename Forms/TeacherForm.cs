using MySql.Data.MySqlClient;
using QLDSV.Models;
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
using QLDSV.Utils;
using System.Xml.Linq;

namespace QLDSV.Forms
{
    public partial class TeacherForm : Form
    {
        int teacherId;

        public TeacherForm(int userId)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            UiTheme.ApplyTheme(this);
            teacherId = TeacherService.GetTeacherId(userId);
        }
        //bắt đầu load form
        private void TeacherForm_Load(object sender, EventArgs e)
        {
            LoadGroup();
            if (cbGroup.Items.Count >0 && cbGroup.SelectedValue != null)
            {
                LoadStudents(Convert.ToInt32(cbGroup.SelectedValue));
            }
            //load tên giáo viên
            string name = TeacherService.GetTeacherName(teacherId);
            textBox1.Text = name;
            //load môn học của giáo viên
            string subject = TeacherService.GetSubject(teacherId);
            textBox2.Text = subject;
            //load danh sach sinh vien theo nhóm
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
            var list = new BindingList<StudentDTO>(TeacherService.GetStudents(groupId));
            dgvDiem.DataSource = list;

            ConfigureGrid();
        }

        private void ConfigureGrid()
        {
            // Ensure columns are set up predictably
            dgvDiem.AutoGenerateColumns = false;

            // Build columns if not present
            if (dgvDiem.Columns.Count ==0)
            {
                var colId = new DataGridViewTextBoxColumn()
                {
                    Name = "Mssv",
                    HeaderText = "MSSV",
                    DataPropertyName = "Mssv",
                    ReadOnly = true,
                    FillWeight = 20
                };
                var colName = new DataGridViewTextBoxColumn()
                {
                    Name = "Name",
                    HeaderText = "Họ và tên",
                    DataPropertyName = "Name",
                    ReadOnly = true,
                    FillWeight = 40
                };
                var colGroup = new DataGridViewTextBoxColumn()
                {
                    Name = "GroupID",
                    HeaderText = "Nhóm",
                    DataPropertyName = "GroupID",
                    ReadOnly = true,
                    Visible = false
                };
                var colScore = new DataGridViewTextBoxColumn()
                {
                    Name = "Score",
                    HeaderText = "Điểm",
                    DataPropertyName = "Score",
                    ReadOnly = false,
                    FillWeight =25,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "N2", NullValue = "0.00" }
                };

                dgvDiem.Columns.AddRange(new DataGridViewColumn[] { colId, colName, colGroup, colScore });
            }

            dgvDiem.CellValidating -= DgvDiem_CellValidating;
            dgvDiem.CellValidating += DgvDiem_CellValidating;

            dgvDiem.CellEndEdit -= DgvDiem_CellEndEdit;
            dgvDiem.CellEndEdit += DgvDiem_CellEndEdit;
        }

        private void DgvDiem_CellValidating(object? sender, DataGridViewCellValidatingEventArgs e)
        {
            // Validate only the Score column
            if (dgvDiem.Columns[e.ColumnIndex].Name != "Score") return;

            var str = (e.FormattedValue ?? "").ToString().Trim();
            if (string.IsNullOrEmpty(str))
            {
                // allow empty - will be treated as0
                return;
            }
            if (!double.TryParse(str, out double val))
            {
                e.Cancel = true;
                MessageBox.Show("Giá trị điểm phải là số hợp lệ (ví dụ:7.50).", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (val <0 || val >10)
            {
                e.Cancel = true;
                MessageBox.Show("Điểm phải trong khoảng0 đến10.", "Lỗi phạm vi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DgvDiem_CellEndEdit(object? sender, DataGridViewCellEventArgs e)
        {
            // Format numeric value to2 decimals
            if (dgvDiem.Columns[e.ColumnIndex].Name != "Score") return;

            var cell = dgvDiem.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (cell.Value == null || cell.Value == DBNull.Value || string.IsNullOrEmpty(cell.Value.ToString()))
            {
                cell.Value =0.00;
            }
            else
            {
                if (double.TryParse(cell.Value.ToString(), out double v))
                {
                    cell.Value = Math.Round(v,2);
                }
                else
                {
                    cell.Value =0.00;
                }
            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvDiem.Rows)
            {
                if (row.IsNewRow) continue;
                string mssv = row.Cells["Mssv"].Value?.ToString() ?? "";
                if (string.IsNullOrEmpty(mssv)) continue;

                int studentId = StudentService.getStudentId(mssv);
                int sgId = 0;
                if (row.Cells["GroupID"].Value != null)
                {
                    int.TryParse(row.Cells["GroupID"].Value.ToString(), out sgId);
                }
                object val = row.Cells["Score"].Value;

                double score = 0;
                if (val != null && val != DBNull.Value && val.ToString() != "")
                {
                    double.TryParse(val.ToString(), out score);
                }
                TeacherService.SaveGrade(studentId, sgId, score);
            }
            MessageBox.Show("Lưu điểm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbGroup.SelectedValue != null)
                LoadStudents(Convert.ToInt32(cbGroup.SelectedValue));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TeacherForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
        }
    }
}
