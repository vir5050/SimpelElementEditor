using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace SimpelElementEditor.ESO
{
    public class PLAYER_STATUS_POINT_CONFIG : ICloneable
    {
        public object Clone() { return this.MemberwiseClone(); }
        public int id { get; set; }
        public string name { get; set; }
        [Reader.FixedArrayLengthAttribute(200)]
        public int[] status_point { get; set; }
        public override string ToString()
        {
            return $"{id}: {name}";
        }
    }
}
