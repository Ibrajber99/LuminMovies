using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesDatabase.Web.Utils.CookieManager
{
    public interface ICookiesManager
    {
        void AddCookie(string key, string value);

        KeyValuePair<string,string> GetCookie(string key);

    }
}
