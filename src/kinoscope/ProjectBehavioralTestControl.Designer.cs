namespace kinoscope
{
    partial class ProjectBehavioralTestControl
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
            this.lblBehavioralTest = new System.Windows.Forms.Label();
            this.bDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblBehavioralTest
            // 
            this.lblBehavioralTest.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBehavioralTest.AutoSize = true;
            this.lblBehavioralTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblBehavioralTest.Location = new System.Drawing.Point(20, 14);
            this.lblBehavioralTest.Name = "lblBehavioralTest";
            this.lblBehavioralTest.Size = new System.Drawing.Size(86, 31);
            this.lblBehavioralTest.TabIndex = 0;
            this.lblBehavioralTest.Text = "label1";
            // 
            // bDelete
            // 
            this.bDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bDelete.BackgroundImage = global::kinoscope.Properties.Resources.remove;
            this.bDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bDelete.Location = new System.Drawing.Point(270, 3);
            this.bDelete.Name = "bDelete";
            this.bDelete.Size = new System.Drawing.Size(56, 56);
            this.bDelete.TabIndex = 1;
            this.bDelete.UseVisualStyleBackColor = true;
            this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
            // 
            // ProjectBehavioralTestControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bDelete);
            this.Controls.Add(this.lblBehavioralTest);
            this.Name = "ProjectBehavioralTestControl";
            this.Size = new System.Drawing.Size(329, 63);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBehavioralTest;
        private System.Windows.Forms.Button bDelete;

    }
}
