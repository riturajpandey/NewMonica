using MonicaLoanApp.Views.Loans;
using MonicaLoanApp.Views.Menu;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MonicaLoanApp
{
    public partial class App : Application
    {
        //TODO : To Declare Global Variables.. 
        public static MasterDetailPage masterDetailPage = new MasterDetailPage();
        //TODO : To Define Global Varialbes Here....
        private static Autofac.IContainer _container;
        public App()
        {
            InitializeComponent();
            //To initialize Containers..
            AppSetup appSetup = new AppSetup();
            _container = appSetup.CreateContainer();

            if (Helpers.Settings.GeneralAccessToken == string.Empty)
            {
                MainPage = new MonicaLoanApp.Views.Login.LoginPage(null);
            }
            else
            {
                App.masterDetailPage.Master = new MenuPage();
                App.masterDetailPage.Detail = new NavigationPage(new YourLoanBalancePage());
                App.Current.MainPage = App.masterDetailPage;
            }

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
