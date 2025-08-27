using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace SimpelElementEditor.ESO.Elements
{
    public class NPC_ESSENCE : ICloneable
    {
        public object Clone() { return this.MemberwiseClone(); }
        public int id { get; set; } = 0;
        public string name { get; set; }
        [Reader.FixedArrayLengthAttribute(16)]

        [Reader.LookupType(typeof(NPC_TYPE))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int id_type { get; set; }
        public float refresh_time { get; set; }
        public int attack_rule { get; set; }

        [Reader.LookupType(typeof(PathData.path))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int file_model { get; set; }

        [Reader.LookupType(typeof(MONSTER_ESSENCE))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int id_src_monster { get; set; }
        [Reader.FixedArrayLengthAttribute(512)]
        public string hello_msg { get; set; }
        public int id_to_discover { get; set; }
        public COMMON.BOOL domain_related { get; set; }
        public COMMON.BOOL guard_npc { get; set; }

        [Reader.LookupType(typeof(NPC_TALK_SERVICE))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int id_talk_service { get; set; }

        [Reader.LookupType(typeof(NPC_SELL_SERVICE))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int id_sell_service { get; set; }

        [Reader.LookupType(typeof(NPC_LEARN_PRODUCE_SERVICE))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int id_learn_produce { get; set; }

        [Reader.LookupType(typeof(NPC_HOTEL_SERVICE))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int id_hotel_service { get; set; }
        public int id_gshop_majortype { get; set; }

        [Reader.LookupType(typeof(NPC_BUY_SERVICE))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int id_buy_service { get; set; }

        [Reader.LookupType(typeof(NPC_TASK_OUT_SERVICE))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int id_task_out_service { get; set; }

        [Reader.LookupType(typeof(NPC_TASK_IN_SERVICE))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int id_task_in_service { get; set; }

        [Reader.LookupType(typeof(NPC_TASK_MATTER_SERVICE))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int id_task_matter_service { get; set; }

        [Reader.LookupType(typeof(NPC_HEAL_SERVICE))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int id_heal_service { get; set; }

        [Reader.LookupType(typeof(NPC_TRANSMIT_SERVICE))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int id_transmit_service { get; set; }

        [Reader.LookupType(typeof(NPC_PROXY_SERVICE))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int id_proxy_service { get; set; }

        [Reader.LookupType(typeof(NPC_STORAGE_SERVICE))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int id_storage_service { get; set; } //all services later in the file, TODO LLATER
        [Reader.LookupType(typeof(NPC_WAR_TOWERBUILD_SERVICE))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int id_war_towerbuild_service { get; set; }
        [Reader.LookupType(typeof(NPC_RESETPROP_SERVICE))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int id_resetprop_service { get; set; }
        [Reader.LookupType(typeof(NPC_EQUIPBIND_SERVICE))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int id_equipbind_service { get; set; }
        [Reader.LookupType(typeof(NPC_EQUIPDESTROY_SERVICE))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int id_equipdestroy_service { get; set; }
        [Reader.LookupType(typeof(NPC_EQUIPUNDESTROY_SERVICE))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int id_equipundestroy_service { get; set; }
        [Reader.LookupType(typeof(BIRTHSKILL_RESET_SERVICE))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int id_birth_reset_service { get; set; }
        [Reader.LookupType(typeof(ITEM_TRADE_CONFIG))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int id_item_trade_service { get; set; }
        [Reader.LookupType(typeof(NPC_PROF_DEMOTION_SERVICE))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int id_prof_demotion { get; set; }
        public int combined_services { get; set; }
        public COMMON.BOOL has_pkvalue_service { get; set; }
        [TypeConverter(typeof(MoneyConverter))]
        public int fee_per_pkvalue { get; set; }
        [Reader.LookupType(typeof(BIRTHSKILL_RESET_SERVICE))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int id_birthskill_reset_service { get; set; }
        [Reader.LookupType(typeof(UPGRADE_TRANSFER_SERVICE))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int id_upgrade_transfer_service { get; set; }
        [Reader.LookupType(typeof(NPC_SUPER_UPGRADE_SERVICE))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int id_super_upgrade_service { get; set; }
        public bool service_install { get; set; }
        public bool service_uninstall { get; set; }
        public bool service_repu_install { get; set; }
        public bool service_equip_hole { get; set; }
        public bool service_repu_equip_hole { get; set; }
        public bool service_equipment_exchange_service { get; set; }
        public bool service_temp2 { get; set; }
        public bool service_temp3 { get; set; }
        [Reader.LookupType(typeof(MINE_ESSENCE))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int id_mine { get; set; }
        public int id_ai_script { get; set; }
        public COMMON.BOOL collision_in_server { get; set; }

        public override string ToString()
        {
            return $"{id}: {name}";
        }
    }
}
