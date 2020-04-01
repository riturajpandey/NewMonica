using Acr.UserDialogs;
using MonicaLoanApp.Models;
using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MonicaLoanApp.ViewModels.Loans
{
    public class YourLoanBalancePageVM : BaseViewModel
    {
        public int TapCount1 = 0;
        public int TapCount2 = 0;

        #region  Constructor
        public YourLoanBalancePageVM(INavigation nav)
        {
            Navigation = nav;
            PlusCommand = new Command(PlusCommandAsync);
            ListCommand = new Command(ListCommandAsync);

        }
        #endregion

        #region Commands  
        public Command PlusCommand { get; set; }
        public Command ListCommand { get; set; }
        #endregion

        #region Properties
        private string _LoanAmount;
        public string LoanAmount
        {
            get { return _LoanAmount; }
            set
            {
                if (_LoanAmount != value)
                {
                    _LoanAmount = value;
                    OnPropertyChanged("LoanAmount");
                }
            }
        }
        private string _DueAmount;
        public string DueAmount
        {
            get { return _DueAmount; }
            set
            {
                if (_DueAmount != value)
                {
                    _DueAmount = value;
                    OnPropertyChanged("DueAmount");
                }
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// TODO: To define
        /// </summary>
        /// <param name="obj"></param>
        private void ListCommandAsync(object obj)
        {
            if (TapCount1 == 0)
            {
                TapCount1++;
                Navigation.PushModalAsync(new Views.Payments.MakePaymentPage());
            }
        }
        /// <summary>
        /// TODO: To define
        /// </summary>
        /// <param name="obj"></param>
        private void PlusCommandAsync(object obj)
        {
            if (TapCount2 == 0)
            {
                TapCount2++;
                Navigation.PushModalAsync(new Views.Loans.LoanApplicationForm());
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
        #endregion
    }
}
