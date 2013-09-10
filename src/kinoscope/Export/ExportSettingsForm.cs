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
        public ObLib.Export.ExportSettings exportSettings;
        public ExportSettingsForm(Trial trial)
        {
            MdiParent = null;
            InitializeComponent();
            this.trial = trial;
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
            exportSettings = new ObLib.Export.ExportSettings(trial, timeBinDuration);
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
    }
}
