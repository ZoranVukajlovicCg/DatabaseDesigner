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
    public partial class FormStringEdit : Form
    {
        public string EditedText { get { return tbString.Text; } }

        public FormStringEdit(string caption, string text)
        {
            this.Visible = false;
            InitializeComponent();

            this.Text = caption;
            this.labCaption.Text = caption;

            tbString.Text = text;
        }
    }
}
