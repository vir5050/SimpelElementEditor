using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;
using SimpelElementEditor.ESO.Elements;

namespace SimpelElementEditor.ESO.ExtraDrops
{
    public class EXTRADROPTABLE : ICloneable
    {
        public object Clone() { return this.MemberwiseClone(); }
        //public int monsterCount { get; set; }
        public List<MONSTER> id_monster { get; set; } = new List<MONSTER>();
        [Reader.FixedArrayLengthAttribute(256)]
        public ITEM[] item { get; set; } = new ITEM[256];
        public string name { get; set; }
        public int type { get; set; }
        // REPLACE  = 1
        // TYPE_ADDON   = 2
        [Reader.FixedArrayLengthAttribute(8)]
        public float[] drop_num_probability { get; set; } = new float[8];
        public override string ToString()
        {
            if (id_monster.Count > 0)
                return $"{name}:{LookupHelper.GetLookupString(this, nameof(MONSTER.id_monster))}";
            else
                return $"No monster assigned";
        }
        public class MONSTER : ICloneable
        {
            public object Clone() { return this.MemberwiseClone(); }
            [Reader.LookupType(typeof(MONSTER_ESSENCE))]
            [TypeConverter(typeof(LookupIdConverter))]
            public float id_monster { get; set; }
            public override string ToString()
            {
                return $"{LookupHelper.GetLookupString(this, nameof(id_monster))}";
            }
        }
        public class ITEM : ICloneable
        {
            public object Clone() { return this.MemberwiseClone(); }
            [TypeConverter(typeof(ItemIdConverter))]
            public int id { get; set; }
            public float probability { get; set; }
            public override string ToString()
            {
                return $"{ItemLookupHelper.GetItemName(id)}: {probability*100}%";
            }
        }
    }
}
