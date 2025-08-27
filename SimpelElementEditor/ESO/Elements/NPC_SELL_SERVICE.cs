using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace SimpelElementEditor.ESO
{
    public class NPC_SELL_SERVICE : ICloneable
    {
        public object Clone() { return this.MemberwiseClone(); }
        public int id { get; set; } = 0;
        public string name { get; set; }

        [Reader.FixedArrayLengthAttribute(8)]
        public PAGES[] pages { get; set; }
        public int id_dialog { get; set; }

        public override string ToString()
        {
            return $"{id}: {name}";
        }
        public class PAGES : ICloneable
        {
            public object Clone() { return this.MemberwiseClone(); }
            [Reader.FixedArrayLengthAttribute(16)]
            public string page_title { get; set; }

            [Reader.FixedArrayLengthAttribute(48)]
            public GOODS[] goods { get; set; }

            public override string ToString()
            {
                return $"{page_title}";
            }
            public class GOODS : ICloneable
            {
                public object Clone() { return this.MemberwiseClone(); }

                [TypeConverter(typeof(ItemIdConverter))]
                public int id_goods { get; set; }

                public override string ToString()
                {
                    return ItemLookupHelper.GetItemString(id_goods);
                }
            }
        }
    }
}
