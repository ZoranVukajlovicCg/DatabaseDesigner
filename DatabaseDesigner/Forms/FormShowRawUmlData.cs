// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FormShowRawUmlData.cs" company="N/A">
//   Zoran Vukajlovic
// </copyright>
// <summary>
//   Defines the FormShowRawUmlData type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DatabaseDesigner.Forms
{
    using System.Text;
    using System.Windows.Forms;

    using DatabaseDesigner.Entities;

    /// <summary>
    /// The form show raw UML data.
    /// </summary>
    public partial class FormShowRawUmlData : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FormShowRawUmlData"/> class.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        public FormShowRawUmlData(UmlDataModel model)
        {
            this.InitializeComponent();
            this.ShowData(model);
        }

        /// <summary>
        /// The show data.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        private void ShowData(UmlDataModel model)
        {
            this.Text += string.Format(@" - {0}", model.Name);
            
            var sb = new StringBuilder();

            sb.AppendLine(string.Format(@"Model Name: {0}", model.Name));
            sb.AppendLine(string.Empty);

            foreach (var table in model.UmlTables)
            {
                sb.AppendLine(@"-------------------------------------------------------------------");
                sb.AppendLine(string.Format(@"Order: {0}", table.Order));
                sb.AppendLine(string.Format(@"Schema: {0}", table.Schema));
                sb.AppendLine(string.Format(@"Name: {0}", table.Name));
                sb.AppendLine(@"----");
                foreach (var column in table.UmlColumns)
                {
                    sb.AppendLine(string.Format(@"Name: {0}", column.Name));
                    sb.AppendLine(string.Format(@"Data Type: {0}", column.DataType));
                    sb.AppendLine(string.Format(@"Is Primary Key: {0}", column.IsPrimaryKey));
                    sb.AppendLine(string.Format(@"Is Autoincrement: {0}", column.IsAutoincrement));
                    sb.AppendLine(string.Format(@"Is Nullable: {0}", column.IsNullable));
                    sb.AppendLine(string.Format(@"Is System: {0}", column.IsSystem));
                    sb.AppendLine(string.Format(@"Is reference: {0}", column.IsReference));
                    sb.AppendLine(string.Format(@"Is constraint: {0}", column.IsConstraint));
                    sb.AppendLine(string.Format(@"Reference Schema: {0}", column.ReferenceSchema));
                    sb.AppendLine(string.Format(@"Reference Table: {0}", column.ReferenceTable));
                    sb.AppendLine(string.Format(@"Reference Column: {0}", column.ReferenceColumn));
                    sb.AppendLine(string.Format(@"Parse Error: {0}", column.ParseError));
                    sb.AppendLine(string.Empty);
                }

                sb.AppendLine(@"----");

                foreach (var index in table.UmlIndexes)
                {
                    sb.AppendLine(string.Format(@"Index: {0}", index.Name));
                }
            }

            sb.AppendLine(@"-------------------------------------------------------------------");

            this.tbRaw.Text = sb.ToString();
        }
    }
}
