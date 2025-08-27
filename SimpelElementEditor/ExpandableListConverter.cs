using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Reflection;
using System.Drawing;
using System.Globalization;
//DEZE FILE WORDT GEBRUIKT
// Converter voor arrays/lists
// ---------- ExpandableListConverter met kleur info ----------
public class ExpandableListConverter : ExpandableObjectConverter
{
    private static readonly Color[] colors = { Color.LightBlue, Color.LightGreen, Color.LightYellow, Color.LightCoral };

    public override bool GetPropertiesSupported(ITypeDescriptorContext context) => true;

    public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
    {
        if (value == null) return base.GetProperties(context, value, attributes);

        IList list;
        bool isArray = false;

        if (value is IList l)
            list = l;
        else if (value.GetType().IsArray)
        {
            list = ((Array)value).Cast<object>().ToList();
            isArray = true;
        }
        else
            return base.GetProperties(context, value, attributes);

        var parentName = context?.PropertyDescriptor?.Name ?? value.GetType().Name;

        var props = new PropertyDescriptor[list.Count];
        for (int i = 0; i < list.Count; i++)
        {
            var item = list[i];

            // Kies kleur op basis van index
            var colorAttr = new ColorAttribute(colors[i % colors.Length]);

            Type itemType = item?.GetType() ?? typeof(object);
            var pd = TypeDescriptor.CreateProperty(
                typeof(object), // componentType maakt hier minder uit
                $"{parentName}[{i}]",
                itemType,
                new TypeConverterAttribute(typeof(ExpandableObjectConverter)),
                colorAttr,
                new EditorAttribute(typeof(ColoredPropertyEditor), typeof(UITypeEditor))
            );

            props[i] = new ListItemPropertyDescriptor(list, i, pd, isArray);
        }

        return new PropertyDescriptorCollection(props);
    }

    public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
    {
        if (destinationType == typeof(string))
            return true;
        return base.CanConvertTo(context, destinationType);
    }

    public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
        if (destinationType == typeof(string) && value is IList list)
        {
            // gebruik de propertynaam als die bekend is
            string label = context?.PropertyDescriptor?.Name
                           ?? value.GetType().GetGenericArguments()[0].Name;

            return $"{label} ({list.Count})";
        }

        return base.ConvertTo(context, culture, value, destinationType);
    }
}

// Attribute om kleur per property op te slaan
[AttributeUsage(AttributeTargets.Property)]
public class ColorAttribute : Attribute
{
    public Color Color { get; }
    public ColorAttribute(int r, int g, int b) => Color = Color.FromArgb(r, g, b);
    public ColorAttribute(Color color) => Color = color;
}

public class ColoredPropertyGrid : PropertyGrid
{
    private Dictionary<string, Color> _rowColors = new Dictionary<string, Color>();

    public void SetRowColor(string propName, Color color)
    {
        _rowColors[propName] = color;
        Refresh();
    }

    protected override void WndProc(ref Message m)
    {
        base.WndProc(ref m);

        const int WM_PAINT = 0x000F;
        if (m.Msg == WM_PAINT)
        {
            PaintRowColors();
        }
    }

    private void PaintRowColors()
    {
        if (Controls.Count < 2) return;
        var gridView = Controls[1]; // Het GridView Control

        foreach (Control row in gridView.Controls)
        {
            if (row is null || string.IsNullOrEmpty(row.Text)) continue;

            if (_rowColors.TryGetValue(row.Text, out Color color))
            {
                using (var brush = new SolidBrush(color))
                {
                    // Hele achtergrond van de row kleuren
                    row.BackColor = color;
                    foreach (Control cell in row.Controls)
                    {
                        cell.BackColor = color;
                    }
                }
            }
        }
    }
}

// UITypeEditor om achtergrondkleur te tekenen
public class ColoredPropertyEditor : UITypeEditor
{
    public override bool GetPaintValueSupported(ITypeDescriptorContext context) => true;

    public override void PaintValue(PaintValueEventArgs e)
    {
        if (contextHasColor(context: e.Context))
        {
            var colorAttr = (ColorAttribute)e.Context.PropertyDescriptor.Attributes[typeof(ColorAttribute)];
            e.Graphics.FillRectangle(new SolidBrush(colorAttr.Color), e.Bounds);
        }
        else
        {
            base.PaintValue(e);
        }

        bool contextHasColor(ITypeDescriptorContext context) =>
            context?.PropertyDescriptor?.Attributes[typeof(ColorAttribute)] != null;
    }
}

