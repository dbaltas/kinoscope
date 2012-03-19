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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bCancel = new System.Windows.Forms.Button();
            this.bSave = new System.Windows.Forms.Button();
            this.bClear = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.lblTimer = new System.Windows.Forms.Label();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tssStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStateBehavior = new System.Windows.Forms.Label();
            this.lblSubjectCode = new System.Windows.Forms.Label();
            this.eventVisualiserText = new observador.TextEventVisualiser();
            this.eventVisualiserRectangles = new observador.RectanglesEventVisualiser();
            this.eventVisualiserBehaviorList = new observador.BehaviorListEventVisualiser();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventVisualiserBehaviorList)).BeginInit();
            this.SuspendLayout();
            // 
            // bCancel
            // 
            this.bCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bCancel.CausesValidation = false;
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Location = new System.Drawing.Point(556, 405);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(110, 23);
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
            this.bSave.Location = new System.Drawing.Point(284, 405);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(110, 23);
            this.bSave.TabIndex = 4;
            this.bSave.Text = "Save Run";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bClear
            // 
            this.bClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bClear.CausesValidation = false;
            this.bClear.Location = new System.Drawing.Point(419, 405);
            this.bClear.Name = "bClear";
            this.bClear.Size = new System.Drawing.Size(110, 23);
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
            this.lblTimer.Size = new System.Drawing.Size(193, 29);
            this.lblTimer.TabIndex = 0;
            this.lblTimer.Text = "00:00:00.000";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssStatus});
            this.statusStrip.Location = new System.Drawing.Point(0, 431);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(695, 22);
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
            this.lblStateBehavior.Size = new System.Drawing.Size(178, 29);
            this.lblStateBehavior.TabIndex = 10;
            this.lblStateBehavior.Text = "lblStateBeh";
            // 
            // lblSubjectCode
            // 
            this.lblSubjectCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSubjectCode.Font = new System.Drawing.Font("Courier New", 18.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblSubjectCode.Location = new System.Drawing.Point(460, 9);
            this.lblSubjectCode.Name = "lblSubjectCode";
            this.lblSubjectCode.Size = new System.Drawing.Size(223, 29);
            this.lblSubjectCode.TabIndex = 11;
            this.lblSubjectCode.Text = "lblSubjectCode";
            this.lblSubjectCode.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // eventVisualiserText
            // 
            this.eventVisualiserText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.eventVisualiserText.Location = new System.Drawing.Point(13, 230);
            this.eventVisualiserText.Multiline = true;
            this.eventVisualiserText.Name = "eventVisualiserText";
            this.eventVisualiserText.ReadOnly = true;
            this.eventVisualiserText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.eventVisualiserText.Size = new System.Drawing.Size(245, 198);
            this.eventVisualiserText.TabIndex = 2;
            // 
            // eventVisualiserRectangles
            // 
            this.eventVisualiserRectangles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.eventVisualiserRectangles.BackColor = System.Drawing.Color.LightYellow;
            this.eventVisualiserRectangles.BarColor = System.Drawing.Color.Silver;
            this.eventVisualiserRectangles.BarHeightPercentage = 0.2F;
            this.eventVisualiserRectangles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.eventVisualiserRectangles.InstantEventWidthPercentage = 0.005F;
            this.eventVisualiserRectangles.Location = new System.Drawing.Point(12, 41);
            this.eventVisualiserRectangles.MarginHeightPercentage = 0.2F;
            this.eventVisualiserRectangles.Name = "eventVisualiserRectangles";
            this.eventVisualiserRectangles.NumberOfRows = 3;
            this.eventVisualiserRectangles.Size = new System.Drawing.Size(671, 183);
            this.eventVisualiserRectangles.TabIndex = 1;
            // 
            // eventVisualiserBehaviorList
            // 
            this.eventVisualiserBehaviorList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.eventVisualiserBehaviorList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.eventVisualiserBehaviorList.Location = new System.Drawing.Point(264, 230);
            this.eventVisualiserBehaviorList.Name = "eventVisualiserBehaviorList";
            this.eventVisualiserBehaviorList.ReadOnly = true;
            this.eventVisualiserBehaviorList.RowHeadersVisible = false;
            this.eventVisualiserBehaviorList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.eventVisualiserBehaviorList.Size = new System.Drawing.Size(419, 169);
            this.eventVisualiserBehaviorList.TabIndex = 3;
            // 
            // RunForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bCancel;
            this.ClientSize = new System.Drawing.Size(695, 453);
            this.Controls.Add(this.lblSubjectCode);
            this.Controls.Add(this.lblStateBehavior);
            this.Controls.Add(this.eventVisualiserText);
            this.Controls.Add(this.eventVisualiserRectangles);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.eventVisualiserBehaviorList);
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
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventVisualiserBehaviorList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Button bClear;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label lblTimer;
        private BehaviorListEventVisualiser eventVisualiserBehaviorList;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel tssStatus;
        private RectanglesEventVisualiser eventVisualiserRectangles;
        private TextEventVisualiser eventVisualiserText;
        private System.Windows.Forms.Label lblStateBehavior;
        private System.Windows.Forms.Label lblSubjectCode;
    }
}