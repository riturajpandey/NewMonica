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
    public class EmailResetPageVM : BaseViewModel
    {
        //TODO : To Define Local Class Level Variables..
        private const string _emailRegex = @"^[a-z][a-z|0-9|]*([_][a-z|0-9]+)*([.][a-z|0-9]+([_][a-z|0-9]+)*)?@[a-z][a-z|0-9|]*\.([a-z][a-z|0-9]*(\.[a-z][a-z|0-9]*)?)$";
        
        #region Constructor
        // <summary>
        /// Initializes a new instance of the <see cref="EmailResetPageVM"/> class.
        /// </summary>
        /// <param name="nav"></param>
        public EmailResetPageVM(INavigation nav)
        {
            Navigation = nav;
            SubmitCommand = new Command(SubmitCommandAsync);
        }
        #endregion

        #region Properties
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
        #endregion

        #region Commands 
        public Command SubmitCommand { get; set; }

        #endregion

        #region Methods
      
        /// <summary>
        /// TODO : To Validate Submit Command...
        /// </summary>
        /// <param name="obj"></param>
        private async void SubmitCommandAsync(object obj)
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
                            await _businessCode.AccessPasswordReminderApi(new AccessPasswordReminderRequestModel()
                            {

                                emailaddress = Email,

                            },
                            async (aobj) =>
                            {
                                Device.BeginInvokeOnMainThread(async () =>
                                {
                                    var requestList = (aobj as AccessPasswordReminderResponseModel);
                                    if (requestList != null)
                                    {
                                        if (requestList.responsecode == 100)
                                        {
                                           // UserDialog.HideLoading();
                                            await Navigation.PushModalAsync(new Views.ResetPassword.UpdatePasswordPage(Email));
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
        /// TODO : To Validate reset password Fields...
        /// </summary>
        /// <returns></returns>
        public async Task<bool> Validate()
        {
            if (string.IsNullOrEmpty(Email))
            {
                UserDialog.Alert("Please enter your email address.");
                return false;
            }
            if (Email.Length < 6 || Email.Length > 100)
            {
                UserDialog.Alert("Email length should be between 6 - 100 charcters.");
                return false;
            }
            bool isValid3 = (Regex.IsMatch(Email, _emailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
            if (!isValid3)
            {
                UserDialogs.Instance.Alert("Please enter valid email", "", "Ok");
                return false;
            }
            return true;
        }
        #endregion
    }
}
