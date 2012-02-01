using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace ObWin
{
 
    public partial class Form : System.Windows.Forms.Form
    {
        private void InitializeComponent()
        {
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
