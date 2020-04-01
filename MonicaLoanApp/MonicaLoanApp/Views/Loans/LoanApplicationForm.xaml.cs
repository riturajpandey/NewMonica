using MonicaLoanApp.Models;
using MonicaLoanApp.ViewModels.Loans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace MonicaLoanApp.Views.Loans
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoanApplicationForm : ContentPage
    {
        //TODO: To define class level variable
        protected LoanApplicationFormVM LoanApplication_Form;

        #region Constructor
        public LoanApplicationForm()
        {
            InitializeComponent();
            Xamarin.Forms.Application.Current.On<Xamarin.Forms.PlatformConfiguration.Android>().UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Resize);
            // iOS Platform
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
            LoanApplication_Form = new LoanApplicationFormVM(this.Navigation);
            this.BindingContext = LoanApplication_Form;
        }
        #endregion

        #region EventHandler
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            Helpers.Constants.PageCount = 0; 
            await LoanApplication_Form.StaticDataSearch();
        }
        #endregion

        #region Methods
        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            PckEmployee.Focus();
        }
        /// <summary>
        /// If User Click On Date Of Birth Picker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DtPckDOB_Tapped(object sender, EventArgs e)
        {
            DtPckDOB.Focus();
        }
        /// <summary>
        /// If User Click On Date Of Birth Picker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void DtPckDOB_DateSelected(object sender, DateChangedEventArgs e)
        {
            try
            {
                if (DtPckDOB.Date != null)
                {
                    var date = DtPckDOB.Date.ToString("dd/MM/yyyy");
                    var DateBirth = date.Replace("-", "/");
                    LoanApplication_Form.DateOfBirth = DateBirth;
                }

            }
            catch (Exception ex)
            { }
        }
        /// <summary>
        /// If User Click On Date Of Birth Picker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void DtPckDOB_Unfocused(object sender, FocusEventArgs e)
        {
            try
            {
                if (DtPckDOB.Date != null)
                {
                    // RegisterOneVM.DateOfBirth = DtPckDOB.Date.ToString("MM/dd/yyyy");
                    var date = DtPckDOB.Date.ToString("dd/MM/yyyy");
                    var DateBirth = date.Replace("-", "/");
                    LoanApplication_Form.DateOfBirth = DateBirth;
                }
            }
            catch (Exception ex)
            { }
        }

        private void Purpose_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PckPurpose.SelectedIndex >= 0)
            {
                var purposecode = PckPurpose.SelectedItem as Staticdata;
                LoanApplication_Form.PurposeCode = purposecode.key;
                LoanApplication_Form.SelectPurpose = PckPurpose.Items[PckPurpose.SelectedIndex]; 
            }

        }
        private void Repayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PckRepayment.SelectedIndex >= 0)
            {
                string repaymenttype = PckRepayment.Items[PckRepayment.SelectedIndex];
                PckRepayment.SelectedItem = repaymenttype;
                LoanApplication_Form.RepaymentType = repaymenttype;
                //LoanApplication_Form.RepaymentType = PckRepayment.Items[PckRepayment.SelectedIndex];
            }
        }
        private void Employee_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PckEmployee.SelectedIndex >= 0)
            {
                var EmployerCode = PckEmployee.SelectedItem as Staticdata;
                LoanApplication_Form.EmployerCode = EmployerCode.key;
                LoanApplication_Form.Employer = PckEmployee.Items[PckEmployee.SelectedIndex];
            }
        }

        private void pckWeeks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pckWeeks.SelectedIndex >= 0)
            {
                LoanApplication_Form.LoanDuration = pckWeeks.Items[pckWeeks.SelectedIndex];
            }
        }

        private void GrdSelectPurpose_Tapped(object sender, EventArgs e)
        {
            PckPurpose.Focus();
        }
        #endregion 
    }
}