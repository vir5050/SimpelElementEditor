using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace SimpelElementEditor.ESO.Elements
{
    public class GARDEN_ORNAMENT_ESSENCE : ICloneable
    {
        public object Clone() { return this.MemberwiseClone(); }
        public int id { get; set; } = 0;
        public string name { get; set; }
        public int file_icon { get; set; }
        public int hanger_index { get; set; }
        public int type { get; set; }
        public int garden_level_min { get; set; }
        public int level { get; set; }
        public int file_model { get; set; }
        public int exp_time { get; set; }
        public float exp_ratio { get; set; }
        public int extra_exp { get; set; }
        public double bag_shape { get; set; }
        public int bag_color { get; set; }
        public int inv_icon { get; set; }
        public int sell_price { get; set; }
        public int buy_price { get; set; }
        public int pile_num_max { get; set; }
                [Editor(typeof(COMMON.FlagsEnumEditor), typeof(System.Drawing.Design.UITypeEditor))]        public COMMON.ProcTypeFlags proc_type { get; set; }
        public override string ToString()
        {
            return $"{id}: {name}";
        }
    }
}
