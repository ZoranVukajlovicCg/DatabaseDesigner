// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UmletDataTransformer.cs" company="N/A">
//   Zoran Vukajlovic
// </copyright>
// <summary>
//   Defines the UmletDataTransformer type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DatabaseDesigner.Clases
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text.RegularExpressions;

    using DatabaseDesigner.Entities;

    public static class UmletDataTransformer
    {
        public static DataModel GetDataModelFromUmletData(UmlDataModel umlModel)
        {
            var model = new DataModel { Name = umlModel.Name, RecreateDataModel = false };

            foreach (var umlTable in umlModel.UmlTables)
            {
                // create table object
                var table = GetTableFromUmletData(umlTable);

                // check created table
                if (table == null)
                {
                    continue;
                }

                // select existing or create new schema
                var schema = model.Schemas.Find(s => s.Name == umlTable.Schema);
                if (model.Schemas.IndexOf(schema) == -1)
                {
                    schema = new Schema { Name = umlTable.Schema };
                    model.Schemas.Add(schema);
                }

                // add table to the selected schema
                schema.Tables.Add(table);

                // add columns to the current table
                foreach (var column in umlTable.UmlColumns.Select(GetColumnFromUmletData).Where(column => column != null))
                {
                    table.Columns.Add(column);
                }

                // sort columns
                Util.RecalculateColumnOrder(table);

                // add indexes to the current table
                foreach (var index in umlTable.UmlIndexes.Select(GetIndexFromUmletData).Where(index => index != null))
                {
                    table.Indexes.Add(index);
                }
            }

            return model;
        }

        public static Table GetTableFromUmletData(UmlTable umlTable)
        {
            var tableNameSegments = umlTable.Name.Split('.');

            var entityName = umlTable.Name;

            // get Entity Name
            if (tableNameSegments.Length > 1)
            {
                if (tableNameSegments[0].Length > 1)
                {
                    tableNameSegments[0] = char.ToUpper(tableNameSegments[0][0]).ToString(CultureInfo.InvariantCulture) + tableNameSegments[0].Substring(1);
                }

                entityName = string.Join(string.Empty, tableNameSegments);
            }

            // get Display Name
            string displayName = Regex.Replace(umlTable.Name, "([A-Z])", " $1", RegexOptions.Compiled).Trim();


            return new Table
                {
                    Name = umlTable.Name, 
                    DisplayName = displayName,
                    Order = umlTable.Order, 
                    EntityName = entityName, 
                    ParentSchema = umlTable.ParentSchema,
                    ParentTable = umlTable.ParentTable,
                    IsAccessControlEnabled = false, 
                    AddToRepository = false
                };
        }

        public static Column GetColumnFromUmletData(UmlColumn umlColumn)
        {
            var column = new Column
                {
                    ColumnOrder = -1,
                    Name = umlColumn.Name,
                    //DbType = umlColumn.DataType,
                    IsNullable = (bool)umlColumn.IsNullable,
                    IsRequired = false,
                    IsSearchable = false,
                    IsFullTextSearch = false,
                    IsSystem = umlColumn.IsSystem ?? false,
                    IsPrimaryKey = umlColumn.IsPrimaryKey ?? false,
                    IsAutoincrement = umlColumn.IsAutoincrement ?? false,
                    IsConstraint = umlColumn.IsConstraint ?? false,
                    IsReference = umlColumn.IsReference ?? false,
                    ReferenceTableSchema = umlColumn.ReferenceSchema,
                    ReferenceTable = umlColumn.ReferenceTable,
                    ReferenceField = umlColumn.ReferenceColumn,
                    IsUmletCreated = true,
                    IsUmletUpdated = false,
                    AddToRepository = false,
                    IsDynamic = false
                };

            // set column display name
            column.DisplayName = column.IsSystem ? string.Empty : Regex.Replace(umlColumn.Name, "([A-Z])", " $1", RegexOptions.Compiled).Trim();
            
            SetColumnDbType(column, umlColumn.DataType);

            // determine if colum is searchable
            var searchableDbTypes = new[] { @"char", @"nchar", @"varchar", @"nvarchar", @"text", @"ntext" };
            column.IsSearchable = searchableDbTypes.Any(umlColumn.DataType.Contains);
            column.IsFullTextSearch = searchableDbTypes.Any(umlColumn.DataType.Contains);

            return column;
        }

        public static Index GetIndexFromUmletData(UmlIndex umlIndex)
        {
            var index = new Index { Name = umlIndex.Name, IsUnique = umlIndex.IsUnique};

            for (var i = 0; i < umlIndex.ColumnList.Length; i++)
            {
                index.Fields.Add(new IndexField { Name = umlIndex.ColumnList[i] });
            }

            return index;
        }

        private static void SetColumnDbType(Column column, string umlDataType)
        {
            column.DbType = umlDataType;
            column.DbLength = 0;

            var openParenthesisIndex = umlDataType.IndexOf(@"(", StringComparison.Ordinal);

            if (openParenthesisIndex != -1)
            {
                var type = umlDataType.Substring(0, openParenthesisIndex);
                var parenthesisContent = umlDataType.Substring(
                    openParenthesisIndex,
                    umlDataType.Length - openParenthesisIndex);

                switch (type)
                {
                    case "char":
                        column.DbType = @"char";
                        column.DbLength = parenthesisContent == @"(max)" ? -1 : Convert.ToInt32(parenthesisContent.Substring(1, parenthesisContent.Length - 2));
                        break;

                    case "varchar":
                        column.DbType = @"varchar";
                        column.DbLength = parenthesisContent == @"(max)" ? -1 : Convert.ToInt32(parenthesisContent.Substring(1, parenthesisContent.Length - 2));
                        break;

                    case "nchar":
                        column.DbType = @"nchar";
                        column.DbLength = parenthesisContent == @"(max)" ? -1 : Convert.ToInt32(parenthesisContent.Substring(1, parenthesisContent.Length - 2));
                        break;

                    case "nvarchar":
                        column.DbType = @"nvarchar";
                        column.DbLength = parenthesisContent.ToLower() == @"(max)" ? -1 : Convert.ToInt32(parenthesisContent.Substring(1, parenthesisContent.Length - 2));
                        break;

                    case "decimal":
                        column.DbType = @"decimal";
                        column.DbLength = -1;
                        column.DbPrecision = parenthesisContent.Substring(1, parenthesisContent.Length - 2);
                        break;

                    case "numeric":
                        column.DbType = @"numeric";
                        column.DbLength = -1;
                        column.DbPrecision = parenthesisContent.Substring(1, parenthesisContent.Length - 2);
                        break;
                }
            }
        }
    }
}
