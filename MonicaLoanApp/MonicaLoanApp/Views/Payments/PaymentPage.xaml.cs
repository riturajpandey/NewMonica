using MonicaLoanApp.ViewModels.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace MonicaLoanApp.Views.Payments
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaymentPage : ContentPage
    {
        //TODO: To define class level variable..
        protected PaymentPageVM PaymentVM;

        #region Constructor
        public PaymentPage()
        {
            InitializeComponent();
            // iOS Platform
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
            PaymentVM = new PaymentPageVM(this.Navigation);
            this.BindingContext = PaymentVM;
        }
        #endregion

        protected override void OnAppearing()
        {
            base.OnAppearing();
            PaymentVM.TapCount = 0;
            PaymentVM.TapCount1 = 0;
            PaymentVM.IsPageEnable = true;
        }
    }
}