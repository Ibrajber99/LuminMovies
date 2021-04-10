using MoviesDataBase.Models.Models.Movie_related_models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesDataBase.Models.Models
{
    public class FullMovie : Movie
    {
        [JsonProperty("revenue")]
        [DisplayFormat(DataFormatString = "{C}")]
        public string Revenue { get; set; }

        [JsonProperty("budget")]
        [DisplayFormat(DataFormatString = "{C}")]
        public string Budget { get;set; }

        [JsonProperty("runtime")]
        public int MovieLength { get; set; }

        [JsonProperty("status")]
        public string MovieStatus { get; set; }

        [JsonProperty("tagline")]
        public string MovieTagline { get; set; }

        [JsonProperty("genres")]
        public List<Genre> Genres { get; set; }
    }
}
