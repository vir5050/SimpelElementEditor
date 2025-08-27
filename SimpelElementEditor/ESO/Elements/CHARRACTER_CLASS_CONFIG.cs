using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace SimpelElementEditor.ESO.Elements
{
    public class CHARRACTER_CLASS_CONFIG : ICloneable //typo is not on me!
    {
        public object Clone() { return this.MemberwiseClone(); }
        public int id { get; set; } = 0;
        public string name { get; set; }
        public int character_class_id { get; set; }
        public int faction { get; set; }
        public int enemy_faction { get; set; }
        public int level_required { get; set; }
        public int sect_mask { get; set; }
        public int level2 { get; set; }
        [TypeConverter(typeof(IntStringListConverter))]
        [IntStringList(nameof(DataFiles.SkillsTemplate))]
        public int attack_skill_id { get; set; }
        public float attack_range { get; set; }
        public float pet_rank_value { get; set; }
        public int pet_adapt { get; set; }
        public int hp { get; set; }
        public int mp { get; set; }
        public int anger { get; set; }
        public int vp { get; set; }
        public int faint { get; set; }
        public int phy_dmg { get; set; }
        public int magic_dmg { get; set; }
        public int phy_defense { get; set; }
        public int magic_defense { get; set; }
        public int attack { get; set; }
        public int armor { get; set; }
        public float phy_crit_rate { get; set; }
        public float phy_crit_damage { get; set; }
        public float magic_crit_rate { get; set; }
        public float magic_crit_damage { get; set; }
        public int anti_phy { get; set; }
        public int anti_gold { get; set; }
        public int anti_wood { get; set; }
        public int anti_water { get; set; }
        public int anti_fire { get; set; }
        public int anti_earth { get; set; }
        public int anti_none { get; set; }
        public int vitality { get; set; }
        public int intelligence { get; set; }
        public int strength { get; set; }
        public int agility { get; set; }
        public int p5th { get; set; }
        public float lvlup_pet_adapt { get; set; }
        public float lvlup_pet_rank_value { get; set; }
        public float lvlup_hp { get; set; }
        public float lvlup_mp { get; set; }
        public float lvlup_anger { get; set; }
        public float lvlup_vp { get; set; }
        public float lvlup_faint { get; set; }
        public float lvlup_phy_dmg { get; set; }
        public float lvlup_magic_dmg { get; set; }
        public float lvlup_phy_defense { get; set; }
        public float lvlup_magic_defense { get; set; }
        public float lvlup_attack { get; set; }
        public float lvlup_armor { get; set; }
        public float lvlup_phy_crit_rate { get; set; }
        public float lvlup_phy_crit_damage { get; set; }
        public float lvlup_magic_crit_rate { get; set; }
        public float lvlup_magic_crit_damage { get; set; }
        public float lvlup_anti_phy { get; set; }
        public float lvlup_anti_gold { get; set; }
        public float lvlup_anti_wood { get; set; }
        public float lvlup_anti_water { get; set; }
        public float lvlup_anti_fire { get; set; }
        public float lvlup_anti_earth { get; set; }
        public float lvlup_anti_none { get; set; }
        public float walk_speed { get; set; }
        public float run_speed { get; set; }
        public float riding_speed { get; set; }
        public int hp_gen1 { get; set; }
        public int hp_gen2 { get; set; }
        public int hp_gen3 { get; set; }
        public int hp_gen4 { get; set; }
        public int mp_gen1 { get; set; }
        public int mp_gen2 { get; set; }
        public int mp_gen3 { get; set; }
        public int mp_gen4 { get; set; }
        public int anger_gen1 { get; set; }
        public int anger_gen2 { get; set; }
        public int vp_gen_time { get; set; }
        public float vp_gen_speed { get; set; }
        public int faint_gen_time { get; set; }
        public float faint_gen_speed { get; set; }
        public int player_status_point_id { get; set; }
        public int character_combo_id { get; set; }
        public int p6th { get; set; }
        public int p7th { get; set; }
        public int p8th { get; set; }
        public int p9th { get; set; }
        public int p10th { get; set; }
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
        public float lvlup_anti_gold1 { get; set; }
        public float lvlup_anti_wood1 { get; set; }
        public float lvlup_anti_water1 { get; set; }
        public float lvlup_anti_fire1 { get; set; }
        public float lvlup_anti_earth1 { get; set; }
        public float lvlup_anti_phy1 { get; set; }
        public float lvlup_anti_none1 { get; set; }
        public float lvlup_anti_phy_crit_rate { get; set; }
        public float lvlup_anti_phy_crit_damage { get; set; }
        public float lvlup_anti_magic_crit_rate { get; set; }
        public float lvlup_anti_magic_crit_damage { get; set; }
        public float lvlup_poison_rate { get; set; }
        public float lvlup_injure_rate { get; set; }
        public float lvlup_stun_rate { get; set; }
        public float lvlup_sleep_rate { get; set; }
        public float lvlup_immobilise_rate { get; set; }
        public float lvlup_slow_rate { get; set; }
        public float lvlup_silence_rate { get; set; }
        public float lvlup_blind_rate { get; set; }
        public float lvlup_weaken_rate { get; set; }
        public float lvlup_immunity_rate { get; set; }
        public float lvlup_beatback_rate { get; set; }
        public float lvlup_reserve_rate { get; set; }
        public float lvlup_anti_poison_rate { get; set; }
        public float lvlup_anti_injure_rate { get; set; }
        public float lvlup_anti_stun_rate { get; set; }
        public float lvlup_anti_sleep_rate { get; set; }
        public float lvlup_anti_immobilise_rate { get; set; }
        public float lvlup_anti_slow_rate { get; set; }
        public float lvlup_anti_silence_rate { get; set; }
        public float lvlup_anti_blind_rate { get; set; }
        public float lvlup_anti_weaken_rate { get; set; }
        public float lvlup_anti_immunity_rate { get; set; }
        public float lvlup_anti_beatback_rate { get; set; }
        public float lvlup_anti_reserve_rate { get; set; }

        public override string ToString()
        {
            return $"{id}: {name}";
        }
    }
}
