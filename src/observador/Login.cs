using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ObWin;

namespace observador
{
    public partial class Login : ObWin.Form
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
            IsUserAuthenticated = true;
            Close();
        }
    }
}
