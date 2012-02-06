namespace observador
{
    partial class DashBoard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashBoard));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.researchersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bCreateDatabase = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.bResearchers = new System.Windows.Forms.Button();
            this.bQuit = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem,
            this.adminToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(906, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.homeToolStripMenuItem.Text = "Home";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.researchersToolStripMenuItem});
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.adminToolStripMenuItem.Text = "Admin";
            // 
            // researchersToolStripMenuItem
            // 
            this.researchersToolStripMenuItem.Name = "researchersToolStripMenuItem";
            this.researchersToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.researchersToolStripMenuItem.Text = "Researchers";
            this.researchersToolStripMenuItem.Click += new System.EventHandler(this.researchersToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // bCreateDatabase
            // 
            this.bCreateDatabase.Location = new System.Drawing.Point(718, 60);
            this.bCreateDatabase.Name = "bCreateDatabase";
            this.bCreateDatabase.Size = new System.Drawing.Size(162, 84);
            this.bCreateDatabase.TabIndex = 2;
            this.bCreateDatabase.Text = "create database";
            this.bCreateDatabase.UseVisualStyleBackColor = true;
            this.bCreateDatabase.Click += new System.EventHandler(this.bCreateDatabase_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label1.Location = new System.Drawing.Point(280, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(432, 120);
            this.label1.TabIndex = 2;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // bResearchers
            // 
            this.bResearchers.Location = new System.Drawing.Point(55, 60);
            this.bResearchers.Name = "bResearchers";
            this.bResearchers.Size = new System.Drawing.Size(162, 84);
            this.bResearchers.TabIndex = 1;
            this.bResearchers.Text = "researchers";
            this.bResearchers.UseVisualStyleBackColor = true;
            this.bResearchers.Click += new System.EventHandler(this.bResearchers_Click);
            // 
            // bQuit
            // 
            this.bQuit.Location = new System.Drawing.Point(718, 180);
            this.bQuit.Name = "bQuit";
            this.bQuit.Size = new System.Drawing.Size(162, 84);
            this.bQuit.TabIndex = 4;
            this.bQuit.Text = "Exit";
            this.bQuit.UseVisualStyleBackColor = true;
            this.bQuit.Click += new System.EventHandler(this.bQuit_Click);
            // 
            // DashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 276);
            this.Controls.Add(this.bQuit);
            this.Controls.Add(this.bResearchers);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bCreateDatabase);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DashBoard";
            this.Text = "Observador v 0.0 - DashBoard";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem researchersToolStripMenuItem;
        private System.Windows.Forms.Button bCreateDatabase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bResearchers;
        private System.Windows.Forms.Button bQuit;
    }
}