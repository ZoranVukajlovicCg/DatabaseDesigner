// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Schema.cs" company="N/A">
//   Zoran Vukajlovic
// </copyright>
// <summary>
//   Defines the Schema type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DatabaseDesigner.Entities
{
    using System.Collections.Generic;

    /// <summary>
    /// The schema.
    /// </summary>
    public class Schema
    {
        public Schema()
        {
            this.Tables = new List<Table>();
        }

        public string Name { get; set; }

        public List<Table> Tables { get; set; } 
    }
}
