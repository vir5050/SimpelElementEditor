using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace SimpelElementEditor.ESO
{
    public class LOTTERY_ESSENCE : ICloneable
    {
        public object Clone() { return this.MemberwiseClone(); }
        public int id { get; set; }
        public string name { get; set; }
        public int file_matter { get; set; }
        public int file_icon { get; set; }
        public int dice_count { get; set; }
        [TypeConverter(typeof(ItemIdConverter))]
        public int item_consume { get; set; }
        public COMMON.BOOL extra_award { get; set; }

        [Reader.FixedArrayLengthAttribute(32)]
        public CANDIDATES[] candidates { get; set; }
        public int index_face { get; set; }
        [TypeConverter(typeof(MoneyConverter))]
        public int price { get; set; }
        [TypeConverter(typeof(MoneyConverter))]
        public int shop_price { get; set; }
        public int pile_num_max { get; set; }
                [Editor(typeof(COMMON.FlagsEnumEditor), typeof(System.Drawing.Design.UITypeEditor))]        public COMMON.ProcTypeFlags proc_type { get; set; }


        public override string ToString()
        {
            return $"{id}: {name}";
        }

        public class CANDIDATES : ICloneable
        {
            public object Clone() { return this.MemberwiseClone(); }
            [Reader.FixedArrayLengthAttribute(32)]
            public string desc { get; set; }
            [TypeConverter(typeof(ItemIdConverter))]
            public int patten_id { get; set; } //typo not on me ;)
            public int icon { get; set; }

            public override string ToString()
            {
                return $"{ItemLookupHelper.GetItemString(patten_id)}";
            }
        }
    }
}
