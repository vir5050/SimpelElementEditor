using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;
using System.Globalization;

namespace SimpelElementEditor.ESO
{
    public class NPC_TASK_IN_SERVICE : ICloneable
    {
        public object Clone() { return this.MemberwiseClone(); }
        public int id { get; set; } = 0;
        public string name { get; set; }

        [Reader.FixedArrayLengthAttribute(256)]
        public ID_TASKS[] id_tasks { get; set; }

        public override string ToString()
        {
            return $"{id}: {name}";
        }
        public class ID_TASKS : ICloneable
        {
            public object Clone() { return this.MemberwiseClone(); }

            [Reader.LookupType(typeof(TasksSimple.task))]
            [TypeConverter(typeof(LookupIdConverter))]
            public int id { get; set; } = 0;
            public override string ToString()
            {
                return $"{id}: {LookupHelper.GetLookupString(this, nameof(id))}";
            }
        }
    }
}
