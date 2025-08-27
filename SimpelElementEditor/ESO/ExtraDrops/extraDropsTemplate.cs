using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SimpelElementEditor.ESO.ExtraDrops
{
    public class extraDropsTemplate : ICloneable
    {
        public object Clone() { return this.MemberwiseClone(); }
        public int magic { get; set; } = 0;
        public List<EXTRADROPTABLE> EXTRADROPTABLE { get; set; } = new List<EXTRADROPTABLE>();
        //public override string ToString()
        //{
        //    return $"{id} ({GSHOP_ITEM.Count})";
        //}
        public extraDropsTemplate Read(BinaryReader br)
        {
            extraDropsTemplate extraDrops = new extraDropsTemplate();
            extraDrops.magic = br.ReadInt32();
            int count = br.ReadInt32();
            for (int i = 0; i < count; i++)
            {
                EXTRADROPTABLE dropTable = new EXTRADROPTABLE();
                //dropTable.monsterCount = br.ReadInt32();
                int monsterCount = br.ReadInt32();
                for(int j = 0; j < monsterCount; j++)
                {
                    EXTRADROPTABLE.MONSTER monster = new EXTRADROPTABLE.MONSTER();
                    monster.id_monster = br.ReadInt32();
                    dropTable.id_monster.Add(monster);
                }
                for(int j = 0;j < dropTable.item.Length; j++)
                {
                    ExtraDrops.EXTRADROPTABLE.ITEM item = new EXTRADROPTABLE.ITEM();
                    item.id = br.ReadInt32();
                    item.probability = br.ReadSingle();
                    dropTable.item[j] = item;
                }
                dropTable.name = COMMON.Unicode.readUnicodeString(br, 128);
                dropTable.type = br.ReadInt32();
                for(int j = 0; j < dropTable.drop_num_probability.Length; j++)
                {
                    dropTable.drop_num_probability[j] = br.ReadSingle();
                }
                extraDrops.EXTRADROPTABLE.Add(dropTable);
            }
            return extraDrops;
        }
    }
}
