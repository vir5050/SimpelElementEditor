using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Globalization;
using SimpelElementEditor;
using System.Reflection;

// ===== Attribute =====
[AttributeUsage(AttributeTargets.Property)]
public class IntStringListAttribute : Attribute
{
    public string PropertyName { get; }
    public IntStringListAttribute(string propertyName) => PropertyName = propertyName;
}

public class IntStringListConverter : TypeConverter
{
    public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) =>
        sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);

    public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
    {
        if (value is string s && context?.PropertyDescriptor != null)
        {
            var attr = context.PropertyDescriptor.Attributes[typeof(IntStringListAttribute)] as IntStringListAttribute;
            if (attr != null)
            {
                var prop = typeof(DataFiles).GetProperty(attr.PropertyName, BindingFlags.Public | BindingFlags.Static);
                var options = prop?.GetValue(null) as Dictionary<int, string>;
                if (options != null)
                {
                    foreach (var kvp in options)
                    {
                        if (string.Equals(kvp.Value?.Trim(), s.Trim(), StringComparison.OrdinalIgnoreCase))
                            return kvp.Key;
                    }
                }

                if (int.TryParse(s, out int i))
                    return i;
            }
        }

        return base.ConvertFrom(context, culture, value);
    }

    public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
        if (destinationType == typeof(string) && value is int i && context?.PropertyDescriptor != null)
        {
            var attr = context.PropertyDescriptor.Attributes[typeof(IntStringListAttribute)] as IntStringListAttribute;
            if (attr != null)
            {
                var prop = typeof(DataFiles).GetProperty(attr.PropertyName, BindingFlags.Public | BindingFlags.Static);
                var options = prop?.GetValue(null) as Dictionary<int, string>;
                if (options != null && options.TryGetValue(i, out var str))
                    return str;
            }

            return i.ToString();
        }

        return base.ConvertTo(context, culture, value, destinationType);
    }

    public override bool GetStandardValuesSupported(ITypeDescriptorContext context) => true;
    public override bool GetStandardValuesExclusive(ITypeDescriptorContext context) => true;

    public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
    {
        if (context?.PropertyDescriptor != null)
        {
            var attr = context.PropertyDescriptor.Attributes[typeof(IntStringListAttribute)] as IntStringListAttribute;
            if (attr != null)
            {
                var prop = typeof(DataFiles).GetProperty(attr.PropertyName, BindingFlags.Public | BindingFlags.Static);
                var options = prop?.GetValue(null) as Dictionary<int, string>;
                if (options != null)
                    return new StandardValuesCollection(options.Values.ToList());
            }
        }
        return base.GetStandardValues(context);
    }
}