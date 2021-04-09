using MovieDataBase.Models;
using MoviesDataBase.Models.Models.Movie_related_models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDataBase.LocalClientAPI
{
    public interface IMovieClient : IBaseClient<Movie>
    {
        Task<MoviesResponseModel> GetNowPlaying(int page = 1);

        Task<MoviesResponseModel> GetPopular(int page = 1);

        Task<MoviesResponseModel> GetTopRated(int page = 1);

        Task<MoviesResponseModel> GetUpcoming(int page = 1);

        Task<FullMovieResponseModel> GetMovie(int id);

        Task<MovieReviewResponseModel> GetMovieReview(int id);

    }
}
