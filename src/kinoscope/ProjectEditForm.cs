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

namespace kinoscope
{
    public partial class ProjectEditForm : ObWin.Form
    {
        private Project _project = null;

        public ProjectEditForm()
        {
            InitializeComponent();
            if (_project == null)
            {
            }
        }

        public ProjectEditForm(Project project)
            : this()
        {
            _project = project;
            _Reload();
        }

        private void _Reload()
        {
            if (_project != null)
            {
                RemoveBehavioralTestControls();
                for (int index = 0; index < _project.BehavioralTests.Count; index++)
                {
                    BehavioralTest behavioralTest = _project.BehavioralTests[index];
                    AddBehavioralTestControl(behavioralTest, index);
                }
            }
            lBehavioralTests.Text = _project.BehavioralTests.Count > 0 ? "Existing Behavioral Tests" : "No Behavioral Tests";

            int height = 180 + _project.BehavioralTests.Count * 70;
            this.Size = new System.Drawing.Size(400, height);
            this.Text = String.Format("Project: {0}", _project);

            List<EntityTemplate> cbEntityTemplates = new List<EntityTemplate>();

            EntityTemplate emptyEntityTemplate = new EntityTemplate();
            emptyEntityTemplate.Id = -1;
            emptyEntityTemplate.Name = "[Please Select]";

            cbEntityTemplates.Add(emptyEntityTemplate);

            foreach (EntityTemplate entityTemplate in EntityTemplate.All())
            {
                cbEntityTemplates.Add(entityTemplate);
            }
            cbTemplate.DataSource = cbEntityTemplates;

            cbTemplate.SelectedIndex = 0;
            txtNewBehavioralTestName.Text = "";
            pAddNew.Visible = false;
            pAddNew.Enabled = false;
            lnkAddBehavioralTest.Visible = true;
        }

        void AddBehavioralTestControl(BehavioralTest behavioralTest, int index)
        {
            ProjectBehavioralTestControl projectBehavioralTestControl1 = new ProjectBehavioralTestControl(_project, index, errorProvider);
            projectBehavioralTestControl1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            projectBehavioralTestControl1.TabIndex = 61;
            projectBehavioralTestControl1.Tag = behavioralTest;
            flowLayoutPanel1.Controls.Add(projectBehavioralTestControl1);
        }

        void RemoveBehavioralTestControls()
        {
            for (int ix = flowLayoutPanel1.Controls.Count - 1; ix >= 0; ix--)
            {
                Control c = flowLayoutPanel1.Controls[ix];
                c.Dispose();
            }
        }

        private void lnkAddBehavioralTest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pAddNew.Visible = true;
            pAddNew.Enabled = true;
            lnkAddBehavioralTest.Visible = false;
        }

        private void bNewCancel_Click(object sender, EventArgs e)
        {
            pAddNew.Visible = false;
            pAddNew.Enabled = false;
            lnkAddBehavioralTest.Visible = true;
        }

        private void ProjectEditForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Escape:
                    Close();
                    break;
                default:
                    break;
            }            
        }

        private void bNewSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                ShowInputError();
                return;
            }

            EntityTemplate entityTemplate = (EntityTemplate)(cbTemplate.SelectedItem);
            BehavioralTest behavioralTest = EntityTemplate.GetAsBehavioralTest(entityTemplate);
            behavioralTest.Name = txtNewBehavioralTestName.Text;
            _project.AddBehavioralTest(behavioralTest);
            _project.Save();
            _project.Refresh();
            _Reload();
        }

        private void txtNewBehavioralTestName_Validating(object sender, CancelEventArgs e)
        {
            Control control = (Control)sender;
            string text = control.Text;

            if (text.Length == 0)
            {
                e.Cancel = true;
                errorProvider.SetError(control, "Name can not be empty.");
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(text, "^[a-zA-Z0-9_ ]*$"))
            {
                e.Cancel = true;
                errorProvider.SetError(control, "Name can only contain letters, numbers, spaces and underscores.");
                return;
            }

            foreach (BehavioralTest behaviorlaTest in _project.BehavioralTests)
            {
                if (behaviorlaTest.Name.ToLower().Trim() == text.ToLower().Trim())
                {
                    e.Cancel = true;
                    errorProvider.SetError(control, "There is already a behavioral test with this name on this project.");
                    return;
                }
            }
            errorProvider.SetError(control, "");
        }

        private void cbTemplate_Validating(object sender, CancelEventArgs e)
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

        private void cbTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox control = (ComboBox)sender;
            if (control.SelectedIndex != 0)
            {
                txtNewBehavioralTestName.Text = control.SelectedItem.ToString();
            }
        }

        public override void Refresh()
        {
            _Reload();
        }
    }
}
