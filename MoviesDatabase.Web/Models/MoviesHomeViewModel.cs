using MovieDataBase.Models;
using MoviesDataBase.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesDatabase.Web.Models
{
    public class MoviesHomeViewModel
    {
        public MoviesHomeViewModel()
        {
            Upcoming = new MoviesResponseModel();
            NowPlaying = new MoviesResponseModel();
            TopRated = new MoviesResponseModel();
            Popular = new MoviesResponseModel();
        }

        public MoviesResponseModel Upcoming { get; set; }

        public MoviesResponseModel NowPlaying { get; set; }

        public MoviesResponseModel TopRated { get; set; }

        public MoviesResponseModel Popular { get; set; }
    }
}
