using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using SimpelElementEditor.ESO;
using System.Collections;

public static class LookupHelper
{
    public static string GetLookupString(object instance, string propertyName)
    {
        if (instance == null || string.IsNullOrEmpty(propertyName))
            return string.Empty;

        var pd = TypeDescriptor.GetProperties(instance)[propertyName];
        if (pd == null)
            return string.Empty;

        var value = pd.GetValue(instance);
        if (value == null)
            return string.Empty;

        var converter = pd.Converter;

        if (value is IList list)
        {
            return "[" + string.Join(", ", list.Cast<object>().Select(item =>
            {
                if (item == null) return "null";

                var itemConverter = TypeDescriptor.GetConverter(item);
                if (itemConverter != null && itemConverter.CanConvertTo(typeof(string)))
                {
                    try { return itemConverter.ConvertToInvariantString(item); }
                    catch { return item.ToString(); }
                }
                return item.ToString();
            })) + "]";
        }

        if (converter != null && converter.CanConvertTo(typeof(string)))
        {
            try
            {
                // Gebruik nu onze SimpleContext zodat de converter weet wat de PropertyDescriptor is
                var ctx = new SimpleContext(instance, pd);
                return converter.ConvertTo(ctx, CultureInfo.InvariantCulture, value, typeof(string))?.ToString() ?? string.Empty;
            }
            catch
            {
                return value.ToString();
            }
        }

        return value.ToString();
    }

    /// <summary>
    /// Haal automatisch het type van de lookup via het attribuut op property level
    /// </summary>
    public static int Resolve(object instance, string propertyName, int id)
    {
        var pd = TypeDescriptor.GetProperties(instance)[propertyName];
        if (pd == null) return id;

        // Zoek het [LookupType]-attribuut
        var attr = (SimpelElementEditor.Reader.LookupTypeAttribute)pd.Attributes[typeof(SimpelElementEditor.Reader.LookupTypeAttribute)];
        if (attr != null)
        {
            var targetType = attr.LookupType;

            // Hier kun je optioneel checken in je eigen Dictionary<Type, Dictionary<int, object>> 
            // als je runtime validation wilt.
            // Zonder tabel gewoon het ID teruggeven.
        }

        return id;
    }

    private class SimpleContext : ITypeDescriptorContext
    {
        public SimpleContext(object instance, PropertyDescriptor pd)
        {
            Instance = instance;
            PropertyDescriptor = pd;
        }

        public IContainer Container => null;
        public object Instance { get; }
        public PropertyDescriptor PropertyDescriptor { get; }
        public object GetService(Type serviceType) => null;
        public bool OnComponentChanging() => true;
        public void OnComponentChanged() { }
    }
}

