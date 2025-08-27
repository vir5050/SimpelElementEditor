using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace SimpelElementEditor.ESO.Elements
{
    public class RUNE_COMBINATION_CONFIG : ICloneable
    {
        public object Clone() { return this.MemberwiseClone(); }
        public int id { get; set; } = 0;
        public string name { get; set; }
        public COMMON.BOOL isEffective { get; set; }
        [Reader.LookupType(typeof(PathData.path))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int file_show_gfx { get; set; }
        public int require_level { get; set; }
        [Editor(typeof(COMMON.FlagsEnumEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public COMMON.CharacterClassFlags require_profession { get; set; }
        public int require_gender { get; set; }
        [Editor(typeof(COMMON.FlagsEnumEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public COMMON.RaceFlags require_race { get; set; }
        public int weapon_rune_level { get; set; }
        public int helmet_rune_level { get; set; }
        public int armour_rune_level { get; set; }
        public int shoe_rune_level { get; set; }
        public int money { get; set; }

        [Reader.FixedArrayLengthAttribute(4)]
        public REPUTATIONS[] reputations { get; set; }
        public int _SP { get; set; }

        [Reader.FixedArrayLengthAttribute(4)]
        public ITEMS[] items { get; set; }
        public int addon_upperlimit { get; set; }

        [Reader.FixedArrayLengthAttribute(8)]
        public FIXED_ADDONS[] fixed_addons { get; set; }
        [Reader.FixedArrayLengthAttribute(8)]
        public int[] id_rand_addonsgroups { get; set; } //lookup in other list that further down the file TODO once its made
        public override string ToString()
        {
            return $"{id}: {name}";
        }
        public class REPUTATIONS : ICloneable
        {
            public object Clone() { return this.MemberwiseClone(); }
            public COMMON.REPU_TYPE repu_id { get; set; }
            public int repu_num { get; set; }
            public override string ToString()
            {
                return $"{repu_id}: {repu_num}";
            }
        }
        public class ITEMS : ICloneable
        {
            public object Clone() { return this.MemberwiseClone(); }

            [TypeConverter(typeof(ItemIdConverter))]
            public int item_id { get; set; }
            public int item_num { get; set; }
            public override string ToString()
            {
                return $"{ItemLookupHelper.GetItemName(item_id)}: {item_num}";
            }
        }
        public class FIXED_ADDONS : ICloneable
        {
            public object Clone() { return this.MemberwiseClone(); }

            [Reader.LookupType(typeof(EQUIPMENT_ADDON))]
            [TypeConverter(typeof(LookupIdConverter))]
            public int id { get; set; }
            public float prop { get; set; }
            public override string ToString()
            {
                return $"{id}: {prop*100}%";
            }
        }
    }
}
