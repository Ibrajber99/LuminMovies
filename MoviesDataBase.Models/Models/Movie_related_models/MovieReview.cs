using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesDataBase.Models.Models.Movie_related_models
{
    public class MovieReview
    {

        [JsonProperty("author")]
        public string AuthorName { get; set; }


        [JsonProperty("content")]
        public string Content { get; set; }


        [JsonProperty("created_at")]
        public DateTime ReviewedCreatedOn { get; set; }


        [JsonProperty("id")]
        public string ReviewId { get; set; }


        [JsonProperty("updated_at")]
        public DateTime ReviewedUpdatedOn { get; set; }


        [JsonProperty("url")]
        public string ReviewUrlPath { get; set; }
    }
}
