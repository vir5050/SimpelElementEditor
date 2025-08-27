using System;
using System.IO;

namespace SimpelElementEditor.ESO.aiPolicy
{ //Different from elementsclien, but it works... and if i fits, i sits
	public class Condition
    {
        public int id { get; set; }
        //condition length;
        public byte[] conditionData { get; set; }
        public int type { get; set; }
        public Condition condLeft { get; set; }
        public int SubNodeL { get; set; } //internal?
        public Condition condRight { get; set; }
        public int SubNodeR { get; set; } //internal?

        public static Condition Read(BinaryReader br)
        {
            Condition cond = new Condition();
            cond.id = br.ReadInt32();
            int length = br.ReadInt32();
            cond.conditionData = br.ReadBytes(length);
            int type = br.ReadInt32();

            if (type == 1)
            {
                cond.condLeft = Condition.Read(br);
                cond.SubNodeL = br.ReadInt32();
                cond.condRight = Condition.Read(br);
                cond.SubNodeR = br.ReadInt32();
            }
            else if (type == 2)
            {
                cond.condRight = Condition.Read(br);
                cond.SubNodeR = br.ReadInt32();
            }
            return cond;
        }
    }
}
