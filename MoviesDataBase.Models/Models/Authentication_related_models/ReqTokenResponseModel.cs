using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesDataBase.Models.Models.Authentication_related_models
{
    public class ReqTokenResponseModel
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        
        [JsonProperty("expires_at")]
        public string ExpiresAt { get; set; }


        [JsonProperty("request_token")]
        public string Token { get; set; }
    }
}
