using Acr.UserDialogs;
using MonicaLoanApp.Models;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MonicaLoanApp.ViewModels.ResetPassword
{
    public class UpdatePasswordPageVm : BaseViewModel
    { 
        public string Email;
        private const string _password = @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{6,}$";

        #region Constructor
        public UpdatePasswordPageVm(INavigation nav, string _Email)
        {
            Navigation = nav;
            PasswordCommand = new Command(PasswordCommandAsync);
            ResendCodeCommand = new Command(ResendCodeAsync); 
            NewPasswordCommand = new Command(NewPasswordCommandAsync);
            Email = _Email; 
        }
        #endregion

        #region Properties


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
        private string _Token;
        public string Token
        {
            get { return _Token; }
            set
            {
                if (_Token != value)
                {
                    _Token = value;
                    OnPropertyChanged("Token");
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
        #endregion

        #region Commands 
        public Command PasswordCommand { get; set; }
        public Command ResendCodeCommand { get; set; } 
        public Command NewPasswordCommand { get; set; }

        #endregion

        #region Methods
        /// <summary>
        ///  TODO : To Validate NewPasswordCommand...
        /// </summary>
        /// <param name="obj"></param>
        private async void NewPasswordCommandAsync(object obj)
        {
            if (!await Validate()) return;
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
                            await _businessCode.AccessPasswordChangeApi(new AccessPasswordChangeRequestModel()
                            {

                                validatetoken = Token,
                                password = NewPassword,
                                emailaddress = Email,
                            },
                            async (aobj) =>
                            {
                                Device.BeginInvokeOnMainThread(async () =>
                                {
                                    var requestList = (aobj as AccessPasswordChangeResponseModel);
                                    if (requestList != null)
                                    {
                                        if (requestList.responsecode == 100)
                                        {
                                            //UserDialogs.Instance.Alert(requestList.responsemessage, "Success", "ok");
                                            //App.Current.MainPage = new Views.Login.LoginPage(Email);
                                            UserDialogs.Instance.Alert("Password changed successfully. You may now login with your new password.", "", "ok");
                                            App.Current.MainPage = new Views.Login.LoginPage(Email);
                                        }
                                        else
                                        {
                                            await App.Current.MainPage.DisplayAlert("", requestList.responsemessage, "Ok");
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
                            }) ;
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
            // UserDialog.Alert("Password reset successfully.!", "Alert", "Ok");
            //
        }

        /// <summary>
        /// TODO : To Validate reset password Fields...
        /// </summary>
        /// <returns></returns>
        public async Task<bool> Validate()
        {
            if (string.IsNullOrEmpty(Token))
            {
                UserDialog.Alert("Please enter Token.");
                return false;
            }
            if (Token.Length >= 20)
            {
                UserDialog.Alert("Reset code should not be more than 20 chracters.");
                return false;
            }
            if (string.IsNullOrEmpty(NewPassword))
            {
                UserDialog.Alert("Please enter new password.");
                return false;
            }
            if (NewPassword.Length < 6 || NewPassword.Length > 50)
            {
                UserDialog.Alert("Password length should be between 6 - 50 charcters.");
                return false;
            }
            bool isValid = (Regex.IsMatch(NewPassword, _password, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
            if (!isValid)
            {
                UserDialogs.Instance.Alert("Password must contain minimum 6 charachters and at least 1 letter, 1 number and 1 special character.", "Alert", "Ok");
                return false;
            }
            return true;
        }

        /// <summary>
        /// To Show or Hide Password
        /// </summary>
        /// <param name="obj"></param>
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

        /// <summary>
        /// TODO : To Perform Resend Code Operation...
        /// </summary>
        /// <param name="obj"></param>
        private async void ResendCodeAsync(object obj)
        {
            try
            {
                UserDialogs.Instance.ShowLoading("Please Wait…", MaskType.Clear);
                if (CrossConnectivity.Current.IsConnected)
                {
                    await Task.Run(async () =>
                    {
                        if (_businessCode != null)
                        {
                            await _businessCode.AccessPasswordResendCodeApi(new ResendCodeRequestModel()
                            {
                                emailaddress =Email,
                            }, async (objs) =>
                            {
                                Device.BeginInvokeOnMainThread(async () =>
                                {
                                    var requestList = (objs as AccessPasswordChangeResponseModel);
                                    if (requestList != null)
                                    {
                                        UserDialog.HideLoading();
                                        UserDialogs.Instance.Alert(requestList.responsemessage, "", "ok");
                                        Xamarin.Forms.MessagingCenter.Send<string>("", "StartCountDown");
                                    }
                                });
                            }, (objj) =>
                            {
                                Device.BeginInvokeOnMainThread(async () =>
                                {
                                    var requestList = (obj as AccessPasswordChangeResponseModel);
                                    if (requestList != null)
                                    {
                                        UserDialog.HideLoading();
                                        UserDialogs.Instance.Alert(requestList.responsemessage, "", "ok");
                                    }
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
            {
                UserDialog.HideLoading();
            }

        }

        #endregion
    }
}
