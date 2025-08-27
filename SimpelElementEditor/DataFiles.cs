using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpelElementEditor.ESO.PathData;
using SimpelElementEditor.ESO.TasksSimple;
using SimpelElementEditor.ESO.Skills;
using SimpelElementEditor.ESO.aiPolicy;
using SimpelElementEditor.ESO.gShop;
using SimpelElementEditor.ESO.ExtraDrops;
using SimpelElementEditor.ESO.npcGen;
using SimpelElementEditor.ESO.Elements;
using System.IO;
using System.ComponentModel;

namespace SimpelElementEditor
{
    public static class DataFiles
    {
        public static ElementsTemplate elementsTemplate = new ElementsTemplate();
        public static PathTemplate pathTemplate = new PathTemplate();
        public static TasksSimpleTemplate tasksSimpleTemplate = new TasksSimpleTemplate();
        public static SkillsTemplate SkillsTemplate = new SkillsTemplate();
        public static aiPolicyTemplate aiPolicyTemplate = new aiPolicyTemplate();
        public static gShopTemplate gShopTemplate = new gShopTemplate();
        public static extraDropsTemplate extraDropsTemplate = new extraDropsTemplate();
        //public static path path = new extraDropsTemplate();
        public static List<mapData> mapData = new List<mapData>();
        public static int selectedaiPolicy = 0;

        public static void load(string elementsPath)
        {
            string folderPath = Path.GetDirectoryName(elementsPath);

            string elementsFilePath = Path.Combine(folderPath, "elements.data");
            string aiPolicyFilePath = Path.Combine(folderPath, "aipolicy.data");
            string gShopFilePath = Path.Combine(folderPath, "gshop.data");
            string extra_dropsPath = Path.Combine(folderPath, "extra_drops.sev");
            string pathPath = Path.Combine(folderPath, "path.data");
            string tasksPath = Path.Combine(folderPath, "tasks.data");


            TypeDescriptor.AddAttributes(typeof(List<>), new TypeConverterAttribute(typeof(ExpandableListConverter)));
            TypeDescriptor.AddAttributes(typeof(Array), new TypeConverterAttribute(typeof(ExpandableListConverter)));
            TypeDescriptor.AddAttributes(typeof(ESO.aiPolicy.Condition), new TypeConverterAttribute(typeof(ExpandableListConverter)));
            TypeDescriptor.AddAttributes(typeof(ESO.aiPolicy.Operation), new TypeConverterAttribute(typeof(ExpandableListConverter)));

            PropertyGridHelper.RegisterExpandableListsSafe(typeof(ESO.aiPolicy.aiPolicyTemplate));
            PropertyGridHelper.RegisterExpandableListsSafe(typeof(ESO.Elements.ElementsTemplate));
            PropertyGridHelper.RegisterExpandableListsSafe(typeof(ESO.gShop.gShopTemplate));
            PropertyGridHelper.RegisterExpandableListsSafe(typeof(ESO.PathData.PathTemplate));
            PropertyGridHelper.RegisterExpandableListsSafe(typeof(ESO.TasksSimple.TasksSimpleTemplate));
            PropertyGridHelper.RegisterExpandableListsSafe(typeof(ESO.ExtraDrops.extraDropsTemplate));
            //PropertyGridHelper.RegisterExpandableListsSafe(typeof(mapData));
            PropertyGridHelper.RegisterExpandableListsSafe(typeof(List<mapData>));
            PropertyGridHelper.RegisterExpandableListsSafe(typeof(npcGenTemplate));

            if (File.Exists(elementsFilePath))
                using (BinaryReader br = new BinaryReader(new FileStream(elementsFilePath, FileMode.Open, FileAccess.Read)))
                    elementsTemplate = elementsTemplate.Read(br);
            else
                writeFilenotFound(elementsPath);

            if (File.Exists(aiPolicyFilePath))
                using (BinaryReader br = new BinaryReader(new FileStream(aiPolicyFilePath, FileMode.Open, FileAccess.Read)))
                    aiPolicyTemplate = aiPolicyTemplate.Read(br);
            else
                writeFilenotFound(aiPolicyFilePath);
            if (File.Exists(gShopFilePath))
                using (BinaryReader br = new BinaryReader(new FileStream(gShopFilePath, FileMode.Open, FileAccess.Read)))
                    gShopTemplate = gShopTemplate.Read(br);
            else
                writeFilenotFound(gShopFilePath);
            if (File.Exists(extra_dropsPath))
                using (BinaryReader br = new BinaryReader(new FileStream(extra_dropsPath, FileMode.Open, FileAccess.Read)))
                    extraDropsTemplate = extraDropsTemplate.Read(br);
            else
                writeFilenotFound(extra_dropsPath);
            if (File.Exists(pathPath))
                using (BinaryReader br = new BinaryReader(new FileStream(pathPath, FileMode.Open, FileAccess.Read)))
                    pathTemplate = pathTemplate.Read(br);
            else
                writeFilenotFound(pathPath);
            if (File.Exists(tasksPath))
                tasksSimpleTemplate = tasksSimpleTemplate.Read(tasksPath); //no binaryreader here
            else
                writeFilenotFound(tasksPath);

            mapData = SimpelElementEditor.mapData.Read(folderPath);




            ItemLookupHelper.InitializeCache();
        }
        private static void writeFilenotFound(string name)
        {
            Console.WriteLine($"Could not find file: {name}");
        }
    }

