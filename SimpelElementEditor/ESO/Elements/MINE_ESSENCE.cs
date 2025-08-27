using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace SimpelElementEditor.ESO.Elements
{
    public class MINE_ESSENCE : ICloneable
    {
        public object Clone() { return this.MemberwiseClone(); }
        public int id { get; set; }
        [Reader.LookupType(typeof(MINE_TYPE))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int id_type { get; set; }
        public string name { get; set; }
        public int level { get; set; }
        public int level_required { get; set; }
        [TypeConverter(typeof(ItemIdConverter))]
        public int id_equipment_required { get; set; }
        public COMMON.BOOL eliminate_tool { get; set; }
        public int time_min { get; set; }
        public int time_max { get; set; }
        public int exp { get; set; }
        public int skillpoint { get; set; }

        [Reader.LookupType(typeof(PathData.path))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int file_model { get; set; }
        [Reader.FixedArrayLengthAttribute(16)]
        public MATERIALS[] materials { get; set; }
        public int num1 { get; set; }
        public float probability1 { get; set; }
        public int num2 { get; set; }
        public float probability2 { get; set; }
        [TypeConverter(typeof(IntStringListConverter))]
        [IntStringList(nameof(DataFiles.tasksSimpleTemplate))]
        public int task_in { get; set; }
        [TypeConverter(typeof(IntStringListConverter))]
        [IntStringList(nameof(DataFiles.tasksSimpleTemplate))]
        public int task_out { get; set; }
        public int uninterruptable { get; set; }
        [Reader.FixedArrayLengthAttribute(4)]
        public NPCGEN[] npcgen { get; set; }
        public AGGROS aggros { get; set; }
        public int role_in_war { get; set; }
        public int permenent { get; set; }
        public int activate_controller_mode { get; set; }
        [Reader.FixedArrayLengthAttribute(4)]
        public int[] activate_controller_id { get; set; }
        public int deactivate_controller_mode { get; set; }
        [Reader.FixedArrayLengthAttribute(4)]
        public int[] deactivate_controller_id { get; set; }
        [Reader.FixedArrayLengthAttribute(32)]
        public string action { get; set; }
        [Reader.FixedArrayLengthAttribute(512)]
        public string type_showed { get; set; }
        public int is_multiple { get; set; }
        public int id_recipe { get; set; }
        public float prop_eliminate { get; set; }
        public int file_occupy_icon { get; set; }
        [Reader.FixedArrayLengthAttribute(4)]
        public MINE_RLT[] mine_rlt { get; set; }
        public int faction { get; set; }
        public int is_center_mine { get; set; }
        public int is_only_by_host { get; set; }


        public override string ToString()
        {
            return $"{id}: {name}";
        }
        public class MATERIALS : ICloneable
        {
            public object Clone() { return this.MemberwiseClone(); }
            [TypeConverter(typeof(ItemLookupHelper))]
            public int id { get; set; }
            public float probability { get; set; }

            public override string ToString()
            {
                return $"{probability*100}%{ItemLookupHelper.GetItemName(id)}";
            }
        }
        public class NPCGEN : ICloneable
        {
            public object Clone() { return this.MemberwiseClone(); }
            [Reader.LookupType(typeof(MONSTER_ESSENCE))]
            [TypeConverter(typeof(LookupIdConverter))]
            public int id_monster { get; set; }
            public int num { get; set; }
            public float radius { get; set; }

            public override string ToString()
            {
                return $"{id_monster}x{num}";
            }
        }
        public class AGGROS : ICloneable
        {
            public object Clone() { return this.MemberwiseClone(); }
            public int monster_faction { get; set; }
            public float radius { get; set; }
            public int num { get; set; }

            public override string ToString()
            {
                return $"{monster_faction}";
            }
        }
        public class MINE_RLT : ICloneable
        {
            public object Clone() { return this.MemberwiseClone(); }
            public int faction { get; set; }
            [Reader.FixedArrayLengthAttribute(4)]
            public int[] open_ctrls { get; set; }
            [Reader.FixedArrayLengthAttribute(4)]
            public int[] close_ctrls { get; set; }

            public override string ToString()
            {
                return $"MINE_RLT";
            }
        }
    }
}
