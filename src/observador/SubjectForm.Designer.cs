namespace observador
{
    partial class SubjectForm
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
            this.bCancel = new System.Windows.Forms.Button();
            this.bSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lStrain = new System.Windows.Forms.Label();
            this.txtStrain = new System.Windows.Forms.TextBox();
            this.lSex = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lWeight = new System.Windows.Forms.Label();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbSubjectGroup = new System.Windows.Forms.ComboBox();
            this.cbSex = new System.Windows.Forms.ComboBox();
            this.dtDob = new System.Windows.Forms.DateTimePicker();
            this.txtOrigin = new System.Windows.Forms.TextBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.bSaveAndClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // bCancel
            // 
            this.bCancel.CausesValidation = false;
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Location = new System.Drawing.Point(284, 199);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 10;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(8, 199);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(135, 23);
            this.bSave.TabIndex = 8;
            this.bSave.Text = "Save and Keep Open";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Code";
            // 
            // lStrain
            // 
            this.lStrain.AutoSize = true;
            this.lStrain.Location = new System.Drawing.Point(55, 62);
            this.lStrain.Name = "lStrain";
            this.lStrain.Size = new System.Drawing.Size(34, 13);
            this.lStrain.TabIndex = 6;
            this.lStrain.Text = "Strain";
            // 
            // txtStrain
            // 
            this.txtStrain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStrain.Location = new System.Drawing.Point(95, 59);
            this.txtStrain.Name = "txtStrain";
            this.txtStrain.Size = new System.Drawing.Size(264, 20);
            this.txtStrain.TabIndex = 3;
            // 
            // lSex
            // 
            this.lSex.AutoSize = true;
            this.lSex.Location = new System.Drawing.Point(64, 88);
            this.lSex.Name = "lSex";
            this.lSex.Size = new System.Drawing.Size(25, 13);
            this.lSex.TabIndex = 8;
            this.lSex.Text = "Sex";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Subject Group";
            // 
            // txtCode
            // 
            this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCode.Location = new System.Drawing.Point(95, 6);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(264, 20);
            this.txtCode.TabIndex = 1;
            this.txtCode.Validating += new System.ComponentModel.CancelEventHandler(this.txtCode_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Origin";
            // 
            // lWeight
            // 
            this.lWeight.AutoSize = true;
            this.lWeight.Location = new System.Drawing.Point(5, 167);
            this.lWeight.Name = "lWeight";
            this.lWeight.Size = new System.Drawing.Size(84, 13);
            this.lWeight.TabIndex = 17;
            this.lWeight.Text = "Weight (in gram)";
            // 
            // txtWeight
            // 
            this.txtWeight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWeight.Location = new System.Drawing.Point(95, 164);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(264, 20);
            this.txtWeight.TabIndex = 7;
            this.txtWeight.Validating += new System.ComponentModel.CancelEventHandler(this.txtWeight_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Date Of Birth";
            // 
            // cbSubjectGroup
            // 
            this.cbSubjectGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSubjectGroup.FormattingEnabled = true;
            this.cbSubjectGroup.Location = new System.Drawing.Point(95, 32);
            this.cbSubjectGroup.Name = "cbSubjectGroup";
            this.cbSubjectGroup.Size = new System.Drawing.Size(136, 21);
            this.cbSubjectGroup.TabIndex = 2;
            // 
            // cbSex
            // 
            this.cbSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSex.FormattingEnabled = true;
            this.cbSex.Items.AddRange(new object[] {
            "Female",
            "Male"});
            this.cbSex.Location = new System.Drawing.Point(95, 85);
            this.cbSex.Name = "cbSex";
            this.cbSex.Size = new System.Drawing.Size(136, 21);
            this.cbSex.TabIndex = 4;
            // 
            // dtDob
            // 
            this.dtDob.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDob.Location = new System.Drawing.Point(95, 112);
            this.dtDob.Name = "dtDob";
            this.dtDob.Size = new System.Drawing.Size(136, 20);
            this.dtDob.TabIndex = 5;
            // 
            // txtOrigin
            // 
            this.txtOrigin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOrigin.Location = new System.Drawing.Point(95, 138);
            this.txtOrigin.Name = "txtOrigin";
            this.txtOrigin.Size = new System.Drawing.Size(264, 20);
            this.txtOrigin.TabIndex = 6;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // bSaveAndClose
            // 
            this.bSaveAndClose.Location = new System.Drawing.Point(162, 199);
            this.bSaveAndClose.Name = "bSaveAndClose";
            this.bSaveAndClose.Size = new System.Drawing.Size(103, 23);
            this.bSaveAndClose.TabIndex = 9;
            this.bSaveAndClose.Text = "Save and Close";
            this.bSaveAndClose.UseVisualStyleBackColor = true;
            this.bSaveAndClose.Click += new System.EventHandler(this.bSaveAndClose_Click);
            // 
            // SubjectForm
            // 
            this.AcceptButton = this.bSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.CancelButton = this.bCancel;
            this.ClientSize = new System.Drawing.Size(384, 240);
            this.Controls.Add(this.bSaveAndClose);
            this.Controls.Add(this.txtOrigin);
            this.Controls.Add(this.dtDob);
            this.Controls.Add(this.cbSex);
            this.Controls.Add(this.cbSubjectGroup);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lWeight);
            this.Controls.Add(this.txtWeight);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lSex);
            this.Controls.Add(this.lStrain);
            this.Controls.Add(this.txtStrain);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.bCancel);
            this.MinimumSize = new System.Drawing.Size(392, 274);
            this.Name = "SubjectForm";
            this.ShowInTaskbar = false;
            this.Text = "Subject";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lStrain;
        private System.Windows.Forms.TextBox txtStrain;
        private System.Windows.Forms.Label lSex;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lWeight;
        private System.Windows.Forms.TextBox txtWeight;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbSubjectGroup;
        private System.Windows.Forms.ComboBox cbSex;
        private System.Windows.Forms.DateTimePicker dtDob;
        private System.Windows.Forms.TextBox txtOrigin;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button bSaveAndClose;
    }
}