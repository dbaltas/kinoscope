namespace observador
{
    partial class AdminResearcherForm
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
            this.bCancel = new System.Windows.Forms.Button();
            this.bSave = new System.Windows.Forms.Button();
            this.lPassword = new System.Windows.Forms.Label();
            this.lUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // bCancel
            // 
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Location = new System.Drawing.Point(154, 100);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 7;
            this.bCancel.Text = "cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(51, 100);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(75, 23);
            this.bSave.TabIndex = 6;
            this.bSave.Text = "Save";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // lPassword
            // 
            this.lPassword.AutoSize = true;
            this.lPassword.Location = new System.Drawing.Point(50, 40);
            this.lPassword.Name = "lPassword";
            this.lPassword.Size = new System.Drawing.Size(53, 13);
            this.lPassword.TabIndex = 2;
            this.lPassword.Text = "Password";
            // 
            // lUsername
            // 
            this.lUsername.AutoSize = true;
            this.lUsername.Location = new System.Drawing.Point(48, 14);
            this.lUsername.Name = "lUsername";
            this.lUsername.Size = new System.Drawing.Size(55, 13);
            this.lUsername.TabIndex = 0;
            this.lUsername.Text = "Username";
            // 
            // txtUsername
            // 
            this.txtUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsername.Location = new System.Drawing.Point(109, 11);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(151, 20);
            this.txtUsername.TabIndex = 1;
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Location = new System.Drawing.Point(109, 37);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(151, 20);
            this.txtPassword.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Repeat Password";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConfirmPassword.Location = new System.Drawing.Point(109, 63);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(151, 20);
            this.txtConfirmPassword.TabIndex = 5;
            // 
            // AdminResearcherForm
            // 
            this.AcceptButton = this.bSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bCancel;
            this.ClientSize = new System.Drawing.Size(272, 135);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.lPassword);
            this.Controls.Add(this.lUsername);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.bCancel);
            this.MinimumSize = new System.Drawing.Size(280, 169);
            this.Name = "AdminResearcherForm";
            this.ShowInTaskbar = false;
            this.Text = "AdminResearcher";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Label lPassword;
        private System.Windows.Forms.Label lUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtConfirmPassword;
    }
}