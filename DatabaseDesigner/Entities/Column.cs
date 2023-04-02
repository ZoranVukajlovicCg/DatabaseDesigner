// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Column.cs" company="N/A">
//   Zoran Vukajlovic
// </copyright>
// <summary>
//   The column.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DatabaseDesigner.Entities
{
    public class Column
    {
        public string Name { get; set; }

        public int ColumnOrder { get; set; }

        public string DisplayName { get; set; }

        public string DbType { get; set; }

        public int DbLength { get; set; }

        public string DbPrecision { get; set; }

        public bool IsNullable { get; set; }

        public string DefaultValue { get; set; }

        public bool IsRequired { get; set; }

        public bool IsSearchable { get; set; }

        public bool IsFullTextSearch { get; set; }

        public bool IsSystem { get; set; }

        public bool IsDynamic { get; set; }

        public bool? IsPrimaryKey { get; set; }

        public bool? IsAutoincrement { get; set; }

        public bool? IsConstraint { get; set; }

        public bool IsReference { get; set; }

        public string ReferenceTableSchema { get; set; }

        public string ReferenceTable { get; set; }

        public string ReferenceField { get; set; }

        public bool AddToRepository { get; set; }

        public bool? IsUmletCreated { get; set; }

        public bool? IsUmletUpdated { get; set; }
    }
}
