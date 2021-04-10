using MoviesDataBase.Models.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDataBase.Models
{
    public class MoviesResponseModel
    {
        public MoviesResponseModel()
        {
            Result = new List<SimpleMovie>();
        }

        [JsonProperty("page")]
        public int CurrentPage { get; set; }

        [JsonProperty("results")]
        public List<SimpleMovie> Result { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }

        [JsonProperty("total_results")]
        public int TotalResults { get; set; }
    }
}
