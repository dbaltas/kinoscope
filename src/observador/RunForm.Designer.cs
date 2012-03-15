﻿namespace observador
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
            this.dgvBehaviors = new System.Windows.Forms.DataGridView();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tssStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStateBehavior = new System.Windows.Forms.Label();
            this.eventVisualiserSecondary = new observador.TextEventVisualiser();
            this.eventVisualiserPrimary = new observador.RectanglesEventVisualiser();
            this.BehaviorKeyStroke = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BehaviorColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BehaviorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BehaviorType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBehaviors)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // bCancel
            // 
            this.bCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bCancel.CausesValidation = false;
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Location = new System.Drawing.Point(779, 444);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 6;
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
            this.bClear.CausesValidation = false;
            this.bClear.Location = new System.Drawing.Point(673, 444);
            this.bClear.Name = "bClear";
            this.bClear.Size = new System.Drawing.Size(75, 23);
            this.bClear.TabIndex = 5;
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
            this.lblTimer.TabIndex = 0;
            this.lblTimer.Text = "00:00:00";
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
            this.BehaviorColor,
            this.BehaviorName,
            this.BehaviorType});
            this.dgvBehaviors.Location = new System.Drawing.Point(546, 41);
            this.dgvBehaviors.Name = "dgvBehaviors";
            this.dgvBehaviors.ReadOnly = true;
            this.dgvBehaviors.RowHeadersVisible = false;
            this.dgvBehaviors.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvBehaviors.Size = new System.Drawing.Size(326, 397);
            this.dgvBehaviors.TabIndex = 3;
            this.dgvBehaviors.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvBehaviors_CellFormatting);
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
            // lblStateBehavior
            // 
            this.lblStateBehavior.AutoSize = true;
            this.lblStateBehavior.Font = new System.Drawing.Font("Courier New", 18.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblStateBehavior.Location = new System.Drawing.Point(228, 9);
            this.lblStateBehavior.Name = "lblStateBehavior";
            this.lblStateBehavior.Size = new System.Drawing.Size(0, 29);
            this.lblStateBehavior.TabIndex = 10;
            // 
            // eventVisualiserSecondary
            // 
            this.eventVisualiserSecondary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.eventVisualiserSecondary.Location = new System.Drawing.Point(13, 240);
            this.eventVisualiserSecondary.Multiline = true;
            this.eventVisualiserSecondary.Name = "eventVisualiserSecondary";
            this.eventVisualiserSecondary.ReadOnly = true;
            this.eventVisualiserSecondary.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.eventVisualiserSecondary.Size = new System.Drawing.Size(527, 198);
            this.eventVisualiserSecondary.TabIndex = 2;
            // 
            // eventVisualiserPrimary
            // 
            this.eventVisualiserPrimary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.eventVisualiserPrimary.BackColor = System.Drawing.Color.LightYellow;
            this.eventVisualiserPrimary.BarColor = System.Drawing.Color.Silver;
            this.eventVisualiserPrimary.BarHeightPercentage = 0.2F;
            this.eventVisualiserPrimary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.eventVisualiserPrimary.InstantEventWidthPercentage = 0.005F;
            this.eventVisualiserPrimary.Location = new System.Drawing.Point(12, 41);
            this.eventVisualiserPrimary.MarginHeightPercentage = 0.2F;
            this.eventVisualiserPrimary.Name = "eventVisualiserPrimary";
            this.eventVisualiserPrimary.NumberOfRows = 3;
            this.eventVisualiserPrimary.Size = new System.Drawing.Size(528, 193);
            this.eventVisualiserPrimary.TabIndex = 1;
            // 
            // BehaviorKeyStroke
            // 
            this.BehaviorKeyStroke.DataPropertyName = "KeyStroke";
            this.BehaviorKeyStroke.HeaderText = "Key";
            this.BehaviorKeyStroke.Name = "BehaviorKeyStroke";
            this.BehaviorKeyStroke.ReadOnly = true;
            this.BehaviorKeyStroke.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.BehaviorKeyStroke.Width = 70;
            // 
            // BehaviorColor
            // 
            this.BehaviorColor.HeaderText = "";
            this.BehaviorColor.Name = "BehaviorColor";
            this.BehaviorColor.ReadOnly = true;
            this.BehaviorColor.Width = 20;
            // 
            // BehaviorName
            // 
            this.BehaviorName.DataPropertyName = "Name";
            this.BehaviorName.HeaderText = "Name";
            this.BehaviorName.Name = "BehaviorName";
            this.BehaviorName.ReadOnly = true;
            this.BehaviorName.Width = 145;
            // 
            // BehaviorType
            // 
            this.BehaviorType.DataPropertyName = "Type";
            this.BehaviorType.HeaderText = "Type";
            this.BehaviorType.Name = "BehaviorType";
            this.BehaviorType.ReadOnly = true;
            this.BehaviorType.Width = 88;
            // 
            // RunForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bCancel;
            this.ClientSize = new System.Drawing.Size(884, 492);
            this.Controls.Add(this.lblStateBehavior);
            this.Controls.Add(this.eventVisualiserSecondary);
            this.Controls.Add(this.eventVisualiserPrimary);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.dgvBehaviors);
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
        private System.Windows.Forms.DataGridView dgvBehaviors;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel tssStatus;
        private RectanglesEventVisualiser eventVisualiserPrimary;
        private TextEventVisualiser eventVisualiserSecondary;
        private System.Windows.Forms.Label lblStateBehavior;
        private System.Windows.Forms.DataGridViewTextBoxColumn BehaviorKeyStroke;
        private System.Windows.Forms.DataGridViewTextBoxColumn BehaviorColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn BehaviorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn BehaviorType;

    }
}