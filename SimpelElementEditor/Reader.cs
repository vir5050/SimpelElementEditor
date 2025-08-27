using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using SimpelElementEditor.ESO.Elements;
using System.Reflection;

namespace SimpelElementEditor
{
    class Reader
    {
        public static List<T> ReadList<T>(ElementsTemplate elements, BinaryReader br) where T : new()
        {
            int objectLength = br.ReadInt32();
            int objectCount = br.ReadInt32();

            T[] list = new T[objectCount];

            //Console.WriteLine(type.ToString()); 
            Console.WriteLine($"Reading {objectCount} objects of type {typeof(T).Name} ({objectLength} bytes)");
            for (int i = 0; i < objectCount; i++)
            {
                list[i] = (ReadFromBinaryReader<T>(br));
            }
            return list.ToList<T>();
        }


        [AttributeUsage(AttributeTargets.Property)]
        public class IndexNamesAttribute : Attribute
        {
            public string[] Names { get; }

            public IndexNamesAttribute(params string[] names)
            {
                Names = names;
            }
        }

        [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
        public class LookupTypeAttribute : Attribute
        {
            public Type LookupType { get; }

            public LookupTypeAttribute(Type lookupType)
            {
                LookupType = lookupType;
            }
        }

        [AttributeUsage(AttributeTargets.Property)]
        public class ElementReferenceAttribute : Attribute
        {
            public string ListName { get; }
            public ElementReferenceAttribute(string listName)
            {
                ListName = listName;
            }
        }

        [AttributeUsage(AttributeTargets.Property)]
        public class FixedArrayLengthAttribute : Attribute
        {
            public int Length { get; }

            public FixedArrayLengthAttribute(int length)
            {
                Length = length;
            }
        }

        public static T ReadFromBinaryReader<T>(BinaryReader br) where T : new()
        {
            T instance = new T();
            var type = typeof(T);

            foreach (var prop in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (!prop.CanWrite)
                    continue;

                var propType = prop.PropertyType;

                if (propType.IsArray)
                {
                    var elementType = propType.GetElementType();
                    var lengthAttr = prop.GetCustomAttribute<FixedArrayLengthAttribute>();
                    if (lengthAttr == null)
                        throw new Exception($"Array property {prop.Name} must have FixedArrayLengthAttribute.");

                    int length = lengthAttr.Length;
                    Array array = Array.CreateInstance(elementType, length);
                    for (int i = 0; i < length; i++)
                    {
                        object value = ReadPrimitive(br, elementType, prop);
                        array.SetValue(value, i);
                    }
                    prop.SetValue(instance, array);
                }
                else
                {
                    object value = ReadPrimitive(br, propType, prop);
                    prop.SetValue(instance, value);
                }
            }

            return instance;
        }

        private static object ReadPrimitive(BinaryReader br, Type type, PropertyInfo prop = null)
        {
            if (type == typeof(int))
                return br.ReadInt32();
            if (type == typeof(uint))
                return br.ReadUInt32();
            if (type == typeof(short))
                return br.ReadInt16();
            if (type == typeof(ushort))
                return br.ReadUInt16();
            if (type == typeof(byte))
                return br.ReadByte();
            if (type == typeof(float))
                return br.ReadSingle();
            if (type == typeof(double))
                return br.ReadDouble();
            if (type == typeof(bool))
                return br.ReadBoolean();
            if (type == typeof(char))
                return br.ReadChar();
            if (type == typeof(string))
            {
                int length = -1;

                // 1️⃣ Check attribuut
                var fixedLenAttr = prop?.GetCustomAttribute<FixedArrayLengthAttribute>();
                if (fixedLenAttr != null)
                {
                    length = fixedLenAttr.Length;
                }
                else if (string.Equals(prop?.Name, "name", StringComparison.OrdinalIgnoreCase))
                {
                    // 2️⃣ Speciale regel voor "name"
                    length = 64;
                }
                else
                {
                    // 3️⃣ Default lengte (pas aan naar wens)

                    throw new NotSupportedException($"No length specified for {prop?.Name}.");
                }
                if (length > 0)
                    //string chars = ;
                    return COMMON.Unicode.readUnicodeString(br, length).TrimEnd('\0');
                else
                    throw new NotSupportedException($"No string length for {prop?.Name} specified.");

            }
            if (type.IsEnum)
            {
                int raw = br.ReadInt32();
                return Enum.ToObject(type, raw);
            }

            //
            if (!type.IsPrimitive && type.IsClass)
            {
                var method = typeof(Reader)
                    .GetMethod(nameof(ReadFromBinaryReader))
                    .MakeGenericMethod(type);
                return method.Invoke(null, new object[] { br });
            }

            throw new NotSupportedException($"Type {type.Name} is not supported.");
        }
        public static void WriteList<T>(BinaryWriter bw, List<T> list) where T : new()
        {
            if (list == null) throw new ArgumentNullException(nameof(list));

            int objectLength;

            // Bepaal lengte van een object (indien lijst leeg, van een lege instantie)
            using (var ms = new MemoryStream())
            using (var tempBw = new BinaryWriter(ms))
            {
                T sampleObj = (list.Count > 0) ? list[0] : new T();
                WriteToBinaryWriter(tempBw, sampleObj);
                tempBw.Flush();
                objectLength = (int)ms.Length;
            }

            // Schrijf lengte en count
            bw.Write(objectLength);
            bw.Write(list.Count);

            // Schrijf de objecten zelf
            foreach (var obj in list)
            {
                WriteToBinaryWriter(bw, obj);
            }
        }
        public static void WriteToBinaryWriter<T>(BinaryWriter bw, T obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            var type = typeof(T);

            foreach (var prop in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (!prop.CanRead)
                    continue;

                var value = prop.GetValue(obj);
                var propType = prop.PropertyType;

                if (propType.IsArray)
                {
                    var elementType = propType.GetElementType();
                    var lengthAttr = prop.GetCustomAttribute<FixedArrayLengthAttribute>();
                    if (lengthAttr == null)
                        throw new Exception($"Array property {prop.Name} must have FixedArrayLengthAttribute.");

                    int length = lengthAttr.Length;
                    Array array = (Array)value;

                    for (int i = 0; i < length; i++)
                    {
                        object elementValue = array != null && i < array.Length ? array.GetValue(i) : Activator.CreateInstance(elementType);
                        WritePrimitive(bw, elementType, elementValue, prop);
                    }
                }
                else
                {
                    WritePrimitive(bw, propType, value, prop);
                }
            }
        }

        private static void WritePrimitive(BinaryWriter bw, Type type, object value, PropertyInfo prop = null)
        {
            if (type == typeof(int))
                bw.Write((int)(value ?? 0));
            else if (type == typeof(uint))
                bw.Write((uint)(value ?? 0));
            else if (type == typeof(short))
                bw.Write((short)(value ?? 0));
            else if (type == typeof(ushort))
                bw.Write((ushort)(value ?? 0));
            else if (type == typeof(byte))
                bw.Write((byte)(value ?? 0));
            else if (type == typeof(float))
                bw.Write((float)(value ?? 0));
            else if (type == typeof(double))
                bw.Write((double)(value ?? 0));
            else if (type == typeof(bool))
                bw.Write((bool)(value ?? false));
            else if (type == typeof(char))
                bw.Write((char)(value ?? '\0'));
            else if (type == typeof(string))
            {
                int length = -1;

                var fixedLenAttr = prop?.GetCustomAttribute<FixedArrayLengthAttribute>();
                if (fixedLenAttr != null)
                {
                    length = fixedLenAttr.Length;
                }
                else if (string.Equals(prop?.Name, "name", StringComparison.OrdinalIgnoreCase))
                {
                    length = 64;
                }
                else
                {
                    throw new NotSupportedException($"No length specified for {prop?.Name}.");
                }

                if (length > 0)
                {
                    string str = value?.ToString() ?? string.Empty;

                    COMMON.Unicode.writeUnicodeStringWithFix(bw, str, length);
                    //COMMON.Unicode.writeUnicodeString(bw, str, length);
                    /*var encoding = Encoding.Unicode;
                    byte[] strBytes = encoding.GetBytes(str);

                    byte[] buffer = new byte[length];
                    int count = Math.Min(strBytes.Length, length);
                    Array.Copy(strBytes, buffer, count);

                    bw.Write(buffer);*/
                }
                else
                {
                    throw new NotSupportedException($"No string length for {prop?.Name} specified.");
                }
                return;
            }
            else if (type.IsEnum)
            {
                // schrijf enum als 4-byte int
                int enumVal = value != null ? Convert.ToInt32(value) : 0;
                bw.Write(enumVal);
            }
            else if (!type.IsPrimitive && type.IsClass)
            {
                if (value == null)
                {
                    // schrijf lege instantie
                    var emptyInstance = Activator.CreateInstance(type);
                    var method = typeof(ElementsTemplate) // vervang door de class naam waar WriteToBinaryWriter staat
                        .GetMethod(nameof(WriteToBinaryWriter))
                        .MakeGenericMethod(type);
                    method.Invoke(null, new object[] { bw, emptyInstance });
                }
                else
                {
                    var method = typeof(ElementsTemplate)
                        .GetMethod(nameof(WriteToBinaryWriter))
                        .MakeGenericMethod(type);
                    method.Invoke(null, new object[] { bw, value });
                }
            }
            else
            {
                throw new NotSupportedException($"Type {type.Name} is not supported for writing.");
            }
        }
    }
}
