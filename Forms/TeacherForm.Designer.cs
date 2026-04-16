using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace QLDSV.Forms

{
    partial class TeacherForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            panel4 = new Panel();
            label3 = new Label();
            button2 = new QLDSV.Utils.RoundedButton();
            btnSave = new QLDSV.Utils.RoundedButton();
            cbGroup = new ComboBox();
            panel3 = new Panel();
            textBox2 = new TextBox();
            label2 = new Label();
            textBox1 = new TextBox();
            label1 = new Label();
            panel2 = new Panel();
            dgvDiem = new DataGridView();
            teacherDBBindingSource = new BindingSource(components);
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDiem).BeginInit();
            ((System.ComponentModel.ISupportInitialize)teacherDBBindingSource).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel3);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(220, 450);
            panel1.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.Controls.Add(label3);
            panel4.Controls.Add(button2);
            panel4.Controls.Add(btnSave);
            panel4.Controls.Add(cbGroup);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(0, 186);
            panel4.Name = "panel4";
            panel4.Size = new Size(220, 264);
            panel4.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(28, 30);
            label3.Name = "label3";
            label3.Size = new Size(92, 15);
            label3.TabIndex = 3;
            label3.Text = "Nhóm môn học";
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(239, 83, 80); // Softer Red
            button2.BorderRadius = 20;
            button2.Cursor = Cursors.Hand;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button2.ForeColor = Color.White;
            button2.Location = new Point(45, 199);
            button2.Name = "button2";
            button2.Size = new Size(140, 40);
            button2.TabIndex = 2;
            button2.Text = "🚪 Đăng xuất";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(74, 144, 226); // Softer Blue
            btnSave.BorderRadius = 20;
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(45, 114);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(140, 40);
            btnSave.TabIndex = 1;
            btnSave.Text = "💾 Lưu thay đổi";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // cbGroup
            // 
            cbGroup.FormattingEnabled = true;
            cbGroup.Location = new Point(36, 48);
            cbGroup.Name = "cbGroup";
            cbGroup.Size = new Size(140, 23);
            cbGroup.TabIndex = 0;
            cbGroup.SelectedIndexChanged += cbGroup_SelectedIndexChanged;
            // 
            // panel3
            // 
            panel3.Controls.Add(textBox2);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(textBox1);
            panel3.Controls.Add(label1);
            panel3.Cursor = Cursors.SizeNS;
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(220, 186);
            panel3.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(23, 98);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(170, 23);
            textBox2.TabIndex = 3;
            textBox2.ReadOnly = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(34, 80);
            label2.Name = "label2";
            label2.Size = new Size(86, 15);
            label2.TabIndex = 2;
            label2.Text = "Môn phụ trách";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(23, 41);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(170, 23);
            textBox1.TabIndex = 1;
            textBox1.ReadOnly = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(34, 23);
            label1.Name = "label1";
            label1.Size = new Size(73, 15);
            label1.TabIndex = 0;
            label1.Text = "Chào mừng ";
            // 
            // panel2
            // 
            panel2.Controls.Add(dgvDiem);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(220, 0);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(8);
            panel2.Size = new Size(580, 450);
            panel2.TabIndex = 1;
            // 
            // dgvDiem
            // 
            dgvDiem.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDiem.Dock = DockStyle.Fill;
            dgvDiem.Location = new Point(8, 8);
            dgvDiem.Name = "dgvDiem";
            dgvDiem.Size = new Size(564, 434);
            dgvDiem.TabIndex = 0;
            dgvDiem.AllowUserToAddRows = false;
            dgvDiem.AllowUserToResizeRows = false;
            dgvDiem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDiem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDiem.RowHeadersVisible = false;
            dgvDiem.BorderStyle = BorderStyle.None;
            dgvDiem.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 244, 248);
            dgvDiem.BackgroundColor = Color.White;
            // 
            // TeacherForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            ClientSize = new Size(800, 450);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "TeacherForm";
            Text = "Quản Lý Điểm Sinh Viên";
            StartPosition = FormStartPosition.CenterScreen;
            FormClosing += TeacherForm_FormClosing;
            Load += TeacherForm_Load;
            panel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDiem).EndInit();
            ((System.ComponentModel.ISupportInitialize)teacherDBBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel4;
        private Panel panel3;
        private Panel panel2;
        private QLDSV.Utils.RoundedButton button2;
        private QLDSV.Utils.RoundedButton btnSave;
        private ComboBox cbGroup;
        private Label label2;
        private TextBox textBox1;
        private Label label1;
        private BindingSource teacherDBBindingSource;
        private DataGridView dgvDiem;
        private TextBox textBox2;
        private Label label3;
    }

}