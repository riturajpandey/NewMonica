using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using MonicaLoanApp.Controls;
using MonicaLoanApp.iOS.Renders;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomUnderLinedLAbel), typeof(CustomUnderLinedLabelRenderer))]
namespace MonicaLoanApp.iOS.Renders
{
    public class CustomUnderLinedLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            if (this.Control != null)
            {
                if (e.NewElement != null)
                {
                    var label = (CustomUnderLinedLAbel)this.Element;
                    this.Control.AttributedText = new NSAttributedString(label.Text, underlineStyle: NSUnderlineStyle.Single);
                }
            }
        }
    }
}