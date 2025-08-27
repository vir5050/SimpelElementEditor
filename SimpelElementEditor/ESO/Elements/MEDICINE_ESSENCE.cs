using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace SimpelElementEditor.ESO
{
    public class MEDICINE_ESSENCE : ICloneable
    {
        public object Clone() { return this.MemberwiseClone(); }
        public int id { get; set; }

        [Reader.LookupType(typeof(MEDICINE_MAJOR_TYPE))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int id_major_type { get; set; }

        [Reader.LookupType(typeof(MEDICINE_SUB_TYPE))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int id_sub_type { get; set; }
        public string name { get; set; }

        [Reader.LookupType(typeof(PathData.path))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int file_matter { get; set; }

        [Reader.LookupType(typeof(PathData.path))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int file_icon { get; set; }
        public int require_level { get; set; }
        public int cool_type_mask { get; set; }
        public int cool_time { get; set; }
        public int only_in_war { get; set; }
        public int type { get; set; }

        [Reader.FixedArrayLengthAttribute(4)]
        public int[] hp { get; set; }

        [Reader.FixedArrayLengthAttribute(4)]
        public int[] mp { get; set; }

        [Reader.FixedArrayLengthAttribute(4)]
        public int[] vp { get; set; }

        [Reader.FixedArrayLengthAttribute(4)]
        public int[] anger { get; set; }
        public int physique_add { get; set; }
        public int physique_dec { get; set; }
        public int physique { get; set; }
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
    }
}
