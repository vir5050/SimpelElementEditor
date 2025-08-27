using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace SimpelElementEditor.ESO
{
    public class UPGRADE_TRANSFER_SERVICE : ICloneable
    {
        public object Clone() { return this.MemberwiseClone(); }
        public int id { get; set; } = 0;
        public string name { get; set; }

        [Reader.FixedArrayLengthAttribute(20)]
        public TRANSFER_LEVELS[] transfer_levels { get; set; }

        public override string ToString()
        {
            return $"{id}: {name}";
        }
        public class TRANSFER_LEVELS : ICloneable
        {
            public object Clone() { return this.MemberwiseClone(); }
            [TypeConverter(typeof(ItemIdConverter))]
            public int objects_need { get; set; } = 0;
            public float success_rate { get; set; }
            public int fee { get; set; }

            public override string ToString()
            {
                return $"{objects_need}";
            }
        }
    }
}