// PropertyDescriptor voor elk item in een list/array
// ---------- Pas ListItemPropertyDescriptor aan om kleur attribuut te ondersteunen ----------
public class ListItemPropertyDescriptor : PropertyDescriptor
{
    private IList _list;
    private int _index;
    private PropertyDescriptor _baseDescriptor;
    private bool _isArray;

    public ListItemPropertyDescriptor(IList list, int index, PropertyDescriptor baseDescriptor, bool isArray)
        : base(baseDescriptor)
    {
        _list = list;
        _index = index;
        _baseDescriptor = baseDescriptor;
        _isArray = isArray;
    }

    public override object GetValue(object component) => _list[_index]; public override void SetValue(object component, object value)
    {
        if (_isArray)
            return; // Arrays zijn fixed size, meestal niet overschrijven

        if (_list == null || _index < 0 || _index >= _list.Count)
            return;

        var targetType = _list[_index]?.GetType()
                         ?? _list.GetType().GetGenericArguments().FirstOrDefault()
                         ?? typeof(object);

        try
        {
            object converted = value;

            if (value != null && !targetType.IsAssignableFrom(value.GetType()))
            {
                var converter = TypeDescriptor.GetConverter(targetType);
                if (converter != null && converter.CanConvertFrom(value.GetType()))
                {
                    converted = converter.ConvertFrom(value);
                }
                else
                {
                    // Laatste poging: ChangeType
                    converted = Convert.ChangeType(value, targetType);
                }
            }

            _list[_index] = converted;
        }
        catch (Exception ex)
        {
            // optioneel: loggen of gewoon negeren
            System.Diagnostics.Debug.WriteLine($"SetValue conversion failed: {ex.Message}");
        }
    }
    public override bool CanResetValue(object component) => false;
    public override void ResetValue(object component) { }
    public override bool ShouldSerializeValue(object component) => true;
    public override Type ComponentType => _list.GetType();
    public override bool IsReadOnly => false;
    public override Type PropertyType => _list[_index]?.GetType() ?? typeof(object);
}

public static class PropertyGridHelper
{
    private static readonly HashSet<Type> RegisteredTypes = new HashSet<Type>();

    /*public static void RegisterExpandableListsSafe(Type rootType)
    {
        // Altijd ook voor arrays
        TypeDescriptor.AddAttributes(typeof(Array),
            new TypeConverterAttribute(typeof(ExpandableListConverter)));

        // Alle List<T> vinden in het hele objectmodel
        foreach (var listType in FindAllListTypes(rootType))
        {
            // Converter voor de lijst zelf
            TypeDescriptor.AddAttributes(listType,
                new TypeConverterAttribute(typeof(ExpandableListConverter)));

            // Ook het itemtype zelf expandable maken, mits geschikt
            if (listType.IsGenericType)
            {
                var itemType = listType.GetGenericArguments()[0];
                if (IsExpandable(itemType))
                {
                    TypeDescriptor.AddAttributes(itemType,
                        new TypeConverterAttribute(typeof(ExpandableObjectConverter)));
                }
            }
        }
    }*/

    public static void RegisterExpandableListsSafe(Type rootType)
    {
        // Altijd ook voor arrays
        TypeDescriptor.AddAttributes(typeof(Array),
            new TypeConverterAttribute(typeof(ExpandableListConverter)));

        // Roottype zelf expandable maken (indien geschikt)
        if (IsExpandable(rootType))
        {
            TypeDescriptor.AddAttributes(rootType,
                new TypeConverterAttribute(typeof(ExpandableObjectConverter)));
        }

        // Extra: als rootType zelf een List<T> is
        if (rootType.IsGenericType && rootType.GetGenericTypeDefinition() == typeof(List<>))
        {
            RegisterListType(rootType);
            return; // geen verdere scan nodig
        }

        // Alle List<T> vinden in het hele objectmodel
        foreach (var listType in FindAllListTypes(rootType))
        {
            RegisterListType(listType);
        }
    }

    private static void RegisterListType(Type listType)
    {
        // Converter voor de lijst zelf
        TypeDescriptor.AddAttributes(listType,
            new TypeConverterAttribute(typeof(ExpandableListConverter)));

        // Ook het itemtype zelf expandable maken, mits geschikt
        if (listType.IsGenericType)
        {
            var itemType = listType.GetGenericArguments()[0];
            if (IsExpandable(itemType))
            {
                TypeDescriptor.AddAttributes(itemType,
                    new TypeConverterAttribute(typeof(ExpandableObjectConverter)));
            }
        }
    }

