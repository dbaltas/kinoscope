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
            this.bClear = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.lblTimer = new System.Windows.Forms.Label();
            this.pnlEventVisualiser = new System.Windows.Forms.Panel();
            this.dgvBehaviors = new System.Windows.Forms.DataGridView();
            this.BehaviorKeyStroke = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BehaviorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BehaviorType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tssStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlEventVisualiserSecondary = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBehaviors)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // bCancel
            // 
            this.bCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Location = new System.Drawing.Point(779, 444);
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
            this.bSave.Enabled = false;
            this.bSave.Location = new System.Drawing.Point(568, 444);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(75, 23);
            this.bSave.TabIndex = 4;
            this.bSave.Text = "Save Run";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bClear
            // 
            this.bClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bClear.Location = new System.Drawing.Point(673, 444);
            this.bClear.Name = "bClear";
            this.bClear.Size = new System.Drawing.Size(75, 23);
            this.bClear.TabIndex = 3;
            this.bClear.Text = "Reset";
            this.bClear.UseVisualStyleBackColor = true;
            this.bClear.Click += new System.EventHandler(this.bClear_Click);
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
            this.pnlEventVisualiser.Size = new System.Drawing.Size(527, 205);
            this.pnlEventVisualiser.TabIndex = 7;
            // 
            // dgvBehaviors
            // 
            this.dgvBehaviors.AllowUserToAddRows = false;
            this.dgvBehaviors.AllowUserToDeleteRows = false;
            this.dgvBehaviors.AllowUserToOrderColumns = true;
            this.dgvBehaviors.AllowUserToResizeColumns = false;
            this.dgvBehaviors.AllowUserToResizeRows = false;
            this.dgvBehaviors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBehaviors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvBehaviors.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BehaviorKeyStroke,
            this.BehaviorName,
            this.BehaviorType});
            this.dgvBehaviors.Location = new System.Drawing.Point(546, 41);
            this.dgvBehaviors.Name = "dgvBehaviors";
            this.dgvBehaviors.ReadOnly = true;
            this.dgvBehaviors.RowHeadersVisible = false;
            this.dgvBehaviors.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvBehaviors.Size = new System.Drawing.Size(326, 397);
            this.dgvBehaviors.TabIndex = 8;
            // 
            // BehaviorKeyStroke
            // 
            this.BehaviorKeyStroke.DataPropertyName = "KeyStroke";
            this.BehaviorKeyStroke.HeaderText = "Key";
            this.BehaviorKeyStroke.Name = "BehaviorKeyStroke";
            this.BehaviorKeyStroke.ReadOnly = true;
            this.BehaviorKeyStroke.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.BehaviorKeyStroke.Width = 40;
            // 
            // BehaviorName
            // 
            this.BehaviorName.DataPropertyName = "Name";
            this.BehaviorName.HeaderText = "Name";
            this.BehaviorName.Name = "BehaviorName";
            this.BehaviorName.ReadOnly = true;
            this.BehaviorName.Width = 175;
            // 
            // BehaviorType
            // 
            this.BehaviorType.DataPropertyName = "Type";
            this.BehaviorType.HeaderText = "Type";
            this.BehaviorType.Name = "BehaviorType";
            this.BehaviorType.ReadOnly = true;
            this.BehaviorType.Width = 108;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssStatus});
            this.statusStrip.Location = new System.Drawing.Point(0, 470);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(884, 22);
            this.statusStrip.TabIndex = 9;
            this.statusStrip.Text = "Ready";
            // 
            // tssStatus
            // 
            this.tssStatus.Name = "tssStatus";
            this.tssStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // pnlEventVisualiserSecondary
            // 
            this.pnlEventVisualiserSecondary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlEventVisualiserSecondary.Location = new System.Drawing.Point(12, 252);
            this.pnlEventVisualiserSecondary.Name = "pnlEventVisualiserSecondary";
            this.pnlEventVisualiserSecondary.Size = new System.Drawing.Size(527, 215);
            this.pnlEventVisualiserSecondary.TabIndex = 8;
            // 
            // RunForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bCancel;
            this.ClientSize = new System.Drawing.Size(884, 492);
            this.Controls.Add(this.pnlEventVisualiserSecondary);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.dgvBehaviors);
            this.Controls.Add(this.pnlEventVisualiser);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.bClear);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.bCancel);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(649, 396);
            this.Name = "RunForm";
            this.ShowInTaskbar = false;
            this.Text = "Run";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RunForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBehaviors)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Button bClear;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Panel pnlEventVisualiser;
        private System.Windows.Forms.DataGridView dgvBehaviors;
        private System.Windows.Forms.DataGridViewTextBoxColumn BehaviorKeyStroke;
        private System.Windows.Forms.DataGridViewTextBoxColumn BehaviorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn BehaviorType;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel tssStatus;
        private System.Windows.Forms.Panel pnlEventVisualiserSecondary;

    }
}