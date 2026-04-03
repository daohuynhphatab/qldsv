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
            button2 = new Button();
            btnSave = new Button();
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
            panel1.Size = new Size(159, 450);
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
            panel4.Size = new Size(159, 264);
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
            button2.Location = new Point(34, 199);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 2;
            button2.Text = "Đăng xuất";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(31, 114);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(89, 23);
            btnSave.TabIndex = 1;
            btnSave.Text = "Lưu thay đổi";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // cbGroup
            // 
            cbGroup.FormattingEnabled = true;
            cbGroup.Location = new Point(12, 48);
            cbGroup.Name = "cbGroup";
            cbGroup.Size = new Size(121, 23);
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
            panel3.Size = new Size(159, 186);
            panel3.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(23, 98);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 3;
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
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 1;
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
            panel2.Location = new Point(159, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(641, 450);
            panel2.TabIndex = 1;
            // 
            // dgvDiem
            // 
            dgvDiem.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDiem.Dock = DockStyle.Fill;
            dgvDiem.Location = new Point(0, 0);
            dgvDiem.Name = "dgvDiem";
            dgvDiem.Size = new Size(641, 450);
            dgvDiem.TabIndex = 0;
            // 
            // teacherDBBindingSource
            // 
            teacherDBBindingSource.DataSource = typeof(TeacherDB);
            // 
            // TeacherForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "TeacherForm";
            Text = "Quản Lý Điểm Sinh Viên";
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
        private Button button2;
        private Button btnSave;
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