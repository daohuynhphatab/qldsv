namespace QLDSV.Forms
{
    partial class SearchForm
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
            txtStudentId = new TextBox();
            btnSearch = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // txtStudentId
            // 
            txtStudentId.Location = new Point(96, 74);
            txtStudentId.Name = "txtStudentId";
            txtStudentId.Size = new Size(100, 23);
            txtStudentId.TabIndex = 0;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(96, 103);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(100, 25);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "Tra cứu";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(93, 56);
            label1.Name = "label1";
            label1.Size = new Size(106, 15);
            label1.TabIndex = 3;
            label1.Text = "Nhập mã sinh viên";
            // 
            // SearchForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(298, 200);
            Controls.Add(label1);
            Controls.Add(btnSearch);
            Controls.Add(txtStudentId);
            Name = "SearchForm";
            Text = "Tra cứu điểm sinh viên";
            FormClosing += SearchForm_FormClosing;
            Load += SearchForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtStudentId;
        private Button btnSearch;
        private Label label1;
    }
}