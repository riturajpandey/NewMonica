using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MonicaLoanApp.Controls;
using MonicaLoanApp.Droid.Renders;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomUnderLinedLAbel), typeof(CustomUnderLinedLabelRenderer))]
namespace MonicaLoanApp.Droid.Renders
{
    public class CustomUnderLinedLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            if (this.Control != null)
            {
                Control.PaintFlags = PaintFlags.UnderlineText; 
            }
        }
    }
}