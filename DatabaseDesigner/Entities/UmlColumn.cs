// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UmlColumn.cs" company="N/A">
//   Zoran Vukajlovic
// </copyright>
// <summary>
//   The UML column.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DatabaseDesigner.Entities
{
    /// <summary>
    /// The UML column.
    /// </summary>
    public class UmlColumn
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the data type.
        /// </summary>
        public string DataType { get; set; }

        /// <summary>
        /// Gets or sets the is primary key.
        /// </summary>
        public bool? IsPrimaryKey { get; set; }

        public bool? IsAutoincrement { get; set; }

        public bool? IsConstraint { get; set; }

        public bool? IsNullable { get; set; }

        /// <summary>
        /// Gets or sets the is system.
        /// </summary>
        public bool? IsSystem { get; set; }

        /// <summary>
        /// Gets or sets the is reference.
        /// </summary>
        public bool? IsReference { get; set; }

        /// <summary>
        /// Gets or sets the reference schema.
        /// </summary>
        public string ReferenceSchema { get; set; }

        /// <summary>
        /// Gets or sets the reference table.
        /// </summary>
        public string ReferenceTable { get; set; }

        /// <summary>
        /// Gets or sets the reference column.
        /// </summary>
        public string ReferenceColumn { get; set; }

        /// <summary>
        /// Gets or sets the parse error.
        /// </summary>
        public string ParseError { get; set; }
    }
}
