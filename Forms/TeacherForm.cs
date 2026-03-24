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
        string subject_id;

        public TeacherForm(string sid)
        {
            InitializeComponent();
            subject_id = sid;
            LoadData();
        }
        void LoadData()
        {
            var conn = DB.GetConnection();
            conn.Open();

            string query = @"
            SELECT g.id, s.mssv, s.name, sub.name AS subject, g.score
            FROM students s
            LEFT JOIN grades g 
                ON s.mssv = g.mssv AND g.subject_id = @sid
            JOIN subjects sub ON sub.id = @sid
            ";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@sid", subject_id);

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView.DataSource = dt;

            conn.Close();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var conn = DB.GetConnection();
            conn.Open();

            if (selectedId == -1)
            {
                // INSERT
                string insert = "INSERT INTO grades(mssv, subject_id, score) VALUES (@m,@s,@sc)";
                MySqlCommand cmd = new MySqlCommand(insert, conn);

                cmd.Parameters.AddWithValue("@m", txtMSSV.Text);
                cmd.Parameters.AddWithValue("@s", subject_id);
                cmd.Parameters.AddWithValue("@sc", txtScore.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm thành công!");
            }
            else
            {
                // UPDATE
                string update = "UPDATE grades SET score=@sc WHERE id=@id";
                MySqlCommand cmd = new MySqlCommand(update, conn);

                cmd.Parameters.AddWithValue("@sc", txtScore.Text);
                cmd.Parameters.AddWithValue("@id", selectedId);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Cập nhật thành công!");
            }

            conn.Close();

            selectedId = -1;
            LoadData();
        }
        int selectedId = -1;

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridView.Rows[e.RowIndex];

                if (row.Cells["id"].Value != DBNull.Value)
                {
                    selectedId = Convert.ToInt32(row.Cells["id"].Value);
                }
                else
                {
                    selectedId = -1; // chưa có điểm → insert
                }
                txtMSSV.Text = row.Cells["mssv"].Value.ToString();
                txtName.Text = row.Cells["name"].Value.ToString();
                txtScore.Text = row.Cells["score"].Value.ToString();
            }
        }

    }
}
