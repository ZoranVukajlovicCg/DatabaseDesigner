using DatabaseDesigner.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseDesigner.Forms
{
    public partial class FormScriptParams : Form
    {
        public TargetDb SelectedRdbms { get { return (TargetDb)cbTargetRdbms.SelectedItem; } }

        public bool AddToRepository { get { return cbAddToRepository.Checked; } }

        public FormScriptParams()
        {
            InitializeComponent();
            // bind enum to a combobox
            cbTargetRdbms.DataSource = Enum.GetValues(typeof(TargetDb));
            cbTargetRdbms.DisplayMember = "ToString";
            toolTip.SetToolTip(cbAddToRepository, @"Selecting this option overrides all Add to repository options for tables/columns. All data objects will be added to repository!");
        }
    }
}
