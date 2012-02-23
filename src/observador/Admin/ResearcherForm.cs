using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ObLib.Domain;

namespace observador
{
    public partial class AdminResearcherForm : Form
    {
        private Researcher _researcher = null;

        public AdminResearcherForm()
        {
            InitializeComponent();
        }

        public AdminResearcherForm(Researcher researcher) : this()
        {
            if (researcher != null)
            {
                _researcher = researcher;
                txtUsername.Text = researcher.Username;
                txtPassword.Text = researcher.Password;
                txtConfirmPassword.Text = researcher.Password;
            }
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            Researcher researcher = _researcher ?? new Researcher();
            researcher.Username = txtUsername.Text;
            researcher.Password = txtPassword.Text;
            researcher.Save();
            this.Close();
        }
    }
}
