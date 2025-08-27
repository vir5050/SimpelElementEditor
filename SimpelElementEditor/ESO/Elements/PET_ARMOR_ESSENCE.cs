using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace SimpelElementEditor.ESO
{
    public class PET_ARMOR_ESSENCE : ICloneable
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
        [Reader.FixedArrayLengthAttribute(32)]
        public string desc { get; set; }
        public int pet_level { get; set; }
        public int pet_type_mask { get; set; }
        public int monster_faction { get; set; }
        [TypeConverter(typeof(NamedArrayConverter))]
        [Reader.FixedArrayLengthAttribute(18)]
        [Reader.IndexNames("FireResist", "WaterResist", "EarthResist", "AirResist", "PoisonResist")]
        public PROPS[] props { get; set; }
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

        public class PROPS : ICloneable
        {
            public object Clone() { return this.MemberwiseClone(); }
            public float maximum { get; set; }
            public float minimum { get; set; }
            public float ultimate { get; set; }

            public override string ToString()
            {
                return $"{minimum}: {maximum}";
            }
        }
    }
}
