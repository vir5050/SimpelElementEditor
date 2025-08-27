using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace SimpelElementEditor.ESO
{
    public class NPC_EQUIPUNDESTROY_SERVICE : ICloneable
    {
        public object Clone() { return this.MemberwiseClone(); }
        public int id { get; set; } = 0;
        public string name { get; set; }
        [TypeConverter(typeof(ItemIdConverter))]

        public int id_object_need { get; set; }
        [TypeConverter(typeof(MoneyConverter))]
        public int price { get; set; }

        public override string ToString()
        {
            return $"{id}: {name}";
        }
    }
}
