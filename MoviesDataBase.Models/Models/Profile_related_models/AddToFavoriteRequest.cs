using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesDataBase.Models.Models.Profile_related_models
{
    public class AddToFavoriteRequest
    {
        public AddToFavoriteRequest()
        {
            MediaType = "movie";
            Favorite = true;
        }

        [JsonProperty("media_type")]
        public string MediaType { get; private set; }

        [JsonProperty("media_id")]
        public int MediaId { get; set; }

        [JsonProperty("favorite")]
        public bool Favorite { get; private set; }


    }
}
