// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UmlDataModel.cs" company="N/A">
//   Zoran Vukajlovic
// </copyright>
// <summary>
//   Defines the UmlDataModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DatabaseDesigner.Entities
{
    using System.Collections.Generic;

    /// <summary>
    /// The UML data model.
    /// </summary>
    public class UmlDataModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UmlDataModel"/> class.
        /// </summary>
        public UmlDataModel()
        {
            this.UmlTables = new List<UmlTable>();
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the tables.
        /// </summary>
        public List<UmlTable> UmlTables { get; set; } 
    }
}
