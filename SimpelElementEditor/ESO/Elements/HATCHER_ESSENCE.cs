using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace SimpelElementEditor.ESO.Elements
{
    public class HATCHER_ESSENCE : ICloneable
    {
        public object Clone() { return this.MemberwiseClone(); }
        public int id { get; set; }

        [Reader.LookupType(typeof(HATCHER_MAJOR_TYPE))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int id_major_type { get; set; }
        public string name { get; set; }

        [Reader.LookupType(typeof(PathData.path))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int file_matter { get; set; }

        [Reader.LookupType(typeof(PathData.path))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int file_icon { get; set; }
        public double need_exp { get; set; }
        public int need_level { get; set; }
        public int exp_inc_type { get; set; }
        [Reader.LookupType(typeof(MONSTER_ESSENCE))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int monster_id { get; set; }
        public int monster_exp { get; set; }
        [Reader.LookupType(typeof(EQUIPMENT_ESSENCE))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int weapon_id { get; set; }

        [Reader.LookupType(typeof(Skills.skill))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int skill_id { get; set; }

        [Reader.LookupType(typeof(TasksSimple.task))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int task_id { get; set; }
        public int task_exp { get; set; }
        [Reader.LookupType(typeof(PRODUCE_TYPE_CONFIG))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int produce_id { get; set; }
        public int produce_exp { get; set; }

        [Reader.LookupType(typeof(MINE_ESSENCE))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int ore_id { get; set; }
        public int ore_exp { get; set; }

        [Reader.LookupType(typeof(RECIPE_ESSENCE))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int recipe_id { get; set; }
        public int recipe_exp { get; set; }
        [Reader.FixedArrayLengthAttribute(64)]
        public HATCHED_ITEM[] hatched_item { get; set; }
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

        public class HATCHED_ITEM : ICloneable
        {
            public object Clone() { return this.MemberwiseClone(); }



            [TypeConverter(typeof(ItemIdConverter))]
            public int hatched_id { get; set; } = 0;
            public float hatched_rate { get; set; }

            public override string ToString()
            {
                return $"{ItemLookupHelper.GetItemName(hatched_id)}: {hatched_rate*100}%";
            }
        }
    }
}
