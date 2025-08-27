using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace SimpelElementEditor.ESO
{
    public class MERGE_RECIPE_ESSENCE : ICloneable
    {
        public object Clone() { return this.MemberwiseClone(); }
        public int id { get; set; }
        public string name { get; set; }
        public COMMON.BOOL keep_time_prop { get; set; }
        public COMMON.BOOL keep_bind_prop { get; set; }
        public COMMON.BOOL keep_refine_prop { get; set; }
        public COMMON.BOOL keep_pstone_prop { get; set; }
        [Reader.FixedArrayLengthAttribute(4)]
        public MAKES[] makes { get; set; }
        [Reader.FixedArrayLengthAttribute(6)]
        public MAINS[] mains { get; set; }
        public float basic_prob { get; set; }
        public int fee { get; set; }
        [Reader.FixedArrayLengthAttribute(4)]
        public HELPERS[] helpers { get; set; }
        public int id_recipe { get; set; }


        public override string ToString()
        {
            return $"{id}: {name}";
        }
        public class MAKES : ICloneable
        {
            public object Clone() { return this.MemberwiseClone(); }
            public float probability { get; set; }
            [TypeConverter(typeof(ItemIdConverter))]
            public int id1 { get; set; }
            public int num1 { get; set; }
            [TypeConverter(typeof(ItemIdConverter))]
            public int id2 { get; set; }
            public int num2 { get; set; }

            public override string ToString()
            {
                return $"{ItemLookupHelper.GetItemName(id1)}x {num1}";
            }
        }
        public class MAINS : ICloneable
        {
            public object Clone() { return this.MemberwiseClone(); }
            [TypeConverter(typeof(ItemIdConverter))]
            public int id_main { get; set; }
            public int num { get; set; }
            public int rank { get; set; }

            public override string ToString()
            {
                return $"{ItemLookupHelper.GetItemName(id_main)}x {num}";
            }
        }
        public class HELPERS : ICloneable
        {
            public object Clone() { return this.MemberwiseClone(); }
            [TypeConverter(typeof(ItemIdConverter))]
            public int id { get; set; }
            public float probability { get; set; }

            public override string ToString()
            {
                return $"{ItemLookupHelper.GetItemName(id)} - {probability*100}%";
            }
        }
    }
}
