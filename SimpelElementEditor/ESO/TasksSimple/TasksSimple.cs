using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;

namespace SimpelElementEditor.ESO.TasksSimple
{
    public class TasksSimpleTemplate : ICloneable
    {
        public DateTime timestamp { get; set; }
        public List<task> path { get; set; } = new List<task>();
        public object Clone() { return this.MemberwiseClone(); }
        public TasksSimpleTemplate Read(string fileLocation)
        {
            TasksSimpleTemplate TasksSimpleTemplate = new TasksSimpleTemplate();

            int index = 1;
            while (true)
            {
                string fileName = $"{fileLocation}{index}";

                if (!File.Exists(fileName))
                {
                    break; // Stop als het bestand niet bestaat
                }
                Console.WriteLine("Loading " + fileName);
                using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                using (var br = new BinaryReader(fs))
                {
                    // Hier jouw binary leeslogica
                    int timeStamp = br.ReadInt32(); //ignore this :)
                    int count = br.ReadInt32();
                    int[] vs = new int[count];
                    for(int i = 0; i < count; i++)
                    {
                        vs[i] = br.ReadInt32();
                    }
                    foreach(int v in vs)
                    {
                        br.BaseStream.Position = v;
                        task task = new task();
                        task.id = br.ReadInt32();
                        task.name = COMMON.Unicode.readUnicodeString(br, 64).TrimEnd('\0');
                        TasksSimpleTemplate.path.Add(task);
                    }
                }

                index++;
            }

            return TasksSimpleTemplate;
        }
    }
}
