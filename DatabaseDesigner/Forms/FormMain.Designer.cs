namespace DatabaseDesigner.Forms
{
    partial class FormMain
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
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.saveModelDialog = new System.Windows.Forms.SaveFileDialog();
            this.openModelDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveDatabaseScriptDialog = new System.Windows.Forms.SaveFileDialog();
            this.loadUmlDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.miFile = new System.Windows.Forms.ToolStripMenuItem();
            this.miNew = new System.Windows.Forms.ToolStripMenuItem();
            this.miOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.miSave = new System.Windows.Forms.ToolStripMenuItem();
            this.miSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.miExit = new System.Windows.Forms.ToolStripMenuItem();
            this.miImport = new System.Windows.Forms.ToolStripMenuItem();
            this.miLoadUml = new System.Windows.Forms.ToolStripMenuItem();
            this.miScript = new System.Windows.Forms.ToolStripMenuItem();
            this.miSqlScript = new System.Windows.Forms.ToolStripMenuItem();
            this.miHibMappings = new System.Windows.Forms.ToolStripMenuItem();
            this.miClasses = new System.Windows.Forms.ToolStripMenuItem();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.labIndexCount = new System.Windows.Forms.Label();
            this.labColumnCount = new System.Windows.Forms.Label();
            this.labTableCount = new System.Windows.Forms.Label();
            this.labSchemaCount = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labScriptPathCaption = new System.Windows.Forms.Label();
            this.labScriptPath = new System.Windows.Forms.Label();
            this.labModelPathCaption = new System.Windows.Forms.Label();
            this.labModelPath = new System.Windows.Forms.Label();
            this.labUmlModelPathCaption = new System.Windows.Forms.Label();
            this.labScriptGenerated = new System.Windows.Forms.Label();
            this.ilStatus = new System.Windows.Forms.ImageList(this.components);
            this.labModelSaved = new System.Windows.Forms.Label();
            this.labModelCreated = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labMoveDown = new System.Windows.Forms.Label();
            this.labMoveUp = new System.Windows.Forms.Label();
            this.labRemove = new System.Windows.Forms.Label();
            this.labRename = new System.Windows.Forms.Label();
            this.labAdd = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbSchemas = new System.Windows.Forms.ListBox();
            this.labChangeModelName = new System.Windows.Forms.Label();
            this.labModelName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labUmlModelPath = new System.Windows.Forms.Label();
            this.labUmlModelLoaded = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labColapse = new System.Windows.Forms.Label();
            this.tTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveModelDialog
            // 
            this.saveModelDialog.DefaultExt = "xml";
            this.saveModelDialog.Filter = "XML Schema|*.xml";
            // 
            // openModelDialog
            // 
            this.openModelDialog.FileName = "openFileDialog1";
            this.openModelDialog.Filter = "XML Schema|*.xml";
            // 
            // saveDatabaseScriptDialog
            // 
            this.saveDatabaseScriptDialog.Filter = "T-SQL Script|*.sql";
            // 
            // loadUmlDialog
            // 
            this.loadUmlDialog.DefaultExt = "uxf";
            this.loadUmlDialog.Filter = "Umlet graph files (*.uxf)|*.uxf";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFile,
            this.miImport,
            this.miScript});
            this.menuStrip1.Location = new System.Drawing.Point(8, 8);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1248, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // miFile
            // 
            this.miFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miNew,
            this.miOpen,
            this.miSave,
            this.miSaveAs,
            this.toolStripMenuItem1,
            this.miExit});
            this.miFile.Name = "miFile";
            this.miFile.Size = new System.Drawing.Size(37, 20);
            this.miFile.Text = "File";
            // 
            // miNew
            // 
            this.miNew.Name = "miNew";
            this.miNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.miNew.Size = new System.Drawing.Size(186, 22);
            this.miNew.Text = "New";
            this.miNew.Click += new System.EventHandler(this.ButtonNewClick);
            // 
            // miOpen
            // 
            this.miOpen.Name = "miOpen";
            this.miOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.miOpen.Size = new System.Drawing.Size(186, 22);
            this.miOpen.Text = "Open";
            this.miOpen.Click += new System.EventHandler(this.ButtonOpenClick);
            // 
            // miSave
            // 
            this.miSave.Name = "miSave";
            this.miSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.miSave.Size = new System.Drawing.Size(186, 22);
            this.miSave.Text = "Save";
            this.miSave.Click += new System.EventHandler(this.ButtonSaveClick);
            // 
            // miSaveAs
            // 
            this.miSaveAs.Name = "miSaveAs";
            this.miSaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.miSaveAs.Size = new System.Drawing.Size(186, 22);
            this.miSaveAs.Text = "Save As";
            this.miSaveAs.Click += new System.EventHandler(this.ButtonSaveAsClick);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(183, 6);
            // 
            // miExit
            // 
            this.miExit.Name = "miExit";
            this.miExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.miExit.Size = new System.Drawing.Size(186, 22);
            this.miExit.Text = "Exit";
            this.miExit.Click += new System.EventHandler(this.ButtonCloseClick);
            // 
            // miImport
            // 
            this.miImport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miLoadUml});
            this.miImport.Name = "miImport";
            this.miImport.Size = new System.Drawing.Size(55, 20);
            this.miImport.Text = "Import";
            // 
            // miLoadUml
            // 
            this.miLoadUml.Name = "miLoadUml";
            this.miLoadUml.Size = new System.Drawing.Size(180, 22);
            this.miLoadUml.Text = "From UMLet file";
            this.miLoadUml.Click += new System.EventHandler(this.ButtonLoadUmlClick);
            // 
            // miScript
            // 
            this.miScript.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miSqlScript,
            this.miHibMappings,
            this.miClasses});
            this.miScript.Name = "miScript";
            this.miScript.Size = new System.Drawing.Size(49, 20);
            this.miScript.Text = "Script";
            // 
            // miSqlScript
            // 
            this.miSqlScript.Name = "miSqlScript";
            this.miSqlScript.Size = new System.Drawing.Size(228, 22);
            this.miSqlScript.Text = "Create SQL Script";
            this.miSqlScript.Click += new System.EventHandler(this.ButtonGenerateClick);
            // 
            // miHibMappings
            // 
            this.miHibMappings.Enabled = false;
            this.miHibMappings.Name = "miHibMappings";
            this.miHibMappings.Size = new System.Drawing.Size(228, 22);
            this.miHibMappings.Text = "Create NHibernate Mappings";
            this.miHibMappings.Visible = false;
            // 
            // miClasses
            // 
            this.miClasses.Enabled = false;
            this.miClasses.Name = "miClasses";
            this.miClasses.Size = new System.Drawing.Size(228, 22);
            this.miClasses.Text = "CreateData Model Classes";
            this.miClasses.Visible = false;
            // 
            // scMain
            // 
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.Location = new System.Drawing.Point(8, 32);
            this.scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.scMain.Panel1.Controls.Add(this.labIndexCount);
            this.scMain.Panel1.Controls.Add(this.labColumnCount);
            this.scMain.Panel1.Controls.Add(this.labTableCount);
            this.scMain.Panel1.Controls.Add(this.labSchemaCount);
            this.scMain.Panel1.Controls.Add(this.label7);
            this.scMain.Panel1.Controls.Add(this.labScriptPathCaption);
            this.scMain.Panel1.Controls.Add(this.labScriptPath);
            this.scMain.Panel1.Controls.Add(this.labModelPathCaption);
            this.scMain.Panel1.Controls.Add(this.labModelPath);
            this.scMain.Panel1.Controls.Add(this.labUmlModelPathCaption);
            this.scMain.Panel1.Controls.Add(this.labScriptGenerated);
            this.scMain.Panel1.Controls.Add(this.labModelSaved);
            this.scMain.Panel1.Controls.Add(this.labModelCreated);
            this.scMain.Panel1.Controls.Add(this.label6);
            this.scMain.Panel1.Controls.Add(this.label5);
            this.scMain.Panel1.Controls.Add(this.label4);
            this.scMain.Panel1.Controls.Add(this.labMoveDown);
            this.scMain.Panel1.Controls.Add(this.labMoveUp);
            this.scMain.Panel1.Controls.Add(this.labRemove);
            this.scMain.Panel1.Controls.Add(this.labRename);
            this.scMain.Panel1.Controls.Add(this.labAdd);
            this.scMain.Panel1.Controls.Add(this.label3);
            this.scMain.Panel1.Controls.Add(this.lbSchemas);
            this.scMain.Panel1.Controls.Add(this.labChangeModelName);
            this.scMain.Panel1.Controls.Add(this.labModelName);
            this.scMain.Panel1.Controls.Add(this.label2);
            this.scMain.Panel1.Controls.Add(this.panel1);
            this.scMain.Panel1.Controls.Add(this.labUmlModelPath);
            this.scMain.Panel1.Controls.Add(this.labUmlModelLoaded);
            this.scMain.Panel1.Controls.Add(this.label1);
            this.scMain.Panel1.Controls.Add(this.labColapse);
            this.scMain.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel1Paint);
            this.scMain.Size = new System.Drawing.Size(1248, 787);
            this.scMain.SplitterDistance = 416;
            this.scMain.TabIndex = 17;
            // 
            // labIndexCount
            // 
            this.labIndexCount.AutoSize = true;
            this.labIndexCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labIndexCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labIndexCount.Location = new System.Drawing.Point(40, 510);
            this.labIndexCount.Name = "labIndexCount";
            this.labIndexCount.Size = new System.Drawing.Size(44, 13);
            this.labIndexCount.TabIndex = 36;
            this.labIndexCount.Text = "Indexes";
            // 
            // labColumnCount
            // 
            this.labColumnCount.AutoSize = true;
            this.labColumnCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labColumnCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labColumnCount.Location = new System.Drawing.Point(40, 485);
            this.labColumnCount.Name = "labColumnCount";
            this.labColumnCount.Size = new System.Drawing.Size(47, 13);
            this.labColumnCount.TabIndex = 35;
            this.labColumnCount.Text = "Columns";
            // 
            // labTableCount
            // 
            this.labTableCount.AutoSize = true;
            this.labTableCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTableCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labTableCount.Location = new System.Drawing.Point(40, 460);
            this.labTableCount.Name = "labTableCount";
            this.labTableCount.Size = new System.Drawing.Size(39, 13);
            this.labTableCount.TabIndex = 34;
            this.labTableCount.Text = "Tables";
            // 
            // labSchemaCount
            // 
            this.labSchemaCount.AutoSize = true;
            this.labSchemaCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labSchemaCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labSchemaCount.Location = new System.Drawing.Point(40, 435);
            this.labSchemaCount.Name = "labSchemaCount";
            this.labSchemaCount.Size = new System.Drawing.Size(51, 13);
            this.labSchemaCount.TabIndex = 33;
            this.labSchemaCount.Text = "Schemas";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label7.Location = new System.Drawing.Point(40, 410);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 32;
            this.label7.Text = "Statistic:";
            // 
            // labScriptPathCaption
            // 
            this.labScriptPathCaption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labScriptPathCaption.AutoSize = true;
            this.labScriptPathCaption.Cursor = System.Windows.Forms.Cursors.Default;
            this.labScriptPathCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labScriptPathCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labScriptPathCaption.Location = new System.Drawing.Point(40, 642);
            this.labScriptPathCaption.Name = "labScriptPathCaption";
            this.labScriptPathCaption.Size = new System.Drawing.Size(85, 13);
            this.labScriptPathCaption.TabIndex = 31;
            this.labScriptPathCaption.Text = "SQL Script path:";
            // 
            // labScriptPath
            // 
            this.labScriptPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labScriptPath.AutoSize = true;
            this.labScriptPath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labScriptPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labScriptPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labScriptPath.Location = new System.Drawing.Point(40, 667);
            this.labScriptPath.Name = "labScriptPath";
            this.labScriptPath.Size = new System.Drawing.Size(82, 13);
            this.labScriptPath.TabIndex = 30;
            this.labScriptPath.Text = "SQL Script path";
            this.labScriptPath.Click += new System.EventHandler(this.ModelPathClick);
            // 
            // labModelPathCaption
            // 
            this.labModelPathCaption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labModelPathCaption.AutoSize = true;
            this.labModelPathCaption.Cursor = System.Windows.Forms.Cursors.Default;
            this.labModelPathCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labModelPathCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labModelPathCaption.Location = new System.Drawing.Point(40, 592);
            this.labModelPathCaption.Name = "labModelPathCaption";
            this.labModelPathCaption.Size = new System.Drawing.Size(63, 13);
            this.labModelPathCaption.TabIndex = 29;
            this.labModelPathCaption.Text = "Model path:";
            // 
            // labModelPath
            // 
            this.labModelPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labModelPath.AutoSize = true;
            this.labModelPath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labModelPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labModelPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labModelPath.Location = new System.Drawing.Point(40, 617);
            this.labModelPath.Name = "labModelPath";
            this.labModelPath.Size = new System.Drawing.Size(60, 13);
            this.labModelPath.TabIndex = 28;
            this.labModelPath.Text = "Model path";
            this.labModelPath.Click += new System.EventHandler(this.ModelPathClick);
            // 
            // labUmlModelPathCaption
            // 
            this.labUmlModelPathCaption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labUmlModelPathCaption.AutoSize = true;
            this.labUmlModelPathCaption.Cursor = System.Windows.Forms.Cursors.Default;
            this.labUmlModelPathCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labUmlModelPathCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labUmlModelPathCaption.Location = new System.Drawing.Point(40, 542);
            this.labUmlModelPathCaption.Name = "labUmlModelPathCaption";
            this.labUmlModelPathCaption.Size = new System.Drawing.Size(88, 13);
            this.labUmlModelPathCaption.TabIndex = 27;
            this.labUmlModelPathCaption.Text = "UML model path:";
            // 
            // labScriptGenerated
            // 
            this.labScriptGenerated.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labScriptGenerated.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labScriptGenerated.ImageIndex = 0;
            this.labScriptGenerated.ImageList = this.ilStatus;
            this.labScriptGenerated.Location = new System.Drawing.Point(351, 185);
            this.labScriptGenerated.Name = "labScriptGenerated";
            this.labScriptGenerated.Size = new System.Drawing.Size(16, 16);
            this.labScriptGenerated.TabIndex = 26;
            // 
            // ilStatus
            // 
            this.ilStatus.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilStatus.ImageStream")));
            this.ilStatus.TransparentColor = System.Drawing.Color.Transparent;
            this.ilStatus.Images.SetKeyName(0, "no.ico");
            this.ilStatus.Images.SetKeyName(1, "yes.ico");
            // 
            // labModelSaved
            // 
            this.labModelSaved.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labModelSaved.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labModelSaved.ImageIndex = 0;
            this.labModelSaved.ImageList = this.ilStatus;
            this.labModelSaved.Location = new System.Drawing.Point(351, 160);
            this.labModelSaved.Name = "labModelSaved";
            this.labModelSaved.Size = new System.Drawing.Size(16, 16);
            this.labModelSaved.TabIndex = 25;
            // 
            // labModelCreated
            // 
            this.labModelCreated.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labModelCreated.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labModelCreated.ImageIndex = 0;
            this.labModelCreated.ImageList = this.ilStatus;
            this.labModelCreated.Location = new System.Drawing.Point(351, 135);
            this.labModelCreated.Name = "labModelCreated";
            this.labModelCreated.Size = new System.Drawing.Size(16, 16);
            this.labModelCreated.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label6.Location = new System.Drawing.Point(40, 185);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "SQL Script generated";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label5.Location = new System.Drawing.Point(40, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Model saved";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label4.Location = new System.Drawing.Point(40, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Model created";
            // 
            // labMoveDown
            // 
            this.labMoveDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labMoveDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labMoveDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labMoveDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labMoveDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labMoveDown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labMoveDown.Location = new System.Drawing.Point(292, 364);
            this.labMoveDown.Name = "labMoveDown";
            this.labMoveDown.Size = new System.Drawing.Size(75, 23);
            this.labMoveDown.TabIndex = 20;
            this.labMoveDown.Text = "Move Down";
            this.labMoveDown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labMoveDown.Click += new System.EventHandler(this.SchemaButtonClick);
            this.labMoveDown.MouseEnter += new System.EventHandler(this.labBttnMouseEnter);
            this.labMoveDown.MouseLeave += new System.EventHandler(this.labBtnMouseLeave);
            // 
            // labMoveUp
            // 
            this.labMoveUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labMoveUp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labMoveUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labMoveUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labMoveUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labMoveUp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labMoveUp.Location = new System.Drawing.Point(292, 334);
            this.labMoveUp.Name = "labMoveUp";
            this.labMoveUp.Size = new System.Drawing.Size(75, 23);
            this.labMoveUp.TabIndex = 19;
            this.labMoveUp.Text = "Move Up";
            this.labMoveUp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labMoveUp.Click += new System.EventHandler(this.SchemaButtonClick);
            this.labMoveUp.MouseEnter += new System.EventHandler(this.labBttnMouseEnter);
            this.labMoveUp.MouseLeave += new System.EventHandler(this.labBtnMouseLeave);
            // 
            // labRemove
            // 
            this.labRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labRemove.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labRemove.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labRemove.Location = new System.Drawing.Point(292, 304);
            this.labRemove.Name = "labRemove";
            this.labRemove.Size = new System.Drawing.Size(75, 23);
            this.labRemove.TabIndex = 18;
            this.labRemove.Text = "Remove";
            this.labRemove.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labRemove.Click += new System.EventHandler(this.SchemaButtonClick);
            this.labRemove.MouseEnter += new System.EventHandler(this.labBttnMouseEnter);
            this.labRemove.MouseLeave += new System.EventHandler(this.labBtnMouseLeave);
            // 
            // labRename
            // 
            this.labRename.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labRename.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labRename.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labRename.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labRename.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labRename.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labRename.Location = new System.Drawing.Point(292, 274);
            this.labRename.Name = "labRename";
            this.labRename.Size = new System.Drawing.Size(75, 23);
            this.labRename.TabIndex = 17;
            this.labRename.Text = "Rename";
            this.labRename.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labRename.Click += new System.EventHandler(this.SchemaButtonClick);
            this.labRename.MouseEnter += new System.EventHandler(this.labBttnMouseEnter);
            this.labRename.MouseLeave += new System.EventHandler(this.labBtnMouseLeave);
            // 
            // labAdd
            // 
            this.labAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labAdd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labAdd.Location = new System.Drawing.Point(292, 244);
            this.labAdd.Name = "labAdd";
            this.labAdd.Size = new System.Drawing.Size(75, 23);
            this.labAdd.TabIndex = 16;
            this.labAdd.Text = "Add";
            this.labAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labAdd.Click += new System.EventHandler(this.SchemaButtonClick);
            this.labAdd.MouseEnter += new System.EventHandler(this.labBttnMouseEnter);
            this.labAdd.MouseLeave += new System.EventHandler(this.labBtnMouseLeave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label3.Location = new System.Drawing.Point(40, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Schemas";
            // 
            // lbSchemas
            // 
            this.lbSchemas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSchemas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lbSchemas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbSchemas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbSchemas.FormattingEnabled = true;
            this.lbSchemas.Location = new System.Drawing.Point(43, 244);
            this.lbSchemas.Name = "lbSchemas";
            this.lbSchemas.Size = new System.Drawing.Size(243, 143);
            this.lbSchemas.TabIndex = 9;
            // 
            // labChangeModelName
            // 
            this.labChangeModelName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labChangeModelName.AutoSize = true;
            this.labChangeModelName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labChangeModelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labChangeModelName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labChangeModelName.Location = new System.Drawing.Point(347, 60);
            this.labChangeModelName.Name = "labChangeModelName";
            this.labChangeModelName.Size = new System.Drawing.Size(23, 17);
            this.labChangeModelName.TabIndex = 8;
            this.labChangeModelName.Text = "...";
            this.labChangeModelName.Click += new System.EventHandler(this.labChangeModelNameClick);
            // 
            // labModelName
            // 
            this.labModelName.AutoSize = true;
            this.labModelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labModelName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labModelName.Location = new System.Drawing.Point(40, 81);
            this.labModelName.Name = "labModelName";
            this.labModelName.Size = new System.Drawing.Size(65, 13);
            this.labModelName.TabIndex = 7;
            this.labModelName.Text = "Model name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label2.Location = new System.Drawing.Point(40, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Model name:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(211)))), ((int)(((byte)(182)))));
            this.panel1.Location = new System.Drawing.Point(43, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(324, 2);
            this.panel1.TabIndex = 5;
            // 
            // labUmlModelPath
            // 
            this.labUmlModelPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labUmlModelPath.AutoSize = true;
            this.labUmlModelPath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labUmlModelPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labUmlModelPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labUmlModelPath.Location = new System.Drawing.Point(40, 567);
            this.labUmlModelPath.Name = "labUmlModelPath";
            this.labUmlModelPath.Size = new System.Drawing.Size(85, 13);
            this.labUmlModelPath.TabIndex = 4;
            this.labUmlModelPath.Text = "UML model path";
            this.labUmlModelPath.Click += new System.EventHandler(this.ModelPathClick);
            // 
            // labUmlModelLoaded
            // 
            this.labUmlModelLoaded.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labUmlModelLoaded.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labUmlModelLoaded.ImageIndex = 0;
            this.labUmlModelLoaded.ImageList = this.ilStatus;
            this.labUmlModelLoaded.Location = new System.Drawing.Point(351, 110);
            this.labUmlModelLoaded.Name = "labUmlModelLoaded";
            this.labUmlModelLoaded.Size = new System.Drawing.Size(16, 16);
            this.labUmlModelLoaded.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Location = new System.Drawing.Point(40, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "UML Model loaded";
            // 
            // labColapse
            // 
            this.labColapse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labColapse.AutoSize = true;
            this.labColapse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labColapse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labColapse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labColapse.Location = new System.Drawing.Point(389, 9);
            this.labColapse.Name = "labColapse";
            this.labColapse.Size = new System.Drawing.Size(21, 13);
            this.labColapse.TabIndex = 1;
            this.labColapse.Text = "<<";
            this.labColapse.Click += new System.EventHandler(this.ColapseButtonClick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1264, 827);
            this.Controls.Add(this.scMain);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Text = "Database Designer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMainClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormKeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveModelDialog;
        private System.Windows.Forms.OpenFileDialog openModelDialog;
        private System.Windows.Forms.SaveFileDialog saveDatabaseScriptDialog;
        private System.Windows.Forms.OpenFileDialog loadUmlDialog;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem miFile;
        private System.Windows.Forms.ToolStripMenuItem miNew;
        private System.Windows.Forms.ToolStripMenuItem miOpen;
        private System.Windows.Forms.ToolStripMenuItem miSave;
        private System.Windows.Forms.ToolStripMenuItem miSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem miExit;
        private System.Windows.Forms.ToolStripMenuItem miImport;
        private System.Windows.Forms.ToolStripMenuItem miLoadUml;
        private System.Windows.Forms.ToolStripMenuItem miScript;
        private System.Windows.Forms.ToolStripMenuItem miSqlScript;
        private System.Windows.Forms.ToolStripMenuItem miHibMappings;
        private System.Windows.Forms.ToolStripMenuItem miClasses;
        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.Label labColapse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList ilStatus;
        private System.Windows.Forms.Label labUmlModelPath;
        private System.Windows.Forms.Label labUmlModelLoaded;
        private System.Windows.Forms.ToolTip tTip;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labChangeModelName;
        private System.Windows.Forms.Label labModelName;
        private System.Windows.Forms.ListBox lbSchemas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labAdd;
        private System.Windows.Forms.Label labMoveDown;
        private System.Windows.Forms.Label labMoveUp;
        private System.Windows.Forms.Label labRemove;
        private System.Windows.Forms.Label labRename;
        private System.Windows.Forms.Label labScriptGenerated;
        private System.Windows.Forms.Label labModelSaved;
        private System.Windows.Forms.Label labModelCreated;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labScriptPathCaption;
        private System.Windows.Forms.Label labScriptPath;
        private System.Windows.Forms.Label labModelPathCaption;
        private System.Windows.Forms.Label labModelPath;
        private System.Windows.Forms.Label labUmlModelPathCaption;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labIndexCount;
        private System.Windows.Forms.Label labColumnCount;
        private System.Windows.Forms.Label labTableCount;
        private System.Windows.Forms.Label labSchemaCount;
    }
}

