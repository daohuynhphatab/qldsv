using Microsoft.Reporting.WinForms;
using QLDSV.Logic;
using QLDSV.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace QLDSV.Forms
{
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            LoadClasses();
            ShowReport();
        }

        private void LoadClasses()
        {
            var classes = ReportService.GetAllClasses();
            cbClass.DataSource = classes;
            cbClass.DisplayMember = "Name";
            cbClass.ValueMember = "Id";
            cbClass.SelectedIndex = -1;
        }

        private void ShowReport(int? classId = null, string description = "(Tất cả các lớp)")
        {
            try
            {
                DataTable data = ReportService.GetBaoCaoDiemToanKhoaDataTable(classId);
                
                reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource rds = new ReportDataSource("DataSetBaoCao", data);
                reportViewer1.LocalReport.DataSources.Add(rds);

                // Đường dẫn file RDLC - trong môi trường dev thường ở thư mục Reports của project
                // Trong môi trường build có thể cần copy file này vào output
                string reportPath = Path.Combine(Application.StartupPath, "Reports", "rptBaoCaoDiem.rdlc");
                
                // Nếu không thấy ở bin, thử lùi ra ngoài (trường hợp chạy từ VS dự án .NET 8)
                if (!File.Exists(reportPath))
                {
                    reportPath = Path.Combine(Directory.GetParent(Application.StartupPath).Parent.Parent.FullName, "Reports", "rptBaoCaoDiem.rdlc");
                }

                if (File.Exists(reportPath))
                {
                    reportViewer1.LocalReport.ReportPath = reportPath;
                }
                else
                {
                    // Fallback hoặc báo lỗi
                    MessageBox.Show("Không tìm thấy file báo cáo tại: " + reportPath, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Set parameter
                ReportParameter[] param = new ReportParameter[1];
                param[0] = new ReportParameter("MoTaKetQua", description);
                reportViewer1.LocalReport.SetParameters(param);

                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;
                
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị báo cáo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (cbClass.SelectedValue != null)
            {
                int id = (int)cbClass.SelectedValue;
                string name = cbClass.Text;
                ShowReport(id, $"Lớp: {name}");
            }
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            cbClass.SelectedIndex = -1;
            ShowReport();
        }
    }
}
