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
    public partial class AdminResearcher : Form
    {
        public AdminResearcher()
        {
            InitializeComponent();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            Researcher researcher = new Researcher();
            researcher.Username = txtUsername.Text;
            researcher.Password = txtPassword.Text;
            researcher.Save();
            this.Close();
        }
    }
}
