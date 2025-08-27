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
    public class NPCCtrl : ICloneable
    {
        public object Clone() { return this.MemberwiseClone(); }

        public int id { get; set; }
        public int iControllerID { get; set; }
        public string szName { get; set; }
        public bool bActived { get; set; }
        public int iWaitTime { get; set; }
        public int iStopTime { get; set; }
        public bool bActiveTimeInvalid { get; set; }
        public bool bStopTimeInvalid { get; set; }
        public TIMETABLE Time1 { get; set; }
        public TIMETABLE Time2 { get; set; }
        public int iActiveTimeRange { get; set; }
        public bool bRepeatActived { get; set; }
        public override string ToString()
        {
            return szName;
        }
        public static NPCCtrl Read(BinaryReader br)
        {
            NPCCtrl Ctrl = new NPCCtrl();

            Ctrl.id = br.ReadInt32();
            Ctrl.iControllerID = br.ReadInt32();
            Ctrl.szName = COMMON.Unicode.readUnicodeString(br, 128);
            Ctrl.bActived = br.ReadBoolean();
            Ctrl.iWaitTime = br.ReadInt32();
            Ctrl.iStopTime = br.ReadInt32();
            Ctrl.bActiveTimeInvalid = br.ReadBoolean();
            Ctrl.bStopTimeInvalid = br.ReadBoolean();
            Ctrl.Time1 = TIMETABLE.Read(br);
            Ctrl.Time2 = TIMETABLE.Read(br);
            Ctrl.iActiveTimeRange = br.ReadInt32();
            Ctrl.bRepeatActived = br.ReadBoolean();
            return Ctrl;
        }

        public class TIMETABLE : ICloneable
        {
            public object Clone() { return this.MemberwiseClone(); }
            public int Year { get; set; }
            public int Month { get; set; }
            public int DayOfWeek { get; set; }
            public int Day { get; set; }
            public int Hours { get; set; }
            public int Minutes { get; set; }

            public static TIMETABLE Read(BinaryReader br)
            {
                return new TIMETABLE
                {
                    Year = br.ReadInt32(),
                    Month = br.ReadInt32(),
                    DayOfWeek = br.ReadInt32(),
                    Day = br.ReadInt32(),
                    Hours = br.ReadInt32(),
                    Minutes = br.ReadInt32()
                };
            }
        }
    }
}

