namespace observador
{
    partial class AdminResearchers
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
            this.dgvResearchers = new System.Windows.Forms.DataGridView();
            this.username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.projects = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResearchers)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvResearchers
            // 
            this.dgvResearchers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResearchers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.username,
            this.projects});
            this.dgvResearchers.Location = new System.Drawing.Point(12, 12);
            this.dgvResearchers.Name = "dgvResearchers";
            this.dgvResearchers.Size = new System.Drawing.Size(265, 303);
            this.dgvResearchers.TabIndex = 0;
            // 
            // username
            // 
            this.username.HeaderText = "username";
            this.username.Name = "username";
            this.username.Width = 150;
            // 
            // projects
            // 
            this.projects.HeaderText = "Projects";
            this.projects.Name = "projects";
            this.projects.Width = 70;
            // 
            // AdminResearchers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 327);
            this.Controls.Add(this.dgvResearchers);
            this.Name = "AdminResearchers";
            this.Text = "Observador v 0.0 - Admin - Researchers";
            this.Load += new System.EventHandler(this.AdminResearchers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResearchers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvResearchers;
        private System.Windows.Forms.DataGridViewTextBoxColumn username;
        private System.Windows.Forms.DataGridViewTextBoxColumn projects;
    }
}