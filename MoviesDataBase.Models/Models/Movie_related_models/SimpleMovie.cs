using MoviesDataBase.Models.Models.Movie_related_models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesDataBase.Models.Models
{
    public class SimpleMovie : Movie
    {
        [JsonProperty("genre_ids")]
        public List<string> Genres { get; set; }
    }
}
