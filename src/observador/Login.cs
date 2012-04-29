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
    public partial class Login : Form
    {
        public bool IsUserAuthenticated { get; private set; }

        public Login()
        {
            InitializeComponent();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            IsUserAuthenticated = false;
            Close();
        }

        private void bLogin_Click(object sender, EventArgs e)
        {
            SubmitForm();
        }

        private void SubmitForm()
        {
            Cursor.Current = Cursors.WaitCursor;
            Researcher authenticatedResearcher = Researcher.Authenticate(txtUsername.Text, txtPassword.Text);
            IsUserAuthenticated = true;
            if (authenticatedResearcher == null)
            {
                MessageBox.Show("Invalid username or password.", "Login failed");
                txtUsername.Focus();
                return;
            }
            Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            Text = string.Format("{0} - Login", Program.GetTitle());
        }
    }
}
