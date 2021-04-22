using MoviesDataBase.Models.Models.Authentication_related_models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDataBase.ClientAPI
{
    public interface IAuthenticationClient
    {
        Task<ReqTokenResponseModel> GetRequestToken();

        Task<SessionResponseModel> GetSession(string token);

        string GetRedirectPath(string token);
    }
}
