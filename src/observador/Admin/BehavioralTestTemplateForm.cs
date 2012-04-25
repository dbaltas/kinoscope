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
        private BehavioralTest _BehavioralTestTemplate;

        public BehavioralTestTemplateForm(EntityTemplate entityTemplate = null)
        {            
            InitializeComponent();
            flowLayoutPanel1.HorizontalScroll.Visible = false;

            List<BehavioralTestType> cbBehavioralTestTypes = new List<BehavioralTestType>();

            BehavioralTestType emptyBehavioralTestType = new BehavioralTestType();
            emptyBehavioralTestType.Id = -1;
            emptyBehavioralTestType.Name = "[Please Select]";

            cbBehavioralTestTypes.Add(emptyBehavioralTestType);

            foreach (BehavioralTestType type in BehavioralTestType.All())
            {
                cbBehavioralTestTypes.Add(type);
            }
            cmbBehavioralTestType.DataSource = cbBehavioralTestTypes;

            cmbBehavioralTestType.SelectedIndex = 0;

            _BehavioralTestTemplate = new BehavioralTest();

            if (entityTemplate != null)
            {
                _entityTemplate = entityTemplate;
                txtName.Text = _entityTemplate.Name;

                // deserialize template and read duration txtDuration.Text = entityTemplate.
                BehavioralTest behavioralTest = EntityTemplate.GetAsBehavioralTest(_entityTemplate);
                _BehavioralTestTemplate = behavioralTest;
                cmbBehavioralTestType.SelectedItem = behavioralTest.BehavioralTestType;

                for (int index = 0; index < behavioralTest.Sessions.Count; index++)
                {
                    Session session = behavioralTest.Sessions[index];
                    AddSessionControl(session, index);
                }
            }

            cmbSessionCount.SelectedItem = _BehavioralTestTemplate.Sessions.Count.ToString();

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

                entityTemplate = new EntityTemplate();
            }
            else
            {
                entityTemplate = _entityTemplate;
            }

            for (int ix = flowLayoutPanel1.Controls.Count - 1; ix >= 0; ix--)
            {
                Control c = flowLayoutPanel1.Controls[ix];
                if (c is BehavioralTestTemplateSessionControl)
                {
                    BehavioralTestTemplateSessionControl bc = (BehavioralTestTemplateSessionControl)c;
                    bc.Save();
                }
            }

            _BehavioralTestTemplate.Name = txtName.Text;
            _BehavioralTestTemplate.BehavioralTestType = (BehavioralTestType)(cmbBehavioralTestType.SelectedItem);
            entityTemplate.SaveBehavioralTest(_BehavioralTestTemplate);
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

            if (!Regex.IsMatch(text, "^[a-zA-Z0-9_ ]*$"))
            {
                e.Cancel = true;
                errorProvider.SetError(control, "Name can only contain letters, numbers spaces and underscores.");
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

        private void cmbSessionCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox control = (ComboBox)sender;
            int sessionCount = Int32.Parse(control.SelectedItem.ToString());

            RemoveSessionControls();
            if (sessionCount == 0)
            {
                return;
            }

            for (int i = 0; i < sessionCount; i++)
            {
                Session session = new Session();
                session.Name = String.Format("S{0}", i+1);
                if (_BehavioralTestTemplate != null)
                {
                    if (_BehavioralTestTemplate.Sessions.Count > i)
                    {
                        session = _BehavioralTestTemplate.Sessions[i];
                    }
                    else
                    {
                        Trial trial = new Trial();
                        session.Trials.Add(trial);
                        _BehavioralTestTemplate.Sessions.Add(session);
                    }
                }
                else
                {
                    Trial trial = new Trial();
                    session.Trials.Add(trial);
                    _BehavioralTestTemplate.Sessions.Add(session);
                }
            }

            if (_BehavioralTestTemplate.Sessions.Count > sessionCount)
            {
                for (int i = sessionCount; i < _BehavioralTestTemplate.Sessions.Count; i++)
                {
                    _BehavioralTestTemplate.Sessions.Remove(_BehavioralTestTemplate.Sessions[i]);
                }
            }

            for (int i = 0; i < _BehavioralTestTemplate.Sessions.Count; i++)
            {
                AddSessionControl(_BehavioralTestTemplate.Sessions[i], i);
            }

        }

        void AddSessionControl(Session session, int index)
        {
            BehavioralTestTemplateSessionControl session1 = new BehavioralTestTemplateSessionControl(_BehavioralTestTemplate, index, errorProvider);

            int y = 134;
            y += index * 200; 
            //session1.Location = new System.Drawing.Point(35, y);
            session1.Size = new System.Drawing.Size(340, 173);
            session1.TabIndex = 61;
            session1.Tag = session;
            flowLayoutPanel1.Controls.Add(session1);
        }

        void RemoveSessionControls()
        {
            for (int ix = flowLayoutPanel1.Controls.Count - 1; ix >= 0; ix--)
            {
                Control c = flowLayoutPanel1.Controls[ix];
                if (c is BehavioralTestTemplateSessionControl)
                {
                    c.Dispose();
                }
            }
        }
    }
}
