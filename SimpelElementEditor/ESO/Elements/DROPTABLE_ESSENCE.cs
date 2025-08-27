using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace SimpelElementEditor.ESO.Elements
{
    public class DROPTABLE_ESSENCE : ICloneable
    {
        public object Clone() { return this.MemberwiseClone(); }
        public int id { get; set; } = 0;

        [Reader.LookupType(typeof(DROPTABLE_TYPE))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int id_type { get; set; }
        public string name { get; set; }

        [Reader.FixedArrayLengthAttribute(5)]
        public float[] probability { get; set; }

        [Reader.FixedArrayLengthAttribute(64)]
        public DROPS[] drops { get; set; }
        public override string ToString()
        {
            return $"{id}: {name}";
        }
    }

    public class DROPS : ICloneable
    {
        public object Clone() { return this.MemberwiseClone(); }
        [TypeConverter(typeof(ItemIdConverter))]
        public int id_obj { get; set; }
        public float probability { get; set; }
        public override string ToString()
        {
            return $"{probability*100}%: {ItemLookupHelper.GetItemName(id_obj)}";
        }
    }
}
