using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace SimpelElementEditor.ESO
{
    public class NPC_TASK_MATTER_SERVICE : ICloneable
    {
        public object Clone() { return this.MemberwiseClone(); }
        public int id { get; set; } = 0;
        public string name { get; set; }

        [Reader.FixedArrayLengthAttribute(16)]
        public TASKS[] tasks { get; set; }

        public override string ToString()
        {
            return $"{id}: {name}";
        }
        public class TASKS : ICloneable
        {
            public object Clone() { return this.MemberwiseClone(); }
            public int id_task { get; set; } = 0;
            [Reader.FixedArrayLengthAttribute(4)]
            public TAKS_MATTERS[] taks_matters { get; set; } //typo is on not on me! :)

            public override string ToString()
            {
                return $"{id_task}";
            }
            public class TAKS_MATTERS : ICloneable //typo still not on me ;)
            {
                public object Clone() { return this.MemberwiseClone(); }

                [TypeConverter(typeof(ItemIdConverter))]
                public int id_matter { get; set; }
                public int num_matter { get; set; }

                public override string ToString()
                {
                    return ItemLookupHelper.GetItemString(id_matter);
                }
            }
        }
    }
}
