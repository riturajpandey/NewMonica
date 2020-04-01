using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreGraphics;
using Foundation;
using MonicaLoanApp.Controls;
using MonicaLoanApp.iOS.Renders;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomFrameForOpacity), typeof(CustomFrameForOpacityRenderer))]
namespace MonicaLoanApp.iOS.Renders
{
    public class CustomFrameForOpacityRenderer : FrameRenderer
    {
        #region Override Method For Give More Shadow Of Frame
        public override void Draw(CGRect rect)
        {
            base.Draw(rect);
            var materialFrame = (CustomFrameForOpacity)Element;
            // Update shadow to match better material design standards of elevation
            //Layer.ShadowRadius = 20.0f;
            Layer.ShadowColor = UIColor.Gray.CGColor;
            Layer.ShadowOffset = new CGSize(2, 2);
            Layer.ShadowOpacity = 0.30f;
            Layer.ShadowPath = UIBezierPath.FromRect(Layer.Bounds).CGPath;
            Layer.MasksToBounds = true;
        }
        #endregion
    }
}