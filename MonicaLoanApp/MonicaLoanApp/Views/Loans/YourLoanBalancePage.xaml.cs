using MonicaLoanApp.ViewModels.Loans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace MonicaLoanApp.Views.Loans
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class YourLoanBalancePage : ContentPage
    {
        //Define Properties Here...
        protected YourLoanBalancePageVM YourLoanBalancePagevm;

        #region Constructor
        public YourLoanBalancePage()
        {
            InitializeComponent();
            // iOS Platform
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
            YourLoanBalancePagevm = new YourLoanBalancePageVM(this.Navigation);
            BindingContext = YourLoanBalancePagevm;
        }
        #endregion
        #region EventHandler
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            YourLoanBalancePagevm.TapCount1 = 0;
            YourLoanBalancePagevm.TapCount2 = 0;
            Helpers.Constants.PageCount = 0;
            await YourLoanBalancePagevm.GetProfile();
            //YourLoanBalancePagevm.LoanAmount = "N"+ Helpers.Constants.UserLoanbalance;
            //YourLoanBalancePagevm.DueAmount = "N"+ Helpers.Constants.UserDuebalance;
            YourLoanBalancePagevm.LoanAmount = String.Format("{0:n0}", Convert.ToInt32(Helpers.Constants.UserLoanbalance));
            YourLoanBalancePagevm.DueAmount = String.Format("{0:n0}", Convert.ToInt32(Helpers.Constants.UserDuebalance));
        }
        #endregion 
    }
}