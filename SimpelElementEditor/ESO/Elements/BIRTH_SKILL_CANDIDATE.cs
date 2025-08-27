using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SimpelElementEditor.ESO.Elements
{
    public class BIRTH_SKILL_CANDIDATE : ICloneable
    {
        public object Clone() { return this.MemberwiseClone(); }
        public int id { get; set; } = 0;
        public string name { get; set; }

        [Reader.FixedArrayLengthAttribute(24)]
        public int[] birth_skills { get; set; }

        [Reader.FixedArrayLengthAttribute(32)]
        public int[] fixed_birth_skills { get; set; }

        public override string ToString()
        {
            return $"{id}: {name}";
        }
    }
}
