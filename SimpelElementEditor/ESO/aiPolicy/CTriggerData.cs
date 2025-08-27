using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SimpelElementEditor.ESO.aiPolicy
{
    public class CTriggerData
    {
        public int uVersion { get; set; }
        public int uID { get; set; }
        public bool bActive { get; set; }
        public bool bRun { get; set; }
        public bool bAttackValid { get; set; }
        public string szName { get; set; }
        public Condition condition { get; set; }//pointer?
        public List<Operation> operations { get; set; }

        public static CTriggerData Read(BinaryReader br)
        {
            CTriggerData TriggerData = new CTriggerData();
            TriggerData.uVersion = br.ReadInt32();
            TriggerData.uID = br.ReadInt32();
            TriggerData.bActive = br.ReadBoolean();
            TriggerData.bRun = br.ReadBoolean();
            TriggerData.bAttackValid = br.ReadBoolean();
            //TriggerData.szName = Encoding.Unicode.GetString(br.ReadBytes(128)).Split('\0')[0];
            TriggerData.szName = Encoding.GetEncoding("gb2312").GetString(br.ReadBytes(128)).Split('\0')[0];
            TriggerData.condition = Condition.Read(br);
            int count = br.ReadInt32();
            TriggerData.operations = new List<Operation>();
            for (int i = 0; i < count; i++)
            {
                TriggerData.operations.Add(Operation.Read(br));
            }
            return TriggerData;
        }

        public override string ToString()
        {
            return $"{uID}: {szName}";
        }
    }
}
