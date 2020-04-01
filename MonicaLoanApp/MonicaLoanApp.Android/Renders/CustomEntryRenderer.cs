using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MonicaLoanApp.Controls;
using MonicaLoanApp.Droid.Renders;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace MonicaLoanApp.Droid.Renders
{
    class CustomEntryRenderer : EntryRenderer
    {
        #region Constructor
        public CustomEntryRenderer(Context context) : base(context)
        {

        }
        #endregion

        #region Overrides Methods
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Entry> e)
        {
            base.OnElementChanged(e);
            this.Control.SetSelectAllOnFocus(true);
            if (Control != null)
            {
                var entry = (EditText)Control;
                entry.Background = null;
                Control.SetBackgroundColor(global::Android.Graphics.Color.Transparent);
                Element.BackgroundColor = Color.Transparent;
            }
        }
        #endregion
    }
}