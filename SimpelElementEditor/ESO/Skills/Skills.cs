using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;

namespace SimpelElementEditor.ESO.Skills
{
    public class SkillsTemplate : ICloneable
    {
        public List<skill> skill { get; set; } = new List<skill>();
        public object Clone() { return this.MemberwiseClone(); }
        public List<skill> Read(string filePath)
        {
            var skills = new List<skill>();
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Could not find {filePath}");
                return skills;
            }

            string fileText = File.ReadAllText(filePath, Encoding.UTF8);

            // Match id + alles tussen de eerste en de laatste aanhalingstekens, inclusief nieuwe regels
            var regex = new Regex(@"^\s*(\d+)\s+""(.*?)""\s*$", RegexOptions.Multiline | RegexOptions.Singleline);

            var tempSkills = new Dictionary<int, skill>();

            foreach (Match match in regex.Matches(fileText))
            {
                int fileId = int.Parse(match.Groups[1].Value);
                string value = match.Groups[2].Value.Replace("\\n", "\n");

                int baseId = fileId / 10; // verwijder laatste cijfer

                if (!tempSkills.ContainsKey(baseId))
                    tempSkills[baseId] = new skill { id = baseId };

                var sk = tempSkills[baseId];

                switch (fileId % 10)
                {
                    case 0:
                        sk.name = value;
                        break;
                    case 1:
                        sk.shortDesc = value;
                        break;
                    case 2:
                        sk.longDesc = value;
                        break;
                }
            }

            skills.AddRange(tempSkills.Values.OrderBy(s => s.id));
            return skills;
        }
    }
}
