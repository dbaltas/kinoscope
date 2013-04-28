namespace kinoscope
{
    partial class ResearcherBehaviorKeyStrokeForm
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
            this.lblKeyStroke = new System.Windows.Forms.Label();
            this.txtKeyStroke = new System.Windows.Forms.TextBox();
            this.lblBehavior = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtBehavior = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // bCancel
            // 
            this.bCancel.CausesValidation = false;
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Location = new System.Drawing.Point(159, 69);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 5;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(43, 69);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(75, 23);
            this.bSave.TabIndex = 4;
            this.bSave.Text = "Save";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // lblKeyStroke
            // 
            this.lblKeyStroke.AutoSize = true;
            this.lblKeyStroke.Location = new System.Drawing.Point(7, 46);
            this.lblKeyStroke.Name = "lblKeyStroke";
            this.lblKeyStroke.Size = new System.Drawing.Size(59, 13);
            this.lblKeyStroke.TabIndex = 2;
            this.lblKeyStroke.Text = "Key Stroke";
            // 
            // txtKeyStroke
            // 
            this.txtKeyStroke.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKeyStroke.Location = new System.Drawing.Point(72, 43);
            this.txtKeyStroke.Name = "txtKeyStroke";
            this.txtKeyStroke.ReadOnly = true;
            this.txtKeyStroke.Size = new System.Drawing.Size(180, 20);
            this.txtKeyStroke.TabIndex = 3;
            this.txtKeyStroke.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKeyStroke_KeyDown);
            this.txtKeyStroke.Validating += new System.ComponentModel.CancelEventHandler(this.txtKeyStroke_Validating);
            // 
            // lblBehavior
            // 
            this.lblBehavior.AutoSize = true;
            this.lblBehavior.Location = new System.Drawing.Point(17, 15);
            this.lblBehavior.Name = "lblBehavior";
            this.lblBehavior.Size = new System.Drawing.Size(49, 13);
            this.lblBehavior.TabIndex = 0;
            this.lblBehavior.Text = "Behavior";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // txtBehavior
            // 
            this.txtBehavior.Location = new System.Drawing.Point(72, 12);
            this.txtBehavior.Name = "txtBehavior";
            this.txtBehavior.ReadOnly = true;
            this.txtBehavior.Size = new System.Drawing.Size(180, 20);
            this.txtBehavior.TabIndex = 6;
            // 
            // ResearcherBehaviorKeyStrokeForm
            // 
            this.AcceptButton = this.bSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.CancelButton = this.bCancel;
            this.ClientSize = new System.Drawing.Size(277, 102);
            this.Controls.Add(this.txtBehavior);
            this.Controls.Add(this.lblBehavior);
            this.Controls.Add(this.lblKeyStroke);
            this.Controls.Add(this.txtKeyStroke);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.bCancel);
            this.MinimumSize = new System.Drawing.Size(285, 136);
            this.Name = "ResearcherBehaviorKeyStrokeForm";
            this.ShowInTaskbar = false;
            this.Text = "Key Stroke";
            this.Load += new System.EventHandler(this.ResearcherBehaviorKeyStrokeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Label lblKeyStroke;
        private System.Windows.Forms.TextBox txtKeyStroke;
        private System.Windows.Forms.Label lblBehavior;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.TextBox txtBehavior;
    }
}