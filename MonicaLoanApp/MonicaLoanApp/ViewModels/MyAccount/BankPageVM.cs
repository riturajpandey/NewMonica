using Acr.UserDialogs;
using MonicaLoanApp.Models;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MonicaLoanApp.ViewModels.MyAccount
{
    public class BankPageVM : BaseViewModel
    {
        #region Constructor
        public BankPageVM(INavigation nav)
        {
            Navigation = nav;
            SaveCommand = new Command(SaveCommandAsync);
        }
        #endregion

        #region Properties
        private string _BankAccountNumber;
        public string BankAccountNumber
        {
            get { return _BankAccountNumber; }
            set
            {
                if (_BankAccountNumber != value)
                {
                    _BankAccountNumber = value;
                    OnPropertyChanged("BankAccountNumber");
                }
            }

        }
        private string _EnterBVN;
        public string EnterBVN
        {
            get { return _EnterBVN; }
            set
            {
                if (_EnterBVN != value)
                {
                    _EnterBVN = value;
                    OnPropertyChanged("EnterBVN");
                }
            }
        }
        private ObservableCollection<Staticdata> _Banklist;
        public ObservableCollection<Staticdata> Banklist
        {
            get { return _Banklist; }
            set
            {
                if (_Banklist != value)
                {
                    _Banklist = value;
                    OnPropertyChanged("Banklist");
                }
            }
        }
        private string _Bankcode;
        public string Bankcode
        {
            get { return _Bankcode; }
            set
            {
                if (_Bankcode != value)
                {
                    _Bankcode = value;
                    OnPropertyChanged("Bankcode");
                }
            }
        }

        private string _BankName;
        public string BankName
        {
            get { return _BankName; }
            set
            {
                if (_BankName != value)
                {
                    _BankName = value; 
                    OnPropertyChanged("BankName");
                }
            }
        }

        #endregion

        #region Commands
        public Command SaveCommand { get; set; }
        #endregion

        #region Methods

        /// <summary>
        /// To Call Api To Save Profile...
        /// </summary>
        /// <param name="obj"></param>
        private async void SaveCommandAsync(object obj)
        {
            //Apply ValidateBank...
            if (!await ValidateBank()) return;
            //Call api..
            try
            {
                UserDialogs.Instance.ShowLoading();
                if (CrossConnectivity.Current.IsConnected)
                {
                    await Task.Run(async () =>
                    {
                        if (_businessCode != null)
                        {
                            await _businessCode.ProfileSaveApi(new ProfileSaveRequestModel()
                            {
                                usertoken = Helpers.Settings.GeneralAccessToken,
                                mobileno = Helpers.Constants.Usermobileno,
                                gender = Helpers.Constants.Usergender,
                                maritalstatus = Helpers.Constants.UserMaritalstatus,
                                bankcode = Bankcode,
                                bankaccountno = BankAccountNumber,
                                addressline1 = Helpers.Constants.UserAddressline1,
                                addressline2 = Helpers.Constants.UserAddressline2,
                                City = Helpers.Constants.UserCity,
                                Statecode = Helpers.Constants.UserStatecode, 
                                employercode = Helpers.Constants.UserEmployercode,
                                employeenumber = Helpers.Constants.UserEmployeenumber,
                                Salary = Helpers.Constants.UserSalary,
                                Startdate = Helpers.Constants.UserStartdate,
                                Profilepic = Helpers.Constants.Userprofilepic
                            },
                            async (_obj) =>
                            {
                                Device.BeginInvokeOnMainThread(async () =>
                                {
                                    var requestList = (_obj as ProfileSaveResponseModel);
                                    if (requestList != null)
                                    {
                                        if (requestList.responsecode == 100)
                                        {
                                            await GetProfile();
                                            UserDialogs.Instance.HideLoading();
                                            var alertConfig = new AlertConfig
                                            {
                                                Title = "",
                                                Message = "Your bank details updated successfully!",
                                                OkText = "OK",
                                                OnAction = () =>
                                                {
                                                    App.Current.MainPage = new Views.MyAccount.MyAccountPage();
                                                }
                                            };
                                            UserDialogs.Instance.Alert(alertConfig);
                                        }
                                        else
                                        {
                                            UserDialogs.Instance.Alert(requestList.responsemessage, "", "ok");
                                        }

                                    }
                                    else
                                    {
                                        UserDialogs.Instance.HideLoading();
                                        UserDialogs.Instance.Alert("Something went wrong please try again.", "", "OK");
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

        /// <summary>
        /// TO call Get profile data
        /// </summary>
        /// <returns></returns>
        public async Task GetProfile()
        {
            //Call api..
            try
            {
                UserDialogs.Instance.ShowLoading();
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

        /// <summary>
        /// Call This Api For StaticDataSearch
        /// </summary>
        /// <returns></returns>
        public async Task StaticDataSearch()
        {
            //Fileter Bank List From Static Data List..
            try
            {
                var filteredBankList = Helpers.Constants.StaticDataList.Where(a => a.type == "BANK").ToList();
                Banklist = new ObservableCollection<Staticdata>(filteredBankList);
            }
            catch (Exception ex)
            { UserDialog.HideLoading(); }
        }
        /// <summary>
        /// TODO : To Validate User ValidateEmployement Fields...
        /// </summary>
        /// <returns></returns>
        public async Task<bool> ValidateBank()
        {
            if(string.IsNullOrEmpty(BankName))
            {
                UserDialog.Alert("Please select bank.");
                return false;
            }
            if (string.IsNullOrEmpty(BankAccountNumber))
            {
                UserDialog.Alert("Please enter bank account number.");
                return false;
            }
            if (string.IsNullOrEmpty(EnterBVN))
            {
                UserDialog.Alert("Please enter bvn number.");
                return false;
            }
            return true;

        }
        #endregion
    }
}
