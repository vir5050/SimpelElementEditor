using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace SimpelElementEditor.ESO.Elements
{
    public class SUMMON_MONSTER_ESSENCE : ICloneable
    {
        public object Clone() { return this.MemberwiseClone(); }
        public int id { get; set; } = 0;
        public string name { get; set; }
        [Reader.LookupType(typeof(PathData.path))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int file_matter { get; set; }
        [Reader.LookupType(typeof(PathData.path))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int file_icon { get; set; }
        public int required_level { get; set; }
        [Reader.FixedArrayLengthAttribute(2)]
        public MONSTERS[] monsters { get; set; }
        [TypeConverter(typeof(MoneyConverter))]
        public int price { get; set; }
        [TypeConverter(typeof(MoneyConverter))]
        public int shop_price { get; set; }
        public int pile_num_max { get; set; }
                [Editor(typeof(COMMON.FlagsEnumEditor), typeof(System.Drawing.Design.UITypeEditor))]        public COMMON.ProcTypeFlags proc_type { get; set; }
        public class MONSTERS : ICloneable
        {
            public object Clone() { return this.MemberwiseClone(); }
            [Reader.LookupType(typeof(MONSTER_ESSENCE))]
            [TypeConverter(typeof(LookupIdConverter))]
            public int id { get; set; } = 0;
            public int lifespan { get; set; }
            public int num { get; set; }

            public override string ToString()
            {
                return $"{id}: {lifespan}";
            }
        }
        public override string ToString()
        {
            return $"{id}: {name}";
        }
    }
}
