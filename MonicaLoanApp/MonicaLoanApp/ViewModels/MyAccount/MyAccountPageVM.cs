using Acr.UserDialogs;
using MonicaLoanApp.Models;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MonicaLoanApp.ViewModels.MyAccount
{
    public class MyAccountPageVM : BaseViewModel
    {
        public int TapCount = 0;
        public int TapCount1 = 0;
        public int TapCount2 = 0;
        public int TapCount3 = 0;
        public int TapCount4 = 0;
        #region Constructor
        public MyAccountPageVM(INavigation nav)
        {
            Navigation = nav;
            MenuCommand = new Command(MenuCommandAsync);
            PersonalDetailsCommand = new Command(PersonalDetailsCommandAsync);
            AddressCommand = new Command(AddressCommandAsync);
            EmployementCommand = new Command(EmployementCommandAsync);
            BankDetailsCommand = new Command(BankDetailsCommandAsync);
            logoutCommand = new Command(logoutCommandAsync);
            AppSettingCommand = new Command(AppSettingCommandAsync);
        }
        #endregion

        #region Properties
        private bool _IsPageEnable = true;
        public bool IsPageEnable
        {
            get { return _IsPageEnable; }
            set
            {
                if (_IsPageEnable != value)
                {
                    _IsPageEnable = value;
                    OnPropertyChanged("IsPageEnable");
                }
            }
        }

        private string _PersonalDetails;
        public string PersonalDetails
        {
            get { return _PersonalDetails; }
            set
            {
                if (_PersonalDetails != value)
                {
                    _PersonalDetails = value;
                    OnPropertyChanged("PersonalDetails");
                }
            }
        }

        private string _Address;
        public string Address
        {
            get { return _Address; }
            set
            {
                if (_Address != value)
                {
                    _Address = value;
                    OnPropertyChanged("Address");
                }
            }
        }

        private string _Employement;
        public string Employement
        {
            get { return _Employement; }
            set
            {
                if (_Employement != value)
                {
                    _Employement = value;
                    OnPropertyChanged("Employement");
                }
            }
        }

        private string _BankDetails;
        public string BankDetails
        {
            get { return _BankDetails; }
            set
            {
                if (_BankDetails != value)
                {
                    _BankDetails = value;
                    OnPropertyChanged("BankDetails");
                }

            }
        }
        #endregion

        #region Commands
        public Command MenuCommand { get; set; }
        public Command PersonalDetailsCommand { get; set; }
        public Command AddressCommand { get; set; }
        public Command EmployementCommand { get; set; }
        public Command BankDetailsCommand { get; set; }
        public Command settingCommand { get; set; }
        public Command logoutCommand { get; set; }
        public Command AppSettingCommand { get; set; }
        #endregion

        #region Method
        /// <summary>
        /// TODO: To define logoutCommand.
        /// </summary>
        /// <param name="obj"></param>

        private async void logoutCommandAsync(object obj)
        {
            IsPageEnable = false;
            var res = await UserDialogs.Instance.ConfirmAsync("Are you sure you want to cancel registration varification", null, "No", "Yes");
            var text = (res ? "No" : "Yes");
            if (text == "Yes")
            {
                //Call api..
                try
                {
                    //Call AccessRegister Api..  
                    UserDialogs.Instance.ShowLoading("Please Wait…", MaskType.Clear);
                    if (CrossConnectivity.Current.IsConnected)
                    {
                        await Task.Run(async () =>
                        {
                            if (_businessCode != null)
                            {
                                await _businessCode.AccessLogOutApi(new AccessLogOutRequestModel()
                                {
                                    usertoken = Helpers.Settings.GeneralAccessToken,

                                },
                                async (aobj) =>
                                {
                                    Device.BeginInvokeOnMainThread(async () =>
                                    {
                                        var requestList = (aobj as AccessLogOutResponseModel);
                                        if (requestList != null)
                                        {
                                            if (requestList.responsecode == 100)
                                            {
                                                Helpers.Settings.GeneralAccessToken = string.Empty;
                                                App.Current.MainPage = new Views.Login.LoginPage(null);
                                            }
                                            else
                                            {
                                                UserDialogs.Instance.Alert(requestList.responsemessage, "", "ok");
                                            }

                                        }

                                        UserDialog.HideLoading();
                                    });
                                }, (objj) =>
                                {
                                    Device.BeginInvokeOnMainThread(async () =>
                                    {
                                        UserDialog.HideLoading();
                                        UserDialog.Alert("Something went wrong. Please try again later.", "", "Ok");
                                    });
                                });
                            }
                        }).ConfigureAwait(false);
                    }
                    else
                    {
                        UserDialogs.Instance.Loading().Hide();
                        await UserDialogs.Instance.AlertAsync("No Network Connection found, Please try again!", "", "Okay");
                    }
                }
                catch (Exception ex)
                { UserDialog.HideLoading(); }
            }
            else
            {
                IsPageEnable = true;
            }
        }

        /// <summary>
        /// TODO: To define BankDetailsCommand.
        /// </summary>
        /// <param name="obj"></param>
        private async void BankDetailsCommandAsync(object obj)
        {
            if (TapCount == 0)
            {
                TapCount++;
                await Navigation.PushModalAsync(new Views.MyAccount.BankPage());
            }
        }
        /// <summary>
        /// TODO: To define EmployementCommand.
        /// </summary>
        /// <param name="obj"></param>
        private async void EmployementCommandAsync(object obj)
        {
            if (TapCount1 == 0)
            {
                TapCount1++;
                await Navigation.PushModalAsync(new Views.MyAccount.EmployementPage());
            }
        }
        /// <summary>
        /// TODO: To define AddressCommand.
        /// </summary>
        /// <param name="obj"></param>
        private async void AddressCommandAsync(object obj)
        {
            if (TapCount2 == 0)
            {
                TapCount2++;
                await Navigation.PushModalAsync(new Views.MyAccount.AddressPage());
            }
        }
        /// <summary>
        /// TODO: To define PersonalDetails.
        /// </summary>
        /// <param name="obj"></param>
        private async void PersonalDetailsCommandAsync(object obj)
        {
            if (TapCount3 == 0)
            {
                TapCount3++;
                await Navigation.PushModalAsync(new Views.MyAccount.Personal_Details());
            }
        }

        /// <summary>
        /// TODO: To define App SEttings.
        /// </summary>
        /// <param name="obj"></param>
        private async void AppSettingCommandAsync(object obj)
        {
            if (TapCount4 == 0)
            {
                TapCount4++;
                App.masterDetailPage.IsPresented = false;
                App.masterDetailPage.Detail = new Xamarin.Forms.NavigationPage(new Views.MyAccount.AppSettingPage());
                App.Current.MainPage = App.masterDetailPage;
                App.masterDetailPage.IsPresented = false;
            }
            //await Navigation.PushModalAsync(new Views.MyAccount.AppSettingPage()); 
        }

        /// <summary>
        /// TODO: To define Menu command.
        /// </summary>
        /// <param name="obj"></param>
        private void MenuCommandAsync(object obj)
        {
            App.masterDetailPage.IsPresented = true;
        }
        #endregion
    }
}
