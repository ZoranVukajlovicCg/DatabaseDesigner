using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDesigner.Clases
{
    public static class AppStatus
    {
        public static bool UmletModelLoaded {  get; set; }

        public static string UmletModelPath { get; set; }

        public static bool ModelCreated { get; set; }

        public static string ModelPath { get; set;}

        public static bool ModelSaved { get; set; }

        public static bool ScriptGenerated { get; set; }

        public static string ScriptPath { get; set; }
    }
}
