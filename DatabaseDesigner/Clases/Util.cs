// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Util.cs" company="N/A">
//   Zoran Vukajlovic
// </copyright>
// <summary>
//   The utils.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DatabaseDesigner.Clases
{
    using System;
    using System.Deployment.Application;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Xml.Serialization;
    using Arda.xControls;
    using DatabaseDesigner.Entities;
    using XControlsNT;

    public enum FormMode
    {
        Add = 1,
        Edit = 2
    }

    public enum TargetDb
    {
        MSSQL = 1,
        PostgreSQL = 2,
    }

    public class Util
    {
        #region Objects Update

        public static void UpdateDataModel(DataModel source, DataModel destination)
        {
            // update destination name
            destination.Name = source.Name;

            // delete all existing schemas not found in source schemas
            destination.Schemas.RemoveAll(d => source.Schemas.All(s => s.Name != d.Name));

            // loop through existing schemas and update tables
            // myObjectList.Where(X => idList.Contains(X.id)).ToList()
            foreach (var sourceSchema in source.Schemas.Where(s => destination.Schemas.Any(d => d.Name == s.Name)).ToList())
            {
                var destinationSchema = destination.Schemas.First(d => d.Name == sourceSchema.Name);
                UpdateSchema(sourceSchema, destinationSchema);
            }

            // add all new schemas to existing model
            var l = source.Schemas.Where(s => destination.Schemas.All(d => d.Name != s.Name)).ToList();
            destination.Schemas.AddRange(l);
        }

        public static void UpdateSchema(Schema source, Schema destination)
        {
            // delete all existing tables not found in source tables for the curent schema
            destination.Tables.RemoveAll(d => source.Tables.All(s => s.Name != d.Name));

            // loop through existing tables and update columns
            foreach (var sourceTable in source.Tables.Where(s => destination.Tables.Any(d => d.Name == s.Name)))
            {
                var destinationTable = destination.Tables.First(d => d.Name == sourceTable.Name);
                
                // update table Order
                destinationTable.Order = sourceTable.Order;
                
                // update table columns
                UpdateTable(sourceTable, destinationTable);
            }

            // add all new tables to existing current schema
            destination.Tables.AddRange(source.Tables.Where(s => destination.Tables.All(d => d.Name != s.Name)));

            // sort tables
            destination.Tables = destination.Tables.OrderBy(t => t.Order).ToList();
        }

        public static void UpdateTable(Table source, Table destination)
        {
            // delete all existing columns not found in source columns for the curent table
            destination.Columns.RemoveAll(d => source.Columns.All(s => s.Name != d.Name));

            // loop through existing columns and update values
            foreach (var sourceColumn in source.Columns.Where(s => destination.Columns.Any(d => d.Name == s.Name)))
            {
                var destinationColumn = destination.Columns.First(d => d.Name == sourceColumn.Name);
                
                // update values form source if necessary
                destinationColumn.IsUmletUpdated = false;

                if (destinationColumn.DbType != sourceColumn.DbType)
                {
                    destinationColumn.DbType = sourceColumn.DbType;
                    destinationColumn.IsUmletUpdated = true;
                }

                if (destinationColumn.DbLength != sourceColumn.DbLength)
                {
                    destinationColumn.DbLength = sourceColumn.DbLength;
                    destinationColumn.IsUmletUpdated = true;
                }

                if (destinationColumn.DbPrecision != sourceColumn.DbPrecision)
                {
                    destinationColumn.DbPrecision = sourceColumn.DbPrecision;
                    destinationColumn.IsUmletUpdated = true;
                }

                if (destinationColumn.IsSystem != sourceColumn.IsSystem)
                {
                    destinationColumn.IsSystem = sourceColumn.IsSystem;
                    destinationColumn.IsUmletUpdated = true;
                }

                if (destinationColumn.IsReference != sourceColumn.IsReference)
                {
                    destinationColumn.IsReference = sourceColumn.IsReference;
                    destinationColumn.IsUmletUpdated = true;
                }

                if (destinationColumn.ReferenceTable != sourceColumn.ReferenceTable)
                {
                    destinationColumn.ReferenceTable = sourceColumn.ReferenceTable;
                    destinationColumn.IsUmletUpdated = true;
                }

                if (destinationColumn.ReferenceField != sourceColumn.ReferenceField)
                {
                    destinationColumn.ReferenceField = sourceColumn.ReferenceField;
                    destinationColumn.IsUmletUpdated = true;
                }

            }
            
            // add all new columns to existing current table
            destination.Columns.AddRange(source.Columns.Where(s => destination.Columns.All(d => d.Name != s.Name)));

            // sort columns
            destination.Columns = destination.Columns.OrderBy(t => t.ColumnOrder).ToList();

            // delete all existing indexes not found in source tables for the curent table
            destination.Indexes.RemoveAll(d => source.Indexes.All(s => s.Name != d.Name));

            // loop through existing indexes and update 
            foreach (var sourceIndex in source.Indexes.Where(s => destination.Indexes.Any(d => d.Name == s.Name)))
            {
                var destinationIndex = destination.Indexes.First(d => d.Name == sourceIndex.Name);
                UpdateIndex(sourceIndex, destinationIndex, destination.Name);
            }

            // add all new indexes to existing current table
            destination.Indexes.AddRange(source.Indexes.Where(s => destination.Indexes.All(d => d.Name != s.Name)));
        }

        public static void UpdateIndex(Index source, Index destination, string tableName)
        {
            destination.IsUnique = source.IsUnique;

            // delete all existing fields not found in source index
            destination.Fields.RemoveAll(d => source.Fields.All(s => s.Name != d.Name));

            // add all new fields to existing current index
            destination.Fields.AddRange(source.Fields.Where(s => destination.Fields.All(d => d.Name != s.Name)));

            // create new index name
            destination.Name = CreateIndexName(destination, tableName);
        }

        #endregion

        #region Objects Copy

        /// <summary>
        /// The copy data model.
        /// </summary>
        /// <param name="m">
        /// The m.
        /// </param>
        /// <returns>
        /// The <see cref="DataModel"/>.
        /// </returns>
        public static DataModel CopyDataModel(DataModel m)
        {
            DataModel model;

            var xs = new XmlSerializer(typeof(DataModel));
            var ms = new MemoryStream();
            xs.Serialize(ms, m);

            // rewind memory stream
            ms.Position = 0;

            using (var sr = new StreamReader(ms))
            {
                model = (DataModel)xs.Deserialize(sr);
            }

            return model;
        }

        /// <summary>
        /// The copy schema.
        /// </summary>
        /// <param name="s">
        /// The s.
        /// </param>
        /// <returns>
        /// The <see cref="Schema"/>.
        /// </returns>
        public static Schema CopySchema(Schema s)
        {
            Schema schema;

            var xs = new XmlSerializer(typeof(Schema));
            var ms = new MemoryStream();
            xs.Serialize(ms, s);

            // rewind memory stream
            ms.Position = 0;

            using (var sr = new StreamReader(ms))
            {
                schema = (Schema)xs.Deserialize(sr);
            }

            return schema;
        }

        /// <summary>
        /// The copy table.
        /// </summary>
        /// <param name="t">
        /// The t.
        /// </param>
        /// <returns>
        /// The <see cref="Table"/>.
        /// </returns>
        public static Table CopyTable(Table t)
        {
            Table table;

            var xs = new XmlSerializer(typeof(Table));
            var ms = new MemoryStream();
            xs.Serialize(ms, t);

            // rewind memory stream
            ms.Position = 0;

            using (var sr = new StreamReader(ms))
            {
                table = (Table)xs.Deserialize(sr);
            }

            return table;
        }

        /// <summary>
        /// The copy column.
        /// </summary>
        /// <param name="c">
        /// The c.
        /// </param>
        /// <returns>
        /// The <see cref="Column"/>.
        /// </returns>
        public static Column CopyColumn(Column c)
        {
            Column column;

            var xs = new XmlSerializer(typeof(Column));
            var ms = new MemoryStream();
            xs.Serialize(ms, c);

            // rewind memory stream
            ms.Position = 0;

            using (var sr = new StreamReader(ms))
            {
                column = (Column)xs.Deserialize(sr);
            }

            return column;
        }

        /// <summary>
        /// The copy index.
        /// </summary>
        /// <param name="i">
        /// The i.
        /// </param>
        /// <returns>
        /// The <see cref="Index"/>.
        /// </returns>
        public static Index CopyIndex(Index i)
        {
            Index index;

            var xs = new XmlSerializer(typeof(Index));
            var ms = new MemoryStream();
            xs.Serialize(ms, i);

            // rewind memory stream
            ms.Position = 0;

            using (var sr = new StreamReader(ms))
            {
                index = (Index)xs.Deserialize(sr);
            }

            return index;
        }

        #endregion
        
        public static string CreateIndexName(Index index, string tableName)
        {
            var count = 2 + index.Fields.Count;
            var name = new string[count];

            name[0] = index.IsUnique ? @"UX" : @"IX";

            name[1] = string.Empty;

            var tableNames = tableName.Split('.');
            if (tableNames.Length == 1)
            {
                name[1] = tableNames[0];
            }

            if (tableNames.Length == 2)
            {
                name[1] = tableNames[1];
            }

            var i = 2;

            foreach (var field in index.Fields)
            {
                name[i] = field.Name;
                i++;
            }

            return string.Join("_", name);
        }
        
        public static void RecalculateColumnOrder(Table table)
        {
            foreach (var column in table.Columns)
            {
                column.ColumnOrder = table.Columns.IndexOf(column) + 1;
            }
        }
        
        public static void CopyProperties(object source, object destination)
        {
            // If any this null throw an exception
            if (source == null || destination == null)
            {
                throw new Exception("Source or/and Destination Objects are null");
            }
            
            // Getting the Types of the objects
            var typeDest = destination.GetType();
            var typeSrc = source.GetType();

            // Iterate the Properties of the source instance and  
            // populate them from their desination counterparts  
            var srcProps = typeSrc.GetProperties();
            foreach (var srcProp in srcProps)
            {
                if (!srcProp.CanRead)
                {
                    continue;
                }

                var targetProperty = typeDest.GetProperty(srcProp.Name);
                if (targetProperty == null)
                {
                    continue;
                }

                if (!targetProperty.CanWrite)
                {
                    continue;
                }

                if (targetProperty.GetSetMethod(true) != null && targetProperty.GetSetMethod(true).IsPrivate)
                {
                    continue;
                }

                if ((targetProperty.GetSetMethod().Attributes & MethodAttributes.Static) != 0)
                {
                    continue;
                }

                if (!targetProperty.PropertyType.IsAssignableFrom(srcProp.PropertyType))
                {
                    continue;
                }

                // Passed all tests, lets set the value
                targetProperty.SetValue(destination, srcProp.GetValue(source, null), null);
            }
        }
        
        public static void CloneIndex(Index source, Index destination)
        {
            destination.IsUnique = source.IsUnique;
            foreach (var field in source.Fields)
            {
                destination.Fields.Add(new IndexField { Name = field.Name });
            }
        }
        
        public static void CopyIndexProperties(Index source, Index destination)
        {
            destination.Name = source.Name;
            destination.IsUnique = source.IsUnique;
            destination.Fields.Clear();
            foreach (var field in source.Fields)
            {
                destination.Fields.Add(new IndexField { Name = field.Name });
            }
        }
        
        public static void XGridSetup(XGrid grid)
        {
            grid.RowHeight = Properties.Settings.Default.RowHeight;
            grid.OddBackColor = Properties.Settings.Default.OddBackColor;
            grid.EvenBackColor = Properties.Settings.Default.EvenBackColor;
            grid.GridLineColor = Properties.Settings.Default.GridlineColor;
            grid.ShowHorizontalGrid = Properties.Settings.Default.ShowHorizontalGridlines;
            grid.ShowVerticalGrid = Properties.Settings.Default.ShowVerticalGridlines;
            grid.Refresh();
        }
        
        public static void GridSetup(xGrid grid)
        {
            grid.RowHeight = Properties.Settings.Default.RowHeight;
            grid.OddBackColor = Properties.Settings.Default.OddBackColor;
            grid.EvenBackColor = Properties.Settings.Default.EvenBackColor;
            grid.GridLineColor = Properties.Settings.Default.GridlineColor;
            grid.ShowHorizontalGrid = Properties.Settings.Default.ShowHorizontalGridlines;
            grid.ShowVerticalGrid = Properties.Settings.Default.ShowVerticalGridlines;
            grid.SetProperties();
            grid.Refresh();
        }
        
        public static string GetShortTableName(string fullName)
        {
            var s = fullName.Split('.');

            return s.Length == 2 ? s[1] : fullName;
        }
        
        public static string GetNewLineDelimiter(string source)
        {
            string newLine = @"\r\n";
            if (source.IndexOf(newLine) == -1)
            {
                newLine = @"\n";
            }

            return newLine;
        }
    }
}
