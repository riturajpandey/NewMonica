using MonicaLoanApp.ViewModels.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace MonicaLoanApp.Views.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        //TODO : To Define Class Level Variables...
        private MenuPageVM MenuVM;

        #region Constructor
        public MenuPage()
        {
            InitializeComponent();
            // iOS Platform
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
            Xamarin.Forms.NavigationPage.SetHasNavigationBar(this, false);
            MenuVM = new MenuPageVM(this.Navigation); 
            this.BindingContext = MenuVM;
        }
        #endregion

        #region EventHandler
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await MenuVM.GetProfile();
            MenuVM.UserName= Helpers.Constants.UserFirstname;
            MenuVM.UserNumber= Helpers.Constants.ProfileNumber;
        }
        #endregion
    }
}