// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FormAddDataModel.cs" company="N/A">
//   Zoran Vukajlovic
// </copyright>
// <summary>
//   Defines the FormAddDataModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DatabaseDesigner.Forms
{
    using System;
    using System.Windows.Forms;

    using DatabaseDesigner.Entities;

    /// <summary>
    /// The form add data model.
    /// </summary>
    public partial class FormAddDataModel : Form
    {
        /// <summary>
        /// The model.
        /// </summary>
        private DataModel model;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="FormAddDataModel"/> class.
        /// </summary>
        /// <param name="m">
        /// The m.
        /// </param>
        public FormAddDataModel(DataModel m)
        {
            this.InitializeComponent();
            this.model = m;
        }

        /// <summary>
        /// The edit.
        /// </summary>
        /// <returns>
        /// The <see cref="DialogResult"/>.
        /// </returns>
        public DialogResult Edit()
        {
            this.Text = @"Edit Data Model";
            this.tbName.Text = this.model.Name;

            return this.ShowDialog();
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
            if (string.IsNullOrEmpty(this.tbName.Text))
            {
                MessageBox.Show(
                    @"Data model name is not entered!",
                    @"ERROR",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            this.model.Name = this.tbName.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
