using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace SimpelElementEditor.ESO
{
    public class RECIPE_ESSENCE : ICloneable
    {
        public object Clone() { return this.MemberwiseClone(); }
        public int id { get; set; }

        [Reader.LookupType(typeof(RECIPE_MAJOR_TYPE))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int id_major_type { get; set; }

        [Reader.LookupType(typeof(RECIPE_SUB_TYPE))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int id_sub_type { get; set; }
        public string name { get; set; }
        public int level { get; set; }
        [Reader.FixedArrayLengthAttribute(3)]
        public PRODUCTS[] products { get; set; }
        public int price { get; set; }
        public float duration { get; set; }
        public int cycle { get; set; }
        public int times { get; set; }
        [Reader.FixedArrayLengthAttribute(6)]
        public MATERIALS[] materials { get; set; }
        [Reader.LookupType(typeof(PRODUCE_TYPE_CONFIG))]
        [TypeConverter(typeof(LookupIdConverter))]
        public int produce_type { get; set; }
        [Reader.FixedArrayLengthAttribute(3)]
        public REQUIRED[] required { get; set; }
        [Reader.FixedArrayLengthAttribute(32)]
        public string action { get; set; }
        [Reader.FixedArrayLengthAttribute(3)]
        public REQUIRED[] acquired { get; set; }

        public override string ToString()
        {
            return $"{id}: {name}";
        }
        public class PRODUCTS : ICloneable
        {
            public object Clone() { return this.MemberwiseClone(); }
            public float probability { get; set; }
            [TypeConverter(typeof(ItemIdConverter))]
            public int id_to_make { get; set; }
            public int min_num_make { get; set; }
            public int max_num_make { get; set; }

            public override string ToString()
            {
                return $"{ItemLookupHelper.GetItemName(id_to_make)}";
            }
        }
        public class MATERIALS : ICloneable
        {
            public object Clone() { return this.MemberwiseClone(); }
            [TypeConverter(typeof(ItemIdConverter))]
            public int id { get; set; }
            public int num { get; set; }

            public override string ToString()
            {
                return $"{num}x{ItemLookupHelper.GetItemName(id)}";
            }
        }
        public class REQUIRED : ICloneable
        {
            public object Clone() { return this.MemberwiseClone(); }
            [Reader.LookupType(typeof(PRODUCE_TYPE_CONFIG))]
            [TypeConverter(typeof(LookupIdConverter))]
            public int id { get; set; }
            public int value { get; set; }

            public override string ToString()
            {
                return $"{value}x{ItemLookupHelper.GetItemName(id)}";
            }
        }
    }
}
