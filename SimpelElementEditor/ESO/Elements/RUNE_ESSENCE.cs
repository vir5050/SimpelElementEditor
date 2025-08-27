using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace SimpelElementEditor.ESO.Elements
{
    public class RUNE_ESSENCE : ICloneable
    {
        public object Clone() { return this.MemberwiseClone(); }
        public int id { get; set; }
        public string name { get; set; }
        [Reader.LookupType(typeof(PathData.path))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int file_matter { get; set; }
        [Reader.LookupType(typeof(PathData.path))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int file_icon { get; set; }
        [Reader.LookupType(typeof(PathData.path))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int file_show_gfx { get; set; }
        public int level { get; set; }
        [Reader.FixedArrayLengthAttribute(32)]
        public string show_level { get; set; }
        public int pack_index { get; set; }
        [Reader.FixedArrayLengthAttribute(4)]
        public FIXED_ADDONS[] fixed_addons { get; set; }
        [Reader.FixedArrayLengthAttribute(4)]
        public int[] id_rand_addonsgroups { get; set; } //to link once id_rand_addons is created....
        public int uninstall_aux_item1 { get; set; }
        public int uninstall_aux_item2 { get; set; }
        [TypeConverter(typeof(MoneyConverter))]
        public int price { get; set; }
        [TypeConverter(typeof(MoneyConverter))]
        public int shop_price { get; set; }
        public int pile_num_max { get; set; }
        [Editor(typeof(COMMON.FlagsEnumEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public COMMON.ProcTypeFlags proc_type { get; set; }

        public override string ToString()
        {
            return $"{id}: {name}";
        }
        public class FIXED_ADDONS : ICloneable
        {
            public object Clone() { return this.MemberwiseClone(); }
            [Reader.LookupType(typeof(EQUIPMENT_ADDON))]
            [TypeConverter(typeof(LookupIdConverter))]
            public int id { get; set; }
            public float prob { get; set; }

            public override string ToString()
            {
                return $"{id}: {prob*100}%";
            }
        }
    }
}
