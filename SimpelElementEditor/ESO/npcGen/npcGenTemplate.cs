using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SimpelElementEditor.ESO.npcGen
{
    public class npcGenTemplate : ICloneable
    {
        public object Clone() { return this.MemberwiseClone(); }
        public int dwVersion { get; set; }
        public List<AIGEN> AIGEN { get; set; } = new List<AIGEN>();
        public List<ResArea> ResArea { get; set; } = new List<ResArea>();
        public List<DynObj> DynObj { get; set; } = new List<DynObj>();
        public List<NPCCtrl> NPCCtrl { get; set; } = new List<NPCCtrl>();
        public static npcGenTemplate Read(BinaryReader br)
        {
            npcGenTemplate npcGen = new npcGenTemplate();
            npcGen.dwVersion = br.ReadInt32();
            int iNumAIGen = br.ReadInt32();
            int iNumResArea = br.ReadInt32();
            int iNumDynObj = br.ReadInt32();
            int iNumNPCCtrl = br.ReadInt32();
            for (int i = 0; i < iNumAIGen; i++)
            {
                npcGen.AIGEN.Add(ESO.npcGen.AIGEN.Read(br));
            }
            for (int i = 0; i < iNumResArea; i++)
            {
                npcGen.ResArea.Add(ESO.npcGen.ResArea.Read(br));
            }
            for (int i = 0; i < iNumDynObj; i++)
            {
                npcGen.DynObj.Add(ESO.npcGen.DynObj.Read(br));
            }
            for (int i = 0; i < iNumNPCCtrl; i++)
            {
                npcGen.NPCCtrl.Add(ESO.npcGen.NPCCtrl.Read(br));
            }
            return npcGen;
        }
    }
}
