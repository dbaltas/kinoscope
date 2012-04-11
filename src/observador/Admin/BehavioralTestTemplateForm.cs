using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
            cmbBehavioralTestType.DataSource = BehavioralTestType.All();
            cmbBehavioralTestType.SelectedIndex = 0;
            cmbSessionCount.SelectedIndex = 0;
            cmbTrialCount.SelectedIndex = 0;
        }

        public BehavioralTestTemplateForm(EntityTemplate entityTemplate)
            : this()
        {
            _entityTemplate = entityTemplate;
            if (entityTemplate != null)
            {
                txtName.Text = entityTemplate.Name;
                // deserialize template and read duration txtDuration.Text = entityTemplate.
                BehavioralTest behavioralTest = EntityTemplate.GetAsBehavioralTest(entityTemplate);
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

    }
}
