﻿using System;
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
    public partial class SubjectGroupForm : Form
    {
        private SubjectGroup _subjectGroup = null;

        public SubjectGroupForm()
        {
            InitializeComponent();
        }

        public SubjectGroupForm(SubjectGroup subjectGroup) : this()
        {
            _subjectGroup = subjectGroup;
            txtName.Text = subjectGroup.Name;
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            SubjectGroup subjectGroup = _subjectGroup ?? new SubjectGroup();

            subjectGroup.Name = txtName.Text;
            subjectGroup.Tm = DateTime.Now;
            if (_subjectGroup == null)
            {
                Researcher.Current.ActiveProject.AddSubjectGroup(subjectGroup);
            }
            subjectGroup.Project.Save();
            this.Close();
        }
    }
}