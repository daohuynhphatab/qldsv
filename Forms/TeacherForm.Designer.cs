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
            panel1 = new Panel();
            dataGridView = new DataGridView();
            panel2 = new Panel();
            label3 = new Label();
            txtName = new TextBox();
            label2 = new Label();
            label1 = new Label();
            btnAdd = new Button();
            txtMSSV = new TextBox();
            txtScore = new TextBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(dataGridView);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 106);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 344);
            panel1.TabIndex = 0;
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.Location = new Point(0, 0);
            dataGridView.Name = "dataGridView";
            dataGridView.Size = new Size(800, 344);
            dataGridView.TabIndex = 0;
            dataGridView.CellClick += dataGridView_CellClick;
            // 
            // panel2
            // 
            panel2.Controls.Add(label3);
            panel2.Controls.Add(txtName);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(btnAdd);
            panel2.Controls.Add(txtMSSV);
            panel2.Controls.Add(txtScore);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(800, 100);
            panel2.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(367, 49);
            label3.Name = "label3";
            label3.Size = new Size(25, 15);
            label3.TabIndex = 6;
            label3.Text = "Ten";
            // 
            // txtName
            // 
            txtName.Location = new Point(430, 41);
            txtName.Name = "txtName";
            txtName.Size = new Size(100, 23);
            txtName.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(367, 78);
            label2.Name = "label2";
            label2.Size = new Size(35, 15);
            label2.TabIndex = 4;
            label2.Text = "Diem";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(367, 20);
            label1.Name = "label1";
            label1.Size = new Size(37, 15);
            label1.TabIndex = 3;
            label1.Text = "MSSV";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(703, 69);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(85, 22);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Lưu thay đổi";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtMSSV
            // 
            txtMSSV.Location = new Point(430, 12);
            txtMSSV.Name = "txtMSSV";
            txtMSSV.Size = new Size(100, 23);
            txtMSSV.TabIndex = 1;
            // 
            // txtScore
            // 
            txtScore.Location = new Point(430, 70);
            txtScore.Name = "txtScore";
            txtScore.Size = new Size(100, 23);
            txtScore.TabIndex = 0;
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
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DataGridView dataGridView;
        private Panel panel2;
        private Button btnAdd;
        private TextBox txtMSSV;
        private TextBox txtScore;
        private Label label2;
        private Label label1;
        private Label label3;
        private TextBox txtName;
    }
}