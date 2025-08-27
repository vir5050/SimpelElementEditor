using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace SimpelElementEditor.ESO
{
    public class PET_PRODUCE_ESSENCE : ICloneable
    {
        public object Clone() { return this.MemberwiseClone(); }
        public int id { get; set; } = 0;
        public string name { get; set; }
        public int level { get; set; }
        [Reader.FixedArrayLengthAttribute(64)]
        public RESULTANTS[] resultants { get; set; }
        [Reader.FixedArrayLengthAttribute(8)]
        public MATERIALS[] materials { get; set; }
        public int pet_produce_type { get; set; }
        public int proficency_need { get; set; }
        public int proficency_got { get; set; }
        public override string ToString()
        {
            return $"{id}: {name}";
        }
        public class RESULTANTS : ICloneable
        {
            public object Clone() { return this.MemberwiseClone(); }
            public float prop { get; set; }
            [TypeConverter(typeof(ItemIdConverter))]
            public int id { get; set; }
            public int min_num { get; set; }
            public int max_num { get; set; }
            public override string ToString()
            {
                return $"{id} - {prop*100}%";
            }
        }
        public class MATERIALS : ICloneable
        {
            public object Clone() { return this.MemberwiseClone(); }
            [TypeConverter(typeof(ItemIdConverter))]
            public int id { get; set; }
            public int num { get; set; }
            public override string ToString()
            {
                return $"{id}: {num}";
            }
        }
    }
}
