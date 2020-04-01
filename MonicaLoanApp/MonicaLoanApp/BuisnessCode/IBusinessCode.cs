using MonicaLoanApp.Models;
using MonicaLoanApp.Models.Loan;
using MonicaLoanApp.Models.Payments;
using System;
using System.Threading.Tasks;

namespace MonicaLoanApp.BuisnessCode
{
    public interface IBusinessCode
    {
        //StaticDataSearch Api ...
        Task<StaticDataSearchResponseModel> StaticDataSearchApi(StaticDataSearchRequestModel request, Action<object> success, Action<object> failed);

        #region Register Apis
        //AccessRegisterPreValidate 
        Task<AccessRegisterPreValidateResponseModel> AccessRegisterPreValidateApi(AccessRegisterPreValidateRequestModel request, Action<object> success, Action<object> failed);

        //AccessRegister 
        Task<AccessRegisterResponseModel> AccessRegisterApi(AccessRegisterRequestModel request, Action<object> success, Action<object> failed);
        //AccessRegisterActivateApi 
        Task<AccessRegisterActivateResponseModel> AccessRegisterActivateApi(AccessRegisterActivateRequestModel request, Action<object> success, Action<object> failed);

        #endregion

        #region Login
        //Login Api
        Task<LoginResponseModel> AccessLoginApi(LoginRequestModel request, Action<object> success, Action<object> failed);
        #endregion

        #region resetpassword
        //StaticDataSearch Api ...
        Task<AccessPasswordReminderResponseModel> AccessPasswordReminderApi(AccessPasswordReminderRequestModel request, Action<object> success, Action<object> failed);
        //StaticDataSearch Api ...
        Task<AccessPasswordChangeResponseModel> AccessPasswordChangeApi(AccessPasswordChangeRequestModel request, Action<object> success, Action<object> failed);
        Task<AccessPasswordChangeResponseModel> AccessPasswordResendCodeApi(ResendCodeRequestModel request, Action<object> success, Action<object> failed);
        #endregion

        #region Logout
        // Logout Api...
        Task<AccessLogOutResponseModel> AccessLogOutApi(AccessLogOutRequestModel request, Action<object> success, Action<object> failed);
        #endregion

        #region Loan Create Api
        //LoanCreate Api...
        Task<LoanCreateResponseModel> LoanCreateApi(LoanCreateRequestModel request, Action<object> success, Action<object> failed);
        //Profile Get Api...
        #endregion

        #region Profile
        //get Profile data Api..
        Task<ProfileGetResponseModel> ProfileGetApi(ProfileGetRequestModel request, Action<object> success, Action<object> failed);
        Task<ProfileSaveResponseModel> ProfileSaveApi(ProfileSaveRequestModel request, Action<object> success, Action<object> failed);

        //Save Profile Data...
        // Task<SaveDataResponseModel> ProfileSaveApi(SaveDataResponseModel request, Action<object> succss, Action<object> failed);
        #endregion

        #region LoanSearch 
        Task<LoanSearchResponseModel> LoanSearchApi(LoanSearchRequestModel request, Action<object> success, Action<object> failed);
        Task<AllLoanResponseModel> GetAllLoansApi(AllLoanRequestModel request, Action<object> success, Action<object> failed);
        Task<LoanRespondResponseModel> LoanRespondApi(LoanRespondRequestModel request, Action<object> success, Action<object> failed);
        #endregion

        #region Payment 
        Task<PaymentCreateResponseModel> PaymentCreateApi(PaymentCreateRequestModel request, Action<object> success, Action<object> failed);
        Task<PaymentSearchResponseModel> PaymentSearchApi(PaymentSearchRequestModel request, Action<object> success, Action<object> failed);
        #endregion
    }

}