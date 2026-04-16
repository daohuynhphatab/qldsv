using QLDSV.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace QLDSV.Forms
{
    public partial class StudentForm : Form
    {
        string mssv;
        int studentId;
        public StudentForm(string IdSearch)
        {
            InitializeComponent();
            mssv = IdSearch;
            studentId = StudentService.getStudentId(mssv);
            StartPosition = FormStartPosition.CenterScreen;
            Font = new Font("Segoe UI",9F, FontStyle.Regular, GraphicsUnit.Point);

            // wire up button events
            button1.Click += Button1_Click; // In bảng điểm
            button2.Click += Button2_Click; // Khiếu nại điểm
        }

        private void Button2_Click(object? sender, EventArgs e)
        {
            // Show contact info for complaints
            string contact = "Phòng Đào tạo - Trường Đại học An Giang\nĐịa chỉ:\nEmail: \nSĐT: ";
            MessageBox.Show(contact, "Thông tin liên hệ khiếu nại điểm", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Button1_Click(object? sender, EventArgs e)
        {
            try
            {
                // Prepare data
                GradeDTO s = StudentService.GetGrade(studentId);
                string studentName = StudentService.GetStudentName(studentId);
                string studentClass = StudentService.GetStudentClass(studentId);

                using var wb = new XLWorkbook();
                var ws = wb.Worksheets.Add("Bảng điểm");

                ws.Cell(1,1).Value = "Mã số sinh viên";
                ws.Cell(1,2).Value = mssv;
                ws.Cell(2,1).Value = "Họ và tên";
                ws.Cell(2,2).Value = studentName;
                ws.Cell(3,1).Value = "Lớp";
                ws.Cell(3,2).Value = studentClass;

                ws.Cell(5,1).Value = "Môn học";
                ws.Cell(5,2).Value = "Điểm";

                int row = 6;
                foreach (var subject in s.SubjectGrades)
                {
                    ws.Cell(row, 1).Value = subject.Key;
                    ws.Cell(row, 2).Value = subject.Value;
                    row++;
                }

                ws.Cell(row, 1).Value = "Điểm trung bình";
                ws.Cell(row, 2).Value = s.Average;

                // Formatting
                var headerRange = ws.Range("A5:B5");
                headerRange.Style.Font.Bold = true;
                headerRange.Style.Fill.BackgroundColor = XLColor.LightGray;

                ws.Columns().AdjustToContents();

                using SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel Workbook|*.xlsx";
                sfd.FileName = $"BangDiem_{mssv}.xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    wb.SaveAs(sfd.FileName);
                    MessageBox.Show($"Đã xuất thành công: {sfd.FileName}", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất file: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //load form thông tin sinh viên
        private void StudentForm_Load(object sender, EventArgs e)
        {

            // Hiển thị thông tin sinh viên lên form
            label8.Text = mssv;

            string name = StudentService.GetStudentName(studentId);
            label9.Text = name;

            string classes = StudentService.GetStudentClass(studentId);
            label10.Text = classes;

            //Hiển thị điểm sinh viên lên textbox tương ứng
            GradeDTO s = StudentService.GetGrade(studentId);

            // Hiển thị động các môn học và tên môn
            var subjects = s.SubjectGrades.Keys.ToList();
            if (subjects.Count > 0)
            {
                label1.Text = subjects[0];
                textBox1.Text = s.SubjectGrades[subjects[0]]?.ToString() ?? "";
            }
            if (subjects.Count > 1)
            {
                label2.Text = subjects[1];
                textBox2.Text = s.SubjectGrades[subjects[1]]?.ToString() ?? "";
            }
            if (subjects.Count > 2)
            {
                label3.Text = subjects[2];
                textBox3.Text = s.SubjectGrades[subjects[2]]?.ToString() ?? "";
            }
            
            textBox4.Text = s.Average.ToString("0.00");
        }

        private void StudentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SearchForm search = new SearchForm();
            search.Show();
        }
    }
}
