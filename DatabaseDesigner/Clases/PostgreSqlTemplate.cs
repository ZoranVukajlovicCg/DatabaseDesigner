using DatabaseDesigner.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDesigner.Clases
{
    internal class PostgreSqlTemplate
    {
        public string Line { get; }
        public string Comment { get; }
        public string HeaderText { get; }
        public string CreateSchema { get; }
        public string CreateTable { get; }
        public string EndIf { get; }
        public string PkConstraint { get; }
        public string AddColumn { get; }
        public string FkConstraint { get; }
        public string AddIndex { get; }
        public string BlockStart { get; }
        public string BlockEnd { get; }
        public string RepositoryStart { get; }
        public string AddTableToRepository { get; }
        public string BeginIfTableExists { get; } 
        public string AddColumnToRepository { get; }

        public PostgreSqlTemplate()
        {
            this.Line =
                @"---------------------------------------------------------------------------------";
            this.Comment =
                @"--";
            this.HeaderText =
                @"--  Auto-generated script by Database Designer 2.0 (c) Zoran Vukajlovic 2016-2023";
            this.CreateSchema =
                "\tIF NOT EXISTS(SELECT SCHEMA_NAME FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = '{schema}')\r\n\t\tTHEN\r\n\t\t\tCREATE SCHEMA {schema};\r\n\t\tEND IF;";
            this.CreateTable =
                "\tIF NOT EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = '{schema}' AND TABLE_NAME = '{table}')\r\n\tTHEN\r\n\t\tCREATE TABLE {schema}.{qualifiedName} (";
            this.EndIf =
                "\tEND IF;";
            this.PkConstraint =
                "\tCONSTRAINT {constraint} PRIMARY KEY ({columnQualified}));";
            this.AddColumn =
                "\tIF NOT EXISTS(SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA = '{schema}' AND TABLE_NAME = '{table}' AND COLUMN_NAME = '{column}')\r\n\tTHEN\r\n\t\tALTER TABLE {schema}.{tableQualified} ADD {columnQualified} {dbType} {null};\r\n\tEND IF;";
            this.FkConstraint =
                "\tIF NOT EXISTS(SELECT CONSTRAINT_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE TABLE_SCHEMA = '{schema}' AND TABLE_NAME = '{table}' AND CONSTRAINT_NAME = '{constraint}')\r\n\tTHEN\r\n\t\tALTER TABLE {schema}.{tableQualified} ADD CONSTRAINT {constraint} FOREIGN KEY ({columnQualified}) REFERENCES {refSchema}.{refTableQualified}({refFieldQualified});\r\n\tEND IF;";
            this.AddIndex =
                "\tCREATE {unique}INDEX IF NOT EXISTS {index} ON {schema}.{tableQualified} {indexColumns};";
            this.BlockStart =
                "DO $$\r\nBEGIN";
            this.BlockEnd =
                "END $$";
            this.RepositoryStart =
                "\tDECLARE tableid BIGINT;\r\n\tBEGIN";
            this.AddTableToRepository =
                "\t\tCALL rep.spaddtable('{name}', {namespace}, '{schema}', {entityName}, {displayName}, {parentSchema}, {parentName}, {referencePattern}, {iconName}, {isAccessControl}, {isDynamic}, tableid); \r\n";
            this.BeginIfTableExists =
                "\t\tIF tableid IS NOT NULL\r\n\t\tTHEN\r\n";
            this.AddColumnToRepository =
                "\t\t\tCALL rep.spaddcolumn(tableid, '{name}', {displayName}, '{dbType}', {dbLength}, {dbPrecision}, {isNullable}, {isReference}, {refSchema}, {refTable}, {refField}, {order}, {required}, {searchable}, {fts}, {system}, {dynamic}, {def});\r\n";
        }
    }
}
