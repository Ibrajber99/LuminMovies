using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesDataBase.Models.Models.Movie_related_models
{
    public abstract class Movie
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("original_title")]
        public string MovieTitle { get; set; }

        [JsonProperty("original_language")]
        public string MovieLanguage { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("popularity")]
        public decimal Popularity { get; set; }

        [JsonProperty("poster_path")]
        public string PosterPath { get; set; }

        [JsonProperty("release_date")]
        public string ReleaseDate { get; set; }

        [JsonProperty("vote_average")]
        public decimal VoteAverage { get; set; }

        [JsonProperty("vote_count")]
        public int VoteCount { get; set; }

        [JsonProperty("adult")]
        public bool Adult { get; set; }

        [JsonProperty("backdrop_path")]
        public string backDropPath { get; set; }// Image maybe ? dont know yet
    }
}
