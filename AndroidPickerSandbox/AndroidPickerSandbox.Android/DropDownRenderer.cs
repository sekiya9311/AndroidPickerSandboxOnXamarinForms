using System.Linq;
using Android.Content;
using Android.Views;
using Android.Widget;
using AndroidPickerSandbox;
using AndroidPickerSandbox.Android;
using Google.Android.Material.Dialog;
using Google.Android.Material.TextField;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(DropDown), typeof(DropDownRenderer))]
namespace AndroidPickerSandbox.Android
{
    class DropDownRenderer : ViewRenderer<DropDown, TextInputLayout>, IDialogInterfaceOnDismissListener
    {
        private readonly Context _context;
    
        public DropDownRenderer(Context context) : base(MaterialComponentsContextThemeWrapper.Create(context))
        {
            _context = Context!;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<DropDown> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                SetNativeControl(CreateNativeControl());
            }
        }

        protected override TextInputLayout CreateNativeControl()
        {
            var inflater = LayoutInflater.FromContext(_context)!;
            var view = (TextInputLayout)inflater.Inflate(Resource.Layout.drop_down, null)!;
            var editText = view.EditText;
            
            editText.Text = Element.SelectedIndex < 0
                ? ""
                : Element.Items[Element.SelectedIndex];
            editText.ShowSoftInputOnFocus = false;
            view.Hint = Element.Placeholder;
            editText.FocusChange += EditText_FocusChange;

            return view;
        }

        protected override void Dispose(bool disposing)
        {
            if (Control == null)
            {
                return;
            }

            Control.EditText.FocusChange -= EditText_FocusChange;
            base.Dispose(disposing);
        }

        private void EditText_FocusChange(object sender, FocusChangeEventArgs e)
        {
            if (e.HasFocus)
            {
                ShowDialog();    
            }
        }

        private void ShowDialog()
        {
            NumberPicker picker = new(_context);
            picker.SetDisplayedValues(Element.Items.ToArray());
            picker.MinValue = 0;
            picker.MaxValue = Element.Items.Count - 1;
            if (Element.SelectedIndex >= 0)
            {
                picker.Value = Element.SelectedIndex;
            }

            MaterialAlertDialogBuilder builder = new(_context);
            builder
                .SetView(picker)
                .SetPositiveButton("OK", (s, e) =>
                {
                    Element.SelectedIndex = picker.Value;
                    Control.EditText.Text = Element.Items[picker.Value];
                })
                .SetNegativeButton("Cancel", (_, _) => {})
                .SetOnDismissListener(this);
            builder.Create().Show();
        }

        public void OnDismiss(IDialogInterface? dialog)
        {
            Control.RootView?.RequestFocus();
        }
    }
}
