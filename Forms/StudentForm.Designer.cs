namespace QLDSV.Forms
{
    partial class StudentForm
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
            txtMSSV = new TextBox();
            btnSearch = new Button();
            dataGridView1 = new DataGridView();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // txtMSSV
            // 
            txtMSSV.Location = new Point(198, 87);
            txtMSSV.Name = "txtMSSV";
            txtMSSV.Size = new Size(100, 23);
            txtMSSV.TabIndex = 0;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(198, 116);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(100, 25);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "Tra cứu";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Bottom;
            dataGridView1.Location = new Point(0, 233);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(536, 52);
            dataGridView1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(195, 69);
            label1.Name = "label1";
            label1.Size = new Size(106, 15);
            label1.TabIndex = 3;
            label1.Text = "Nhập mã sinh viên";
            // 
            // StudentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(536, 285);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(btnSearch);
            Controls.Add(txtMSSV);
            Name = "StudentForm";
            Text = "Tra cứu điểm sinh viên";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtMSSV;
        private Button btnSearch;
        private DataGridView dataGridView1;
        private Label label1;
    }
}