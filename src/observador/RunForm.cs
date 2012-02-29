using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ObLib.Domain;
using ObLib;

namespace observador
{
    public partial class RunForm : Form
    {
        Run _run;
        public RunForm(Run run)
        {
            _run = run;
            InitializeComponent();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            _run.Tm = DateTime.Now;

            _run.Trial.Save();
            this.Close();
        }
    }
}
