using MoviesDataBase.Models.Models.Movie_related_models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesDataBase.Models.Models.Formatted_Models
{
    public class MovieCastResponseModel
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("cast")]
        public List<Cast> Cast { get; set; }
    }
}
