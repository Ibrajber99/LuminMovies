﻿using Microsoft.AspNetCore.Mvc;
using MovieDataBase.ClientAPI;
using MoviesDatabase.Web.Models;
using MoviesDatabase.Web.Utils;
using MoviesDatabase.Web.Utils.CookieManager;
using System;
using System.Threading.Tasks;

namespace MoviesDatabase.Web.Controllers
{
    public class HomeController : Controller
    {
        private const string ERROR_PAGE_PATH = "Error";
        private const string SESSION_VAL = "SESSIONID";

        private readonly IMovieClient _client;
        private readonly ICookiesManager _cookiesManager;
        private readonly IProfileClient _profileClient;

        private readonly Utilities _utils;
        private readonly MoviesHomeViewModel _homeModel;
        private readonly MovieSearchViewModel _searchModel;
        private readonly MoviesByGenreViewModel _movieGenereModel;
        private readonly MoviesByOptionsViewModel _moviesByOptionModel;
        private readonly MovieDetailsViewModel _movieDetailsModel;
        private readonly ErrorViewModel _errorVM;

        public HomeController(
            IMovieClient client,
            ICookiesManager cookiesManager,
            IProfileClient profileClient,
            Utilities utils,
            MoviesHomeViewModel homeModel,
            MovieSearchViewModel searchModel,
            MoviesByGenreViewModel movieGenereModel,
            MoviesByOptionsViewModel moviesByOptionModel,
            MovieDetailsViewModel movieDetailsModel,
            ErrorViewModel errorVM)
        {
            _client = client;
            _cookiesManager = cookiesManager;
            _profileClient = profileClient;
            _homeModel = homeModel;
            _searchModel = searchModel;
            _movieGenereModel = movieGenereModel;
            _moviesByOptionModel =  moviesByOptionModel;
            _movieDetailsModel = movieDetailsModel;
            _utils = utils;
            _errorVM = errorVM;

            var sessionId = _cookiesManager.GetCookie(SESSION_VAL);
            _profileClient.SetSession(sessionId.Value);
        }


        public async Task<IActionResult> Index()
        {
            try
            {
                var upcomingAsync = _client.GetUpcoming();
                var nowPlayingAsync = _client.GetNowPlaying();
                var topRatedAsync = _client.GetTopRated();
                var popularAsync = _client.GetPopular();
               
                await Task.WhenAll(upcomingAsync, nowPlayingAsync,
                    topRatedAsync, popularAsync);
               
                _homeModel.Upcoming = upcomingAsync.Result;
                _homeModel.NowPlaying = nowPlayingAsync.Result;
                _homeModel.TopRated = topRatedAsync.Result;
                _homeModel.Popular = popularAsync.Result;
               
                _utils.SetMoviesImageUrl(_homeModel.Upcoming.Result);
                _utils.SetMoviesImageUrl(_homeModel.NowPlaying.Result);
                _utils.SetMoviesImageUrl(_homeModel.TopRated.Result);
                _utils.SetMoviesImageUrl(_homeModel.Popular.Result);


                return View(_homeModel);
            }
            catch (Exception ex)
            {
                _errorVM.RequestId = ex.Message;

                return View(ERROR_PAGE_PATH, _errorVM);
            }

        }

        public async Task<IActionResult> MovieSearch(string searchQuery, int page =1)
        {
            try
            {

               if (string.IsNullOrEmpty(searchQuery))
                    return RedirectToAction(nameof(Index));
               
                var searchResult = await _client.GetMovieSearch(searchQuery,page);
               
               _utils.SetMoviesImageUrl(searchResult.Result);
               
               _searchModel.MovieResponse = searchResult;
               _searchModel.Query = searchQuery;
               
               
               return View(_searchModel);
            }
            catch (Exception ex)
            {
                _errorVM.RequestId = ex.Message;

                return View(ERROR_PAGE_PATH, _errorVM);
            }
        }

