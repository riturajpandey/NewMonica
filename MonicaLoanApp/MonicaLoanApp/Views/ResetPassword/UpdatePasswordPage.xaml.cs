using MonicaLoanApp.ViewModels.ResetPassword;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace MonicaLoanApp.Views.ResetPassword
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdatePasswordPage : ContentPage
    {
        protected UpdatePasswordPageVm NewPasswordVM;
        int countdown = 60;

        #region Constructor
        public UpdatePasswordPage(string Email)
        {
            InitializeComponent();
            Xamarin.Forms.Application.Current.On<Xamarin.Forms.PlatformConfiguration.Android>().UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Resize);
            // iOS Platform
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
            NewPasswordVM = new UpdatePasswordPageVm(this.Navigation, Email);
            this.BindingContext = NewPasswordVM;


            LblCountDown.Text = countdown.ToString() + " Seconds";

            //To restart countdown...
            MessagingCenter.Subscribe<string>(this, "StartCountDown", (sender) =>
            {
                LblCountDown.Text = countdown.ToString() + " Seconds";
                GrdCountDown.IsVisible = true;
                GrdResendLink.IsVisible = false;

                Device.StartTimer(TimeSpan.FromMilliseconds(1000), () =>
                {
                    bool IsRepeat = true;
                    countdown = countdown - 1;
                    LblCountDown.Text = countdown.ToString() + " Seconds";

                    if (countdown == 0)
                    {
                        IsRepeat = false;
                        countdown = 60;
                        GrdCountDown.IsVisible = false;
                        GrdResendLink.IsVisible = true;
                    }
                    return IsRepeat;
                });
            });
        }

        #region Event Handler

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            Device.StartTimer(TimeSpan.FromMilliseconds(1000), () =>
            {
                bool IsRepeat = true;
                countdown = countdown - 1;
                LblCountDown.Text = countdown.ToString() + " Seconds";

                if (countdown == 0)
                {
                    IsRepeat = false;
                    countdown = 60;
                    GrdCountDown.IsVisible = false;
                    GrdResendLink.IsVisible = true;
                }
                return IsRepeat;
            });
        }
        #endregion
        #endregion 
    }
}