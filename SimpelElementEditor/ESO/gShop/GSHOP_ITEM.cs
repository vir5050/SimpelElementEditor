using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;
using SimpelElementEditor.ESO.Elements;

namespace SimpelElementEditor.ESO.gShop
{
    public class GSHOP_ITEM : ICloneable
    {
        public object Clone() { return this.MemberwiseClone(); }
        public int id { get; set; }
        public int num { get; set; }
        [Reader.FixedArrayLengthAttribute(128)]
        public string surface_path { get; set; }
        [Reader.FixedArrayLengthAttribute(4)]
        public BUY[] buy { get; set; } //buy array 4

        [Reader.LookupType(typeof(SHOP_CATERGORYS))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int main_type { get; set; }
        public int sub_type { get; set; }
        public int local_id { get; set; }
        [Reader.FixedArrayLengthAttribute(1024)]
        public string Desc { get; set; }
        public string name { get; set; }
        public bool bHasPresent { get; set; }
        public int Presentid { get; set; }
        public int Presentcount { get; set; }
        public bool bPresentBind { get; set; }
        [Reader.FixedArrayLengthAttribute(1216)]
        public byte[] uk { get; set; }
        public override string ToString()
        {
            return $"{id}: {ItemLookupHelper.GetItemName(id)}";
        }

        public class BUY : ICloneable
        {
            public object Clone() { return this.MemberwiseClone(); }
            public int price { get; set; }
            public int end_time { get; set; }
            public int time { get; set; }
            public int start_time { get; set; }
            public int type { get; set; }
            public int day { get; set; }
            public int status { get; set; }
            public int flag { get; set; }
            public int reputation_type { get; set; }
            public int reputation { get; set; }
            public int sellstatus { get; set; }
            public int discount { get; set; }
            public override string ToString()
            {
                return $"{price}";
            }
        }
    }
}
