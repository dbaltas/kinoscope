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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbRun = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbTrial = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.eventVisualiserText = new observador.TextEventVisualiser();
            this.eventVisualiserRectangles = new observador.RectanglesEventVisualiser();
            this.eventVisualiserBehaviorList = new observador.BehaviorListEventVisualiser();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventVisualiserBehaviorList)).BeginInit();
            this.SuspendLayout();
            // 
            // bCancel
            // 
            this.bCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bCancel.CausesValidation = false;
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Location = new System.Drawing.Point(600, 421);
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
            this.bSave.Location = new System.Drawing.Point(328, 421);
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
            this.bClear.Location = new System.Drawing.Point(463, 421);
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
            this.statusStrip.Location = new System.Drawing.Point(0, 447);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(723, 22);
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
            this.lblStateBehavior.Size = new System.Drawing.Size(238, 29);
            this.lblStateBehavior.TabIndex = 10;
            this.lblStateBehavior.Text = "no run selected";
            // 
            // lblSubjectCode
            // 
            this.lblSubjectCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSubjectCode.Font = new System.Drawing.Font("Courier New", 18.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblSubjectCode.Location = new System.Drawing.Point(572, 9);
            this.lblSubjectCode.Name = "lblSubjectCode";
            this.lblSubjectCode.Size = new System.Drawing.Size(139, 29);
            this.lblSubjectCode.TabIndex = 11;
            this.lblSubjectCode.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbRun);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbTrial);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(335, 268);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(372, 123);
            this.panel1.TabIndex = 0;
            this.panel1.TabStop = true;
            // 
            // cbRun
            // 
            this.cbRun.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRun.FormattingEnabled = true;
            this.cbRun.Location = new System.Drawing.Point(75, 88);
            this.cbRun.Name = "cbRun";
            this.cbRun.Size = new System.Drawing.Size(279, 21);
            this.cbRun.TabIndex = 16;
            this.cbRun.SelectedIndexChanged += new System.EventHandler(this.cbRun_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Subject";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Trial";
            // 
            // cbTrial
            // 
            this.cbTrial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTrial.FormattingEnabled = true;
            this.cbTrial.Location = new System.Drawing.Point(75, 46);
            this.cbTrial.Name = "cbTrial";
            this.cbTrial.Size = new System.Drawing.Size(279, 21);
            this.cbTrial.TabIndex = 13;
            this.cbTrial.SelectedIndexChanged += new System.EventHandler(this.cbTrial_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label2.Location = new System.Drawing.Point(11, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(350, 58);
            this.label2.TabIndex = 12;
            this.label2.Text = "Select The Trial and the Subject you wish to score";
            // 
            // eventVisualiserText
            // 
            this.eventVisualiserText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.eventVisualiserText.Location = new System.Drawing.Point(13, 231);
            this.eventVisualiserText.Multiline = true;
            this.eventVisualiserText.Name = "eventVisualiserText";
            this.eventVisualiserText.ReadOnly = true;
            this.eventVisualiserText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.eventVisualiserText.Size = new System.Drawing.Size(309, 213);
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
            this.eventVisualiserRectangles.Size = new System.Drawing.Size(699, 184);
            this.eventVisualiserRectangles.TabIndex = 1;
            // 
            // eventVisualiserBehaviorList
            // 
            this.eventVisualiserBehaviorList.AllowUserToAddRows = false;
            this.eventVisualiserBehaviorList.AllowUserToDeleteRows = false;
            this.eventVisualiserBehaviorList.AllowUserToResizeColumns = false;
            this.eventVisualiserBehaviorList.AllowUserToResizeRows = false;
            this.eventVisualiserBehaviorList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.eventVisualiserBehaviorList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.eventVisualiserBehaviorList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn16,
            this.dataGridViewTextBoxColumn17,
            this.dataGridViewTextBoxColumn18,
            this.dataGridViewTextBoxColumn19,
            this.dataGridViewTextBoxColumn20});
            this.eventVisualiserBehaviorList.Location = new System.Drawing.Point(328, 231);
            this.eventVisualiserBehaviorList.Name = "eventVisualiserBehaviorList";
            this.eventVisualiserBehaviorList.ReadOnly = true;
            this.eventVisualiserBehaviorList.RowHeadersVisible = false;
            this.eventVisualiserBehaviorList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.eventVisualiserBehaviorList.Size = new System.Drawing.Size(383, 184);
            this.eventVisualiserBehaviorList.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "KeyStroke";
            this.dataGridViewTextBoxColumn16.HeaderText = "Key";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.ReadOnly = true;
            this.dataGridViewTextBoxColumn16.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn16.Width = 40;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.HeaderText = "";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            this.dataGridViewTextBoxColumn17.Width = 20;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn18.HeaderText = "Name";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.ReadOnly = true;
            this.dataGridViewTextBoxColumn18.Width = 145;
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.DataPropertyName = "Type";
            this.dataGridViewTextBoxColumn19.HeaderText = "Type";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.ReadOnly = true;
            this.dataGridViewTextBoxColumn19.Width = 78;
            // 
            // dataGridViewTextBoxColumn20
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn20.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn20.HeaderText = "Duration/Count";
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            this.dataGridViewTextBoxColumn20.ReadOnly = true;
            this.dataGridViewTextBoxColumn20.Width = 96;
            // 
            // RunForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bCancel;
            this.ClientSize = new System.Drawing.Size(723, 469);
            this.Controls.Add(this.panel1);
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
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbRun;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbTrial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
    }
}