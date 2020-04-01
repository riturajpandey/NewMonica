using Acr.UserDialogs;
using MonicaLoanApp.Interfaces;
using MonicaLoanApp.Models;
using MonicaLoanApp.Views.Popup.LoanApplication;
using Plugin.Connectivity;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Plugin.Permissions;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MonicaLoanApp.ViewModels.Loans
{
    public class LoanApplicationFormVM : BaseViewModel
    {
        /// <summary>
        /// TODO: To define class level variable...
        /// </summary>
        protected SubmittedLoanApplicationPopup SubmittedLoanApplicationPopup;
        public bool IsPhoto = false; 
        #region Constructor
        public LoanApplicationFormVM(INavigation nav)
        {
            Navigation = nav;
            Continue = new Command(ContinueCommandAsync);
            BckCommand = new Command(BckCommandAsync);
            SubmitCommand = new Command(SubmitCommandAsync);
            IdCardCommand = new Command(IdCardCommandAsync);
        }




        #endregion

        #region Properties
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
        private ObservableCollection<Staticdata> _Purpose;
        public ObservableCollection<Staticdata> Purpose
        {
            get { return _Purpose; }
            set
            {
                if (_Purpose != value)
                {
                    _Purpose = value;
                    OnPropertyChanged("Purpose");
                }
            }
        }
        private string _PartImgBase64;
        public string PartImgBase64
        {
            get { return _PartImgBase64; }
            set
            {
                if (_PartImgBase64 != value)
                {
                    _PartImgBase64 = value;
                    OnPropertyChanged("PartImgBase64");
                }
            }
        }

        private string _EnterAmount;
        public string EnterAmount
        {
            get { return _EnterAmount; }
            set
            {
                if (_EnterAmount != value)
                {
                    _EnterAmount = value;
                    OnPropertyChanged("EnterAmount");
                }
            }
        }
        private string _EnterEmployeeNumber;
        public string EnterEmployeeNumber
        {
            get { return _EnterEmployeeNumber; }
            set
            {
                if (_EnterEmployeeNumber != value)
                {
                    _EnterEmployeeNumber = value;
                    OnPropertyChanged("EnterEmployeeNumber");
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
        private string _NumberOfWeek;
        public string NumberOfWeek
        {
            get { return _NumberOfWeek; }
            set
            {
                if (_NumberOfWeek != value)
                {
                    _NumberOfWeek = value;
                    OnPropertyChanged("NumberOfWeek");
                }
            }
        }
        private bool _GridOne = true;
        public bool GridOne
        {
            get { return _GridOne; }
            set
            {
                if (_GridOne != value)
                {
                    _GridOne = value;
                    OnPropertyChanged("GridOne");
                }
            }
        }
        private bool _GridSecond = false;
        public bool GridSecond
        {
            get { return _GridSecond; }
            set
            {
                if (_GridSecond != value)
                {
                    _GridSecond = value;
                    OnPropertyChanged("GridSecond");
                }
            }
        }

        private string _DateOfBirth = "Select Start date";
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

        private string _LoanDuration;
        public string LoanDuration
        {
            get { return _LoanDuration; }
            set
            {
                if (_LoanDuration != value)
                {
                    _LoanDuration = value;
                    OnPropertyChanged("LoanDuration");
                }
            }
        }
        private string _RepaymentType;
        public string RepaymentType
        {
            get { return _RepaymentType; }
            set
            {
                if (_RepaymentType != value)
                {
                    _RepaymentType = value;
                    OnPropertyChanged("RepaymentType");
                }
            }
        }

        private string _SelectPurpose;
        public string SelectPurpose
        {
            get { return _SelectPurpose; }
            set
            {
                if (_SelectPurpose != value)
                {
                    _SelectPurpose = value;
                    OnPropertyChanged("SelectPurpose");
                }
            }
        }

        private string _Employer;
        public string Employer
        {
            get { return _Employer; }
            set
            {
                if (_Employer != value)
                {
                    _Employer = value;
                    OnPropertyChanged("Employer");
                }
            }
        }
        public string PurposeCode { get; set; }
        public string EmployerCode { get; set; }
        #endregion

        #region Command
        public Command Continue { get; set; }
        public Command BckCommand { get; set; }
        public Command SubmitCommand { get; set; }
        public Command IdCardCommand { get; set; }
        #endregion

        #region Method
        /// <summary>
        /// TODO: To define continue command for naviagtion to next page.
        /// </summary>
        /// <param name="obj"></param>
        private async void ContinueCommandAsync(object obj)
        {
            //Apply Validations...
            if (!await ValidateLoan()) return;
            GridOne = false;
            GridSecond = true;
        }

        /// <summary>
        /// TODO : To Validate User ValidateEmployement Fields...
        /// </summary>
        /// <returns></returns>
        public async Task<bool> ValidateLoan()
        {
            if (string.IsNullOrEmpty(EnterAmount))
            {
                UserDialog.Alert("Please enter amount.");
                return false;
            }
            if (string.IsNullOrEmpty(SelectPurpose))
            {
                UserDialog.Alert("Please select purpose.");
                return false;
            }
            if (string.IsNullOrEmpty(RepaymentType))
            {
                UserDialog.Alert("Please select repayment type.");
                return false;
            }
            if (string.IsNullOrEmpty(LoanDuration))
            {
                UserDialog.Alert("Please select duration.");
                return false;
            }
            if (string.IsNullOrEmpty(NumberOfWeek))
            {
                UserDialog.Alert("Please enter no. of duration."); 
                return false;
            }
            return true;  
        }

        public async Task<bool> ValidateLoanDetail()
        {
            if (string.IsNullOrEmpty(Employer))
            {
                UserDialog.Alert("Please select employer.");
                return false;
            }
            if (DateOfBirth == "Select Start date")
            {
                UserDialog.Alert("Please select start date.");
                return false;
            }
            if (string.IsNullOrEmpty(EnterSalary))
            {
                UserDialog.Alert("Please enter salary.");
                return false;
            }
            if (string.IsNullOrEmpty(EnterEmployeeNumber))
            {
                UserDialog.Alert("Please enter employee number.");
                return false;
            }
            if (string.IsNullOrEmpty(PartImgBase64))
            {
                UserDialog.Alert("Please upload id card.");
                return false;
            }
            return true;
        }

        /// <summary>
        /// TODO: To define SubmitCommand for naviagtion to next page.
        /// </summary>
        /// <param name="obj"></param>
        private async void SubmitCommandAsync(object obj)
        { 
            //Apply Validations...
            if (!await ValidateLoanDetail()) return; 
            //Call api..
            try
            {
                //Call AccessRegister Api..  
                UserDialogs.Instance.ShowLoading();
                if (CrossConnectivity.Current.IsConnected)
                {
                    await Task.Run(async () =>
                    {
                        if (_businessCode != null)
                        {
                            await _businessCode.LoanCreateApi(new LoanCreateRequestModel()
                            {
                                usertoken = Helpers.Settings.GeneralAccessToken,
                                loanamount= Convert.ToInt32(EnterAmount),
                                durationperiod= LoanDuration,
                                durationtotal= Convert.ToInt32(NumberOfWeek),
                                employeesalarymonthly= Convert.ToInt32(EnterSalary),
                                employercode=EmployerCode,
                                purposecode=PurposeCode,
                                employeenumber= EnterEmployeeNumber,
                                employeeidcard= PartImgBase64,
                                employeestartdate= DateOfBirth,
                                
                            },
                            async (_obj) =>
                            {
                                Device.BeginInvokeOnMainThread(async () =>
                                {
                                    var requestList = (_obj as LoanCreateResponseModel);
                                    if (requestList != null)
                                    {
                                        if (requestList.responsecode == 100)
                                        {
                                            Helpers.Settings.GeneralLoanNumber = requestList.loannumber;
                                            Helpers.Constants.LoanSubmitSms = requestList.responsemessage;
                                            SubmittedLoanApplicationPopup = new SubmittedLoanApplicationPopup();
                                            await Navigation.PushPopupAsync(SubmittedLoanApplicationPopup, true);

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
            //SubmittedLoanApplicationPopup = new SubmittedLoanApplicationPopup();
            //await Navigation.PushPopupAsync(SubmittedLoanApplicationPopup, true);

        }
        /// <summary>
        /// TODO: To define backCommand for hide and show grid .
        /// </summary>
        /// <param name="obj"></param>
        private void BckCommandAsync(object obj)
        {
            if (GridSecond == true)
            {
                GridOne = true;
                GridSecond = false;
            }
            else if (GridOne == true)
            {
                Navigation.PopModalAsync();
            }
        }
        /// <summary>
        /// To open media funtion...
        /// </summary>
        /// <param name="obj"></param>
        private async void IdCardCommandAsync(object obj)
        {
            //Ask the user if they want to use the camera or pick from the gallery
            var action = await UserDialogs.Instance.ActionSheetAsync("Add Photo", "Cancel", null, null, "Choose Photo", "Take Photo");

            if (action == "Take Photo")
            {
                try
                {
                    IsPhoto = true;
                    var status = await CrossPermissions.Current.CheckPermissionStatusAsync
                                                 (Plugin.Permissions.Abstractions.Permission.Camera);

                    if (status != Plugin.Permissions.Abstractions.PermissionStatus.Granted)
                    {
                        var result = await CrossPermissions.Current.RequestPermissionsAsync(new[] {
                                                                                  Plugin.Permissions.Abstractions.Permission.Camera });
                        status = result[Plugin.Permissions.Abstractions.Permission.Camera];
                    }

                    if (status == Plugin.Permissions.Abstractions.PermissionStatus.Granted)
                    {
                        if (!CrossMedia.Current.IsCameraAvailable)
                        {
                            UserDialogs.Instance.Alert("No camera avaialble.", null, "OK");
                            return;
                        }
                        var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                        {
                            Directory = "Sample",
                            Name = "test.png"
                        });
                        if (file == null)
                            return;
                        var path = file.Path;
                        Helpers.Constants.imgFilePath = file.Path;
                        //Helpers.Constants.PartImage = file.Path;
                        //PartImg = file.Path;
                        var ImageByteData = await DependencyService.Get<IMediaService>().ResizeImage(await DependencyService.Get<IMediaService>().GetMediaInBytes(file.Path), 50, 50);
                        PartImgBase64 = Convert.ToBase64String(ImageByteData);
                        Helpers.Constants.PartImageBase64 = PartImgBase64;
                    }
                    UserDialogs.Instance.HideLoading();
                }
                catch (Exception exception)
                {
                    UserDialogs.Instance.HideLoading();
                }
            }
            else if (action == "Choose Photo")
            {
                try
                {
                    IsPhoto = true;
                    var status = await CrossPermissions.Current.CheckPermissionStatusAsync
                                                 (Plugin.Permissions.Abstractions.Permission.Photos);

                    if (status != Plugin.Permissions.Abstractions.PermissionStatus.Granted)
                    {
                        var result = await CrossPermissions.Current.RequestPermissionsAsync(new[] {
                                                                                  Plugin.Permissions.Abstractions.Permission.Photos });
                        status = result[Plugin.Permissions.Abstractions.Permission.Photos];
                    }

                    if (status == Plugin.Permissions.Abstractions.PermissionStatus.Granted)
                    {
                        if (!CrossMedia.Current.IsPickPhotoSupported)
                        {
                            return;
                        }
                        var file = await CrossMedia.Current.PickPhotoAsync();
                        if (file == null)
                        {
                            return;
                        }
                        var path = file.Path;
                        Helpers.Constants.imgFilePath = file.Path;
                        //Helpers.Constants.PartImage = file.Path;
                        //PartImg = file.Path;
                        var ImageByteData = await DependencyService.Get<IMediaService>().ResizeImage(await DependencyService.Get<IMediaService>().GetMediaInBytes(file.Path), 50, 50);
                        PartImgBase64 = Convert.ToBase64String(ImageByteData);
                        Helpers.Constants.PartImageBase64 = PartImgBase64;
                    }
                    UserDialogs.Instance.HideLoading();
                }
                catch (Exception exception)
                {
                    UserDialogs.Instance.HideLoading();
                }
            }
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

                var PurposeList = Helpers.Constants.StaticDataList.Where(a => a.type == "PURPOSE").ToList();
                Purpose = new ObservableCollection<Staticdata>(PurposeList);
            }
            catch (Exception ex)
            { UserDialog.HideLoading(); }
        }

        #endregion
    }
}
