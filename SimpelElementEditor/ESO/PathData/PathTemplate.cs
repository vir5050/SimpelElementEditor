using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;

namespace SimpelElementEditor.ESO.PathData
{
    public class PathTemplate : ICloneable
    {
        public int magic { get; set; }
        public DateTime timestamp { get; set; }
        public List<path> path { get; set; } = new List<path>();
        public object Clone() { return this.MemberwiseClone(); }
        public PathTemplate Read(BinaryReader br)
        {
            PathTemplate PathTemplate = new PathTemplate();
            PathTemplate.timestamp = DateTimeOffset.FromUnixTimeSeconds(br.ReadInt32()).UtcDateTime;
            int count = br.ReadInt32();
            for(int i = 0; i < count; i++)
            {   
                path path = new path();
                path.id = br.ReadInt32();
                int length = br.ReadInt32();
                path.realName = Encoding.GetEncoding("gb2312").GetString(br.ReadBytes(length)).TrimEnd('\0');
                path.name = TranslatePath(path.realName);
                PathTemplate.path.Add(path);
            }


            Regex chineseRegex = new Regex(@"[\u4e00-\u9fff]");
            var seenDirectories = new HashSet<string>();

            string outputFile = "chinese_paths.txt";
            using (var writer = new StreamWriter(outputFile))
            {
                foreach (path path in PathTemplate.path)
                {
                    string directory = Path.GetDirectoryName(path.realName) ?? string.Empty;

                    // Alleen als de map Chinese tekens bevat én nog niet eerder is toegevoegd
                    if (chineseRegex.IsMatch(directory) && seenDirectories.Add(directory))
                    {
                        writer.WriteLine(path.realName);
                    }
                }
            }
            return PathTemplate;
        }

        private static string TranslatePath(string input)
        {
            if(input == null) return null;
            var dictionary = new Dictionary<string, string>
            { { "怪物", "Monster" },
    { "植物系", "Plant" },
    { "木怪", "Wood Monster" },
    { "飞行系", "Flying" },
    { "通用蝙蝠怪", "Common Bat Monster" },
    { "大怪鸟", "Giant Bird" },
    { "吸血蝙蝠怪", "Vampire Bat Monster" },
    { "吸血蝙蝠", "Vampire Bat" },
    { "金属系", "Metal" },
    { "铜钱妖", "Copper Coin Demon" },
    { "怪箱子", "Mimic Chest" },
    { "野兽系", "Beast" },
    { "猛虎", "Tiger" },
    { "巨鳄", "Giant Crocodile" },
    { "兔鼠", "Rabbit Rat" },
    { "特殊系", "Special" },
    { "鬼火", "Will-o'-the-Wisp" },
    { "昆虫系", "Insect" },
    { "蝎子", "Scorpion" },
    { "蜘蛛", "Spider" },
    { "蚊子", "Mosquito" },
    { "盾蟹", "Shield Crab" },
    { "地龙", "Earth Dragon" },
    { "人型系", "Humanoid" },
    { "贪酒小妖", "Drunken Imp" },
    { "矿工", "Miner" },
    { "猫剑士", "Cat Swordsman" },
    { "流放将军", "Exiled General" },
    { "江洋大盗", "Pirate" },
    { "不死系", "Undead" },
    { "无头将军", "Headless General" },
    { "幽灵战士", "Ghost Warrior" },
    { "boss", "Boss" },
    { "独角鬼", "One-Horned Demon" },
    { "天兵天将", "Heavenly Soldiers" },
    { "魏征", "Wei Zheng" },
    { "羊力大仙", "Goat Power Immortal" },
    { "秦琼", "Qin Qiong" },
    { "福星", "Lucky Star" },
    { "异国国王（胖）", "Foreign King (Fat)" },
    { "异国国王（瘦）", "Foreign King (Slim)" },
    { "尉迟恭", "Yuchi Gong" },
    { "仓库管理员", "Warehouse Keeper" },
    { "九老丈人", "Old Master Jiu" },
    { "龙型系", "Dragon Type" },
    { "食草龙", "Herbivorous Dragon" },
    { "蝙蝠手雷", "Bat Grenade" },
    { "女巫", "Witch" },
    { "假牙怪", "False Teeth Monster" },
    { "铁甲兽", "Armored Beast" },
    { "钢兽", "Steel Beast" },
    { "水晶龟", "Crystal Turtle" },
    { "黑熊", "Black Bear" },
    { "猩猩怪", "Ape Monster" },
    { "毒蛇", "Venomous Snake" },
    { "叽咕王", "Chirpy King" },
    { "男物品", "Men Items" },

    };

            foreach (var kvp in dictionary)
            {
                input = input.Replace(kvp.Key, kvp.Value);
            }

            return input;
        }
    }
}
