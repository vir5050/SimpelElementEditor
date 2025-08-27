using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace SimpelElementEditor.ESO.Elements
{
    public class EQUIPMENT_ADDON : ICloneable
    {
        public object Clone() { return this.MemberwiseClone(); }
        public int id { get; set; }
        public string name { get; set; }
        public COMMON.EQUIPMENT_ADDON_TYPE type { get; set; }
        public int num_params { get; set; }
        public int param1 { get; set; }
        public int param2 { get; set; }
        public int param3 { get; set; }

        public override string ToString()
        {
            return $"{id}: {name}";
        }
        public class ADDONS : ICloneable
        {
            public object Clone() { return this.MemberwiseClone(); }
            [Reader.LookupType(typeof(EQUIPMENT_ADDON))]
            [TypeConverter(typeof(LookupIdConverter))]
            public int id { get; set; }

            public override string ToString()
            {
                return $"{LookupHelper.GetLookupString(this, nameof(id))}";
            }
        }
    }
}
