using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

public class NamedArrayConverter : ArrayConverter
{
    public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
    {
        var array = value as Array;
        if (array == null)
            return base.GetProperties(context, value, attributes);

        // Zoek naar IndexNamesAttribute op de property zelf
        var indexNames = GetIndexNames(context);

        var props = new PropertyDescriptor[array.Length];
        for (int i = 0; i < array.Length; i++)
        {
            string displayName = (indexNames != null && i < indexNames.Length)
                ? indexNames[i]
                : $"Index {i}";

            props[i] = new ArrayItemPropertyDescriptor(array, i, displayName);
        }

        return new PropertyDescriptorCollection(props);
    }

    private string[] GetIndexNames(ITypeDescriptorContext context)
    {
        if (context?.PropertyDescriptor == null)
            return null;

        var attr = context.PropertyDescriptor.Attributes
            .OfType<SimpelElementEditor.Reader.IndexNamesAttribute>()
            .FirstOrDefault();

        return attr?.Names;
    }
}

public class ArrayItemPropertyDescriptor : PropertyDescriptor
{
    private readonly Array _array;
    private readonly int _index;

    public ArrayItemPropertyDescriptor(Array array, int index, string name) : base(name, null)
    {
        _array = array;
        _index = index;
    }

    public override object GetValue(object component) => _array.GetValue(_index);
    public override void SetValue(object component, object value) => _array.SetValue(value, _index);
    public override bool IsReadOnly => false;
    public override Type PropertyType => _array.GetType().GetElementType();
    public override Type ComponentType => _array.GetType();
    public override bool CanResetValue(object component) => false;
    public override void ResetValue(object component) { }
    public override bool ShouldSerializeValue(object component) => true;
}
