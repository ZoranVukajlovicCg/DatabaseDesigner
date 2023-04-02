// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Table.cs" company="N/A">
//   Zoran Vukajlovic
// </copyright>
// <summary>
//   The table.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DatabaseDesigner.Entities
{
    using System.Collections.Generic;
    using System.Drawing;

    public class Table
    {
        public Table()
        {
            this.Columns = new List<Column>();
            this.Indexes = new List<Index>();
        }

        public int? Order { get; set; } 

        public string Name { get; set; }

        public string Namespace { get; set; }

        public string EntityName { get; set; }

        public string DisplayName { get; set; }

        public string ParentSchema { get; set; }

        public string ParentTable { get; set; }

        public string ReferencePattern { get; set; }

        public string EntityIconName { get; set; }

        public bool IsAccessControlEnabled { get; set; }

        public bool AddToRepository { get; set; }

        public List<Column> Columns { get; set; }

        public List<Index> Indexes { get; set; } 
    }
}
