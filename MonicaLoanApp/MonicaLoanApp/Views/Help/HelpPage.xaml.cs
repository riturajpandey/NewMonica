using MonicaLoanApp.Models;
using MonicaLoanApp.Models.Help;
using MonicaLoanApp.ViewModels.Help;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace MonicaLoanApp.Views.Help
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HelpPage : ContentPage
    {
        //TODO: To define Class level variable...
        protected HelpPageVM HelpVM;
        int TapCount = 0;
        #region Constructor
        public HelpPage()
        {
            InitializeComponent();
            // iOS Platform
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
            HelpVM = new HelpPageVM(this.Navigation);
            this.BindingContext = HelpVM;
        }
        #endregion

        #region Methods
        /// <summary>
        /// TODO: To list tapped event open LoanDetail page..
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void LoanDetail_Tapped(object sender, EventArgs e)
        {
            if (TapCount == 0)
            {
                TapCount++;
                var item = (sender as Grid).BindingContext as Staticdata;
                if (item != null)
                    await Navigation.PushModalAsync(new Views.Help.DebitCardQueries(item));
            }
        }
        #endregion

        #region EventHandler
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            TapCount = 0; 
            Helpers.Constants.PageCount = 0;
            await HelpVM.StaticDataSearch();
        }
        #endregion

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            lvQuerylist.ItemsSource = HelpVM.FaqList.Where(x => x.key.ToLower().Contains(e.NewTextValue.ToLower())).ToList();
        }
    }
}