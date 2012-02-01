using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ObLib.Domain;
using ObLib.Repositories;

namespace observador
{
    public partial class AdminResearchers : Form
    {
        public AdminResearchers()
        {
            InitializeComponent();
        }

        private void AdminResearchers_Load(object sender, EventArgs e)
        {
            var researchers = Researcher.All();
            DataGridViewRow row = new DataGridViewRow();

            foreach (Researcher researcher in researchers) 
            {
                string[] row1 = new string[] { researcher.Username, researcher.Projects.Count().ToString() };
                dgvResearchers.Rows.Add(row1);
            }
        }
    }
}
