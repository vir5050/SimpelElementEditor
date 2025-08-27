using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace SimpelElementEditor.ESO
{
    public class TEXT_FIREWORKS_ESSENCE : ICloneable
    {
        public object Clone() { return this.MemberwiseClone(); }
        public int id { get; set; }
        public string name { get; set; }
        public int file_matter { get; set; }
        public int file_icon { get; set; }
        public int file_fw { get; set; }
        public int level { get; set; }

        [Reader.FixedArrayLengthAttribute(512)]
        public string char_can_use { get; set; }
        public int max_char { get; set; }
        [TypeConverter(typeof(MoneyConverter))]
        public int price { get; set; }
        [TypeConverter(typeof(MoneyConverter))]
        public int shop_price { get; set; }
        public int pile_num_max { get; set; }
                [Editor(typeof(COMMON.FlagsEnumEditor), typeof(System.Drawing.Design.UITypeEditor))]        public COMMON.ProcTypeFlags proc_type { get; set; }


        public override string ToString()
        {
            return $"{id}: {name}";
        }
    }
}
