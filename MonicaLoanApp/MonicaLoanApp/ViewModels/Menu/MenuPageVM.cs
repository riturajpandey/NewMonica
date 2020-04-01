using Acr.UserDialogs;
using MonicaLoanApp.Models;
using MonicaLoanApp.Views.Loans;
using MonicaLoanApp.Views.Payments;
using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MonicaLoanApp.ViewModels.Menu
{
    public class MenuPageVM : BaseViewModel
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuPageViewModel"/> class.
        /// </summary>
        /// <param name="nav"></param>
        public MenuPageVM(INavigation nav)
        {
            Navigation = nav;
            HomeCommand = new Command(OnHomeAsync);
            LoansCommand = new Command(OnLoansAsync);
            PaymentsCommand = new Command(OnPaymentsAsync);
            MyAccountCommand = new Command(OnMyAccountAsync);
            HelpCommand = new Command(OnHelpAsync);
            SignOutCommand = new Command(OnSignOutAsync);

        }

        #endregion

        #region DELEGATECOMMAND  
        public Command HomeCommand { get; set; }
        public Command LoansCommand { get; set; }
        public Command PaymentsCommand { get; set; }
        public Command MyAccountCommand { get; set; }
        public Command HelpCommand { get; set; }
        public Command SignOutCommand { get; set; }

        #endregion

        #region PROPERTIES 
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

        private string _UserName;
        public string UserName
        {
            get { return _UserName; }
            set
            {
                if (_UserName != value)
                {
                    _UserName = value;
                    OnPropertyChanged("UserName");
                }
            }
        }
        private string _UserNumber;
        public string UserNumber
        {
            get { return _UserNumber; }
            set
            {
                if (_UserNumber != value)
                {
                    _UserNumber = value;
                    OnPropertyChanged("UserNumber");
                }
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// TODO : To navigate To Home Page...
        /// </summary>
        /// <param name="obj"></param>
        private async void OnHomeAsync(object obj)
        {
            IsPageEnable = false;
            App.masterDetailPage.IsPresented = false;
            App.masterDetailPage.Detail = new Xamarin.Forms.NavigationPage(new YourLoanBalancePage());
            App.Current.MainPage = App.masterDetailPage;
            App.masterDetailPage.IsPresented = false;
        }
        /// <summary>
        /// TODO : To Perform Loan Page...
        /// </summary>
        /// <param name="obj"></param>
        private async void OnLoansAsync(object obj)
        {
            App.masterDetailPage.IsPresented = false;
            App.masterDetailPage.Detail = new Xamarin.Forms.NavigationPage(new LoanDetailsPage());
            App.Current.MainPage = App.masterDetailPage;
            App.masterDetailPage.IsPresented = false;
        }
        /// <summary>
        /// TODO : To Perform Loan Page...
        /// </summary>
        /// <param name="obj"></param>
        private async void OnPaymentsAsync(object obj)
        {
            App.masterDetailPage.IsPresented = false;
            App.masterDetailPage.Detail = new Xamarin.Forms.NavigationPage(new PaymentListPage());
            App.Current.MainPage = App.masterDetailPage;
            App.masterDetailPage.IsPresented = false;
        }
        /// <summary>
        /// TODO : To Perform Account Page...
        /// </summary>
        /// <param name="obj"></param>
        private async void OnMyAccountAsync(object obj)
        {
            App.masterDetailPage.IsPresented = false;
            App.masterDetailPage.Detail = new Xamarin.Forms.NavigationPage(new Views.MyAccount.MyAccountPage());
            App.Current.MainPage = App.masterDetailPage;
            App.masterDetailPage.IsPresented = false;
        }
        /// <summary>
        /// TODO : To Perform Help Page...
        /// </summary>
        /// <param name="obj"></param>
        private async void OnHelpAsync(object obj)
        {
            App.masterDetailPage.IsPresented = false;
            App.masterDetailPage.Detail = new Xamarin.Forms.NavigationPage(new Views.Help.HelpPage());
            App.Current.MainPage = App.masterDetailPage;
            App.masterDetailPage.IsPresented = false;
        }
        /// <summary>
        /// TODO : To Perform SignOut Page...
        /// </summary>
        /// <param name="obj"></param>
        private async void OnSignOutAsync(object obj)
        {
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
        }
        /// <summary>
        /// TO call Get profile data
        /// </summary>
        /// <returns></returns>
        public async Task GetProfile()
        {
            //Call api..
            try
            {
                //To Load The Data From Cache...
                if (!string.IsNullOrEmpty(Helpers.Settings.GeneralProfileDataJSON))
                {
                    var requestList = JsonConvert.DeserializeObject<ProfileGetResponseModel>(Helpers.Settings.GeneralProfileDataJSON);
                    if (requestList != null)
                    {
                        if (requestList.responsecode == 100)
                        {
                            Helpers.Constants.ProfileNumber = requestList.profilenumber;
                            Helpers.Constants.UserLoanbalance = requestList.loanbalance;
                            Helpers.Constants.UserDuebalance = requestList.duesoon;
                            Helpers.Constants.UserBvn = requestList.bvn;
                            Helpers.Constants.UserCity = requestList.city;
                            Helpers.Constants.UserBankname = requestList.bankname;
                            Helpers.Constants.UserBankcode = requestList.bankcode;
                            Helpers.Constants.UserAddressline1 = requestList.addressline1;
                            Helpers.Constants.UserAddressline2 = requestList.addressline2;
                            Helpers.Constants.UserBankaccountno = requestList.bankaccountno;
                            Helpers.Constants.UserDateofbirth = requestList.dateofbirth;
                            Helpers.Constants.UserEmailAddress = requestList.emailaddress;
                            Helpers.Constants.UserEmployeenumber = requestList.employeenumber;
                            Helpers.Constants.UserEmployercode = requestList.employercode;
                            Helpers.Constants.UserEmployername = requestList.employername;
                            Helpers.Constants.UserFirstname = requestList.firstname;
                            Helpers.Constants.UserMiddlename = requestList.middlename;
                            Helpers.Constants.UserLastname = requestList.lastname;
                            Helpers.Constants.Usermobileno = requestList.mobileno;
                            Helpers.Constants.Userprofilepic = requestList.profilepic;
                            Helpers.Constants.UserMaritalstatus = requestList.maritalstatus;
                            Helpers.Constants.UserSalary = requestList.salary;
                            Helpers.Constants.UserStateName = requestList.statename;
                            if (!string.IsNullOrEmpty(Helpers.Constants.UserStateName))
                            {
                                var item = Helpers.Constants.StaticDataList.Where(a => a.data == Helpers.Constants.UserStateName).FirstOrDefault();
                                Helpers.Constants.UserStatecode = item.key;
                            }
                            Helpers.Constants.UserStartdate = requestList.startdate;
                            Helpers.Constants.Usergender = requestList.gender;
                        }
                    }
                }
                //Call AccessRegister Api..  
                //UserDialogs.Instance.ShowLoading("Please Wait…", MaskType.Clear);
                if (CrossConnectivity.Current.IsConnected)
                {
                    await Task.Run(async () =>
                    {
                        if (_businessCode != null)
                        {
                            await _businessCode.ProfileGetApi(new ProfileGetRequestModel()
                            {
                                usertoken = Helpers.Settings.GeneralAccessToken,
                            },
                            async (_obj) =>
                            {
                                Device.BeginInvokeOnMainThread(async () =>
                                {
                                    var requestList = (_obj as ProfileGetResponseModel);
                                    if (requestList != null)
                                    {
                                        if (requestList.responsecode == 100)
                                        {
                                            Helpers.Constants.ProfileNumber = requestList.profilenumber;
                                            Helpers.Constants.UserLoanbalance = requestList.loanbalance;
                                            Helpers.Constants.UserDuebalance = requestList.duesoon;
                                            Helpers.Constants.UserBvn = requestList.bvn;
                                            Helpers.Constants.UserCity = requestList.city;
                                            Helpers.Constants.UserBankname = requestList.bankname;
                                            Helpers.Constants.UserBankcode = requestList.bankcode;
                                            Helpers.Constants.UserAddressline1 = requestList.addressline1;
                                            Helpers.Constants.UserAddressline2 = requestList.addressline2;
                                            Helpers.Constants.UserBankaccountno = requestList.bankaccountno;
                                            Helpers.Constants.UserDateofbirth = requestList.dateofbirth;
                                            Helpers.Constants.UserEmailAddress = requestList.emailaddress;
                                            Helpers.Constants.UserEmployeenumber = requestList.employeenumber;
                                            Helpers.Constants.UserEmployercode = requestList.employercode;
                                            Helpers.Constants.UserEmployername = requestList.employername;
                                            Helpers.Constants.UserFirstname = requestList.firstname;
                                            Helpers.Constants.UserMiddlename = requestList.middlename;
                                            Helpers.Constants.UserLastname = requestList.lastname;
                                            Helpers.Constants.Usermobileno = requestList.mobileno;
                                            Helpers.Constants.Userprofilepic = requestList.profilepic;
                                            Helpers.Constants.UserMaritalstatus = requestList.maritalstatus;
                                            Helpers.Constants.UserSalary = requestList.salary;
                                            Helpers.Constants.UserStateName = requestList.statename;
                                            if (!string.IsNullOrEmpty(Helpers.Constants.UserStateName))
                                            {
                                                var item = Helpers.Constants.StaticDataList.Where(a => a.data == Helpers.Constants.UserStateName).FirstOrDefault();
                                                Helpers.Constants.UserStatecode = item.key;
                                            }
                                            Helpers.Constants.UserStartdate = requestList.startdate;
                                            Helpers.Constants.Usergender = requestList.gender;
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
                    //UserDialogs.Instance.Loading().Hide();
                    //await UserDialogs.Instance.AlertAsync("No Network Connection found, Please try again!", "", "Okay");
                }
            }
            catch (Exception ex)
            { UserDialog.HideLoading(); }
        }

        //public async Task GetProfile()
        //{
        //    //Call api..
        //    try
        //    {
        //        //Call AccessRegister Api..  
        //        UserDialogs.Instance.ShowLoading("Please Wait…", MaskType.Clear);
        //        if (CrossConnectivity.Current.IsConnected)
        //        {
        //            await Task.Run(async () =>
        //            {
        //                if (_businessCode != null)
        //                {
        //                    await _businessCode.ProfileGetApi(new ProfileGetRequestModel()
        //                    {
        //                        usertoken = Helpers.Settings.GeneralAccessToken,

        //                    },
        //                    async (_obj) =>
        //                    {
        //                        Device.BeginInvokeOnMainThread(async () =>
        //                        {
        //                            var requestList = (_obj as ProfileGetResponseModel);
        //                            if (requestList != null)
        //                            {
        //                                if (requestList.responsecode == 100)
        //                                {
        //                                    Helpers.Constants.ProfileNumber = requestList.profilenumber;
        //                                    Helpers.Constants.UserLoanbalance = requestList.loanbalance;
        //                                    Helpers.Constants.UserDuebalance = requestList.duesoon;
        //                                    Helpers.Constants.UserBvn = requestList.bvn;
        //                                    Helpers.Constants.UserCity = requestList.city;
        //                                    Helpers.Constants.UserBankname = requestList.bankname;
        //                                    Helpers.Constants.UserBankcode = requestList.bankcode;
        //                                    Helpers.Constants.UserAddressline1 = requestList.addressline1;
        //                                    Helpers.Constants.UserAddressline2 = requestList.addressline2;
        //                                    Helpers.Constants.UserBankaccountno = requestList.bankaccountno;
        //                                    Helpers.Constants.UserDateofbirth = requestList.dateofbirth;
        //                                    Helpers.Constants.UserEmailAddress = requestList.emailaddress;
        //                                    Helpers.Constants.UserEmployeenumber = requestList.employeenumber;
        //                                    Helpers.Constants.UserEmployercode = requestList.employercode;
        //                                    Helpers.Constants.UserEmployername = requestList.employername;
        //                                    Helpers.Constants.UserFirstname = requestList.firstname;
        //                                    Helpers.Constants.UserMiddlename = requestList.middlename;
        //                                    Helpers.Constants.UserLastname = requestList.lastname;
        //                                    Helpers.Constants.Usermobileno = requestList.mobileno;
        //                                    Helpers.Constants.Userprofilepic = requestList.profilepic;
        //                                    Helpers.Constants.UserMaritalstatus = requestList.maritalstatus;
        //                                    Helpers.Constants.UserSalary = requestList.salary;
        //                                    Helpers.Constants.UserStateName = requestList.statename;
        //                                    if (!string.IsNullOrEmpty(Helpers.Constants.UserStateName))
        //                                    {
        //                                        var item = Helpers.Constants.StaticDataList.Where(a => a.data == Helpers.Constants.UserStateName).FirstOrDefault();
        //                                        Helpers.Constants.UserStatecode = item.key;
        //                                    }

        //                                    Helpers.Constants.UserStartdate = requestList.startdate;
        //                                    Helpers.Constants.Usergender = requestList.gender;

        //                                }
        //                                else
        //                                {
        //                                    UserDialogs.Instance.Alert(requestList.responsemessage, "", "ok");

        //                                }

        //                            }

        //                            UserDialog.HideLoading();
        //                        });
        //                    }, (objj) =>
        //                    {
        //                        Device.BeginInvokeOnMainThread(async () =>
        //                        {
        //                            UserDialog.HideLoading();
        //                            UserDialog.Alert("Something went wrong. Please try again later.", "", "Ok");
        //                        });
        //                    });
        //                }
        //            }).ConfigureAwait(false);
        //        }
        //        else
        //        {
        //            UserDialogs.Instance.Loading().Hide();
        //            await UserDialogs.Instance.AlertAsync("No Network Connection found, Please try again!", "", "Okay");
        //        }
        //    }
        //    catch (Exception ex)
        //    { UserDialog.HideLoading(); }
        //}
        #endregion
    }
}
