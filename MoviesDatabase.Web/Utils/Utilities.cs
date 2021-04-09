using Microsoft.Extensions.Configuration;
using MoviesDataBase.Models.Models;
using MoviesDataBase.Models.Models.Movie_related_models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesDatabase.Web.Utils
{
    public class Utilities
    {
        private IConfiguration Configuration;

        private string IMAGE_PATH;

        private string YOUTUBE_PATH;

        private const string IMAGE_EXTENSION = ".svg";

        public Utilities(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
            IMAGE_PATH = this.Configuration.GetSection("APIImagePath").Value;
            YOUTUBE_PATH = this.Configuration.GetSection("YoutubeVideoPath").Value;
           
        }

        public void SetMovieVideosUrl(List<MovieVideo> videos)
        {
            foreach (var video in videos)
            {
                video.Key = YOUTUBE_PATH + video.Key;
            }
        }

        public void SetMoviesImageUrl(List<SimpleMovie> movies)
        {
            foreach (var movie in movies)
            {
                SetMovieImageUrl(movie);
            }
        }

        public void SetMovieImageUrl(Movie movie)
        {
            movie.backDropPath = IMAGE_PATH + movie.backDropPath;
            movie.PosterPath = IMAGE_PATH + movie.PosterPath;
        }

        public void SetCastsImageUrl(List<Cast> casts)
        {
            foreach (var cast in casts)
            {
                SetCastImageUrl(cast);
            }
        }

        public void SetCastImageUrl(Cast cast)
        {
            cast.ProfilePath = IMAGE_PATH + cast.ProfilePath;
        }
    }
}
