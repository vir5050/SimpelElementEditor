using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace SimpelElementEditor.ESO.Elements
{
    public class AIRCRAFT_ESSENCE : ICloneable
    {
        public object Clone() { return this.MemberwiseClone(); }
        public int id { get; set; } = 0;
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
        [TypeConverter(typeof(MoneyConverter))]
        public int price { get; set; }
        [TypeConverter(typeof(MoneyConverter))]
        public int shop_price { get; set; }
        [Reader.FixedArrayLengthAttribute(32)]
        public string descript { get; set; }
        public int level_required { get; set; }
        public COMMON.CharacterClassFlags character_combo_id { get; set; }
        public COMMON.BOOL only_in_war { get; set; }
        public int fly_mode { get; set; }
        public float speed { get; set; }
        public int mp_used { get; set; }
        public float sprint_speed { get; set; }
        public int vp_used { get; set; }
        public int can_attack { get; set; }
        [Reader.FixedArrayLengthAttribute(5)]
        public ADDONS[] addons { get; set; }
        public int pile_num_max { get; set; }
                [Editor(typeof(COMMON.FlagsEnumEditor), typeof(System.Drawing.Design.UITypeEditor))]        
        public COMMON.ProcTypeFlags proc_type { get; set; }

        public override string ToString()
        {
            return $"{id}: {name}";
        }
        public class ADDONS : ICloneable
        {
            public object Clone() { return this.MemberwiseClone(); }

            [Reader.LookupType(typeof(Skills.skill))]
            [TypeConverter(typeof(LookupIdConverter))]
            public int id { get; set; } = 0;
            public int level { get; set; }

            public override string ToString()
            {
                return $"{id}: {level}";
            }
        }
    }
}
