using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace SimpelElementEditor.ESO.Elements
{
    public class EQUIPMENT_RANDOM_ADDONSGROUP : ICloneable
    {
        public object Clone() { return this.MemberwiseClone(); }
        public int id { get; set; } = 0;
        public string name { get; set; }
        [Reader.FixedArrayLengthAttribute(48)]
        public ADDONS[] addons { get; set; }

        public override string ToString()
        {
            return $"{id}: {name}";
        }
        public class ADDONS : ICloneable
        {
            public object Clone() { return this.MemberwiseClone(); }
            [Reader.LookupType(typeof(EQUIPMENT_ADDON))]
            [TypeConverter(typeof(LookupIdConverter))]
            public int addon_id { get; set; }
            public float prob { get; set; }

            public override string ToString()
            {
                return $"{LookupHelper.GetLookupString(this, nameof(addon_id))}: {prob}";
            }
        }
    }
}
