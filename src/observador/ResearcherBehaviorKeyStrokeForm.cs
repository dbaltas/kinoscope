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
            List<VerboseBehavior> verboseBehaviors = new List<VerboseBehavior>();
            foreach (Behavior behavior in Behavior.All())
            {
                // Show only behaviors that the user hasn't assigned yet, except for the edited behavior, if any.
                if ((_researcherBehaviorKeyStroke != null && _researcherBehaviorKeyStroke.Behavior.Id == behavior.Id)
                    || !Researcher.Current.ResearcherBehaviorKeyStrokes.Any((item) => item.Behavior.Id == behavior.Id))
                {
                    verboseBehaviors.Add(new VerboseBehavior() { Behavior = behavior });
                }
            }

            cbBehavior.DataSource = verboseBehaviors;

            if (_researcherBehaviorKeyStroke != null)
            {
                foreach (object cbBehaviorItem in cbBehavior.Items)
                {
                    if (((VerboseBehavior)cbBehaviorItem).Behavior.Id == _researcherBehaviorKeyStroke.Behavior.Id)
                    {
                        cbBehavior.SelectedItem = cbBehaviorItem;
                        break;
                    }
                }
                txtKeyStroke.Text = _researcherBehaviorKeyStroke.KeyStroke;
            }

            if (cbBehavior.Items.Count == 0)
            {
                MessageBox.Show("All behaviors have been assigned custom key strokes.", "No more behaviors");
                Close();
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

                ResearcherBehaviorKeyStroke researcherBehaviorKeyStroke =
                    _researcherBehaviorKeyStroke ?? new ResearcherBehaviorKeyStroke();

                researcherBehaviorKeyStroke.Behavior = ((VerboseBehavior)cbBehavior.SelectedItem).Behavior;
                researcherBehaviorKeyStroke.KeyStroke = txtKeyStroke.Text;

                if (_researcherBehaviorKeyStroke == null)
                {
                    Researcher.Current.AddResearcherBehaviorKeyStroke(researcherBehaviorKeyStroke);
                    Researcher.Current.Save();
                }
                else
                {
                    _researcherBehaviorKeyStroke.Save();
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
