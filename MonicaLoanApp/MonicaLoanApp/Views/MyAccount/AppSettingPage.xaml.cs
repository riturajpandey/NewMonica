using MonicaLoanApp.ViewModels.MyAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace MonicaLoanApp.Views.MyAccount
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppSettingPage : ContentPage
    {
        /// <summary>
        /// TODO: To define class level variable.
        /// </summary>
        protected AppSettingPageVM AppSettingVM;

        #region Constructor
        public AppSettingPage()
        {
            InitializeComponent();
            // iOS Platform
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
            AppSettingVM = new AppSettingPageVM(this.Navigation);
            this.BindingContext = AppSettingVM;    
        }
        #endregion 

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}