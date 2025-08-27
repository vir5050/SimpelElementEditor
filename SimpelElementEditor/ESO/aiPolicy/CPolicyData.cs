using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace SimpelElementEditor.ESO.aiPolicy
{
	public class CPolicyData : ICloneable
	{
        public int Version { get; set; }
        public int id { get; set; }
        public List<CTriggerData> TriggerData { get; set; }

        public object Clone() { return this.MemberwiseClone(); }
        public static CPolicyData Read(BinaryReader br)
        {
            CPolicyData PolicyData = new CPolicyData();
            PolicyData.Version = br.ReadInt32();
            PolicyData.id = br.ReadInt32();
            int count = br.ReadInt32();

            PolicyData.TriggerData = new List<CTriggerData>();
            for (int i = 0; i < count; i++)
            {
                PolicyData.TriggerData.Add(CTriggerData.Read(br));
            }
            return PolicyData;

        }
        public override string ToString()
        {
            if (TriggerData.Count > 0)
                return $"{id}: {TriggerData[0].szName}";
            else
                return $"{id}: no triggers";
        }
    }
}
