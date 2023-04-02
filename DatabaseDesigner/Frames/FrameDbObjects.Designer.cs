namespace DatabaseDesigner.Frames
{
    partial class FrameDbObjects
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrameDbObjects));
            this.panelTop = new System.Windows.Forms.Panel();
            this.xFrame1 = new Arda.xControls.xFrame();
            this.grid = new Arda.xControls.xGrid(this.components);
            this.ilGrid = new System.Windows.Forms.ImageList(this.components);
            this.panelHeader = new System.Windows.Forms.Panel();
            this.cbSchema = new System.Windows.Forms.ComboBox();
            this.bAdd = new System.Windows.Forms.Button();
            this.il = new System.Windows.Forms.ImageList(this.components);
            this.bRemove = new System.Windows.Forms.Button();
            this.bUp = new System.Windows.Forms.Button();
            this.bDown = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.PanelBottom = new System.Windows.Forms.Panel();
            this.cm = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miEditTable = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.miShowColumns = new System.Windows.Forms.ToolStripMenuItem();
            this.miShowIndexes = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.miCopyColumns = new System.Windows.Forms.ToolStripMenuItem();
            this.miPasteColumns = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.miCopyIndexes = new System.Windows.Forms.ToolStripMenuItem();
            this.miPasteIndexes = new System.Windows.Forms.ToolStripMenuItem();
            this.panelTop.SuspendLayout();
            this.xFrame1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.panelHeader.SuspendLayout();
            this.cm.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelTop.Controls.Add(this.xFrame1);
            this.panelTop.Controls.Add(this.panelHeader);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1320, 553);
            this.panelTop.TabIndex = 0;
            // 
            // xFrame1
            // 
            this.xFrame1.BackColor = System.Drawing.SystemColors.Window;
            this.xFrame1.Controls.Add(this.grid);
            this.xFrame1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xFrame1.Location = new System.Drawing.Point(0, 32);
            this.xFrame1.Name = "xFrame1";
            this.xFrame1.Padding = new System.Windows.Forms.Padding(2);
            this.xFrame1.Size = new System.Drawing.Size(1320, 521);
            this.xFrame1.TabIndex = 1;
            // 
            // grid
            // 
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EvenBackColor = System.Drawing.SystemColors.Window;
            this.grid.EvenForeColor = System.Drawing.SystemColors.WindowText;
            this.grid.GridLineColor = System.Drawing.SystemColors.ControlDark;
            this.grid.ImageList = this.ilGrid;
            this.grid.Location = new System.Drawing.Point(2, 2);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.OddBackColor = System.Drawing.SystemColors.Window;
            this.grid.OddForeColor = System.Drawing.SystemColors.WindowText;
            this.grid.ReadOnly = true;
            this.grid.RowHeight = 24;
            this.grid.SelectedBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.grid.SelectedForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.ShowHorizontalGrid = false;
            this.grid.ShowVerticalGrid = false;
            this.grid.Size = new System.Drawing.Size(1316, 517);
            this.grid.StandardTab = true;
            this.grid.TabIndex = 0;
            this.grid.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.GridTablesCellMenuNeeded);
            this.grid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.GridCellFormating);
            this.grid.SelectionChanged += new System.EventHandler(this.GridTablesSelectionChanged);
            this.grid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GridKeyDown);
            // 
            // ilGrid
            // 
            this.ilGrid.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilGrid.ImageStream")));
            this.ilGrid.TransparentColor = System.Drawing.Color.Transparent;
            this.ilGrid.Images.SetKeyName(0, "x-2x.png");
            this.ilGrid.Images.SetKeyName(1, "check-2x.png");
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(211)))), ((int)(((byte)(182)))));
            this.panelHeader.Controls.Add(this.cbSchema);
            this.panelHeader.Controls.Add(this.bAdd);
            this.panelHeader.Controls.Add(this.bRemove);
            this.panelHeader.Controls.Add(this.bUp);
            this.panelHeader.Controls.Add(this.bDown);
            this.panelHeader.Controls.Add(this.label2);
            this.panelHeader.Controls.Add(this.label1);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1320, 32);
            this.panelHeader.TabIndex = 0;
            // 
            // cbSchema
            // 
            this.cbSchema.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbSchema.FormattingEnabled = true;
            this.cbSchema.Location = new System.Drawing.Point(242, 6);
            this.cbSchema.Name = "cbSchema";
            this.cbSchema.Size = new System.Drawing.Size(176, 21);
            this.cbSchema.TabIndex = 7;
            this.cbSchema.SelectionChangeCommitted += new System.EventHandler(this.SchemaChanged);
            // 
            // bAdd
            // 
            this.bAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(211)))), ((int)(((byte)(182)))));
            this.bAdd.Dock = System.Windows.Forms.DockStyle.Right;
            this.bAdd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bAdd.FlatAppearance.BorderSize = 0;
            this.bAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(224)))), ((int)(((byte)(193)))));
            this.bAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(224)))), ((int)(((byte)(193)))));
            this.bAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bAdd.ForeColor = System.Drawing.Color.Black;
            this.bAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bAdd.ImageIndex = 0;
            this.bAdd.ImageList = this.il;
            this.bAdd.Location = new System.Drawing.Point(840, 0);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(120, 32);
            this.bAdd.TabIndex = 0;
            this.bAdd.TabStop = false;
            this.bAdd.Text = "Add";
            this.bAdd.UseVisualStyleBackColor = false;
            this.bAdd.Click += new System.EventHandler(this.ButtonAddTableClick);
            // 
            // il
            // 
            this.il.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("il.ImageStream")));
            this.il.TransparentColor = System.Drawing.Color.White;
            this.il.Images.SetKeyName(0, "plus-2x.png");
            this.il.Images.SetKeyName(1, "ban-2x.png");
            this.il.Images.SetKeyName(2, "arrow-thick-bottom-2x.png");
            this.il.Images.SetKeyName(3, "arrow-thick-top-2x.png");
            // 
            // bRemove
            // 
            this.bRemove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(211)))), ((int)(((byte)(182)))));
            this.bRemove.Dock = System.Windows.Forms.DockStyle.Right;
            this.bRemove.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bRemove.FlatAppearance.BorderSize = 0;
            this.bRemove.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(224)))), ((int)(((byte)(193)))));
            this.bRemove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(224)))), ((int)(((byte)(193)))));
            this.bRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bRemove.ForeColor = System.Drawing.Color.Black;
            this.bRemove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bRemove.ImageIndex = 1;
            this.bRemove.ImageList = this.il;
            this.bRemove.Location = new System.Drawing.Point(960, 0);
            this.bRemove.Name = "bRemove";
            this.bRemove.Size = new System.Drawing.Size(120, 32);
            this.bRemove.TabIndex = 4;
            this.bRemove.TabStop = false;
            this.bRemove.Text = "Remove";
            this.bRemove.UseVisualStyleBackColor = false;
            this.bRemove.Click += new System.EventHandler(this.ButtonRemoveTableClick);
            // 
            // bUp
            // 
            this.bUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(211)))), ((int)(((byte)(182)))));
            this.bUp.Dock = System.Windows.Forms.DockStyle.Right;
            this.bUp.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bUp.FlatAppearance.BorderSize = 0;
            this.bUp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(224)))), ((int)(((byte)(193)))));
            this.bUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(224)))), ((int)(((byte)(193)))));
            this.bUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bUp.ForeColor = System.Drawing.Color.Black;
            this.bUp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bUp.ImageIndex = 3;
            this.bUp.ImageList = this.il;
            this.bUp.Location = new System.Drawing.Point(1080, 0);
            this.bUp.Name = "bUp";
            this.bUp.Size = new System.Drawing.Size(120, 32);
            this.bUp.TabIndex = 5;
            this.bUp.TabStop = false;
            this.bUp.Text = "Move Up";
            this.bUp.UseVisualStyleBackColor = false;
            this.bUp.Click += new System.EventHandler(this.ButtonUpClick);
            // 
            // bDown
            // 
            this.bDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(211)))), ((int)(((byte)(182)))));
            this.bDown.Dock = System.Windows.Forms.DockStyle.Right;
            this.bDown.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bDown.FlatAppearance.BorderSize = 0;
            this.bDown.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(224)))), ((int)(((byte)(193)))));
            this.bDown.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(224)))), ((int)(((byte)(193)))));
            this.bDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bDown.ForeColor = System.Drawing.Color.Black;
            this.bDown.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bDown.ImageIndex = 2;
            this.bDown.ImageList = this.il;
            this.bDown.Location = new System.Drawing.Point(1200, 0);
            this.bDown.Name = "bDown";
            this.bDown.Size = new System.Drawing.Size(120, 32);
            this.bDown.TabIndex = 6;
            this.bDown.TabStop = false;
            this.bDown.Text = "Move Down";
            this.bDown.UseVisualStyleBackColor = false;
            this.bDown.Click += new System.EventHandler(this.ButtonDownClick);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(180, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 32);
            this.label2.TabIndex = 2;
            this.label2.Text = "Schema:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tables";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 553);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1320, 3);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // PanelBottom
            // 
            this.PanelBottom.BackColor = System.Drawing.Color.White;
            this.PanelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelBottom.Location = new System.Drawing.Point(0, 556);
            this.PanelBottom.Name = "PanelBottom";
            this.PanelBottom.Size = new System.Drawing.Size(1320, 82);
            this.PanelBottom.TabIndex = 2;
            // 
            // cm
            // 
            this.cm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miEditTable,
            this.toolStripSeparator1,
            this.miShowColumns,
            this.miShowIndexes,
            this.toolStripMenuItem1,
            this.miCopyColumns,
            this.miPasteColumns,
            this.toolStripMenuItem2,
            this.miCopyIndexes,
            this.miPasteIndexes});
            this.cm.Name = "cmTables";
            this.cm.Size = new System.Drawing.Size(155, 176);
            // 
            // miEditTable
            // 
            this.miEditTable.Name = "miEditTable";
            this.miEditTable.Size = new System.Drawing.Size(154, 22);
            this.miEditTable.Text = "Edit";
            this.miEditTable.Click += new System.EventHandler(this.MenuEditTableClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(151, 6);
            // 
            // miShowColumns
            // 
            this.miShowColumns.Name = "miShowColumns";
            this.miShowColumns.Size = new System.Drawing.Size(154, 22);
            this.miShowColumns.Text = "Show Columns";
            this.miShowColumns.Click += new System.EventHandler(this.MenuShowColumnsClick);
            // 
            // miShowIndexes
            // 
            this.miShowIndexes.Name = "miShowIndexes";
            this.miShowIndexes.Size = new System.Drawing.Size(154, 22);
            this.miShowIndexes.Text = "Show Indexes";
            this.miShowIndexes.Click += new System.EventHandler(this.MenuShowIndexesClick);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(151, 6);
            // 
            // miCopyColumns
            // 
            this.miCopyColumns.Name = "miCopyColumns";
            this.miCopyColumns.Size = new System.Drawing.Size(154, 22);
            this.miCopyColumns.Text = "Copy Columns";
            this.miCopyColumns.Click += new System.EventHandler(this.MenuCopyColumnsClick);
            // 
            // miPasteColumns
            // 
            this.miPasteColumns.Name = "miPasteColumns";
            this.miPasteColumns.Size = new System.Drawing.Size(154, 22);
            this.miPasteColumns.Text = "Paste Columns";
            this.miPasteColumns.Click += new System.EventHandler(this.MenuPasteColumnsClick);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(151, 6);
            // 
            // miCopyIndexes
            // 
            this.miCopyIndexes.Name = "miCopyIndexes";
            this.miCopyIndexes.Size = new System.Drawing.Size(154, 22);
            this.miCopyIndexes.Text = "Copy Indexes";
            this.miCopyIndexes.Click += new System.EventHandler(this.MenuCopyIndexesClick);
            // 
            // miPasteIndexes
            // 
            this.miPasteIndexes.Name = "miPasteIndexes";
            this.miPasteIndexes.Size = new System.Drawing.Size(154, 22);
            this.miPasteIndexes.Text = "Paste Indexes";
            this.miPasteIndexes.Click += new System.EventHandler(this.MenuPasteIndexesClick);
            // 
            // FrameDbObjects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.PanelBottom);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panelTop);
            this.Name = "FrameDbObjects";
            this.Size = new System.Drawing.Size(1320, 638);
            this.panelTop.ResumeLayout(false);
            this.xFrame1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.cm.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel PanelBottom;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Button bAdd;
        private System.Windows.Forms.ImageList il;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bDown;
        private System.Windows.Forms.Button bUp;
        private System.Windows.Forms.Button bRemove;
        private System.Windows.Forms.Label label2;
        private Arda.xControls.xFrame xFrame1;
        private Arda.xControls.xGrid grid;
        private System.Windows.Forms.ContextMenuStrip cm;
        private System.Windows.Forms.ToolStripMenuItem miEditTable;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem miCopyColumns;
        private System.Windows.Forms.ToolStripMenuItem miPasteColumns;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem miCopyIndexes;
        private System.Windows.Forms.ToolStripMenuItem miPasteIndexes;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem miShowColumns;
        private System.Windows.Forms.ToolStripMenuItem miShowIndexes;
        private System.Windows.Forms.ImageList ilGrid;
        private System.Windows.Forms.ComboBox cbSchema;

    }
}
