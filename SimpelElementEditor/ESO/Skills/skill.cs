using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpelElementEditor.ESO.Skills
{
    public class skill
    {
        public object Clone() { return this.MemberwiseClone(); }
        public int id { get; set; }
        public string name { get; set; }
        public string shortDesc { get; set; }
        public string longDesc { get; set; }
        
            
        public override string ToString()
        {
            return $"{id}: {name}";
        }
    }
}
