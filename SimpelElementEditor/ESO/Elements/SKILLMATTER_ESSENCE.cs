using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace SimpelElementEditor.ESO.Elements
{
    public class SKILLMATTER_ESSENCE : ICloneable
    {
        public object Clone() { return this.MemberwiseClone(); }
        public int id { get; set; }
        public string name { get; set; }
        [Reader.LookupType(typeof(PathData.path))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int file_matter { get; set; }
        [Reader.LookupType(typeof(PathData.path))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int file_icon { get; set; }
        public int level_required { get; set; }
        [Reader.LookupType(typeof(Skills.skill))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int id_skill { get; set; }
        public int level_skill { get; set; }
        public COMMON.BOOL only_in_war { get; set; }
        public int cool_type_mask { get; set; }
        public int cool_time { get; set; }
        public int permenent { get; set; }
        [Reader.LookupType(typeof(Skills.skill))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int cast_skill { get; set; }

        [Reader.LookupType(typeof(MONSTER_ESSENCE))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int id_target { get; set; }
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
    }
}
