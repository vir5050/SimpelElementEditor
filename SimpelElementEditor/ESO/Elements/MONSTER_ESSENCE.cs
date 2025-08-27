using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace SimpelElementEditor.ESO.Elements
{
    public class MONSTER_ESSENCE : ICloneable
    {
        public object Clone() { return this.MemberwiseClone(); }
        public int id { get; set; } = 0;

        [Reader.LookupType(typeof(MONSTER_TYPE))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int id_type { get; set; }
        public string name { get; set; }
        [Reader.FixedArrayLengthAttribute(32)]
        public string prop { get; set; }
        [Reader.FixedArrayLengthAttribute(32)]
        public string desc { get; set; }
        public int faction { get; set; }
        public int enemy_faction { get; set; }
        public int monster_faction { get; set; }
        public int monster_race { get; set; }

        [Reader.LookupType(typeof(PathData.path))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int file_model { get; set; }
        public float size { get; set; }
        public int name_color { get; set; }
        public int id_strategy { get; set; }
        public int level { get; set; }
        public int show_level { get; set; }
        public COMMON.BOOL is_boss { get; set; }
        public int killed_exp { get; set; }
        public int killed_drop { get; set; }
        public int immune_type { get; set; }
        public int show_as_flag { get; set; }
        public float sight_range { get; set; }
        public float attack_range { get; set; }
        public COMMON.BOOL aggressive_mode { get; set; }
        public int monster_faction_ask_help { get; set; }
        public int monster_faction_can_help { get; set; }
        public float aggro_range { get; set; }
        public float aggro_time { get; set; }
        public float dead_aggro_time { get; set; }
        public int patroll_mode { get; set; }
        public int stand_mode { get; set; }
        public int inhabit_type { get; set; }
        public float walk_speed { get; set; }
        public float run_speed { get; set; }
        //[Reader.LookupType(typeof(aiPolicy.CPolicyData))]
        //[TypeConverter(typeof(LookupIdConverter))]
        public int common_strategy { get; set; }
        public int after_death { get; set; }
        public int exp { get; set; }
        public int _sp { get; set; }
        public int money_average { get; set; }
        public int money_var { get; set; }
        public int hp { get; set; }
        public int mp { get; set; }
        public int faint { get; set; }
        public int phy_dmg { get; set; }
        public int magic_dmg { get; set; }
        public int phy_defense { get; set; }
        public int magic_defense { get; set; }
        public int extra_damage { get; set; }
        public int extra_defence { get; set; }
        public int attack { get; set; }
        public int armor { get; set; }
        public float phy_crit_rate { get; set; }
        public float phy_crit_damage { get; set; }
        public float magic_crit_rate { get; set; }
        public float magic_crit_damage { get; set; }
        public int adjust_gold { get; set; }
        public int adjust_wood { get; set; }
        public int adjust_water { get; set; }
        public int adjust_fire { get; set; }
        public int adjust_earth { get; set; }
        public int adjust_none { get; set; }
        public int adjust_phy { get; set; }
        public int hp_gen1 { get; set; }
        public int hp_gen2 { get; set; }
        public int mp_gen1 { get; set; }
        public int mp_gen2 { get; set; }
        public int faint_gen_time { get; set; }
        public int faint_gen_speed { get; set; }
        public int role_in_war { get; set; }
        public int drop_times { get; set; }

        [Reader.LookupType(typeof(DROPTABLE_ESSENCE))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int id_drop_table { get; set; }
        [Reader.LookupType(typeof(Skills.skill))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int attack_skill { get; set; }
        [Reader.FixedArrayLengthAttribute(32)]
        public SKILLS[] skills { get; set; }
        public float capture_prob { get; set; }
        [Reader.FixedArrayLengthAttribute(2)]
        public CAPTURES[] captures { get; set; }
        public COMMON.BOOL can_capture { get; set; }
        [Reader.LookupType(typeof(Skills.skill))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int inborn_skill { get; set; }
        public float capture_hp_ratio { get; set; }
        public int not_attack_player { get; set; }
        public int use_target_list { get; set; }
        [Reader.FixedArrayLengthAttribute(32)]
        public int[] target_list { get; set; }
        public int highest_frequency { get; set; }
        public int score { get; set; }
        [Reader.FixedArrayLengthAttribute(4)]
        public KILLED_REPU[] killed_repu { get; set; }
        public int anti_gold1 { get; set; }
        public int anti_wood1 { get; set; }
        public int anti_water1 { get; set; }
        public int anti_fire1 { get; set; }
        public int anti_earth1 { get; set; }
        public int anti_phy1 { get; set; }
        public int anti_none1 { get; set; }
        public float anti_phy_crit_rate { get; set; }
        public float anti_phy_crit_damage { get; set; }
        public float anti_magic_crit_rate { get; set; }
        public float anti_magic_crit_damage { get; set; }
        public float poison_rate { get; set; }
        public float injure_rate { get; set; }
        public float stun_rate { get; set; }
        public float sleep_rate { get; set; }
        public float immobilise_rate { get; set; }
        public float slow_rate { get; set; }
        public float silence_rate { get; set; }
        public float blind_rate { get; set; }
        public float weaken_rate { get; set; }
        public float immunity_rate { get; set; }
        public float beatback_rate { get; set; }
        public float reserve_rate { get; set; }
        public float anti_poison_rate { get; set; }
        public float anti_injure_rate { get; set; }
        public float anti_stun_rate { get; set; }
        public float anti_sleep_rate { get; set; }
        public float anti_immobilise_rate { get; set; }
        public float anti_slow_rate { get; set; }
        public float anti_silence_rate { get; set; }
        public float anti_blind_rate { get; set; }
        public float anti_weaken_rate { get; set; }
        public float anti_immunity_rate { get; set; }
        public float anti_beatback_rate { get; set; }
        public float anti_reserve_rate { get; set; }
        [Reader.FixedArrayLengthAttribute(4)]
        public KILLED_REPU_LIMIT[] killed_repu_limit { get; set; }
        public float battle_point_deduct { get; set; }
        public float monster_class { get; set; }

        public override string ToString()
        {
            return $"{id}: {name}";
        }

        public class SKILLS : ICloneable
        {
            public object Clone() { return this.MemberwiseClone(); }
            [Reader.LookupType(typeof(Skills.skill))]
            [TypeConverter(typeof(LookupIdConverter))]
            public int id_skill { get; set; } = 0;
            public int level { get; set; }

            public override string ToString()
            {
                return $"{id_skill}: {level}";
            }
        }

        public class CAPTURES : ICloneable
        {
            public object Clone() { return this.MemberwiseClone(); }

            [Reader.LookupType(typeof(PET_BEDGE_ESSENCE))]
            [TypeConverter(typeof(LookupIdConverter))]
            public int id { get; set; } = 0;
            public float prob { get; set; }

            public override string ToString()
            {
                return $"{id}: {prob * 100}%";
            }
        }
        public class KILLED_REPU : ICloneable
        {
            public object Clone() { return this.MemberwiseClone(); }
            public int killed_num { get; set; }
            public COMMON.REPU_TYPE repu_type { get; set; }
            public int repu_val { get; set; }

            public override string ToString()
            {
                return $"{repu_type}";
            }
        }
        public class KILLED_REPU_LIMIT : ICloneable
        {
            public object Clone() { return this.MemberwiseClone(); }
            public COMMON.REPU_TYPE type { get; set; }
            public int limit_value { get; set; }
            public float limit_counter { get; set; }
            public int value { get; set; }

            public override string ToString()
            {
                return $"{type}";
            }
        }
    }
}
