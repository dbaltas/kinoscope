namespace observador
{
    partial class SubjectGroupForm
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
            this.lName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // bCancel
            // 
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Location = new System.Drawing.Point(200, 41);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 3;
            this.bCancel.Text = "cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(78, 41);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(75, 23);
            this.bSave.TabIndex = 2;
            this.bSave.Text = "Save";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // lName
            // 
            this.lName.AutoSize = true;
            this.lName.Location = new System.Drawing.Point(12, 9);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(35, 13);
            this.lName.TabIndex = 0;
            this.lName.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(53, 6);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(275, 20);
            this.txtName.TabIndex = 1;
            // 
            // SubjectGroupForm
            // 
            this.AcceptButton = this.bSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bCancel;
            this.ClientSize = new System.Drawing.Size(340, 76);
            this.Controls.Add(this.lName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.bCancel);
            this.MinimumSize = new System.Drawing.Size(348, 110);
            this.Name = "SubjectGroupForm";
            this.ShowInTaskbar = false;
            this.Text = "Subject Group";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Label lName;
        private System.Windows.Forms.TextBox txtName;
    }
}