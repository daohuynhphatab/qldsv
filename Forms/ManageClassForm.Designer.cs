using System.Drawing;
using System.Windows.Forms;
using QLDSV.Utils;

namespace QLDSV.Forms
{
    partial class ManageClassForm
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
            this.dgvClasses = new DataGridView();
            this.pnlClass = new Panel();
            this.lblClassName = new Label();
            this.txtClassName = new TextBox();
            this.btnAddClass = new RoundedButton();
            this.btnEditClass = new RoundedButton();
            this.btnDeleteClass = new RoundedButton();
            
            this.SuspendLayout();

            this.dgvClasses.Dock = DockStyle.Fill;
            this.dgvClasses.BackgroundColor = Color.White;
            this.dgvClasses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvClasses.CellClick += new DataGridViewCellEventHandler(this.dgvClasses_CellClick);
            
            this.pnlClass.Dock = DockStyle.Right;
            this.pnlClass.Width = 300;
            this.pnlClass.BackColor = Color.FromArgb(240, 244, 248);
            
            this.lblClassName.Text = "Tên Lớp:";
            this.lblClassName.Location = new Point(20, 30);
            this.lblClassName.AutoSize = true;
            this.txtClassName.Location = new Point(20, 55);
            this.txtClassName.Width = 260;
            
            this.btnAddClass.Text = "➕ Thêm";
            this.btnAddClass.BackColor = Color.FromArgb(74, 144, 226);
            this.btnAddClass.Location = new Point(20, 110);
            this.btnAddClass.Size = new Size(125, 40);
            this.btnAddClass.Click += new System.EventHandler(this.btnAddClass_Click);
            
            this.btnEditClass.Text = "✏ Sửa";
            this.btnEditClass.BackColor = Color.FromArgb(74, 144, 226);
            this.btnEditClass.Location = new Point(155, 110);
            this.btnEditClass.Size = new Size(125, 40);
            this.btnEditClass.Click += new System.EventHandler(this.btnEditClass_Click);
            
            this.btnDeleteClass.Text = "🗑 Xóa";
            this.btnDeleteClass.BackColor = Color.FromArgb(239, 83, 80);
            this.btnDeleteClass.Location = new Point(20, 160);
            this.btnDeleteClass.Size = new Size(260, 40);
            this.btnDeleteClass.Click += new System.EventHandler(this.btnDeleteClass_Click);
            
            this.pnlClass.Controls.Add(lblClassName);
            this.pnlClass.Controls.Add(txtClassName);
            this.pnlClass.Controls.Add(btnAddClass);
            this.pnlClass.Controls.Add(btnEditClass);
            this.pnlClass.Controls.Add(btnDeleteClass);
            
            // ManageClassForm
            this.ClientSize = new Size(800, 450);
            this.Controls.Add(this.dgvClasses);
            this.Controls.Add(this.pnlClass);
            this.Font = new Font("Segoe UI", 10F);
            this.Name = "ManageClassForm";
            this.Text = "Quản lý Lớp";
            this.StartPosition = FormStartPosition.CenterScreen;
            
            this.ResumeLayout(false);
        }

        private DataGridView dgvClasses;
        private Panel pnlClass;
        private Label lblClassName;
        private TextBox txtClassName;
        private RoundedButton btnAddClass, btnEditClass, btnDeleteClass;
    }
}
