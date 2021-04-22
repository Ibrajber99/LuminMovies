using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesDataBase.Models.Models.Profile_related_models
{
    public class AddToWatchListRequest
    {
        public AddToWatchListRequest()
        {
            MediaType = "movie";
            WatchList = true;
        }

        [JsonProperty("media_type")]
        public string MediaType { get; private set; }

        [JsonProperty("media_id")]
        public int MediaId { get; set; }

        [JsonProperty("watchlist")]
        public bool WatchList { get; private set; }

    }
}
