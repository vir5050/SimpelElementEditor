using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace SimpelElementEditor.ESO
{
    public class GARDEN_AWARD : ICloneable
    {
        public object Clone() { return this.MemberwiseClone(); }
        public int id { get; set; } = 0;
        public string name { get; set; }
        public float award_prob { get; set; }
        public int max_kind { get; set; }
        public int actual_kind { get; set; }
        [TypeConverter(typeof(MoneyConverter))]
        public int money { get; set; }
        public float money_prob { get; set; }

        [Reader.FixedArrayLengthAttribute(24)]
        public ITEMS[] items { get; set; }

        public override string ToString()
        {
            return $"{id}: {name}";
        }
        public class ITEMS : ICloneable
        {
            public object Clone() { return this.MemberwiseClone(); }
            [TypeConverter(typeof(ItemIdConverter))]
            public int item_id { get; set; }
            public int item_num { get; set; }
            public float item_prob { get; set; }

            public override string ToString()
            {
                return $"{ItemLookupHelper.GetItemString(item_id)}";
            }
        }
    }
}
