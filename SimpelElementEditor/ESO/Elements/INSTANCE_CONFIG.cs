using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace SimpelElementEditor.ESO.Elements
{
    public class INSTANCE_CONFIG : ICloneable
    {
        public object Clone() { return this.MemberwiseClone(); }
        public int id { get; set; }
        public string name { get; set; }
        public int pvp_type { get; set; }
        public COMMON.WORLDS world_index { get; set; }
        public int inst_time { get; set; }
        public int inst_revive_time { get; set; }
        public int max_copy_num { get; set; }
        public int midway_join { get; set; }
        public int zero_player_time { get; set; }
        public int min_player_num { get; set; }
        public int min_player_time { get; set; }
        public int play_type { get; set; }
        public int monster_lvl_adjust { get; set; }
        public int win_def_time { get; set; }
        public int lose_pve { get; set; }
        public int id_global_ctrl { get; set; }
        public int id_ctrl_prep { get; set; }
        public int id_ctrl_begin { get; set; }
        public int id_ctrl_end { get; set; }
        [Reader.FixedArrayLengthAttribute(5)]
        public int[] score_task_ids { get; set; }
        [Reader.FixedArrayLengthAttribute(5)]
        public int[] score_awards { get; set; }
        public int max_spectator_num { get; set; }
        public int id_spectator_item { get; set; }
        public int no_spectator_min_x { get; set; }
        public int no_spectator_min_y { get; set; }
        public int no_spectator_min_z { get; set; }
        public int no_spectator_max_x { get; set; }
        public int no_spectator_max_y { get; set; }
        public int no_spectator_max_z { get; set; }
        [Reader.FixedArrayLengthAttribute(2)]
        public SIDES[] sides { get; set; }
        public int wait_time { get; set; }
        public int balance_popu { get; set; }
        public int auto_assign_side { get; set; }
        public float popu_ratio { get; set; }
        public int team_mode { get; set; }
        public int family_mode { get; set; }
        public int faction_mode { get; set; }


        public override string ToString()
        {
            return $"{id}: {name}";
        }
        public class SIDES : ICloneable
        {
            public object Clone() { return this.MemberwiseClone(); }
            public int max_player { get; set; }
            public int start_player_num { get; set; }
            public int close_player_num { get; set; }
            public int min_level_req { get; set; }
            public int max_level_req { get; set; }
            public int max_prof_player { get; set; }
            public int req_camp { get; set; }
            [TypeConverter(typeof(ItemIdConverter))]
            public int req_item { get; set; }
            [TypeConverter(typeof(MoneyConverter))]
            public int req_money { get; set; }
            public int enter_pos { get; set; }
            public int def_revive_pos { get; set; }
            public int revive_pos_1 { get; set; }
            public int revive_pos_2 { get; set; }
            public int revive_pos_3 { get; set; }
            public int revive_pos_4 { get; set; }
            public int revive_pos_5 { get; set; }
            public int revive_pos_6 { get; set; }
            public int revive_pos_7 { get; set; }
            public int revive_pos_8 { get; set; }
            [Reader.LookupType(typeof(MONSTER_ESSENCE))]
            [TypeConverter(typeof(LookupIdConverter))]
            public int monster_dummy { get; set; }
            [Reader.LookupType(typeof(MONSTER_ESSENCE))]
            [TypeConverter(typeof(LookupIdConverter))]
            public int loot_dummy { get; set; }
            public int task_1 { get; set; }
            public int task_2 { get; set; }
            public int task_3 { get; set; }
            public int task_4 { get; set; }
            public int task_5 { get; set; }
            [Reader.LookupType(typeof(MONSTER_ESSENCE))]
            [TypeConverter(typeof(LookupIdConverter))]
            public int win_kill_monster { get; set; }
            public int win_res_point { get; set; }
            public int win_score_point { get; set; }
            [Reader.FixedArrayLengthAttribute(16)]
            public RES_HOLDS[] res_holds { get; set; }
            [TypeConverter(typeof(ItemIdConverter))]
            public int id_reward_win { get; set; }
            [TypeConverter(typeof(ItemIdConverter))]
            public int id_reward_lose { get; set; }
            [TypeConverter(typeof(ItemIdConverter))]
            public int id_reward_deuce { get; set; }
            [Reader.FixedArrayLengthAttribute(3)]
            public float[] start_area_min { get; set; }
            [Reader.FixedArrayLengthAttribute(3)]
            public float[] start_area_max { get; set; }
            [Reader.FixedArrayLengthAttribute(10)]
            public int[] battle_point_task_award { get; set; }
            [Reader.FixedArrayLengthAttribute(10)]
            public int[] battle_point { get; set; }
            public int init_battle_point { get; set; }
            public int fail_battle_point { get; set; }
            public COMMON.REPU_TYPE need_repu_id { get; set; }
            public int need_repu_amount { get; set; }
            public int drop_repu_decay_base { get; set; }


            public override string ToString()
            {
                return $"side";
            }
            public class RES_HOLDS : ICloneable
            {
                public object Clone() { return this.MemberwiseClone(); }
                public int id_res { get; set; }
                public int res_inc_speed { get; set; }

                public override string ToString()
                {
                    return $"{id_res}: {res_inc_speed}";
                }
            }
        }
    }
}
