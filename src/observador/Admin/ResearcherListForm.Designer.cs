namespace observador
{
    partial class AdminResearcherListForm
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
        this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.username = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.projects = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.toolStrip1 = new System.Windows.Forms.ToolStrip();
        this.toolStripButtonAdd = new System.Windows.Forms.ToolStripButton();
        this.toolStripButtonEdit = new System.Windows.Forms.ToolStripButton();
        this.toolStripButtonRemove = new System.Windows.Forms.ToolStripButton();
        this.toolStripButtonRefresh = new System.Windows.Forms.ToolStripButton();
        this.toolStripButtonClose = new System.Windows.Forms.ToolStripButton();
        ((System.ComponentModel.ISupportInitialize)(this.dgvResearchers)).BeginInit();
        this.toolStrip1.SuspendLayout();
        this.SuspendLayout();
        // 
        // dgvResearchers
        // 
        this.dgvResearchers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dgvResearchers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.username,
            this.projects});
        this.dgvResearchers.Location = new System.Drawing.Point(12, 42);
        this.dgvResearchers.Name = "dgvResearchers";
        this.dgvResearchers.Size = new System.Drawing.Size(374, 253);
        this.dgvResearchers.TabIndex = 0;
        // 
        // id
        // 
        this.id.DataPropertyName = "Id";
        this.id.HeaderText = "id";
        this.id.Name = "id";
        this.id.ReadOnly = true;
        // 
        // username
        // 
        this.username.DataPropertyName = "Username";
        this.username.HeaderText = "username";
        this.username.Name = "username";
        this.username.ReadOnly = true;
        this.username.Width = 150;
        // 
        // projects
        // 
        this.projects.DataPropertyName = "ProjectCount";
        this.projects.HeaderText = "Projects";
        this.projects.Name = "projects";
        this.projects.ReadOnly = true;
        this.projects.Width = 70;
        // 
        // toolStrip1
        // 
        this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
        this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAdd,
            this.toolStripButtonEdit,
            this.toolStripButtonRemove,
            this.toolStripButtonRefresh,
            this.toolStripButtonClose});
        this.toolStrip1.Location = new System.Drawing.Point(0, 0);
        this.toolStrip1.Name = "toolStrip1";
        this.toolStrip1.Size = new System.Drawing.Size(396, 39);
        this.toolStrip1.TabIndex = 1;
        this.toolStrip1.Text = "toolStrip1";
        // 
        // toolStripButtonAdd
        // 
        this.toolStripButtonAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        this.toolStripButtonAdd.Image = global::observador.Properties.Resources.add;
        this.toolStripButtonAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
        this.toolStripButtonAdd.Name = "toolStripButtonAdd";
        this.toolStripButtonAdd.Size = new System.Drawing.Size(36, 36);
        this.toolStripButtonAdd.Text = "Add";
        this.toolStripButtonAdd.ToolTipText = "Add New";
        this.toolStripButtonAdd.Click += new System.EventHandler(this.toolStripButtonAdd_Click);
        // 
        // toolStripButtonEdit
        // 
        this.toolStripButtonEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        this.toolStripButtonEdit.Image = global::observador.Properties.Resources.edit;
        this.toolStripButtonEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
        this.toolStripButtonEdit.Name = "toolStripButtonEdit";
        this.toolStripButtonEdit.Size = new System.Drawing.Size(36, 36);
        this.toolStripButtonEdit.Text = "toolStripButton2";
        this.toolStripButtonEdit.ToolTipText = "Edit";
        this.toolStripButtonEdit.Click += new System.EventHandler(this.toolStripButtonEdit_Click);
        // 
        // toolStripButtonRemove
        // 
        this.toolStripButtonRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        this.toolStripButtonRemove.Image = global::observador.Properties.Resources.remove;
        this.toolStripButtonRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
        this.toolStripButtonRemove.Name = "toolStripButtonRemove";
        this.toolStripButtonRemove.Size = new System.Drawing.Size(36, 36);
        this.toolStripButtonRemove.Text = "Delete";
        this.toolStripButtonRemove.Click += new System.EventHandler(this.toolStripButtonRemove_Click);
        // 
        // toolStripButtonRefresh
        // 
        this.toolStripButtonRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        this.toolStripButtonRefresh.Image = global::observador.Properties.Resources.refresh;
        this.toolStripButtonRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
        this.toolStripButtonRefresh.Name = "toolStripButtonRefresh";
        this.toolStripButtonRefresh.Size = new System.Drawing.Size(36, 36);
        this.toolStripButtonRefresh.Text = "toolStripButton4";
        this.toolStripButtonRefresh.ToolTipText = "Refresh";
        this.toolStripButtonRefresh.Click += new System.EventHandler(this.toolStripButtonRefresh_Click);
        // 
        // toolStripButtonClose
        // 
        this.toolStripButtonClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        this.toolStripButtonClose.Image = global::observador.Properties.Resources.close;
        this.toolStripButtonClose.ImageTransparentColor = System.Drawing.Color.Magenta;
        this.toolStripButtonClose.Name = "toolStripButtonClose";
        this.toolStripButtonClose.Size = new System.Drawing.Size(36, 36);
        this.toolStripButtonClose.Text = "toolStripButtonClose";
        this.toolStripButtonClose.ToolTipText = "Close";
        this.toolStripButtonClose.Click += new System.EventHandler(this.toolStripButtonClose_Click);
        // 
        // AdminResearchers
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(396, 302);
        this.Controls.Add(this.toolStrip1);
        this.Controls.Add(this.dgvResearchers);
        this.Name = "AdminResearchers";
        this.Text = "Observador v 0.0 - Admin - Researchers";
        this.Load += new System.EventHandler(this.AdminResearchers_Load);
        ((System.ComponentModel.ISupportInitialize)(this.dgvResearchers)).EndInit();
        this.toolStrip1.ResumeLayout(false);
        this.toolStrip1.PerformLayout();
        this.ResumeLayout(false);
        this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvResearchers;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonAdd;
        private System.Windows.Forms.ToolStripButton toolStripButtonEdit;
        private System.Windows.Forms.ToolStripButton toolStripButtonRemove;
        private System.Windows.Forms.ToolStripButton toolStripButtonRefresh;
        private System.Windows.Forms.ToolStripButton toolStripButtonClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn username;
        private System.Windows.Forms.DataGridViewTextBoxColumn projects;
    }
}