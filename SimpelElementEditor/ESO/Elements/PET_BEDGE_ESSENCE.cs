using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace SimpelElementEditor.ESO.Elements
{
    public class PET_BEDGE_ESSENCE : ICloneable
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
        [Reader.LookupType(typeof(PathData.path))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int file_icon_unidentify { get; set; }
        [Reader.FixedArrayLengthAttribute(2)]
        public int[] file_head_icon { get; set; }
        [Reader.LookupType(typeof(PathData.path))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int file_head_icon2 { get; set; }
        [Reader.FixedArrayLengthAttribute(16)]
        public int[] file_to_shown { get; set; }
        public float size { get; set; }
        public int pet_type { get; set; }
        public int pet_food_mask { get; set; }
        public int level { get; set; }
        public int life { get; set; }
        public int faint { get; set; }
        public int exp_levelup_id { get; set; }
        public int init_evaluation { get; set; }
        public int fight_type { get; set; }
        public int monster_faction { get; set; }
        public int summon_mp_used { get; set; }
        public int combine_mp_used { get; set; }
        public int mp_per_second { get; set; }
        [Reader.LookupType(typeof(Skills.skill))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int combine_skill { get; set; }
        public int merge_sp_consume { get; set; }
        public float sight_range { get; set; }
        public float attack_range { get; set; }
        public float aggro_range { get; set; }
        public int aggro_time { get; set; }
        public int stand_mode { get; set; }
        public float walk_speed { get; set; }
        public float run_speed { get; set; }
        public int max_skills { get; set; }
        public int min_skills { get; set; }
        public int hp_gen1 { get; set; }
        public int hp_gen2 { get; set; }
        public int faint_gen_time { get; set; }
        public float faint_gen_speed { get; set; }

        [TypeConverter(typeof(NamedArrayConverter))]
        [Reader.FixedArrayLengthAttribute(18)]
        [Reader.IndexNames("FireResist", "WaterResist", "EarthResist", "AirResist", "PoisonResist")]
        public PROPS[] props { get; set; }

        [Reader.FixedArrayLengthAttribute(2)]
        public PET_COMBINE_SKILL[] pet_combine_skill { get; set; }

        [Reader.FixedArrayLengthAttribute(4)]
        public EQUIPMENT_ADDON.ADDONS[] pet_combine_addon { get; set; }

        [Reader.FixedArrayLengthAttribute(32)]
        public string quality_desc { get; set; } 
        public float hp_grow_aver { get; set; }
        public float phy_dmg_grow_aver { get; set; }
        public float magic_dmg_grow_aver { get; set; }
        public float phy_defense_grow_aver { get; set; }
        public float magic_defense_grow_aver { get; set; }
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
            public float init_value { get; set; }
            public float init_value_var { get; set; }
            public float merge_value_max { get; set; }
            public float p_value { get; set; }
            public float p_value_var { get; set; }
            public float merge_p_value_max { get; set; }

            public override string ToString()
            {
                return $"{init_value}";
            }
        }
        public class PET_COMBINE_SKILL : ICloneable
        {
            public object Clone() { return this.MemberwiseClone(); }
            [Reader.LookupType(typeof(Skills.skill))]
            [TypeConverter(typeof(LookupIdConverter))]
            public int id_skill { get; set; }
            public int level { get; set; }

            public override string ToString()
            {
                return $"{id_skill} - {level}";
            }
        }
    }
}
