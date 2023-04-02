// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UmletXmlParser.cs" company="N/A">
//   Zoran Vukajlovic
// </copyright>
// <summary>
//   The UML-et xml parser.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DatabaseDesigner.Clases
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net.NetworkInformation;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using System.Xml;

    using DatabaseDesigner.Entities;

    public static class UmletXmlParser
    {
        public static UmlDataModel ParseUmletXml(string path)
        {
            var model = new UmlDataModel { Name = Path.GetFileNameWithoutExtension(path) };
            var doc = new XmlDocument();

            try
            {
                doc.Load(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.ToString(), @"Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            // select all 'element' nodes
            var elements = doc.SelectNodes("/diagram/element");

            // if no elements are found return null reference
            if (elements == null)
            {
                MessageBox.Show(@"Xml file contains no elements.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            // fill the model
            FillUmlModel(model, elements);

            // check the table count
            if (model.UmlTables.Count == 0)
            {
                MessageBox.Show(@"Xml file contains no table models.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            return model;
        }

        private static void FillUmlModel(UmlDataModel model, XmlNodeList elements)
        {
            foreach (var panelAttributes in elements.Cast<XmlNode>().Where(CheckIfClassNode).Select(element => element.SelectSingleNode("panel_attributes")).Where(panelAttributes => panelAttributes != null))
            {
                var segments = Regex.Split(panelAttributes.InnerText, "--");
                var segmentCount = segments.Length;

                // if segment count is less than 2 table is not valid for import
                if (segmentCount < 2)
                {
                    continue;
                }

                // if segment is empty -> continue
                if (string.IsNullOrEmpty(segments[0]))
                {
                    continue;
                }

                // get table data
                var table = GetUmlTable(segments[0]);
                if (table == null)
                {
                    continue;
                }

                model.UmlTables.Add(table);

                // fill table columns
                FillUmlTableColumns(table, segments[1]);

                // check if index segment exists
                if (segments.Length < 3)
                {
                    continue;
                }

                // fill table indexes
                FillUmlTableIndexes(table, segments[2]);
            }

            // sort tables by Order
            model.UmlTables = model.UmlTables.OrderBy(x => x.Order).ToList();
        }

        private static bool CheckIfClassNode(XmlNode node)
        {
            var id = node.SelectSingleNode("id");
            if (id == null)
            {
                return false;
            }

            return id.InnerText == @"UMLClass";
        }

        private static UmlTable GetUmlTable(string segment)
        {
            // check if table segment is empty or null
            if (string.IsNullOrEmpty(segment))
            {
                return null;
            }

            // check if appropriate stereotype exists
            var stereotypes = new[] { @"<<table", @"<<entity" };
            if (!stereotypes.Any(segment.ToLower().Contains))
            {
                return null;
            }

            //trim all blanks in segment
            segment = segment.Trim();

            // get lines in segment
            var tableLines = Regex.Split(segment, Util.GetNewLineDelimiter(segment));

            // exclude empty lines
            List<string> tableLinesList = tableLines.ToList();
            tableLinesList.RemoveAll(x => x == string.Empty);
            tableLines = tableLinesList.ToArray();

            // check if segment contains required minimal number of lines
            if (tableLines.Length < 2)
            {
                return null;
            }

            // find table name name index
            int tableNameIndex = -1;
            for (int i = 0; i < tableLinesList.Count; i++)
            {
                if (!tableLines[i].Contains(@"<<"))
                    tableNameIndex = i;
            }

            // find table stereotype
            int tableStereotypeIndex = -1;
            for (int i = 0; i < tableLinesList.Count; i++)
            {
                if (stereotypes.Any(tableLines[i].Contains))
                    tableStereotypeIndex = i;
            }

            // find parent table index
            int parentStereotypeIndex = -1;
            for (int i = 0; i < tableLinesList.Count; i++)
            {
                if (tableLines[i].Contains(@"<<parent"))
                    parentStereotypeIndex = i;
            }

            // get table stereotype cmponents
            string tableStereotype = tableLines[tableStereotypeIndex].TrimStart('<').TrimEnd('>');
            var ts = tableStereotype.Split(':');

            // get table order
            var tableOrder = -1;
            if (ts.Length > 1)
            {
                tableOrder = Convert.ToInt32(ts[1]);
            }

            // get table data
            var tableData = tableLines[tableNameIndex].Trim().Split('.');

            // check if table data have enough elements
            if (tableData.Length < 2)
            {
                return null;
            }

            // check if table schema exists
            if (string.IsNullOrEmpty(tableData[0]))
            {
                return null;
            }

            // set valid table name (lov factor)
            var tableName = tableData.Length == 3
                                ? string.Format(@"{0}.{1}", tableData[1], tableData[2])
                                : tableData[1];

            // check if table name exists
            if (string.IsNullOrEmpty(tableName))
            {
                return null;
            }

            string parentTable = null;
            string parentSchema = null;
            if (parentStereotypeIndex != -1)
            {
                string parentStereoytpe = tableLines[parentStereotypeIndex].TrimStart('<').TrimEnd('>');
                var parentStereotypeSegments = parentStereoytpe.Split(':');
                if (parentStereotypeSegments.Length == 2)
                {
                    var parentStrings = parentStereotypeSegments[1].Split('.');
                    switch (parentStrings.Length)
                    {
                        case 2:
                            parentSchema = parentStrings[0];
                            parentTable = parentStrings[1];
                            break;
                        default:
                            parentTable = null;
                            break;
                    }
                }
            }

            // return new UmlTable object
            return new UmlTable { Order = tableOrder, Schema = tableData[0], Name = tableName, ParentSchema = parentSchema, ParentTable = parentTable};
        }

        private static void FillUmlTableColumns(UmlTable table, string segment)
        {
            // get all lines in the Columns segment
            var columnLines = Regex.Split(segment, Util.GetNewLineDelimiter(segment));

            // exclude empty lines
            List<string> columnLinesList = columnLines.ToList();
            columnLinesList.RemoveAll(x => x == string.Empty);
            columnLines = columnLinesList.ToArray();


            // if no column lines are found -> return
            if (columnLines.Length == 0)
            {
                return;
            }

            foreach (var col in columnLines.Select(GetUmlColumn).Where(col => col != null))
            {
                table.UmlColumns.Add(col);
            }
        }

        private static void FillUmlTableIndexes(UmlTable table, string segment)
        {
            
            
            var lines = Regex.Split(segment, Util.GetNewLineDelimiter(segment));

            // if there is no data in Index segment
            if (lines.Length == 0)
            {
                return;
            }

            bool isLegacy = false;
            bool isUnique = false;
            var legacyKeywords = new[] { @"IX", @"UX" };
            var uniqueKeywords = new[] { @"UX", @"<<Unique" };
            var indexIndetifiers = new[] { @"IX", @"UX", @"<<" };

            // select the lines that actually contains index data
            List<string> indexLinesList = new List<string>();
            for (int i = 0; i < lines.Length; i++)
            {
                if (indexIndetifiers.Any(lines[i].Contains))
                {
                    indexLinesList.Add(lines[i]);
                }
            }
            string[] indexLines = indexLinesList.ToArray();

            // add all found indexes to the table
            foreach (var indexLine in indexLines)//.Where(indexLine => indexLine.Length > 2).Where(indexLine => indexLine.Substring(0, 2) == @"IX" || indexLine.Substring(0, 2) == @"UX"))
            {
                isLegacy = legacyKeywords.Any(indexLine.Contains);
                isUnique = uniqueKeywords.Any(indexLine.Contains);

                string indexName = isUnique ? @"UX_" + table.Name : @"IX_" + table.Name;
                if (isLegacy)
                {
                    var indexElements = indexLine.Split('_');
                    if (indexElements.Length < 2 || indexElements.Length > 4) 
                    {
                        return;
                    }
                    string[] indexColumns = new string[indexElements.Length-2];
                    for (int i = 0; i < indexElements.Length-2; i++) 
                    {
                        indexColumns[i] = indexElements[i+2];
                        indexName += @"_";
                        indexName += indexColumns[i];
                    }
                    table.UmlIndexes.Add(new UmlIndex {Name = indexName, IsLegacy = isLegacy, IsUnique = isUnique, ColumnList = indexColumns });
                    return;
                }
                else
                {
                    var indexElements = indexLine.Split(':');
                    if (indexElements.Length < 2)
                    {
                        return;
                    }
                    string columns = indexElements[1].TrimStart('<').TrimEnd('>');
                    var indexColumns = columns.Split(',');
                    for (int i = 0; i < indexColumns.Length; i++)
                    {
                        indexColumns[i] = indexColumns[i].Trim();
                        indexName += @"_";
                        indexName += indexColumns[i];
                    }
                    table.UmlIndexes.Add(new UmlIndex {Name = indexName, IsLegacy = isLegacy, IsUnique = isUnique, ColumnList = indexColumns});
                }
            }

            return;
        }

        private static UmlColumn GetUmlColumn(string columnRawData)
        {
            var col = new UmlColumn();

            var colData = columnRawData.Split(':');

            // if column string is invalid (no : between column name and the rest of colum info) add error report
            if (colData.Length != 2)
            {
                col.ParseError = string.Format(@"Column raw string is invalid. Wrong segment count ({0}).", colData.Length);
                return null;
            }

            // check if column name exists
            if (string.IsNullOrEmpty(colData[0]))
            {
                col.ParseError = @"Column name is empty";
                return col;
            }

            // set column name
            col.Name = colData[0];

            // check if colum properties are empty
            if (string.IsNullOrEmpty(colData[1]))
            {
                col.ParseError = @"Column properties are empty";
                return col;
            }

            // get col properties strings and remove empty fields
            var colProps = colData[1].Trim().Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToArray();

            // check if the colum properties exists
            if (colProps.Length == 0 || colProps.Length > 2)
            {
                col.ParseError = string.Format(@"Column property string is invalid. Wrong property count ({0}).", colProps.Length);
                return col;
            }

            // check if the column data type exists
            if (string.IsNullOrEmpty(colProps[0]))
            {
                col.ParseError = @"Column data type is empty";
                return col;
            }

            // set column data type
            col.DataType = colProps[0];
            
            // check column prototypes
            col.IsPrimaryKey = false;
            col.IsReference = false;
            col.IsSystem = false;
            col.IsNullable = true;

            // if no additional properties exist -> return
            if (colProps.Length == 1)
            {
                return col;
            }

            if (string.IsNullOrEmpty(colProps[1]))
            {
                return col;
            }

            // get column stereotypes
            string stereotypes = colProps[1].Trim();

            // get additional column properties
            var idStereotypes = new[] { @"<<PK", @"<<identity", @"<<auto" };
            var refStereotypes = new[] { @"<<FK", @"<<ref", @"<<con"};

            col.IsPrimaryKey = idStereotypes.Any(stereotypes.Contains);
            col.IsAutoincrement = stereotypes.Contains(@"<<auto>>");
            col.IsReference = refStereotypes.Any(stereotypes.Contains);
            col.IsConstraint = stereotypes.Contains(@"<<con");
            col.IsSystem = stereotypes.Contains(@"<<sys>>");
            col.IsNullable = !col.IsPrimaryKey & !stereotypes.Contains(@"<<non>>");

            if (!(bool)col.IsReference)
            {
                return col;
            }

            if ((bool)col.IsConstraint)
            {
                int i = 1;
                i++;
            }

            // extract reference stereotype
            int start = stereotypes.IndexOf(@"FK");

            if (start == -1)
            {
                start = stereotypes.IndexOf(@"ref");
            }

            if (start == -1)
            {
                start = stereotypes.IndexOf(@"con");
            }

            if (start == -1)
            {
                col.IsReference = false;
                return col;
            }

            int end = stereotypes.IndexOf(@">>");

            if (end == -1)
            {
                col.IsReference = false;
                return col;
            }

            string reference = stereotypes.Substring(start, end - start);

            //get reference data
            var referenceData = reference.Split('/');

            // check if reference data is valid
            if (referenceData.Length == 4)
            {
                col.ReferenceSchema = referenceData[1];
                col.ReferenceTable = referenceData[2];
                col.ReferenceColumn = referenceData[3];
            }
            else
            {
                col.ParseError = string.Format(@"Column reference property count is invalid ({0}).", referenceData.Length);
            }

            return col;
        }
    }
}
