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
            btnSearch = new QLDSV.Utils.RoundedButton();
            label1 = new Label();
            SuspendLayout();
            // 
            // txtStudentId
            // 
            txtStudentId.Location = new Point(85, 80);
            txtStudentId.Name = "txtStudentId";
            txtStudentId.Size = new Size(180, 25);
            txtStudentId.TabIndex = 0;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(74, 144, 226); // Softer Blue
            btnSearch.BorderRadius = 20;
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(85, 120);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(180, 40);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "🔍 Tra cứu";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(81, 55);
            label1.Name = "label1";
            label1.Size = new Size(125, 19);
            label1.TabIndex = 3;
            label1.Text = "Nhập mã sinh viên:";
            // 
            // SearchForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(350, 220);
            Controls.Add(label1);
            Controls.Add(btnSearch);
            Controls.Add(txtStudentId);
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "SearchForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tra cứu điểm sinh viên";
            FormClosing += SearchForm_FormClosing;
            Load += SearchForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtStudentId;
        private QLDSV.Utils.RoundedButton btnSearch;
        private Label label1;
    }
}