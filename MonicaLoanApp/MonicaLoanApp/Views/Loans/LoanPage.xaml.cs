using MonicaLoanApp.ViewModels.Loans;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace MonicaLoanApp.Views.Loans
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoanPage : ContentPage
    {
        //TODO : To Define class Level Variables...
        protected LoanPageVM LoanVM;

        #region Constructor
        public LoanPage()
        {
            InitializeComponent();
            // iOS Platform
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
            LoanVM = new LoanPageVM(this.Navigation);
            this.BindingContext = LoanVM;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoanVM.TapCount = 0; 
        }
        #endregion
    }
}