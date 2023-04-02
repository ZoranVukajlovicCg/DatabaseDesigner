namespace DatabaseDesigner.Frames
{
    partial class FrameIndexes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrameIndexes));
            this.miEditTable = new System.Windows.Forms.ToolStripMenuItem();
            this.cm = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.il = new System.Windows.Forms.ImageList(this.components);
            this.xFrame1 = new Arda.xControls.xFrame();
            this.grid = new Arda.xControls.xGrid(this.components);
            this.panelHeader = new System.Windows.Forms.Panel();
            this.bAdd = new System.Windows.Forms.Button();
            this.bRemove = new System.Windows.Forms.Button();
            this.bUp = new System.Windows.Forms.Button();
            this.bDown = new System.Windows.Forms.Button();
            this.labHeader = new System.Windows.Forms.Label();
            this.cm.SuspendLayout();
            this.xFrame1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // miEditTable
            // 
            this.miEditTable.Name = "miEditTable";
            this.miEditTable.Size = new System.Drawing.Size(94, 22);
            this.miEditTable.Text = "Edit";
            this.miEditTable.Click += new System.EventHandler(this.MenuEditClick);
            // 
            // cm
            // 
            this.cm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miEditTable});
            this.cm.Name = "cmTables";
            this.cm.Size = new System.Drawing.Size(95, 26);
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
            // xFrame1
            // 
            this.xFrame1.BackColor = System.Drawing.SystemColors.Window;
            this.xFrame1.Controls.Add(this.grid);
            this.xFrame1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xFrame1.Location = new System.Drawing.Point(0, 32);
            this.xFrame1.Name = "xFrame1";
            this.xFrame1.Padding = new System.Windows.Forms.Padding(2);
            this.xFrame1.Size = new System.Drawing.Size(1173, 598);
            this.xFrame1.TabIndex = 4;
            // 
            // grid
            // 
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EvenBackColor = System.Drawing.SystemColors.Window;
            this.grid.EvenForeColor = System.Drawing.SystemColors.WindowText;
            this.grid.GridLineColor = System.Drawing.SystemColors.ControlDark;
            this.grid.ImageList = null;
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
            this.grid.Size = new System.Drawing.Size(1169, 594);
            this.grid.StandardTab = true;
            this.grid.TabIndex = 0;
            this.grid.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.GridCellContextMenuNeeded);
            this.grid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.GridCellFormating);
            this.grid.SelectionChanged += new System.EventHandler(this.GridSelectionChanged);
            this.grid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GridKeyDown);
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(211)))), ((int)(((byte)(182)))));
            this.panelHeader.Controls.Add(this.bAdd);
            this.panelHeader.Controls.Add(this.bRemove);
            this.panelHeader.Controls.Add(this.bUp);
            this.panelHeader.Controls.Add(this.bDown);
            this.panelHeader.Controls.Add(this.labHeader);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1173, 32);
            this.panelHeader.TabIndex = 5;
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
            this.bAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bAdd.ImageIndex = 0;
            this.bAdd.ImageList = this.il;
            this.bAdd.Location = new System.Drawing.Point(693, 0);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(120, 32);
            this.bAdd.TabIndex = 0;
            this.bAdd.TabStop = false;
            this.bAdd.Text = "Add";
            this.bAdd.UseVisualStyleBackColor = false;
            this.bAdd.Click += new System.EventHandler(this.ButtonAddClick);
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
            this.bRemove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bRemove.ImageIndex = 1;
            this.bRemove.ImageList = this.il;
            this.bRemove.Location = new System.Drawing.Point(813, 0);
            this.bRemove.Name = "bRemove";
            this.bRemove.Size = new System.Drawing.Size(120, 32);
            this.bRemove.TabIndex = 4;
            this.bRemove.TabStop = false;
            this.bRemove.Text = "Remove";
            this.bRemove.UseVisualStyleBackColor = false;
            this.bRemove.Click += new System.EventHandler(this.ButtonRemoveClick);
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
            this.bUp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bUp.ImageIndex = 3;
            this.bUp.ImageList = this.il;
            this.bUp.Location = new System.Drawing.Point(933, 0);
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
            this.bDown.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bDown.ImageIndex = 2;
            this.bDown.ImageList = this.il;
            this.bDown.Location = new System.Drawing.Point(1053, 0);
            this.bDown.Name = "bDown";
            this.bDown.Size = new System.Drawing.Size(120, 32);
            this.bDown.TabIndex = 6;
            this.bDown.TabStop = false;
            this.bDown.Text = "Move Down";
            this.bDown.UseVisualStyleBackColor = false;
            this.bDown.Click += new System.EventHandler(this.ButtonDownClick);
            // 
            // labHeader
            // 
            this.labHeader.Dock = System.Windows.Forms.DockStyle.Left;
            this.labHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labHeader.ForeColor = System.Drawing.Color.Black;
            this.labHeader.Location = new System.Drawing.Point(0, 0);
            this.labHeader.Name = "labHeader";
            this.labHeader.Size = new System.Drawing.Size(674, 32);
            this.labHeader.TabIndex = 1;
            this.labHeader.Text = "Indexes";
            this.labHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrameIndexes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.xFrame1);
            this.Controls.Add(this.panelHeader);
            this.Name = "FrameIndexes";
            this.Size = new System.Drawing.Size(1173, 630);
            this.cm.ResumeLayout(false);
            this.xFrame1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem miEditTable;
        private System.Windows.Forms.ContextMenuStrip cm;
        private System.Windows.Forms.ImageList il;
        private Arda.xControls.xFrame xFrame1;
        private Arda.xControls.xGrid grid;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Button bAdd;
        private System.Windows.Forms.Button bRemove;
        private System.Windows.Forms.Button bUp;
        private System.Windows.Forms.Button bDown;
        private System.Windows.Forms.Label labHeader;
    }
}
