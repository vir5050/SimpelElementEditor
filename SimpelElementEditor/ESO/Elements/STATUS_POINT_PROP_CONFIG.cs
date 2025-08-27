using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace SimpelElementEditor.ESO
{
    public class STATUS_POINT_PROP_CONFIG : ICloneable
    {
        public object Clone() { return this.MemberwiseClone(); }
        public int id { get; set; }
        public string name { get; set; }
        public int status_point_type { get; set; }
        public float adjust_gold { get; set; }
        public float adjust_wood { get; set; }
        public float adjust_water { get; set; }
        public float adjust_fire { get; set; }
        public float adjust_earth { get; set; }
        public float adjust_none { get; set; }
        public float adjust_phy { get; set; }
        public float pet_adapt { get; set; }
        public float pet_rank { get; set; }
        public float hp { get; set; }
        public float mp { get; set; }
        public float vp { get; set; }
        public float faint { get; set; }
        public float phy_dmg { get; set; }
        public float magic_dmg { get; set; }
        public float phy_defense { get; set; }
        public float magic_defense { get; set; }
        public float attack { get; set; }
        public float armor { get; set; }
        public float phy_crit_rate { get; set; }
        public float phy_crit_damage { get; set; }
        public float magic_crit_rate { get; set; }
        public float magic_crit_damage { get; set; }
        public float walk_speed { get; set; }
        public float run_speed { get; set; }
        public float riding_speed { get; set; }
        public float hp_gen1 { get; set; }
        public float hp_gen2 { get; set; }
        public float hp_gen3 { get; set; }
        public float hp_gen4 { get; set; }
        public float mp_gen1 { get; set; }
        public float mp_gen2 { get; set; }
        public float mp_gen3 { get; set; }
        public float mp_gen4 { get; set; }
        public override string ToString()
        {
            return $"{id}: {name}";
        }
    }
}
