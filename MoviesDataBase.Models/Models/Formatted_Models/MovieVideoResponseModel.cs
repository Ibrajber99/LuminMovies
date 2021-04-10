using MoviesDataBase.Models.Models.Movie_related_models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesDataBase.Models.Models.Formatted_Models
{
    public class MovieVideoResponseModel
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("results")]
        public List<MovieVideo> Results { get; set; }
    }
}
