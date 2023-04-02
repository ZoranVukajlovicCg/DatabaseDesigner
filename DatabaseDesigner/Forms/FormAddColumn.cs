// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FormAddColumn.cs" company="N/A">
//   Zoran Vukajlovic
// </copyright>
// <summary>
//   Defines the FormAddColumn type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DatabaseDesigner.Forms
{
    using System;
    using System.Windows.Forms;

    using DatabaseDesigner.Clases;
    using DatabaseDesigner.Entities;

    public partial class FormAddColumn : Form
    {
        private readonly Table table;

        private FormMode mode;

        private int currentIndex;

        private Column currentColumn;

        public FormAddColumn(Table t)
        {
            this.InitializeComponent();

            this.table = t;
            this.currentIndex = -1;
            this.currentColumn = null;
        }

        public DialogResult Add()
        {
            this.mode = FormMode.Add;
            this.Text = string.Format(@"Add Column: {0}", this.table.Name);
            
            this.currentColumn = new Column();

            // bind current column to a controls
            this.BindColumn(this.currentColumn);
            
            return this.ShowDialog();
        }

        public DialogResult Edit(int columnIndex)
        {
            this.mode = FormMode.Edit;
            this.Text = string.Format(@"Edit Column: {0}", this.table.Name);
            
            // save the index of the edited column
            this.currentIndex = columnIndex;

            // create new column object and copy properties from the edited column
            this.currentColumn = new Column();
            Util.CopyProperties(this.table.Columns[columnIndex], this.currentColumn);

            // set controls states
            cbIsConstraint.Enabled = cbIsReference.Checked;
            labRefTableSchema.Enabled = cbIsReference.Checked;
            tbRefTableSchema.Enabled = cbIsReference.Checked;
            labRefTable.Enabled = cbIsReference.Checked;
            tbRefTable.Enabled = cbIsReference.Checked;
            labRefField.Enabled = cbIsReference.Checked;
            tbRefField.Enabled = cbIsReference.Checked;

            // bind current column to a controls
            this.BindColumn(this.currentColumn);

            return this.ShowDialog();
        }

        private void BindColumn(Column column)
        {
            this.tbName.DataBindings.Add("Text", column, "Name");
            this.tbDisplayName.DataBindings.Add("Text", column, "DisplayName");
            this.tbDataType.DataBindings.Add("Text", column, "DbType");
            //this.cbDataType.DataBindings.Add("SelectedItem", column, "DbType");
            this.tbSize.DataBindings.Add("Text", column, "DbLength");
            this.tbPrecision.DataBindings.Add("Text", column, "DbPrecision");
            this.tbDefaultValue.DataBindings.Add("Text", column, "DefaultValue");
            this.cbIsNullable.DataBindings.Add("Checked", column, "IsNullable");
            this.cbIsRequired.DataBindings.Add("Checked", column, "IsRequired");
            this.cbIsSearchable.DataBindings.Add("Checked", column, "IsSearchable");
            this.cbIsFullTextSearch.DataBindings.Add("Checked", column, "IsFullTextSearch");
            this.cbIsFullTextSearch.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
            this.cbIsSystem.DataBindings.Add("Checked", column, "IsSystem");
            this.cbIsReference.DataBindings.Add("Checked", column, "IsReference");
            this.cbIsConstraint.DataBindings.Add("Checked", column, "IsConstraint");
            this.tbRefTableSchema.DataBindings.Add("Text", column, "ReferenceTableSchema");
            this.tbRefTable.DataBindings.Add("Text", column, "ReferenceTable");
            this.tbRefField.DataBindings.Add("Text", column, "ReferenceField");
            //this.cbRefRepository.DataBindings.Add("SelectedItem", column, "TableRepository");
            this.cbAddToRepository.DataBindings.Add("Checked", column, "AddToRepository");
            //this.tbFormInformation.DataBindings.Add("Text", column, "FormInformation");
            //this.tbTranslationKeyField.DataBindings.Add("Text", column, "TranslationKeyField");
        }

        #region Events

        private void ButtonOkClick(object sender, EventArgs e)
        {
            if (this.mode == FormMode.Add)
            {
                // just take current column and add it to the underlaying table
                this.currentColumn.ColumnOrder = -1;
                this.table.Columns.Add(this.currentColumn);
            }

            if (this.mode == FormMode.Edit)
            {
                // copy properties form the current column into the edited column
                Util.CopyProperties(this.currentColumn, this.table.Columns[this.currentIndex]);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void DataTypeSelectionChanged(object sender, EventArgs e)
        {
            //if ((string)this.cbDataType.SelectedItem == "string")
            //{
            //    this.tbSize.Visible = true;
            //    this.labSize.Visible = true;
            //}
            //else
            //{
            //    this.tbSize.Text = @"0";
            //    this.currentColumn.DbLength = 0;
            //    this.tbSize.Visible = false;
            //    this.labSize.Visible = false;
            //}

            //if ((string)this.cbDataType.SelectedItem == "decimal")
            //{
            //    this.tbPrecision.Visible = true;
            //    this.labPrecision.Visible = true;
            //}
            //else
            //{
            //    this.tbPrecision.Visible = false;
            //    this.tbPrecision.Text = string.Empty;
            //    this.currentColumn.DbPrecision = string.Empty;
            //    this.labPrecision.Visible = false;
            //}
        }

        private void IsRequiredOrNullableCheckChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                if (((Control)sender).Name == @"cbIsRequired")
                {
                    this.cbIsNullable.Checked = false;
                    this.currentColumn.IsNullable = false;
                }

                if (((Control)sender).Name == @"cbIsNullable")
                {
                    this.cbIsRequired.Checked = false;
                    this.currentColumn.IsRequired = false;
                }
            }
        }

        private void IsSearchableCheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                this.cbIsFullTextSearch.Visible = true;
            }
            else
            {
                this.cbIsFullTextSearch.Checked = false;
                this.currentColumn.IsFullTextSearch = false;
                this.cbIsFullTextSearch.Visible = false;
            }
        }

        private void IsReferenceCheckedChanged(object sender, EventArgs e)
        {
            cbIsConstraint.Enabled = ((CheckBox)sender).Checked;

            cbIsConstraint.Enabled = ((CheckBox)sender).Checked;
            labRefTableSchema.Enabled = ((CheckBox)sender).Checked;
            tbRefTableSchema.Enabled = ((CheckBox)sender).Checked;
            labRefTable.Enabled = ((CheckBox)sender).Checked;
            tbRefTable.Enabled = ((CheckBox)sender).Checked;
            labRefField.Enabled = ((CheckBox)sender).Checked;
            tbRefField.Enabled = ((CheckBox)sender).Checked;
        }

        #endregion
    }
}
