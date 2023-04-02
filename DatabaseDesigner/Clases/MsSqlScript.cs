using DatabaseDesigner.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDesigner.Clases
{
    internal class MsSqlScript
    {
        private DataModel currentModel;
        private bool addToRepository;

        public MsSqlScript(DataModel model, bool toRepository)
        {
            this.currentModel = model;
            this.addToRepository = toRepository;
        }

        public void GenerateScript(string filename)
        {
            var template = new MsSqlTemplate();
            var file = new StreamWriter(filename);
            string script = string.Empty;
            bool toRepository = false;

            file.WriteLine(template.Line);
            file.WriteLine(template.Comment);
            file.WriteLine(template.HeaderText);
            file.WriteLine(@"--  File:   {0}", Path.GetFileName(filename));
            file.WriteLine(@"--  Time:   {0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            file.WriteLine(@"--  Target: MSSQL");
            file.WriteLine(template.Line);
            file.WriteLine(string.Empty);

            // go through all schemas
            foreach (var schema in this.currentModel.Schemas)
            {
                file.WriteLine(template.Comment);
                file.WriteLine(String.Format(@"-- Schema: {0}", schema.Name));
                file.WriteLine(template.Comment);
                file.WriteLine(string.Empty);
                script = template.CreateSchema.Replace("{schema}", schema.Name);
                file.Write(script);
                file.WriteLine(string.Empty);

                // go through all tables
                foreach (var table in schema.Tables)
                {
                    this.ScriptTable(file, schema, table, template);
                    toRepository = toRepository || table.AddToRepository || this.addToRepository;
                }
            }

            if (toRepository)
            {
                this.ScriptRepository(file, template);
            }

            file.Close();
        }

        private void ScriptTable(StreamWriter file, Schema schema, Table table, MsSqlTemplate template)
        {
            string script = string.Empty;

            // header
            file.WriteLine(template.Line);
            file.WriteLine(@"--  {0:000}. {1}", table.Order, table.Name);
            file.WriteLine(template.Line);

            // select id columns
            var col = table.Columns.Where(x => (bool)x.IsPrimaryKey).ToArray();
            if (col.Length == 0)
            {
                return;
            }

            // script CREATE TABLE with all elements
            script = template.CreateTable.Replace("{schema}", schema.Name).Replace("{table}", table.Name).Replace("{qualifiedName}", table.Name);
            file.Write(script);
            file.Write(this.GetPrimaryKeyColumns(col));
            file.WriteLine(string.Empty);
            string constraint = String.Format("PK_{0}", this.GetShortName(table.Name));
            string pkColumns = string.Empty;
            foreach (var column in col)
            {
                pkColumns += String.Format("[{0}] ASC, ", column.Name);
            }
            pkColumns = pkColumns.Substring(0, pkColumns.Length - 2);
            script = template.PkConstraint.Replace("{constraint}", constraint).Replace("{columnQualified}", pkColumns);
            file.Write("\t\t" + script);
            file.WriteLine(string.Empty);
            file.WriteLine(template.End);
            file.WriteLine(template.Go);
            file.WriteLine(string.Empty);

            // script rest of the columns
            foreach (var column in table.Columns.Where(x => !(bool)x.IsPrimaryKey).ToList())
            {
                this.ScriptColumn(file, column, schema, table, template);
            }

            // script indexes
            foreach (var index in table.Indexes)
            {
                this.ScriptIndex(file, index, schema.Name, table.Name, template);
            }
        }

        private void ScriptColumn(StreamWriter file, Column column, Schema schema, Table table, MsSqlTemplate template)
        {
            string dbType = this.GetDBTypeString(column.DbType, column.DbLength, column.DbPrecision);
            string isNull = column.IsNullable ? "NULL" : "NOT NULL";
            
            // add column if it not exists
            string script = template.AddColumn
                .Replace("{schema}", schema.Name)
                .Replace("{table}", table.Name)
                .Replace("{column}", column.Name)
                .Replace("{tableQualified}", table.Name)
                .Replace("{columnQualified}", column.Name)
                .Replace("{dbType}", dbType)
                .Replace("{null}", isNull);
            file.Write(script);
            file.WriteLine(string.Empty);

            // ceate fk constraint if it not exists
            if ((bool)column.IsConstraint)
            {
                string constraint = String.Format(@"FK_{0}_{1}", this.GetShortName(table.Name), this.GetShortName(column.Name));
                script = template.FkConstraint
                    .Replace("{schema}", schema.Name)
                    .Replace("{table}", table.Name)
                    .Replace("{constraint}", constraint)
                    .Replace("{tableQualified}", table.Name)
                    .Replace("{columnQualified}",column.Name)
                    .Replace("{refSchema}", column.ReferenceTableSchema)
                    .Replace("{refTableQualified}", column.ReferenceTable)
                    .Replace("{refFieldQualified}", column.ReferenceField);
                file.Write(script);
                file.WriteLine(string.Empty);
            }
        }

        private void ScriptIndex(StreamWriter file, Index index, string schema, string table, MsSqlTemplate template)
        {
            string columns = @"(";
            foreach (var col in index.Fields)
            {
                columns += String.Format(@"[{0}], ", col.Name);
            }
            columns = columns.Substring(0, columns.Length - 2);
            columns += @")";

            string script = template.AddIndex
                .Replace("{schema}", schema)
                .Replace("{table}", table)
                .Replace("{index}", index.Name)
                .Replace("{unique}", index.IsUnique ? "UNIQUE " : string.Empty)
                .Replace("{tableQualified}", table)
                .Replace("{indexColumns}", columns);
            file.Write(script);
            file.WriteLine(string.Empty);
        }

        private void ScriptRepository(StreamWriter file, MsSqlTemplate template)
        {
            string comm = string.Empty;

            file.Write(template.RepositoryStart);
            file.WriteLine(string.Empty);

            foreach (var schema in this.currentModel.Schemas)
            {
                foreach (var table in schema.Tables)
                {
                    if (this.addToRepository || table.AddToRepository)
                    {
                        comm = template.AddTableToRepository
                            .Replace("{name}", String.IsNullOrEmpty(table.Name) ? "null" : String.Format("'{0}'", table.Name))
                            .Replace("{namespace}", String.IsNullOrEmpty(table.Namespace) ? "null" : String.Format("'{0}'", table.Namespace))
                            .Replace("{schema}", String.IsNullOrEmpty(schema.Name) ? "null" : String.Format("'{0}'", schema.Name))
                            .Replace("{entityName}", String.IsNullOrEmpty(table.EntityName) ? "null" : String.Format("'{0}'", table.EntityName))
                            .Replace("{displayName}", String.IsNullOrEmpty(table.DisplayName) ? "null" : String.Format("'{0}'", table.DisplayName))
                            .Replace("{parentSchema}", String.IsNullOrEmpty(table.ParentSchema) ? "null" : String.Format("'{0}'", table.ParentSchema))
                            .Replace("{parentName}", String.IsNullOrEmpty(table.ParentTable) ? "null" : String.Format("'{0}'", table.ParentTable))
                            .Replace("{referencePattern}", String.IsNullOrEmpty(table.ReferencePattern) ? "null" : String.Format("'{0}'", table.ReferencePattern))
                            .Replace("{iconName}", String.IsNullOrEmpty(table.EntityIconName) ? "null" : String.Format("'{0}'", table.EntityIconName))
                            .Replace("{isAccessControl}", Convert.ToInt16(table.IsAccessControlEnabled).ToString())
                            .Replace("{isDynamic}", "false");
                        file.Write(comm);
                    }
                    file.Write(template.BeginIfTableExists);
                    foreach (var column in table.Columns.Where(x => !(bool)x.IsPrimaryKey).ToList())
                    {
                        if (this.addToRepository || column.AddToRepository)
                        {
                            comm = template.AddColumnToRepository
                                .Replace("{name}", String.IsNullOrEmpty(column.Name) ? "null" : String.Format("'{0}'", column.Name))
                                .Replace("{displayName}", String.IsNullOrEmpty(column.DisplayName) ? "null" : String.Format("'{0}'", column.DisplayName))
                                .Replace("{dbType}", String.IsNullOrEmpty(column.DbType) ? "null" : String.Format("'{0}'", column.DbType))
                                .Replace("{dbLength}", column.DbLength.ToString())
                                .Replace("{dbPrecision}", String.IsNullOrEmpty(column.DbPrecision) ? "null" : String.Format("'{0}'", column.DbPrecision))
                                .Replace("{isNullable}", Convert.ToInt16(column.IsNullable).ToString())
                                .Replace("{isReference}", Convert.ToInt16(column.IsReference).ToString())
                                .Replace("{refSchema}", String.IsNullOrEmpty(column.ReferenceTableSchema) ? "null" : String.Format("'{0}'", column.ReferenceTableSchema))
                                .Replace("{refTable}", String.IsNullOrEmpty(column.ReferenceTable) ? "null" : String.Format("'{0}'", column.ReferenceTable))
                                .Replace("{refField}", String.IsNullOrEmpty(column.ReferenceField) ? "null" : String.Format("'{0}'", column.ReferenceField))
                                .Replace("{order}", column.ColumnOrder.ToString())
                                .Replace("{required}", Convert.ToInt16(column.IsRequired).ToString())
                                .Replace("{searchable}", Convert.ToInt16(column.IsSearchable).ToString())
                                .Replace("{fts}", Convert.ToInt16(column.IsFullTextSearch).ToString())
                                .Replace("{system}", Convert.ToInt16(column.IsSystem).ToString())
                                .Replace("{dynamic}", "null")
                                .Replace("{def}", String.IsNullOrEmpty(column.DefaultValue) ? "null" : String.Format("'{0}'", column.DefaultValue));
                            file.Write(comm);
                        }
                    }
                    file.WriteLine(template.End);
                }
            }
            file.WriteLine(template.Go);
        }

        private string GetPrimaryKeyColumns(Column[] columns)
        {
            string text = string.Empty;

            foreach (Column col in columns)
            {
                text += String.Format("\r\n\t\t[{0}] {1}{2} {3},",
                            col.Name,
                            this.GetDBTypeString(col.DbType, col.DbLength, col.DbPrecision),
                            (bool)col.IsAutoincrement ? @" IDENTITY(1,1)" : string.Empty,
                            col.IsNullable ? @"NULL" : @"NOT NULL");

            }
            return text;
        }

        private string GetShortName(string table)
        {
            if (table.Contains(@"."))
            {
                return table.Split('.')[1];
            }
            if (table.Contains(@" "))
            {
                return table.Replace(@" ", string.Empty);
            }
            return table;
        }

        private string GetDBTypeString(string dbType, int length, string precision)
        {
            if (String.IsNullOrEmpty(dbType))
            {
                return string.Empty;
            }

            if (length == 0 && String.IsNullOrEmpty(precision))
            {
                return dbType.ToUpper();
            }

            string ret = string.Empty;
            if (length == -1)
            {
                return String.Format(@"{0}(max)", dbType.ToUpper());
            }

            if (length > 0)
            {
                return String.Format(@"{0}({1})", dbType.ToUpper(), length);
            }

            if (!String.IsNullOrEmpty(precision))
            {
                return String.Format(@"{0}({1})", dbType, precision).ToUpper();
            }

            return string.Empty;
        }

    }
}

