﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Foundation;
using MonicaLoanApp.Controls;
using MonicaLoanApp.iOS.Renders;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace MonicaLoanApp.iOS.Renders
{
    public class CustomEntryRenderer : EntryRenderer
    {
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (Control != null)
            {
                Control.BorderStyle = UITextBorderStyle.None;
                Control.TintColor = UIColor.Black;
                //  Control.Layer.CornerRadius = 10;
                //   Control.TextColor = UIColor.White;
            }
        }
    }
}