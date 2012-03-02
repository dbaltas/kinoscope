using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace ObWin
{

    public partial class Form : System.Windows.Forms.Form
    {
        protected void ShowError(Exception ex)
        {
            ShowError(ex.Message);
        }

        protected void ShowError(string errorMessage)
        {
            MessageBox.Show(errorMessage, "Error!");
        }
    }
}
