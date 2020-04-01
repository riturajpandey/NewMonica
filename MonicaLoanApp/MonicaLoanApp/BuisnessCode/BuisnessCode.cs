using Acr.UserDialogs;
using MonicaLoanApp.Models;
using MonicaLoanApp.Models.Loan;
using MonicaLoanApp.Models.Payments;
using MonicaLoanApp.Providers;
using MonicaLoanApp.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MonicaLoanApp.BuisnessCode
{
    public class BuisnessCode : IBusinessCode
    {
        IApiProvider _apiProvider;

        public BuisnessCode(IApiProvider apiProvider)
        {
            //To initialize service providers...
            _apiProvider = apiProvider;
           
        }

        #region StaticDataSearchApi
        public async Task<StaticDataSearchResponseModel> StaticDataSearchApi(StaticDataSearchRequestModel request, Action<object> success, Action<object> failed)
        {
            StaticDataSearchResponseModel resmodel = new StaticDataSearchResponseModel();
            try
            {
                var url = string.Format("{0}/api/appconnect/StaticDataSearch", WebServiceDetails.BaseUri);
                string randomGuid = Guid.NewGuid().ToString();
                var dic = new Dictionary<string, string>();
                //dic.Add("Content-Type", "Application/json");
                dic.Add("randomguid", randomGuid);
                dic.Add("hash", randomGuid + WebServiceDetails.AppKey);
                var result = _apiProvider.Post<StaticDataSearchResponseModel, StaticDataSearchRequestModel>(url, request, dic);
                var response = result.Result;
                Helpers.Settings.GeneralStaticDataResponse = response.RawResult; 
                StaticDataSearchResponseModel objres = null;
                dynamic obj = "";
                StaticDataSearchResponseModel reg = new StaticDataSearchResponseModel();
                if (response.IsSuccessful != false)
                {
                    objres = JsonConvert.DeserializeObject<StaticDataSearchResponseModel>(response.RawResult);
                    success.Invoke(objres);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    failed.Invoke(obj);
                }
            }
            catch (Exception exception)
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert("Something went wrong please try again.", "", "OK");
            }
            return resmodel;

        }
        #endregion

        #region Register Apis 
        /// <summary>
        /// Call This Api For AccessRegisterPreValidate...
        /// </summary>
        /// <param name="request"></param>
        /// <param name="success"></param>
        /// <param name="failed"></param>
        /// <returns></returns>
        public async Task<AccessRegisterPreValidateResponseModel> AccessRegisterPreValidateApi(AccessRegisterPreValidateRequestModel request, Action<object> success, Action<object> failed)
        {
            AccessRegisterPreValidateResponseModel resmodel = new AccessRegisterPreValidateResponseModel();
            try
            {
                var url = string.Format("{0}/api/appconnect/AccessRegisterPreValidate", WebServiceDetails.BaseUri);
                string randomGuid = Guid.NewGuid().ToString();
                var dic = new Dictionary<string, string>();
                //dic.Add("Content-Type", "Application/json");
                dic.Add("randomguid", randomGuid);
                dic.Add("hash", randomGuid + WebServiceDetails.AppKey + request.emailaddress + request.bvn);
                var result = _apiProvider.Post<AccessRegisterPreValidateResponseModel, AccessRegisterPreValidateRequestModel>(url, request, dic);

                var response = result.Result;
                AccessRegisterPreValidateResponseModel objres = null;
                dynamic obj = "";
                AccessRegisterPreValidateResponseModel reg = new AccessRegisterPreValidateResponseModel();
                if (response.IsSuccessful != false)
                {
                    objres = JsonConvert.DeserializeObject<AccessRegisterPreValidateResponseModel>(response.RawResult);
                    success.Invoke(objres);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    failed.Invoke(obj);
                }
            }
            catch (Exception exception)
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert("Something went wrong please try again.", "", "OK");
            }
            return resmodel;

        }
        /// <summary>
        /// Call This Api For AccessRegisterApi...
        /// </summary>
        /// <param name="request"></param>
        /// <param name="success"></param>
        /// <param name="failed"></param>
        /// <returns></returns>
        public async Task<AccessRegisterResponseModel> AccessRegisterApi(AccessRegisterRequestModel request, Action<object> success, Action<object> failed)
        {
            AccessRegisterResponseModel resmodel = new AccessRegisterResponseModel();
            try
            {
                var url = string.Format("{0}/api/appconnect/AccessRegister", WebServiceDetails.BaseUri);
                string randomGuid = Guid.NewGuid().ToString();
                var dic = new Dictionary<string, string>();
                //dic.Add("Content-Type", "Application/json");
                dic.Add("randomguid", randomGuid);
                dic.Add("hash", randomGuid + WebServiceDetails.AppKey + request.emailaddress + request.bvn + request.lastname + request.password);
                var result = _apiProvider.Post<AccessRegisterResponseModel, AccessRegisterRequestModel>(url, request, dic);
                var response = result.Result;
                AccessRegisterResponseModel objres = null;
                dynamic obj = "";
                AccessRegisterResponseModel reg = new AccessRegisterResponseModel();
                if (response.IsSuccessful != false)
                {
                    objres = JsonConvert.DeserializeObject<AccessRegisterResponseModel>(response.RawResult);
                    success.Invoke(objres);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    failed.Invoke(obj);
                }
            }
            catch (Exception exception)
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert("Something went wrong please try again.", "", "OK");
            }
            return resmodel;
        }
        /// <summary>
        /// To call AccessRegisterApi...
        /// </summary>
        /// <param name="request"></param>
        /// <param name="success"></param>
        /// <param name="failed"></param>
        /// <returns></returns>
        public async Task<AccessRegisterActivateResponseModel> AccessRegisterActivateApi(AccessRegisterActivateRequestModel request, Action<object> success, Action<object> failed)
        {
            AccessRegisterActivateResponseModel resmodel = new AccessRegisterActivateResponseModel();
            try
            {
                var url = string.Format("{0}/api/appconnect/AccessRegisterActivate", WebServiceDetails.BaseUri);
                string randomGuid = Guid.NewGuid().ToString();
                var dic = new Dictionary<string, string>();
                //dic.Add("Content-Type", "Application/json");
                dic.Add("randomguid", randomGuid);
                dic.Add("hash", randomGuid + WebServiceDetails.AppKey + request.usertoken + request.validatetoken);
                var result = _apiProvider.Post<AccessRegisterActivateResponseModel, AccessRegisterActivateRequestModel>(url, request, dic);
                var response = result.Result;
                AccessRegisterActivateResponseModel objres = null;
                dynamic obj = "";
                AccessRegisterActivateResponseModel reg = new AccessRegisterActivateResponseModel();
                if (response.IsSuccessful != false)
                {
                    objres = JsonConvert.DeserializeObject<AccessRegisterActivateResponseModel>(response.RawResult);
                    success.Invoke(objres);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    failed.Invoke(obj);
                }
            }
            catch (Exception exception)
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert("Something went wrong please try again.", "", "OK");
            }
            return resmodel;
        }


        #endregion

        #region Login
        public async Task<LoginResponseModel> AccessLoginApi(LoginRequestModel request, Action<object> success, Action<object> failed)
        {
            LoginResponseModel resmodel = new LoginResponseModel();
            try
            {
                var url = string.Format("{0}/api/appconnect/AccessLogin", WebServiceDetails.BaseUri);
                string randomGuid = Guid.NewGuid().ToString();
                var dic = new Dictionary<string, string>();
                //dic.Add("Content-Type", "Application/json");
                dic.Add("randomguid", randomGuid);
                dic.Add("hash", randomGuid + WebServiceDetails.AppKey + request.emailaddress + request.password);
                var result = _apiProvider.Post<LoginResponseModel, LoginRequestModel>(url, request, dic);
                var response = result.Result;
                LoginResponseModel objres = null;
                dynamic obj = "";
                LoginResponseModel reg = new LoginResponseModel();
                if (response.IsSuccessful != false)
                {
                    objres = JsonConvert.DeserializeObject<LoginResponseModel>(response.RawResult);
                    success.Invoke(objres);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    failed.Invoke(obj);
                }
            }
            catch (Exception exception)
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert("Something went wrong please try again.", "", "OK");
            }
            return resmodel;
        }
        #endregion

        #region Resetpassword
        /// <summary>
        /// To call AccessPasswordReminderApi...
        /// </summary>
        /// <param name="request"></param>
        /// <param name="success"></param>
        /// <param name="failed"></param>
        /// <returns></returns>
        public async Task<AccessPasswordReminderResponseModel> AccessPasswordReminderApi(AccessPasswordReminderRequestModel request, Action<object> success, Action<object> failed)
        {
            AccessPasswordReminderResponseModel resmodel = new AccessPasswordReminderResponseModel();
            try
            {
                var url = string.Format("{0}/api/appconnect/AccessPasswordReminder", WebServiceDetails.BaseUri);
                string randomGuid = Guid.NewGuid().ToString();
                var dic = new Dictionary<string, string>();
                //dic.Add("Content-Type", "Application/json");
                dic.Add("randomguid", randomGuid);
                dic.Add("hash", randomGuid + WebServiceDetails.AppKey + request.emailaddress);
                var result = _apiProvider.Post<AccessPasswordReminderResponseModel, AccessPasswordReminderRequestModel>(url, request, dic);
                var response = result.Result;
                AccessPasswordReminderResponseModel objres = null;
                dynamic obj = "";
                AccessPasswordReminderResponseModel reg = new AccessPasswordReminderResponseModel();
                if (response.IsSuccessful != false)
                {
                    objres = JsonConvert.DeserializeObject<AccessPasswordReminderResponseModel>(response.RawResult);
                    success.Invoke(objres);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    failed.Invoke(obj);
                }
            }
            catch (Exception exception)
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert("Something went wrong please try again.", "", "OK");
            }
            return resmodel;
        }
        /// <summary>
        /// To call AccessPasswordChangeApi...
        /// </summary>
        /// <param name="request"></param>
        /// <param name="success"></param>
        /// <param name="failed"></param>
        /// <returns></returns>
        public async Task<AccessPasswordChangeResponseModel> AccessPasswordChangeApi(AccessPasswordChangeRequestModel request, Action<object> success, Action<object> failed)
        {
            AccessPasswordChangeResponseModel resmodel = new AccessPasswordChangeResponseModel();
            try
            {
                var url = string.Format("{0}/api/appconnect/AccessPasswordChange", WebServiceDetails.BaseUri);
                string randomGuid = Guid.NewGuid().ToString();
                var dic = new Dictionary<string, string>();
                //dic.Add("Content-Type", "Application/json");
                dic.Add("randomguid", randomGuid);
                dic.Add("hash", randomGuid + WebServiceDetails.AppKey + request.emailaddress + request.validatetoken + request.password);
                var result = _apiProvider.Post<AccessPasswordChangeResponseModel, AccessPasswordChangeRequestModel>(url, request, dic);
                var response = result.Result;
                AccessPasswordChangeResponseModel objres = null;
                dynamic obj = "";
                AccessPasswordChangeResponseModel reg = new AccessPasswordChangeResponseModel();
                if (response.IsSuccessful != false)
                {
                    objres = JsonConvert.DeserializeObject<AccessPasswordChangeResponseModel>(response.RawResult);
                    success.Invoke(objres);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    failed.Invoke(obj);
                }
            }
            catch (Exception exception)
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert("Something went wrong please try again.", "", "OK");
            }
            return resmodel;
        }
        
        /// <summary>
        /// To call AccessPasswordChangeApi...
        /// </summary>
        /// <param name="request"></param>
        /// <param name="success"></param>
        /// <param name="failed"></param>
        /// <returns></returns>
        public async Task<AccessPasswordChangeResponseModel> AccessPasswordResendCodeApi(ResendCodeRequestModel request, Action<object> success, Action<object> failed) 
        {
            AccessPasswordChangeResponseModel resmodel = new AccessPasswordChangeResponseModel();
            try
            {
                var url = string.Format("{0}/api/appconnect/AccessPasswordResendCode", WebServiceDetails.BaseUri);
                string randomGuid = Guid.NewGuid().ToString();
                var dic = new Dictionary<string, string>();
                //dic.Add("Content-Type", "Application/json");
                dic.Add("randomguid", randomGuid);
                dic.Add("hash", randomGuid + WebServiceDetails.AppKey + request.emailaddress);
                var result = _apiProvider.Post<AccessPasswordChangeResponseModel, ResendCodeRequestModel>(url, request, dic);
                var response = result.Result;
                AccessPasswordChangeResponseModel objres = null;
                dynamic obj = JsonConvert.DeserializeObject<AccessPasswordChangeResponseModel>(response.RawResult);
                AccessPasswordChangeResponseModel reg = new AccessPasswordChangeResponseModel();
                if (response.IsSuccessful != false)
                {
                    objres = JsonConvert.DeserializeObject<AccessPasswordChangeResponseModel>(response.RawResult);
                    success.Invoke(objres);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    failed.Invoke(obj);
                }
            }
            catch (Exception exception)
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert("Something went wrong please try again.", "", "OK");
            }
            return resmodel;
        }

        #endregion

        #region LogOut
        /// <summary>
        /// To call Logout Api..
        /// </summary>
        /// <param name="request"></param>
        /// <param name="success"></param>
        /// <param name="failed"></param>
        /// <returns></returns>
        public async Task<AccessLogOutResponseModel> AccessLogOutApi(AccessLogOutRequestModel request, Action<object> success, Action<object> failed)
        {
            AccessLogOutResponseModel resmodel = new AccessLogOutResponseModel();
            try
            {
                var url = string.Format("{0}/api/appconnect/AccessLogOut", WebServiceDetails.BaseUri);
                string randomGuid = Guid.NewGuid().ToString();
                var dic = new Dictionary<string, string>();
                //dic.Add("Content-Type", "Application/json");
                dic.Add("randomguid", randomGuid);
                dic.Add("hash", randomGuid + WebServiceDetails.AppKey + request.usertoken + Helpers.Constants.LoginUserSecret);
                var result = _apiProvider.Post<AccessLogOutResponseModel, AccessLogOutRequestModel>(url, request, dic);
                var response = result.Result;
                AccessLogOutResponseModel objres = null;
                dynamic obj = "";
                AccessLogOutResponseModel reg = new AccessLogOutResponseModel();
                if (response.IsSuccessful != false)
                {
                    objres = JsonConvert.DeserializeObject<AccessLogOutResponseModel>(response.RawResult);
                    success.Invoke(objres);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    failed.Invoke(obj);
                }
            }
            catch (Exception exception)
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert("Something went wrong please try again.", "", "OK");
            }
            return resmodel;
        }
        #endregion

        #region Loan 
        /// <summary>
        /// To call LoanCreate Api..
        /// </summary>
        /// <param name="request"></param>
        /// <param name="success"></param>
        /// <param name="failed"></param>
        /// <returns></returns>
        public async Task<LoanCreateResponseModel> LoanCreateApi(LoanCreateRequestModel request, Action<object> success, Action<object> failed)
        {
            LoanCreateResponseModel resmodel = new LoanCreateResponseModel();
            try
            {
                var url = string.Format("{0}/api/appconnect/LoanCreate", WebServiceDetails.BaseUri);
                string randomGuid = Guid.NewGuid().ToString();
                var dic = new Dictionary<string, string>();
                //dic.Add("Content-Type", "Application/json");
                dic.Add("randomguid", randomGuid);
                dic.Add("hash", randomGuid + WebServiceDetails.AppKey + request.usertoken + Helpers.Constants.LoginUserSecret + request.employercode + request.loanamount);
                var result = _apiProvider.Post<LoanCreateResponseModel, LoanCreateRequestModel>(url, request, dic);
                var response = result.Result;
                LoanCreateResponseModel objres = null;
                dynamic obj = "";
                LoanCreateResponseModel reg = new LoanCreateResponseModel();
                if (response.IsSuccessful != false)
                {
                    objres = JsonConvert.DeserializeObject<LoanCreateResponseModel>(response.RawResult);
                    success.Invoke(objres);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    failed.Invoke(obj);
                }
            }
            catch (Exception exception)
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert("Something went wrong please try again.", "", "OK");
            }
            return resmodel;
        }

        /// <summary>
        /// To Call Loan Search Api
        /// </summary>
        /// <param name="request"></param>
        /// <param name="success"></param>
        /// <param name="failed"></param>
        /// <returns></returns>
        public async Task<LoanSearchResponseModel> LoanSearchApi(LoanSearchRequestModel request, Action<object> success, Action<object> failed)
        {
            LoanSearchResponseModel resmodel = new LoanSearchResponseModel();
            try
            {
                var url = string.Format("{0}/api/appconnect/LoanSearch", WebServiceDetails.BaseUri);
                string randomGuid = Guid.NewGuid().ToString();
                var dic = new Dictionary<string, string>();
                //dic.Add("Content-Type", "Application/json");
                dic.Add("randomguid", randomGuid);
                dic.Add("hash", randomGuid + WebServiceDetails.AppKey + request.usertoken + Helpers.Constants.LoginUserSecret + request.loannumber);
                var result = _apiProvider.Post<LoanSearchResponseModel, LoanSearchRequestModel>(url, request, dic);
                var response = result.Result;
                LoanSearchResponseModel objres = null;
                dynamic obj = "";
                LoanSearchResponseModel reg = new LoanSearchResponseModel();
                if (response.IsSuccessful != false)
                {
                    objres = JsonConvert.DeserializeObject<LoanSearchResponseModel>(response.RawResult);
                    success.Invoke(objres);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    failed.Invoke(obj);
                }
            }
            catch (Exception exception)
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert("Something went wrong please try again.", "", "OK");
            }
            return resmodel;
        }

        /// <summary>
        /// To Call All Loan Api...
        /// </summary>
        /// <param name="request"></param>
        /// <param name="success"></param>
        /// <param name="failed"></param>
        /// <returns></returns> 
        public async Task<AllLoanResponseModel> GetAllLoansApi(AllLoanRequestModel request, Action<object> success, Action<object> failed)
        {
            AllLoanResponseModel resmodel = new AllLoanResponseModel();
            try
            {
                var url = string.Format("{0}/api/appconnect/LoanSearch", WebServiceDetails.BaseUri);
                string randomGuid = Guid.NewGuid().ToString();
                var dic = new Dictionary<string, string>();
                //dic.Add("Content-Type", "Application/json");
                dic.Add("randomguid", randomGuid);
                dic.Add("hash", randomGuid + WebServiceDetails.AppKey + request.usertoken + Helpers.Constants.LoginUserSecret + Helpers.Settings.GeneralLoanNumber);
                var result = _apiProvider.Post<AllLoanResponseModel, AllLoanRequestModel>(url, request, dic);
                var response = result.Result;
                AllLoanResponseModel objres = null;
                dynamic obj = "";
                AllLoanResponseModel reg = new AllLoanResponseModel();
                if (response.IsSuccessful != false)
                {
                    objres = JsonConvert.DeserializeObject<AllLoanResponseModel>(response.RawResult);
                    success.Invoke(objres);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    failed.Invoke(obj);
                }
            }
            catch (Exception exception)
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert("Something went wrong please try again.", "", "OK");
            }
            return resmodel;
        }

        /// <summary>
        /// To Call Loan Respond Api
        /// </summary>
        /// <param name="request"></param>
        /// <param name="success"></param>
        /// <param name="failed"></param>
        /// <returns></returns>
        public async Task<LoanRespondResponseModel> LoanRespondApi(LoanRespondRequestModel request, Action<object> success, Action<object> failed)
        {
            LoanRespondResponseModel resmodel = new LoanRespondResponseModel();
            try
            {
                var url = string.Format("{0}/api/appconnect/LoanRespond", WebServiceDetails.BaseUri);
                string randomGuid = Guid.NewGuid().ToString();
                var dic = new Dictionary<string, string>();
                //dic.Add("Content-Type", "Application/json");
                dic.Add("randomguid", randomGuid);
                dic.Add("hash", randomGuid + WebServiceDetails.AppKey + request.usertoken + Helpers.Constants.LoginUserSecret + request.loannumber + request.action);
                var result = _apiProvider.Post<LoanRespondResponseModel, LoanRespondRequestModel>(url, request, dic);
                var response = result.Result;
                LoanRespondResponseModel objres = null;
                dynamic obj = "";
                LoanRespondResponseModel reg = new LoanRespondResponseModel();
                if (response.IsSuccessful != false)
                {
                    objres = JsonConvert.DeserializeObject<LoanRespondResponseModel>(response.RawResult);
                    success.Invoke(objres);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    failed.Invoke(obj);
                }
            }
            catch (Exception exception)
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert("Something went wrong please try again.", "", "OK");
            }
            return resmodel;
        }
        #endregion

        #region Payment 
        /// <summary>
        /// To Call Payment Create Api...
        /// </summary>
        /// <param name="request"></param>
        /// <param name="success"></param>
        /// <param name="failed"></param>
        /// <returns></returns>
        public async Task<PaymentCreateResponseModel> PaymentCreateApi(PaymentCreateRequestModel request, Action<object> success, Action<object> failed)
        {
            PaymentCreateResponseModel resmodel = new PaymentCreateResponseModel();
            try
            {
                var url = string.Format("{0}/api/appconnect/PaymentCreate", WebServiceDetails.BaseUri);
                string randomGuid = Guid.NewGuid().ToString();
                var dic = new Dictionary<string, string>();
                //dic.Add("Content-Type", "Application/json");
                dic.Add("randomguid", randomGuid);
                dic.Add("hash", randomGuid + WebServiceDetails.AppKey + request.usertoken + Helpers.Constants.LoginUserSecret + request.loannumber + request.loanschedulenumber);
                var result = _apiProvider.Post<PaymentCreateResponseModel, PaymentCreateRequestModel>(url, request, dic);
                var response = result.Result;
                PaymentCreateResponseModel objres = null;  
                dynamic obj = "";
                PaymentCreateResponseModel reg = new PaymentCreateResponseModel();
                if (response.IsSuccessful != false)
                {
                    objres = JsonConvert.DeserializeObject<PaymentCreateResponseModel>(response.RawResult);
                    success.Invoke(objres);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    failed.Invoke(obj);
                }
            }
            catch (Exception exception)
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert("Something went wrong please try again.", "", "OK");
            }
            return resmodel;
        }

        /// <summary>
        /// To Call Payment Search Api...
        /// </summary>
        /// <param name="request"></param>
        /// <param name="success"></param>
        /// <param name="failed"></param>
        /// <returns></returns>
        public async Task<PaymentSearchResponseModel> PaymentSearchApi(PaymentSearchRequestModel request, Action<object> success, Action<object> failed)
        {
            PaymentSearchResponseModel resmodel = new PaymentSearchResponseModel();
            try
            {
                var url = string.Format("{0}/api/appconnect/PaymentSearch", WebServiceDetails.BaseUri);
                string randomGuid = Guid.NewGuid().ToString();
                var dic = new Dictionary<string, string>();
                //dic.Add("Content-Type", "Application/json");
                dic.Add("randomguid", randomGuid);
                dic.Add("hash", randomGuid + WebServiceDetails.AppKey + request.usertoken + Helpers.Constants.LoginUserSecret);
                var result = _apiProvider.Post<PaymentSearchResponseModel, PaymentSearchRequestModel>(url, request, dic); 
                var response = result.Result;
                PaymentSearchResponseModel objres = null;
                dynamic obj = "";
                PaymentSearchResponseModel reg = new PaymentSearchResponseModel();
                if (response.IsSuccessful != false)
                {
                    objres = JsonConvert.DeserializeObject<PaymentSearchResponseModel>(response.RawResult);
                    success.Invoke(objres); 
                } 
                else
                {
                    UserDialogs.Instance.HideLoading();
                    failed.Invoke(obj);
                }
            }
            catch (Exception exception)
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert("Something went wrong please try again.", "", "OK");
            }
            return resmodel;
        }
        #endregion

        #region Profile
        /// <summary>
        /// To call Profile Get Api
        /// </summary>
        /// <param name="request"></param>
        /// <param name="success"></param>
        /// <param name="failed"></param>
        /// <returns></returns>
        public async Task<ProfileGetResponseModel> ProfileGetApi(ProfileGetRequestModel request, Action<object> success, Action<object> failed)
        {
            ProfileGetResponseModel resmodel = new ProfileGetResponseModel();
            try
            {
                var url = string.Format("{0}/api/appconnect/ProfileGet", WebServiceDetails.BaseUri);
                string randomGuid = Guid.NewGuid().ToString();
                var dic = new Dictionary<string, string>();
                //dic.Add("Content-Type", "Application/json");
                dic.Add("randomguid", randomGuid);
                dic.Add("hash", randomGuid + WebServiceDetails.AppKey + request.usertoken + Helpers.Constants.LoginUserSecret);
                var result = _apiProvider.Post<ProfileGetResponseModel, ProfileGetRequestModel>(url, request, dic);
                var response = result.Result;
                Helpers.Settings.GeneralProfileDataJSON = response.RawResult;
                ProfileGetResponseModel objres = null;
                dynamic obj = "";
                ProfileGetResponseModel reg = new ProfileGetResponseModel();
                if (response.IsSuccessful != false)
                {
                    objres = JsonConvert.DeserializeObject<ProfileGetResponseModel>(response.RawResult);
                    success.Invoke(objres);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    failed.Invoke(obj);
                }
            }
            catch (Exception exception)
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert("Something went wrong please try again.", "", "OK");
            }
            return resmodel;
        }

        public async Task<ProfileSaveResponseModel> ProfileSaveApi(ProfileSaveRequestModel request, Action<object> success, Action<object> failed)
        {
            ProfileSaveResponseModel resmodel = new ProfileSaveResponseModel();
            try
            {
                var url = string.Format("{0}/api/appconnect/ProfileSave", WebServiceDetails.BaseUri); 
                string randomGuid = Guid.NewGuid().ToString(); 
                var dic = new Dictionary<string, string>();
                //dic.Add("Content-Type", "Application/json");
                dic.Add("randomguid", randomGuid);
                dic.Add("hash", randomGuid + WebServiceDetails.AppKey + request.usertoken + Helpers.Constants.LoginUserSecret + Helpers.Constants.UserEmailAddress + Helpers.Constants.UserLastname);
                var result = _apiProvider.Post<ProfileSaveResponseModel, ProfileSaveRequestModel>(url, request, dic); 
                var response = result.Result;
                ProfileSaveResponseModel objres = null;
                dynamic obj = "";
                ProfileSaveResponseModel reg = new ProfileSaveResponseModel(); 
                if (response.IsSuccessful != false)
                {
                    objres = JsonConvert.DeserializeObject<ProfileSaveResponseModel>(response.RawResult);
                    success.Invoke(objres);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    failed.Invoke(obj);
                }
            }
            catch (Exception exception)
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert("Something went wrong please try again.", "", "OK");
            }
            return resmodel;
        }
        #endregion
    }
}
