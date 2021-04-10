using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesDataBase.Models.Models.Formatted_Models
{
    public class MovieGenresResponseModel
    {
        [JsonProperty("genres")]
        public List<Genre> Genres { get; set; }
    }
}
