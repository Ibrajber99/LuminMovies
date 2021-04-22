using MovieDataBase.Models;
using MoviesDataBase.Models.Models.Profile_related_models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesDatabase.Web.Models
{
    public class ProfileViewModel
    {  
        public ProfileModel Profile { get; set; }

        public MoviesResponseModel WatchList { get; set; }

        public MoviesResponseModel Favorites { get; set; }

        public MoviesResponseModel Rated { get; set; }

    }
}
