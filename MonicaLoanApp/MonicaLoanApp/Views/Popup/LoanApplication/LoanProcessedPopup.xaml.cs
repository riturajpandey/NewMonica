using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace MonicaLoanApp.Views.Popup.LoanApplication
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoanProcessedPopup : PopupPage
    {
        public event EventHandler DialogClosed;
        public event EventHandler DialogShow;
        public event EventHandler DialogClosing;
        public event EventHandler DialogShowing;
        public LoanProcessedPopup()
        {
            InitializeComponent();
            
            PopUpBgLayout.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(HideDialog)
            });
        }
        private void ShowDialogAnimation(Xamarin.Forms.VisualElement dialog, Xamarin.Forms.VisualElement bg)
        {
            dialog.TranslationY = bg.Height;
            bg.IsVisible = true;
            dialog.IsVisible = true;

            ////ANIMATIONS 
            var showBgAnimation = OpacityAnimation(bg, 0, 0.5);
            var showDialogAnimation = TransLateYAnimation(dialog, bg.Height, 0);

            ////EXECUTE ANIMATIONS
            this.Animate("showBg", showBgAnimation, 16, 200, Easing.Linear, (d, f) => { });
            this.Animate("showMenu", showDialogAnimation, 16, 200, Easing.Linear, (d, f) =>
            {
                OnDialogShow(new EventArgs());
            });

            OnDialogShowing(new EventArgs());
        }
        private async void HideDialogAnimation(Xamarin.Forms.VisualElement dialog, Xamarin.Forms.VisualElement bg)
        {
            //ANIMATIONS     
            var hideBgAnimation = OpacityAnimation(bg, 0.5, 0);
            var showDialogAnimation = TransLateYAnimation(dialog, 0, bg.Height);

            ////EXECUTE ANIMATIONS
            this.Animate("hideBg", hideBgAnimation, 16, 200, Easing.Linear, (d, f) => { });
            this.Animate("hideMenu", showDialogAnimation, 16, 200, Easing.Linear, (d, f) =>
            {
                bg.IsVisible = false;
                dialog.IsVisible = false;
                dialog.TranslationY = PopUpBgLayout.Height;

                OnDialogClosing(new EventArgs());
            });
            await Navigation.PopAllPopupAsync(true);

            OnDialogClosing(new EventArgs());
        }
        public void ShowDialog()
        {
            ShowDialogAnimation(PopUpDialogLayout, PopUpBgLayout);
        }
        public void HideDialog()
        {
            HideDialogAnimation(PopUpDialogLayout, PopUpBgLayout);
        }
        protected virtual void OnDialogClosed(EventArgs e)
        {
            DialogClosed?.Invoke(this, e);
        }
        protected virtual void OnDialogShow(EventArgs e)
        {
            DialogShow?.Invoke(this, e);
        }
        protected virtual void OnDialogClosing(EventArgs e)
        {
            DialogClosing?.Invoke(this, e);
        }
        protected virtual void OnDialogShowing(EventArgs e)
        {
            DialogShowing?.Invoke(this, e);
        }
        private static Animation TransLateYAnimation(Xamarin.Forms.VisualElement element, double from, double to)
        {
            return new Animation(d => { element.TranslationY = d; }, from, to);
        }
        private static Animation TransLateXAnimation(Xamarin.Forms.VisualElement element, double from, double to)
        {
            return new Animation(d => { element.TranslationX = d; }, from, to);
        }
        private static Animation OpacityAnimation(Xamarin.Forms.VisualElement element, double from, double to)
        {
            return new Animation(d => { element.Opacity = d; }, from, to);
        }
    }
}