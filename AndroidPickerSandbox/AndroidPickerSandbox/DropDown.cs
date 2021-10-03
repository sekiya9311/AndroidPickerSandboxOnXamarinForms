using System;
using System.Collections;
using System.Collections.Generic;
using Xamarin.Forms;

namespace AndroidPickerSandbox
{
    public class DropDown : View
    {
        public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(
            nameof(Placeholder),
            typeof(string),
            typeof(DropDown),
            ""
        );
        
        public static readonly BindableProperty SelectedIndexProperty = BindableProperty.Create(
            nameof(SelectedIndex),
            typeof(int),
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

        public string Placeholder
        {
            get => (string)GetValue(PlaceholderProperty);
            set => SetValue(PlaceholderProperty, value);
        }

        public int SelectedIndex
        {
            get => (int)GetValue(SelectedIndexProperty);
            set => SetValue(SelectedIndexProperty, value);
        }

        public IList<string> Items
        {
            get => (IList<string>)GetValue(ItemsProperty);
            set => SetValue(ItemsProperty, value);
        }
    }
}
