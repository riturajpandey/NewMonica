using MonicaLoanApp.ViewModels.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace MonicaLoanApp.Views.Register
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConfirmRegistrationPage : ContentPage
    {
        protected ConfirmRegistrationVM ConfrmRegistrationvm;
        int countdown = 60; 

        public ConfirmRegistrationPage(string email)
        {
            InitializeComponent();
            ConfrmRegistrationvm = new ConfirmRegistrationVM(this.Navigation, email);
            this.BindingContext = ConfrmRegistrationvm;

            LblCountDown.Text = countdown.ToString() + " Seconds";
            // iOS Platform
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);

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
    }
}