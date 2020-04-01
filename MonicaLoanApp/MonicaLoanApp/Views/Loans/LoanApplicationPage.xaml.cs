using Acr.UserDialogs;
using MonicaLoanApp.Models;
using MonicaLoanApp.Models.Loan;
using MonicaLoanApp.ViewModels.Loans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xam.Plugin;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace MonicaLoanApp.Views.Loans
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoanApplicationPage : ContentPage
    {
        //TODO : To Define class Level Variables...
        protected LoanApplicationPageVM LoanApplicationVM;
        public PopupMenu Popup;
        AllLoan AllLoanDetails;

        #region Constructor
        public LoanApplicationPage(AllLoan allLoan) 
        {
            InitializeComponent();
            // iOS Platform
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
            LoanApplicationVM = new LoanApplicationPageVM(this.Navigation); 
            this.BindingContext = LoanApplicationVM;
            AllLoanDetails = allLoan; 
        }

        /// <summary> 
        /// TODO : To Define OnAppearing Event...
        /// </summary>
        protected async override void OnAppearing()
        {
            base.OnAppearing(); 
            await LoanApplicationVM.GetLoanDetail(AllLoanDetails);
            await LoanApplicationVM.StaticDataSearch(); 
        }
        #endregion

        //TODO : To Define Menu Dot Tapped Event...
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Popup = new PopupMenu()
            {
                BindingContext = LoanApplicationVM.ContextMenu,
            };

            //Popup.SetBinding(PopupMenu.ItemsSourceProperty, "ContextMenu");
            Popup.ItemsSource = LoanApplicationVM.ContextMenu;
            Popup.ShowPopup(sender as Image);  
            Popup.OnItemSelected += popup_onitemselected;  
        }

        private async void popup_onitemselected(string item)
        {
            if (item == "Accept")
            {
                var res = await UserDialogs.Instance.ConfirmAsync("Are you sure you want to accept loan.", null, "No", "Yes");
                var text = (res ? "No" : "Yes");
                if (text == "Yes")
                {
                    LoanApplicationVM.Action = "A";
                    await LoanApplicationVM.LoanRespond(AllLoanDetails); 
                }
            }
            if (item == "Decline")
            {
                PckDeclineReason.IsVisible = true; 
                PckDeclineReason.Focus();
            }
        }

        private async void PckDeclineReason_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PckDeclineReason.SelectedIndex >= 0)
            {
                var declinereason = PckDeclineReason.SelectedItem as Staticdata;
                LoanApplicationVM.DeclineReasonCode = declinereason.key;
                LoanApplicationVM.Action = "D";
                await LoanApplicationVM.LoanRespond(AllLoanDetails);
            }
        }
    }
}