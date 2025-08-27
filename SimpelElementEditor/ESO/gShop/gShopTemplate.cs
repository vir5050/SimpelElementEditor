using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SimpelElementEditor.ESO.Elements;

namespace SimpelElementEditor.ESO.gShop
{
    public class gShopTemplate : ICloneable
    {
        public object Clone() { return this.MemberwiseClone(); }
        public int id { get; set; } = 0;
        public List<GSHOP_ITEM> GSHOP_ITEM { get; set; } = new List<GSHOP_ITEM>();
        public List<SHOP_CATERGORYS> GSHOP_CATERGORYS { get; set; } = new List<SHOP_CATERGORYS>();
        public override string ToString()
        {
            return $"{id} ({GSHOP_ITEM.Count})";
        }
        public gShopTemplate Read(BinaryReader br)
        {
            gShopTemplate gShop = new gShopTemplate();
            gShop.id = br.ReadInt32();
            int count = br.ReadInt32();
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Read GSHOP_ITEM category {i}");
                gShop.GSHOP_ITEM.Add(Reader.ReadFromBinaryReader<GSHOP_ITEM>(br));
            }
            count = br.ReadInt32();
            Console.WriteLine($"Read {count} category's");
           for(int i = 0; i < count;i++)
            {
                Console.WriteLine($"Read gShop category {i}");
                SHOP_CATERGORYS category = new SHOP_CATERGORYS();
                category.id = br.ReadInt32();
                category.name = COMMON.Unicode.readUnicodeString(br, 128);
                int subcount = br.ReadInt32();
                Console.WriteLine($"Read ({category.id}){category.name}: {subcount} sub category's");
                for(int y =0; y < subcount;y++)
                {
                    //SHOP_CATERGORYS.SHOP_SUB_CATERGORYS sub_cat = new SHOP_CATERGORYS.SHOP_SUB_CATERGORYS();
                    //sub_cat.name = COMMON.Unicode.readUnicodeString(br, 128);
                    //Console.WriteLine($"Read {category.name}: {sub_cat.name}");
                    //category.sub_cats.Add(sub_cat);
                    category.SHOP_SUB_CATERGORYS.Add(COMMON.Unicode.readUnicodeString(br, 128));
                }
                gShop.GSHOP_CATERGORYS.Add(category);
            };
            return gShop;
        }
    }
}
