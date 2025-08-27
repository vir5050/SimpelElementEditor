using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SimpelElementEditor.ESO.Elements;
using System.ComponentModel;

namespace SimpelElementEditor.ESO.npcGen
{
    public class AIGEN : ICloneable
    {
        public object Clone() { return this.MemberwiseClone(); }
        public COMMON.BOOL iType { get; set; }
        public int iNumGen { get; set; }
        public VECTOR3 vPos { get; set; } = new VECTOR3();
        public VECTOR3 vDir { get; set; } = new VECTOR3();
        public VECTOR3 vExts { get; set; } = new VECTOR3();
        public int iNPCType { get; set; }
        public int iGroupType { get; set; }
        public bool bInitGen { get; set; }
        public bool bAutoRevive { get; set; }
        public bool bValidOnce { get; set; }
        public int dwGenID { get; set; }
        public int idCtrl { get; set; }
        public int iLifeTime { get; set; }
        public int iMaxNum { get; set; }
        public int dwExportID { get; set; }
        public List<ATTACH> attachList { get; set; } = new List<ATTACH>();
        public override string ToString()
        {
            if (attachList.Count > 0)
                return $"{iNumGen}: {LookupHelper.GetLookupString(attachList[0], nameof(ATTACH.dwID))}";
            else
                return "No monsters attached";
        }

        public class ATTACH : ICloneable
        {
            public object Clone() { return this.MemberwiseClone(); }
            [Reader.LookupType(typeof(MONSTER_ESSENCE))]
            [TypeConverter(typeof(LookupIdConverter))] //custom typeconverter would be required here since its npc + mosnter essence.
            //work around with display is in place, for a full editor ask chatgpt to fix you a typeconverter ;)
            public int dwID { get; set; }
            public int dwNum { get; set; }
            public int dwRefresh { get; set; }
            public int dwDiedTimes { get; set; }
            public int dwAggressive { get; set; }
            public float fOffsetWater { get; set; }
            public float fOffsetTrn { get; set; }
            public int dwFaction { get; set; }
            public int dwFacHelper { get; set; }
            public int dwFacAccept { get; set; }
            public bool bNeedHelp { get; set; } //no common.bool because its single byte data
            public bool bDefFaction { get; set; }
            public bool bDefFacHelper { get; set; }
            public bool bDefFacAccept { get; set; }
            public int iPathID { get; set; }
            public int discount { get; set; }
            public int iLoopType { get; set; }
            public int iSpeedFlag { get; set; }
            public int iDeadTime { get; set; }
            public override string ToString()
            {
                return $"{dwNum}x {LookupHelper.Resolve(this, nameof(ATTACH.dwID), dwID)}"; 
            }
            public static ATTACH Read(BinaryReader br)
            {
                ATTACH attach = new ATTACH();
                attach.dwID = br.ReadInt32();
                attach.dwNum = br.ReadInt32();
                attach.dwRefresh = br.ReadInt32();
                attach.dwDiedTimes = br.ReadInt32();
                attach.dwAggressive = br.ReadInt32();
                attach.fOffsetWater = br.ReadSingle();
                attach.fOffsetTrn = br.ReadSingle();
                attach.dwFaction = br.ReadInt32();
                attach.dwFacHelper = br.ReadInt32();
                attach.dwFacAccept = br.ReadInt32();
                attach.bNeedHelp = br.ReadBoolean();
                attach.bDefFaction = br.ReadBoolean();
                attach.bDefFacHelper = br.ReadBoolean();
                attach.bDefFacAccept = br.ReadBoolean();
                attach.iPathID = br.ReadInt32();
                attach.iLoopType = br.ReadInt32();
                attach.iSpeedFlag = br.ReadInt32();
                attach.iDeadTime = br.ReadInt32();
                return attach;
            }
        }

        public static AIGEN Read(BinaryReader br)
        {
            AIGEN aiGen = new AIGEN();
            aiGen.iType = (COMMON.BOOL)br.ReadInt32();
            aiGen.iNumGen = br.ReadInt32();
            aiGen.vPos = VECTOR3.Read(br);
            //Console.WriteLine(aiGen.vPos.ToString());
            aiGen.vDir = VECTOR3.Read(br);
            aiGen.vExts = VECTOR3.Read(br);
            aiGen.iNPCType = br.ReadInt32();
            aiGen.iGroupType = br.ReadInt32();
            aiGen.bInitGen = br.ReadBoolean();
            aiGen.bAutoRevive = br.ReadBoolean();
            aiGen.bValidOnce = br.ReadBoolean();
            aiGen.dwGenID = br.ReadInt32();
            aiGen.idCtrl = br.ReadInt32();
            aiGen.iLifeTime = br.ReadInt32();
            aiGen.iMaxNum = br.ReadInt32();
            aiGen.dwExportID = br.ReadInt32();
            int count = br.ReadInt32();
            for(int i = 0; i < (count + aiGen.iNumGen); i++)
            {
                aiGen.attachList.Add(ATTACH.Read(br));
            }
            return aiGen;
        }
    }
}

