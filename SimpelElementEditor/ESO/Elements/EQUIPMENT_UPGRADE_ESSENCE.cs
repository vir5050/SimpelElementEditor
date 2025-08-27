using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SimpelElementEditor.ESO.Elements
{
    public class EQUIPMENT_UPGRADE_ESSENCE : ICloneable
    {
        public object Clone() { return this.MemberwiseClone(); }
        public int id { get; set; } = 0;
        public string name { get; set; }
        public int max_level { get; set; }
        [Reader.FixedArrayLengthAttribute(10)]
        public int[] required_sp { get; set; }
        public int phy_dmg { get; set; }
        public int phy_dmg_var { get; set; }
        public int magic_dmg { get; set; }
        public int magic_dmg_var { get; set; }
        public int phy_defence { get; set; }
        public int phy_defence_var { get; set; }
        public int magic_defence { get; set; }
        public int magic_defence_var { get; set; }
        public int hp { get; set; }
        public int hp_var { get; set; }
        public int mp { get; set; }
        public int mp_var { get; set; }
        public int attack { get; set; }
        public int attack_var { get; set; }
        public int armor { get; set; }
        public int armor_var { get; set; }
        public int adjust_gold { get; set; }
        public int adjust_gold_var { get; set; }
        public int adjust_wood { get; set; }
        public int adjust_wood_var { get; set; }
        public int adjust_water { get; set; }
        public int adjust_water_var { get; set; }
        public int adjust_fire { get; set; }
        public int adjust_fire_var { get; set; }
        public int adjust_earth { get; set; }
        public int adjust_earth_var { get; set; }
        public int adjust_phy { get; set; }
        public int adjust_phy_var { get; set; }
        public int adjust_none { get; set; }
        public int adjust_none_var { get; set; }
        public float speed { get; set; }
        public float speed_var { get; set; }
        public int upgrade_phy_dmg { get; set; }
        public int upgrade_phy_dmg_var { get; set; }
        public int upgrade_magic_dmg { get; set; }
        public int upgrade_magic_dmg_var { get; set; }
        public int upgrade_phy_defence { get; set; }
        public int upgrade_phy_defence_var { get; set; }
        public int upgrade_magic_defence { get; set; }
        public int upgrade_magic_defence_var { get; set; }
        public int upgrade_hp { get; set; }
        public int upgrade_hp_var { get; set; }
        public int upgrade_mp { get; set; }
        public int upgrade_mp_var { get; set; }
        public int upgrade_attack { get; set; }
        public int upgrade_attack_var { get; set; }
        public int upgrade_armor { get; set; }
        public int upgrade_armor_var { get; set; }
        public int upgrade_adjust_gold { get; set; }
        public int upgrade_adjust_gold_var { get; set; }
        public int upgrade_adjust_wood { get; set; }
        public int upgrade_adjust_wood_var { get; set; }
        public int upgrade_adjust_water { get; set; }
        public int upgrade_adjust_water_var { get; set; }
        public int upgrade_adjust_fire { get; set; }
        public int upgrade_adjust_fire_var { get; set; }
        public int upgrade_adjust_earth { get; set; }
        public int upgrade_adjust_earth_var { get; set; }
        public int upgrade_adjust_phy { get; set; }
        public int upgrade_adjust_phy_var { get; set; }
        public int upgrade_adjust_none { get; set; }
        public int upgrade_adjust_none_var { get; set; }
        public float upgrade_speed { get; set; }
        public float upgrade_speed_var { get; set; }
        [Reader.FixedArrayLengthAttribute(10)]
        public ADDONS[] addons { get; set; }


        public override string ToString()
        {
            return $"{id}: {name}";
        }

        public class ADDONS : ICloneable
        {
            public object Clone() { return this.MemberwiseClone(); }
            [Reader.FixedArrayLengthAttribute(8)]
            public EQUIPMENT_ADDON.ADDONS[] id { get; set; }
            public override string ToString()
            {
                return $"{id}";
            }
        }
    }
}
