﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using MonicaLoanApp.Controls;
using MonicaLoanApp.iOS.Renders;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomBorderlessDatePicker), typeof(CustomBorderlessDatePickerRenderer))]
namespace MonicaLoanApp.iOS.Renders
{
    public class CustomBorderlessDatePickerRenderer : DatePickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
        {
            base.OnElementChanged(e);
            if (this.Control == null)
                return;
            Control.Layer.BorderColor = UIColor.Black.CGColor;
        }
    }
}