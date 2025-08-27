using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.ComponentModel;
using SimpelElementEditor.COMMON;

namespace SimpelElementEditor.ESO.Elements
{
    public class ElementsTemplate : ICloneable
    {
        public int magic { get; set; }
        public DateTime timestamp { get; set; }
        public List<EQUIPMENT_ADDON> EQUIPMENT_ADDON { get; set; } = new List<EQUIPMENT_ADDON>();
        public List<EQUIPMENT_MAJOR_TYPE> EQUIPMENT_MAJOR_TYPE { get; set; } = new List<EQUIPMENT_MAJOR_TYPE>();
        public List<EQUIPMENT_SUB_TYPE> EQUIPMENT_SUB_TYPE { get; set; } = new List<EQUIPMENT_SUB_TYPE>();
        public List<EQUIPMENT_ESSENCE> EQUIPMENT_ESSENCE { get; set; } = new List<EQUIPMENT_ESSENCE>();
        public List<MEDICINE_MAJOR_TYPE> MEDICINE_MAJOR_TYPE { get; set; } = new List<MEDICINE_MAJOR_TYPE>();
        public List<MEDICINE_SUB_TYPE> MEDICINE_SUB_TYPE { get; set; } = new List<MEDICINE_SUB_TYPE>();
        public List<MEDICINE_ESSENCE> MEDICINE_ESSENCE { get; set; } = new List<MEDICINE_ESSENCE>();
        public List<MATERIAL_MAJOR_TYPE> MATERIAL_MAJOR_TYPE { get; set; } = new List<MATERIAL_MAJOR_TYPE>();
        public List<MATERIAL_SUB_TYPE> MATERIAL_SUB_TYPE { get; set; } = new List<MATERIAL_SUB_TYPE>();
        public List<MATERIAL_ESSENCE> MATERIAL_ESSENCE { get; set; } = new List<MATERIAL_ESSENCE>();
        public List<REFINE_TICKET_ESSENCE> REFINE_TICKET_ESSENCE { get; set; } = new List<REFINE_TICKET_ESSENCE>();
        public List<SKILLTOME_SUB_TYPE> SKILLTOME_SUB_TYPE { get; set; } = new List<SKILLTOME_SUB_TYPE>();
        public List<SKILLTOME_ESSENCE> SKILLTOME_ESSENCE { get; set; } = new List<SKILLTOME_ESSENCE>();
        public List<TRANSMITROLL_ESSENCE> TRANSMITROLL_ESSENCE { get; set; } = new List<TRANSMITROLL_ESSENCE>();
        public List<LUCKYROLL_ESSENCE> LUCKYROLL_ESSENCE { get; set; } = new List<LUCKYROLL_ESSENCE>();
        public List<TOWNSCROLL_ESSENCE> TOWNSCROLL_ESSENCE { get; set; } = new List<TOWNSCROLL_ESSENCE>();
        public List<REVIVESCROLL_ESSENCE> REVIVESCROLL_ESSENCE { get; set; } = new List<REVIVESCROLL_ESSENCE>();
        public List<TASKMATTER_ESSENCE> TASKMATTER_ESSENCE { get; set; } = new List<TASKMATTER_ESSENCE>();
        public List<DROPTABLE_TYPE> DROPTABLE_TYPE { get; set; } = new List<DROPTABLE_TYPE>();
        public List<DROPTABLE_ESSENCE> DROPTABLE_ESSENCE { get; set; } = new List<DROPTABLE_ESSENCE>();

