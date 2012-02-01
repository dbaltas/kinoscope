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
        public Login()
        {
            InitializeComponent();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bLogin_Click(object sender, EventArgs e)
        {
            DashBoard form = new DashBoard();
            if (IsUSerAuthenticated())
            {
                form.ShowDialog();
            }
        }

        private bool IsUSerAuthenticated()
        {
            return true;
        }

        private void bLogin_Click_1(object sender, EventArgs e)
        {

        }
    }
}
