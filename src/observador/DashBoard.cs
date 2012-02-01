using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ObLib.Domain;
using ObLib.Repositories;

using ObWin;

namespace observador
{
    public partial class DashBoard : ObWin.Form
    {
        public DashBoard()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void researchersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminResearchers form = new AdminResearchers();
            form.Show();
        }

        private void bCreateDatabase_Click(object sender, EventArgs e)
        {
            NHibernateHelper.BuildSchema();
            SeedData.AddInitialData();
        }
    }
}
