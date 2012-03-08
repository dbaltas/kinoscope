using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace ObWin
{

    public partial class Form : System.Windows.Forms.Form
    {
        protected void FailWithError(Exception ex)
        {
            // TODO: Log exception

            ShowError(string.Format(
                "A non-recoverable error has occurred. The application will now terminate. " +
                "We are sorry for the inconvenience.{0}{0}Error details:{0}{1}",
                Environment.NewLine, ex.Message));

            Application.Exit();
        }

        protected void ShowError(Exception ex)
        {
            ShowError(ex.Message);
        }

        protected void ShowError(string errorMessage)
        {
            MessageBox.Show(errorMessage, "Error!");
        }

        protected void ShowInputError()
        {
            MessageBox.Show("Please review the errors and correct the input.", "Incorrect input");
        }
    }
}
