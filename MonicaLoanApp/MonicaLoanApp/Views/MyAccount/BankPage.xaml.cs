using MonicaLoanApp.Models;
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
    public partial class BankPage : ContentPage
    {
        //TODO: To define class level variable...
        protected BankPageVM BankVM;

        #region Constructor
        public BankPage()
        {
            InitializeComponent();
            Xamarin.Forms.Application.Current.On<Xamarin.Forms.PlatformConfiguration.Android>().UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Resize);
            // iOS Platform
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
            BankVM = new BankPageVM(this.Navigation);
            this.BindingContext = BankVM;
        }
        #endregion
        #region EventHandler
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            Helpers.Constants.PageCount = 0;
            await BankVM.StaticDataSearch();

            BankVM.Bankcode = Helpers.Constants.UserBankcode;
            BankVM.BankName = Helpers.Constants.UserBankname;
            BankVM.BankAccountNumber = Helpers.Constants.UserBankaccountno;
            BankVM.EnterBVN = Helpers.Constants.UserBvn; 

            if (!string.IsNullOrEmpty(Helpers.Constants.UserBankname))
            {
                var item = BankVM.Banklist.Where(a => a.data == Helpers.Constants.UserBankname).FirstOrDefault();
                var index = BankVM.Banklist.IndexOf(item);
                PckBankfrst.SelectedIndex = index;  
            }
        }
        #endregion

        private void PckSelectbankCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PckBankfrst.SelectedIndex >= 0)
            {
                var bank = PckBankfrst.SelectedItem as Staticdata;
                BankVM.BankName = PckBankfrst.Items[PckBankfrst.SelectedIndex];
                BankVM.Bankcode = bank.key; 
            }
        }
    }
}