public class LookupIdConverter : TypeConverter
{
    public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) =>
        sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);

    public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
    {
        if (value is string s && context?.PropertyDescriptor != null)
        {
            var attr = context.PropertyDescriptor.Attributes[typeof(SimpelElementEditor.Reader.LookupTypeAttribute)] as SimpelElementEditor.Reader.LookupTypeAttribute;
            if (attr != null)
            {
                var list = GetLookupList(attr.LookupType);
                var found = list?.Cast<object>().FirstOrDefault(x => GetName(x).Equals(s, StringComparison.OrdinalIgnoreCase));
                if (found != null)
                {
                    return GetId(found);
                }

                if (int.TryParse(s, out int id))
                    return id;
            }
        }
        return base.ConvertFrom(context, culture, value);
    }

    public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
        if (destinationType == typeof(string) && value is int id)
        {
            Type lookupType = null;

            // probeer eerst het attribuut te pakken
            if (context?.PropertyDescriptor != null)
            {
                var attr = context.PropertyDescriptor.Attributes[typeof(SimpelElementEditor.Reader.LookupTypeAttribute)]
                           as SimpelElementEditor.Reader.LookupTypeAttribute;
                if (attr != null)
                    lookupType = attr.LookupType;
            }

            // fallback: als er geen context of attribuut is, probeer een standaard lookupType
            if (lookupType == null)
                lookupType = typeof(SimpelElementEditor.ESO.Elements.ElementsTemplate); // pas aan naar je meest gebruikte type

            // doe de lookup
            var list = GetLookupList(lookupType);
            if (list != null)
            {
                var found = list.Cast<object>().FirstOrDefault(x => GetId(x) == id);
                if (found != null)
                    return GetName(found);

                if (lookupType == typeof(SimpelElementEditor.ESO.Elements.MONSTER_ESSENCE)) //if monster not found fall back on npc, required for npcgen
                {
                    var npcList = GetLookupList(typeof(SimpelElementEditor.ESO.Elements.NPC_ESSENCE));
                    found = npcList?.Cast<object>().FirstOrDefault(x => GetId(x) == id);
                    if (found != null)
                        return GetName(found);
                }
            }

            // fallback: gewoon het nummer tonen
            return id.ToString();
        }

        return base.ConvertTo(context, culture, value, destinationType);
    }

    public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
    {
        if (context?.PropertyDescriptor != null)
        {
            var attr = context.PropertyDescriptor.Attributes[typeof(SimpelElementEditor.Reader.LookupTypeAttribute)] as SimpelElementEditor.Reader.LookupTypeAttribute;
            if (attr != null)
            {
                var list = GetLookupList(attr.LookupType);
                if (list != null)
                    return new StandardValuesCollection(list.Cast<object>().Select(GetName).ToList());
            }
        }
        return base.GetStandardValues(context);
    }

    public override bool GetStandardValuesSupported(ITypeDescriptorContext context) => true;
    public override bool GetStandardValuesExclusive(ITypeDescriptorContext context) => true;

    // Helpers: haal de lijst op basis van het type
    /*private IList GetLookupList(Type lookupType)
    {
        // Hier moet je jouw data-bron koppelen.
        // Bijvoorbeeld singleton of statisch ElementsTemplate instance:
        if (lookupType == typeof(EQUIPMENT_SUB_TYPE))
            return SimpelElementEditor.Form1.CurrentElementsTemplate.EQUIPMENT_SUB_TYPE.Cast<object>().ToList();
        if (lookupType == typeof(EQUIPMENT_MAJOR_TYPE))
            return SimpelElementEditor.Form1.CurrentElementsTemplate.EQUIPMENT_MAJOR_TYPE.Cast<object>().ToList();
        if (lookupType == typeof(MATERIAL_MAJOR_TYPE))
            return SimpelElementEditor.Form1.CurrentElementsTemplate.MATERIAL_MAJOR_TYPE.Cast<object>().ToList();
        if (lookupType == typeof(MATERIAL_SUB_TYPE))
            return SimpelElementEditor.Form1.CurrentElementsTemplate.MATERIAL_SUB_TYPE.Cast<object>().ToList();

        // Voeg hier andere types toe
        return null;
    }*/

    private IList GetLookupList(Type lookupType)
    {
        var sources = new object[] {
        SimpelElementEditor.DataFiles.elementsTemplate,
        SimpelElementEditor.DataFiles.aiPolicyTemplate,
        SimpelElementEditor.DataFiles.pathTemplate,
        SimpelElementEditor.DataFiles.tasksSimpleTemplate,
        SimpelElementEditor.DataFiles.SkillsTemplate,
        SimpelElementEditor.DataFiles.mapData,
        SimpelElementEditor.DataFiles.gShopTemplate
    };

        foreach (var src in sources)
        {
            if (src == null) continue;
            var match = src.GetType()
                .GetProperties()
                .FirstOrDefault(p =>
                {
                    var propType = p.PropertyType;
                    return propType.IsGenericType &&
                           typeof(IList).IsAssignableFrom(propType) &&
                           propType.GetGenericArguments()[0] == lookupType;
                });

            if (match != null)
            {
                var list = match.GetValue(src) as IList;
                if (list != null && list.Count > 0)
                    return list;
            }
        }

        return Array.Empty<object>(); // fallback
    }

    // Helpers om id en name te pakken via reflection
    private int GetId(object item)
    {
        var prop = item.GetType().GetProperty("id");
        return (int)(prop?.GetValue(item) ?? 0);
    }

    private string GetName(object item)
    {
        var prop = item.GetType().GetProperty("name");
        return (string)(prop?.GetValue(item) ?? "");
    }
}