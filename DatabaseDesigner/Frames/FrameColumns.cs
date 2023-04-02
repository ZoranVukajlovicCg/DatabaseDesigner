// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FrameColumns.cs" company="N/A">
//   Zoran Vukajlovic
// </copyright>
// <summary>
//   Defines the FrameColumns type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DatabaseDesigner.Frames
{
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    using DatabaseDesigner.Clases;
    using DatabaseDesigner.Entities;
    using DatabaseDesigner.Forms;

    public partial class FrameColumns : UserControl
    {
        public delegate void dlgcUpdateTablesCallback();
        private dlgcUpdateTablesCallback dlgUpdatTableCallback;
        public delegate void dlgcUpdateInfoPanelCallback();
        private dlgcUpdateInfoPanelCallback dlgUpdateInfoCallback;


        private Table dataSource;
        private int currentGridIndex;

        public FrameColumns(dlgcUpdateTablesCallback dlgTables, dlgcUpdateInfoPanelCallback dlgInfo)
        {
            this.dlgUpdatTableCallback = dlgTables;
            this.dlgUpdateInfoCallback = dlgInfo;
            this.InitializeComponent();

            Util.GridSetup(this.grid);
            this.grid.AddCustomColumn(new DataColumn("ColumnOrder", typeof(int)), "Order", 45, true, string.Empty, DataGridViewContentAlignment.MiddleRight);
            this.grid.AddCustomColumn(new DataColumn("Name", typeof(string)), "Name", 170, true, string.Empty, DataGridViewContentAlignment.MiddleLeft);
            this.grid.AddCustomColumn(new DataColumn("DisplayName", typeof(string)), "Display Name", 170, true, string.Empty, DataGridViewContentAlignment.MiddleLeft);
            this.grid.AddCustomColumn(new DataColumn("DbType", typeof(string)), "Data Type", 80, true, string.Empty, DataGridViewContentAlignment.MiddleLeft);
            this.grid.AddCustomColumn(new DataColumn("DbLength", typeof(int)), "Length", 50, true, string.Empty, DataGridViewContentAlignment.MiddleRight);
            this.grid.AddCustomColumn(new DataColumn("DbPrecision", typeof(string)), "Precision", 60, true, string.Empty, DataGridViewContentAlignment.MiddleLeft);
            this.grid.AddCustomColumn(new DataColumn("DefaultValue", typeof(string)), "Default Value", 170, true, string.Empty, DataGridViewContentAlignment.MiddleLeft);
            this.grid.AddCheckColumn(new DataColumn("IsPrimaryKey", typeof(bool)), "PK", 45, null, null);
            this.grid.AddCheckColumn(new DataColumn("IsAutoincrement", typeof(bool)), "AI", 45, null, null);
            this.grid.AddCheckColumn(new DataColumn("IsNullable", typeof(bool)), "Null", 45, null, null);
            this.grid.AddCheckColumn(new DataColumn("IsRequired", typeof(bool)), "Req", 45, null, null);
            this.grid.AddCheckColumn(new DataColumn("IsSearchable", typeof(bool)), "Srch", 45, null, null);
            this.grid.AddCheckColumn(new DataColumn("IsFullTextSearch", typeof(bool)), "FTS", 45, null, null);
            this.grid.AddCheckColumn(new DataColumn("IsSystem", typeof(bool)), "Sys", 45, null, null);
            this.grid.AddCheckColumn(new DataColumn("AddToRepository", typeof(bool)), "Rep", 45, null, null);
            this.grid.AddCheckColumn(new DataColumn("IsReference", typeof(bool)), "Ref", 45, null, null);
            this.grid.AddCheckColumn(new DataColumn("IsConstraint", typeof(bool)), "Con", 45, null, null);
            this.grid.AddCustomColumn(new DataColumn("ReferenceTableSchema", typeof(string)), "Ref. Schema", 100, true, string.Empty, DataGridViewContentAlignment.MiddleLeft);
            this.grid.AddCustomColumn(new DataColumn("ReferenceTable", typeof(string)), "Reference Table", 150, true, string.Empty, DataGridViewContentAlignment.MiddleLeft);
            this.grid.AddCustomColumn(new DataColumn("ReferenceField", typeof(string)), "Reference Field", 150, true, string.Empty, DataGridViewContentAlignment.MiddleLeft);
        }

        public void ResetData(Table table)
        {
            this.dataSource = table;
            this.BindData(table);
            this.labHeader.Text = string.Format(@"Columns: {0}", table.Name);
        }

        public void Add()
        {
            this.AddColumn();
        }

        private void BindData(Table ds)
        {
            var bs = new BindingSource { DataSource = ds.Columns };
            this.grid.DataSource = bs;
        }

        #region Actions

        private void AddColumn()
        {
            var f = new FormAddColumn(this.dataSource);
            if (f.Add() != DialogResult.OK)
            {
                return;
            }

            Util.RecalculateColumnOrder(this.dataSource);
            ((BindingSource)this.grid.DataSource).ResetBindings(false);
            AppStatus.ModelSaved = false;
            this.Invoke(dlgUpdateInfoCallback);
        }

        private void EditColumn(int index)
        {
            var f = new FormAddColumn(this.dataSource);
            if (f.Edit(index) != DialogResult.OK)
            {
                return;
            }

            ((BindingSource)this.grid.DataSource).ResetBindings(false);
            AppStatus.ModelSaved = false;
            this.Invoke(dlgUpdateInfoCallback);
        }

        private void RemoveColumn()
        {
            if (this.currentGridIndex < 0 || this.currentGridIndex > this.dataSource.Columns.Count - 1)
            {
                return;
            }

            if (MessageBox.Show(
                @"Do you want to permanently remove selected column?",
                @"WARNING",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }

            this.dataSource.Columns.RemoveAt(this.currentGridIndex);

            Util.RecalculateColumnOrder(this.dataSource);
            ((BindingSource)this.grid.DataSource).ResetBindings(false);
            AppStatus.ModelSaved = false;
            this.Invoke(dlgUpdateInfoCallback);
        }

        private void MoveColumnUp()
        {
            if (this.currentGridIndex < 0 || this.currentGridIndex > this.dataSource.Columns.Count - 1)
            {
                return;
            }

            if (this.currentGridIndex < 1)
            {
                return;
            }

            var column = Util.CopyColumn(this.dataSource.Columns[this.currentGridIndex]);
            this.dataSource.Columns.RemoveAt(this.currentGridIndex);
            this.dataSource.Columns.Insert(this.currentGridIndex - 1, column);

            Util.RecalculateColumnOrder(this.dataSource);
            ((BindingSource)this.grid.DataSource).ResetBindings(false);
            AppStatus.ModelSaved = false;

            this.grid.CurrentCell = this.grid.Rows[this.currentGridIndex - 1].Cells[0];
            this.Invoke(dlgUpdateInfoCallback);
        }

        private void MoveColumnDown()
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

            var column = Util.CopyColumn(this.dataSource.Columns[this.currentGridIndex]);
            this.dataSource.Columns.RemoveAt(this.currentGridIndex);
            this.dataSource.Columns.Insert(this.currentGridIndex + 1, column);

            Util.RecalculateColumnOrder(this.dataSource);
            ((BindingSource)this.grid.DataSource).ResetBindings(false);
            AppStatus.ModelSaved = false;

            this.grid.CurrentCell = this.grid.Rows[this.currentGridIndex + 1].Cells[0];
            this.Invoke(dlgUpdateInfoCallback);
        }

        private void RepositoryChange(int index)
        {
            this.dataSource.Columns[index].AddToRepository = !this.dataSource.Columns[index].AddToRepository;
            
            // if column is set to be added to repository, table must be added too
            if(this.dataSource.Columns[index].AddToRepository)
            {
                this.dataSource.AddToRepository = true;
            }
            else
            {
                // chack all the columns if all have AddToRepository false set table AddToRepository to false
                bool addToRepository = false;
                foreach(var column in this.dataSource.Columns) 
                { 
                    if (column.AddToRepository)
                    {
                        addToRepository = true;
                        break;
                    }
                }
                if(!addToRepository) 
                {
                    this.dataSource.AddToRepository = addToRepository;    
                }
            }

            ((BindingSource)this.grid.DataSource).ResetBindings(false);
            AppStatus.ModelSaved = false;
            this.Invoke(dlgUpdatTableCallback);
            this.Invoke(dlgUpdateInfoCallback);
        }

        #endregion

        #region Events

        private void ButtonAddClick(object sender, System.EventArgs e)
        {
            this.AddColumn();
        }

        private void ButtonRemoveClick(object sender, System.EventArgs e)
        {
            this.RemoveColumn();
        }

        private void ButtonUpClick(object sender, System.EventArgs e)
        {
            this.MoveColumnUp();
        }

        private void ButtonDownClick(object sender, System.EventArgs e)
        {
            this.MoveColumnDown();
        }

        private void MenuEditClick(object sender, System.EventArgs e)
        {
            if (this.grid.SelectedRows[0].Index != -1)
            {
                this.EditColumn(this.grid.SelectedRows[0].Index);
            }
        }
        
        private void GridSelectionChanged(object sender, System.EventArgs e)
        {
            if (this.grid.SelectedRows.Count <= 0)
            {
                return;
            }

            this.currentGridIndex = this.grid.SelectedRows[0].Index;
        }

        private void GridCellContextMenuNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            if (((Control)sender).Focused && e.RowIndex != -1)
            {
                e.ContextMenuStrip = this.cm;
            }
        }

        private void GridCellFormating(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex != 1)
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
                this.EditColumn(this.currentGridIndex);
                e.Handled = true;
            }

            if (e.KeyCode == Keys.Delete)
            {
                this.RemoveColumn();
                e.Handled = true;
            }

            if (e.KeyCode == Keys.PageUp)
            {
                this.MoveColumnUp();
                e.Handled = true;
            }

            if (e.KeyCode == Keys.PageDown)
            {
                this.MoveColumnDown();
                e.Handled = true;
            }
        }

        private void MenuRepositoryClick(object sender, System.EventArgs e)
        {
            if (this.grid.SelectedRows[0].Index != -1)
            {
                this.RepositoryChange(this.grid.SelectedRows[0].Index);
            }
        }

        private void cmOpening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.grid.SelectedRows[0].Index != -1)
            {
                miRepository.Text = this.dataSource.Columns[this.grid.SelectedRows[0].Index].AddToRepository ? @"Do not add to repository" : @"Add to repository";
            }
        }

        #endregion
    }
}
