using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace SimpelElementEditor.ESO
{
    public class SEED_ESSENCE : ICloneable
    {
        public object Clone() { return this.MemberwiseClone(); }
        public int id { get; set; } = 0;
        public string name { get; set; }
        [Reader.LookupType(typeof(PathData.path))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int file_icon { get; set; }
        public int level { get; set; }
        public int garden_level_min { get; set; }
        public int season_num { get; set; }

        [Reader.FixedArrayLengthAttribute(5)]
        public STAGES[] stages { get; set; }
        public int file_wither_model { get; set; }
        public int protect_time { get; set; }
        public int output_min { get; set; }
        public int output_max { get; set; }
        public int harvest_exp { get; set; }
        public int harvest_money { get; set; }
        public int steal_exp { get; set; }
        public int steal_money { get; set; }
        public int water_exp { get; set; }
        public int water_money { get; set; }
        public int weed_exp { get; set; }
        public int weed_money { get; set; }
        public int deworm_exp { get; set; }
        public int deworm_money { get; set; }
        public int seed_exp { get; set; }
        public int seed_money { get; set; }
        public int plow_exp { get; set; }
        public int plow_money { get; set; }
        public int steal_ratio { get; set; }
        public int min_per_steal { get; set; }
        public int max_per_steal { get; set; }
        public int sell_price { get; set; }
        public int buy_price { get; set; }
        public int fruit_id { get; set; }
        public int pile_num_max { get; set; }
                [Editor(typeof(COMMON.FlagsEnumEditor), typeof(System.Drawing.Design.UITypeEditor))]        public COMMON.ProcTypeFlags proc_type { get; set; }
        public override string ToString()
        {
            return $"{id}: {name}";
        }
        public class STAGES : ICloneable
        {
            public object Clone() { return this.MemberwiseClone(); }
            public int last_time { get; set; } = 0;
            public int file_model { get; set; }
            public override string ToString()
            {
                return $"{file_model}: {last_time}";
            }
        }
        }
}
