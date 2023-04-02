using DatabaseDesigner.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DatabaseDesigner.Clases
{
    internal class ScriptTemplate
    {
        private TargetDb targetDb;
        public string Line { get; }
        public string Comment { get; }
        public string HeaderText { get; }

        public ScriptTemplate(TargetDb target)
        {
            this.targetDb = target;
            this.Line =
                @"---------------------------------------------------------------------------------";
            this.Comment =
                @"--";
            this.HeaderText =
                @"--  Auto-generated script by Database Designer 2.0 (c) Zoran Vukajlovic 2016-2023";


        }

        public string GetSchemaCheck(string schema)
        {
            return String.Format(@"IF NOT EXISTS(SELECT SCHEMA_NAME FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = '{0}')", schema);
        }

        public string GetTableCheck(string schema, string table)
        {
            return String.Format(@"IF NOT EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = '{0}' AND TABLE_NAME = '{1}')", schema, table);
        }

        public string GetColumnCheck(string schema, string table, string column)
        {
            return String.Format(@"IF NOT EXISTS(SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA = '{0}' AND TABLE_NAME = '{1}' AND COLUMN_NAME = '{2}')", schema, table, column);
        }

        public string GetIndexCheck(string schema, string table, string index)
        {
            return String.Format(@"IF NOT EXISTS(SELECT CONSTRAINT_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE TABLE_SCHEMA = '{0}' AND TABLE_NAME = '{1}' AND CONSTRAINT_NAME = '{2}')", schema, table, index);
        }

        public string GetConstraintCheck(string schema, string table, string constraint)
        {
            return String.Format(
                @"IF NOT EXISTS(SELECT CONSTRAINT_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE TABLE_SCHEMA = '{0}' AND TABLE_NAME = '{1}' AND CONSTRAINT_NAME = '{2}')", 
                schema, 
                table, 
                constraint);
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
                switch (targetDb)
                {
                    case TargetDb.MSSQL: ret = String.Format(@"{0}(max)", dbType.ToUpper()); break;
                    case TargetDb.PostgreSQL: ret = @"TEXT"; break;
                    //case TargetDb.MySQL: ret = @"LONGTEXT"; break;
                    default: break;
                }
                return ret.ToUpper();
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

        public string GetPrimaryKeyString(string table, Column[] columns)
        {
            if (String.IsNullOrEmpty(table))
            {
                return string.Empty;
            }

            // get short table name
            string tableName = this.GetShortTableName(table);
            string s = string.Empty;
            string name = String.Format("PK_{0}", this.GetShortTableName(table));
            name = this.targetDb == TargetDb.PostgreSQL ? name.ToLower() : name;

            switch (this.targetDb)
            {
                case TargetDb.MSSQL:
                    s = String.Format(@"CONSTRAINT {0} PRIMARY KEY CLUSTERED (", name);
                    foreach (Column col in columns)
                    {
                        s += String.Format(@"{0} ASC,", this.GetQualifiedDbObjectName(this.GetDbObjectName(col.Name)));
                    }
                    s = s.Substring(0, s.Length - 1);
                    s += @")";
                    break;
                default:
                    s = String.Format(@"CONSTRAINT {0} PRIMARY KEY (", name);
                    foreach (Column col in columns)
                    {
                        s += String.Format(@"{0},", this.GetQualifiedDbObjectName(this.GetDbObjectName(col.Name)));
                    }
                    s = s.Substring(0, s.Length - 1);
                    s += @")";
                    break;
            }

            // convert to lower for postgresql
            //if (this.targetDb == TargetDb.PostgreSQL)
            //{
            //    s = s.ToLower();
            //}

            return s;
        }

        public string GetForeignKeyName(string table, string column)
        {
            string s = String.Format(@"FK_{0}_{1}", table, column);
            return this.targetDb == TargetDb.PostgreSQL ? s.ToLower() : s;
        }

        public string GetDbObjectName(string name)
        {
            return this.targetDb == TargetDb.PostgreSQL ? name.ToLower() : name;
        }

        public string GetQualifiedDbObjectName(string name)
        {
            string[] illegalCharacters = { @".", @" " };
            if (!illegalCharacters.Any(name.Contains))
            {
                return name;
            }
            string ret = this.targetDb == TargetDb.MSSQL ? String.Format(@"[{0}]", name) : String.Format("\"{0}\"", name);
            return this.targetDb == TargetDb.PostgreSQL ? ret.ToLower() : ret;
        }

        public string GetPrimaryKeyColumns(Column[] columns)
        {
            string text = string.Empty;

            foreach (Column col in columns)
            {
                switch (this.targetDb)
                {
                    case TargetDb.MSSQL:
                        text = String.Format("{0} {1}{2} {3},",
                            this.GetQualifiedDbObjectName(this.GetDbObjectName(col.Name)),
                            col.DbType.ToUpper(),
                            (bool)col.IsAutoincrement ? @" IDENTITY(1,1)" : string.Empty,
                            col.IsNullable ? @"NULL" : @"NOT NULL");
                        break;
                    case TargetDb.PostgreSQL:
                        text = String.Format("{0} {1} {2},",
                            this.GetQualifiedDbObjectName(this.GetDbObjectName(col.Name)),
                            (bool)col.IsAutoincrement ? "SERIAL" : col.DbType.ToUpper(),
                            col.IsNullable ? @"NULL" : @"NOT NULL");
                        break;
                    //case TargetDb.MySQL:
                    //    text = String.Format("{0} {1} {2} {3},",
                    //        this.GetQualifiedDbObjectName(this.GetDbObjectName(col.Name)),
                    //        col.DbType.ToUpper(),
                    //        (bool)col.IsAutoincrement ? @"AUTO_INCREMENT" : string.Empty,
                    //        col.IsNullable ? @"NULL" : @"NOT NULL");
                    //    break;
                    default: break;
                }
            }
            return text;
        }

        public string GetShortTableName(string table)
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

        public string GetIfCompaudBegining()
        {
            return this.targetDb == TargetDb.MSSQL ? @"BEGIN" : @"THEN";
        }

        public string GetIfCompaudEnding() 
        {
            return this.targetDb == TargetDb.MSSQL ? @"END" : @"END IF;";
        }

    }
}
