// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FormMain.cs" company="N/A">
//   Zoran Vukajlovic
// </copyright>
// <summary>
//   The form main.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DatabaseDesigner.Forms
{
    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using System.Xml.Serialization;

    using DatabaseDesigner.Clases;
    using DatabaseDesigner.Entities;
    using DatabaseDesigner.Frames;

    public partial class FormMain : Form
    {
        private const string FormBaseHeaderText = "Database Designer";
        private const string DbObjectsScriptPrefix = @"Create Database Objects - ";
        private readonly string currentDirectory;
        private DataModel currentModel;
        private FrameDbObjects frameDbObjects;
        private int currentSplitterDistance;
        private bool leftPanelColapsed;
        private FrameColumns.dlgcUpdateInfoPanelCallback dlgUpdateInfo;
        private BindingSource schemaBindingSource;

        public FormMain()
        {
            this.InitializeComponent();

            this.currentDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            this.CheckDirectories();

            this.currentSplitterDistance = 200;
            this.scMain.Dock = DockStyle.Fill;
            this.scMain.SplitterDistance = currentSplitterDistance;

            this.dlgUpdateInfo = new FrameColumns.dlgcUpdateInfoPanelCallback(UpdateInfoPanel);
            this.currentModel = new DataModel { Name = "Untitled Model", RecreateDataModel = false };
            this.frameDbObjects = new FrameDbObjects(this.currentModel, this.dlgUpdateInfo) { Dock = DockStyle.Fill, Parent = this.scMain.Panel2, Visible = true };

            this.schemaBindingSource = new BindingSource { DataSource = this.currentModel.Schemas };
            this.lbSchemas.DataSource = this.schemaBindingSource;
            this.lbSchemas.DisplayMember = "Name";

            this.SetNewModel();
        }
        private void HeaderCallback()
        {
            this.Text = string.Format(@"{0} - {1}", FormBaseHeaderText, this.currentModel.Name);
            this.frameDbObjects.ResetAllBindings();
        }
        private void CheckDirectories()
        {
            var projectDirectory = this.currentDirectory + @"\Projects";
            var dataModelDirectory = this.currentDirectory + @"\DbModelScripts";

            if (!Directory.Exists(projectDirectory))
            {
                Directory.CreateDirectory(projectDirectory);
            }

            if (!Directory.Exists(dataModelDirectory))
            {
                Directory.CreateDirectory(dataModelDirectory);
            }

            this.openModelDialog.InitialDirectory = projectDirectory;
            this.saveModelDialog.InitialDirectory = projectDirectory;
            this.saveDatabaseScriptDialog.InitialDirectory = dataModelDirectory;
        }
        private void SetNewModel()
        {
            this.Text = FormBaseHeaderText + @" - Untitled Model";

            // set status variables
            AppStatus.UmletModelLoaded = false;
            AppStatus.UmletModelPath = string.Empty;
            AppStatus.ModelCreated = true;
            //AppStatus.ModelLoaded = false;
            AppStatus.ModelPath = string.Empty;
            AppStatus.ScriptGenerated = false;
            AppStatus.ScriptPath = string.Empty;
            AppStatus.ModelSaved = true;

            // update info panel
            this.UpdateInfoPanel();
        }
        private void CheckIfSaved()
        {
            if (AppStatus.ModelSaved)
            {
                return;
            }
            
            if (MessageBox.Show(
                @"Current model is not saved!\r\nSaveNow?",
                @"WARNING",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Save();
            }
        }
        private void GenerateIndexNames()
        {
            foreach (var schema in this.currentModel.Schemas)
            {
                foreach (var table in schema.Tables)
                {
                    foreach (var index in table.Indexes)
                    {
                        index.Name = Util.CreateIndexName(index, table.Name);
                    }
                }
            }
        }
        private void SaveModel(string path)
        {
            var xs = new XmlSerializer(typeof(DataModel));
            TextWriter tw = new StreamWriter(path);
            xs.Serialize(tw, this.currentModel);
            tw.Close();
            AppStatus.ModelSaved = true;
            AppStatus.ModelPath = path;
            this.UpdateInfoPanel();
        }
        private void UpdateInfoPanel()
        {
            // display model name
            labModelName.Text = this.currentModel.Name;
            
            // get status
            labUmlModelLoaded.ImageIndex = Convert.ToInt32(AppStatus.UmletModelLoaded);
            labModelCreated.ImageIndex = Convert.ToInt32(AppStatus.ModelCreated);
            labModelSaved.ImageIndex = Convert.ToInt32(AppStatus.ModelSaved);
            labScriptGenerated.ImageIndex = Convert.ToInt32(AppStatus.ScriptGenerated);

            // get statistic
            labSchemaCount.Text = String.Format(@"Schemas ({0})", this.currentModel.Schemas.Count);
            int tableCount = 0;
            int columnCount = 0;
            int IndexCount = 0;
            foreach (var schema in this.currentModel.Schemas)
            {
                tableCount += schema.Tables.Count;
                foreach (var table in schema.Tables) 
                {
                    columnCount += table.Columns.Count;
                    IndexCount += table.Indexes.Count;
                }
            }
            labTableCount.Text = String.Format(@"Tables ({0})", tableCount);
            labColumnCount.Text = String.Format(@"Columns ({0})", columnCount);
            labIndexCount.Text = String.Format(@"Indexes ({0})", IndexCount);


            // display paths
            labUmlModelPathCaption.Visible = AppStatus.UmletModelLoaded && !String.IsNullOrEmpty(AppStatus.UmletModelPath);
            labUmlModelPath.Visible = AppStatus.UmletModelLoaded && !String.IsNullOrEmpty(AppStatus.UmletModelPath);
            labUmlModelPath.Text = AppStatus.UmletModelPath.Length < 40 ? AppStatus.UmletModelPath : AppStatus.UmletModelPath.Substring(0, 40) + @"...";
            labModelPathCaption.Visible = AppStatus.ModelCreated && !String.IsNullOrEmpty(AppStatus.ModelPath);
            labModelPath.Visible = AppStatus.ModelCreated && !String.IsNullOrEmpty(AppStatus.ModelPath);
            labModelPath.Text = AppStatus.ModelPath.Length < 40 ? AppStatus.ModelPath : AppStatus.ModelPath.Substring(0, 40) + @"...";
            labScriptPathCaption.Visible = AppStatus.ScriptGenerated && !String.IsNullOrEmpty(AppStatus.ScriptPath);
            labScriptPath.Visible = AppStatus.ScriptGenerated && !String.IsNullOrEmpty(AppStatus.ScriptPath);
            labScriptPath.Text = AppStatus.ScriptPath.Length < 40 ? AppStatus.ScriptPath : AppStatus.ScriptPath.Substring(0, 40) + @"...";


            // set full path in tooltip
            tTip.SetToolTip(labUmlModelPath, AppStatus.UmletModelPath);
            tTip.SetToolTip(labModelPath, AppStatus.ModelPath);
            tTip.SetToolTip(labScriptPath, AppStatus.ScriptPath);
            

            this.schemaBindingSource.DataSource = this.currentModel.Schemas;
            this.schemaBindingSource.ResetBindings(false);
        }

        #region Actions

        private void New()
        {
            this.CheckIfSaved();
            this.SetNewModel();
        }

        private void Open()
        {
            this.CheckIfSaved();

            if (this.openModelDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            try
            {
                var xs = new XmlSerializer(typeof(DataModel));
                using (var sr = new StreamReader(this.openModelDialog.FileName))
                {
                    this.currentModel = (DataModel)xs.Deserialize(sr);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.InnerException.ToString(), @"ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // update status variables
            AppStatus.UmletModelLoaded = false;
            AppStatus.UmletModelPath = string.Empty;
            AppStatus.ModelCreated = true;
            //AppStatus.ModelLoaded = true;
            AppStatus.ModelPath = this.openModelDialog.FileName;
            AppStatus.ScriptGenerated = false;
            AppStatus.ScriptPath = string.Empty;
            AppStatus.ModelSaved = true;

            this.Text = FormBaseHeaderText + @" - " + this.currentModel.Name;
            //this.frameModelInfo.ReloadData(this.currentModel);
            this.frameDbObjects.ReloadData(this.currentModel);
            this.UpdateInfoPanel();
            this.frameDbObjects.Focus();
        }

        private void Save()
        {
            if (string.IsNullOrEmpty(AppStatus.ModelPath))
            {
                this.SaveAs();
            }
            else
            {
                this.SaveModel(AppStatus.ModelPath);
            }
        }

        private void SaveAs()
        {
            this.saveModelDialog.FileName = this.currentModel.Name;

            if (this.saveModelDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            this.SaveModel(this.saveModelDialog.FileName);
        }

        private void GenerateScript()
        {
            // get script params
            TargetDb selectedRdbms = TargetDb.MSSQL;
            bool addToRepository = false;

            var f = new FormScriptParams();
            if (f.ShowDialog() == DialogResult.OK)
            {
                selectedRdbms = f.SelectedRdbms;
                addToRepository = f.AddToRepository;
            }
            else
            {
                MessageBox.Show("Script generation aborted!");
                return;
            }

            // open save dialog
            this.saveDatabaseScriptDialog.FileName = FormMain.DbObjectsScriptPrefix + this.currentModel.Name;
            if (this.saveDatabaseScriptDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            // generate script
            switch (selectedRdbms)
            {
                case TargetDb.MSSQL:
                    (new MsSqlScript(this.currentModel, addToRepository)).GenerateScript(this.saveDatabaseScriptDialog.FileName);
                    break;
                case TargetDb.PostgreSQL:
                    (new PostgreSqlScript(this.currentModel, addToRepository)).GenerateScript(this.saveDatabaseScriptDialog.FileName);
                    break;
                default:
                    break;
            }

            //var generator = new ScriptGenerator(this.currentModel, selectedRdbms, addToRepository);
            //generator.GenerateScript(this.saveDatabaseScriptDialog.FileName);
            
            // update status
            AppStatus.ScriptGenerated = true;
            AppStatus.ScriptPath = this.saveDatabaseScriptDialog.FileName;
            this.UpdateInfoPanel();
        }

        private void ApplicationExit()
        {
            this.Close();
        }

        private void LoadUml()
        {
            if (this.loadUmlDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            using (var f = new FormLoadUml(this.loadUmlDialog.FileName))
            {
                if (f.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                if (f.CreateNewModel)
                {
                    this.CheckIfSaved();
                    this.currentModel = f.ImportedModel;
                }
                else
                {
                    Util.UpdateDataModel(f.ImportedModel, this.currentModel);
                }

            }

            // update status variables
            AppStatus.UmletModelLoaded = true;
            AppStatus.UmletModelPath = this.loadUmlDialog.FileName;
            AppStatus.ModelCreated = true;
            AppStatus.ModelPath = string.Empty;
            AppStatus.ScriptGenerated = false;
            AppStatus.ScriptPath = string.Empty;
            AppStatus.ModelSaved = false;

            this.Text = FormBaseHeaderText + @" - " + this.currentModel.Name;
            //this.frameModelInfo.ReloadData(this.currentModel);
            this.UpdateInfoPanel();
            
            this.frameDbObjects.ReloadData(this.currentModel);
            this.frameDbObjects.Focus();
        }

        private void OpenFolder(string path)
        {
            //string folderPath = Path.GetFullPath(Path.GetDirectoryName(path));
            Process.Start("explorer.exe", $"/select, \"{path}\"");
        }

        private void ChangeModelName()
        {
            var f = new FormStringEdit(@"Change model name", this.labModelName.Text);
            //f.Visible = false;
            if (f.ShowDialog() == DialogResult.OK)
            {
                this.labModelName.Text = f.EditedText;
                this.currentModel.Name = f.EditedText;
                this.Text = string.Format(@"{0} - {1}", FormBaseHeaderText, this.currentModel.Name);
            }
        }

        private void AddSchema()
        {
            var f = new FormAddSchema(this.currentModel);
            if (f.Add() != DialogResult.OK)
            {
                return;
            }

            //this.schemaBindingSource.ResetBindings(false);
            AppStatus.ModelSaved = false;
            this.frameDbObjects.ResetAllBindings();
            this.UpdateInfoPanel();
        }
        
        private void RenameSchema()
        {
            if (this.lbSchemas.SelectedIndex < 0 || this.lbSchemas.SelectedIndex > this.lbSchemas.Items.Count - 1)
            {
                return;
            }

            var f = new FormAddSchema(this.currentModel);
            if (f.Edit(this.lbSchemas.SelectedIndex) != DialogResult.OK)
            {
                return;
            }

            //this.schemaBindingSource.ResetBindings(false);
            AppStatus.ModelSaved = false;
            this.frameDbObjects.ResetAllBindings();
            this.UpdateInfoPanel();
        }
        
        private void RemoveSchema()
        {
            if (this.lbSchemas.SelectedIndex < 0 || this.lbSchemas.SelectedIndex > this.lbSchemas.Items.Count - 1)
            {
                return;
            }

            if (MessageBox.Show(@"Removing the selected schema will permanently delete all the tables under the schema.\r\nDo you want to permanently remove selected schema?", @"WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }

            this.currentModel.Schemas.RemoveAt(this.lbSchemas.SelectedIndex);

            //this.schemaBindingSource.ResetBindings(false);
            AppStatus.ModelSaved = false;
            this.frameDbObjects.ResetAllBindings();
            this.UpdateInfoPanel();
        }
        
        private void MoveSchemaUp()
        {
            if (this.lbSchemas.SelectedIndex < 1 || this.lbSchemas.SelectedIndex > this.lbSchemas.Items.Count - 1)
            {
                return;
            }

            var schema = Util.CopySchema(this.currentModel.Schemas[this.lbSchemas.SelectedIndex]);
            this.currentModel.Schemas.RemoveAt(this.lbSchemas.SelectedIndex);
            this.currentModel.Schemas.Insert(this.lbSchemas.SelectedIndex - 1, schema);

            //this.schemaBindingSource.ResetBindings(false);
            AppStatus.ModelSaved = false;
            this.frameDbObjects.ResetAllBindings();
            this.UpdateInfoPanel();

            this.lbSchemas.SelectedIndex--;
        }
        
        private void MoveSchemaDown()
        {
            if (this.lbSchemas.SelectedIndex < 0 || this.lbSchemas.SelectedIndex > this.currentModel.Schemas.Count - 1)
            {
                return;
            }

            if (this.lbSchemas.SelectedIndex > this.currentModel.Schemas.Count - 2)
            {
                return;
            }

            var schema = Util.CopySchema(this.currentModel.Schemas[this.lbSchemas.SelectedIndex]);
            this.currentModel.Schemas.RemoveAt(this.lbSchemas.SelectedIndex);
            this.currentModel.Schemas.Insert(this.lbSchemas.SelectedIndex + 1, schema);

            //this.schemaBindingSource.ResetBindings(false);
            AppStatus.ModelSaved = false;
            this.frameDbObjects.ResetAllBindings();
            this.UpdateInfoPanel();

            this.lbSchemas.SelectedIndex++;
        }
        
        #endregion

        #region Event Handlers

        private void ButtonNewClick(object sender, EventArgs e)
        {
            this.New();
        }
        
        private void ButtonOpenClick(object sender, EventArgs e)
        {
            this.Open();
        }
        
        private void ButtonSaveClick(object sender, EventArgs e)
        {
            this.Save();
        }
        
        private void ButtonSaveAsClick(object sender, EventArgs e)
        {
            this.SaveAs();
        }
        
        private void ButtonLoadUmlClick(object sender, EventArgs e)
        {
            this.LoadUml();
        }

        private void ButtonGenerateClick(object sender, EventArgs e)
        {
            this.GenerateScript();
        }

        private void ButtonCloseClick(object sender, EventArgs e)
        {
            this.ApplicationExit();
        }

        private void GenerateIndexNamesClick(object sender, EventArgs e)
        {
            this.GenerateIndexNames();
        }

        private void FormKeyDown(object sender, KeyEventArgs e)
        {
            if (this.frameDbObjects.Visible)
            {
                this.frameDbObjects.MainFormKeyDown(e);
            }
        }

        private void ColapseButtonClick(object sender, EventArgs e)
        {
            if (this.leftPanelColapsed)
            {
                this.scMain.SplitterDistance = this.currentSplitterDistance;
                this.labColapse.Text = "<<";
                this.leftPanelColapsed = false;
            }
            else
            {
                this.currentSplitterDistance = this.scMain.SplitterDistance;
                this.labColapse.Text = ">>";
                this.scMain.SplitterDistance = 32;
                this.leftPanelColapsed = true;
            }
        }

        private void Panel1Paint(object sender, PaintEventArgs e)
        {
            string myText = "Project Info";

            FontFamily fontFamily = new FontFamily("Verdana");
            Font font = new Font(
            fontFamily,
               10,
               FontStyle.Bold,
               GraphicsUnit.Point);
            
            StringFormat stringFormat = new StringFormat();
            SolidBrush solidBrush = new SolidBrush(Color.FromArgb(244,244,244));

            Point point = new Point(40, 10);

            if (this.leftPanelColapsed)
            {
                point.X = 8;
                point.Y = 40;
                stringFormat.FormatFlags = StringFormatFlags.DirectionVertical;
            }

            e.Graphics.DrawString(myText, font, solidBrush, point, stringFormat);
        }

        private void ModelPathClick(object sender, EventArgs e)
        {
            switch ((sender as Control).Name)
            {
                case "labModelPath":
                    if (!String.IsNullOrEmpty(AppStatus.ModelPath))
                    {
                        this.OpenFolder(AppStatus.ModelPath);
                    }
                    break;
                case "labUmlModelPath":
                    if (!String.IsNullOrEmpty(AppStatus.UmletModelPath))
                    {
                        this.OpenFolder(AppStatus.UmletModelPath);
                    }
                    break;
                case "labScriptPath":
                    if (!String.IsNullOrEmpty(AppStatus.ScriptPath))
                    {
                        this.OpenFolder(AppStatus.ScriptPath);
                    }
                    break;
                default:
                    break;
            }
        }

        private void labChangeModelNameClick(object sender, EventArgs e)
        {
            this.ChangeModelName();
        }

        private void labBttnMouseEnter(object sender, EventArgs e)
        {
            (sender as Label).BackColor = Color.FromArgb(170, 211, 182);
            (sender as Label).ForeColor = Color.FromArgb(64, 64, 64);
        }

        private void labBtnMouseLeave(object sender, EventArgs e)
        {
            (sender as Label).BackColor = Color.FromArgb(64, 64, 64);
            (sender as Label).ForeColor = Color.FromArgb(224, 224, 224);
        }

        private void SchemaButtonClick(object sender, EventArgs e)
        {
            switch ((sender as Control).Name)
            {
                case "labAdd":
                    this.AddSchema();
                    break;
                case "labRename":
                    this.RenameSchema();
                    break;
                case "labRemove":
                    this.RemoveSchema();
                    break;
                case "labMoveUp":
                    this.MoveSchemaUp();
                    break;
                case "labMoveDown":
                    this.MoveSchemaDown();
                    break;
                default:
                    break;
            }
        }

        private void FormMainClosing(object sender, FormClosingEventArgs e)
        {
            this.CheckIfSaved();
        }

        #endregion
    }
}