        [Reader.FixedArrayLengthAttribute(8)]
        public byte[] md5pos0 { get; set; }
        public List<MONSTER_TYPE> MONSTER_TYPE { get; set; } = new List<MONSTER_TYPE>();
        public List<MONSTER_ESSENCE> MONSTER_ESSENCE { get; set; } = new List<MONSTER_ESSENCE>();
        public List<EQUIPMENT_UPGRADE_ESSENCE> EQUIPMENT_UPGRADE_ESSENCE { get; set; } = new List<EQUIPMENT_UPGRADE_ESSENCE>();
        public List<AIRCRAFT_ESSENCE> AIRCRAFT_ESSENCE { get; set; } = new List<AIRCRAFT_ESSENCE>();
        public List<CHANGE_SHAPE_ESSENCE> CHANGE_SHAPE_ESSENCE { get; set; } = new List<CHANGE_SHAPE_ESSENCE>();
        public List<SUMMON_MONSTER_ESSENCE> SUMMON_MONSTER_ESSENCE { get; set; } = new List<SUMMON_MONSTER_ESSENCE>();
        public List<PET_BEDGE_ESSENCE> PET_BEDGE_ESSENCE { get; set; } = new List<PET_BEDGE_ESSENCE>();
        public List<PET_FOOD_ESSENCE> PET_FOOD_ESSENCE { get; set; } = new List<PET_FOOD_ESSENCE>();
        public List<PET_SKILL_ESSENCE> PET_SKILL_ESSENCE { get; set; } = new List<PET_SKILL_ESSENCE>();
        public List<PET_ARMOR_ESSENCE> PET_ARMOR_ESSENCE { get; set; } = new List<PET_ARMOR_ESSENCE>();
        public List<MERGE_RECIPE_ESSENCE> MERGE_RECIPE_ESSENCE { get; set; } = new List<MERGE_RECIPE_ESSENCE>();
        public List<NPC_HOTEL_SERVICE> NPC_HOTEL_SERVICE { get; set; } = new List<NPC_HOTEL_SERVICE>();
        public List<PRODUCE_TYPE_CONFIG> PRODUCE_TYPE_CONFIG { get; set; } = new List<PRODUCE_TYPE_CONFIG>();
        public List<NPC_LEARN_PRODUCE_SERVICE> NPC_LEARN_PRODUCE_SERVICE { get; set; } = new List<NPC_LEARN_PRODUCE_SERVICE>();
        public List<AI_HELPER_ESSENCE> AI_HELPER_ESSENCE { get; set; } = new List<AI_HELPER_ESSENCE>();
        public List<PET_PRODUCE_ESSENCE> PET_PRODUCE_ESSENCE { get; set; } = new List<PET_PRODUCE_ESSENCE>();
        public List<PET_MERGE_ESSENCE> PET_MERGE_ESSENCE { get; set; } = new List<PET_MERGE_ESSENCE>();
        public List<CHANGE_RECOVER_ESSENCE> CHANGE_RECOVER_ESSENCE { get; set; } = new List<CHANGE_RECOVER_ESSENCE>();
        public List<HATCHER_MAJOR_TYPE> HATCHER_MAJOR_TYPE { get; set; } = new List<HATCHER_MAJOR_TYPE>();
        public List<HATCHER_ESSENCE> HATCHER_ESSENCE { get; set; } = new List<HATCHER_ESSENCE>();
        public List<BOOK_ESSENCE> BOOK_ESSENCE { get; set; } = new List<BOOK_ESSENCE>();
        public List<SPECIAL_SPEAKER_ESSENCE> SPECIAL_SPEAKER_ESSENCE { get; set; } = new List<SPECIAL_SPEAKER_ESSENCE>();
        public List<GARDEN_ESSENCE> GARDEN_ESSENCE { get; set; } = new List<GARDEN_ESSENCE>();
        public List<GARDEN_ORNAMENT_ESSENCE> GARDEN_ORNAMENT_ESSENCE { get; set; } = new List<GARDEN_ORNAMENT_ESSENCE>();
        public List<SEED_ESSENCE> SEED_ESSENCE { get; set; } = new List<SEED_ESSENCE>();
        public List<FRUIT_ESSENCE> FRUIT_ESSENCE { get; set; } = new List<FRUIT_ESSENCE>();
        public List<PETBOX_EXPLIST_CONFIG> PETBOX_EXPLIST_CONFIG { get; set; } = new List<PETBOX_EXPLIST_CONFIG>();
        public List<GARDEN_TOOL_ESSENCE> GARDEN_TOOL_ESSENCE { get; set; } = new List<GARDEN_TOOL_ESSENCE>(); 
        public List<GARDEN_FUNC_ESSENCE> GARDEN_FUNC_ESSENCE { get; set; } = new List<GARDEN_FUNC_ESSENCE>();
        public List<GARDEN_AWARD> GARDEN_AWARD { get; set; } = new List<GARDEN_AWARD>();
        public List<SPEAKER_LEVEL_NUM_CONFIG> SPEAKER_LEVEL_NUM_CONFIG { get; set; } = new List<SPEAKER_LEVEL_NUM_CONFIG>();
        public List<SPEAKER_NUM_MONEY_CONFIG> SPEAKER_NUM_MONEY_CONFIG { get; set; } = new List<SPEAKER_NUM_MONEY_CONFIG>();
        public List<BIRTHSKILL_RESET_SERVICE> BIRTHSKILL_RESET_SERVICE { get; set; } = new List<BIRTHSKILL_RESET_SERVICE>();
        public List<BIRTH_SKILL_CANDIDATE> BIRTH_SKILL_CANDIDATE { get; set; } = new List<BIRTH_SKILL_CANDIDATE>(); 
        public List<UPGRADE_TRANSFER_SERVICE> UPGRADE_TRANSFER_SERVICE { get; set; } = new List<UPGRADE_TRANSFER_SERVICE>(); 
        public List<GARDEN_EXCHANGE_CONFIG> GARDEN_EXCHANGE_CONFIG { get; set; } = new List<GARDEN_EXCHANGE_CONFIG>(); 
        public List<RUNE_COMBINATION_CONFIG> RUNE_COMBINATION_CONFIG { get; set; } = new List<RUNE_COMBINATION_CONFIG>();
        public List<NPC_SUPER_UPGRADE_SERVICE> NPC_SUPER_UPGRADE_SERVICE { get; set; } = new List<NPC_SUPER_UPGRADE_SERVICE>();
        public List<RUNE_ESSENCE> RUNE_ESSENCE { get; set; } = new List<RUNE_ESSENCE>();
        public List<EQUIPMENT_EXCHANGE_CONFIG> EQUIPMENT_EXCHANGE_CONFIG { get; set; } = new List<EQUIPMENT_EXCHANGE_CONFIG>();
        public int tag { get; set; }
        public byte[] data { get; set; }
        public DateTime t { get; set; }
        public List<NPC_TALK_SERVICE> NPC_TALK_SERVICE { get; set; } = new List<NPC_TALK_SERVICE>();
        public List<NPC_SELL_SERVICE> NPC_SELL_SERVICE { get; set; } = new List<NPC_SELL_SERVICE>();
        public List<NPC_BUY_SERVICE> NPC_BUY_SERVICE { get; set; } = new List<NPC_BUY_SERVICE>();
        public List<NPC_TASK_IN_SERVICE> NPC_TASK_IN_SERVICE { get; set; } = new List<NPC_TASK_IN_SERVICE>();
        public List<NPC_TASK_OUT_SERVICE> NPC_TASK_OUT_SERVICE { get; set; } = new List<NPC_TASK_OUT_SERVICE>();
        public List<NPC_TASK_MATTER_SERVICE> NPC_TASK_MATTER_SERVICE { get; set; } = new List<NPC_TASK_MATTER_SERVICE>();
        public List<NPC_HEAL_SERVICE> NPC_HEAL_SERVICE { get; set; } = new List<NPC_HEAL_SERVICE>();
        public List<NPC_TRANSMIT_SERVICE> NPC_TRANSMIT_SERVICE { get; set; } = new List<NPC_TRANSMIT_SERVICE>();
        public List<NPC_PROXY_SERVICE> NPC_PROXY_SERVICE { get; set; } = new List<NPC_PROXY_SERVICE>();
        public List<NPC_STORAGE_SERVICE> NPC_STORAGE_SERVICE { get; set; } = new List<NPC_STORAGE_SERVICE>(); 
        public List<NPC_TYPE> NPC_TYPE { get; set; } = new List<NPC_TYPE>();
        public List<NPC_ESSENCE> NPC_ESSENCE { get; set; } = new List<NPC_ESSENCE>();
        public List<RECIPE_MAJOR_TYPE> RECIPE_MAJOR_TYPE { get; set; } = new List<RECIPE_MAJOR_TYPE>();
        public List<RECIPE_SUB_TYPE> RECIPE_SUB_TYPE { get; set; } = new List<RECIPE_SUB_TYPE>();
        public List<RECIPE_ESSENCE> RECIPE_ESSENCE { get; set; } = new List<RECIPE_ESSENCE>(); 
        public List<ENEMY_FACTION_CONFIG> ENEMY_FACTION_CONFIG { get; set; } = new List<ENEMY_FACTION_CONFIG>();
        public List<CHARRACTER_CLASS_CONFIG> CHARRACTER_CLASS_CONFIG { get; set; } = new List<CHARRACTER_CLASS_CONFIG>();
        public byte[] md5pos1 { get; set; }
        public List<PARAM_ADJUST_CONFIG> PARAM_ADJUST_CONFIG { get; set; } = new List<PARAM_ADJUST_CONFIG>();
        public List<TASKDICE_ESSENCE> TASKDICE_ESSENCE { get; set; } = new List<TASKDICE_ESSENCE>();
        public List<TASKNORMALMATTER_ESSENCE> TASKNORMALMATTER_ESSENCE { get; set; } = new List<TASKNORMALMATTER_ESSENCE>();
        public List<MINE_TYPE> MINE_TYPE { get; set; } = new List<MINE_TYPE>();
        public List<MINE_ESSENCE> MINE_ESSENCE { get; set; } = new List<MINE_ESSENCE>();
        public List<GM_GENERATOR_TYPE> GM_GENERATOR_TYPE { get; set; } = new List<GM_GENERATOR_TYPE>();
        public List<GM_GENERATOR_ESSENCE> GM_GENERATOR_ESSENCE { get; set; } = new List<GM_GENERATOR_ESSENCE>();
        public List<FIREWORKS_ESSENCE> FIREWORKS_ESSENCE { get; set; } = new List<FIREWORKS_ESSENCE>();
        public List<PLAYER_LEVELEXP_CONFIG> PLAYER_LEVELEXP_CONFIG { get; set; } = new List<PLAYER_LEVELEXP_CONFIG>();
        public List<NPC_WAR_TOWERBUILD_SERVICE> NPC_WAR_TOWERBUILD_SERVICE { get; set; } = new List<NPC_WAR_TOWERBUILD_SERVICE>();
        public List<PLAYER_SECONDLEVEL_CONFIG> PLAYER_SECONDLEVEL_CONFIG { get; set; } = new List<PLAYER_SECONDLEVEL_CONFIG>();
        public List<NPC_RESETPROP_SERVICE> NPC_RESETPROP_SERVICE { get; set; } = new List<NPC_RESETPROP_SERVICE>();
        public List<ESTONE_ESSENCE> ESTONE_ESSENCE { get; set; } = new List<ESTONE_ESSENCE>();
        public byte[] md5pos2 { get; set; }
        public List<PSTONE_ESSENCE> PSTONE_ESSENCE { get; set; } = new List<PSTONE_ESSENCE>();
        public List<SSTONE_ESSENCE> SSTONE_ESSENCE { get; set; } = new List<SSTONE_ESSENCE>();
        public List<STATUS_POINT_PROP_CONFIG> STATUS_POINT_PROP_CONFIG { get; set; } = new List<STATUS_POINT_PROP_CONFIG>();
        public List<PLAYER_STATUS_POINT_CONFIG> PLAYER_STATUS_POINT_CONFIG { get; set; } = new List<PLAYER_STATUS_POINT_CONFIG>();
        public int tag1 { get; set; }
        public byte[] data1 { get; set; }
        public List<RECIPEROLL_MAJOR_TYPE> RECIPEROLL_MAJOR_TYPE { get; set; } = new List<RECIPEROLL_MAJOR_TYPE>();
        public List<RECIPEROLL_SUB_TYPE> RECIPEROLL_SUB_TYPE { get; set; } = new List<RECIPEROLL_SUB_TYPE>();
        public List<RECIPEROLL_ESSENCE> RECIPEROLL_ESSENCE { get; set; } = new List<RECIPEROLL_ESSENCE>();
        public List<SUITE_ESSENCE> SUITE_ESSENCE { get; set; } = new List<SUITE_ESSENCE>();
        public List<DOUBLE_EXP_ESSENCE> DOUBLE_EXP_ESSENCE { get; set; } = new List<DOUBLE_EXP_ESSENCE>();
        public List<DESTROYING_ESSENCE> DESTROYING_ESSENCE { get; set; } = new List<DESTROYING_ESSENCE>();
        public List<NPC_EQUIPBIND_SERVICE> NPC_EQUIPBIND_SERVICE { get; set; } = new List<NPC_EQUIPBIND_SERVICE>();
        public List<NPC_EQUIPDESTROY_SERVICE> NPC_EQUIPDESTROY_SERVICE { get; set; } = new List<NPC_EQUIPDESTROY_SERVICE>();
        public List<NPC_EQUIPUNDESTROY_SERVICE> NPC_EQUIPUNDESTROY_SERVICE { get; set; } = new List<NPC_EQUIPUNDESTROY_SERVICE>();
        public List<NPC_BIRTH_RESET_SERVICE> NPC_BIRTH_RESET_SERVICE { get; set; } = new List<NPC_BIRTH_RESET_SERVICE>();
        public List<SKILLMATTER_ESSENCE> SKILLMATTER_ESSENCE { get; set; } = new List<SKILLMATTER_ESSENCE>();
        public List<VEHICLE_ESSENCE> VEHICLE_ESSENCE { get; set; } = new List<VEHICLE_ESSENCE>();
        public byte[] md5pos3 { get; set; }
        public List<COUPLE_JUMPTO_ESSENCE> COUPLE_JUMPTO_ESSENCE { get; set; } = new List<COUPLE_JUMPTO_ESSENCE>();
        public List<LOTTERY_ESSENCE> LOTTERY_ESSENCE { get; set; } = new List<LOTTERY_ESSENCE>();
        public List<CAMRECORDER_ESSENCE> CAMRECORDER_ESSENCE { get; set; } = new List<CAMRECORDER_ESSENCE>(); 
        public List<TITLE_PROP_CONFIG> TITLE_PROP_CONFIG { get; set; } = new List<TITLE_PROP_CONFIG>();
        public List<SPECIAL_ID_CONFIG> SPECIAL_ID_CONFIG { get; set; } = new List<SPECIAL_ID_CONFIG>();
        public List<TEXT_FIREWORKS_ESSENCE> TEXT_FIREWORKS_ESSENCE { get; set; } = new List<TEXT_FIREWORKS_ESSENCE>();
        public List<TALISMAN_MAINPART_ESSENCE> TALISMAN_MAINPART_ESSENCE { get; set; } = new List<TALISMAN_MAINPART_ESSENCE>();
        public List<TALISMAN_EXPFOOD_ESSENCE> TALISMAN_EXPFOOD_ESSENCE { get; set; } = new List<TALISMAN_EXPFOOD_ESSENCE>();
        public List<TALISMAN_MERGEKATALYST_ESSENCE> TALISMAN_MERGEKATALYST_ESSENCE { get; set; } = new List<TALISMAN_MERGEKATALYST_ESSENCE>();
        public List<TALISMAN_ENERGYFOOD_ESSENCE> TALISMAN_ENERGYFOOD_ESSENCE { get; set; } = new List<TALISMAN_ENERGYFOOD_ESSENCE>();
        public List<SPEAKER_ESSENCE> SPEAKER_ESSENCE { get; set; } = new List<SPEAKER_ESSENCE>();
        public List<PLAYER_TALENT_CONFIG> PLAYER_TALENT_CONFIG { get; set; } = new List<PLAYER_TALENT_CONFIG>();
        public List<POTENTIAL_TOME_ESSENCE> POTENTIAL_TOME_ESSENCE { get; set; } = new List<POTENTIAL_TOME_ESSENCE>();
        public List<ITEM_TRADE_CONFIG> ITEM_TRADE_CONFIG { get; set; } = new List<ITEM_TRADE_CONFIG>();
        public List<INSTANCE_CONFIG> INSTANCE_CONFIG { get; set; } = new List<INSTANCE_CONFIG>();
        public List<EQUIPMENT_RANDOM_ADDONSGROUP> EQUIPMENT_RANDOM_ADDONSGROUP { get; set; } = new List<EQUIPMENT_RANDOM_ADDONSGROUP>();
        public List<NPC_PROF_DEMOTION_SERVICE> NPC_PROF_DEMOTION_SERVICE { get; set; } = new List<NPC_PROF_DEMOTION_SERVICE>();
        public List<talk_proc> talk_proc { get; set; } = new List<talk_proc>();
        public object Clone() { return this.MemberwiseClone(); }


