using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace SimpelElementEditor.ESO
{
    public class SUITE_ESSENCE : ICloneable
    {
        public object Clone() { return this.MemberwiseClone(); }
        public int id { get; set; }
        public string name { get; set; }
        public int max_equips { get; set; }
        [Reader.FixedArrayLengthAttribute(14)]
        public EQUIPMENTS[] equipments { get; set; }
        [Reader.FixedArrayLengthAttribute(13)]
        public EQUIPMENTS[] addons { get; set; }
        [Reader.FixedArrayLengthAttribute(128)]
        public string file_gfx { get; set; }
        public int hh_type { get; set; }


        public override string ToString()
        {
            return $"{id}: {name}";
        }
        public class EQUIPMENTS : ICloneable
        {
            public object Clone() { return this.MemberwiseClone(); }
            public int id { get; set; }


            public override string ToString()
            {
                return $"{id}";
            }
        }
    }
}
