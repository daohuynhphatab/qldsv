using MySql.Data.MySqlClient;
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
        public StudentForm()
        {
            InitializeComponent();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            var conn = DB.GetConnection();
            conn.Open();

            string query = @"
            SELECT 
                s.mssv,
                s.name,
                IFNULL(GROUP_CONCAT(CONCAT(sub.name, ': ', g.score) SEPARATOR ' | '),'Chưa có điểm') AS subjects
            FROM students s
            LEFT JOIN grades g ON s.mssv = g.mssv
            LEFT JOIN subjects sub ON g.subject_id = sub.id
            WHERE s.mssv = @m
            GROUP BY s.mssv, s.name
            ";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@m", txtMSSV.Text);

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Columns["subjects"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            conn.Close();
        }


    }
}
