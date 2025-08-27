using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace SimpelElementEditor.ESO
{
    public class NPC_BIRTH_RESET_SERVICE : ICloneable
    {
        public object Clone() { return this.MemberwiseClone(); }
        public int id { get; set; } = 0;
        public string name { get; set; }
        [Reader.FixedArrayLengthAttribute(6)]
        public ITEMS_NEED[] items_need { get; set; }

        public override string ToString()
        {
            return $"{id}: {name}";
        }
        public class ITEMS_NEED : ICloneable
        {
            public object Clone() { return this.MemberwiseClone(); }
            [TypeConverter(typeof(ItemIdConverter))]
            public int items_need { get; set; }

            public override string ToString()
            {
                return $"{ItemLookupHelper.GetItemString(items_need)}";
            }
        }
    }
}
