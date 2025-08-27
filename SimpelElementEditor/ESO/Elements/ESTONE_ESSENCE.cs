using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace SimpelElementEditor.ESO.Elements
{
    public class ESTONE_ESSENCE : ICloneable
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
        [Reader.FixedArrayLengthAttribute(4)]
        public EFFECTS[] effects { get; set; }
        public int price { get; set; }
        [TypeConverter(typeof(MoneyConverter))]
        public int shop_price { get; set; }
        [TypeConverter(typeof(MoneyConverter))]
        public float rank { get; set; }
        public int pile_num_max { get; set; }
         [Editor(typeof(COMMON.FlagsEnumEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public COMMON.ProcTypeFlags proc_type { get; set; }


        public override string ToString()
        {
            return $"{id}: {name}";
        }
        public class EFFECTS : ICloneable
        {
            public object Clone() { return this.MemberwiseClone(); }
            public COMMON.EquipInventoryItemType equip_mask { get; set; }
            [Reader.LookupType(typeof(EQUIPMENT_ADDON))]
            [TypeConverter(typeof(LookupIdConverter))]
            public int effect_addon_type { get; set; }

            public override string ToString()
            {
                return $"{equip_mask}: {effect_addon_type}";
            }
        }
    }
}
