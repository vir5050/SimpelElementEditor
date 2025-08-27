using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SimpelElementEditor.ESO
{
    public class NPC_TALK_SERVICE : ICloneable
    {
        public object Clone() { return this.MemberwiseClone(); }
        public int id { get; set; } = 0;
        public string name { get; set; }
        public int id_dialog { get; set; }

        public override string ToString()
        {
            return $"{id}: {name}";
        }
    }
}
