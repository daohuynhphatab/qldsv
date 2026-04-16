namespace QLDSV.Forms
{
    partial class ReportForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.btnAll = new QLDSV.Utils.RoundedButton();
            this.btnFilter = new QLDSV.Utils.RoundedButton();
            this.cbClass = new System.Windows.Forms.ComboBox();
            this.lblClass = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.pnlFilter.SuspendLayout();
            this.SuspendLayout();
            
            // pnlFilter
            this.pnlFilter.Controls.Add(this.btnAll);
            this.pnlFilter.Controls.Add(this.btnFilter);
            this.pnlFilter.Controls.Add(this.cbClass);
            this.pnlFilter.Controls.Add(this.lblClass);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Height = 60;
            this.pnlFilter.BackColor = System.Drawing.Color.White;

            // lblClass
            this.lblClass.Text = "Chọn lớp:";
            this.lblClass.Location = new System.Drawing.Point(20, 20);
            this.lblClass.AutoSize = true;

            // cbClass
            this.cbClass.Location = new System.Drawing.Point(90, 16);
            this.cbClass.Size = new System.Drawing.Size(200, 25);
            this.cbClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // btnFilter
            this.btnFilter.Text = "🔍 Lọc kết quả";
            this.btnFilter.Location = new System.Drawing.Point(310, 10);
            this.btnFilter.Size = new System.Drawing.Size(120, 40);
            this.btnFilter.BackColor = System.Drawing.Color.FromArgb(74, 144, 226);
            this.btnFilter.ForeColor = System.Drawing.Color.White;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);

            // btnAll
            this.btnAll.Text = "📄 Hiện tất cả";
            this.btnAll.Location = new System.Drawing.Point(440, 10);
            this.btnAll.Size = new System.Drawing.Size(120, 40);
            this.btnAll.BackColor = System.Drawing.Color.FromArgb(80, 200, 120);
            this.btnAll.ForeColor = System.Drawing.Color.White;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);

            // reportViewer1
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(0, 60);

            // ReportForm
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.pnlFilter);
            this.Name = "ReportForm";
            this.Text = "Báo cáo điểm toàn khóa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.ReportForm_Load);
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Label lblClass;
        private System.Windows.Forms.ComboBox cbClass;
        private QLDSV.Utils.RoundedButton btnFilter;
        private QLDSV.Utils.RoundedButton btnAll;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}
