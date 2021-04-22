using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieDataBase.ClientAPI;
using MoviesDatabase.Web.Models;
using MoviesDatabase.Web.Utils.CookieManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesDatabase.Web.Controllers
{
    public class AuthenticationController : Controller
    {
        private const string ERROR_PAGE_PATH = "Error";
        private const string TOKEN_VAL = "TOKEN";
        private const string SESSION_VAL = "SESSIONID";


        private readonly IAuthenticationClient _authClient;
        private readonly ICookiesManager _cookiesManager;
        private readonly ErrorViewModel _errorVM;

        public AuthenticationController(IAuthenticationClient authClient,
            ICookiesManager cookiesManager, ErrorViewModel errorVM)
        {
            _authClient = authClient;
            _cookiesManager = cookiesManager;
            _errorVM = errorVM;
        }

        public async Task<ActionResult> Index()
        {
            try
            {
                var response = await _authClient.GetRequestToken();

                var redirectPath = _authClient.GetRedirectPath(response.Token);

                _cookiesManager.AddCookie(TOKEN_VAL, response.Token);


                return Redirect(redirectPath);
            }
            catch (Exception ex)
            {
                _errorVM.RequestId = ex.Message;

                return View(ERROR_PAGE_PATH, _errorVM);
            }
        }

       public async Task<ActionResult> TokenRedirectApproval()
       {

            try
            {
                var token = _cookiesManager.GetCookie(TOKEN_VAL);

                var response = await _authClient.GetSession(token.Value);

                _cookiesManager.AddCookie(SESSION_VAL, response.SessionID);

                return RedirectToAction("Index", "Profile");
            }
            catch (Exception ex)
            {
                _errorVM.RequestId = ex.Message;

                return View(ERROR_PAGE_PATH, _errorVM);
            }
        }
    }

}
