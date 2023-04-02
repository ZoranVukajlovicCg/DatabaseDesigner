// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FormAddSchema.cs" company="N/A">
//   Zoran Vukajlovic
// </copyright>
// <summary>
//   The form add schema.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DatabaseDesigner.Forms
{
    using System;
    using System.Windows.Forms;

    using DatabaseDesigner.Clases;
    using DatabaseDesigner.Entities;

    /// <summary>
    /// The form add schema.
    /// </summary>
    public partial class FormAddSchema : Form
    {
        /// <summary>
        /// The schema.
        /// </summary>
        private DataModel model;

        /// <summary>
        /// The mode.
        /// </summary>
        private FormMode mode;

        /// <summary>
        /// The current index.
        /// </summary>
        private int currentIndex;

        /// <summary>
        /// The current schema.
        /// </summary>
        private Schema currentSchema;

        /// <summary>
        /// Initializes a new instance of the <see cref="FormAddSchema"/> class. 
        /// </summary>
        /// <param name="m">
        /// The m.
        /// </param>
        public FormAddSchema(DataModel m)
        {
            this.InitializeComponent();

            this.model = m;
            this.currentIndex = -1;
            this.currentSchema = null;
        }

        /// <summary>
        /// The add.
        /// </summary>
        /// <returns>
        /// The <see cref="DialogResult"/>.
        /// </returns>
        public DialogResult Add()
        {
            this.mode = FormMode.Add;
            this.Text = @"Add Shema";

            this.currentSchema = new Schema();

            // bind current column to a controls
            this.BindData(this.currentSchema);

            return this.ShowDialog();
        }

        /// <summary>
        /// The edit.
        /// </summary>
        /// <param name="index">
        /// The index.
        /// </param>
        /// <returns>
        /// The <see cref="DialogResult"/>.
        /// </returns>
        public DialogResult Edit(int index)
        {
            this.mode = FormMode.Edit;
            this.Text = @"Edit Schema";

            // save the index of the edited column
            this.currentIndex = index;

            // create new column object and copy properties from the edited column
            this.currentSchema = new Schema();
            Util.CopyProperties(this.model.Schemas[index], this.currentSchema);

            // bind current column to a controls
            this.BindData(this.currentSchema);
            
            return this.ShowDialog();
        }

        /// <summary>
        /// The bind data.
        /// </summary>
        /// <param name="schema">
        /// The schema.
        /// </param>
        private void BindData(Schema schema)
        {
            this.tbSchema.DataBindings.Add("Text", schema, "Name");
        }

        /// <summary>
        /// The button ok click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ButtonOkClick(object sender, EventArgs e)
        {
            if (this.mode == FormMode.Add)
            {
                // just take current table and add it to the underlaying schema
                this.model.Schemas.Add(this.currentSchema);
            }

            if (this.mode == FormMode.Edit)
            {
                // copy properties form the current table into the edited table
                Util.CopyProperties(this.currentSchema, this.model.Schemas[this.currentIndex]);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
