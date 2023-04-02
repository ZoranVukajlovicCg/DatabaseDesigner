using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseDesigner.Forms
{
    using System.Text.RegularExpressions;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.XPath;

    using DatabaseDesigner.Clases;

    public partial class FormTest : Form
    {
        public FormTest()
        {
            InitializeComponent();
        }

        private void LoadUml()
        {
            if (this.openFile.ShowDialog() == DialogResult.OK)
            {
                this.Parse(this.openFile.FileName);
            }
        }

        private void Parse(string path)
        {
            var model = UmletXmlParser.ParseUmletXml(path);

            if (model == null)
            {
                return;
            }

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
                    sb.AppendLine(string.Format(@"Is System: {0}", column.IsSystem));
                    sb.AppendLine(string.Format(@"Is reference: {0}", column.IsReference));
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
            
            this.tb.Text = sb.ToString();
        }

        private void ParseUmletXml(string path)
        {
            var doc = new XmlDocument();
            doc.Load(path);

            XmlNodeList elements = doc.SelectNodes("/diagram/element");

            if (elements == null)
            {
                return;
            }

            StringBuilder builder = new StringBuilder();

            foreach (XmlNode element in elements)
            {
                var id = element.SelectSingleNode("id");
                if (id == null)
                {
                    continue;
                }

                if (id.InnerText != @"UMLClass")
                {
                    continue;
                }

                var content = element.SelectSingleNode("panel_attributes");
                if (content == null)
                {
                    continue;
                }

                var segments = Regex.Split(content.InnerText, "--");

                // reference tables - only one segment - skip
                if (segments.Length < 2)
                {
                    continue;
                }

                if (string.IsNullOrEmpty(segments[0]))
                {
                    continue;
                }

                var tableLines = Regex.Split(segments[0], "\r\n");

                if (tableLines.Length == 0)
                {
                    continue;
                }

                if (string.IsNullOrEmpty(tableLines[0]))
                {
                    continue;
                }

                if (tableLines[0] == @"<<Table>>")
                {
                    var s = tableLines[1].Split('.');

                    builder.AppendLine("TABLES:");
                    builder.AppendLine(string.Format("Schema: {0}", s[0]));
                    if (s.Length == 2)
                    {
                        builder.AppendLine(string.Format("Name: {0}", s[1]));
                    }

                    if (s.Length == 3)
                    {
                        builder.AppendLine(string.Format("Name: {0}.{1}", s[1], s[2]));
                    }

                    var columnLines = Regex.Split(segments[1], "\r\n");

                    if (columnLines.Length == 0)
                    {
                        continue;
                    }

                    builder.AppendLine(@" ");
                    builder.AppendLine("COLUMNS:");

                    foreach (var columnLine in columnLines.Where(columnRaw => !string.IsNullOrEmpty(columnRaw)))
                    {
                        var colData = columnLine.Split(':');
                        if (colData.Length != 2)
                        {
                            builder.AppendLine("ERROR parsing column");
                        }

                        builder.AppendLine(string.Format("Name: {0}", colData[0]));
                        var colProps = colData[1].Trim().Split(' ');

                        if (colProps.Length == 0 || colProps.Length > 2)
                        {
                            builder.AppendLine("ERROR parsing column");
                        }

                        if (!string.IsNullOrEmpty(colProps[0]))
                        {
                            builder.AppendLine(string.Format("Data Type: {0}", colProps[0]));
                        }

                        var isRef = 0;
                        var isPk = 0;
                        var refSchema = string.Empty;
                        var refTable = string.Empty;
                        var refField = string.Empty;

                        if (colProps.Length > 1)
                        {
                            if (!string.IsNullOrEmpty(colProps[1]))
                            {
                                if (colProps[1].Trim().Substring(0, 4) == @"<<PK")
                                {
                                    isPk = 1;
                                }

                                if (colProps[1].Trim().Substring(0, 4) == @"<<FK")
                                {
                                    isRef = 1;
                                    var refComponents = colProps[1].Trim().Split('/');

                                    if (refComponents.Length < 4)
                                    {
                                        builder.AppendLine("ERROR parsing column");
                                        continue;
                                    }

                                    refSchema = refComponents[1];
                                    refTable = refComponents[2];
                                    refField = refComponents[3].Substring(0, refComponents[3].Length - 2);
                                }
                            }
                        }

                        builder.AppendLine(string.Format("Is Primary Key: {0}", isPk));
                        builder.AppendLine(string.Format("Is Reference: {0}", isRef));
                        builder.AppendLine(string.Format("Reference Schema: {0}", refSchema));
                        builder.AppendLine(string.Format("Reference Table: {0}", refTable));
                        builder.AppendLine(string.Format("Reference Column: {0}", refField));

                        builder.AppendLine(@"-------------------------------------------------------------------");
                    }

                    if (segments.Length > 2)
                    {
                        var indexLines = Regex.Split(segments[2], "\r\n");

                        if (indexLines.Length == 0)
                        {
                            continue;
                        }

                        builder.AppendLine(@" ");
                        builder.AppendLine("INDEXES:");

                        foreach (var indexLine in indexLines.Where(indexLine => indexLine.Length > 2).Where(indexLine => indexLine.Substring(0, 2) == @"IX" || indexLine.Substring(0, 2) == @"UX"))
                        {
                            builder.AppendLine(string.Format("Index: {0}", indexLine));
                        }

                    }
                    
                    builder.AppendLine(@" ");
                    builder.AppendLine(@"xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
                    builder.AppendLine(@" ");
                }
            }
            
            this.tb.Text = builder.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.LoadUml();
        }
    }
}
