using DatabaseDesigner.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseDesigner.Clases
{
    internal class MsSqlTemplate
    {
        public string Line { get; }
        public string Comment { get; }
        public string HeaderText { get; }
        public string CreateSchema { get; }
        public string CreateTable { get; }
        public string End { get; }
        public string Go { get; }
        public string PkConstraint { get; }
        public string AddColumn { get; }
        public string FkConstraint { get; }
        public string AddIndex { get; }
        public string RepositoryStart { get; }
        public string AddTableToRepository { get; }
        public string BeginIfTableExists { get; }
        public string AddColumnToRepository { get; }

        public MsSqlTemplate()
        {
            this.Line =
                @"---------------------------------------------------------------------------------";
            this.Comment =
                @"--";
            this.HeaderText =
                @"--  Auto-generated script by Database Designer 2.0 (c) Zoran Vukajlovic 2016-2023";
            this.CreateSchema =
                "IF NOT EXISTS(SELECT SCHEMA_NAME FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = '{schema}')\r\nBEGIN\r\n\tEXEC('CREATE SCHEMA {schema}')\r\nEND\r\nGO";
            this.CreateTable =
                "IF NOT EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = '{schema}' AND TABLE_NAME = '{table}')\r\nBEGIN\r\n\tCREATE TABLE [{schema}].[{qualifiedName}] (";
            this.End =
                "END";
            this.Go = "GO";
            this.PkConstraint =
                "CONSTRAINT {constraint} PRIMARY KEY CLUSTERED ({columnQualified}))";
            this.AddColumn = 
                "IF NOT EXISTS(SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA = '{schema}' AND TABLE_NAME = '{table}' AND COLUMN_NAME = '{column}')\r\nBEGIN\r\n\tALTER TABLE [{schema}].[{tableQualified}] ADD [{columnQualified}] {dbType} {null}\r\nEND\r\nGO";
            this.FkConstraint =
                "IF NOT EXISTS(SELECT CONSTRAINT_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE TABLE_SCHEMA = '{schema}' AND TABLE_NAME = '{table}' AND CONSTRAINT_NAME = '{constraint}')\r\nBEGIN\r\n\tALTER TABLE [{schema}].[{tableQualified}] ADD CONSTRAINT [{constraint}] FOREIGN KEY ([{columnQualified}]) REFERENCES [{refSchema}].[{refTableQualified}]([{refFieldQualified}])\r\nEND\r\nGO";
            this.AddIndex =
                "IF NOT EXISTS(SELECT * FROM SYS.INDEXES WHERE [name] = '{index}' AND [object_id] = OBJECT_ID('[{schema}].[{table}]'))\r\nBEGIN\r\n\tCREATE {unique}INDEX [{index}] ON [{schema}].[{tableQualified}] {indexColumns};\r\nEND\r\nGO";
            this.RepositoryStart =
                "DECLARE @tabId int";
            this.AddTableToRepository =
                "EXECUTE [rep].[spAddTable]\r\n" +
                "\t@tableName = {name},\r\n" +
                "\t@tableNamespace = {namespace},\r\n" +
                "\t@tableSchema = {schema},\r\n" +
                "\t@entityName = {entityName},\r\n" +
                "\t@displayName = {displayName},\r\n" +
                "\t@parentSchema = {parentSchema},\r\n" +
                "\t@parentName = {parentName},\r\n" +
                "\t@referencePattern = {referencePattern},\r\n" +
                "\t@iconName = {iconName},\r\n" +
                "\t@isAccessControlEnabled = {isAccessControl},\r\n" +
                "\t@isDynamic = {isDynamic},\r\n" +
                "\t@tableid = @tabId OUTPUT;\r\n";
            this.BeginIfTableExists =
                "IF @tabId IS NOT NULL\r\nBEGIN\r\n";
            this.AddColumnToRepository =
                "\tEXECUTE [rep].[spAddColumn]\r\n" +
                "\t\t@tableId = @tabId,\r\n" +
                "\t\t@columnName = {name},\r\n" +
                "\t\t@displayName = {displayName},\r\n" +
                "\t\t@dbType = {dbType},\r\n" +
                "\t\t@dbLength = {dbLength},\r\n" +
                "\t\t@dbPrecision = {dbPrecision},\r\n" +
                "\t\t@isNullable = {isNullable},\r\n" +
                "\t\t@isReference = {isReference},\r\n" +
                "\t\t@referenceSchema = {refSchema},\r\n" +
                "\t\t@referenceTable = {refTable},\r\n" +
                "\t\t@referenceField = {refField},\r\n" +
                "\t\t@propertyOrder = {order},\r\n" +
                "\t\t@isRequired = {required},\r\n" +
                "\t\t@isSearchable = {searchable},\r\n" +
                "\t\t@isFullTextSearch = {fts},\r\n" +
                "\t\t@isSystem = {system},\r\n" +
                "\t\t@isDynamic = {dynamic},\r\n" +
                "\t\t@defaultValue = {def};\r\n";
        }
    }
}
