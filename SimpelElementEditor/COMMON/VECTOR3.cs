using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace SimpelElementEditor.ESO
{
    public class VECTOR3 : ICloneable
    {
        public object Clone() { return this.MemberwiseClone(); }

        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }

        public static VECTOR3 Read (BinaryReader br)
        {
            VECTOR3 vector = new VECTOR3();
            vector.x = br.ReadSingle();
            vector.y = br.ReadSingle();
            vector.z = br.ReadSingle();
            return vector;
        }

        public void write(BinaryWriter bw, VECTOR3 vector)
        {
            bw.Write(vector.x);
            bw.Write(vector.y);
            bw.Write(vector.z);
        }
        public override string ToString()
        {
            return $"x: {x.ToString("F2")} - y: {y.ToString("F2")} - z: {z.ToString("F2")}";
        }
    }
}
