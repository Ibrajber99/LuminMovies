using MovieDataBase.Models;
using MoviesDataBase.Models.Models.Profile_related_models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDataBase.ClientAPI
{
    public interface IProfileClient
    {
        Task<ProfileModel> GetProfile();

        Task<MoviesResponseModel> GetWatchList();

        Task<MoviesResponseModel> GetFavorites();

        Task<MoviesResponseModel> GetRated();

        Task<bool> AddToWatchList(AddToWatchListRequest request);

        Task<bool> AddToFavorites(AddToFavoriteRequest request);

        Task<bool> AddMovieRating(string movieId,decimal rating);

        void SetSession(string sessionId);

        bool IsSessionEmpty();
    }
}
