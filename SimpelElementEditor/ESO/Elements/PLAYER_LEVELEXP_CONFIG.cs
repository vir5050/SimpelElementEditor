using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace SimpelElementEditor.ESO
{
    public class PLAYER_LEVELEXP_CONFIG : ICloneable
    {
        public object Clone() { return this.MemberwiseClone(); }
        public int id { get; set; }
        public string name { get; set; }
        [Reader.FixedArrayLengthAttribute(200)]
        public double[] exp { get; set; }
        [Reader.FixedArrayLengthAttribute(100)]
        public int[] talisman_exp { get; set; }
        [Reader.FixedArrayLengthAttribute(10)]
        public int[] prod_exp_need { get; set; }
        [Reader.FixedArrayLengthAttribute(100)]
        public float[] prod_exp_gained { get; set; }
        [Reader.FixedArrayLengthAttribute(2400)]
        public double[] exp2 { get; set; }
        [Reader.FixedArrayLengthAttribute(200)]
        public double[] pet_exp { get; set; }
        public override string ToString()
        {
            return $"{id}: {name}";
        }
    }
}
