// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FormLoadUml.cs" company="N/A">
//   Zoran Vukajlovic
// </copyright>
// <summary>
//   Defines the FormLoadUml type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DatabaseDesigner.Forms
{
    using System.Windows.Forms;

    using DatabaseDesigner.Clases;
    using DatabaseDesigner.Entities;

    public partial class FormLoadUml : Form
    {
        private readonly string currentPath;
        private UmlDataModel currentUmlModel;

        public FormLoadUml(string path)
        {
            this.InitializeComponent();
            
            this.currentPath = path;
            this.CreateNewModel = true;
            this.ImportedModel = null;
        }

        public DataModel ImportedModel { get; set; }

        public bool CreateNewModel { get; set; }

        private void LoadUml()
        {
            this.currentUmlModel = UmletXmlParser.ParseUmletXml(this.currentPath);

            if (this.currentUmlModel == null)
            {
                MessageBox.Show(@"Error getting data from the UMLET file!", @"ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            this.Text += string.Format(@" - {0}", this.currentUmlModel.Name);

            var validationReport = string.Empty;
            UmletDataValidator.ValidateModel(this.currentUmlModel, ref validationReport);

            this.tbValidationReport.Text = validationReport;
        }

        private void ViewRawData()
        {
            var f = new FormShowRawUmlData(this.currentUmlModel);
            f.ShowDialog();
        }

        private void Accept()
        {
            this.ImportedModel = UmletDataTransformer.GetDataModelFromUmletData(this.currentUmlModel);

            if (this.ImportedModel == null)
            {
                MessageBox.Show(@"Imported model is null!", @"ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void FormShown(object sender, System.EventArgs e)
        {
            this.LoadUml();
        }

        private void ButtonViewRawDataClick(object sender, System.EventArgs e)
        {
            this.ViewRawData();
        }

        private void ButtonOkClick(object sender, System.EventArgs e)
        {
            this.Accept();
        }

        private void RadioButtonCheckedChanged(object sender, System.EventArgs e)
        {
            this.CreateNewModel = this.rbNew.Checked;
        }
    }
}
