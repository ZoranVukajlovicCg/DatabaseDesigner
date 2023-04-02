// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScriptGenerator.cs" company="N/A">
//   Zoran Vukajlovic
// </copyright>
// <summary>
//   Defines the ScriptGenerator type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DatabaseDesigner.Clases
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using DatabaseDesigner.Entities;

    public class ScriptGenerator
    {
        private DataModel currentModel;
        private TargetDb targetDb;
        private bool addToRepository;

        public ScriptGenerator(DataModel model, TargetDb target, bool toRepository)
        {
            this.currentModel = model;
            this.targetDb = target;
            this.addToRepository = toRepository;
        }

        public void GenerateScript(string filename)
        {
            ScriptTemplate template = new ScriptTemplate(this.targetDb);
            
            var file = new StreamWriter(filename);
            file.WriteLine(template.Line);
            file.WriteLine(template.Comment);
            file.WriteLine(template.HeaderText);
            file.WriteLine(@"--  File:   {0}", Path.GetFileName(filename));
            file.WriteLine(@"--  Time:   {0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            file.WriteLine(@"--  Target: {0}", this.targetDb.ToString());
            file.WriteLine(template.Line);
            file.WriteLine(string.Empty);

            //var tplt = new MsSqlTemplate();
            //string s = tplt.CreateSchema.Replace(@"{schema}", "rep");
            //file.Write(s);
            //file.Close();
            //return;


            string leadingTab = string.Empty;
            if (this.targetDb == TargetDb.PostgreSQL)
            {
                file.WriteLine(@"DO $$");
                file.WriteLine(@"BEGIN");
                leadingTab = "\t";
            }

            // go through all schemas
            foreach (var schema in this.currentModel.Schemas)
            {
                file.WriteLine(template.Comment);
                file.WriteLine(String.Format(@"-- Schema: {0}", schema.Name));
                file.WriteLine(template.Comment);
                file.WriteLine(template.Comment);

                string schemaName = template.GetDbObjectName(schema.Name);
                file.WriteLine(leadingTab + template.GetSchemaCheck(schemaName));
                file.WriteLine(leadingTab + template.GetIfCompaudBegining());
                string line = this.targetDb == TargetDb.MSSQL ? String.Format("\tEXEC('CREATE SCHEMA {0}')", template.GetQualifiedDbObjectName(schemaName)) : String.Format("\tCREATE SCHEMA {0};", template.GetQualifiedDbObjectName(schemaName));
                file.WriteLine(leadingTab + line);
                file.WriteLine(leadingTab + template.GetIfCompaudEnding());
                if (this.targetDb == TargetDb.MSSQL)
                {
                    file.WriteLine(leadingTab + @"GO");
                }
                file.WriteLine(leadingTab + template.Comment);

                foreach (var table in schema.Tables)
                {
                    this.ScriptTable(file, schema, table, template, leadingTab);
                }

                if (this.targetDb == TargetDb.PostgreSQL)
                {
                    file.WriteLine(@"END $$");
                }
            }
            file.Close();
        }

        private void ScriptTable(StreamWriter file, Schema schema, Table table, ScriptTemplate template, string leadingTab)
        {
            // header
            file.WriteLine(Scripts.Line);
            file.WriteLine(@"--  {0:000}. {1}", table.Order, table.Name);
            file.WriteLine(Scripts.Line);

            // select id columns
            var col = table.Columns.Where(x => (bool)x.IsPrimaryKey).ToArray();
            if (col.Length == 0)
            {
                return;
            }

            // script CREATE TABLE with all elements

            // get proper names
            string tableName = template.GetDbObjectName(table.Name);
            string tableQualifiedName = template.GetQualifiedDbObjectName(tableName);

            file.WriteLine(leadingTab + template.GetTableCheck(schema.Name, tableName));
            file.WriteLine(leadingTab + template.GetIfCompaudBegining());
            string line = string.Empty;
            file.WriteLine(leadingTab + String.Format("\tCREATE TABLE {0}.{1} (", schema.Name, tableQualifiedName));
            file.WriteLine(leadingTab + "\t\t" + template.GetPrimaryKeyColumns(col));
            line = template.GetPrimaryKeyString(tableName, col) + ")";
            line = this.targetDb == TargetDb.MSSQL ? line : line + @";";
            file.WriteLine(leadingTab + "\t\t" + line);
            file.WriteLine(leadingTab + template.GetIfCompaudEnding());
            if (this.targetDb == TargetDb.MSSQL)
            {
                file.WriteLine(leadingTab + @"GO");
            }

            // script columns
            foreach (var column in table.Columns.Where(x => !(bool)x.IsPrimaryKey).ToList())
            {
                this.ScriptColumn(file, column, schema, table, template, leadingTab);
            }

            // script indexes
            foreach (var index in table.Indexes)
            {
                this.ScriptIndex(file, index, schema.Name, table.Name, template, leadingTab);
            }
        }

        private void ScriptColumn(StreamWriter file, Column column, Schema schema, Table table, ScriptTemplate template, string leadingTab)
        {
            string tableName = template.GetDbObjectName(table.Name);
            string tableQualifiedName = template.GetQualifiedDbObjectName(tableName);
            string columnName = template.GetDbObjectName(column.Name);
            string columnQualifiedName = template.GetQualifiedDbObjectName(columnName);

            file.WriteLine(leadingTab + template.GetColumnCheck(schema.Name, tableName, columnName));
            file.WriteLine(leadingTab + template.GetIfCompaudBegining());
            string script = String.Format("\tALTER TABLE {0}.{1} ADD {2} {3} {4}",
                        schema.Name,
                        tableQualifiedName,
                        columnQualifiedName,
                        template.GetDBTypeString(column.DbType, column.DbLength, column.DbPrecision),
                        column.IsNullable ? @"NULL" : @"NOT NULL");
            script = this.targetDb == TargetDb.MSSQL ? script : script + @";";
            file.WriteLine(leadingTab + script);
            file.WriteLine(leadingTab + template.GetIfCompaudEnding());
            if (this.targetDb == TargetDb.MSSQL)
            {
                file.WriteLine(leadingTab + @"GO");
            }

            file.WriteLine(template.Comment);

            // set constraints
            if ((bool)column.IsConstraint)
            {
                string foreignKeyConstraintName = template.GetForeignKeyName(template.GetShortTableName(tableName), columnName);
                file.WriteLine(leadingTab + template.GetConstraintCheck(schema.Name, tableName, foreignKeyConstraintName));
                file.WriteLine(leadingTab + template.GetIfCompaudBegining());
                script = String.Format("\tALTER TABLE {0}.{1} ADD CONSTRAINT {2} FOREIGN KEY ({3}) REFERENCES {4}({5})",
                    schema.Name,
                    tableQualifiedName,
                    foreignKeyConstraintName,
                    columnQualifiedName,
                    column.ReferenceTableSchema + @"." + template.GetQualifiedDbObjectName(template.GetDbObjectName(column.ReferenceTable)),
                    template.GetQualifiedDbObjectName(template.GetDbObjectName(column.ReferenceField)));
                script = this.targetDb == TargetDb.MSSQL ? script : script + @";";
                file.WriteLine(leadingTab + script);
                file.WriteLine(leadingTab + template.GetIfCompaudEnding());
                if (this.targetDb == TargetDb.MSSQL)
                {
                    file.WriteLine(leadingTab + @"GO");
                }
                file.WriteLine(template.Comment);
            }

            // set variables
            //f.WriteLine("\t" + @"SET @colName = '{0}'", c.Name);

            //if (string.IsNullOrEmpty(c.DisplayName))
            //{
            //    f.WriteLine("\t" + @"SET @colDisplayName = NULL");
            //}
            //else
            //{
            //    f.WriteLine("\t" + @"SET @colDisplayName = '{0}'", c.DisplayName);
            //}

            //f.WriteLine("\t" + @"SET @colOrder = {0}", c.ColumnOrder);

            //if (string.IsNullOrEmpty(c.DbType))
            //{
            //    f.WriteLine("\t" + @"SET @type = NULL");
            //}
            //else
            //{
            //    f.WriteLine("\t" + @"SET @type = '{0}'", c.DbType);
            //}

            //f.WriteLine("\t" + @"SET @length = {0}", c.DbLength);

            //if (string.IsNullOrEmpty(c.DbPrecision))
            //{
            //    f.WriteLine("\t" + @"SET @precision = NULL");
            //}
            //else
            //{
            //    f.WriteLine("\t" + @"SET @precision = '{0}'", c.DbPrecision);
            //}

            //if (string.IsNullOrEmpty(c.DefaultValue))
            //{
            //    f.WriteLine("\t" + @"SET @defaultVal = NULL");
            //}
            //else
            //{
            //    f.WriteLine("\t" + @"SET @defaultVal = '{0}'", c.DefaultValue);
            //}

            //if (string.IsNullOrEmpty(c.ReferenceTableSchema))
            //{
            //    f.WriteLine("\t" + @"SET @refSchema = NULL");
            //}
            //else
            //{
            //    f.WriteLine("\t" + @"SET @refSchema = '{0}'", c.ReferenceTableSchema);
            //}

            //if (string.IsNullOrEmpty(c.ReferenceTable))
            //{
            //    f.WriteLine("\t" + @"SET @refTable = NULL");
            //}
            //else
            //{
            //    f.WriteLine("\t" + @"SET @refTable = '{0}'", c.ReferenceTable);
            //}

            //if (string.IsNullOrEmpty(c.ReferenceField))
            //{
            //    f.WriteLine("\t" + @"SET @refField = NULL");
            //}
            //else
            //{
            //    f.WriteLine("\t" + @"SET @refField = '{0}'", c.ReferenceField);
            //}

            ////if (string.IsNullOrEmpty(c.TableRepository))
            ////{
            ////    f.WriteLine("\t" + @"SET @refRepository = NULL");
            ////}
            ////else
            ////{
            ////    f.WriteLine("\t" + @"SET @refRepository = '{0}'", c.TableRepository);
            ////}

            ////if (string.IsNullOrEmpty(c.FormInformation))
            ////{
            ////    f.WriteLine("\t" + @"SET @formInfo = NULL");
            ////}
            ////else
            ////{
            ////    f.WriteLine("\t" + @"SET @formInfo = '{0}'", c.FormInformation);
            ////}

            ////if (string.IsNullOrEmpty(c.TranslationKeyField))
            ////{
            ////    f.WriteLine("\t" + @"SET @tkfield = NULL");
            ////}
            ////else
            ////{
            ////    f.WriteLine("\t" + @"SET @tkfield = '{0}'", c.TranslationKeyField);
            ////}

            //f.WriteLine("\t" + @"SET @nullable = {0}", Convert.ToInt32(c.IsNullable));
            //f.WriteLine("\t" + @"SET @required = {0}", Convert.ToInt32(c.IsRequired));
            //f.WriteLine("\t" + @"SET @searchable = {0}", Convert.ToInt32(c.IsSearchable));
            //f.WriteLine("\t" + @"SET @fullTextSearch = {0}", Convert.ToInt32(c.IsFullTextSearch));
            //f.WriteLine("\t" + @"SET @system = {0}", Convert.ToInt32(c.IsSystem));
            //f.WriteLine("\t" + @"SET @ref = {0}", Convert.ToInt32(c.IsSystem));
            //f.WriteLine("\t" + @"SET @toRepository = {0}", Convert.ToInt32(c.AddToRepository));

            //// create column
            //f.Write(Scripts.CreateColumn);
            //f.WriteLine(string.Empty);
        }

        private void ScriptIndex(StreamWriter file, Index index, string schema, string table, ScriptTemplate template, string leadingTab)
        {
            string tableName = template.GetDbObjectName(table);
            string tableQualifiedName = template.GetQualifiedDbObjectName(tableName);
            string indexName = template.GetDbObjectName(index.Name);
            string columns = @"(";
            foreach (var col in index.Fields)
            {
                columns += String.Format(@"{0}, ", template.GetQualifiedDbObjectName(template.GetDbObjectName(col.Name)));
            }
            columns = columns.Substring(0, columns.Length - 2);
            columns += @")";

            if (this.targetDb == TargetDb.PostgreSQL)
            {
                string line = String.Format("CREATE {0}INDEX IF NOT EXISTS {1} ON {2} {3};",
                    index.IsUnique ? "UNIQUE " : string.Empty,
                    indexName,
                    schema + "." + tableQualifiedName,
                    columns);
                file.WriteLine(leadingTab + line);
            }
            else
            {
                file.WriteLine(leadingTab + template.GetIndexCheck(schema, tableName, indexName));
                file.WriteLine(leadingTab + template.GetIfCompaudBegining());
                file.WriteLine(leadingTab + String.Format("\tCREATE {0}INDEX {1} ON {2} {3};",
                    index.IsUnique ? "UNIQUE " : string.Empty,
                    indexName,
                    schema + "." + tableQualifiedName,
                    columns));
                file.WriteLine(leadingTab + template.GetIfCompaudEnding());
                if (this.targetDb == TargetDb.MSSQL)
                {
                    file.WriteLine(leadingTab + @"GO");
                }
            }
            file.WriteLine(template.Comment);


            //CREATE INDEX IF NOT EXISTS index_name ON table_name(column_name);




            //// check if index is defined
            //switch (i.Fields.Count)
            //{
            //    case 0:
            //        return; // no index fields found

            //    case 1:
            //        this.SetSingleFieldIndex(f, i);
            //        break;

            //    case 2:
            //        this.SetDoubleFieldIndex(f, i);
            //        break;

            //    default:
            //        f.WriteLine("\t" + @"-- WARNING: Indexes with more than two fields are not supported");
            //        break;
            //}
        }
    }
}
