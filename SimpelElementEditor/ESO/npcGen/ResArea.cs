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
    public class ResArea : ICloneable
    {
        public object Clone() { return this.MemberwiseClone(); }

        public VECTOR3 vPos { get; set; } = new VECTOR3();
        public float y { get; set; }
        public float z { get; set; }
        public int iNumRes { get; set; }
        public bool bInitGen { get; set; }
        public bool bAutoRevive { get; set; }
        public bool bValidOnce { get; set; }
        public int dwGenID { get; set; }
        public byte dir1 { get; set; }
        public byte dir2 { get; set; }
        public byte rad { get; set; }
        public int idCtrl { get; set; }
        public int iMaxNum { get; set; }
        public int dwExportID { get; set; }
        public int iAttachNum { get; set; }

        public List<ATTACH> attachList { get; set; } = new List<ATTACH>();
        public override string ToString()
        {
            if (attachList.Count > 0)
                return $"{LookupHelper.GetLookupString(attachList[0], nameof(ATTACH.idTemplate))}";
            else
                return "No monsters attached";
        }

        public class ATTACH : ICloneable
        {
            public object Clone() { return this.MemberwiseClone(); }
            public int iResType { get; set; }
            [Reader.LookupType(typeof(MINE_ESSENCE))]
            [TypeConverter(typeof(LookupIdConverter))] 
            public int idTemplate { get; set; }
            public int dwRefreshTime { get; set; }
            public int dwNumber { get; set; }
            public float fHeiOff { get; set; }
            public override string ToString()
            {
                return $"{LookupHelper.Resolve(this, nameof(ATTACH.idTemplate), idTemplate)}"; 
            }
            public static ATTACH Read(BinaryReader br)
            {
                ATTACH attach = new ATTACH();
                attach.iResType = br.ReadInt32();
                attach.idTemplate = br.ReadInt32();
                attach.dwRefreshTime = br.ReadInt32();
                attach.dwNumber = br.ReadInt32();
                attach.fHeiOff = br.ReadSingle();
                return attach;
            }
        }

        public static ResArea Read(BinaryReader br)
        {
            ResArea res = new ResArea();
            res.vPos = VECTOR3.Read(br);
            res.y = br.ReadInt32();
            res.z = br.ReadInt32();
            res.iNumRes = br.ReadInt32();
            res.bInitGen = br.ReadBoolean();
            res.bAutoRevive = br.ReadBoolean();
            res.bValidOnce = br.ReadBoolean();
            res.dwGenID = br.ReadInt32();
            res.dir1 = br.ReadByte();
            res.dir2 = br.ReadByte();
            res.rad = br.ReadByte();
            res.idCtrl = br.ReadInt32();
            res.iMaxNum = br.ReadInt32();
            res.dwExportID = br.ReadInt32();
            int count = br.ReadInt32();
            for(int i = 0; i < (count + res.iNumRes); i++)
            {
                res.attachList.Add(ATTACH.Read(br));
            }
            return res;
        }
    }
}

