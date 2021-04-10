using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesDataBase.Models.Models.Movie_related_models
{
    public class Cast
    {
        [JsonProperty("adult")]
        public bool Adult { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("known_for_department")]
        public string KnownFor { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("original_name")]
        public string OriginalName { get; set; }

        [JsonProperty("popularity")]
        public string Popularity { get; set; }

        [JsonProperty("profile_path")]
        public string ProfilePath { get; set; }

        [JsonProperty("cast_id")]
        public int CastId { get; set; }

        [JsonProperty("character")]
        public string Character { get; set; }
    }
}
