using DatabaseDesigner.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDesigner.Clases
{
    internal class PostgreSqlScript
    {
        private DataModel currentModel;
        private bool addToRepository;

        public PostgreSqlScript(DataModel model, bool toRepository)
        {
            this.currentModel = model;
            this.addToRepository = toRepository;
        }

        public void GenerateScript(string filename)
        {
            var template = new PostgreSqlTemplate();
            var file = new StreamWriter(filename);
            string script = string.Empty;
            bool toRepository = false;

            file.WriteLine(template.Line);
            file.WriteLine(template.Comment);
            file.WriteLine(template.HeaderText);
            file.WriteLine(@"--  File:   {0}", Path.GetFileName(filename));
            file.WriteLine(@"--  Time:   {0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            file.WriteLine(@"--  Target: PostgreSQL");
            file.WriteLine(template.Line);
            file.WriteLine(string.Empty);

            // start block
            file.Write(template.BlockStart);
            file.WriteLine(string.Empty);

            // go through all schemas
            foreach (var schema in this.currentModel.Schemas)
            {
                file.WriteLine(template.Comment);
                file.WriteLine(String.Format(@"-- Schema: {0}", schema.Name));
                file.WriteLine(template.Comment);
                file.WriteLine(string.Empty);
                script = template.CreateSchema.Replace("{schema}", schema.Name.ToLower());
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

            // end block
            file.Write(template.BlockEnd);
            file.WriteLine(string.Empty);

            file.Close();
        }

        private void ScriptTable(StreamWriter file, Schema schema, Table table, PostgreSqlTemplate template)
        {
            string script = string.Empty;

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
            string tableName = this.GetQualifiedName(table.Name);
            script = template.CreateTable.Replace("{schema}", schema.Name.ToLower()).Replace("{table}", table.Name.ToLower()).Replace("{qualifiedName}", tableName);
            file.Write(script);
            file.Write(this.GetPrimaryKeyColumns(col));
            file.WriteLine(string.Empty);
            string constraint = String.Format("pk_{0}", this.GetShortName(table.Name));
            string pkColumns = string.Empty;
            foreach (var column in col)
            {
                pkColumns += String.Format("{0}, ", this.GetQualifiedName(column.Name));
            }
            pkColumns = pkColumns.Substring(0, pkColumns.Length - 2);
            script = template.PkConstraint.Replace("{constraint}", constraint).Replace("{columnQualified}", pkColumns);
            file.Write("\t\t" + script);
            file.WriteLine(string.Empty);
            file.Write(template.EndIf);
            file.WriteLine(string.Empty);
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

        private void ScriptColumn(StreamWriter file, Column column, Schema schema, Table table, PostgreSqlTemplate template)
        {
            string tableName = this.GetQualifiedName(table.Name);
            string columnName = this.GetQualifiedName(column.Name);
            string dbType = this.GetDBTypeString(column.DbType, column.DbLength, column.DbPrecision);
            string isNull = column.IsNullable ? "NULL" : "NOT NULL";

            // add column if it not exists
            string script = template.AddColumn
                .Replace("{schema}", schema.Name.ToLower())
                .Replace("{table}", table.Name.ToLower())
                .Replace("{column}", column.Name.ToLower())
                .Replace("{tableQualified}", tableName)
                .Replace("{columnQualified}", columnName)
                .Replace("{dbType}", dbType)
                .Replace("{null}", isNull);
            file.Write(script);
            file.WriteLine(string.Empty);
            file.WriteLine(string.Empty);

            // ceate fk constraint if it not exists
            if ((bool)column.IsConstraint)
            {
                string constraint = String.Format(@"FK_{0}_{1}", this.GetShortName(table.Name), this.GetShortName(column.Name)).ToLower();
                string refTableName = this.GetQualifiedName(column.ReferenceTable);
                string refColumnName = this.GetQualifiedName(column.ReferenceField);
                script = template.FkConstraint
                    .Replace("{schema}", schema.Name.ToLower())
                    .Replace("{table}", table.Name.ToLower())
                    .Replace("{constraint}", constraint)
                    .Replace("{tableQualified}", tableName)
                    .Replace("{columnQualified}", columnName)
                    .Replace("{refSchema}", column.ReferenceTableSchema)
                    .Replace("{refTableQualified}", refTableName)
                    .Replace("{refFieldQualified}", refColumnName);
                file.Write(script);
                file.WriteLine(string.Empty);
                file.WriteLine(string.Empty);
            }

        }

        private void ScriptIndex(StreamWriter file, Index index, string schema, string table, PostgreSqlTemplate template)
        {
            string columns = @"(";
            foreach (var col in index.Fields)
            {
                columns += String.Format(@"{0}, ", this.GetQualifiedName(col.Name));
            }
            columns = columns.Substring(0, columns.Length - 2);
            columns += @")";

            string script = template.AddIndex
                .Replace("{schema}", schema)
                .Replace("{index}", index.Name.ToLower())
                .Replace("{unique}", index.IsUnique ? "UNIQUE " : string.Empty)
                .Replace("{tableQualified}", this.GetQualifiedName(table))
                .Replace("{indexColumns}", columns);
            file.Write(script);
            file.WriteLine(string.Empty);
            file.WriteLine(string.Empty);
        }

        private void ScriptRepository(StreamWriter file, PostgreSqlTemplate template)
        {
            string comm = string.Empty;

            file.Write(template.RepositoryStart);
            file.WriteLine(string.Empty);

            foreach(var schema in this.currentModel.Schemas) 
            {
                foreach(var table in schema.Tables)
                {
                    if (this.addToRepository || table.AddToRepository)
                    {
                        comm = template.AddTableToRepository
                            .Replace("{name}", table.Name)
                            .Replace("{namespace}", String.IsNullOrEmpty(table.Namespace) ? "null" : String.Format("'{0}'", table.Namespace))
                            .Replace("{schema}", schema.Name)
                            .Replace("{entityName}", String.IsNullOrEmpty(table.EntityName) ? "null" : String.Format("'{0}'", table.EntityName))
                            .Replace("{displayName}", String.IsNullOrEmpty(table.DisplayName) ? "null" : String.Format("'{0}'", table.DisplayName))
                            .Replace("{parentSchema}", String.IsNullOrEmpty(table.ParentSchema) ? "null" : String.Format("'{0}'", table.ParentSchema))
                            .Replace("{parentName}", String.IsNullOrEmpty(table.ParentTable) ? "null" : String.Format("'{0}'", table.ParentTable))
                            .Replace("{referencePattern}", String.IsNullOrEmpty(table.ReferencePattern) ? "null" : String.Format("'{0}'", table.ReferencePattern))
                            .Replace("{iconName}", String.IsNullOrEmpty(table.EntityIconName) ? "null" : String.Format("'{0}'", table.EntityIconName))
                            .Replace("{isAccessControl}", table.IsAccessControlEnabled ? "true" : "false")
                            .Replace("{isDynamic}", "false");
                        file.Write(comm);
                        //file.WriteLine(string.Empty);
                    }
                    file.Write(template.BeginIfTableExists);
                    foreach (var column in table.Columns.Where(x => !(bool)x.IsPrimaryKey).ToList())
                    {
                        if (this.addToRepository || column.AddToRepository)
                        {
                            comm = template.AddColumnToRepository
                                .Replace("{name}", column.Name)
                                .Replace("{displayName}", String.IsNullOrEmpty(column.DisplayName) ? "null" : String.Format("'{0}'", column.DisplayName))
                                .Replace("{dbType}", column.DbType)
                                .Replace("{dbLength}", column.DbLength.ToString())
                                .Replace("{dbPrecision}", String.IsNullOrEmpty(column.DbPrecision) ? "null" : String.Format("'{0}'", column.DbPrecision))
                                .Replace("{isNullable}", column.IsNullable ? "true" : "false")
                                .Replace("{isReference}", column.IsReference ? "true" : "false")
                                .Replace("{refSchema}", String.IsNullOrEmpty(column.ReferenceTableSchema) ? "null" : String.Format("'{0}'", column.ReferenceTableSchema))
                                .Replace("{refTable}", String.IsNullOrEmpty(column.ReferenceTable) ? "null" : String.Format("'{0}'", column.ReferenceTable))
                                .Replace("{refField}", String.IsNullOrEmpty(column.ReferenceField) ? "null" : String.Format("'{0}'", column.ReferenceField))
                                .Replace("{order}", column.ColumnOrder.ToString())
                                .Replace("{required}", column.IsRequired ? "true" : "false")
                                .Replace("{searchable}", column.IsSearchable ? "true" : "false")
                                .Replace("{fts}", column.IsFullTextSearch ? "true" : "false")
                                .Replace("{system}", column.IsSystem ? "true" : "false")
                                .Replace("{dynamic}", "null")
                                .Replace("{def}", String.IsNullOrEmpty(column.DefaultValue) ? "null" : String.Format("'{0}'", column.DefaultValue));
                            file.Write(comm);
                        }
                    }
                    file.WriteLine("\t" + template.EndIf);
                    //file.WriteLine(string.Empty);
                }
                file.WriteLine("\tEND;");
            }
        }

        public string GetName(string name)
        {
            return name.ToLower();
        }

        public string GetQualifiedName(string name)
        {
            string[] illegalCharacters = { @".", @" " };
            if (illegalCharacters.Any(name.Contains))
            {
                return String.Format("\"{0}\"", name).ToLower();
            }
            return name.ToLower();
        }

        public string GetPrimaryKeyColumns(Column[] columns)
        {
            string text = string.Empty;
            foreach (Column col in columns)
            {
                text += String.Format("\r\n\t\t\t{0} {1} {2},",
                    this.GetQualifiedName(col.Name),
                    (bool)col.IsAutoincrement ? "SERIAL" : this.GetDBTypeString(col.DbType, col.DbLength, col.DbPrecision),
                    col.IsNullable ? @"NULL" : @"NOT NULL");
            }
            return text;
        }

        public string GetShortName(string table)
        {
            if (table.Contains(@"."))
            {
                return table.Split('.')[1];
            }
            if (table.Contains(@" "))
            {
                return table.Replace(@" ", string.Empty);
            }
            return table.ToLower();
        }

        public string GetDBTypeString(string dbType, int length, string precision)
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
                return @"TEXT";
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
