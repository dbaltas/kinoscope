namespace observador
{
    partial class RunForm
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
            this.bStart = new System.Windows.Forms.Button();
            this.bClear = new System.Windows.Forms.Button();
            this.bStop = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.lblTimer = new System.Windows.Forms.Label();
            this.pnlEventVisualiser = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // bCancel
            // 
            this.bCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Location = new System.Drawing.Point(672, 320);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 5;
            this.bCancel.Text = "Discard";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // bSave
            // 
            this.bSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bSave.Location = new System.Drawing.Point(561, 320);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(75, 23);
            this.bSave.TabIndex = 4;
            this.bSave.Text = "Save Run";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bStart
            // 
            this.bStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.bStart.Location = new System.Drawing.Point(55, 320);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(75, 23);
            this.bStart.TabIndex = 1;
            this.bStart.Text = "Start!";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.bStart_Click);
            // 
            // bClear
            // 
            this.bClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bClear.Location = new System.Drawing.Point(277, 320);
            this.bClear.Name = "bClear";
            this.bClear.Size = new System.Drawing.Size(75, 23);
            this.bClear.TabIndex = 3;
            this.bClear.Text = "Reset";
            this.bClear.UseVisualStyleBackColor = true;
            this.bClear.Click += new System.EventHandler(this.bClear_Click);
            // 
            // bStop
            // 
            this.bStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bStop.Location = new System.Drawing.Point(166, 320);
            this.bStop.Name = "bStop";
            this.bStop.Size = new System.Drawing.Size(75, 23);
            this.bStop.TabIndex = 2;
            this.bStop.Text = "Stop";
            this.bStop.UseVisualStyleBackColor = true;
            this.bStop.Click += new System.EventHandler(this.bStop_Click);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Font = new System.Drawing.Font("Courier New", 18.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblTimer.Location = new System.Drawing.Point(12, 9);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(133, 29);
            this.lblTimer.TabIndex = 6;
            this.lblTimer.Text = "00:00:00";
            // 
            // pnlEventVisualiser
            // 
            this.pnlEventVisualiser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlEventVisualiser.Location = new System.Drawing.Point(12, 41);
            this.pnlEventVisualiser.Name = "pnlEventVisualiser";
            this.pnlEventVisualiser.Size = new System.Drawing.Size(768, 273);
            this.pnlEventVisualiser.TabIndex = 7;
            // 
            // RunForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bCancel;
            this.ClientSize = new System.Drawing.Size(792, 366);
            this.Controls.Add(this.pnlEventVisualiser);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.bStop);
            this.Controls.Add(this.bClear);
            this.Controls.Add(this.bStart);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.bCancel);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(649, 209);
            this.Name = "RunForm";
            this.ShowInTaskbar = false;
            this.Text = "Run";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RunForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.Button bClear;
        private System.Windows.Forms.Button bStop;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Panel pnlEventVisualiser;

    }
}