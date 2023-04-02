// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataModel.cs" company="N/A">
//   Zoran Vukajlovic
// </copyright>
// <summary>
//   Defines the DataModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DatabaseDesigner.Entities
{
    using System.Collections.Generic;

    public class DataModel
    {
        public DataModel()
        {
            this.Schemas = new List<Schema>();
        }

        public string Name { get; set; }

        public bool RecreateDataModel { get; set; }

        public List<Schema> Schemas { get; set; } 
    }
}
