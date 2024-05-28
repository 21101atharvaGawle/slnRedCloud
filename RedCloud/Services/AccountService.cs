using MvcApiCallingService.Helpers.ApiHelper;
using RedCloud.Domain.Comman;
using RedCloud.Interface;
using RedCloud.Models.Account;

namespace RedCloud.Service
{
    public class AccountService : IAccountService
    {
        private readonly IApiClient<UserVM> _apiClientLogin;
        //private readonly IApiClient<Register> _apiClientRegister;
        private readonly ILogger<AccountService> _logger;


        public AccountService(IApiClient<UserVM> apiClientLogin, ILogger<AccountService> logger)
        {
            _apiClientLogin = apiClientLogin;
            _logger = logger;
            //_apiClientRegister = apiClientRegister;
        }


        public async Task<UserVM> Login(Models.Account.Login login)
        {
            _logger.LogInformation("LoginAccount Service initiated");
            var response = await _apiClientLogin.PostAuthAsync("Account", login);
            if (response == null)
            {
                _logger.LogInformation("LoginAccount Service conpleted");
                return response;
            }

            _logger.LogInformation("LoginAccount Service conpleted");
            return response;
        }


        //public async Task<Register> Register(Register register)
        //{
        //    _logger.LogInformation("RegisterAccount Service initiated");
        //    var response = await _apiClientRegister.PostAuthAsync("Account/register", register);
        //    if (response == null)
        //    {
        //        //Register registerResponse = new Register();
        //        register.Message = $" UserName {register.UserName} or Email {register.Email} already exist";
        //        return register;
        //    }
        //    _logger.LogInformation("RegisterAccount Service conpleted");
        //    return response;

        //}


    }
}
