using System;
using System.Collections;
using Xamarin.Forms;

namespace AndroidPickerSandbox
{
    public class DropDown : View
    {
        public static readonly BindableProperty SelectedItemProperty = BindableProperty.Create(
            nameof(SelectedItem),
            typeof(object),
            typeof(DropDown),
            null,
            BindingMode.TwoWay
        );

        public static readonly BindableProperty ItemsProperty = BindableProperty.Create(
            nameof(Items),
            typeof(IList),
            typeof(DropDown),
            Array.Empty<object>(),
            BindingMode.TwoWay
        );

        public object SelectedItem
        {
            get => GetValue(SelectedItemProperty);
            set => SetValue(SelectedItemProperty, value);
        }

        public IList Items
        {
            get => (IList)GetValue(ItemsProperty);
            set => SetValue(ItemsProperty, value);
        }
    }
}
