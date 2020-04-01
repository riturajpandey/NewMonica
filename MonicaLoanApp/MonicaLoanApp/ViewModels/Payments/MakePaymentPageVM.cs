using MonicaLoanApp.Models;
using Acr.UserDialogs;
using MonicaLoanApp.Models.Loan;
using MonicaLoanApp.Models.Payments;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MonicaLoanApp.ViewModels.Payments
{
    public class MakePaymentPageVM : BaseViewModel
    {
        #region Constructor
        public MakePaymentPageVM(INavigation nav)
        {
            Navigation = nav;
            PaymentCommand = new Command(PaymentCommandAsync);
        }
        #endregion

        #region Properties
        private ObservableCollection<Staticdata> _SelectLoan;
        public ObservableCollection<Staticdata> SelectLoan
        {
            get { return _SelectLoan; }
            set
            {
                if (_SelectLoan != value)
                {
                    _SelectLoan = value;
                    OnPropertyChanged("SelectLoan");
                }
            }
        }

        private string _DateOfBirth = "Select schedule";
        public string DateOfBirth
        {
            get { return _DateOfBirth; }
            set
            {
                if (_DateOfBirth != value)
                {
                    _DateOfBirth = value;
                    OnPropertyChanged("DateOfBirth");
                }
            }
        }
        private string _Amount;
        public string Amount
        {
            get { return _Amount; }
            set
            {
                if (_Amount != value)
                {
                    _Amount = value;
                    OnPropertyChanged("Amount");
                }
            }
        }

        private string _LoanPurpose;
        public string LoanPurpose
        {
            get { return _LoanPurpose; }
            set
            {
                if (_LoanPurpose != value)
                {
                    _LoanPurpose = value; 
                    OnPropertyChanged("LoanPurpose"); 
                }
            }
        }

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

        private string _LoanNumber = "Select loan";
        public string LoanNumber
        {
            get { return _LoanNumber; }
            set
            {
                if (_LoanNumber != value)
                {
                    _LoanNumber = value;
                    OnPropertyChanged("LoanNumber"); 
                }
            }
        }

        private string _LoanSchedule = "Select schedule"; 
        public string LoanSchedule 
        {
            get { return _LoanSchedule; }
            set
            {
                if (_LoanSchedule != value)
                {
                    _LoanSchedule = value;
                    OnPropertyChanged("LoanSchedule"); 
                }
            }
        }

        private ObservableCollection<AllLoan> _LoansList;
        public ObservableCollection<AllLoan> LoansList
        {
            get { return _LoansList; } 
            set
            {
                if (_LoansList != value)
                {
                    _LoansList = value;
                    OnPropertyChanged("LoansList");
                }
            }
        }

        private ObservableCollection<Schedule> _SchedulesList;
        public ObservableCollection<Schedule> SchedulesList 
        {
            get { return _SchedulesList; }
            set
            {
                if (_SchedulesList != value)
                {
                    _SchedulesList = value;
                    OnPropertyChanged("SchedulesList");
                }
            }
        }

        private string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                if (_Name != value)
                {
                    _Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        private string _Bank;
        public string Bank
        {
            get { return _Bank; }
            set
            {
                if (_Bank != value)
                {
                    _Bank = value;
                    OnPropertyChanged("Bank");
                }
            }
        }

        private string _AccountNumber;
        public string AccountNumber
        {
            get { return _AccountNumber; }
            set
            {
                if (_AccountNumber != value)
                {
                    _AccountNumber = value;
                    OnPropertyChanged("AccountNumber");
                }
            }
        }

        private string _Reference;
        public string Reference
        {
            get { return _Reference; }
            set
            {
                if (_Reference != value)
                {
                    _Reference = value;
                    OnPropertyChanged("Reference");
                }
            }
        }
        #endregion

        #region Commands
        public Command PaymentCommand { get; set; }
        #endregion

        #region Methods
        public async Task GetAllLoans()
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
                            await _businessCode.GetAllLoansApi(new AllLoanRequestModel()
                            {
                                usertoken = MonicaLoanApp.Helpers.Settings.GeneralAccessToken
                            },
                            async (obj) =>
                            {
                                Device.BeginInvokeOnMainThread(async () =>
                                {
                                    var requestList = (obj as AllLoanResponseModel).loans;
                                    if (requestList.Count > 0)
                                    {
                                        UserDialogs.Instance.HideLoading();
                                        LoansList = new ObservableCollection<AllLoan>(requestList);
                                    }
                                    else
                                    {
                                        UserDialogs.Instance.HideLoading();
                                        UserDialogs.Instance.Alert("Currently you have no loans to make payment.", "", "OK");
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

        public async Task GetLoans()
        {
            //Call api..
            try
            {
                //UserDialogs.Instance.ShowLoading("Loading...", MaskType.Clear);
                if (CrossConnectivity.Current.IsConnected)
                {
                    await Task.Run(async () =>
                    {
                        if (_businessCode != null)
                        {
                            await _businessCode.LoanSearchApi(new LoanSearchRequestModel()
                            {
                                usertoken = MonicaLoanApp.Helpers.Settings.GeneralAccessToken,
                                loannumber = LoanNumber
                            },
                            async (obj) =>
                            {
                                Device.BeginInvokeOnMainThread(async () =>
                                {
                                    var requestList = (obj as LoanSearchResponseModel).loans;
                                    if (requestList != null)
                                    {
                                        UserDialogs.Instance.HideLoading();
                                        SchedulesList = new ObservableCollection<Schedule>(requestList[0].schedules);
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
        /// TODO: To define Payment Complete Command...
        /// </summary>
        /// <param name="obj"></param>
        private async void PaymentCommandAsync(object obj)
        {
            //Apply LoginValidations...
            if (!await PaymentValidate()) return;

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
                            await _businessCode.PaymentCreateApi(new PaymentCreateRequestModel()
                            {
                                usertoken = Helpers.Settings.GeneralAccessToken,
                                loannumber = LoanNumber, 
                                loanschedulenumber = LoanSchedule, 
                                amount = Amount,
                                paymentmethodcode = "CARD" 
                            },
                            async (objj) =>
                            {
                                Device.BeginInvokeOnMainThread(async () =>
                                {
                                    var requestList = (objj as PaymentCreateResponseModel); 
                                    if (requestList != null) 
                                    {
                                        UserDialogs.Instance.HideLoading();
                                        var alertConfig = new AlertConfig
                                        {
                                            Title = "", 
                                            Message = "Payment created successfully!",   
                                            OkText = "OK",
                                            OnAction = () =>
                                            {
                                                App.Current.MainPage = new Views.Payments.PaymentListPage();
                                            }
                                        };
                                        UserDialogs.Instance.Alert(alertConfig);
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

            //UserDialog.Alert("Payment Complete successfully.!", "Success", "Ok");
            //App.Current.MainPage = new Views.Payments.PaymentListPage();
        }

        //TODO : To Apply SignupValidations...
        private async Task<bool> PaymentValidate()
        {
            if (LoanNumber == "Select loan")
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert("Please select loan.", "", "Ok"); 
                return false;
            }
            if (LoanSchedule == "Select schedule")
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert("Please select schedule", "", "Ok"); 
                return false;
            }
            if (string.IsNullOrEmpty(Amount))
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert("Please enter amount.", "", "Ok");
                return false; 
            } 
            if(Convert.ToInt32(Amount) > (Convert.ToInt32(LoanAmount)))
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert("Invalid amount", "", "Ok");
                return false;
            }
            return true; 
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
                SelectLoan = new ObservableCollection<Staticdata>(EmployerList);
            }
            catch (Exception ex)
            { UserDialog.HideLoading(); }
        }
        #endregion

    }
}
