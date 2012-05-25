namespace observador
{
    partial class ProjectEditForm
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
            this.components = new System.ComponentModel.Container();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.bAddBehavioralTest = new System.Windows.Forms.Button();
            this.lnkAddBehavioralTest = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(355, 93);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // bAddBehavioralTest
            // 
            this.bAddBehavioralTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bAddBehavioralTest.BackgroundImage = global::observador.Properties.Resources.add;
            this.bAddBehavioralTest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bAddBehavioralTest.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.bAddBehavioralTest.Location = new System.Drawing.Point(12, 115);
            this.bAddBehavioralTest.Name = "bAddBehavioralTest";
            this.bAddBehavioralTest.Size = new System.Drawing.Size(75, 63);
            this.bAddBehavioralTest.TabIndex = 1;
            this.bAddBehavioralTest.UseVisualStyleBackColor = true;
            // 
            // lnkAddBehavioralTest
            // 
            this.lnkAddBehavioralTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lnkAddBehavioralTest.AutoSize = true;
            this.lnkAddBehavioralTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lnkAddBehavioralTest.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lnkAddBehavioralTest.Location = new System.Drawing.Point(93, 133);
            this.lnkAddBehavioralTest.Name = "lnkAddBehavioralTest";
            this.lnkAddBehavioralTest.Size = new System.Drawing.Size(265, 31);
            this.lnkAddBehavioralTest.TabIndex = 2;
            this.lnkAddBehavioralTest.TabStop = true;
            this.lnkAddBehavioralTest.Text = "New Behavioral Test";
            // 
            // ProjectEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(379, 182);
            this.Controls.Add(this.lnkAddBehavioralTest);
            this.Controls.Add(this.bAddBehavioralTest);
            this.Controls.Add(this.flowLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(356, 101);
            this.Name = "ProjectEditForm";
            this.ShowInTaskbar = false;
            this.Text = "Project";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.LinkLabel lnkAddBehavioralTest;
        private System.Windows.Forms.Button bAddBehavioralTest;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}