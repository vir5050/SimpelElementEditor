using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Reflection;
using System.Globalization;
using SimpelElementEditor.ESO;

public static class ItemLookupHelper
{
    public static Dictionary<int, string> _cache;
    public static Dictionary<string, int> _reverseCache;

    public static void InitializeCache()
    {
        var template = SimpelElementEditor.DataFiles.elementsTemplate;
        _cache = new Dictionary<int, string>();
        _reverseCache = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

        void AddItems<T>(IEnumerable<T> list, Func<T, int> getId, Func<T, string> getName)
        {
            foreach (var item in list)
            {
                var id = getId(item);
                var name = getName(item) ?? $"Unknown ({id})";
                if (!_cache.ContainsKey(id))
                    _cache[id] = name;
                if (!_reverseCache.ContainsKey(name))
                    _reverseCache[name] = id;
            }
        }

        AddItems(template.EQUIPMENT_ESSENCE, i => i.id, i => i.name);
        AddItems(template.MEDICINE_ESSENCE, i => i.id, i => i.name);
        AddItems(template.MATERIAL_ESSENCE, i => i.id, i => i.name);
        AddItems(template.REFINE_TICKET_ESSENCE, i => i.id, i => i.name);
        AddItems(template.SKILLTOME_ESSENCE, i => i.id, i => i.name);
        AddItems(template.TRANSMITROLL_ESSENCE, i => i.id, i => i.name);
        AddItems(template.LUCKYROLL_ESSENCE, i => i.id, i => i.name);
        AddItems(template.TOWNSCROLL_ESSENCE, i => i.id, i => i.name);
        AddItems(template.REVIVESCROLL_ESSENCE, i => i.id, i => i.name);
        AddItems(template.TASKMATTER_ESSENCE, i => i.id, i => i.name);
        AddItems(template.AIRCRAFT_ESSENCE, i => i.id, i => i.name);
        AddItems(template.CHANGE_SHAPE_ESSENCE, i => i.id, i => i.name);
        AddItems(template.SUMMON_MONSTER_ESSENCE, i => i.id, i => i.name);
        AddItems(template.PET_BEDGE_ESSENCE, i => i.id, i => i.name);
        AddItems(template.PET_FOOD_ESSENCE, i => i.id, i => i.name);
        AddItems(template.PET_SKILL_ESSENCE, i => i.id, i => i.name);
        AddItems(template.PET_ARMOR_ESSENCE, i => i.id, i => i.name);
        AddItems(template.AI_HELPER_ESSENCE, i => i.id, i => i.name);
        AddItems(template.PET_MERGE_ESSENCE, i => i.id, i => i.name);
        AddItems(template.CHANGE_RECOVER_ESSENCE, i => i.id, i => i.name);
        AddItems(template.HATCHER_ESSENCE, i => i.id, i => i.name);
        AddItems(template.BOOK_ESSENCE, i => i.id, i => i.name);
        AddItems(template.SPECIAL_SPEAKER_ESSENCE, i => i.id, i => i.name);
        AddItems(template.GARDEN_ORNAMENT_ESSENCE, i => i.id, i => i.name);
        AddItems(template.SEED_ESSENCE, i => i.id, i => i.name);
        AddItems(template.FRUIT_ESSENCE, i => i.id, i => i.name);
        AddItems(template.GARDEN_TOOL_ESSENCE, i => i.id, i => i.name);
        AddItems(template.RUNE_ESSENCE, i => i.id, i => i.name);
        AddItems(template.TASKDICE_ESSENCE, i => i.id, i => i.name);
        AddItems(template.TASKNORMALMATTER_ESSENCE, i => i.id, i => i.name);
        AddItems(template.GM_GENERATOR_ESSENCE, i => i.id, i => i.name);
        AddItems(template.FIREWORKS_ESSENCE, i => i.id, i => i.name);
        AddItems(template.ESTONE_ESSENCE, i => i.id, i => i.name);
        AddItems(template.PSTONE_ESSENCE, i => i.id, i => i.name);
        AddItems(template.SSTONE_ESSENCE, i => i.id, i => i.name);
        AddItems(template.RECIPEROLL_ESSENCE, i => i.id, i => i.name);
        AddItems(template.DOUBLE_EXP_ESSENCE, i => i.id, i => i.name);
        AddItems(template.DESTROYING_ESSENCE, i => i.id, i => i.name);
        AddItems(template.SKILLMATTER_ESSENCE, i => i.id, i => i.name);
        AddItems(template.VEHICLE_ESSENCE, i => i.id, i => i.name);
        AddItems(template.COUPLE_JUMPTO_ESSENCE, i => i.id, i => i.name);
        AddItems(template.LOTTERY_ESSENCE, i => i.id, i => i.name);
        AddItems(template.CAMRECORDER_ESSENCE, i => i.id, i => i.name);
        AddItems(template.TEXT_FIREWORKS_ESSENCE, i => i.id, i => i.name);
        AddItems(template.TALISMAN_MAINPART_ESSENCE, i => i.id, i => i.name);
        AddItems(template.TALISMAN_EXPFOOD_ESSENCE, i => i.id, i => i.name);
        AddItems(template.TALISMAN_MERGEKATALYST_ESSENCE, i => i.id, i => i.name);
        AddItems(template.TALISMAN_ENERGYFOOD_ESSENCE, i => i.id, i => i.name);
        AddItems(template.SPEAKER_ESSENCE, i => i.id, i => i.name);
        AddItems(template.POTENTIAL_TOME_ESSENCE, i => i.id, i => i.name);
    }

    public static string GetItemName(int id)
    {
        if (_cache == null)
            InitializeCache();

        return _cache.TryGetValue(id, out var name) ? name : $"Unknown ({id})";
    }
    public static string GetItemString(int id)
    {
        var name = GetItemName(id);
        return name != null ? $"{id} - {name}" : id.ToString();
    }

    public static int GetId(string name)
    {
        if (_reverseCache == null)
            InitializeCache();

        return _reverseCache.TryGetValue(name, out var id) ? id : -1;
    }

    public static IEnumerable<int> GetAllIds()
    {
        if (_cache == null)
            InitializeCache();

        return _cache.Keys;
    }
}

public class ItemIdConverter : Int32Converter
{
    public override bool GetStandardValuesSupported(ITypeDescriptorContext context) => false;

    public override bool GetStandardValuesExclusive(ITypeDescriptorContext context) => false;

    public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
    {
        return new StandardValuesCollection(ItemLookupHelper.GetAllIds().ToArray());
    }

    public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
        if (destinationType == typeof(string) && value is int id)
        {
            string name = ItemLookupHelper.GetItemName(id);
            return $"{id} - {name}";
        }
        return base.ConvertTo(context, culture, value, destinationType);
    }

    public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
    {
        if (value is string str)
        {
            str = str.Trim();

            var parts = str.Split(new[] { '-' }, 2);
            if (parts.Length == 2)
            {
                if (int.TryParse(parts[0].Trim(), out int idFromPart))
                    return idFromPart;
            }
            else
            {
                if (int.TryParse(str, out int idDirect))
                    return idDirect;

                int idByName = ItemLookupHelper.GetId(str);
                if (idByName != -1)
                    return idByName;
            }

            throw new ArgumentException($"Waarde '{str}' is geen geldig ID of naam.");
        }

        return base.ConvertFrom(context, culture, value);
    }
}