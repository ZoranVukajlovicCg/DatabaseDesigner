// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Scripts.cs" company="N/A">
//   Zoran Vukajlovic
// </copyright>
// <summary>
//   The scripts.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DatabaseDesigner.Clases
{
    public static class Scripts
    {
        public const string Line = 

@"--------------------------------------------------------------------------------";

        public const string Comment =

@"--";
        
        public const string HeaderText =

@"--  Auto-generated script by Database Designer 1.0     (c) Zoran Vukajlovic 2016";

        public const string CreateSchema =

@"IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = @dbSchema) 
    EXEC('CREATE SCHEMA [' + @dbSchema + '] AUTHORIZATION [dbo]');
GO";
        
        public const string CreateTable =

@"IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = @tableFqName AND TABLE_SCHEMA = @dbSchema)
BEGIN
    EXECUTE [util].[spCreateTableWireframe]
        @scriptName = @currentScriptName,
        @schema = @dbSchema,
        @name = @tableFqName,
	    @entityName = @entityClassName,
	    @parentTableId = @parentId,
	    @referencePattern = @refPattern,
	    @addToRepository = @toRepository,
	    @entityIconName = @iconName,
	    @isUpdatableFromExternalSource = @fromExternal,
	    @isAccessControlEnabled = @acEnabled,
	    @isAccessScopeEnabled = @asEnabled,
	    @id = @currentTableId
END
";

        public const string CreateColumn =

@"	EXECUTE [util].[spAddColumnToWireframe] 
        @scriptName = @currentScriptName,
		@tableSchema = @dbSchema, 
        @tableName = @tableFqName, 
        @columnName = @colName, 
        @columnDisplayName = @colDisplayName, 
		@dbType = @type, 
        @dbLength =  @length, 
        @dbPrecision = @precision, 
        @isNullable = @nullable, 
        @defaultValue = @defaultVal,
		@isRequired = @required, 
        @isSearchable = @searchable, 
        @isFullTextSearch = @fullTextSearch,  
        @isSystem = @system,
		@isReference = @ref, 
        @referenceTableSchema = @refSchema,
        @referenceTableName = @refTable, 
        @referenceField = @refField, 
        @tableRepository = @refRepository,
		@fromInformation = @formInfo,
        @translationKeyField = @tkfield,
		@addToRepository = @toRepository
";

        public const string DeclareSchema = 

@"DECLARE @dbSchema nvarchar(32)";

        public const string DeclareVariables =

@"DECLARE @currentTableId int
DECLARE @currentScriptName nvarchar(max)
DECLARE @tableFqName nvarchar(64)
DECLARE @tableShortName nvarchar(64)
DECLARE @entityClassName nvarchar(64)
DECLARE @parentId int
DECLARE @refPattern nvarchar(128)
DECLARE @toRepository bit
DECLARE @iconName nvarchar(64)
DECLARE @fromExternal bit
DECLARE @acEnabled bit
DECLARE @asEnabled bit
DECLARE @colName nvarchar(64)
DECLARE @colDisplayName nvarchar(64)
DECLARE @colOrder int
DECLARE @type nvarchar(64)
DECLARE @length int
DECLARE @precision nvarchar(12)
DECLARE @nullable bit
DECLARE @defaultVal nvarchar(max)
DECLARE @required bit
DECLARE @searchable bit
DECLARE @fullTextSearch bit
DECLARE @system bit
DECLARE @ref bit
DECLARE @refSchema nvarchar(64)
DECLARE @refTable nvarchar(64)
DECLARE @refField nvarchar(64)
DECLARE @tkField nvarchar(64)
DECLARE @refRepository nvarchar(64)
DECLARE @formInfo nvarchar(max)
DECLARE @isUniqueIndex bit
DECLARE @indexColumn1 nvarchar(64)
DECLARE @indexColumn2 nvarchar(64)
";

        /// <summary>
        /// The check if table exists.
        /// </summary>
        public const string CheckIfTableExists =

@"IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = @tableFqName AND TABLE_SCHEMA = @dbSchema)
BEGIN
";

        /// <summary>
        /// The create single index.
        /// </summary>
        public const string CreateSingleIndex = 

@"	EXECUTE [util].[spCreateSingleColumnIndex] 
        @tableSchema = @dbSchema, 
        @tableName = @tableFqName, 
        @columnName = @indexColumn1, 
        @isUnique = @isUniqueIndex
";

        /// <summary>
        /// The create double index.
        /// </summary>
        public const string CreateDoubleIndex =

@"	EXECUTE [util].[spCreateDoubleColumnIndex] 
        @tableSchema = @dbSchema, 
        @tableName = @tableFqName, 
        @columnName1 = @indexColumn1, 
        @columnName2 = @indexColumn2, 
        @isUnique = @isUniqueIndex
";
    }
}
