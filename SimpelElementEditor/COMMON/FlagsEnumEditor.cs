using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Drawing.Design; // voor UITypeEditor
using System.Windows.Forms;
using System.Windows.Forms.Design; // voor IWindowsFormsEditorService

namespace SimpelElementEditor.COMMON
{
    public class FlagsEnumEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
            => UITypeEditorEditStyle.DropDown;

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            var editorService = provider?.GetService(typeof(IWindowsFormsEditorService)) as IWindowsFormsEditorService;
            if (editorService == null) return value;

            CheckedListBox list = new CheckedListBox
            {
                BorderStyle = BorderStyle.None,
                CheckOnClick = true
            };

            foreach (Enum enumValue in Enum.GetValues(value.GetType()))
            {
                bool isChecked = ((Enum)value).HasFlag(enumValue);
                list.Items.Add(enumValue, isChecked);
            }

            list.ItemCheck += (s, e) =>
            {
                int index = e.Index;
                var itemValue = (Enum)list.Items[index];
                if (e.NewValue == CheckState.Checked)
                    value = (Enum)Enum.ToObject(value.GetType(), Convert.ToInt32(value) | Convert.ToInt32(itemValue));
                else
                    value = (Enum)Enum.ToObject(value.GetType(), Convert.ToInt32(value) & ~Convert.ToInt32(itemValue));
            };

            editorService.DropDownControl(list);
            return value;
        }
    }
}
