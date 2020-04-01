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
    public partial class AddressPage : ContentPage
    {//TODO: To define class level variable..
        protected AddressPageVM AddressVM;
        public AddressPage()
        {
            InitializeComponent();
            Xamarin.Forms.Application.Current.On<Xamarin.Forms.PlatformConfiguration.Android>().UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Resize);
            // iOS Platform
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true); 
            AddressVM = new AddressPageVM(this.Navigation);
            this.BindingContext = AddressVM;
        }
        #region EventHandler
        /// <summary>
        /// To Define OnApperaing Event ...
        /// </summary>
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            Helpers.Constants.PageCount = 0;
            await AddressVM.StaticDataSearch();
            AddressVM.AddressOne = Helpers.Constants.UserAddressline1;
            AddressVM.AddressSecond = Helpers.Constants.UserAddressline2;
            AddressVM.City = Helpers.Constants.UserCity;
            AddressVM.State = Helpers.Constants.UserStateName;
            AddressVM.StateCode = Helpers.Constants.UserStatecode; 

            if (!string.IsNullOrEmpty(Helpers.Constants.UserStateName))
            {
                var item = AddressVM.Statelist.Where(a => a.data == Helpers.Constants.UserStateName).FirstOrDefault();
                var index = AddressVM.Statelist.IndexOf(item);
                pckstate.SelectedIndex = index;
            }
        }

        private void pckstate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pckstate.SelectedIndex >= 0)
            {
                var state = pckstate.SelectedItem as Staticdata;
                AddressVM.StateCode = state.key; 
                AddressVM.State = pckstate.Items[pckstate.SelectedIndex];
            } 
        }
        #endregion 
    }
}