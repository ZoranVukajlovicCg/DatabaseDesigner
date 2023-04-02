// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Index.cs" company="N/A">
// Zoran Vukajlovic  
// </copyright>
// <summary>
//   The index.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DatabaseDesigner.Entities
{
    using System.Collections.Generic;

    public class Index
    {
        public Index()
        {
            this.Fields = new List<IndexField>();
        }

        public string Name { get; set; }
        
        public bool IsUnique { get; set; }

        public List<IndexField> Fields { get; set; }
    }
}
