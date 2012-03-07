namespace observador
{
    partial class RunEventForm
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
            this.lblBehavior = new System.Windows.Forms.Label();
            this.lblTimeTracked = new System.Windows.Forms.Label();
            this.txtTimeTracked = new System.Windows.Forms.TextBox();
            this.cbBehavior = new System.Windows.Forms.ComboBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // bCancel
            // 
            this.bCancel.CausesValidation = false;
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Location = new System.Drawing.Point(158, 65);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 5;
            this.bCancel.Text = "cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(39, 65);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(75, 23);
            this.bSave.TabIndex = 4;
            this.bSave.Text = "Save";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // lblBehavior
            // 
            this.lblBehavior.AutoSize = true;
            this.lblBehavior.Location = new System.Drawing.Point(36, 15);
            this.lblBehavior.Name = "lblBehavior";
            this.lblBehavior.Size = new System.Drawing.Size(49, 13);
            this.lblBehavior.TabIndex = 0;
            this.lblBehavior.Text = "Behavior";
            // 
            // lblTimeTracked
            // 
            this.lblTimeTracked.AutoSize = true;
            this.lblTimeTracked.Location = new System.Drawing.Point(12, 42);
            this.lblTimeTracked.Name = "lblTimeTracked";
            this.lblTimeTracked.Size = new System.Drawing.Size(73, 13);
            this.lblTimeTracked.TabIndex = 2;
            this.lblTimeTracked.Text = "Time Tracked";
            // 
            // txtTimeTracked
            // 
            this.txtTimeTracked.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimeTracked.Location = new System.Drawing.Point(91, 39);
            this.txtTimeTracked.Name = "txtTimeTracked";
            this.txtTimeTracked.Size = new System.Drawing.Size(161, 20);
            this.txtTimeTracked.TabIndex = 3;
            this.txtTimeTracked.Validating += new System.ComponentModel.CancelEventHandler(this.txtTimeTracked_Validating);
            // 
            // cbBehavior
            // 
            this.cbBehavior.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbBehavior.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBehavior.FormattingEnabled = true;
            this.cbBehavior.Location = new System.Drawing.Point(91, 12);
            this.cbBehavior.Name = "cbBehavior";
            this.cbBehavior.Size = new System.Drawing.Size(161, 21);
            this.cbBehavior.TabIndex = 1;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // RunEventForm
            // 
            this.AcceptButton = this.bSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.CancelButton = this.bCancel;
            this.ClientSize = new System.Drawing.Size(276, 99);
            this.Controls.Add(this.cbBehavior);
            this.Controls.Add(this.lblTimeTracked);
            this.Controls.Add(this.txtTimeTracked);
            this.Controls.Add(this.lblBehavior);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.bCancel);
            this.MinimumSize = new System.Drawing.Size(284, 133);
            this.Name = "RunEventForm";
            this.ShowInTaskbar = false;
            this.Text = "Run Event";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Label lblBehavior;
        private System.Windows.Forms.Label lblTimeTracked;
        private System.Windows.Forms.TextBox txtTimeTracked;
        private System.Windows.Forms.ComboBox cbBehavior;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}