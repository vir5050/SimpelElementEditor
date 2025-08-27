using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace SimpelElementEditor.ESO
{
    public class NPC_SUPER_UPGRADE_SERVICE : ICloneable
    {
        public object Clone() { return this.MemberwiseClone(); }
        public int id { get; set; } = 0;
        public string name { get; set; }

        [Reader.FixedArrayLengthAttribute(6)]
        public LEVELS[] levels { get; set; }
        public override string ToString()
        {
            return $"{id}: {name}";
        }

        public class LEVELS : ICloneable
        {
            public object Clone() { return this.MemberwiseClone(); }
            public int super_upgrade_level { get; set; }
            [Reader.FixedArrayLengthAttribute(4)]
            public ITEMS[] items { get; set; }
            public int money { get; set; }
            [Reader.FixedArrayLengthAttribute(4)]
            public REPUTATIONS[] reputations { get; set; }
            public override string ToString()
            {
                return $"{super_upgrade_level}";
            }
            public class ITEMS : ICloneable
            {
                public object Clone() { return this.MemberwiseClone(); }
                [TypeConverter(typeof(ItemIdConverter))]
                public int id { get; set; }
                public int num { get; set; }
                public override string ToString()
                {
                    return $"{ItemLookupHelper.GetItemName(id)}x {num}";
                }
            }
            public class REPUTATIONS : ICloneable
            {
                public object Clone() { return this.MemberwiseClone(); }
                public COMMON.REPU_TYPE id { get; set; }
                public int num { get; set; }
                public override string ToString()
                {
                    return $"{id}: {num}";
                }
            }
        }
    }
}
