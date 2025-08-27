using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SimpelElementEditor.ESO
{
    public class PARAM_ADJUST_CONFIG : ICloneable
    {
        public object Clone() { return this.MemberwiseClone(); }
        public int id { get; set; } = 0;
        public string name { get; set; }
        [Reader.FixedArrayLengthAttribute(16)]
        public LEVEL_DIFF_ADJUST[] level_diff_adjust { get; set; }
        [Reader.FixedArrayLengthAttribute(11)]
        public TEAM_ADJUST[] team_adjust { get; set; }
        [Reader.FixedArrayLengthAttribute(9)]
        public TEAM_ADJUST[] team_profession_adjust { get; set; }
        [Reader.FixedArrayLengthAttribute(9)]
        public LEVEL_DIFF_PRODUCE[] level_diff_produce { get; set; }
        [Reader.FixedArrayLengthAttribute(16)]
        public float[] pet_capture_adjust { get; set; }
        [Reader.FixedArrayLengthAttribute(16)]
        public int[] pet_fight_winner_score { get; set; }
        [Reader.FixedArrayLengthAttribute(16)]
        public int[] pet_fight_loser_score { get; set; }
        public override string ToString()
        {
            return $"{id}: {name}";
        }
        public class LEVEL_DIFF_ADJUST : ICloneable
        {
            public object Clone() { return this.MemberwiseClone(); }
            public int level_diff { get; set; }
            public float adjust_exp { get; set; }
            public float adjust_money { get; set; }
            public float adjust_matter { get; set; }
            public float adjust_attack { get; set; }
            public override string ToString()
            {
                return $"{level_diff}";
            }
        }
        public class TEAM_ADJUST : ICloneable
        {
            public object Clone() { return this.MemberwiseClone(); }
            public float adjust_exp { get; set; }
            public override string ToString()
            {
                return $"{adjust_exp}";
            }
        }
        public class LEVEL_DIFF_PRODUCE : ICloneable
        {
            public object Clone() { return this.MemberwiseClone(); }
            public int level_diff { get; set; }
            public float adjust_exp { get; set; }
            public override string ToString()
            {
                return $"{level_diff}";
            }
        }
    }
}