    private static IEnumerable<Type> FindAllListTypes(Type rootType)
    {
        var visited = new HashSet<Type>();
        var stack = new Stack<Type>();
        stack.Push(rootType);

        while (stack.Count > 0)
        {
            var current = stack.Pop();
            if (current == null || visited.Contains(current))
                continue;

            visited.Add(current);

            foreach (var prop in current.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                var propType = prop.PropertyType;
                if (propType.IsGenericType && propType.GetGenericTypeDefinition() == typeof(List<>))
                {
                    yield return propType;
                    stack.Push(propType.GetGenericArguments()[0]); // itemtype ook scannen
                }
                else if (IsExpandable(propType))
                {
                    stack.Push(propType);
                }
            }
        }
    }

    /// <summary>
    /// Bepaalt of een type geschikt is om expandable te maken.
    /// Sluit strings, primitives, enums en value types uit.
    /// </summary>
    private static bool IsExpandable(Type type)
    {
        return type != typeof(string) &&
               !type.IsPrimitive &&
               !type.IsEnum &&
               !type.IsValueType;
    }
}



/*public static class PropertyGridHelper
{
    private static readonly HashSet<Type> RegisteredTypes = new HashSet<Type>();
    public static void RegisterExpandableListsSafe(Type rootType)
    {
        // Altijd ook voor arrays
        TypeDescriptor.AddAttributes(typeof(Array),
            new TypeConverterAttribute(typeof(ExpandableListConverter)));

        // Alle List<T> vinden in het hele objectmodel
        foreach (var listType in FindAllListTypes(rootType))
        {
            TypeDescriptor.AddAttributes(listType,
                new TypeConverterAttribute(typeof(ExpandableListConverter)));

            // Ook het itemtype zelf expandable maken
            if (listType.IsGenericType)
            {
                var itemType = listType.GetGenericArguments()[0];
                TypeDescriptor.AddAttributes(itemType,
                    new TypeConverterAttribute(typeof(ExpandableObjectConverter)));
            }
        }
    }

    private static IEnumerable<Type> FindAllListTypes(Type rootType)
    {
        var visited = new HashSet<Type>();
        var stack = new Stack<Type>();
        stack.Push(rootType);

        while (stack.Count > 0)
        {
            var current = stack.Pop();
            if (current == null || visited.Contains(current))
                continue;

            visited.Add(current);

            foreach (var prop in current.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                var propType = prop.PropertyType;
                if (propType.IsGenericType && propType.GetGenericTypeDefinition() == typeof(List<>))
                {
                    yield return propType;
                    stack.Push(propType.GetGenericArguments()[0]); // itemtype ook scannen
                }
                else if (!propType.IsPrimitive && propType != typeof(string))
                {
                    stack.Push(propType);
                }
            }
        }
    }
    /*public static void RegisterExpandableListsSafe(Type rootType)
    {
        if (rootType == null || RegisteredTypes.Contains(rootType))
            return;

        RegisteredTypes.Add(rootType);

        foreach (var prop in rootType.GetProperties(BindingFlags.Public | BindingFlags.Instance))
        {
            var t = prop.PropertyType;

            // Voeg converter toe alleen voor arrays/lijsten
            if (typeof(IList).IsAssignableFrom(t) || t.IsArray)
            {
                TypeDescriptor.AddAttributes(t, new TypeConverterAttribute(typeof(ExpandableListConverter)));
            }

            // Registreer subtypes die geen primitive/string zijn EN geen list/array
            if (!t.IsPrimitive && t != typeof(string) && !typeof(IList).IsAssignableFrom(t) && !t.IsArray)
            {
                RegisterExpandableListsSafe(t);
            }
        }*/
//}



