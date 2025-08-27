using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SimpelElementEditor.COMMON
{
    internal class Unicode
    {
        public static string readUnicodeString(BinaryReader br, int stringLength)
        {
            return Encoding.Unicode.GetString(br.ReadBytes(stringLength)).Trim('\0');
        }
        public static void writeUnicodeStringWithFix(BinaryWriter bw, string str, int stringLength)
        {
            var encoding = Encoding.Unicode;
            byte[] nameBytes = encoding.GetBytes(str ?? "");

            // Dont know why i need this fix but somehow a encoding error somewher on just this 1 character... spend 3 hours trying to debug it... fuck it :)
            for (int i = 0; i < nameBytes.Length - 1; i += 2)
            {
                if (nameBytes[i] == 0xFD && nameBytes[i + 1] == 0xFF)
                {
                    nameBytes[i] = 0xC4;
                    nameBytes[i + 1] = 0xDC;
                }
            }

            byte[] buffer = new byte[stringLength];
            int count = Math.Min(nameBytes.Length, stringLength);
            Array.Copy(nameBytes, buffer, count);
            bw.Write(buffer);
        }
        public static void writeUnicodeString(BinaryWriter bw, string str, int byteLength)
        {

            if (str == null)
                str = string.Empty;

            byte[] bytes = Encoding.Unicode.GetBytes(str);

            byte[] buffer = new byte[byteLength];
            int count = Math.Min(bytes.Length, byteLength);
            Array.Copy(bytes, buffer, count);

            bw.Write(buffer);
        }
    }
}
