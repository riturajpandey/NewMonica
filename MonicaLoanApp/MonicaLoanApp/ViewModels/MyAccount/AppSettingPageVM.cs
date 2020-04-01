using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MonicaLoanApp.ViewModels.MyAccount
{
    public class AppSettingPageVM : BaseViewModel
    {
        #region Constructor
        public AppSettingPageVM(INavigation nav)
        {
            Navigation = nav;
            BackCommand = new Command(BackCommandAsync); 
        }
        #endregion

        #region Properties
        #endregion

        #region Command 
        public Command BackCommand { get; set; }
        #endregion

        #region Method
        /// <summary>
        /// To Define Back Button Event...
        /// </summary>
        /// <param name="obj"></param>
        private async void BackCommandAsync(object obj)
        {
            App.masterDetailPage.IsPresented = false;
            App.masterDetailPage.Detail = new Xamarin.Forms.NavigationPage(new Views.MyAccount.MyAccountPage());
            App.Current.MainPage = App.masterDetailPage;
            App.masterDetailPage.IsPresented = false;
            //App.Current.MainPage = new Views.MyAccount.MyAccountPage();
        }
        #endregion
    }
}