        public async Task<IActionResult> GetMoviesGenre(int genreID, string genreName, int page =1)
        {
            try
            {
                var moviesByGenre = await _client.GetMoviesByGenre(genreID, page);
                _utils.SetMoviesImageUrl(moviesByGenre.Result);

                _movieGenereModel.GenreId = genreID;
                _movieGenereModel.MovieResponse = moviesByGenre;
                _movieGenereModel.GenreName = genreName;


                return View(_movieGenereModel);
            }
            catch (Exception ex)
            {
                _errorVM.RequestId = ex.Message;

                return View(ERROR_PAGE_PATH, _errorVM);
            }
        }

        public async Task<IActionResult> GetMoviesByOption(string optionId, string optionName, int page = 1)
        {
            try
            {
                object movieOptionVal;
                Enum.TryParse(typeof(MoviesOptions), optionId, out movieOptionVal);
                
                
                if (movieOptionVal != null)
                {


                    _moviesByOptionModel.OptionType = (MoviesOptions)movieOptionVal;

                    _moviesByOptionModel.OptionName = optionName;
                
                   switch (_moviesByOptionModel.OptionType)
                   {
                       case MoviesOptions.UPCOMING:
                            _moviesByOptionModel.MovieResponse = await _client.GetUpcoming(page);
                           break;
                       case MoviesOptions.NOW_PLAYING:
                            _moviesByOptionModel.MovieResponse = await _client.GetNowPlaying(page);
                           break;
                       case MoviesOptions.TOP_RATED:
                            _moviesByOptionModel.MovieResponse = await _client.GetTopRated(page);
                           break;
                       case MoviesOptions.POPULAR:
                            _moviesByOptionModel.MovieResponse = await _client.GetPopular(page);
                           break;
                       default:
                            _moviesByOptionModel.MovieResponse = await _client.GetPopular(page);
                           break;
                   }

                    _utils.SetMoviesImageUrl(_moviesByOptionModel.MovieResponse.Result);

                    return View(_moviesByOptionModel);
                }
                else
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                _errorVM.RequestId = ex.Message;

                return View(ERROR_PAGE_PATH, _errorVM);
            }
        }

        public async Task<IActionResult> MovieDetails(int id)
        {
            try
            {
                var movieDetailsAsync =  _client.GetMovie(id);
                var movieVideosAsync =  _client.GetMovieVideos(id);
                var movieReviews = _client.GetMovieReview(id);
                var recommended = _client.GetMoviesRecommendations(id);
                var movieCast = _client.GetMovieCast(id);

                await Task.WhenAll(movieDetailsAsync,
                    movieVideosAsync,movieReviews,
                    recommended,movieCast);

                _movieDetailsModel.Result = movieDetailsAsync.Result;
                _movieDetailsModel.Videos = movieVideosAsync.Result;
                _movieDetailsModel.Reviews = movieReviews.Result;
                _movieDetailsModel.Recommendations = recommended.Result;
                _movieDetailsModel.MovieCast = movieCast.Result;

                _utils.SetMovieImageUrl(_movieDetailsModel.Result.Movie);
                _utils.SetMoviesImageUrl(_movieDetailsModel.Recommendations.Result);
                _utils.SetMovieVideosUrl(_movieDetailsModel.Videos.Results);
                _utils.SetCastsImageUrl(_movieDetailsModel.MovieCast.Cast);

                if (!_profileClient.IsSessionEmpty())
                {
                    var profileRatedTask = await _profileClient.GetRated();

                    var ratedMovie = profileRatedTask.Result.Find(i => i.ID == id);
                    if(ratedMovie != null)
                    {
                        _movieDetailsModel.Result.Movie.Rating
                            = ratedMovie.Rating;
                    }
                }

                return View(_movieDetailsModel);
            }
            catch (Exception ex)
            {
                _errorVM.RequestId = ex.Message;
                return View(ERROR_PAGE_PATH, _errorVM);
            }
        }
    }
}
