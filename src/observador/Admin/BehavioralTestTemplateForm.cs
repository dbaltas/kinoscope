using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using ObLib.Domain;

namespace observador
{
    public partial class BehavioralTestTemplateForm : ObWin.Form
    {
        private EntityTemplate _entityTemplate = null;

        public BehavioralTestTemplateForm()
        {            
            InitializeComponent();

            List<BehavioralTestType> cbBehavioralTestTypes = new List<BehavioralTestType>();

            BehavioralTestType emptyBehavioralTestType = new BehavioralTestType();
            emptyBehavioralTestType.Id = -1;
            emptyBehavioralTestType.Name = "[Please Select]";

            cbBehavioralTestTypes.Add(emptyBehavioralTestType);

            // code below throws following exception thus the foreach
            // Unable to cast object of type 'System.Collections.ArrayList' to type 'System.Collections.Generic.List`1[ObLib.Domain.BehavioralTestType]'
            // List<BehavioralTestType> allBehavioralTestTypes = (List<BehavioralTestType>)(BehavioralTestType.All());
            // cbBehavioralTestTypes.AddRange(allBehavioralTestTypes);
            foreach (BehavioralTestType type in BehavioralTestType.All())
            {
                cbBehavioralTestTypes.Add(type);
            }
            cmbBehavioralTestType.DataSource = cbBehavioralTestTypes;

            cmbBehavioralTestType.SelectedIndex = 0;
            cmbSessionCount.SelectedIndex = 0;
            cmbTrialCount.SelectedIndex = 0;
        }

        public BehavioralTestTemplateForm(EntityTemplate entityTemplate)
            : this()
        {
            _entityTemplate = entityTemplate;
            if (_entityTemplate != null)
            {
                txtName.Text = _entityTemplate.Name;
                // deserialize template and read duration txtDuration.Text = entityTemplate.
                BehavioralTest behavioralTest = EntityTemplate.GetAsBehavioralTest(_entityTemplate);
                txtDuration.Text = behavioralTest.Sessions[0].Trials[0].Duration.ToString();
                cmbBehavioralTestType.SelectedItem = behavioralTest.BehavioralTestType;
            }
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                ShowInputError();
                return;
            }

            if (Save())
            {
                Close();
            }
        }

        protected bool Save()
        {
            EntityTemplate entityTemplate;
            if (_entityTemplate == null)
            {
                entityTemplate = EntityTemplate.CreateSingleSessionSingleTrialTemplate(
                    (BehavioralTestType)cmbBehavioralTestType.SelectedItem,
                    txtName.Text,
                    Int32.Parse(txtDuration.Text));
            }
            else
            {
                entityTemplate = _entityTemplate;
                entityTemplate.UpdateAndSave((BehavioralTestType)cmbBehavioralTestType.SelectedItem,
                    txtName.Text,
                    Int32.Parse(txtDuration.Text));
            }
            if (CallerForm is ListForm<EntityTemplate>)
            {
                (CallerForm as ListForm<EntityTemplate>).OrderRefresh(entityTemplate);
            }

            return true;
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            Control control = (Control)sender;
            string text = control.Text;

            if (text.Length == 0)
            {
                e.Cancel = true;
                errorProvider.SetError(control, "Name can not be empty.");
                return;
            }

            if (!Regex.IsMatch(text, "^[a-zA-Z0-9_]*$"))
            {
                e.Cancel = true;
                errorProvider.SetError(control, "Name can only contain letters, numbers and underscores.");
                return;
            }

            errorProvider.SetError(control, "");
        }

        private void txtDuration_Validating(object sender, CancelEventArgs e)
        {
            Control control = (Control)sender;
            string text = control.Text;

            int result;
            if (!Int32.TryParse(text, out result))
            {
                e.Cancel = true;
                errorProvider.SetError(control, "Please provide a valid number for duration.");
                return;
            }
            if (result <= 0)
            {
                e.Cancel = true;
                errorProvider.SetError(control, "Please provide a positive number for duration.");
                return;
            }

            errorProvider.SetError(control, "");
        }

        private void cmbBehavioralTestType_Validating(object sender, CancelEventArgs e)
        {
            ComboBox control = (ComboBox)sender;
            int index = control.SelectedIndex;

            if (index == 0)
            {
                e.Cancel = true;
                errorProvider.SetError(control, "Please select a behavioral test type.");
                return;
            }

            errorProvider.SetError(control, "");
        }

    }
}
