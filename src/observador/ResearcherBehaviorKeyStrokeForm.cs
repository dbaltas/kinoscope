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
    //TODO: Not tested: Test! (Delete crashes)
    //TODO: Use KeyDown event to detect key stroke.
    public partial class ResearcherBehaviorKeyStrokeForm : ObWin.Form
    {
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

            List<VerboseBehavior> verboseBehaviors = new List<VerboseBehavior>();
            foreach (Behavior behavior in Behavior.All())
            {
                verboseBehaviors.Add(new VerboseBehavior() { Behavior = behavior });
            }

            cbBehavior.DataSource = verboseBehaviors;
        }

        public ResearcherBehaviorKeyStrokeForm(ResearcherBehaviorKeyStroke researcherBehaviorKeyStroke)
            : this()
        {
            if (researcherBehaviorKeyStroke != null)
            {
                _researcherBehaviorKeyStroke = researcherBehaviorKeyStroke;

                foreach (object cbBehaviorItem in cbBehavior.Items)
                {
                    if (((VerboseBehavior)cbBehaviorItem).Behavior == researcherBehaviorKeyStroke.Behavior)
                    {
                        cbBehavior.SelectedItem = researcherBehaviorKeyStroke.Behavior;
                        break;
                    }
                }
                txtKeyStroke.Text = researcherBehaviorKeyStroke.KeyStroke;
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
                ResearcherBehaviorKeyStroke researcherBehaviorKeyStroke =
                    _researcherBehaviorKeyStroke ?? new ResearcherBehaviorKeyStroke();

                researcherBehaviorKeyStroke.Behavior = ((VerboseBehavior)cbBehavior.SelectedItem).Behavior;
                researcherBehaviorKeyStroke.KeyStroke = txtKeyStroke.Text;

                if (_researcherBehaviorKeyStroke == null)
                {
                    Researcher.Current.AddResearcherBehaviorKeyStroke(researcherBehaviorKeyStroke);
                }

                Researcher.Current.Save();

                this.Close();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }
    }
}
