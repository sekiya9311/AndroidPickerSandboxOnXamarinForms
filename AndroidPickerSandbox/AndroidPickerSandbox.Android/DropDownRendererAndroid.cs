﻿using Android.Content;
using Android.Views;
using Android.Widget;
using AndroidPickerSandbox;
using AndroidPickerSandbox.Android;
using Google.Android.Material.TextField;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(DropDown), typeof(DropDownRendererAndroid))]
namespace AndroidPickerSandbox.Android
{
    public class DropDownRendererAndroid : ViewRenderer<DropDown, TextInputLayout>
    {
        private TextInputLayout? _textInputLayout;
        private AutoCompleteTextView? _autoCompleteTextView;
        
        public DropDownRendererAndroid(Context context) : base(MaterialComponentsContextThemeWrapper.Create(context))
        {
        }

        protected override TextInputLayout CreateNativeControl()
        {
            var myContext = Context!;
            var inflater = LayoutInflater.FromContext(myContext)!;
            
            _textInputLayout = (TextInputLayout)inflater.Inflate(Resource.Layout.drop_down, null)!;
            _autoCompleteTextView = (AutoCompleteTextView)_textInputLayout.EditText;
            // NOTE: https://stackoverflow.com/questions/61581115/inputtype-none-doesnt-work-with-material-components-exposeddropdownmenu
            _autoCompleteTextView.ShowSoftInputOnFocus = false;

            return _textInputLayout;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<DropDown> e)
        {
            base.OnElementChanged(e);
            if (Control == null)
            {
                SetNativeControl(CreateNativeControl());
            }
            
            if (_autoCompleteTextView == null) return;
            ArrayAdapter adapter = new(Context!, Resource.Layout.list_item_of_drop_down, Element.Items);
            _autoCompleteTextView.Adapter = adapter;
            _autoCompleteTextView.Text = Element.SelectedItem.ToString();
        }
    }
}
