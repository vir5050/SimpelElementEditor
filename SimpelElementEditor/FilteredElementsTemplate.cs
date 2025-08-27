using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;
using SimpelElementEditor.ESO.Elements;

public static class PropertyGridExtensions
{
    public static void ExpandSmallLists(this PropertyGrid grid, int maxItems = 10)
    {
        foreach (GridItem item in grid.SelectedGridItem?.Parent?.GridItems ?? grid.SelectedGridItem?.GridItems ?? grid.SelectedGridItem?.GridItems)
        {
            ExpandIfSmall(item, maxItems);
        }

        void ExpandIfSmall(GridItem gi, int max)
        {
            if (gi.GridItems.Count > 0)
            {
                foreach (GridItem child in gi.GridItems)
                    ExpandIfSmall(child, max);

                if (gi.GridItems.Count <= max)
                    gi.Expanded = true;
            }
        }
    }
    public static void ExpandSingleRoot(this PropertyGrid grid)
    {
        if (grid?.SelectedGridItem == null) return;

        // Bepaal de top-level GridItems
        GridItemCollection roots = grid.SelectedGridItem.Parent?.GridItems ?? grid.SelectedGridItem.GridItems;
        if (roots == null) return;

        if (roots.Count == 1)
        {
            roots[0].Expanded = true;
        }
    }
}
public class FilteredElementsTemplate : ICustomTypeDescriptor
{
    private readonly ElementsTemplate _original;
    private readonly string _search;

    public FilteredElementsTemplate(ElementsTemplate original, string search)
    {
        _original = original;
        _search = search?.ToLower() ?? "";
    }

    public AttributeCollection GetAttributes() => TypeDescriptor.GetAttributes(_original);
    public string GetClassName() => TypeDescriptor.GetClassName(_original);
    public string GetComponentName() => TypeDescriptor.GetComponentName(_original);
    public TypeConverter GetConverter() => TypeDescriptor.GetConverter(_original);
    public EventDescriptor GetDefaultEvent() => TypeDescriptor.GetDefaultEvent(_original);
    public PropertyDescriptor GetDefaultProperty() => TypeDescriptor.GetDefaultProperty(_original);
    public object GetEditor(Type editorBaseType) => TypeDescriptor.GetEditor(_original, editorBaseType);
    public EventDescriptorCollection GetEvents(Attribute[] attributes) => TypeDescriptor.GetEvents(_original, attributes);
    public EventDescriptorCollection GetEvents() => TypeDescriptor.GetEvents(_original);

    public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
    {
        var props = TypeDescriptor.GetProperties(_original, attributes);
        var filteredProps = new List<PropertyDescriptor>();

        foreach (PropertyDescriptor prop in props)
        {
            if (!typeof(IList).IsAssignableFrom(prop.PropertyType)) continue; // alleen lijsten

            var list = prop.GetValue(_original) as IList;
            if (list == null || list.Count == 0) continue;

            var filteredList = FilterList(list);
            if (filteredList != null && filteredList.Count > 0)
            {
                // vervang originele list door filtered list
                var pd = new FilteredListPropertyDescriptor(prop, filteredList);
                filteredProps.Add(pd);
            }
        }

        return new PropertyDescriptorCollection(filteredProps.ToArray());
    }

    public PropertyDescriptorCollection GetProperties() => GetProperties(new Attribute[0]);
    public object GetPropertyOwner(PropertyDescriptor pd) => _original;

    private IList FilterList(IList originalList)
    {
        var itemType = originalList.GetType().IsGenericType
            ? originalList.GetType().GetGenericArguments()[0]
            : originalList[0]?.GetType();

        if (itemType == null) return null;

        var idProp = itemType.GetProperty("id");
        var nameProp = itemType.GetProperty("name");

        var filteredList = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(itemType));

        foreach (var item in originalList)
        {
            if (item == null) continue;

            bool matches = false;
            if (idProp != null && idProp.GetValue(item)?.ToString()?.ToLower().Contains(_search) == true)
                matches = true;
            if (nameProp != null && nameProp.GetValue(item)?.ToString()?.ToLower().Contains(_search) == true)
                matches = true;

            if (matches) filteredList.Add(item);
        }

        return filteredList.Count > 0 ? filteredList : null;
    }

    // HulppropertyDescriptor om de filtered list door te geven
    private class FilteredListPropertyDescriptor : PropertyDescriptor
    {
        private readonly PropertyDescriptor _base;
        private readonly IList _list;

        public FilteredListPropertyDescriptor(PropertyDescriptor baseProp, IList list)
            : base(baseProp)
        {
            _base = baseProp;
            _list = list;
        }

        public override Type ComponentType => _base.ComponentType;
        public override bool IsReadOnly => _base.IsReadOnly;
        public override Type PropertyType => _base.PropertyType;
        public override bool CanResetValue(object component) => _base.CanResetValue(component);
        public override object GetValue(object component) => _list;
        public override void ResetValue(object component) => _base.ResetValue(component);
        public override void SetValue(object component, object value) => _base.SetValue(component, value);
        public override bool ShouldSerializeValue(object component) => _base.ShouldSerializeValue(component);
    }
}


