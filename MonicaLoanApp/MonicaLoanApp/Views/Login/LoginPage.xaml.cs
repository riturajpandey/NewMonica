using Acr.UserDialogs;
using MonicaLoanApp.Interfaces;
using MonicaLoanApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace MonicaLoanApp.Views.Login 
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    { 
        //TODO : To Define class Level Variables...
        protected LoginPageVM LoginVm; 

        #region Constructor
        public LoginPage(string email)
        {
            InitializeComponent();
            Xamarin.Forms.Application.Current.On<Xamarin.Forms.PlatformConfiguration.Android>().UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Resize);
            // iOS Platform
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
            LoginVm = new LoginPageVM(this.Navigation);
            this.BindingContext = LoginVm;

            if(!string.IsNullOrEmpty(email))
            {
                LoginVm.Email = email;
            } 
        }
        #endregion

        #region Event Hanlders

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoginVm.IsPageEnable = true;
            LoginVm.TapCount = 0;
            LoginVm.TapCount1 = 0;
            Helpers.Constants.IsVerifyToken = false;
        }

        //TODO : To Define Device Back Button Tapped Event...
        protected override bool OnBackButtonPressed()
        {
            CloseApp();
            return true;
        }

        //TODO : To Define Close App Event...
        public async void CloseApp()
        {
            var res = await UserDialogs.Instance.ConfirmAsync("Are you sure you want to exit the app?", null, "No", "Yes");
            var text = (res ? "No" : "Yes");
            if (text == "Yes")
            {
                DependencyService.Get<ICloseAppService>().CloseApp();
            }
        }
        #endregion
    }
}