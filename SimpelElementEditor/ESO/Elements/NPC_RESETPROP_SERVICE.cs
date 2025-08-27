using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace SimpelElementEditor.ESO
{
    public class NPC_RESETPROP_SERVICE : ICloneable
    {
        public object Clone() { return this.MemberwiseClone(); }
        public int id { get; set; }

        public string name { get; set; }
        [Reader.FixedArrayLengthAttribute(6)]
        public PROP_ENTRY[] prop_entry { get; set; }

        public override string ToString()
        {
            return $"{id}: {name}";
        }
        public class PROP_ENTRY : ICloneable
        {
            public object Clone() { return this.MemberwiseClone(); }
            [TypeConverter(typeof(ItemIdConverter))]
            public int id_object_need { get; set; }
            public int resetprop_type { get; set; }

            public override string ToString()
            {
                return $"{ItemLookupHelper.GetItemName(id_object_need)}";
            }
        }
    }
}
