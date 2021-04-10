using MovieDataBase.Models;
using MoviesDataBase.Models.Models.Formatted_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesDatabase.Web.Models
{
    public class MovieDetailsViewModel
    {
        public MovieDetailsViewModel()
        {
            Result = new FullMovieResponseModel();
            Videos = new MovieVideoResponseModel();
            Reviews = new MovieReviewResponseModel();
            Recommendations = new MoviesResponseModel();
            MovieCast = new MovieCastResponseModel();
        }

        public FullMovieResponseModel Result { get; set; }

        public MovieVideoResponseModel Videos { get; set; }

        public MovieReviewResponseModel Reviews { get; set; }

        public MoviesResponseModel Recommendations { get; set; }

        public MovieCastResponseModel MovieCast { get; set; }

    }
}
