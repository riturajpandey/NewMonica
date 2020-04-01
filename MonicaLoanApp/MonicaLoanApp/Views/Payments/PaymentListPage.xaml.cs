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
    public partial class PaymentListPage : ContentPage
    {
        /// <summary>
        /// TODO: To define Class level variable.....
        /// </summary>
        protected PaymentPageVM PaymentVM;
        

        #region Constructor
        public PaymentListPage() 
        {
            InitializeComponent();
            // iOS Platform
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
            PaymentVM = new PaymentPageVM(this.Navigation);
            this.BindingContext = PaymentVM; 
        }
        #endregion

        protected async override void OnAppearing() 
        {
            base.OnAppearing();
            PaymentVM.TapCount = 0;
            PaymentVM.TapCount1 = 0;
            PaymentVM.IsPageEnable = true;
            await PaymentVM.GetAllPayments();
        }
    }
}