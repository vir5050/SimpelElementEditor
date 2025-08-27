using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace SimpelElementEditor.ESO.Elements
{
    public class CHANGE_SHAPE_ESSENCE : ICloneable
    {
        public object Clone() { return this.MemberwiseClone(); }
        public int id { get; set; }
        public string name { get; set; }
        [Reader.FixedArrayLengthAttribute(32)]
        public string collection { get; set; }

        [Reader.LookupType(typeof(PathData.path))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int file_matter { get; set; }

        [Reader.LookupType(typeof(PathData.path))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int file_icon { get; set; }

        [Reader.LookupType(typeof(PathData.path))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int file_model { get; set; }
        [Reader.FixedArrayLengthAttribute(512)]
        public string descript_text { get; set; }
        public int valid_time { get; set; }
        public int level_required { get; set; }
        public int stand_mode { get; set; }
        public int monster_race { get; set; }
        public float advantage_param { get; set; }
        public int used_vp { get; set; }
        public int used_time { get; set; }
        public float height_var { get; set; }
        public float speed { get; set; }
        public int can_attack { get; set; }
        public int hide_name { get; set; }
        public int can_fly { get; set; }


        [Reader.LookupType(typeof(AIRCRAFT_ESSENCE))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int aircraft_id { get; set; }
        [Reader.FixedArrayLengthAttribute(32)]
        public string buff_action1 { get; set; }
        [Reader.FixedArrayLengthAttribute(32)]
        public string buff_action2 { get; set; }
        [Reader.FixedArrayLengthAttribute(32)]
        public string buff_action3 { get; set; }
        [Reader.FixedArrayLengthAttribute(32)]
        public string debuff_action1 { get; set; }
        [Reader.FixedArrayLengthAttribute(32)]
        public string debuff_action2 { get; set; }
        [Reader.FixedArrayLengthAttribute(32)]
        public string debuff_action3 { get; set; }
        [Reader.FixedArrayLengthAttribute(32)]
        public string attack_action1 { get; set; }
        [Reader.FixedArrayLengthAttribute(32)]
        public string attack_action2 { get; set; }
        [Reader.FixedArrayLengthAttribute(32)]
        public string attack_action3 { get; set; }
        [Reader.FixedArrayLengthAttribute(3)]
        public int[] shape_required { get; set; }
        [Reader.FixedArrayLengthAttribute(3)]
        public ADDON_SKILLS[] addon_skills { get; set; }
        [Reader.FixedArrayLengthAttribute(6)]
        public EQUIPMENT_ADDON.ADDONS[] addons { get; set; }

        [Reader.FixedArrayLengthAttribute(3)]
        public PET_INFO[] pet_info { get; set; }

        [Reader.FixedArrayLengthAttribute(3)]
        public ADDED_PET_SKILLS[] added_pet_skills { get; set; }

        public int pet_race_evaluation { get; set; }
        [Reader.FixedArrayLengthAttribute(3)]
        public ADDED_PET_SKILLS[] pet_race_skills { get; set; }
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

        public class ADDON_SKILLS : ICloneable
        {
            public object Clone() { return this.MemberwiseClone(); }
            public int id { get; set; } = 0;
            public int level { get; set; }

            public override string ToString()
            {
                return $"{id}: {level}";
            }
        }
        public class PET_INFO : ICloneable
        {
            public object Clone() { return this.MemberwiseClone(); }
            public int pet_id { get; set; } = 0;
            public int evaluation { get; set; }

            public override string ToString()
            {
                return $"{pet_id}: {evaluation}";
            }
        }
        public class ADDED_PET_SKILLS : ICloneable
        {
            public object Clone() { return this.MemberwiseClone(); }
            public int id { get; set; } = 0;
            public int level { get; set; }

            public override string ToString()
            {
                return $"{id}: {level}";
            }
        }
    }
}
