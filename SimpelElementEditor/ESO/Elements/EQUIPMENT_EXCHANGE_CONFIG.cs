using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace SimpelElementEditor.ESO.Elements
{
    public class EQUIPMENT_EXCHANGE_CONFIG : ICloneable
    {
        public object Clone() { return this.MemberwiseClone(); }
        public int id { get; set; }
        public string name { get; set; }
        [TypeConverter(typeof(ItemIdConverter))]
        public int gen_item_id { get; set; }
        public int gen_item_level { get; set; }
        [TypeConverter(typeof(ItemIdConverter))]
        public int main_item_id { get; set; }
        public int main_item_level { get; set; }
        [Reader.FixedArrayLengthAttribute(3)]
        public AUX_ITEMS[] aux_items { get; set; }
        public int success_prop { get; set; }
        public int fee { get; set; }

        public override string ToString()
        {
            return $"{id}: {name}";
        }
        public class AUX_ITEMS : ICloneable
        {
            public object Clone() { return this.MemberwiseClone(); }
            [TypeConverter(typeof(ItemIdConverter))]
            public int item_id { get; set; }
            public int item_num { get; set; }

            public override string ToString()
            {
                return $"{ItemLookupHelper.GetItemName(item_id)}x {item_num}";
            }
        }
    }
}
