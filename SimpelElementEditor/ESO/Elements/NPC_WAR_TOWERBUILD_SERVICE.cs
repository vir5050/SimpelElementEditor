using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace SimpelElementEditor.ESO
{
    public class NPC_WAR_TOWERBUILD_SERVICE : ICloneable
    {
        public object Clone() { return this.MemberwiseClone(); }
        public int id { get; set; } = 0;
        public string name { get; set; }
        [Reader.FixedArrayLengthAttribute(4)]
        public BUILD_INFO[] build_info { get; set; }

        public override string ToString()
        {
            return $"{id}: {name}";
        }
        public class BUILD_INFO : ICloneable
        {
            public object Clone() { return this.MemberwiseClone(); }
            public int id_in_build { get; set; }
            public int id_buildup { get; set; }
            [TypeConverter(typeof(ItemIdConverter))]
            public int id_object_need { get; set; }
            public int time_use { get; set; }
            public int fee { get; set; }

            public override string ToString()
            {
                return $"{id_in_build}: {id_buildup}";
            }
        }
    }
}
