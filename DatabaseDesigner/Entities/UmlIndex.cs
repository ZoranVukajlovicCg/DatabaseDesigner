// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UmlIndex.cs" company="N/A">
//   Zoran Vukajlovic
// </copyright>
// <summary>
//   Defines the UmlIndex type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DatabaseDesigner.Entities
{
    public class UmlIndex
    {
        public string Name { get; set; }
        public bool IsUnique { get; set; }
        public bool IsLegacy { get; set; }
        public string[] ColumnList { get; set; }
    }
}
