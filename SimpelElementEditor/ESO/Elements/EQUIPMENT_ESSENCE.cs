using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace SimpelElementEditor.ESO.Elements
{
    public class EQUIPMENT_ESSENCE : ICloneable
    {
        public int id { get; set; }

        [Reader.LookupType(typeof(EQUIPMENT_MAJOR_TYPE))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int id_major_type { get; set; }

        [Reader.LookupType(typeof(EQUIPMENT_SUB_TYPE))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int id_sub_type { get; set; }
        public string name { get; set; }
        public int equip_type { get; set; }
        [Editor(typeof(COMMON.FlagsEnumEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public COMMON.EquipInventoryItemType equip_mask { get; set; }

        [Reader.LookupType(typeof(PathData.path))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int file_model_male { get; set; }

        [Reader.LookupType(typeof(PathData.path))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int file_model_female { get; set; }

        [Reader.LookupType(typeof(PathData.path))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int file_model_male_l { get; set; }

        [Reader.LookupType(typeof(PathData.path))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int file_model_female_l { get; set; }

        [Reader.LookupType(typeof(PathData.path))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int file_matter { get; set; }

        [Reader.LookupType(typeof(PathData.path))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int file_icon { get; set; }
        public int equip_location { get; set; }
        public int action_type { get; set; }
        public int show_type { get; set; }

        [Reader.FixedArrayLengthAttribute(32)]
        public string show_level { get; set; }
        public int level { get; set; }
        [Editor(typeof(COMMON.FlagsEnumEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public COMMON.CharacterClassFlags character_combo_id { get; set; }
        [Editor(typeof(COMMON.FlagsEnumEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public COMMON.GenderFlags require_gender { get; set; }
        public int require_level { get; set; }
        public int sect_mask { get; set; }
        public int require_level2 { get; set; }
        [Editor(typeof(COMMON.FlagsEnumEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public COMMON.RaceFlags race_mask { get; set; }
        public int hp { get; set; }
        public int mp { get; set; }
        public int min_phy_dmg { get; set; }
        public int max_phy_dmg { get; set; }
        public int min_magic_dmg { get; set; }
        public int max_magic_dmg { get; set; }
        public int phy_defence { get; set; }
        public int magic_defence { get; set; }
        public int attack { get; set; }
        public int armor { get; set; }
        public float attack_range { get; set; }
        [TypeConverter(typeof(MoneyConverter))]
        public int price { get; set; }
        [TypeConverter(typeof(MoneyConverter))]
        public int shop_price { get; set; }
        [Reader.LookupType(typeof(EQUIPMENT_ADDON))]
        [TypeConverter(typeof(LookupIdConverter))]

        public int id_addon1 { get; set; }
        [Reader.LookupType(typeof(EQUIPMENT_ADDON))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int id_addon2 { get; set; }
        [Reader.LookupType(typeof(EQUIPMENT_ADDON))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int id_addon3 { get; set; }
        [Reader.LookupType(typeof(EQUIPMENT_ADDON))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int id_addon4 { get; set; }
        [Reader.LookupType(typeof(EQUIPMENT_ADDON))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int id_addon5 { get; set; }
        [Reader.LookupType(typeof(EQUIPMENT_RANDOM_ADDONSGROUP))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int id_rand_addonsgroup1 { get; set; }
        [Reader.LookupType(typeof(EQUIPMENT_RANDOM_ADDONSGROUP))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int id_rand_addonsgroup2 { get; set; }
        [Reader.LookupType(typeof(EQUIPMENT_RANDOM_ADDONSGROUP))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int id_rand_addonsgroup3 { get; set; }
        [Reader.LookupType(typeof(EQUIPMENT_RANDOM_ADDONSGROUP))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int id_rand_addonsgroup4 { get; set; }
        [Reader.LookupType(typeof(EQUIPMENT_RANDOM_ADDONSGROUP))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int id_rand_addonsgroup5 { get; set; }
        [TypeConverter(typeof(MoneyConverter))]
        public int fee_estone { get; set; }
        [TypeConverter(typeof(MoneyConverter))]
        public int fee_install_pstone { get; set; }
        [TypeConverter(typeof(MoneyConverter))]
        public int fee_UNinstall_pstone { get; set; }
        [TypeConverter(typeof(MoneyConverter))]
        public int fee_install_sstone { get; set; }
        [TypeConverter(typeof(MoneyConverter))]
        public int fee_UNinstall_sstone { get; set; }
        [Reader.LookupType(typeof(ESTONE_ESSENCE))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int id_estone { get; set; }
        public int addon_prop { get; set; }
        public float basic_rank { get; set; }

        
        [Reader.FixedArrayLengthAttribute(20)]
        public int[] ehanced_value { get; set; }
        /*public int ehanced_value_2 { get; set; }
        public int ehanced_value_3 { get; set; }
        public int ehanced_value_4 { get; set; }
        public int ehanced_value_5 { get; set; }
        public int ehanced_value_6 { get; set; }
        public int ehanced_value_7 { get; set; }
        public int ehanced_value_8 { get; set; }
        public int ehanced_value_9 { get; set; }
        public int ehanced_value_10 { get; set; }
        public int ehanced_value_11 { get; set; }
        public int ehanced_value_12 { get; set; }
        public int ehanced_value_13 { get; set; }
        public int ehanced_value_14 { get; set; }
        public int ehanced_value_15 { get; set; }
        public int ehanced_value_16 { get; set; }
        public int ehanced_value_17 { get; set; }
        public int ehanced_value_18 { get; set; }
        public int ehanced_value_19 { get; set; }
        public int ehanced_value_20 { get; set; }*/
        public int basic_show_level { get; set; }
        public int pstone_num { get; set; }
        public int pstone_num_var { get; set; }
        public COMMON.BOOL can_upgrade { get; set; }
        [Reader.LookupType(typeof(EQUIPMENT_UPGRADE_ESSENCE))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int id_upgrade { get; set; }
        [TypeConverter(typeof(IntStringListConverter))]
        [IntStringList(nameof(DataFiles.SkillsTemplate))]
        public int addon_skill1 { get; set; }
        [TypeConverter(typeof(IntStringListConverter))]
        [IntStringList(nameof(DataFiles.SkillsTemplate))]
        public int addon_skill2 { get; set; }
        [TypeConverter(typeof(ItemIdConverter))]
        public int suite_cond_1 { get; set; }
        [TypeConverter(typeof(ItemIdConverter))]
        public int suite_cond_2 { get; set; }
        [TypeConverter(typeof(ItemIdConverter))]
        public int suite_cond_3 { get; set; }
        [TypeConverter(typeof(ItemIdConverter))]
        public int suite_cond_4 { get; set; }
        [TypeConverter(typeof(ItemIdConverter))]
        public int suite_cond_5 { get; set; }
        [TypeConverter(typeof(ItemIdConverter))]
        public int suite_cond_6 { get; set; }
        [TypeConverter(typeof(ItemIdConverter))]
        public int suite_cond_7 { get; set; }
        [TypeConverter(typeof(ItemIdConverter))]
        public int suite_cond_8 { get; set; }
        [Reader.LookupType(typeof(EQUIPMENT_ADDON))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int suite_ext_prop_1 { get; set; }
        [Reader.LookupType(typeof(EQUIPMENT_ADDON))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int suite_ext_prop_2 { get; set; }
        [Reader.LookupType(typeof(EQUIPMENT_ADDON))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int suite_ext_prop_3 { get; set; }
        [Reader.LookupType(typeof(EQUIPMENT_ADDON))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int suite_ext_prop_4 { get; set; }
        [Reader.LookupType(typeof(EQUIPMENT_ADDON))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int suite_ext_prop_5 { get; set; }
        public int added_level_require { get; set; }
        public int gen_estone_max { get; set; }
        public int gen_estone_min { get; set; }
        public COMMON.BOOL can_install_hole { get; set; }
        public int max_hole_num { get; set; }
        [Reader.LookupType(typeof(TASKNORMALMATTER_ESSENCE))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int item_install_hole { get; set; }
        public COMMON.BOOL can_add_rune { get; set; }
        public int pile_num_max { get; set; }
        [Editor(typeof(COMMON.FlagsEnumEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public COMMON.ProcTypeFlags proc_type { get; set; }
        public object Clone() { return this.MemberwiseClone(); }

        public override string ToString()
        {
            return $"{id}: {name}";
        }
    }
}
