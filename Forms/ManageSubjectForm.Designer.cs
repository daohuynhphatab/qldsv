using System.Drawing;
using System.Windows.Forms;
using QLDSV.Utils;

namespace QLDSV.Forms
{
    partial class ManageSubjectForm
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
            this.dgvSubjects = new DataGridView();
            this.pnlSubject = new Panel();
            this.lblSubjectName = new Label();
            this.txtSubjectName = new TextBox();
            this.lblSubjectCredits = new Label();
            this.txtSubjectCredits = new TextBox();
            this.btnAddSubject = new RoundedButton();
            this.btnEditSubject = new RoundedButton();
            this.btnDeleteSubject = new RoundedButton();
            
            this.SuspendLayout();

            this.dgvSubjects.Dock = DockStyle.Fill;
            this.dgvSubjects.BackgroundColor = Color.White;
            this.dgvSubjects.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvSubjects.CellClick += new DataGridViewCellEventHandler(this.dgvSubjects_CellClick);
            
            this.pnlSubject.Dock = DockStyle.Right;
            this.pnlSubject.Width = 300;
            this.pnlSubject.BackColor = Color.FromArgb(240, 244, 248);
            
            this.lblSubjectName.Text = "Tên môn:";
            this.lblSubjectName.Location = new Point(20, 30);
            this.lblSubjectName.AutoSize = true;
            this.txtSubjectName.Location = new Point(20, 55);
            this.txtSubjectName.Width = 260;
            
            this.lblSubjectCredits.Text = "Số tín chỉ:";
            this.lblSubjectCredits.Location = new Point(20, 90);
            this.lblSubjectCredits.AutoSize = true;
            this.txtSubjectCredits.Location = new Point(20, 115);
            this.txtSubjectCredits.Width = 260;

            this.btnAddSubject.Text = "➕ Thêm";
            this.btnAddSubject.BackColor = Color.FromArgb(74, 144, 226);
            this.btnAddSubject.Location = new Point(20, 175);
            this.btnAddSubject.Size = new Size(125, 40);
            this.btnAddSubject.Click += new System.EventHandler(this.btnAddSubject_Click);
            
            this.btnEditSubject.Text = "✏ Sửa";
            this.btnEditSubject.BackColor = Color.FromArgb(74, 144, 226);
            this.btnEditSubject.Location = new Point(155, 175);
            this.btnEditSubject.Size = new Size(125, 40);
            this.btnEditSubject.Click += new System.EventHandler(this.btnEditSubject_Click);
            
            this.btnDeleteSubject.Text = "🗑 Xóa";
            this.btnDeleteSubject.BackColor = Color.FromArgb(239, 83, 80);
            this.btnDeleteSubject.Location = new Point(20, 225);
            this.btnDeleteSubject.Size = new Size(260, 40);
            this.btnDeleteSubject.Click += new System.EventHandler(this.btnDeleteSubject_Click);
            
            this.pnlSubject.Controls.Add(lblSubjectName);
            this.pnlSubject.Controls.Add(txtSubjectName);
            this.pnlSubject.Controls.Add(lblSubjectCredits);
            this.pnlSubject.Controls.Add(txtSubjectCredits);
            this.pnlSubject.Controls.Add(btnAddSubject);
            this.pnlSubject.Controls.Add(btnEditSubject);
            this.pnlSubject.Controls.Add(btnDeleteSubject);

            // ManageSubjectForm
            this.ClientSize = new Size(800, 450);
            this.Controls.Add(this.dgvSubjects);
            this.Controls.Add(this.pnlSubject);
            this.Font = new Font("Segoe UI", 10F);
            this.Name = "ManageSubjectForm";
            this.Text = "Quản lý Môn học";
            this.StartPosition = FormStartPosition.CenterScreen;
            
            this.ResumeLayout(false);
        }

        private DataGridView dgvSubjects;
        private Panel pnlSubject;
        private Label lblSubjectName, lblSubjectCredits;
        private TextBox txtSubjectName, txtSubjectCredits;
        private RoundedButton btnAddSubject, btnEditSubject, btnDeleteSubject;
    }
}
