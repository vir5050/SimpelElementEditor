using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace SimpelElementEditor.ESO.Elements
{
    public class TITLE_PROP_CONFIG : ICloneable
    {
        public object Clone() { return this.MemberwiseClone(); }
        public int id { get; set; }
        public string name { get; set; }
        public int id_title { get; set; }
        [Reader.FixedArrayLengthAttribute(3)]
        public EQUIPMENT_ADDON.ADDONS[] file_icon { get; set; }


        public override string ToString()
        {
            return $"{id}: {name}";
        }
    }
}
