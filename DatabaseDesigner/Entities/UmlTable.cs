// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UmlTable.cs" company="N/A">
//   Zoran Vukajlovic
// </copyright>
// <summary>
//   The UML table.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DatabaseDesigner.Entities
{
    using System.Collections.Generic;

    public class UmlTable
    {
        public UmlTable()
        {
            this.ParentTable = null;
            this.UmlColumns = new List<UmlColumn>();
            this.UmlIndexes = new List<UmlIndex>();
        }

        public int? Order { get; set; }
        public string Schema { get; set; }
        public string Name { get; set; }
        public string ParentSchema { get; set; }
        public string ParentTable { get; set; }
        public List<UmlColumn> UmlColumns { get; set; }
        public List<UmlIndex> UmlIndexes { get; set; }
    }
}
