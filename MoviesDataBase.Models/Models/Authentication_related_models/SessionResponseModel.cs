using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesDataBase.Models.Models.Authentication_related_models
{
    public class SessionResponseModel
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("session_id")]        
        public string SessionID { get; set; }
    }
}