        public ElementsTemplate Read(BinaryReader br)
        {
            ElementsTemplate elements = new ElementsTemplate();
            elements.magic = br.ReadInt32();
            elements.timestamp = DateTimeOffset.FromUnixTimeSeconds(br.ReadInt32()).UtcDateTime;
            elements.EQUIPMENT_ADDON = Reader.ReadList<EQUIPMENT_ADDON>(elements, br);
            elements.EQUIPMENT_MAJOR_TYPE = Reader.ReadList<EQUIPMENT_MAJOR_TYPE>(elements, br);
            elements.EQUIPMENT_SUB_TYPE = Reader.ReadList<EQUIPMENT_SUB_TYPE>(elements, br);
            elements.EQUIPMENT_ESSENCE = Reader.ReadList<EQUIPMENT_ESSENCE>(elements, br);
            elements.MEDICINE_MAJOR_TYPE = Reader.ReadList<MEDICINE_MAJOR_TYPE>(elements, br);
            elements.MEDICINE_SUB_TYPE = Reader.ReadList<MEDICINE_SUB_TYPE>(elements, br);
            elements.MEDICINE_ESSENCE = Reader.ReadList<MEDICINE_ESSENCE>(elements, br);
            elements.MATERIAL_MAJOR_TYPE = Reader.ReadList<MATERIAL_MAJOR_TYPE>(elements, br);
            elements.MATERIAL_SUB_TYPE = Reader.ReadList<MATERIAL_SUB_TYPE>(elements, br);
            elements.MATERIAL_ESSENCE = Reader.ReadList<MATERIAL_ESSENCE>(elements, br);
            elements.REFINE_TICKET_ESSENCE = Reader.ReadList<REFINE_TICKET_ESSENCE>(elements, br);
            elements.SKILLTOME_SUB_TYPE = Reader.ReadList<SKILLTOME_SUB_TYPE>(elements, br);
            elements.SKILLTOME_ESSENCE = Reader.ReadList<SKILLTOME_ESSENCE>(elements, br);
            elements.TRANSMITROLL_ESSENCE = Reader.ReadList<TRANSMITROLL_ESSENCE>(elements, br);
            elements.LUCKYROLL_ESSENCE = Reader.ReadList<LUCKYROLL_ESSENCE>(elements, br);
            elements.TOWNSCROLL_ESSENCE = Reader.ReadList<TOWNSCROLL_ESSENCE>(elements, br);
            elements.REVIVESCROLL_ESSENCE = Reader.ReadList<REVIVESCROLL_ESSENCE>(elements, br);
            elements.TASKMATTER_ESSENCE = Reader.ReadList<TASKMATTER_ESSENCE>(elements, br);
            elements.DROPTABLE_TYPE = Reader.ReadList<DROPTABLE_TYPE>(elements, br);
            elements.DROPTABLE_ESSENCE = Reader.ReadList<DROPTABLE_ESSENCE>(elements, br);
            elements.md5pos0 = new byte[8];
            for (int i = 0; i < elements.md5pos0.Length; i++)
            {
                elements.md5pos0[i] = br.ReadByte();
            }
            elements.MONSTER_TYPE = Reader.ReadList<MONSTER_TYPE>(elements, br);
            elements.MONSTER_ESSENCE = Reader.ReadList<MONSTER_ESSENCE>(elements, br);
            elements.EQUIPMENT_UPGRADE_ESSENCE = Reader.ReadList<EQUIPMENT_UPGRADE_ESSENCE>(elements, br);
            elements.AIRCRAFT_ESSENCE = Reader.ReadList<AIRCRAFT_ESSENCE>(elements, br);
            elements.CHANGE_SHAPE_ESSENCE = Reader.ReadList<CHANGE_SHAPE_ESSENCE>(elements, br);
            elements.SUMMON_MONSTER_ESSENCE = Reader.ReadList<SUMMON_MONSTER_ESSENCE>(elements, br);
            elements.PET_BEDGE_ESSENCE = Reader.ReadList<PET_BEDGE_ESSENCE>(elements, br);
            elements.PET_FOOD_ESSENCE = Reader.ReadList<PET_FOOD_ESSENCE>(elements, br);
            elements.PET_SKILL_ESSENCE = Reader.ReadList<PET_SKILL_ESSENCE>(elements, br);
            elements.PET_ARMOR_ESSENCE = Reader.ReadList<PET_ARMOR_ESSENCE>(elements, br);
            elements.MERGE_RECIPE_ESSENCE = Reader.ReadList<MERGE_RECIPE_ESSENCE>(elements, br);
            elements.NPC_HOTEL_SERVICE = Reader.ReadList<NPC_HOTEL_SERVICE>(elements, br);
            elements.PRODUCE_TYPE_CONFIG = Reader.ReadList<PRODUCE_TYPE_CONFIG>(elements, br);
            elements.NPC_LEARN_PRODUCE_SERVICE = Reader.ReadList<NPC_LEARN_PRODUCE_SERVICE>(elements, br);
            elements.AI_HELPER_ESSENCE = Reader.ReadList<AI_HELPER_ESSENCE>(elements, br);
            elements.PET_PRODUCE_ESSENCE = Reader.ReadList<PET_PRODUCE_ESSENCE>(elements, br);
            elements.PET_MERGE_ESSENCE = Reader.ReadList<PET_MERGE_ESSENCE>(elements, br);
            elements.CHANGE_RECOVER_ESSENCE = Reader.ReadList<CHANGE_RECOVER_ESSENCE>(elements, br);
            elements.HATCHER_MAJOR_TYPE = Reader.ReadList<HATCHER_MAJOR_TYPE>(elements, br);
            elements.HATCHER_ESSENCE = Reader.ReadList<HATCHER_ESSENCE>(elements, br);
            elements.BOOK_ESSENCE = Reader.ReadList<BOOK_ESSENCE>(elements, br);
            elements.SPECIAL_SPEAKER_ESSENCE = Reader.ReadList<SPECIAL_SPEAKER_ESSENCE>(elements, br);
            elements.GARDEN_ESSENCE = Reader.ReadList<GARDEN_ESSENCE>(elements, br);
            elements.GARDEN_ORNAMENT_ESSENCE = Reader.ReadList<GARDEN_ORNAMENT_ESSENCE>(elements, br);
            elements.SEED_ESSENCE = Reader.ReadList<SEED_ESSENCE>(elements, br);
            elements.FRUIT_ESSENCE = Reader.ReadList<FRUIT_ESSENCE>(elements, br);
            elements.PETBOX_EXPLIST_CONFIG = Reader.ReadList<PETBOX_EXPLIST_CONFIG>(elements, br);
            elements.GARDEN_TOOL_ESSENCE = Reader.ReadList<GARDEN_TOOL_ESSENCE>(elements, br);
            elements.GARDEN_FUNC_ESSENCE = Reader.ReadList<GARDEN_FUNC_ESSENCE>(elements, br);
            elements.GARDEN_AWARD = Reader.ReadList<GARDEN_AWARD>(elements, br);
            elements.SPEAKER_LEVEL_NUM_CONFIG = Reader.ReadList<SPEAKER_LEVEL_NUM_CONFIG>(elements, br);
            elements.SPEAKER_NUM_MONEY_CONFIG = Reader.ReadList<SPEAKER_NUM_MONEY_CONFIG>(elements, br);
            elements.BIRTHSKILL_RESET_SERVICE = Reader.ReadList<BIRTHSKILL_RESET_SERVICE>(elements, br);
            elements.BIRTH_SKILL_CANDIDATE = Reader.ReadList<BIRTH_SKILL_CANDIDATE>(elements, br); 
            elements.UPGRADE_TRANSFER_SERVICE = Reader.ReadList<UPGRADE_TRANSFER_SERVICE>(elements, br);
            elements.GARDEN_EXCHANGE_CONFIG = Reader.ReadList<GARDEN_EXCHANGE_CONFIG>(elements, br);
            elements.RUNE_COMBINATION_CONFIG = Reader.ReadList<RUNE_COMBINATION_CONFIG>(elements, br);
            elements.NPC_SUPER_UPGRADE_SERVICE = Reader.ReadList<NPC_SUPER_UPGRADE_SERVICE>(elements, br);
            elements.RUNE_ESSENCE = Reader.ReadList<RUNE_ESSENCE>(elements, br);
            elements.EQUIPMENT_EXCHANGE_CONFIG = Reader.ReadList<EQUIPMENT_EXCHANGE_CONFIG>(elements, br);
            elements.tag = br.ReadInt32();
            int len = br.ReadInt32();
            elements.data = br.ReadBytes(len);
            elements.t = DateTimeOffset.FromUnixTimeSeconds(br.ReadInt32()).UtcDateTime;
            Console.WriteLine($"Reading tag {tag} length of {len} (bytes) t {t}");
            

            elements.NPC_TALK_SERVICE = Reader.ReadList<NPC_TALK_SERVICE>(elements, br);
            elements.NPC_SELL_SERVICE = Reader.ReadList<NPC_SELL_SERVICE>(elements, br);
            elements.NPC_BUY_SERVICE = Reader.ReadList<NPC_BUY_SERVICE>(elements, br);
            elements.NPC_TASK_IN_SERVICE = Reader.ReadList<NPC_TASK_IN_SERVICE>(elements, br);
            elements.NPC_TASK_OUT_SERVICE = Reader.ReadList<NPC_TASK_OUT_SERVICE>(elements, br);
            elements.NPC_TASK_MATTER_SERVICE = Reader.ReadList<NPC_TASK_MATTER_SERVICE>(elements, br);
            elements.NPC_HEAL_SERVICE = Reader.ReadList<NPC_HEAL_SERVICE>(elements, br);
            elements.NPC_TRANSMIT_SERVICE = Reader.ReadList<NPC_TRANSMIT_SERVICE>(elements, br);
            elements.NPC_PROXY_SERVICE = Reader.ReadList<NPC_PROXY_SERVICE>(elements, br);
            elements.NPC_STORAGE_SERVICE = Reader.ReadList<NPC_STORAGE_SERVICE>(elements, br);
            elements.NPC_TYPE = Reader.ReadList<NPC_TYPE>(elements, br);
            elements.NPC_ESSENCE = Reader.ReadList<NPC_ESSENCE>(elements, br);
            elements.RECIPE_MAJOR_TYPE = Reader.ReadList<RECIPE_MAJOR_TYPE>(elements, br);
            elements.RECIPE_SUB_TYPE = Reader.ReadList<RECIPE_SUB_TYPE>(elements, br);
            elements.RECIPE_ESSENCE = Reader.ReadList<RECIPE_ESSENCE>(elements, br);
            elements.ENEMY_FACTION_CONFIG = Reader.ReadList<ENEMY_FACTION_CONFIG>(elements, br);
            elements.CHARRACTER_CLASS_CONFIG = Reader.ReadList<CHARRACTER_CLASS_CONFIG>(elements, br);
            elements.md5pos1 = new byte[8];
            for (int i = 0; i < elements.md5pos1.Length; i++)
            {
                elements.md5pos1[i] = br.ReadByte();
            }
            elements.PARAM_ADJUST_CONFIG = Reader.ReadList<PARAM_ADJUST_CONFIG>(elements, br);
            elements.TASKDICE_ESSENCE = Reader.ReadList<TASKDICE_ESSENCE>(elements, br);
            elements.TASKNORMALMATTER_ESSENCE = Reader.ReadList<TASKNORMALMATTER_ESSENCE>(elements, br);
            elements.MINE_TYPE = Reader.ReadList<MINE_TYPE>(elements, br);
            elements.MINE_ESSENCE = Reader.ReadList<MINE_ESSENCE>(elements, br);
            elements.GM_GENERATOR_TYPE = Reader.ReadList<GM_GENERATOR_TYPE>(elements, br);
            elements.GM_GENERATOR_ESSENCE = Reader.ReadList<GM_GENERATOR_ESSENCE>(elements, br);
            elements.FIREWORKS_ESSENCE = Reader.ReadList<FIREWORKS_ESSENCE>(elements, br);
            elements.PLAYER_LEVELEXP_CONFIG = Reader.ReadList<PLAYER_LEVELEXP_CONFIG>(elements, br);
            elements.NPC_WAR_TOWERBUILD_SERVICE = Reader.ReadList<NPC_WAR_TOWERBUILD_SERVICE>(elements, br);
            elements.PLAYER_SECONDLEVEL_CONFIG = Reader.ReadList<PLAYER_SECONDLEVEL_CONFIG>(elements, br);
            elements.NPC_RESETPROP_SERVICE = Reader.ReadList<NPC_RESETPROP_SERVICE>(elements, br);
            elements.ESTONE_ESSENCE = Reader.ReadList<ESTONE_ESSENCE>(elements, br);
            elements.md5pos2 = new byte[8];
            for (int i = 0; i < elements.md5pos0.Length; i++)
            {
                elements.md5pos2[i] = br.ReadByte();
            }
            elements.PSTONE_ESSENCE = Reader.ReadList<PSTONE_ESSENCE>(elements, br);
            elements.SSTONE_ESSENCE = Reader.ReadList<SSTONE_ESSENCE>(elements, br);
            elements.STATUS_POINT_PROP_CONFIG = Reader.ReadList<STATUS_POINT_PROP_CONFIG>(elements, br);
            elements.PLAYER_STATUS_POINT_CONFIG = Reader.ReadList<PLAYER_STATUS_POINT_CONFIG>(elements, br);
            elements.tag1 = br.ReadInt32();
            len = br.ReadInt32();
            elements.data1 = br.ReadBytes(len);
            elements.RECIPEROLL_MAJOR_TYPE = Reader.ReadList<RECIPEROLL_MAJOR_TYPE>(elements, br);
            elements.RECIPEROLL_SUB_TYPE = Reader.ReadList<RECIPEROLL_SUB_TYPE>(elements, br);
            elements.RECIPEROLL_ESSENCE = Reader.ReadList<RECIPEROLL_ESSENCE>(elements, br);
            elements.SUITE_ESSENCE = Reader.ReadList<SUITE_ESSENCE>(elements, br);
            elements.DOUBLE_EXP_ESSENCE = Reader.ReadList<DOUBLE_EXP_ESSENCE>(elements, br);
            elements.DESTROYING_ESSENCE = Reader.ReadList<DESTROYING_ESSENCE>(elements, br);
            elements.NPC_EQUIPBIND_SERVICE = Reader.ReadList<NPC_EQUIPBIND_SERVICE>(elements, br);
            elements.NPC_EQUIPDESTROY_SERVICE = Reader.ReadList<NPC_EQUIPDESTROY_SERVICE>(elements, br);
            elements.NPC_EQUIPUNDESTROY_SERVICE = Reader.ReadList<NPC_EQUIPUNDESTROY_SERVICE>(elements, br);
            elements.NPC_BIRTH_RESET_SERVICE = Reader.ReadList<NPC_BIRTH_RESET_SERVICE>(elements, br);
            elements.SKILLMATTER_ESSENCE = Reader.ReadList<SKILLMATTER_ESSENCE>(elements, br);
            elements.VEHICLE_ESSENCE = Reader.ReadList<VEHICLE_ESSENCE>(elements, br);
            elements.md5pos3 = new byte[8];
            for (int i = 0; i < elements.md5pos3.Length; i++)
            {
                elements.md5pos3[i] = br.ReadByte();
            }
            elements.COUPLE_JUMPTO_ESSENCE = Reader.ReadList<COUPLE_JUMPTO_ESSENCE>(elements, br);
            elements.LOTTERY_ESSENCE = Reader.ReadList<LOTTERY_ESSENCE>(elements, br);
            elements.CAMRECORDER_ESSENCE = Reader.ReadList<CAMRECORDER_ESSENCE>(elements, br);
            elements.TITLE_PROP_CONFIG = Reader.ReadList<TITLE_PROP_CONFIG>(elements, br);
            elements.SPECIAL_ID_CONFIG = Reader.ReadList<SPECIAL_ID_CONFIG>(elements, br);
            elements.TEXT_FIREWORKS_ESSENCE = Reader.ReadList<TEXT_FIREWORKS_ESSENCE>(elements, br);
            elements.TALISMAN_MAINPART_ESSENCE = Reader.ReadList<TALISMAN_MAINPART_ESSENCE>(elements, br);
            elements.TALISMAN_EXPFOOD_ESSENCE = Reader.ReadList<TALISMAN_EXPFOOD_ESSENCE>(elements, br);
            elements.TALISMAN_MERGEKATALYST_ESSENCE = Reader.ReadList<TALISMAN_MERGEKATALYST_ESSENCE>(elements, br);
            elements.TALISMAN_ENERGYFOOD_ESSENCE = Reader.ReadList<TALISMAN_ENERGYFOOD_ESSENCE>(elements, br);
            elements.SPEAKER_ESSENCE = Reader.ReadList<SPEAKER_ESSENCE>(elements, br);
            elements.PLAYER_TALENT_CONFIG = Reader.ReadList<PLAYER_TALENT_CONFIG>(elements, br);
            elements.POTENTIAL_TOME_ESSENCE = Reader.ReadList<POTENTIAL_TOME_ESSENCE>(elements, br);
            elements.ITEM_TRADE_CONFIG = Reader.ReadList<ITEM_TRADE_CONFIG>(elements, br);
            elements.INSTANCE_CONFIG = Reader.ReadList<INSTANCE_CONFIG>(elements, br);
            elements.EQUIPMENT_RANDOM_ADDONSGROUP = Reader.ReadList<EQUIPMENT_RANDOM_ADDONSGROUP>(elements, br);
            elements.NPC_PROF_DEMOTION_SERVICE = Reader.ReadList<NPC_PROF_DEMOTION_SERVICE>(elements, br);
            int talkLength = br.ReadInt32();
            for (int i = 0; i < talkLength; i++)
            {
                elements.talk_proc.Add(ESO.talk_proc.Read(br));
            }

            return elements;
        }

