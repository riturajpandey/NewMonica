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
    public class EmployementPageVM : BaseViewModel
    {
        #region Constructor
        public EmployementPageVM(INavigation nav)
        {
            Navigation = nav;
            SaveCommand = new Command(SaveCommandAsync);
        }
        #endregion

        #region Properties
        private string _StartDate ;
        public string StartDate
        {
            get { return _StartDate; }
            set
            {
                if (_StartDate != value)
                {
                    _StartDate = value; 
                    OnPropertyChanged("StartDate");
                }
            }
        }
        private string _EnterEmpNo;
        public string EnterEmpNo
        {
            get { return _EnterEmpNo; }
            set
            {
                if (_EnterEmpNo != value)
                {
                    _EnterEmpNo = value;
                    OnPropertyChanged("EnterEmpNo");
                }
            }
        }
        private string _EnterSalary;
        public string EnterSalary
        {
            get { return _EnterSalary; }
            set
            {
                if (_EnterSalary != value)
                {
                    _EnterSalary = value;
                    OnPropertyChanged("EnterSalary");
                }
            }
        }
        private ObservableCollection<Staticdata> _EmpCode;
        public ObservableCollection<Staticdata> EmpCode
        {
            get { return _EmpCode; }
            set
            {
                if (_EmpCode != value)
                {
                    _EmpCode = value;
                    OnPropertyChanged("EmpCode");
                }
            }
        }

        private string _EmployerName;
        public string EmployerName
        {
            get { return _EmployerName; }
            set
            {
                if (_EmployerName != value)
                {
                    _EmployerName = value;
                    OnPropertyChanged("EmployerName");
                }
            }
        }
        private string _EmployerCode;
        public string EmployerCode
        {
            get { return _EmployerCode; }
            set
            {
                if (_EmployerCode != value)
                {
                    _EmployerCode = value;
                    OnPropertyChanged("EmployerCode");
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
            //Apply ValidateEmployement...
            if (!await ValidateEmployement()) return;
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
                                bankcode = Helpers.Constants.UserBankcode,
                                bankaccountno = Helpers.Constants.UserBankaccountno,
                                addressline1 = Helpers.Constants.UserAddressline1,
                                addressline2 = Helpers.Constants.UserAddressline2,
                                City = Helpers.Constants.UserCity,
                                Statecode = Helpers.Constants.UserStatecode,
                                employercode = EmployerCode,
                                employeenumber = EnterEmpNo,
                                Salary = EnterSalary, 
                                Startdate = StartDate, 
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
                                                Message = "Your employment details updated successfully!",
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
                var EmployerList = Helpers.Constants.StaticDataList.Where(a => a.type == "EMPLOYER").ToList();
                EmpCode = new ObservableCollection<Staticdata>(EmployerList);

            }
            catch (Exception ex)
            { UserDialog.HideLoading(); }
        }
        /// <summary>
        /// TODO : To Validate User ValidateEmployement Fields...
        /// </summary>
        /// <returns></returns>
        public async Task<bool> ValidateEmployement()
        {
            if(string.IsNullOrEmpty(EmployerName))
            {
                UserDialog.Alert("Please select employer");
                return false;
            }
            if (string.IsNullOrEmpty(EnterEmpNo))
            {
                UserDialog.Alert("Please enter enter employe No");
                return false;
            }
            if (string.IsNullOrEmpty(EnterSalary))
            {
                UserDialog.Alert("Please enter salary.");
                return false;
            }
            if(StartDate == "Start date")
            {
                UserDialog.Alert("Please select start date.");
                return false;
            }
            return true;

        }
        #endregion
    }
}