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
    public partial class ResetEmailPage : ContentPage
    {
        //TODO : To Define class Level Variables...
        protected EmailResetPageVM EmailResetVM;

        #region COnstructor
        public ResetEmailPage()
        {
            InitializeComponent();
            Xamarin.Forms.Application.Current.On<Xamarin.Forms.PlatformConfiguration.Android>().UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Resize);
            EmailResetVM = new EmailResetPageVM(this.Navigation);
            this.BindingContext = EmailResetVM;
            // iOS Platform
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
        }
        #endregion

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Helpers.Constants.PageCount = 0;
        }

        //private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        //{
        //    Navigation.PopModalAsync();
        //}
    }
}