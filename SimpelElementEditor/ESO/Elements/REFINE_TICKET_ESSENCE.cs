using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace SimpelElementEditor.ESO
{
    public class REFINE_TICKET_ESSENCE : ICloneable
    {
        public object Clone() { return this.MemberwiseClone(); }
        public int id { get; set; }
        public string name { get; set; }
        public int file_matter { get; set; }
        [Reader.LookupType(typeof(PathData.path))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int file_icon { get; set; }
        [Reader.LookupType(typeof(PathData.path))]
        [TypeConverter(typeof(LookupIdConverter))]
        public COMMON.EquipInventoryItemType equip_mask { get; set; }
        public COMMON.CharacterClassFlags equip_class { get; set; }
        public int refine_times { get; set; }
        public int socket_times { get; set; }
        public int transfer_refine_times { get; set; }
        public float ext_reserved_prob { get; set; }
        public float ext_succeed_prob { get; set; }
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
