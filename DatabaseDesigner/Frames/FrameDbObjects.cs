// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FrameDbObjects.cs" company="N/A">
//   Zoran Vukajlovic
// </copyright>
// <summary>
//   The frame db objects.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DatabaseDesigner.Frames
{
    using System.Collections.Generic;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    using DatabaseDesigner.Clases;
    using DatabaseDesigner.Entities;
    using DatabaseDesigner.Forms;

    /// <summary>
    /// The frame DB objects.
    /// </summary>
    public partial class FrameDbObjects : UserControl
    {
        private int currentGridIndex;

        private DataModel dataModel;

        private Schema currentSchema;

        private FrameColumns frameColumns;

        private FrameIndexes frameIndexes;

        private Control currentFrame;

        private List<Column> columnBuffer;

        private List<Index> indexBuffer;

        private BindingSource tableBindingSource;

        private BindingSource schemaBindingSource;

        private FrameColumns.dlgcUpdateTablesCallback dlgUdateTablesCallback;
        private FrameColumns.dlgcUpdateInfoPanelCallback dlgUpdateInfo;

        //public delegate void ResetTableBingings();

        public FrameDbObjects(DataModel dm, FrameColumns.dlgcUpdateInfoPanelCallback dlg)
        {
            this.InitializeComponent();

            this.dataModel = dm;
            this.schemaBindingSource = new BindingSource { DataSource = this.dataModel.Schemas };
            this.tableBindingSource = new BindingSource();
            this.BindData();

            this.currentFrame = null;
            this.columnBuffer = new List<Column>();
            this.indexBuffer = new List<Index>();
            this.currentGridIndex = -1;

            this.dlgUpdateInfo = dlg;
            this.dlgUdateTablesCallback = new FrameColumns.dlgcUpdateTablesCallback(UpdateTables);
            this.frameColumns = new FrameColumns(this.dlgUdateTablesCallback, dlg) { Dock = DockStyle.Fill, Parent = this.PanelBottom, Visible = false };
            this.frameIndexes = new FrameIndexes { Dock = DockStyle.Fill, Parent = this.PanelBottom, Visible = false };

            Util.GridSetup(this.grid);
            this.grid.AddCustomColumn(new DataColumn("Name", typeof(string)), "Name", 200, true, string.Empty, DataGridViewContentAlignment.MiddleLeft);
            this.grid.AddCustomColumn(new DataColumn("DisplayName", typeof(string)), "Display Name", 200, true, string.Empty, DataGridViewContentAlignment.MiddleLeft);
            this.grid.AddCustomColumn(new DataColumn("Namespace", typeof(string)), "Namespace", 200, true, string.Empty, DataGridViewContentAlignment.MiddleLeft);
            this.grid.AddCustomColumn(new DataColumn("EntityName", typeof(string)), "Entity Name", 200, true, string.Empty, DataGridViewContentAlignment.MiddleLeft);
            this.grid.AddCustomColumn(new DataColumn("ParentSchema", typeof(string)), "Par. Schema", 100, true, string.Empty, DataGridViewContentAlignment.MiddleLeft);
            this.grid.AddCustomColumn(new DataColumn("ParentTable", typeof(string)), "Parent Table", 200, true, string.Empty, DataGridViewContentAlignment.MiddleLeft);
            this.grid.AddCustomColumn(new DataColumn("ReferencePattern", typeof(string)), "Reference Pattern", 200, true, string.Empty, DataGridViewContentAlignment.MiddleLeft);
            this.grid.AddCustomColumn(new DataColumn("EntityIconName", typeof(string)), "Icon Name", 200, true, string.Empty, DataGridViewContentAlignment.MiddleLeft);
            this.grid.AddCheckColumn(new DataColumn("IsAccessControlEnabled", typeof(bool)), "ACE", 45, null, null);
            this.grid.AddCheckColumn(new DataColumn("AddToRepository", typeof(bool)), "Rep", 45, null, null);
        }

        public void ReloadData(DataModel data)
        {
            this.dataModel = data;
            this.ResetAllBindings();
        }

        public void ResetAllBindings()
        {
            this.schemaBindingSource.DataSource = this.dataModel.Schemas;
            this.schemaBindingSource.ResetBindings(false);

            if (this.cbSchema.Items.Count < 1)
            {
                return;
            }

            this.cbSchema.SelectedIndex = 0;
            this.currentSchema = this.dataModel.Schemas[0];
            this.BindSchema();
            this.ShowColumns();
        }

        public void MainFormKeyDown(KeyEventArgs e)
        {
            if (!this.Visible)
            {
                return;
            }

            if (e.Alt && e.KeyCode == Keys.Insert)
            {
                if (this.frameColumns.Visible)
                {
                    this.frameColumns.Add();
                }

                if (this.frameIndexes.Visible)
                {
                    this.frameIndexes.Add();
                }

                e.Handled = true;
                return;
            }

            if (e.KeyCode == Keys.Insert)
            {
                this.AddTable();
                e.Handled = true;
            }
        }

        private void BindData()
        {
            this.cbSchema.DataSource = this.schemaBindingSource;
            this.cbSchema.DisplayMember = "Name";

            if (this.cbSchema.Items.Count < 1)
            {
                return;
            }

            this.cbSchema.SelectedIndex = 0;
            this.currentSchema = this.dataModel.Schemas[0];
            this.BindSchema();
        }

        private void BindSchema()
        {
            this.tableBindingSource.DataSource = this.currentSchema.Tables;
            this.grid.DataSource = this.tableBindingSource;
            this.tableBindingSource.ResetBindings(false);
            if (this.tableBindingSource.Count > 0)
            {
                this.currentGridIndex = 0;
            }
            else
            {
                this.currentGridIndex = -1;
            }
        }

        private void BrowseColumns(int index)
        {
            this.frameColumns.ResetData(index > -1 ? this.currentSchema.Tables[index] : new Table());
        }

        private void BrowseIndexes(int index)
        {
            this.frameIndexes.ResetData(index > -1 ? this.currentSchema.Tables[index] : new Table());
        }

        private void UpdateTables()
        {
            // try invalidate the grid
            this.grid.Invalidate();
        }

        #region Actions

        private void SwitchSchema(int index)
        {
            this.currentSchema = this.dataModel.Schemas[index];
            this.BindSchema();
            if (this.currentFrame == this.frameColumns)
            {
                this.BrowseColumns(this.currentGridIndex);
            }

            if (this.currentFrame == this.frameIndexes)
            {
                this.BrowseIndexes(this.currentGridIndex);
            }
        }

        private void AddTable()
        {
            var f = new FormAddTable(this.currentSchema);
            if (f.Add() != DialogResult.OK)
            {
                return;
            }

            ((BindingSource)this.grid.DataSource).ResetBindings(false);
            AppStatus.ModelSaved = false;
            this.Invoke(dlgUpdateInfo);
        }

        private void EditTable()
        {
            if (this.currentGridIndex < 0 || this.currentGridIndex > this.currentSchema.Tables.Count - 1)
            {
                return;
            }

            var f = new FormAddTable(this.currentSchema);
            if (f.Edit(this.currentGridIndex) != DialogResult.OK)
            {
                return;
            }

            ((BindingSource)this.grid.DataSource).ResetBindings(false);
            AppStatus.ModelSaved = false;
            this.Invoke(dlgUpdateInfo);
        }

        private void RemoveTable()
        {
            if (this.currentGridIndex < 0 || this.currentGridIndex > this.currentSchema.Tables.Count - 1)
            {
                return;
            }

            if (MessageBox.Show(@"Do you want to permanently remove selected table?", @"WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }

            this.currentSchema.Tables.RemoveAt(this.currentGridIndex);

            ((BindingSource)this.grid.DataSource).ResetBindings(false);
            AppStatus.ModelSaved = false;
            this.Invoke(dlgUpdateInfo);
        }

        private void MoveTableUp()
        {
            if (this.currentGridIndex < 1 || this.currentGridIndex > this.currentSchema.Tables.Count - 1)
            {
                return;
            }

            var table = Util.CopyTable(this.currentSchema.Tables[this.currentGridIndex]);
            this.currentSchema.Tables.RemoveAt(this.currentGridIndex);
            this.currentSchema.Tables.Insert(this.currentGridIndex - 1, table);

            ((BindingSource)this.grid.DataSource).ResetBindings(false);
            AppStatus.ModelSaved = false;

            this.grid.CurrentCell = this.grid.Rows[this.currentGridIndex - 1].Cells[0];
            this.Invoke(dlgUpdateInfo);
        }

        private void MoveTableDown()
        {
            if (this.currentGridIndex < 0 || this.currentGridIndex > this.currentSchema.Tables.Count - 1)
            {
                return;
            }

            if (this.currentGridIndex > this.currentSchema.Tables.Count - 2)
            {
                this.grid.CurrentCell = this.grid.Rows[this.currentGridIndex].Cells[0];
                return;
            }

            var table = Util.CopyTable(this.currentSchema.Tables[this.currentGridIndex]);
            this.currentSchema.Tables.RemoveAt(this.currentGridIndex);
            this.currentSchema.Tables.Insert(this.currentGridIndex + 1, table);

            ((BindingSource)this.grid.DataSource).ResetBindings(false);
            AppStatus.ModelSaved = false;

            this.grid.CurrentCell = this.grid.Rows[this.currentGridIndex + 1].Cells[0];
            this.Invoke(dlgUpdateInfo);
        }

        private void CopyColumns()
        {
            if (this.currentGridIndex < 0 || this.currentGridIndex > this.currentSchema.Tables.Count - 1)
            {
                return;
            }

            this.columnBuffer.Clear();

            foreach (var col in this.currentSchema.Tables[this.currentGridIndex].Columns)
            {
                this.columnBuffer.Add(Util.CopyColumn(col));
            }
        }

        private void PasteColumns()
        {
            if (this.currentGridIndex < 0 || this.currentGridIndex > this.currentSchema.Tables.Count - 1)
            {
                return;
            }

            if (this.currentSchema.Tables[this.currentGridIndex].Columns.Count > 0)
            {
                if (MessageBox.Show(
                    @"Table already have columns!\r\nOverwrite?",
                    @"WARNING",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    this.currentSchema.Tables[this.currentGridIndex].Columns.Clear();
                }
                else
                {
                    return;
                }
            }

            foreach (var column in this.columnBuffer)
            {
                this.currentSchema.Tables[this.currentGridIndex].Columns.Add(column);
            }

            ((BindingSource)this.grid.DataSource).ResetBindings(false);
            AppStatus.ModelSaved = false;
            this.Invoke(dlgUpdateInfo);
        }

        private void CopyIndexes()
        {
            if (this.currentGridIndex < 0 || this.currentGridIndex > this.currentSchema.Tables.Count - 1)
            {
                return;
            }

            this.indexBuffer.Clear();

            foreach (var index in this.currentSchema.Tables[this.currentGridIndex].Indexes)
            {
                this.indexBuffer.Add(Util.CopyIndex(index));
            }
        }

        private void PasteIndexes()
        {
            if (this.currentGridIndex < 0 || this.currentGridIndex > this.currentSchema.Tables.Count - 1)
            {
                return;
            }

            if (this.currentSchema.Tables[this.currentGridIndex].Indexes.Count > 0)
            {
                if (MessageBox.Show(
                    @"Table already have indexes!\r\nOverwrite?",
                    @"WARNING",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    this.currentSchema.Tables[this.currentGridIndex].Indexes.Clear();
                }
                else
                {
                    return;
                }
            }

            foreach (var index in this.indexBuffer)
            {
                this.currentSchema.Tables[this.currentGridIndex].Indexes.Add(index);
            }

            ((BindingSource)this.grid.DataSource).ResetBindings(false);
            AppStatus.ModelSaved = false;
            this.Invoke(dlgUpdateInfo);
        }

        private void ShowColumns()
        {
            if (this.frameColumns.Visible)
            {
                return;
            }

            if (this.currentFrame != null)
            {
                this.currentFrame.Hide();
            }

            this.currentFrame = this.frameColumns;
            this.frameColumns.Show();
            this.frameColumns.BringToFront();
            this.BrowseColumns(this.currentGridIndex);
        }

        private void ShowIndexes()
        {
            if (this.frameIndexes.Visible)
            {
                return;
            }

            if (this.currentFrame != null)
            {
                this.currentFrame.Hide();
            }

            this.currentFrame = this.frameIndexes;
            this.frameIndexes.Show();
            this.frameIndexes.BringToFront();
            this.BrowseIndexes(this.currentGridIndex);
        }

        #endregion

        #region Events

        private void ButtonAddTableClick(object sender, System.EventArgs e)
        {
            this.AddTable();
        }

        private void ButtonRemoveTableClick(object sender, System.EventArgs e)
        {
            this.RemoveTable();
        }

        private void ButtonUpClick(object sender, System.EventArgs e)
        {
            this.MoveTableUp();
        }

        private void ButtonDownClick(object sender, System.EventArgs e)
        {
            this.MoveTableDown();
        }

        private void MenuEditTableClick(object sender, System.EventArgs e)
        {
            this.EditTable();
        }

        private void MenuShowColumnsClick(object sender, System.EventArgs e)
        {
            this.ShowColumns();
        }

        private void MenuShowIndexesClick(object sender, System.EventArgs e)
        {
            this.ShowIndexes();
        }

        private void MenuCopyColumnsClick(object sender, System.EventArgs e)
        {
            this.CopyColumns();
        }

        private void MenuPasteColumnsClick(object sender, System.EventArgs e)
        {
            this.PasteColumns();
        }

        private void MenuCopyIndexesClick(object sender, System.EventArgs e)
        {
            this.CopyIndexes();
        }

        private void MenuPasteIndexesClick(object sender, System.EventArgs e)
        {
            this.PasteIndexes();
        }

        private void GridTablesSelectionChanged(object sender, System.EventArgs e)
        {
            if (this.grid.SelectedRows.Count <= 0)
            {
                return;
            }

            this.currentGridIndex = this.grid.SelectedRows[0].Index;

            if (this.frameColumns.Visible)
            {
                this.BrowseColumns(this.grid.SelectedRows[0].Index);
            }

            if (this.frameIndexes.Visible)
            {
                this.BrowseIndexes(this.grid.SelectedRows[0].Index);
            }
        }

        private void GridTablesCellMenuNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            if (((Control)sender).Focused && e.RowIndex != -1)
            {
                e.ContextMenuStrip = this.cm;
            }
        }

        private void GridCellFormating(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex != 0)
            {
                return;
            }

            e.CellStyle.Font = new Font(this.grid.Font, FontStyle.Bold);
            e.CellStyle.ForeColor = Color.DarkGreen;
        }

        private void GridKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                this.EditTable();
                e.Handled = true;
            }

            if (e.KeyCode == Keys.Delete)
            {
                this.RemoveTable();
                e.Handled = true;
            }

            if (e.KeyCode == Keys.PageUp)
            {
                this.MoveTableUp();
                e.Handled = true;
            }

            if (e.KeyCode == Keys.PageDown)
            {
                this.MoveTableDown();
                e.Handled = true;
            }

            if (e.Alt && e.KeyCode == Keys.C)
            {
                this.ShowColumns();
                e.Handled = true;
            }

            if (e.Alt && e.KeyCode == Keys.I)
            {
                this.ShowIndexes();
                e.Handled = true;
            }
        }

        private void SchemaChanged(object sender, System.EventArgs e)
        {
            this.SwitchSchema(((ComboBox)sender).SelectedIndex);
        }

        #endregion
    }
}
