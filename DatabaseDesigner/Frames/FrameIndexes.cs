// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FrameIndexes.cs" company="N/A">
//   Zoran Vukajlovic
// </copyright>
// <summary>
//   Defines the FrameIndexes type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DatabaseDesigner.Frames
{
    using System.Collections.Generic;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;

    using DatabaseDesigner.Clases;
    using DatabaseDesigner.Entities;
    using DatabaseDesigner.Forms;

    /// <summary>
    /// The frame indexes.
    /// </summary>
    public partial class FrameIndexes : UserControl
    {
        /// <summary>
        /// The data source.
        /// </summary>
        private Table dataSource;

        /// <summary>
        /// The current grid index.
        /// </summary>
        private int currentGridIndex;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrameIndexes"/> class.
        /// </summary>
        public FrameIndexes()
        {
            this.InitializeComponent();

            Util.GridSetup(this.grid);
            this.grid.AddCustomColumn(new DataColumn("Name", typeof(string)), "Name", 500, true, string.Empty, DataGridViewContentAlignment.MiddleLeft);
            this.grid.AddCheckColumn(new DataColumn("IsUnique", typeof(bool)), "Unique", 55, null, null);
            this.grid.AddCustomColumn(new DataColumn("Fields", typeof(List<IndexField>)), "Columns", 500, true, string.Empty, DataGridViewContentAlignment.MiddleLeft);
        }

        /// <summary>
        /// The reset data.
        /// </summary>
        /// <param name="table">
        /// The table.
        /// </param>
        public void ResetData(Table table)
        {
            this.dataSource = table;
            this.BindData(table);
            this.labHeader.Text = string.Format(@"Indexes: {0}", table.Name);
        }

        /// <summary>
        /// The add.
        /// </summary>
        public void Add()
        {
            this.AddIndex();
        }

        /// <summary>
        /// The bind data.
        /// </summary>
        /// <param name="ds">
        /// The ds.
        /// </param>
        private void BindData(Table ds)
        {
            var bs = new BindingSource { DataSource = ds.Indexes };
            this.grid.DataSource = bs;
        }

        #region Actions

        /// <summary>
        /// The add column.
        /// </summary>
        private void AddIndex()
        {
            var f = new FormAddIndex(this.dataSource);
            if (f.Add() != DialogResult.OK)
            {
                return;
            }

            ((BindingSource)this.grid.DataSource).ResetBindings(false);
            AppStatus.ModelSaved = false;
        }

        /// <summary>
        /// The edit column.
        /// </summary>
        /// <param name="index">
        /// The index.
        /// </param>
        private void EditIndex(int index)
        {
            var f = new FormAddIndex(this.dataSource);
            if (f.Edit(index) != DialogResult.OK)
            {
                return;
            }

            ((BindingSource)this.grid.DataSource).ResetBindings(false);
            AppStatus.ModelSaved = false;
        }

        /// <summary>
        /// The remove column.
        /// </summary>
        private void RemoveIndex()
        {
            if (this.currentGridIndex < 0 || this.currentGridIndex > this.dataSource.Columns.Count - 1)
            {
                return;
            }

            if (MessageBox.Show(
                @"Do you want to permanently remove selected index?",
                @"WARNING",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }

            this.dataSource.Indexes.RemoveAt(this.currentGridIndex);

            ((BindingSource)this.grid.DataSource).ResetBindings(false);
            AppStatus.ModelSaved = false;
        }

        /// <summary>
        /// The move column up.
        /// </summary>
        private void MoveIndexUp()
        {
            if (this.currentGridIndex < 0 || this.currentGridIndex > this.dataSource.Columns.Count - 1)
            {
                return;
            }

            if (this.currentGridIndex < 1)
            {
                return;
            }

            var index = Util.CopyIndex(this.dataSource.Indexes[this.currentGridIndex]);
            this.dataSource.Indexes.RemoveAt(this.currentGridIndex);
            this.dataSource.Indexes.Insert(this.currentGridIndex - 1, index);

            ((BindingSource)this.grid.DataSource).ResetBindings(false);
            AppStatus.ModelSaved = false;

            this.grid.CurrentCell = this.grid.Rows[this.currentGridIndex - 1].Cells[0];
        }

        /// <summary>
        /// The move column down.
        /// </summary>
        private void MoveIndexDown()
        {
            if (this.currentGridIndex < 0 || this.currentGridIndex > this.dataSource.Columns.Count - 1)
            {
                return;
            }

            if (this.currentGridIndex > this.dataSource.Columns.Count - 2)
            {
                this.grid.CurrentCell = this.grid.Rows[this.currentGridIndex].Cells[0];
                return;
            }

            var index = Util.CopyIndex(this.dataSource.Indexes[this.currentGridIndex]);
            this.dataSource.Indexes.RemoveAt(this.currentGridIndex);
            this.dataSource.Indexes.Insert(this.currentGridIndex + 1, index);

            ((BindingSource)this.grid.DataSource).ResetBindings(false);
            AppStatus.ModelSaved = false;

            this.grid.CurrentCell = this.grid.Rows[this.currentGridIndex + 1].Cells[0];
        }

        #endregion

        #region Events

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
            this.AddIndex();
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
            this.RemoveIndex();
        }

        /// <summary>
        /// The button up click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ButtonUpClick(object sender, System.EventArgs e)
        {
            this.MoveIndexUp();
        }

        /// <summary>
        /// The button down click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ButtonDownClick(object sender, System.EventArgs e)
        {
            this.MoveIndexDown();
        }

        /// <summary>
        /// The menu edit click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void MenuEditClick(object sender, System.EventArgs e)
        {
            if (this.grid.SelectedRows[0].Index != -1)
            {
                this.EditIndex(this.grid.SelectedRows[0].Index);
            }
        }

        /// <summary>
        /// The grid tables selection changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void GridSelectionChanged(object sender, System.EventArgs e)
        {
            if (this.grid.SelectedRows.Count <= 0)
            {
                return;
            }

            this.currentGridIndex = this.grid.SelectedRows[0].Index;
        }

        /// <summary>
        /// The grid cell context menu needed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void GridCellContextMenuNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            if (((Control)sender).Focused && e.RowIndex != -1)
            {
                e.ContextMenuStrip = this.cm;
            }
        }

        /// <summary>
        /// The grid cell formatting.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void GridCellFormating(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }

            if (e.ColumnIndex == 2)
            {
                var list = (List<IndexField>)e.Value;
                var cellText = list.Aggregate(
                    string.Empty,
                    (current, field) => current + (current == string.Empty ? field.Name : @", " + field.Name));

                e.Value = cellText;
            }

            if (e.ColumnIndex == 0)
            {
                e.CellStyle.Font = new Font(this.grid.Font, FontStyle.Bold);
                e.CellStyle.ForeColor = Color.DarkGreen;
            }
        }

        /// <summary>
        /// The grid key down.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void GridKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                this.EditIndex(this.currentGridIndex);
                e.Handled = true;
            }

            if (e.KeyCode == Keys.Delete)
            {
                this.RemoveIndex();
                e.Handled = true;
            }

            if (e.KeyCode == Keys.PageUp)
            {
                this.MoveIndexUp();
                e.Handled = true;
            }

            if (e.KeyCode == Keys.PageDown)
            {
                this.MoveIndexDown();
                e.Handled = true;
            }
        }

        #endregion
    }
}
