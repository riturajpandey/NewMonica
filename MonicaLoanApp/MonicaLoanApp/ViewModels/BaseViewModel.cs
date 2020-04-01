using Acr.UserDialogs;
using GalaSoft.MvvmLight.Ioc;
using MonicaLoanApp.BuisnessCode;
using MonicaLoanApp.Models;
using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MonicaLoanApp.ViewModels
{
    public class BaseViewModel : BindableObject
    {

        protected readonly IBusinessCode _businessCode;

        #region CONSTRUCTOR
        public BaseViewModel(INavigation navigation = null)
        {
            try
            {
                Navigation = navigation;
                BacksCommand = new Command(OnBacksAsync);
                MenuCommand = new Command(OnMenuAsync);
                _businessCode = SimpleIoc.Default.GetInstance<IBusinessCode>();

                if (Helpers.Constants.StaticDataList.Count == 0)
                    StaticDataSearch();
            }
            catch (Exception ex)
            { }
        }
        #endregion

        #region COMMAND
        public Command BacksCommand { get; set; }
        public Command MenuCommand { get; set; }
        #endregion

        #region PROPERTIES

        private ObservableCollection<Staticdata> _Staticdatalist;
        public ObservableCollection<Staticdata> Staticdatalist
        {
            get { return _Staticdatalist; }
            set
            {
                if (_Staticdatalist != value)
                {
                    _Staticdatalist = value;
                    OnPropertyChanged("Staticdatalist");
                }
            }
        }

        public Acr.UserDialogs.IUserDialogs UserDialog
        {
            get
            {
                return Acr.UserDialogs.UserDialogs.Instance;
            }
        }
        private INavigation _Navigation;
        public INavigation Navigation
        {
            get { return _Navigation; }
            set
            {
                if (_Navigation != value)
                {
                    _Navigation = value;
                    OnPropertyChanged("Navigation");
                }
            }
        }

        public bool IsInitialized { get; set; }
        #endregion

        #region METHODS 
        /// <summary>
        /// TODO : To Navigate To Back Page...
        /// </summary>
        public async void OnBacksAsync()
        {
            try
            {
                await PopModalAsync();
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// TODO : To Navigate To MasterDetail Page...
        /// </summary>
        /// <param name="obj"></param>
        private void OnMenuAsync(object obj)
        {
            App.masterDetailPage.IsPresented = true;
        }
        public async Task PushModalAsync(Page page)
        {
            if (Navigation != null)
                await Navigation.PushModalAsync(page);
        }

        public async Task PopModalAsync()
        {
            if (Navigation != null)
                await Navigation.PopModalAsync();
        }

        public async Task PushAsync(Page page)
        {
            if (Navigation != null)
                await Navigation.PushModalAsync(page);
        }

        public async Task PopAsync()
        {
            if (Navigation != null)
                await Navigation.PopModalAsync();
        }

        /// <summary>
        /// Call This Api For StaticDataSearch
        /// </summary>
        /// <returns></returns>
        public async Task StaticDataSearch()
        {
            if (!string.IsNullOrEmpty(Helpers.Settings.GeneralStaticDataResponse))
            {
                var objres = JsonConvert.DeserializeObject<StaticDataSearchResponseModel>(Helpers.Settings.GeneralStaticDataResponse);
                Helpers.Constants.StaticDataList = new ObservableCollection<Staticdata>(objres.staticdata);
            }
            else
            {

                //Call api..
                try
                {
                    //Call AccessRegisterActivate Api..  
                    //UserDialogs.Instance.ShowLoading("Loading...", MaskType.Clear);
                    if (CrossConnectivity.Current.IsConnected)
                    {
                        await Task.Run(async () =>
                        {
                            if (_businessCode != null)
                            {
                                await _businessCode.StaticDataSearchApi(new StaticDataSearchRequestModel()
                                { },
                                async (obj) =>
                                {
                                    Device.BeginInvokeOnMainThread(async () =>
                                    {
                                        var requestList = (obj as StaticDataSearchResponseModel);
                                        if (requestList != null)
                                        {
                                            Staticdatalist = new ObservableCollection<Staticdata>(requestList.staticdata);
                                            Helpers.Constants.StaticDataList = Staticdatalist;
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
        }

        #endregion 
    }
}
