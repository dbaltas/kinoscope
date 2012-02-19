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

        private void bQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bCreateDatabase_Click(object sender, EventArgs e)
        {
            NHibernateHelper.BuildSchema();
            SeedData.AddInitialData();
            Application.Exit();
        }

        private void researchersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminResearcherListForm form = new AdminResearcherListForm();
            form.Show();
        }

        private void createDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NHibernateHelper.BuildSchema();
            SeedData.AddInitialData();
        }

        private void myProjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProjectListForm form = new ProjectListForm();
            form.Show();
        }

        private void bResearchers_Click(object sender, EventArgs e)
        {
            AdminResearcherListForm form = new AdminResearcherListForm();
            form.Show();
        }

        private void DashBoard_Load(object sender, EventArgs e)
        {
            Login login = new Login();
            login.ShowDialog();

            if(!login.IsUserAuthenticated)
            {
                Application.Exit();
            }
            if (Researcher.Current() != null)
            {
                tssResearcher.Text = String.Format("Researcher {0} logged in",  Researcher.Current().Username);
            }
        }
    }
}
