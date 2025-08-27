using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace SimpelElementEditor.ESO.Elements
{
    public class GARDEN_EXCHANGE_CONFIG : ICloneable
    {
        public object Clone() { return this.MemberwiseClone(); }
        public int id { get; set; } = 0;
        public string name { get; set; }

        [Reader.FixedArrayLengthAttribute(4)]
        public PAGES[] pages { get; set; }

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
                public int id_goods { get; set; }
                [Reader.FixedArrayLengthAttribute(2)]
                public ITEM_REQUIRED[] item_required { get; set; }
                [Reader.FixedArrayLengthAttribute(2)]
                public ITEM_REQUIRED[] repu_required { get; set; }
                public int garden_money_required { get; set; }

                public override string ToString()
                {
                    return $"{id_goods}";
                }
                public class ITEM_REQUIRED : ICloneable
                {
                    public object Clone() { return this.MemberwiseClone(); }
                    [TypeConverter(typeof(ItemIdConverter))]
                    public int id { get; set; }
                    public int count { get; set; }

                    public override string ToString()
                    {
                        return $"{ItemLookupHelper.GetItemName(id)}x {count}";
                    }
                }
            }
        }
    }
}