/*
public class AutoEditorProvider : TypeDescriptionProvider
{
    private readonly TypeDescriptionProvider _baseProvider;

    public AutoEditorProvider(Type type) : base(TypeDescriptor.GetProvider(type))
    {
        _baseProvider = TypeDescriptor.GetProvider(type);
    }

    public override ICustomTypeDescriptor GetTypeDescriptor(Type objectType, object instance)
    {
        var baseDescriptor = _baseProvider.GetTypeDescriptor(objectType, instance);
        return new AutoEditorTypeDescriptor(baseDescriptor, instance);
    }

    private class AutoEditorTypeDescriptor : CustomTypeDescriptor
    {
        private readonly object _instance;

        public AutoEditorTypeDescriptor(ICustomTypeDescriptor parent, object instance) : base(parent)
        {
            _instance = instance;
        }

        public override PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            var baseProps = base.GetProperties(attributes);
            var newProps = new List<PropertyDescriptor>();

            foreach (PropertyDescriptor prop in baseProps)
            {
                var propType = prop.PropertyType;
                object propValue = null;
                try { propValue = prop.GetValue(_instance); } catch { }

                // Arrays / Lists
                if (typeof(IList).IsAssignableFrom(propType) && propType != typeof(string) && propValue is IList list)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        var element = list[i];
                        if (element != null)
                        {
                            var elementProp = TypeDescriptor.CreateProperty(
                                prop.ComponentType,
                                $"{prop.Name}[{i}]",
                                element.GetType(),
                                new TypeConverterAttribute(typeof(ExpandableObjectConverter))
                            );
                            newProps.Add(elementProp);

                            // Recursief nested types registreren
                            RegisterNestedTypes(element.GetType());
                        }
                    }
                }
                // Nested classes
                else if (propType.IsClass && propType != typeof(string))
                {
                    newProps.Add(TypeDescriptor.CreateProperty(
                        prop.ComponentType,
                        prop,
                        new TypeConverterAttribute(typeof(ExpandableObjectConverter))
                    ));

                    // Recursief nested types registreren
                    RegisterNestedTypes(propType);
                }
                else
                {
                    newProps.Add(prop);
                }
            }

            return new PropertyDescriptorCollection(newProps.ToArray());
        }
    }

    // ----- Recursieve registratie van nested types -----
    private static readonly HashSet<Type> _registeredTypes = new HashSet<Type>();

    public static void Register<T>()
    {
        RegisterTypeRecursive(typeof(T));
    }

    private static void RegisterNestedTypes(Type type)
    {
        RegisterTypeRecursive(type);
    }

    private static void RegisterTypeRecursive(Type type)
    {
        if (_registeredTypes.Contains(type)) return;

        TypeDescriptor.AddProvider(new AutoEditorProvider(type), type);
        _registeredTypes.Add(type);

        foreach (var prop in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
        {
            var propType = prop.PropertyType;

            if (typeof(IList).IsAssignableFrom(propType) && propType != typeof(string))
            {
                var elementType = propType.IsArray
                    ? propType.GetElementType()
                    : propType.GetGenericArguments().Length > 0 ? propType.GetGenericArguments()[0] : null;

                if (elementType != null && elementType.IsClass && elementType != typeof(string))
                    RegisterTypeRecursive(elementType);
            }
            else if (propType.IsClass && propType != typeof(string))
            {
                RegisterTypeRecursive(propType);
            }
        }
    }
}
public class CustomListEditor : UITypeEditor
{
    public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
    {
        return UITypeEditorEditStyle.Modal;
    }

    public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
    {
        if (provider?.GetService(typeof(IWindowsFormsEditorService)) is IWindowsFormsEditorService editorService)
        {
            IList list = value as IList;
            if (list == null) return value;

            using (var form = new Form())
            {
                form.Text = "Edit List";
                form.Width = 400;
                form.Height = 300;
                form.StartPosition = FormStartPosition.CenterParent;

                var listBox = new ListBox() { Dock = DockStyle.Fill };
                foreach (var item in list)
                    listBox.Items.Add(item);

                var addButton = new Button() { Text = "Add", Dock = DockStyle.Top };
                addButton.Click += (s, e) =>
                {
                    listBox.Items.Add(null); // lege waarde of prompt voor type
                };

                var removeButton = new Button() { Text = "Remove", Dock = DockStyle.Top };
                removeButton.Click += (s, e) =>
                {
                    if (listBox.SelectedItem != null)
                        listBox.Items.Remove(listBox.SelectedItem);
                };

                var panel = new Panel() { Dock = DockStyle.Top, Height = 60 };
                panel.Controls.Add(addButton);
                panel.Controls.Add(removeButton);

                form.Controls.Add(listBox);
                form.Controls.Add(panel);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    list.Clear();
                    foreach (var item in listBox.Items)
                        list.Add(item);
                }
            }
        }

        return value;
    }
}

*/
