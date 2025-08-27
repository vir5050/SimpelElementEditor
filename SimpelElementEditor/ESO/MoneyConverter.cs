using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Globalization;

public class MoneyConverter : Int32Converter
{
    public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
    {
        if (sourceType == typeof(string))
            return true;
        return base.CanConvertFrom(context, sourceType);
    }

    public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
    {
        if (destinationType == typeof(string))
            return true;
        return base.CanConvertTo(context, destinationType);
    }

    public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
        if (destinationType == typeof(string) && value is int bronze)
        {
            int gold = bronze / 10000; // 100s = 1g, 100b = 1s → 100*100 = 10,000 bronze
            bronze %= 10000;
            int silver = bronze / 100;
            bronze %= 100;
            return $"{gold}g {silver}s {bronze}b";
        }
        return base.ConvertTo(context, culture, value, destinationType);
    }

    public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
    {
        if (value is string str)
        {
            int totalBronze = 0;

            // Verwacht formaat zoals "10g 5s 20b" (hoofdletters maakt niet uit)
            str = str.Trim().ToLower();
            var parts = str.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var part in parts)
            {
                if (part.EndsWith("g"))
                {
                    if (int.TryParse(part.TrimEnd('g'), out int g))
                        totalBronze += g * 10000;
                }
                else if (part.EndsWith("s"))
                {
                    if (int.TryParse(part.TrimEnd('s'), out int s))
                        totalBronze += s * 100;
                }
                else if (part.EndsWith("b"))
                {
                    if (int.TryParse(part.TrimEnd('b'), out int b))
                        totalBronze += b;
                }
                else if (int.TryParse(part, out int onlyBronze)) // alleen een getal → bronze
                {
                    totalBronze += onlyBronze;
                }
            }

            return totalBronze;
        }
        return base.ConvertFrom(context, culture, value);
    }
}