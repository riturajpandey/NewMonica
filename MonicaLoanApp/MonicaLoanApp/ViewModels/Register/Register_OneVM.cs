using Acr.UserDialogs;
using MonicaLoanApp.Helpers;
using MonicaLoanApp.Models;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MonicaLoanApp.ViewModels.Register
{
    public class Register_OneVM : BaseViewModel
    {
        //TODO : To Define Local Class Level Variables..
        private const string _name = @"^(?=.*?[0-9])(?=.*?[#?!@$%^&*-])$";
        private const string _emailRegex = @"^[a-z][a-z|0-9|]*([_][a-z|0-9]+)*([.][a-z|0-9]+([_][a-z|0-9]+)*)?@[a-z][a-z|0-9|]*\.([a-z][a-z|0-9]*(\.[a-z][a-z|0-9]*)?)$";
        //private const string _NewPasswordRegex = @"^(?=.*[A-Z|0-9])(?=.*\d)(?=.*[$@$!%*#?&])[A-Z|0-9\d$@$!%*#?&]{6,}$";
        private const string _NewFrstname = @"^[a-zA-Z]+$";
        // private const string _NewMiddlename = @"^[a-zA-Z]+$";
        private const string _NewLastname = @"^[a-zA-Z]+$";
        private const string _password = @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{6,}$";
        #region Constructor
        public Register_OneVM(INavigation nav)
        {
            Navigation = nav;
            NextCommand = new Command(NextCommandAsync);
            SecondNextCommand = new Command(SecondNextCommandAsync);
            BckCommand = new Command(BckCommandAsync);
            PasswordCommand = new Command(PasswordCommandAsync);
        }
        #endregion

        #region Properties
        private string _FirstName;
        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                if (_FirstName != value)
                {
                    _FirstName = value;
                    OnPropertyChanged("FirstName");
                }
            }
        }

        private string _MiddleName;
        public string MiddleName
        {
            get { return _MiddleName; }
            set
            {
                if (_MiddleName != value)
                {
                    _MiddleName = value;
                    OnPropertyChanged("MiddleName");
                }
            }
        }
        private string _LastName;
        public string LastName
        {
            get { return _LastName; }
            set
            {
                if (_LastName != value)
                {
                    _LastName = value;
                    OnPropertyChanged("LastName");
                }
            }
        }
        private string _NewPassword;
        public string NewPassword
        {
            get { return _NewPassword; }
            set
            {
                if (_NewPassword != value)
                {
                    _NewPassword = value;
                    OnPropertyChanged("NewPassword");
                }
            }
        }
        private string _Email;
        public string Email
        {
            get { return _Email; }
            set
            {
                if (_Email != value)
                {
                    _Email = value;
                    OnPropertyChanged("Email");
                }
            }
        }
        private bool _FirstGrid = true;
        public bool FirstGrid
        {
            get { return _FirstGrid; }
            set
            {
                if (_FirstGrid != value)
                {
                    _FirstGrid = value;
                    OnPropertyChanged("FirstGrid");
                }
            }
        }

        private bool _SecondGrid = false;
        public bool SecondGrid
        {
            get { return _SecondGrid; }
            set
            {
                if (_SecondGrid != value)
                {
                    _SecondGrid = value;
                    OnPropertyChanged("SecondGrid");
                }
            }
        }
        private bool _FinalGrid = false;
        public bool FinalGrid
        {
            get { return _FinalGrid; }
            set
            {
                if (_FinalGrid != value)
                {
                    _FinalGrid = value;
                    OnPropertyChanged("FinalGrid");
                }
            }
        }
        private string _DateOfBirth = "Date of birth";
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



        private string _Number;
        public string Number
        {
            get { return _Number; }
            set
            {
                if (_Number != value)
                {
                    _Number = value;
                    OnPropertyChanged("Number");
                }
            }
        }
        private string _Gender;
        public string Gender
        {
            get { return _Gender; }
            set
            {
                if (_Gender != value)
                {
                    _Gender = value;
                    OnPropertyChanged("Gender");
                }
            }
        }
        private string _MaritalStatus;
        public string MaritalStatus
        {
            get { return _MaritalStatus; }
            set
            {
                if (_MaritalStatus != value)
                {
                    _MaritalStatus = value;
                    OnPropertyChanged("MaritalStatus");
                }
            }
        }

        private string _BusinessNumber;
        public string BusinessNumber
        {
            get { return _BusinessNumber; }
            set
            {
                if (_BusinessNumber != value)
                {
                    _BusinessNumber = value;
                    OnPropertyChanged("BusinessNumber");
                }
            }
        }

        private string _BankPicker;
        public string BankPicker
        {
            get { return _BankPicker; }
            set
            {
                if (_BankPicker != value)
                {
                    _BankPicker = value;
                    OnPropertyChanged("BankPicker");
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
        private string _Code;
        public string Code
        {
            get { return _Code; }
            set
            {
                if (_Code != value)
                {
                    _Code = value;
                    OnPropertyChanged("Code");
                }
            }
        }

        public string Bankcode { get; set; }
        private bool _IsPasswordShow = true;
        public bool IsPasswordShow
        {
            get { return _IsPasswordShow; }
            set
            {
                if (_IsPasswordShow != value)
                {
                    _IsPasswordShow = value;
                    OnPropertyChanged("IsPasswordShow");
                }
            }
        }

        private bool _IsPasswordNotShow = false;
        public bool IsPasswordNotShow
        {
            get { return _IsPasswordNotShow; }
            set
            {
                if (_IsPasswordNotShow != value)
                {
                    _IsPasswordNotShow = value;
                    OnPropertyChanged("IsPasswordNotShow");
                }
            }
        }
        private bool _IsPassword = true;
        public bool IsPassword
        {
            get { return _IsPassword; }
            set
            {
                if (_IsPassword != value)
                {
                    _IsPassword = value;
                    OnPropertyChanged("IsPassword");
                }
            }
        }
        #endregion

        #region Commands 
        public Command NextCommand { get; set; }
        public Command SecondNextCommand { get; set; }
        public Command FinishCommand { get; set; }
        public Command BckCommand { get; set; }
        public Command PasswordCommand { get; set; }

        #endregion

        #region Method
        /// <summary>
        /// TODO: Define BackCommand validation for Grids inside single page...
        /// </summary>
        /// <param name="obj"></param>
        private void BckCommandAsync(object obj)
        {
            if (SecondGrid == true)
            {
                FirstGrid = true;
                SecondGrid = false;
                // FinalGrid = false;
            }
            else if (FirstGrid == true)
            {
                Navigation.PopModalAsync();
            }
        }
        /// <summary>
        /// TODO: Define NextCommand validation...
        /// </summary>
        /// <param name="obj"></param>
        private async void NextCommandAsync(object obj)
        {
            if (!await SignupValidate())
            {
                return;
            }
            else
            {
                //Call api..
                try
                {
                    //Call AccessRegisterPreValidate Api..  
                    UserDialogs.Instance.ShowLoading("Please Wait…", MaskType.Clear);
                    if (CrossConnectivity.Current.IsConnected)
                    {
                        await Task.Run(async () =>
                        {
                            if (_businessCode != null)
                            {
                                await _businessCode.AccessRegisterPreValidateApi(new AccessRegisterPreValidateRequestModel()
                                {
                                    emailaddress = Email,
                                    bvn = BusinessNumber
                                },
                                async (resobj) =>
                                {
                                    Device.BeginInvokeOnMainThread(async () =>
                                    {
                                        var requestList = (resobj as AccessRegisterPreValidateResponseModel);
                                        if (requestList != null)
                                        {
                                            if (requestList.responsemessage == "Validation Successful")
                                            {
                                                FirstGrid = false;
                                                SecondGrid = true;
                                            }
                                            else
                                            {
                                                UserDialogs.Instance.Alert(requestList.responsemessage, "", "Ok");
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
        /// TODO: Define SecondNextCommand validation...
        /// </summary>
        /// <param name="obj"></param>
        private async void SecondNextCommandAsync(object obj)
        {
            if (!await SecondSignValidate()) return;
            FirstGrid = false;
            SecondGrid = true;
            //Call api..
            await AccessRegister();
            //try
            //{
            //    //Call AccessRegisterPreValidate Api..  
            //    UserDialogs.Instance.ShowLoading("Please Wait…", MaskType.Clear);
            //    if (CrossConnectivity.Current.IsConnected)
            //    {
            //        await Task.Run(async () =>
            //        {
            //            if (_businessCode != null)
            //            {
            //                await _businessCode.AccessRegisterPreValidateApi(new AccessRegisterPreValidateRequestModel()
            //                {
            //                    emailaddress = Email,
            //                    bvn = BusinessNumber
            //                },
            //                async (resobj) =>
            //                {
            //                    Device.BeginInvokeOnMainThread(async () =>
            //                    {
            //                        var requestList = (resobj as AccessRegisterPreValidateResponseModel);
            //                        if (requestList != null)
            //                        {
            //                            if (requestList.responsemessage == "Validation Successful")
            //                            {
            //                                await AccessRegister();
            //                            }
            //                            else
            //                            {
            //                                UserDialogs.Instance.Alert(requestList.responsemessage, "", "Ok");
            //                            }
            //                        }
            //                        UserDialog.HideLoading();
            //                    });
            //                }, (objj) =>
            //                {
            //                    Device.BeginInvokeOnMainThread(async () =>
            //                    {
            //                        UserDialog.HideLoading();
            //                        UserDialog.Alert("Something went wrong. Please try again later.", "", "Ok");
            //                    });
            //                });
            //            }
            //        }).ConfigureAwait(false);
            //    }
            //    else
            //    {
            //        UserDialogs.Instance.Loading().Hide();
            //        await UserDialogs.Instance.AlertAsync("No Network Connection found, Please try again!", "", "Okay");
            //    }
            //}
            //catch (Exception ex)
            //{ UserDialog.HideLoading(); }
        }
        /// <summary>
        /// TODO: Define FinishCommand validation...
        /// </summary>
        /// <param name="obj"></param>
        //private async void FinishCommandAsync(object obj)
        //{
        //    //if (!await FinishSignUpValidate()) return;

        //    //await Navigation.PushModalAsync(new Views.Register.ConfirmRegistrationPage());
        //    //UserDialog.Alert("Congratulations! You are registered successfully.!", "Success", "Ok");
        //    //App.Current.MainPage = new Views.Login.LoginPage();
        //}

        /// <summary>
        /// Call This Api For AccessRegister
        /// </summary>
        /// <returns></returns>
        public async Task AccessRegister()
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
                            await _businessCode.AccessRegisterApi(new AccessRegisterRequestModel()
                            {
                                firstname = FirstName,
                                middlename = MiddleName,
                                lastname = LastName,
                                emailaddress = Email,
                                password = NewPassword,
                                mobileno = Number,
                                gender = Gender,
                                maritalstatus = MaritalStatus,
                                dateofbirth = DateOfBirth,
                                bvn = BusinessNumber,
                                bankcode = Bankcode,
                                bankaccountno = AccountNumber
                            },
                            async (obj) =>
                            {
                                Device.BeginInvokeOnMainThread(async () =>
                                {
                                    var requestList = (obj as AccessRegisterResponseModel);
                                    if (requestList != null)
                                    {
                                        if (requestList.responsecode == 100)
                                        {
                                            Helpers.Constants.UserToken = requestList.usertoken;
                                            await Navigation.PushModalAsync(new Views.Register.ConfirmRegistrationPage(Email));
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

        /// <summary>
        /// Call This Api For AccessRegisterActivate
        /// </summary>
        /// <returns></returns>
        public async Task AccessRegisterActivate()
        {
            //Call api..
            try
            {
                //Call AccessRegisterActivate Api..  
                UserDialogs.Instance.ShowLoading("Please Wait…", MaskType.Clear);
                if (CrossConnectivity.Current.IsConnected)
                {
                    await Task.Run(async () =>
                    {
                        if (_businessCode != null)
                        {
                            await _businessCode.AccessRegisterActivateApi(new AccessRegisterActivateRequestModel()
                            {
                                usertoken = Constants.UserToken,
                                validatetoken = "806207727"
                            },
                            async (obj) =>
                            {
                                Device.BeginInvokeOnMainThread(async () =>
                                {
                                    var requestList = (obj as AccessRegisterResponseModel);
                                    //if (requestList != null)
                                    //{
                                    //    Helpers.Constants.ObjSetUserProfile.birthDate = UserDOB;
                                    //    Helpers.Constants.ObjSetUserProfile.bloodType = BloodGroupType;
                                    //    Helpers.Constants.ObjSetUserProfile.emailAddress = UserEmail;
                                    //    Helpers.Constants.ObjSetUserProfile.fullName = UserFullName;
                                    //    Helpers.Constants.ObjSetUserProfile.height = Convert.ToInt32(UserHeight);
                                    //    Helpers.Constants.ObjSetUserProfile.mobilePhone = UserPhoneNumber;
                                    //    Helpers.Constants.ObjSetUserProfile.weight = Convert.ToInt32(UserWeight);
                                    //    UserDialog.Alert("Profile updated successfully.", "Success", "Ok");
                                    //}
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

        private async void PasswordCommandAsync(object obj)
        {
            if (IsPasswordShow == true)
            {
                IsPasswordShow = false;
                IsPasswordNotShow = true;
                IsPassword = false;
            }
            else
            {
                IsPasswordNotShow = false;
                IsPasswordShow = true;
                IsPassword = true;
            }
        }
        #endregion

        #region Check Validate All Fields
        /// <summary>
        /// TODO : To Apply SignupValidations...
        /// </summary>
        /// <returns></returns>
        private async Task<bool> SignupValidate()
        {
            if (string.IsNullOrEmpty(FirstName) && string.IsNullOrEmpty(LastName) && string.IsNullOrEmpty(Email) && string.IsNullOrEmpty(NewPassword) && string.IsNullOrEmpty(BusinessNumber))
            {

                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert("All fields are required.");
                return false;
            }
            if (string.IsNullOrEmpty(FirstName))
            {
                UserDialog.HideLoading();
                UserDialogs.Instance.Alert("Please enter First Name.");
                return false;
            }
            if (FirstName.Length < 2 || FirstName.Length > 30)
            {
                UserDialog.Alert("First name should bebetween 2 to 30 charachters.");
                return false;
            }
            bool isValid2 = (Regex.IsMatch(FirstName, _NewFrstname, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
            if (!isValid2)
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert("Invalid First name.");
                return false;
            }
            //if (string.IsNullOrEmpty(MiddleName))
            //{
            //    UserDialog.HideLoading();
            //    UserDialogs.Instance.Alert("Please enter Middle Name");
            //    return false;
            //}
            //if (MiddleName.Length >= 30)
            //{
            //    UserDialog.Alert("Token should contain less than 20 charcter.");
            //    return false;
            //}
            //bool isValid5 = (Regex.IsMatch(MiddleName, _NewMiddlename, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
            //if (!isValid5)
            //{
            //    UserDialogs.Instance.HideLoading();
            //    UserDialogs.Instance.Alert("Please use aphabet only");
            //    return false;
            //}
            if (string.IsNullOrEmpty(LastName))
            {
                UserDialog.HideLoading();
                UserDialogs.Instance.Alert("Please enter Last Name");
                return false;
            }
            if (LastName.Length < 2 || LastName.Length > 30)
            {
                UserDialog.Alert("Last name should bebetween 2 to 30 charachters.");
                return false;
            }
            bool isValid3 = (Regex.IsMatch(LastName, _NewLastname, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
            if (!isValid3)
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert("Invalid Last Name.");
                return false;
            }
            if (string.IsNullOrEmpty(Email))
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert("Please enter email.");
                return false;
            }
            if (Email.Length < 6 || Email.Length > 100)
            {
                UserDialog.Alert("Email should be between 6 and 100 characters.");
                return false;
            }
            bool isValid4 = (Regex.IsMatch(Email, _emailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
            if (!isValid4)
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert("Email is not valid.");
                return false;
            }
            if (string.IsNullOrEmpty(NewPassword))
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert("Please enter password.");
                return false;
            }
            if (NewPassword.Length < 6 || NewPassword.Length > 50)
            {
                UserDialog.Alert("Password should be between 6 and 50 characters.");
                return false;
            }
            bool isvalid1 = (Regex.IsMatch(NewPassword, _password, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
            if (!isvalid1)
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert("Password must contain minimum 6 charachters and at least 1 letter, 1 number and 1 special character.", "", "Ok");
                return false;
            }
            if (string.IsNullOrEmpty(BusinessNumber))
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert("Please enter Bvn Number.");
                return false;
            }

            UserDialogs.Instance.HideLoading();
            return true;
        }
        private async Task<bool> SecondSignValidate()
        {
            if (string.IsNullOrEmpty(Number))
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert("Please enter Mobile Number.");
                return false;
            }
            if (Number.Length >= 15)
            {
                UserDialog.Alert("Mobile Number should contain less than 15 charcter.");
                return false;
            }

            if (string.IsNullOrEmpty(Gender))
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert("Please enter your Gender.");
                return false;
            }

            if (string.IsNullOrEmpty(MaritalStatus))
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert("Please enter your Marrital Status.");
                return false;
            }

            if (string.IsNullOrEmpty(DateOfBirth) || DateOfBirth == "Date of birth")
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert("Please enter your Date Of Birth.");
                return false;
            }

            var dob = Convert.ToDateTime(DateOfBirth);
            var age = System.DateTime.Now.Year - dob.Year; 
            if (age < 18)
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert("You must be 18 years or above to register.");
                return false;
            }
             
            if (string.IsNullOrEmpty(Bankcode))
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert("Please select Bank.");
                return false;
            }

            if (string.IsNullOrEmpty(AccountNumber))
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert("Please enter Bank Account Number.");
                return false;
            }

            if (AccountNumber.Length != 10)
            {
                UserDialog.Alert("Account Number should contain exact 10 digit.");
                return false;
            }

            UserDialogs.Instance.HideLoading();
            return true;
        }
        //private async Task<bool> FinishSignUpValidate()
        //{

        //    if (string.IsNullOrEmpty(AccountNumber))
        //    {
        //        UserDialogs.Instance.HideLoading();
        //        UserDialogs.Instance.Alert("Please enter Account Number.");
        //        return false;
        //    }
        //    UserDialogs.Instance.HideLoading();
        //    return true;
        //}

        #endregion
    }
}
