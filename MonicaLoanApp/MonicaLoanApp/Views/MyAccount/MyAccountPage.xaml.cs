using MonicaLoanApp.ViewModels.MyAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace MonicaLoanApp.Views.MyAccount
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyAccountPage : ContentPage
    {
        protected MyAccountPageVM MyAccountVM;
        #region Constructor
        public MyAccountPage()
        {
            InitializeComponent();
            Xamarin.Forms.Application.Current.On<Xamarin.Forms.PlatformConfiguration.Android>().UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Resize);
            // iOS Platform
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
            MyAccountVM = new MyAccountPageVM(this.Navigation);
            this.BindingContext = MyAccountVM;
        }
        #endregion
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            MyAccountVM.TapCount = 0; 
            MyAccountVM.TapCount1 = 0; 
            MyAccountVM.TapCount2 = 0; 
            MyAccountVM.TapCount3 = 0; 
            MyAccountVM.TapCount4 = 0; 
            MyAccountVM.IsPageEnable = true; 
            MyAccountVM.PersonalDetails = Helpers.Constants.UserFirstname + " " + Helpers.Constants.UserLastname;
            MyAccountVM.Address = Helpers.Constants.UserAddressline1 + "," + Helpers.Constants.UserAddressline2 + "" + Helpers.Constants.UserCity;
            MyAccountVM.Employement = Helpers.Constants.UserFirstname + " " + Helpers.Constants.UserLastname;
            MyAccountVM.BankDetails = Helpers.Constants.UserBankname + " " + Helpers.Constants.UserBankaccountno;
        }
    }
}