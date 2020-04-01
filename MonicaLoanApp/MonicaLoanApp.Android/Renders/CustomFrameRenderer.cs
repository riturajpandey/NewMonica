using Android.Content;
using MonicaLoanApp.Controls;
using MonicaLoanApp.Droid.Renders;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Graphics.Drawables;
using FrameRenderer = Xamarin.Forms.Platform.Android.AppCompat.FrameRenderer;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(CustomFrame), typeof(CustomFrameRenderer))]

namespace MonicaLoanApp.Droid.Renders
{
    public class CustomFrameRenderer : FrameRenderer
    {
        #region Constructor
        public CustomFrameRenderer(Context context) : base(context)
        {

        }
        #endregion

        #region Overrides Methods
        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null && Control != null)
            {
                UpdateCornerRadius();
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == nameof(CustomFrame.CornerRadius) ||
               e.PropertyName == nameof(CustomFrame))
            {
                UpdateCornerRadius();
            }
        }

        private void UpdateCornerRadius()
        {
            if (Control.Background is GradientDrawable backgroundGradient)
            {
                var cornerRadius = (Element as CustomFrame)?.CornerRadius;
                if (!cornerRadius.HasValue)
                {
                    return;
                }

                var topLeftCorner = Context.ToPixels(cornerRadius.Value.TopLeft);
                var topRightCorner = Context.ToPixels(cornerRadius.Value.TopRight);
                var bottomLeftCorner = Context.ToPixels(cornerRadius.Value.BottomLeft);
                var bottomRightCorner = Context.ToPixels(cornerRadius.Value.BottomRight);

                var cornerRadii = new[]
                {
                    topLeftCorner,
                    topLeftCorner,

                    topRightCorner,
                    topRightCorner,

                    bottomRightCorner,
                    bottomRightCorner,

                    bottomLeftCorner,
                    bottomLeftCorner,
                };

                backgroundGradient.SetCornerRadii(cornerRadii);
            }
        }
        #endregion
    }
}