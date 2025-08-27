using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SimpelElementEditor.COMMON;

namespace SimpelElementEditor.ESO.Elements
{
    public class BIRTHSKILL_RESET_SERVICE : ICloneable
    {
        public object Clone() { return this.MemberwiseClone(); }
        public int id { get; set; } = 0;
        public string name { get; set; }

        [Reader.FixedArrayLengthAttribute(8)]
        public int[] objects_need { get; set; }
        
        public override string ToString()
        {
            return $"{id}: {name}";
        }
    }
}
