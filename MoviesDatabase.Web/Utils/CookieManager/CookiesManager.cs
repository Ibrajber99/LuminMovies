using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesDatabase.Web.Utils.CookieManager
{
    public class CookiesManager : ICookiesManager
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CookiesManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void AddCookie(string key, string value)
        {
            try
            {
                _httpContextAccessor
                    .HttpContext
                    .Response.Cookies.Append(key, value);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public KeyValuePair<string, string> GetCookie(string key)
        {
            try
            {
                var cookieRes = _httpContextAccessor
                    .HttpContext
                    .Request
                    .Cookies
                    .FirstOrDefault(i => i.Key == key);


                return cookieRes;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
