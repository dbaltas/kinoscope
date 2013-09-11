namespace kinoscope.Export
{
    partial class ExportSettingsForm
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
            this.bExport = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTimeBinDuration = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ckExportTimeBins = new System.Windows.Forms.CheckBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtExportStart = new System.Windows.Forms.TextBox();
            this.txtExportEnd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // bCancel
            // 
            this.bCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bCancel.Location = new System.Drawing.Point(195, 162);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 5;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // bExport
            // 
            this.bExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bExport.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bExport.Location = new System.Drawing.Point(64, 162);
            this.bExport.Name = "bExport";
            this.bExport.Size = new System.Drawing.Size(75, 23);
            this.bExport.TabIndex = 4;
            this.bExport.Text = "Export";
            this.bExport.UseVisualStyleBackColor = true;
            this.bExport.Click += new System.EventHandler(this.bExport_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtExportEnd);
            this.panel1.Controls.Add(this.txtExportStart);
            this.panel1.Controls.Add(this.txtTimeBinDuration);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ckExportTimeBins);
            this.panel1.Location = new System.Drawing.Point(12, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(305, 143);
            this.panel1.TabIndex = 2;
            // 
            // txtTimeBinDuration
            // 
            this.txtTimeBinDuration.Enabled = false;
            this.txtTimeBinDuration.Location = new System.Drawing.Point(180, 91);
            this.txtTimeBinDuration.Name = "txtTimeBinDuration";
            this.txtTimeBinDuration.Size = new System.Drawing.Size(55, 20);
            this.txtTimeBinDuration.TabIndex = 2;
            this.txtTimeBinDuration.Validating += new System.ComponentModel.CancelEventHandler(this.txtTimeBinDuration_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Time Bin duration in seconds:";
            // 
            // ckExportTimeBins
            // 
            this.ckExportTimeBins.AutoSize = true;
            this.ckExportTimeBins.Location = new System.Drawing.Point(27, 75);
            this.ckExportTimeBins.Name = "ckExportTimeBins";
            this.ckExportTimeBins.Size = new System.Drawing.Size(102, 17);
            this.ckExportTimeBins.TabIndex = 0;
            this.ckExportTimeBins.Text = "Export TimeBins";
            this.ckExportTimeBins.UseVisualStyleBackColor = true;
            this.ckExportTimeBins.CheckedChanged += new System.EventHandler(this.ckExportTimeBins_CheckedChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // txtExportStart
            // 
            this.txtExportStart.Location = new System.Drawing.Point(110, 22);
            this.txtExportStart.Name = "txtExportStart";
            this.txtExportStart.Size = new System.Drawing.Size(40, 20);
            this.txtExportStart.TabIndex = 3;
            this.txtExportStart.Validating += new System.ComponentModel.CancelEventHandler(this.txtExportStart_Validating);
            // 
            // txtExportEnd
            // 
            this.txtExportEnd.Location = new System.Drawing.Point(216, 21);
            this.txtExportEnd.Name = "txtExportEnd";
            this.txtExportEnd.Size = new System.Drawing.Size(40, 20);
            this.txtExportEnd.TabIndex = 4;
            this.txtExportEnd.Validating += new System.ComponentModel.CancelEventHandler(this.txtExportEnd_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Export from second:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(155, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "to second:";
            // 
            // ExportSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 197);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bExport);
            this.Controls.Add(this.bCancel);
            this.Name = "ExportSettingsForm";
            this.Text = "Export Settings";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Button bExport;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox ckExportTimeBins;
        private System.Windows.Forms.TextBox txtTimeBinDuration;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtExportEnd;
        private System.Windows.Forms.TextBox txtExportStart;
    }
}