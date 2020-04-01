using Acr.UserDialogs;
using MonicaLoanApp.Models.Loan;
using MonicaLoanApp.ViewModels.Payments;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace MonicaLoanApp.Views.Payments
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MakePaymentPage : ContentPage
    {//TODO: To define class level variable
        protected MakePaymentPageVM MakePaymentVM;

        #region Constructor
        public MakePaymentPage()
        {
            InitializeComponent();
            // iOS Platform
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
            Xamarin.Forms.Application.Current.On<Xamarin.Forms.PlatformConfiguration.Android>().UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Resize);
            MakePaymentVM = new MakePaymentPageVM(this.Navigation);
            this.BindingContext = MakePaymentVM;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            Helpers.Constants.PageCount = 0;
            await MakePaymentVM.GetAllLoans();

            MakePaymentVM.Name = Helpers.Constants.UserFirstname + " " + Helpers.Constants.UserLastname;
            MakePaymentVM.Bank = Helpers.Constants.UserBankname;
            MakePaymentVM.AccountNumber = Helpers.Constants.UserBankaccountno;
            MakePaymentVM.Reference = Helpers.Constants.UserBankcode;
        }
        #endregion

        #region Methods
        private void PckSchedule_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PckSchedule.SelectedIndex >= 0)
            {
                var schedule = PckSchedule.SelectedItem as Schedule;
                MakePaymentVM.LoanSchedule = PckSchedule.Items[PckSchedule.SelectedIndex];
            }
        }

        private void GrdLoan_Tapped(object sender, EventArgs e)
        {
            PckLoan.Focus();
        }

        private void GrdSchedule_Tapped(object sender, EventArgs e)
        {
            if (MakePaymentVM.LoanNumber == "Select loan")
            {
                UserDialogs.Instance.Alert("Please select loan.", "", "Ok");
                return;
            }
            else
            {
                PckSchedule.Focus();
            }
        }

        private async void PckLoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PckLoan.SelectedIndex >= 0)
            {
                var loan = PckLoan.SelectedItem as AllLoan;
                MakePaymentVM.LoanNumber = loan.loannumber;
                MakePaymentVM.LoanAmount = loan.loanamount;
                // MakePaymentVM.LoanPurpose = PckLoan.Items[PckLoan.SelectedIndex];
                await MakePaymentVM.GetLoans();
            }
        }

        private void GrdTabCard_Tapped(object sender, EventArgs e)
        {
            TabBank.BackgroundColor = (Color)App.Current.Resources["AppWhiteColor"];
            TabBank.BorderColor = Color.Gray;
            TabCard.BackgroundColor = (Color)App.Current.Resources["LargeLblColor"];
            TabCard.BorderColor = (Color)App.Current.Resources["LargeLblColor"];

            LblBank.TextColor = Color.Gray;
            LblCard.TextColor = (Color)App.Current.Resources["AppWhiteColor"];

            GrdPayWithCard.IsVisible = true;
            GrdPayByBank.IsVisible = false;
        }

        private void GrdTabBank_Tapped(object sender, EventArgs e)
        {
            TabBank.BackgroundColor = (Color)App.Current.Resources["LargeLblColor"];
            TabBank.BorderColor = (Color)App.Current.Resources["LargeLblColor"];
            TabCard.BackgroundColor = (Color)App.Current.Resources["AppWhiteColor"];
            TabCard.BorderColor = Color.Gray;

            LblBank.TextColor = (Color)App.Current.Resources["AppWhiteColor"];
            LblCard.TextColor = Color.Gray;

            GrdPayByBank.IsVisible = true;
            GrdPayWithCard.IsVisible = false;

        }

        ///// <summary>
        ///// If User Click On Date Of Birth Picker
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void DtPckDOB_Tapped(object sender, EventArgs e)
        //{
        //    DtPckDOB.Focus();
        //}
        ///// <summary>
        ///// If User Click On Date Of Birth Picker
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private async void DtPckDOB_DateSelected(object sender, DateChangedEventArgs e)
        //{
        //    MakePaymentVM.DateOfBirth = DtPckDOB.Date.ToString("dd MMMM yyyy");

        //}
        ///// <summary>
        ///// If User Click On Date Of Birth Picker
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private async void DtPckDOB_Unfocused(object sender, FocusEventArgs e)
        //{
        //    if (DtPckDOB.Date != null)
        //    {
        //        MakePaymentVM.DateOfBirth = DtPckDOB.Date.ToString("dd MMMM yyyy");

        //    }
        //}
        #endregion 
    }
}