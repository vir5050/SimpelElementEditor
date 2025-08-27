using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SimpelElementEditor.ESO
{
    public class window
    {
        //public int crypt_key;
        public int id { get; set; } = 0;
        public int id_parent { get; set; } = 0;
        private int talk_text_len { get; set; } = 3;
        public string talk_text { get; set; } = "new";
        public int num_option { get; set; } = 0;
        public List<option> options { get; set; }
        internal static window Read(BinaryReader br)
        {
            window window = new window();
            window.id = br.ReadInt32();
            if (window.id > -1)
                window.id_parent = br.ReadInt32();
            window.talk_text_len = br.ReadInt32();
            window.talk_text = Encoding.Unicode.GetString(br.ReadBytes(window.talk_text_len * 2), 0, window.talk_text_len * 2).TrimEnd('\0');
            window.num_option = br.ReadInt32();

            window.options = new List<option>();
            for (int i = 0; i < window.num_option; i++)
                window.options.Add(option.Read(br));
            return window;
        }

        internal static void Write(BinaryWriter bw, window window)
        {
            bw.Write(window.id);
            if (window.id > -1)
                bw.Write(window.id_parent);
            window.talk_text += "\0"; //dont ask
            bw.Write(window.talk_text.Length);
            bw.Write(Encoding.Unicode.GetBytes(window.talk_text));
            window.talk_text = window.talk_text.Split('\0')[0];
            bw.Write(window.options.Count());
            for (int i = 0; i < window.options.Count(); i++)
                option.Write(bw, window.options[i]);
        }
    }

    public class option
    {
        //public int crypt_key;
        public int id { get; set; } = 0;
        public string text { get; set; } = "new";
        public int param { get; set; } = 0;

        internal static option Read(BinaryReader br)
        {
            return new option
            {
                id = br.ReadInt32(),
                text = Encoding.Unicode.GetString(br.ReadBytes(128), 0, 128).TrimEnd('\0'),
                param = br.ReadInt32()
            };
        }

        internal static void Write(BinaryWriter bw, option option)
        {
            bw.Write(option.id);
            //byte[] b = new byte[128];
            //Encoding.Unicode.GetBytes(option.text, b);
            //bw.Write(b);

            COMMON.Unicode.writeUnicodeString(bw, option.text, 128);
            bw.Write(option.param);
        }
    }
}