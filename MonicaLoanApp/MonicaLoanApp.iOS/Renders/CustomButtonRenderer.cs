using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using MonicaLoanApp.iOS.Renders;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Button), typeof(CustomButtonRenderer))]
namespace MonicaLoanApp.iOS.Renders
{
    public class CustomButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                var btn = (UIButton)Control;
            }
        }
    }
}