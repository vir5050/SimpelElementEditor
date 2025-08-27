using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace SimpelElementEditor.ESO
{
    public class TALISMAN_MAINPART_ESSENCE : ICloneable
    {
        public object Clone() { return this.MemberwiseClone(); }
        public int id { get; set; }
        public string name { get; set; }
        [Reader.FixedArrayLengthAttribute(4)]
        public int[] file_model { get; set; }
        public int file_matter { get; set; }
        public int file_icon { get; set; }
        [Reader.FixedArrayLengthAttribute(32)]
        public string show_level { get; set; }
        public int level { get; set; }
        public int init_level { get; set; }
        public int character_combo_id { get; set; }
        public int require_gender { get; set; }
        public int require_level { get; set; }
        public int sect_mask { get; set; }
        public int require_level2 { get; set; }
        public int max_level { get; set; }
        public int max_level2 { get; set; }
        public float energy_recover_speed { get; set; }
        public float energy_recover_factor { get; set; }
        public float energy_drop_speed { get; set; }
        [TypeConverter(typeof(MoneyConverter))]
        public int fee_levelup { get; set; }
        [TypeConverter(typeof(MoneyConverter))]
        public int fee_expfood { get; set; }
        [TypeConverter(typeof(MoneyConverter))]
        public int fee_reset { get; set; }
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
