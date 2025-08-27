using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace SimpelElementEditor.ESO
{
    public class VEHICLE_ESSENCE : ICloneable
    {
        public object Clone() { return this.MemberwiseClone(); }
        public int id { get; set; }
        public string name { get; set; }
        [Reader.LookupType(typeof(PathData.path))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int file_model { get; set; }
        [Reader.LookupType(typeof(PathData.path))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int file_matter { get; set; }
        [Reader.LookupType(typeof(PathData.path))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int file_icon { get; set; }
        public int level_required { get; set; }
        public int only_in_war { get; set; }
        public float speed { get; set; }
        public float height { get; set; }
        [Reader.FixedArrayLengthAttribute(32)]
        public string action { get; set; }
        public COMMON.BOOL can_attack { get; set; }
        [Reader.FixedArrayLengthAttribute(5)]
        public ADDONS[] addons { get; set; }
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
        public class ADDONS : ICloneable
        {
            public object Clone() { return this.MemberwiseClone(); }
            [Reader.LookupType(typeof(Skills.skill))]
            [TypeConverter(typeof(LookupIdConverter))]
            public int id { get; set; }
            public int level { get; set; }
            public override string ToString()
            {
                return $"{id}: {level}";
            }
        }
    }
}
