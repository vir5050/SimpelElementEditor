using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace SimpelElementEditor.ESO
{
    public class NPC_PROF_DEMOTION_SERVICE : ICloneable
    {
        public object Clone() { return this.MemberwiseClone(); }
        public int id { get; set; } = 0;
        public string name { get; set; }
        public COMMON.CharacterClassFlags prof_require_mask { get; set; }
        public int prof_trans_mask { get; set; }
        [Reader.FixedArrayLengthAttribute(8)]
        public ITEMS[] items { get; set; }
        [TypeConverter(typeof(MoneyConverter))]
        public int price { get; set; }
        public COMMON.REPU_TYPE repu_id { get; set; }
        public int repu_val { get; set; }
        public override string ToString()
        {
            return $"{id}: {name}";
        }
        public class ITEMS : ICloneable
        {
            public object Clone() { return this.MemberwiseClone(); }
            [Reader.FixedArrayLengthAttribute(32)]
            [TypeConverter(typeof(ItemIdConverter))]
            public int id_item { get; set; }
            public float return_per_item { get; set; }

            public override string ToString()
            {
                return $"{ItemLookupHelper.GetItemString(id_item)}: {return_per_item}";
            }
        }
    }
}
