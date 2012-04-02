using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ObLib;

namespace ObWin
{

    public partial class Form : System.Windows.Forms.Form
    {
        private static System.Windows.Forms.Form _mdiContainer;
        public Form CallerForm;

        public Form()  : base()
        {
            if (!IsMdiContainer)
            {
                MdiParent = _mdiContainer;
                StartPosition = FormStartPosition.CenterParent;
            }
        }

        public static void SetMDIContainer(System.Windows.Forms.Form form)
        {
            _mdiContainer = form;
        }

        protected void FailWithError(Exception ex)
        {
            Logger.logError(ex);

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
