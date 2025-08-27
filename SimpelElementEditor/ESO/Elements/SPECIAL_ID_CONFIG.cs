using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace SimpelElementEditor.ESO.Elements
{
    public class SPECIAL_ID_CONFIG : ICloneable
    {
        public object Clone() { return this.MemberwiseClone(); }
        public int id { get; set; }
        public string name { get; set; }
        public int version { get; set; }
        public float monster_drop_prob { get; set; }
        [TypeConverter(typeof(ItemIdConverter))]
        public int id_money_matter { get; set; }
        [TypeConverter(typeof(ItemIdConverter))]
        public int id_speaker { get; set; }
        [TypeConverter(typeof(ItemIdConverter))]
        public int id_destroying_matter { get; set; }
        [TypeConverter(typeof(ItemIdConverter))]
        public int id_townscroll { get; set; }
        public int id_attacker_droptable { get; set; }
        public int id_defender_droptable { get; set; }
        [TypeConverter(typeof(ItemIdConverter))]
        public int id_talisman_reset_matter { get; set; }
        public int fee_talisman_merge { get; set; }
        public int fee_talisman_enchant { get; set; }
        public int fee_pet_adopt { get; set; }
        public int fee_pet_identify { get; set; }
        public int fee_pet_resurrect { get; set; }
        public int fee_pet_reborn { get; set; }
        public int pk_tran_value { get; set; }
        public float pk_tran_pos_x { get; set; }
        public float pk_tran_pos_y { get; set; }
        public float pk_tran_pos_z { get; set; }
        public int pk_curse_id { get; set; }
        [TypeConverter(typeof(ItemIdConverter))]
        public int pet_adopt_scroll { get; set; }
        [TypeConverter(typeof(ItemIdConverter))]
        public int pet_identify_scroll_1 { get; set; }
        [TypeConverter(typeof(ItemIdConverter))]
        public int pet_identify_scroll_2 { get; set; }
        [TypeConverter(typeof(ItemIdConverter))]
        public int pet_identify_scroll_3 { get; set; }
        [TypeConverter(typeof(ItemIdConverter))]
        public int pet_identify_scroll_4 { get; set; }
        [TypeConverter(typeof(ItemIdConverter))]
        public int pet_identify_scroll_5 { get; set; }
        [TypeConverter(typeof(ItemIdConverter))]
        public int pet_revive_scroll { get; set; }
        [TypeConverter(typeof(ItemIdConverter))]
        public int id_pet_pack_expand { get; set; }
        [TypeConverter(typeof(ItemIdConverter))]
        public int id_pet_skill_pack_expand { get; set; }
        [TypeConverter(typeof(ItemIdConverter))]
        public int id_pet_num_expand { get; set; }
        [TypeConverter(typeof(ItemIdConverter))]
        public int id_pet_bind { get; set; }
        [TypeConverter(typeof(ItemIdConverter))]
        public int id_pet_combine_num_expand { get; set; }
        [TypeConverter(typeof(ItemIdConverter))]
        public int id_pet_forget_skill { get; set; }
        public int fee_pet_rename { get; set; }
        public int fee_pet_eat_item { get; set; }
        public int fee_pet_merge { get; set; }
        public int fee_pet_bine { get; set; }
        public int fee_pet_marriage { get; set; }
        [TypeConverter(typeof(ItemIdConverter))]
        public int id_pet_eat_item { get; set; }
        [TypeConverter(typeof(ItemIdConverter))]
        public int id_pet_merge { get; set; }
        [TypeConverter(typeof(ItemIdConverter))]
        public int id_pet_marriage { get; set; }
        [TypeConverter(typeof(ItemIdConverter))]
        public int id_special_pack_item_1 { get; set; }
        [TypeConverter(typeof(ItemIdConverter))]
        public int id_special_pack_item_2 { get; set; }
        [TypeConverter(typeof(ItemIdConverter))]
        public int id_special_pack_item_3 { get; set; }
        [TypeConverter(typeof(ItemIdConverter))]
        public int id_special_pack_item_4 { get; set; }
        [TypeConverter(typeof(ItemIdConverter))]
        public int id_fast_summon_item1 { get; set; }
        [TypeConverter(typeof(ItemIdConverter))]
        public int id_fast_summon_item2 { get; set; }
        [TypeConverter(typeof(ItemIdConverter))]
        public int id_fast_combine_item1 { get; set; }
        [TypeConverter(typeof(ItemIdConverter))]
        public int id_fast_combine_item2 { get; set; }
        [Reader.LookupType(typeof(SPEAKER_LEVEL_NUM_CONFIG))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int id_speaker_level_num_config { get; set; }
        [Reader.LookupType(typeof(SPEAKER_NUM_MONEY_CONFIG))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int id_speaker_num_money_config { get; set; }

        [Reader.LookupType(typeof(BIRTH_SKILL_CANDIDATE))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int id_birthskill_candidate_config { get; set; }

        [Reader.LookupType(typeof(GARDEN_EXCHANGE_CONFIG))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int id_garden_item_exchg_config { get; set; }
        [TypeConverter(typeof(ItemIdConverter))]
        public int id_carryon_BAGUA_consume { get; set; }



        public override string ToString()
        {
            return $"{id}: {name}";
        }
    }
}