    public class DataFilesWrapper
    {
        public ElementsTemplate ElementsTemplate
        {
            get => DataFiles.elementsTemplate;
            set => DataFiles.elementsTemplate = value;
        }

        public PathTemplate PathTemplate
        {
            get => DataFiles.pathTemplate;
            set => DataFiles.pathTemplate = value;
        }

        public TasksSimpleTemplate TasksSimpleTemplate
        {
            get => DataFiles.tasksSimpleTemplate;
            set => DataFiles.tasksSimpleTemplate = value;
        }

        public SkillsTemplate SkillsTemplate
        {
            get => DataFiles.SkillsTemplate;
            set => DataFiles.SkillsTemplate = value;
        }

        public aiPolicyTemplate AiPolicyTemplate
        {
            get => DataFiles.aiPolicyTemplate;
            set => DataFiles.aiPolicyTemplate = value;
        }

        public gShopTemplate GShopTemplate
        {
            get => DataFiles.gShopTemplate;
            set => DataFiles.gShopTemplate = value;
        }

        public extraDropsTemplate ExtraDropsTemplate
        {
            get => DataFiles.extraDropsTemplate;
            set => DataFiles.extraDropsTemplate = value;
        }

        public List<mapData> MapData
        {
            get => DataFiles.mapData;
            set => DataFiles.mapData = value;
        }
    }

    public class mapData : ICloneable
    {
        public object Clone() { return this.MemberwiseClone(); }
        public string name { get; set; }
        public npcGenTemplate npcGenTemplates { get; set; }
        //public path.sev path.sev { get; set; } place for other map files
        //public precinct.sev { get; set; }
        //public region.sev { get; set; }
        public override string ToString()
        {
            return name;
        }
        public static List<mapData> Read(string folderPath) //path to elements folder
        {
            List<mapData> maps = new List<mapData>();

            var mapNames = new List<string>();

            for (int i = 1; i <= 21; i++)
                mapNames.Add($"x{i}");

            for (int i = 1; i <= 40; i++)
                mapNames.Add($"b{i:00}");

            for (int i = 1; i <= 1; i++)
                mapNames.Add($"C{i:00}");
            for (int i = 1; i <= 1; i++)
                mapNames.Add($"y{i}");

            foreach (var mapName in mapNames)
            {
                var map = new mapData();
                map.name = mapName;
                Console.WriteLine($"Reading map data: {map.name}");

                var npcGenFile = Path.Combine(folderPath, mapName, "npcgen.data");
                if (File.Exists(npcGenFile))
                    using (var br = new BinaryReader(new FileStream(npcGenFile, FileMode.Open, FileAccess.Read)))
                        map.npcGenTemplates = npcGenTemplate.Read(br);
                else
                    Console.WriteLine("Could not find: " + npcGenFile);

                if(map.npcGenTemplates != null && map.npcGenTemplates.dwVersion != 0)
                    maps.Add(map);
            }
            return maps;
        }
    }
}