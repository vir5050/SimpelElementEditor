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
    public class DynObj : ICloneable
    {
        public object Clone() { return this.MemberwiseClone(); }

        public int dwDynObjID { get; set; }
        public VECTOR3 vPos { get; set; } = new VECTOR3();
        public byte dir1 { get; set; }
        public byte dir2 { get; set; }
        public byte rad { get; set; }
        public byte scale { get; set; }
        public int idController { get; set; }
        public override string ToString()
        {
            return dwDynObjID.ToString();
        }

        public static DynObj Read(BinaryReader br)
        {
            DynObj obj = new DynObj();

            obj.dwDynObjID = br.ReadInt32();
            obj.vPos = VECTOR3.Read(br);
            obj.dir1 = br.ReadByte();
            obj.dir2 = br.ReadByte();
            obj.rad = br.ReadByte();
            obj.scale = br.ReadByte();
            obj.idController = br.ReadInt32();
            return obj;
        }
    }
}

