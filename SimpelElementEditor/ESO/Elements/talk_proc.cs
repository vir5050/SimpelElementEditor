using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SimpelElementEditor.ESO
{
    public class talk_proc : ICloneable
    {
        public object Clone() { return this.MemberwiseClone(); }
        public string text { get; set; }
        public int id_talk { get; set; }
        public int num_window { get; set; }
        public int windows_offset { get; set; }
        public List<window> windows { get; set; }

        internal static talk_proc Read(BinaryReader br)
        {
            talk_proc talk_proc = new talk_proc();
            talk_proc.id_talk = br.ReadInt32();
            talk_proc.text = Encoding.Unicode.GetString(br.ReadBytes(128), 0, 128).TrimEnd('\0');
            talk_proc.num_window = br.ReadInt32();
            if (talk_proc.num_window > 0)
                talk_proc.windows_offset = br.ReadInt32();
            //talk_proc.windows = new window[talk_proc.num_window];
            talk_proc.windows = new List<window>();
            for (int i = 0; i < talk_proc.num_window; i++)
                talk_proc.windows.Add(window.Read(br));
            return talk_proc;
        }

        public void Write(BinaryWriter bw, talk_proc talk_proc)
        {
            bw.Write(talk_proc.id_talk);
            COMMON.Unicode.writeUnicodeString(bw, talk_proc.text, 128);
            bw.Write(talk_proc.windows.Count());
            if (talk_proc.num_window > 0)
            {
                if (talk_proc.windows_offset == null)
                    talk_proc.windows_offset = 1;
                bw.Write(talk_proc.windows_offset);
            }
            for (int i = 0; i < talk_proc.windows.Count(); i++)
                window.Write(bw, talk_proc.windows[i]);
        }

        public override string ToString()
        {
            return $"{id_talk}: {text}";
        }
    }
}
