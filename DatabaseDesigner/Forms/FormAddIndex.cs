// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FormAddIndex.cs" company="N/A">
//   Zoran Vukajlovic
// </copyright>
// <summary>
//   Defines the FormAddIndex type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DatabaseDesigner.Forms
{
    using System.Windows.Forms;

    using DatabaseDesigner.Clases;
    using DatabaseDesigner.Entities;

    public partial class FormAddIndex : Form
    {
        private readonly Table table;

        private FormMode mode;
        
        private int currentListIndex;

        private Index currentIndex;

        public FormAddIndex(Table t)
        {
            this.InitializeComponent();

            this.table = t;
            this.lbAllColumns.DataSource = t.Columns;
            this.lbAllColumns.DisplayMember = "Name";

            this.currentListIndex = -1;
            this.currentIndex = null;
        }

        public DialogResult Add()
        {
            this.mode = FormMode.Add;
            this.Text = string.Format(@"Add Index: {0}", this.table.Name);

            this.currentIndex = new Index();

            // bind current column to a controls
            this.BindIndex(this.currentIndex);

            // create index name
            this.CreateIndexName();

            return this.ShowDialog();
        }

        public DialogResult Edit(int indexIndex)
        {
            this.mode = FormMode.Edit;
            this.Text = string.Format(@"Edit Index: {0}", this.table.Name);

            // save the index of the edited column
            this.currentListIndex = indexIndex;

            // create new index object and copy properties from the edited column
            this.currentIndex = new Index();
            Util.CloneIndex(this.table.Indexes[indexIndex], this.currentIndex);

            // bind current column to a controls
            this.BindIndex(this.currentIndex);
            
            // create index name
            this.CreateIndexName();

            return this.ShowDialog();
        }

        private void BindIndex(Index index)
        {
            this.labName.DataBindings.Add("Text", index, "Name");
            this.cbIsUnique.DataBindings.Add("Checked", index, "IsUnique");
            this.lbFields.DataSource = index.Fields;
            this.lbFields.DisplayMember = "Name";
        }

        /// <summary>
        /// The create index name.
        /// </summary>
        private void CreateIndexName()
        {
            var count = 2 + this.lbFields.Items.Count;
            var name = new string[count];

            name[0] = this.currentIndex.IsUnique ? @"UX" : @"IX";

            name[1] = string.Empty;

            var tableName = this.table.Name.Split('.');
            if (tableName.Length == 1)
            {
                name[1] = tableName[0];
            }
            
            if (tableName.Length == 2)
            {
                name[1] = tableName[1];
            }

            var i = 2;
            
            foreach (var field in this.currentIndex.Fields)
            {
                name[i] = field.Name;
                i++;
            }

            this.labName.Text = string.Join("_", name);
            this.currentIndex.Name = this.labName.Text;
        }

        #region Actions

        private void AddField()
        {
            if (this.lbAllColumns.SelectedIndex < 0)
            {
                return;
            }

            // check if the field already exist in the list
            var field = this.currentIndex.Fields.Find(x => x.Name == this.table.Columns[this.lbAllColumns.SelectedIndex].Name);

            if (this.currentIndex.Fields.IndexOf(field) != -1)
            {
                return;
            }
            
            this.currentIndex.Fields.Add(new IndexField { Name = this.table.Columns[this.lbAllColumns.SelectedIndex].Name });

            this.lbFields.DataSource = null;
            this.lbFields.DataSource = this.currentIndex.Fields;
            this.lbFields.DisplayMember = "Name";

            this.CreateIndexName();

            AppStatus.ModelSaved = false;
        }

        private void RemoveField()
        {
            if (this.lbFields.SelectedIndex < 0)
            {
                return;
            }

            this.currentIndex.Fields.RemoveAt(this.lbFields.SelectedIndex);

            this.lbFields.DataSource = null;
            this.lbFields.DataSource = this.currentIndex.Fields;
            this.lbFields.DisplayMember = "Name";

            this.CreateIndexName();

            AppStatus.ModelSaved = false;
        }

        #endregion

        #region Events

        /// <summary>
        /// The button ok click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ButtonOkClick(object sender, System.EventArgs e)
        {
            if (this.currentIndex.Fields.Count == 0)
            {
                MessageBox.Show(@"No columns selected for Index!", @"ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this.mode == FormMode.Add)
            {
                // just take current column and add it to the underlaying table
                this.table.Indexes.Add(this.currentIndex);
            }

            if (this.mode == FormMode.Edit)
            {
                // copy properties form the current column into the edited column
                Util.CopyIndexProperties(this.currentIndex, this.table.Indexes[this.currentListIndex]);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// The button add click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ButtonAddClick(object sender, System.EventArgs e)
        {
            this.AddField();
        }

        /// <summary>
        /// The button remove click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ButtonRemoveClick(object sender, System.EventArgs e)
        {
            this.RemoveField();
        }

        /// <summary>
        /// The is unique checked changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void IsUniqueCheckedChanged(object sender, System.EventArgs e)
        {
            this.currentIndex.IsUnique = this.cbIsUnique.Checked;
            this.CreateIndexName();
        }

        #endregion
    }
}
