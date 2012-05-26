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
            this.lnkAddBehavioralTest = new System.Windows.Forms.LinkLabel();
            this.cbTemplate = new System.Windows.Forms.ComboBox();
            this.txtNewBehavioralTestName = new System.Windows.Forms.TextBox();
            this.pAddNew = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bNewCancel = new System.Windows.Forms.Button();
            this.bNewSave = new System.Windows.Forms.Button();
            this.lBehavioralTests = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.pAddNew.SuspendLayout();
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
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 27);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(355, 106);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // lnkAddBehavioralTest
            // 
            this.lnkAddBehavioralTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lnkAddBehavioralTest.AutoSize = true;
            this.lnkAddBehavioralTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lnkAddBehavioralTest.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lnkAddBehavioralTest.Location = new System.Drawing.Point(12, 153);
            this.lnkAddBehavioralTest.Name = "lnkAddBehavioralTest";
            this.lnkAddBehavioralTest.Size = new System.Drawing.Size(320, 31);
            this.lnkAddBehavioralTest.TabIndex = 2;
            this.lnkAddBehavioralTest.TabStop = true;
            this.lnkAddBehavioralTest.Text = "Add New Behavioral Test";
            this.lnkAddBehavioralTest.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAddBehavioralTest_LinkClicked);
            // 
            // cbTemplate
            // 
            this.cbTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTemplate.FormattingEnabled = true;
            this.cbTemplate.Location = new System.Drawing.Point(118, 13);
            this.cbTemplate.Name = "cbTemplate";
            this.cbTemplate.Size = new System.Drawing.Size(186, 21);
            this.cbTemplate.TabIndex = 3;
            this.cbTemplate.SelectedIndexChanged += new System.EventHandler(this.cbTemplate_SelectedIndexChanged);
            this.cbTemplate.Validating += new System.ComponentModel.CancelEventHandler(this.cbTemplate_Validating);
            // 
            // txtNewBehavioralTestName
            // 
            this.txtNewBehavioralTestName.Location = new System.Drawing.Point(118, 40);
            this.txtNewBehavioralTestName.Name = "txtNewBehavioralTestName";
            this.txtNewBehavioralTestName.Size = new System.Drawing.Size(186, 20);
            this.txtNewBehavioralTestName.TabIndex = 4;
            this.txtNewBehavioralTestName.Validating += new System.ComponentModel.CancelEventHandler(this.txtNewBehavioralTestName_Validating);
            // 
            // pAddNew
            // 
            this.pAddNew.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pAddNew.Controls.Add(this.label2);
            this.pAddNew.Controls.Add(this.label1);
            this.pAddNew.Controls.Add(this.bNewCancel);
            this.pAddNew.Controls.Add(this.bNewSave);
            this.pAddNew.Controls.Add(this.cbTemplate);
            this.pAddNew.Controls.Add(this.txtNewBehavioralTestName);
            this.pAddNew.Location = new System.Drawing.Point(18, 143);
            this.pAddNew.Name = "pAddNew";
            this.pAddNew.Size = new System.Drawing.Size(336, 106);
            this.pAddNew.TabIndex = 5;
            this.pAddNew.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Behavioral Test";
            // 
            // bNewCancel
            // 
            this.bNewCancel.Location = new System.Drawing.Point(178, 73);
            this.bNewCancel.Name = "bNewCancel";
            this.bNewCancel.Size = new System.Drawing.Size(75, 23);
            this.bNewCancel.TabIndex = 6;
            this.bNewCancel.Text = "Cancel";
            this.bNewCancel.UseVisualStyleBackColor = true;
            this.bNewCancel.Click += new System.EventHandler(this.bNewCancel_Click);
            // 
            // bNewSave
            // 
            this.bNewSave.Location = new System.Drawing.Point(56, 73);
            this.bNewSave.Name = "bNewSave";
            this.bNewSave.Size = new System.Drawing.Size(75, 23);
            this.bNewSave.TabIndex = 5;
            this.bNewSave.Text = "Save";
            this.bNewSave.UseVisualStyleBackColor = true;
            this.bNewSave.Click += new System.EventHandler(this.bNewSave_Click);
            // 
            // lBehavioralTests
            // 
            this.lBehavioralTests.AutoSize = true;
            this.lBehavioralTests.Location = new System.Drawing.Point(15, 9);
            this.lBehavioralTests.Name = "lBehavioralTests";
            this.lBehavioralTests.Size = new System.Drawing.Size(125, 13);
            this.lBehavioralTests.TabIndex = 6;
            this.lBehavioralTests.Text = "Existing Behavioral Tests";
            // 
            // ProjectEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(379, 256);
            this.Controls.Add(this.lBehavioralTests);
            this.Controls.Add(this.lnkAddBehavioralTest);
            this.Controls.Add(this.pAddNew);
            this.Controls.Add(this.flowLayoutPanel1);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(356, 101);
            this.Name = "ProjectEditForm";
            this.ShowInTaskbar = false;
            this.Text = "Project";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ProjectEditForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.pAddNew.ResumeLayout(false);
            this.pAddNew.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.LinkLabel lnkAddBehavioralTest;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel pAddNew;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bNewCancel;
        private System.Windows.Forms.Button bNewSave;
        private System.Windows.Forms.ComboBox cbTemplate;
        private System.Windows.Forms.TextBox txtNewBehavioralTestName;
        private System.Windows.Forms.Label lBehavioralTests;
    }
}