        public void Write(BinaryWriter bw, ElementsTemplate elements)
        {
            bw.Write(elements.magic);
            bw.Write((int)new DateTimeOffset(elements.timestamp).ToUnixTimeSeconds());

            Reader.WriteList(bw, elements.EQUIPMENT_ADDON);
            Reader.WriteList(bw, elements.EQUIPMENT_MAJOR_TYPE);
            Reader.WriteList(bw, elements.EQUIPMENT_SUB_TYPE);
            Reader.WriteList(bw, elements.EQUIPMENT_ESSENCE);
            Reader.WriteList(bw, elements.MEDICINE_MAJOR_TYPE);
            Reader.WriteList(bw, elements.MEDICINE_SUB_TYPE);
            Reader.WriteList(bw, elements.MEDICINE_ESSENCE);
            Reader.WriteList(bw, elements.MATERIAL_MAJOR_TYPE);
            Reader.WriteList(bw, elements.MATERIAL_SUB_TYPE);
            Reader.WriteList(bw, elements.MATERIAL_ESSENCE);
            Reader.WriteList(bw, elements.REFINE_TICKET_ESSENCE);
            Reader.WriteList(bw, elements.SKILLTOME_SUB_TYPE);
            Reader.WriteList(bw, elements.SKILLTOME_ESSENCE);
            Reader.WriteList(bw, elements.TRANSMITROLL_ESSENCE);
            Reader.WriteList(bw, elements.LUCKYROLL_ESSENCE);
            Reader.WriteList(bw, elements.TOWNSCROLL_ESSENCE);
            Reader.WriteList(bw, elements.REVIVESCROLL_ESSENCE);
            Reader.WriteList(bw, elements.TASKMATTER_ESSENCE);
            Reader.WriteList(bw, elements.DROPTABLE_TYPE);
            Reader.WriteList(bw, elements.DROPTABLE_ESSENCE);

            bw.Write(elements.md5pos0);

            Reader.WriteList(bw, elements.MONSTER_TYPE);
            Reader.WriteList(bw, elements.MONSTER_ESSENCE);
            Reader.WriteList(bw, elements.EQUIPMENT_UPGRADE_ESSENCE);
            Reader.WriteList(bw, elements.AIRCRAFT_ESSENCE);
            Reader.WriteList(bw, elements.CHANGE_SHAPE_ESSENCE);
            Reader.WriteList(bw, elements.SUMMON_MONSTER_ESSENCE);
            Reader.WriteList(bw, elements.PET_BEDGE_ESSENCE);
            Reader.WriteList(bw, elements.PET_FOOD_ESSENCE);
            Reader.WriteList(bw, elements.PET_SKILL_ESSENCE);
            Reader.WriteList(bw, elements.PET_ARMOR_ESSENCE);
            Reader.WriteList(bw, elements.MERGE_RECIPE_ESSENCE);
            Reader.WriteList(bw, elements.NPC_HOTEL_SERVICE);
            Reader.WriteList(bw, elements.PRODUCE_TYPE_CONFIG);
            Reader.WriteList(bw, elements.NPC_LEARN_PRODUCE_SERVICE);
            Reader.WriteList(bw, elements.AI_HELPER_ESSENCE);
            Reader.WriteList(bw, elements.PET_PRODUCE_ESSENCE);
            Reader.WriteList(bw, elements.PET_MERGE_ESSENCE);
            Reader.WriteList(bw, elements.CHANGE_RECOVER_ESSENCE);
            Reader.WriteList(bw, elements.HATCHER_MAJOR_TYPE);
            Reader.WriteList(bw, elements.HATCHER_ESSENCE);
            Reader.WriteList(bw, elements.BOOK_ESSENCE);
            Reader.WriteList(bw, elements.SPECIAL_SPEAKER_ESSENCE);
            Reader.WriteList(bw, elements.GARDEN_ESSENCE);
            Reader.WriteList(bw, elements.GARDEN_ORNAMENT_ESSENCE);
            Reader.WriteList(bw, elements.SEED_ESSENCE);
            Reader.WriteList(bw, elements.FRUIT_ESSENCE);
            Reader.WriteList(bw, elements.PETBOX_EXPLIST_CONFIG);
            Reader.WriteList(bw, elements.GARDEN_TOOL_ESSENCE);
            Reader.WriteList(bw, elements.GARDEN_FUNC_ESSENCE);
            Reader.WriteList(bw, elements.GARDEN_AWARD);
            Reader.WriteList(bw, elements.SPEAKER_LEVEL_NUM_CONFIG);
            Reader.WriteList(bw, elements.SPEAKER_NUM_MONEY_CONFIG);
            Reader.WriteList(bw, elements.BIRTHSKILL_RESET_SERVICE);
            Reader.WriteList(bw, elements.BIRTH_SKILL_CANDIDATE);
            Reader.WriteList(bw, elements.UPGRADE_TRANSFER_SERVICE);
            Reader.WriteList(bw, elements.GARDEN_EXCHANGE_CONFIG);
            Reader.WriteList(bw, elements.RUNE_COMBINATION_CONFIG);
            Reader.WriteList(bw, elements.NPC_SUPER_UPGRADE_SERVICE);
            Reader.WriteList(bw, elements.RUNE_ESSENCE);
            Reader.WriteList(bw, elements.EQUIPMENT_EXCHANGE_CONFIG);

            bw.Write(elements.tag);
            bw.Write(elements.data.Length);
            bw.Write(elements.data);
            bw.Write((int)new DateTimeOffset(elements.t).ToUnixTimeSeconds());

            Reader.WriteList(bw, elements.NPC_TALK_SERVICE);
            Reader.WriteList(bw, elements.NPC_SELL_SERVICE);
            Reader.WriteList(bw, elements.NPC_BUY_SERVICE);
            Reader.WriteList(bw, elements.NPC_TASK_IN_SERVICE);
            Reader.WriteList(bw, elements.NPC_TASK_OUT_SERVICE);
            Reader.WriteList(bw, elements.NPC_TASK_MATTER_SERVICE);
            Reader.WriteList(bw, elements.NPC_HEAL_SERVICE);
            Reader.WriteList(bw, elements.NPC_TRANSMIT_SERVICE);
            Reader.WriteList(bw, elements.NPC_PROXY_SERVICE);
            Reader.WriteList(bw, elements.NPC_STORAGE_SERVICE);
            Reader.WriteList(bw, elements.NPC_TYPE);
            Reader.WriteList(bw, elements.NPC_ESSENCE);
            Reader.WriteList(bw, elements.RECIPE_MAJOR_TYPE);
            Reader.WriteList(bw, elements.RECIPE_SUB_TYPE);
            Reader.WriteList(bw, elements.RECIPE_ESSENCE);
            Reader.WriteList(bw, elements.ENEMY_FACTION_CONFIG);
            Reader.WriteList(bw, elements.CHARRACTER_CLASS_CONFIG);

            bw.Write(elements.md5pos1);

            Reader.WriteList(bw, elements.PARAM_ADJUST_CONFIG);
            Reader.WriteList(bw, elements.TASKDICE_ESSENCE);
            Reader.WriteList(bw, elements.TASKNORMALMATTER_ESSENCE);
            Reader.WriteList(bw, elements.MINE_TYPE);
            Reader.WriteList(bw, elements.MINE_ESSENCE);
            Reader.WriteList(bw, elements.GM_GENERATOR_TYPE);
            Reader.WriteList(bw, elements.GM_GENERATOR_ESSENCE);
            Reader.WriteList(bw, elements.FIREWORKS_ESSENCE);
            Reader.WriteList(bw, elements.PLAYER_LEVELEXP_CONFIG);
            Reader.WriteList(bw, elements.NPC_WAR_TOWERBUILD_SERVICE);
            Reader.WriteList(bw, elements.PLAYER_SECONDLEVEL_CONFIG);
            Reader.WriteList(bw, elements.NPC_RESETPROP_SERVICE);
            Reader.WriteList(bw, elements.ESTONE_ESSENCE);

            bw.Write(elements.md5pos2);

            Reader.WriteList(bw, elements.PSTONE_ESSENCE);
            Reader.WriteList(bw, elements.SSTONE_ESSENCE);
            Reader.WriteList(bw, elements.STATUS_POINT_PROP_CONFIG);
            Reader.WriteList(bw, elements.PLAYER_STATUS_POINT_CONFIG);

            bw.Write(elements.tag1);
            bw.Write(elements.data1.Length);
            bw.Write(elements.data1);

            Reader.WriteList(bw, elements.RECIPEROLL_MAJOR_TYPE);
            Reader.WriteList(bw, elements.RECIPEROLL_SUB_TYPE);
            Reader.WriteList(bw, elements.RECIPEROLL_ESSENCE);
            Reader.WriteList(bw, elements.SUITE_ESSENCE);
            Reader.WriteList(bw, elements.DOUBLE_EXP_ESSENCE);
            Reader.WriteList(bw, elements.DESTROYING_ESSENCE);
            Reader.WriteList(bw, elements.NPC_EQUIPBIND_SERVICE);
            Reader.WriteList(bw, elements.NPC_EQUIPDESTROY_SERVICE);
            Reader.WriteList(bw, elements.NPC_EQUIPUNDESTROY_SERVICE);
            Reader.WriteList(bw, elements.NPC_BIRTH_RESET_SERVICE);
            Reader.WriteList(bw, elements.SKILLMATTER_ESSENCE);
            Reader.WriteList(bw, elements.VEHICLE_ESSENCE);

            bw.Write(elements.md5pos3);

            Reader.WriteList(bw, elements.COUPLE_JUMPTO_ESSENCE);
            Reader.WriteList(bw, elements.LOTTERY_ESSENCE);
            Reader.WriteList(bw, elements.CAMRECORDER_ESSENCE);
            Reader.WriteList(bw, elements.TITLE_PROP_CONFIG);
            Reader.WriteList(bw, elements.SPECIAL_ID_CONFIG);
            Reader.WriteList(bw, elements.TEXT_FIREWORKS_ESSENCE);
            Reader.WriteList(bw, elements.TALISMAN_MAINPART_ESSENCE);
            Reader.WriteList(bw, elements.TALISMAN_EXPFOOD_ESSENCE);
            Reader.WriteList(bw, elements.TALISMAN_MERGEKATALYST_ESSENCE);
            Reader.WriteList(bw, elements.TALISMAN_ENERGYFOOD_ESSENCE);
            Reader.WriteList(bw, elements.SPEAKER_ESSENCE);
            Reader.WriteList(bw, elements.PLAYER_TALENT_CONFIG);
            Reader.WriteList(bw, elements.POTENTIAL_TOME_ESSENCE);
            Reader.WriteList(bw, elements.ITEM_TRADE_CONFIG);
            Reader.WriteList(bw, elements.INSTANCE_CONFIG);
            Reader.WriteList(bw, elements.EQUIPMENT_RANDOM_ADDONSGROUP);
            Reader.WriteList(bw, elements.NPC_PROF_DEMOTION_SERVICE);

            bw.Write(elements.talk_proc.Count);
            foreach (talk_proc tp in elements.talk_proc)
            {
                tp.Write(bw, tp); // Zorg dat je Write hebt in je talk_proc type
            }
        }
        /*
        private static List<T> ReadList<T>(ElementsTemplate elements, BinaryReader br) where T : new()
        {
            int objectLength = br.ReadInt32();
            int objectCount = br.ReadInt32();

            T[] list = new T[objectCount];

            //Console.WriteLine(type.ToString()); 
            Console.WriteLine($"Reading {objectCount} objects of type {typeof(T).Name} ({objectLength} bytes)");
            for(int i = 0; i < objectCount; i++)
            {
                list[i] = (ReadFromBinaryReader<T>(br));
            }
            return list.ToList<T>();
        }


        [AttributeUsage(AttributeTargets.Property)]
        public class IndexNamesAttribute : Attribute
        {
            public string[] Names { get; }

            public IndexNamesAttribute(params string[] names)
            {
                Names = names;
            }
        }

        [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
        public class LookupTypeAttribute : Attribute
        {
            public Type LookupType { get; }

            public LookupTypeAttribute(Type lookupType)
            {
                LookupType = lookupType;
            }
        }

        [AttributeUsage(AttributeTargets.Property)]
        public class ElementReferenceAttribute : Attribute
        {
            public string ListName { get; }
            public ElementReferenceAttribute(string listName)
            {
                ListName = listName;
            }
        }

        [AttributeUsage(AttributeTargets.Property)]
        public class FixedArrayLengthAttribute : Attribute
        {
            public int Length { get; }

            public FixedArrayLengthAttribute(int length)
            {
                Length = length;
            }
        }

        public static T ReadFromBinaryReader<T>(BinaryReader br) where T : new()
        {
            T instance = new T();
            var type = typeof(T);

            foreach (var prop in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (!prop.CanWrite)
                    continue;

                var propType = prop.PropertyType;

                if (propType.IsArray)
                {
                    var elementType = propType.GetElementType();
                    var lengthAttr = prop.GetCustomAttribute<FixedArrayLengthAttribute>();
                    if (lengthAttr == null)
                        throw new Exception($"Array property {prop.Name} must have FixedArrayLengthAttribute.");

                    int length = lengthAttr.Length;
                    Array array = Array.CreateInstance(elementType, length);
                    for (int i = 0; i < length; i++)
                    {
                        object value = ReadPrimitive(br, elementType, prop);
                        array.SetValue(value, i);
                    }
                    prop.SetValue(instance, array);
                }
                else
                {
                    object value = ReadPrimitive(br, propType, prop);
                    prop.SetValue(instance, value);
                }
            }

            return instance;
        }

        private static object ReadPrimitive(BinaryReader br, Type type, PropertyInfo prop = null)
        {
            if (type == typeof(int))
                return br.ReadInt32();
            if (type == typeof(uint))
                return br.ReadUInt32();
            if (type == typeof(short))
                return br.ReadInt16();
            if (type == typeof(ushort))
                return br.ReadUInt16();
            if (type == typeof(byte))
                return br.ReadByte();
            if (type == typeof(float))
                return br.ReadSingle();
            if (type == typeof(double))
                return br.ReadDouble();
            if (type == typeof(bool))
                return br.ReadBoolean();
            if (type == typeof(char))
                return br.ReadChar();
            if (type == typeof(string))
            {
                int length = -1;

                // 1️⃣ Check attribuut
                var fixedLenAttr = prop?.GetCustomAttribute<FixedArrayLengthAttribute>();
                if (fixedLenAttr != null)
                {
                    length = fixedLenAttr.Length;
                }
                else if (string.Equals(prop?.Name, "name", StringComparison.OrdinalIgnoreCase))
                {
                    // 2️⃣ Speciale regel voor "name"
                    length = 64;
                }
                else
                {
                    // 3️⃣ Default lengte (pas aan naar wens)

                    throw new NotSupportedException($"No length specified for {prop?.Name}.");
                }
                if(length > 0)
                    //string chars = ;
                    return COMMON.Unicode.readUnicodeString(br, length).TrimEnd('\0');
                else
                    throw new NotSupportedException($"No string length for {prop?.Name} specified.");

            }
            if (type.IsEnum)
            {
                int raw = br.ReadInt32();
                return Enum.ToObject(type, raw);
            } 

            //
            if (!type.IsPrimitive && type.IsClass)
            {
                var method = typeof(ElementsTemplate)
                    .GetMethod(nameof(ReadFromBinaryReader))
                    .MakeGenericMethod(type);
                return method.Invoke(null, new object[] { br });
            }

            throw new NotSupportedException($"Type {type.Name} is not supported.");
        }
        public static void WriteList<T>(BinaryWriter bw, List<T> list) where T : new()
        {
            if (list == null) throw new ArgumentNullException(nameof(list));

            int objectLength;

            // Bepaal lengte van een object (indien lijst leeg, van een lege instantie)
            using (var ms = new MemoryStream())
            using (var tempBw = new BinaryWriter(ms))
            {
                T sampleObj = (list.Count > 0) ? list[0] : new T();
                WriteToBinaryWriter(tempBw, sampleObj);
                tempBw.Flush();
                objectLength = (int)ms.Length;
            }

            // Schrijf lengte en count
            bw.Write(objectLength);
            bw.Write(list.Count);

            // Schrijf de objecten zelf
            foreach (var obj in list)
            {
                WriteToBinaryWriter(bw, obj);
            }
        }
        public static void WriteToBinaryWriter<T>(BinaryWriter bw, T obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            var type = typeof(T);

            foreach (var prop in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (!prop.CanRead)
                    continue;

                var value = prop.GetValue(obj);
                var propType = prop.PropertyType;

                if (propType.IsArray)
                {
                    var elementType = propType.GetElementType();
                    var lengthAttr = prop.GetCustomAttribute<FixedArrayLengthAttribute>();
                    if (lengthAttr == null)
                        throw new Exception($"Array property {prop.Name} must have FixedArrayLengthAttribute.");

                    int length = lengthAttr.Length;
                    Array array = (Array)value;

                    for (int i = 0; i < length; i++)
                    {
                        object elementValue = array != null && i < array.Length ? array.GetValue(i) : Activator.CreateInstance(elementType);
                        WritePrimitive(bw, elementType, elementValue, prop);
                    }
                }
                else
                {
                    WritePrimitive(bw, propType, value, prop);
                }
            }
        }

        private static void WritePrimitive(BinaryWriter bw, Type type, object value, PropertyInfo prop = null)
        {
            if (type == typeof(int))
                bw.Write((int)(value ?? 0));
            else if (type == typeof(uint))
                bw.Write((uint)(value ?? 0));
            else if (type == typeof(short))
                bw.Write((short)(value ?? 0));
            else if (type == typeof(ushort))
                bw.Write((ushort)(value ?? 0));
            else if (type == typeof(byte))
                bw.Write((byte)(value ?? 0));
            else if (type == typeof(float))
                bw.Write((float)(value ?? 0));
            else if (type == typeof(double))
                bw.Write((double)(value ?? 0));
            else if (type == typeof(bool))
                bw.Write((bool)(value ?? false));
            else if (type == typeof(char))
                bw.Write((char)(value ?? '\0'));
            else if (type == typeof(string))
            {
                int length = -1;

                var fixedLenAttr = prop?.GetCustomAttribute<FixedArrayLengthAttribute>();
                if (fixedLenAttr != null)
                {
                    length = fixedLenAttr.Length;
                }
                else if (string.Equals(prop?.Name, "name", StringComparison.OrdinalIgnoreCase))
                {
                    length = 64;
                }
                else
                {
                    throw new NotSupportedException($"No length specified for {prop?.Name}.");
                }

                if (length > 0)
                {
                    string str = value?.ToString() ?? string.Empty;

                    COMMON.Unicode.writeUnicodeStringWithFix(bw, str, length);
                    //COMMON.Unicode.writeUnicodeString(bw, str, length);
                    /*var encoding = Encoding.Unicode;
                    byte[] strBytes = encoding.GetBytes(str);

                    byte[] buffer = new byte[length];
                    int count = Math.Min(strBytes.Length, length);
                    Array.Copy(strBytes, buffer, count);

                    bw.Write(buffer);*//*
                }
                else
                {
                    throw new NotSupportedException($"No string length for {prop?.Name} specified.");
                }
                return;
            }
            else if (type.IsEnum)
            {
                // schrijf enum als 4-byte int
                int enumVal = value != null ? Convert.ToInt32(value) : 0;
                bw.Write(enumVal);
            }
            else if (!type.IsPrimitive && type.IsClass)
            {
                if (value == null)
                {
                    // schrijf lege instantie
                    var emptyInstance = Activator.CreateInstance(type);
                    var method = typeof(ElementsTemplate) // vervang door de class naam waar WriteToBinaryWriter staat
                        .GetMethod(nameof(WriteToBinaryWriter))
                        .MakeGenericMethod(type);
                    method.Invoke(null, new object[] { bw, emptyInstance });
                }
                else
                {
                    var method = typeof(ElementsTemplate)
                        .GetMethod(nameof(WriteToBinaryWriter))
                        .MakeGenericMethod(type);
                    method.Invoke(null, new object[] { bw, value });
                }
            }
            else
            {
                throw new NotSupportedException($"Type {type.Name} is not supported for writing.");
            }
        }*/
    }
}
