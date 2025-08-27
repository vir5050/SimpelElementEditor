using System;
using System.IO;
using System.Collections.Generic;

namespace SimpelElementEditor.ESO.aiPolicy
{
    public class aiPolicyTemplate
    {
        public int header { get; set; }
        public List<CPolicyData> PolicyData { get; set; }

        public static aiPolicyTemplate Read(BinaryReader br)
        {
            aiPolicyTemplate aipol = new aiPolicyTemplate();
            aipol.header = br.ReadInt32();
            aipol.PolicyData = new List<CPolicyData>();
            int count = br.ReadInt32();
            for (int i = 0; i < count; i++)
            //for (int i = 0; i < 2; i++)
            {
                aipol.PolicyData.Add(CPolicyData.Read(br));
            }
            return aipol;
        }
    }
}
