// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FormAddTable.cs" company="N/A">
//   Zoran Vukajlovic
// </copyright>
// <summary>
//   Defines the FormAddTable type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DatabaseDesigner.Forms
{
    using System;
    using System.Windows.Forms;

    using DatabaseDesigner.Clases;
    using DatabaseDesigner.Entities;

    public partial class FormAddTable : Form
    {
        private Schema schema;

        private FormMode mode;

        private int currentIndex;

        private Table currentTable;

        public FormAddTable(Schema s)
        {
            this.InitializeComponent();

            this.schema = s;
            this.currentIndex = -1;
            this.currentTable = null;
        }

        public DialogResult Add()
        {
            this.mode = FormMode.Add;
            this.Text = @"Add Table";

            this.currentTable = new Table();

            // bind current column to a controls
            this.BindTable(this.currentTable);

            return this.ShowDialog();
        }

        public DialogResult Edit(int tableIndex)
        {
            this.mode = FormMode.Edit;
            this.Text = @"Edit Table";

            // save the index of the edited column
            this.currentIndex = tableIndex;

            // create new column object and copy properties from the edited column
            this.currentTable = new Table();
            Util.CopyProperties(this.schema.Tables[tableIndex], this.currentTable);

            // bind current column to a controls
            this.BindTable(this.currentTable);
            
            return this.ShowDialog();
        }

        private void BindTable(Table table)
        {
            this.tbName.DataBindings.Add("Text", table, "Name");
            this.tbNamespace.DataBindings.Add("Text", table, "Namespace");
            this.tbEntityName.DataBindings.Add("Text", table, "EntityName");
            this.tbDisplayName.DataBindings.Add("Text", table, "DisplayName");
            this.tbParentTable.DataBindings.Add("Text", table, "ParentTable");
            this.tbReferencePattern.DataBindings.Add("Text", table, "ReferencePattern");
            this.tbEntityIconName.DataBindings.Add("Text", table, "EntityIconName");
            //this.cbIsUpdatable.DataBindings.Add("Checked", table, "IsUpdatableFromExternalSource");
            this.cbIsAccessControlEnabled.DataBindings.Add("Checked", table, "IsAccessControlEnabled");
            //this.cbIsAccessScopeEnabled.DataBindings.Add("Checked", table, "IsAccessScopeEnabled");
            this.cbAddToRepository.DataBindings.Add("Checked", table, "AddToRepository");
        }

        private void ButtonOkClick(object sender, EventArgs e)
        {
            if (this.mode == FormMode.Add)
            {
                // just take current table and add it to the underlaying schema
                this.schema.Tables.Add(this.currentTable);
            }

            if (this.mode == FormMode.Edit)
            {
                // copy properties form the current table into the edited table
                Util.CopyProperties(this.currentTable, this.schema.Tables[this.currentIndex]);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
