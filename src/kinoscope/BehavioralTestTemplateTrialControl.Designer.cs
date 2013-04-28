namespace kinoscope
{
    partial class BehavioralTestTemplateTrialControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbTrial = new System.Windows.Forms.GroupBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.gbTrial.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbTrial
            // 
            this.gbTrial.Controls.Add(this.txtName);
            this.gbTrial.Controls.Add(this.label5);
            this.gbTrial.Controls.Add(this.label4);
            this.gbTrial.Controls.Add(this.txtDuration);
            this.gbTrial.Location = new System.Drawing.Point(3, 3);
            this.gbTrial.Name = "gbTrial";
            this.gbTrial.Size = new System.Drawing.Size(268, 49);
            this.gbTrial.TabIndex = 17;
            this.gbTrial.TabStop = false;
            this.gbTrial.Text = "Trial 1";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(8, 18);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(94, 20);
            this.txtName.TabIndex = 8;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            this.txtName.Validating += new System.ComponentModel.CancelEventHandler(this.txtName_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(215, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "seconds";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(101, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Duration";
            // 
            // txtDuration
            // 
            this.txtDuration.Location = new System.Drawing.Point(153, 18);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(56, 20);
            this.txtDuration.TabIndex = 12;
            this.txtDuration.Validating += new System.ComponentModel.CancelEventHandler(this.txtDuration_Validating);
            // 
            // BehavioralTestTemplateTrialControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbTrial);
            this.Name = "BehavioralTestTemplateTrialControl";
            this.Size = new System.Drawing.Size(274, 55);
            this.gbTrial.ResumeLayout(false);
            this.gbTrial.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbTrial;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtDuration;
        private System.Windows.Forms.TextBox txtName;
    }
}
