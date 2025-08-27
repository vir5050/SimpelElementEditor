using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace SimpelElementEditor.ESO.Elements
{
    public class GARDEN_ESSENCE : ICloneable
    {
        public object Clone() { return this.MemberwiseClone(); }
        public int id { get; set; } = 0;
        public string name { get; set; }
        public int init_level { get; set; }
        public int max_level { get; set; }
        public int exp_list_id { get; set; }

        [Reader.FixedArrayLengthAttribute(10)]
        public LEVELS[] levels { get; set; }
        public int plow_ward { get; set; }
        public override string ToString()
        {
            return $"{id}: {name}";
        }
        public class LEVELS : ICloneable
        {
            public object Clone() { return this.MemberwiseClone(); }
            public int farmland_num { get; set; }
            public int loveland_num { get; set; }
            public int arable_loveland_num { get; set; }
            public int new_farmland_cost { get; set; }
            public int new_loveland_cost { get; set; }
            public float exp_ratio { get; set; }
            public int extra_exp { get; set; }
            public int exp_time { get; set; }
            public int bag_length { get; set; }
            public int bag_width { get; set; }
            public int file_model { get; set; }
            public int hanger_mask { get; set; }
            public int need_exp { get; set; }
            public int level_up_award { get; set; }
        }
    }
}
