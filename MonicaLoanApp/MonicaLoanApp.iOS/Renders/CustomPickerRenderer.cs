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

[assembly: ExportRenderer(typeof(CustomPicker), typeof(CustomPickerRenderer))]
namespace MonicaLoanApp.iOS.Renders
{
    public class CustomPickerRenderer : PickerRenderer
    {
        #region Overrides Methods
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            try
            {
                Control.Layer.BorderWidth = 0;
                Control.BorderStyle = UITextBorderStyle.None;
                Control.BackgroundColor = UIKit.UIColor.White;
            }
            catch (Exception ex)
            {

            }
        }
        #endregion
    }
}