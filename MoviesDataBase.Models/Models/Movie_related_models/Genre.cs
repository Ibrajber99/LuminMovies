﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesDataBase.Models.Models
{
    public class Genre
    { 
        [JsonProperty("id")]
        public string GenreId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
