using Android.Content;
using Android.Views;

namespace AndroidPickerSandbox.Android
{
    internal class MaterialComponentsContextThemeWrapper : ContextThemeWrapper
    {
        private MaterialComponentsContextThemeWrapper(Context context) : base(context, Resource.Style.MaterialTheme)
        {
        }

        public static MaterialComponentsContextThemeWrapper Create(Context context)
        {
            if (context is MaterialComponentsContextThemeWrapper tmp)
                return tmp;
            return new(context);
        }
    }
}
