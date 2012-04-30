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

namespace observador
{
    public partial class ResearcherBehaviorKeyStrokeForm : ObWin.Form
    {
        private KeysConverter _keysConverter = new KeysConverter();

        private class VerboseBehavior
        {
            public Behavior Behavior { get; set; }

            public override string ToString()
            {
                return string.Format("{0} ({1})", Behavior, Behavior.BehavioralTestType);
            }
        }

        private ResearcherBehaviorKeyStroke _researcherBehaviorKeyStroke = null;

        public ResearcherBehaviorKeyStrokeForm()
        {
            InitializeComponent();
        }

        public ResearcherBehaviorKeyStrokeForm(ResearcherBehaviorKeyStroke researcherBehaviorKeyStroke)
            : this()
        {
            if (researcherBehaviorKeyStroke != null)
            {
                _researcherBehaviorKeyStroke = researcherBehaviorKeyStroke;
            }
        }

        private void ResearcherBehaviorKeyStrokeForm_Load(object sender, EventArgs e)
        {
            VerboseBehavior verboseBehavior = new VerboseBehavior() { Behavior = _researcherBehaviorKeyStroke.Behavior };

            txtBehavior.Text = verboseBehavior.ToString();

            if (_researcherBehaviorKeyStroke != null)
            {
                txtKeyStroke.Text = _researcherBehaviorKeyStroke.KeyStroke;
            }
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateChildren())
                {
                    ShowInputError();
                    return;
                }

                _researcherBehaviorKeyStroke.KeyStroke = txtKeyStroke.Text;

                if (_researcherBehaviorKeyStroke.Id == 0) // not persisted in database
                {
                    Researcher.Current.AddResearcherBehaviorKeyStroke(_researcherBehaviorKeyStroke);
                    Researcher.Current.Save();
                }
                else
                {
                    _researcherBehaviorKeyStroke.Save();
                }

                if (CallerForm is ListForm<ResearcherBehaviorKeyStroke>)
                {
                    (CallerForm as ListForm<ResearcherBehaviorKeyStroke>).OrderRefresh(_researcherBehaviorKeyStroke);
                }

                this.Close();
            }
            catch (Exception ex)
            {
                FailWithError(ex);
            }
        }

        private void txtKeyStroke_KeyDown(object sender, KeyEventArgs e)
        {
            txtKeyStroke.Text = _keysConverter.ConvertToString(e.KeyCode);
        }

        private void txtKeyStroke_Validating(object sender, CancelEventArgs e)
        {
            if (txtKeyStroke.Text == "")
            {
                e.Cancel = true;
                errorProvider.SetError(txtKeyStroke, "Key stroke is required.");
            }
            else
            {
                errorProvider.SetError(txtKeyStroke, "");
            }
        }
    }
}
