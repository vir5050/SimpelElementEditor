using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SimpelElementEditor.ESO.Elements
{
    public class GARDEN_FUNC_ESSENCE : ICloneable
    {
        public object Clone() { return this.MemberwiseClone(); }
        public int id { get; set; } = 0;
        public string name { get; set; }
        public int type { get; set; }
        public int time { get; set; }
        public float prop { get; set; }
        public int file_dog_model { get; set; }

        public override string ToString()
        {
            return $"{id}: {name}";
        }
    }
}
