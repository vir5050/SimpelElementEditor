using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace SimpelElementEditor.ESO
{
    public class NPC_TRANSMIT_SERVICE : ICloneable
    {
        public object Clone() { return this.MemberwiseClone(); }
        public int id { get; set; } = 0;
        public string name { get; set; }
        [Reader.FixedArrayLengthAttribute(16)]
        public TARGETS[] targets { get; set; }
        public int id_dialog { get; set; }

        public override string ToString()
        {
            return $"{id}: {name}";
        }
        public class TARGETS : ICloneable
        {
            public object Clone() { return this.MemberwiseClone(); }
            public COMMON.WORLDS id_world { get; set; }
            [Reader.FixedArrayLengthAttribute(32)]
            public string name { get; set; }
            public float x { get; set; }
            public float y { get; set; }
            public float z { get; set; }
            public int fee { get; set; }
            public int required_level { get; set; }

            public override string ToString()
            {
                return $"{id_world}: {name}";
            }
        }
    }
}
