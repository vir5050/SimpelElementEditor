using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SimpelElementEditor.ESO.gShop
{
    public class SHOP_CATERGORYS : ICloneable
    {
        public object Clone() { return this.MemberwiseClone(); }
        public int id { get; set; }
        public string name { get; set; }
        //public List<SHOP_SUB_CATERGORYS> sub_cats { get; set; } = new List<SHOP_SUB_CATERGORYS>();
        public List<string> SHOP_SUB_CATERGORYS { get; set; } = new List<string>();
        public override string ToString()
        {
            return $"{id}: {name}";
        }

        /*public class SHOP_SUB_CATERGORYS : ICloneable
        {
            public object Clone() { return this.MemberwiseClone(); }
            public string name { get; set; }
            public override string ToString()
            {
                return $"{name}";
            }
        }*/
    }
}
