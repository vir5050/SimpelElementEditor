using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace SimpelElementEditor.ESO
{
    public class NPC_TASK_OUT_SERVICE : ICloneable
    {
        public object Clone() { return this.MemberwiseClone(); }
        public int id { get; set; } = 0;
        public string name { get; set; }
        public int id_task_set { get; set; }

        [Reader.FixedArrayLengthAttribute(256)]
        public NPC_TASK_IN_SERVICE.ID_TASKS[] id_tasks { get; set; }

        public override string ToString()
        {
            return $"{id}: {name}";
        }
    }
}
