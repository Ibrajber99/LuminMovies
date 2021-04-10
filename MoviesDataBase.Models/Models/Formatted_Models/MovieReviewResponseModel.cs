using MoviesDataBase.Models.Models.Movie_related_models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDataBase.Models
{
    public class MovieReviewResponseModel
    {
        public MovieReviewResponseModel()
        {
            Reviews = new List<MovieReview>();
        }

        [JsonProperty("id")]
        public int MovieId { get; set; }

        [JsonProperty("page")]
        public int CurrentPage { get; set; }

        [JsonProperty("results")]
        public List<MovieReview> Reviews { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }

        [JsonProperty("total_results")]
        public int TotalResults { get; set; }
    }
}