/*
public class FilteredElementsTemplate : ICustomTypeDescriptor
{
    private readonly ElementsTemplate _original;
    private readonly string _search;

    public FilteredElementsTemplate(ElementsTemplate original, string search)
    {
        _original = original;
        _search = search?.ToLower() ?? "";
    }

    public AttributeCollection GetAttributes() => TypeDescriptor.GetAttributes(_original);
    public string GetClassName() => TypeDescriptor.GetClassName(_original);
    public string GetComponentName() => TypeDescriptor.GetComponentName(_original);
    public TypeConverter GetConverter() => TypeDescriptor.GetConverter(_original);
    public EventDescriptor GetDefaultEvent() => TypeDescriptor.GetDefaultEvent(_original);
    public PropertyDescriptor GetDefaultProperty() => TypeDescriptor.GetDefaultProperty(_original);
    public object GetEditor(Type editorBaseType) => TypeDescriptor.GetEditor(_original, editorBaseType);
    public EventDescriptorCollection GetEvents(Attribute[] attributes) => TypeDescriptor.GetEvents(_original, attributes);
    public EventDescriptorCollection GetEvents() => TypeDescriptor.GetEvents(_original);

    public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
    {
        var props = TypeDescriptor.GetProperties(_original, attributes);
        var filteredProps = new List<PropertyDescriptor>();

        foreach (PropertyDescriptor prop in props)
        {
            if (typeof(IList).IsAssignableFrom(prop.PropertyType))
            {
                var list = prop.GetValue(_original) as IList;
                var filtered = FilterList(list);
                if (filtered != null && filtered.Count > 0)
                {
                    filteredProps.Add(new FilteredListPropertyDescriptor(prop, filtered));
                }
            }
            else
            {
                filteredProps.Add(prop);
            }
        }

        return new PropertyDescriptorCollection(filteredProps.ToArray());
    }

    public PropertyDescriptorCollection GetProperties() => GetProperties(new Attribute[0]);
    public object GetPropertyOwner(PropertyDescriptor pd) => _original;

    private IList FilterList(IList originalList)
    {
        if (originalList == null || originalList.Count == 0) return null;

        Type itemType = null;
        var genericArgs = originalList.GetType().GetGenericArguments();
        if (genericArgs.Length > 0)
            itemType = genericArgs[0];
        else if (originalList[0] != null)
            itemType = originalList[0].GetType();
        else
            return null;

        var filteredList = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(itemType));

        foreach (var item in originalList)
        {
            if (item == null) continue;
            if (ItemMatches(item)) filteredList.Add(item);
        }

        return filteredList.Count > 0 ? filteredList : null;
    }

    private bool ItemMatches(object obj)
    {
        if (obj == null) return false;

        var type = obj.GetType();
        var idProp = type.GetProperty("id");
        var nameProp = type.GetProperty("name");

        if (idProp != null && idProp.GetValue(obj)?.ToString()?.Contains(_search) == true)
            return true;

        if (nameProp != null && nameProp.GetValue(obj)?.ToString()?.ToLower().Contains(_search) == true)
            return true;

        // Recursief zoeken in child-lijsten
        foreach (var prop in type.GetProperties())
        {
            if (typeof(IList).IsAssignableFrom(prop.PropertyType))
            {
                var list = prop.GetValue(obj) as IList;
                if (FilterList(list)?.Count > 0) return true;
            }
        }

        return false;
    }

    // Wrapper voor een gefilterde lijst zodat PropertyGrid het correct toont
    private class FilteredListPropertyDescriptor : PropertyDescriptor
    {
        private readonly PropertyDescriptor _baseDescriptor;
        private readonly object _value;

        public FilteredListPropertyDescriptor(PropertyDescriptor baseDescriptor, object value)
            : base(baseDescriptor.Name, null)
        {
            _baseDescriptor = baseDescriptor;
            _value = value;
        }

        public override bool CanResetValue(object component) => _baseDescriptor.CanResetValue(component);
        public override Type ComponentType => _baseDescriptor.ComponentType;
        public override object GetValue(object component) => _value;
        public override bool IsReadOnly => _baseDescriptor.IsReadOnly;
        public override Type PropertyType => _baseDescriptor.PropertyType;
        public override void ResetValue(object component) => _baseDescriptor.ResetValue(component);
        public override void SetValue(object component, object value) => _baseDescriptor.SetValue(component, value);
        public override bool ShouldSerializeValue(object component) => _baseDescriptor.ShouldSerializeValue(component);
    }
}*/