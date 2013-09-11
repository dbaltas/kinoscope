using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ObLib.Domain;

namespace kinoscope.Export
{
    public partial class ExportSettingsForm : ObWin.Form
    {
        private Trial trial;
        private int timeBinDuration = -1;
        private int exportStart = -1;
        private int exportEnd = -1;
        public ObLib.Export.ExportSettings exportSettings;
        public ExportSettingsForm(Trial trial)
        {
            MdiParent = null;
            InitializeComponent();
            this.trial = trial;
            txtExportStart.Text = 0.ToString();
            txtExportEnd.Text = trial.Duration.ToString();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bExport_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                ShowInputError();
                return;
            }
            exportSettings = new ObLib.Export.ExportSettings(trial, timeBinDuration, exportStart, exportEnd);
            Close();
        }

        private void txtTimeBinDuration_Validating(object sender, CancelEventArgs e)
        {
            bool hasError = false;
            if (ckExportTimeBins.Checked)
            {
                int duration;
                if (int.TryParse(txtTimeBinDuration.Text, out duration))
                {
                    hasError = duration <= 0 || duration > trial.Duration;
                    if (!hasError) timeBinDuration = duration;
                }
                else hasError = true;

            }

            e.Cancel = hasError;
            errorProvider1.SetError(txtTimeBinDuration, hasError ? "Invalid Time Bin Duration." : "");
        }

        private void ckExportTimeBins_CheckedChanged(object sender, EventArgs e)
        {
            txtTimeBinDuration.Enabled = ckExportTimeBins.Checked;
        }

        private void txtExportStart_Validating(object sender, CancelEventArgs e)
        {
            bool hasError = false;
                int start;
                if (int.TryParse(txtExportStart.Text, out start))
                {
                    hasError = start < 0 || start >= trial.Duration;
                    if (!hasError) exportStart = start;
                }
                else hasError = true;

            e.Cancel = hasError;
            errorProvider1.SetError(txtTimeBinDuration, hasError ? "Invalid Export Start." : "");
        }

        private void txtExportEnd_Validating(object sender, CancelEventArgs e)
        {
            bool hasError = false;
                int end;
                if (int.TryParse(txtExportEnd.Text, out end))
                {
                    hasError = end <= 0 || end > trial.Duration;
                    if (!hasError) exportEnd = end;
                }
                else hasError = true;

            e.Cancel = hasError;
            errorProvider1.SetError(txtTimeBinDuration, hasError ? "Invalid Export end." : "");
        }
    }
}
