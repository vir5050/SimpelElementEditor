using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SimpelElementEditor.ESO
{
    public class NPC_HOTEL_SERVICE : ICloneable
    {
        public object Clone() { return this.MemberwiseClone(); }
        public int id { get; set; } = 0;
        public string name { get; set; }
        public COMMON.WORLDS id_world { get; set; }
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }

        public override string ToString()
        {
            return $"{id}: {name}";
        }
    }
}
