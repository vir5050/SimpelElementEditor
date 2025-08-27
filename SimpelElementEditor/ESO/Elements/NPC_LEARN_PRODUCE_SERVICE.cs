using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace SimpelElementEditor.ESO
{
    public class NPC_LEARN_PRODUCE_SERVICE : ICloneable
    {
        public object Clone() { return this.MemberwiseClone(); }
        public int id { get; set; } = 0;
        public string name { get; set; }
        [Reader.FixedArrayLengthAttribute(32)]
        public INFO[] info { get; set; }

        public override string ToString()
        {
            return $"{id}: {name}";
        }
        public class INFO : ICloneable
        {
            public object Clone() { return this.MemberwiseClone(); }

            [Reader.LookupType(typeof(PRODUCE_TYPE_CONFIG))]
            [TypeConverter(typeof(LookupIdConverter))]
            public int produce_skill { get; set; }
            [TypeConverter(typeof(MoneyConverter))]
            public int learn_fee { get; set; }

            public override string ToString()
            {
                return $"{produce_skill}";
            }
        }
    }
}
