using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieDataBase.ClientAPI;
using MoviesDatabase.Web.Models;
using MoviesDatabase.Web.Utils;
using MoviesDatabase.Web.Utils.CookieManager;
using MoviesDataBase.Models.Models.Profile_related_models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesDatabase.Web.Controllers
{
    public class ProfileController : Controller
    {
        private const string ERROR_PAGE_PATH = "Error";
        private const string SESSION_VAL = "SESSIONID";


        private readonly ICookiesManager _cookiesManager;
        private readonly IProfileClient _profileClient;
        private readonly Utilities _utils;
        private readonly ErrorViewModel _errorVM;


        public ProfileController
            (ICookiesManager cookiesManager,
            IProfileClient profileClient,
            Utilities utils, ErrorViewModel errorVM)
        {
            _cookiesManager = cookiesManager;
            _profileClient = profileClient;
            _utils = utils;
            _errorVM = errorVM;

            var sessionId = _cookiesManager.GetCookie(SESSION_VAL);
            _profileClient.SetSession(sessionId.Value);
        }


        public async Task<ActionResult> Index()
        {
            try
            {
                if (_profileClient.IsSessionEmpty())
                {
                    return RedirectToAction("Index", "Authentication");
                }

                var profileDetailsTask =  _profileClient.GetProfile();
                var profileWatchListTask = _profileClient.GetWatchList();
                var profileFavoritesTask = _profileClient.GetFavorites();
                var profileRatedTask = _profileClient.GetRated();

                await Task.WhenAll
                    (profileDetailsTask,profileWatchListTask,
                    profileFavoritesTask,profileRatedTask);


                var profileModel = new ProfileViewModel 
                { Profile = profileDetailsTask.Result,
                WatchList = profileWatchListTask.Result,
                Favorites = profileFavoritesTask.Result,
                Rated = profileRatedTask.Result};


                _utils.SetMoviesImageUrl(profileModel.WatchList.Result);
                _utils.SetMoviesImageUrl(profileModel.Favorites.Result);
                _utils.SetMoviesImageUrl(profileModel.Rated.Result);



                return View(profileModel);
            }
            catch (Exception ex)
            {
                _errorVM.RequestId = ex.Message;

                return View(ERROR_PAGE_PATH, _errorVM);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddMovieToWatchList(string movieId)
        {
            try
            {
                if (_profileClient.IsSessionEmpty())
                {
                    return BadRequest("Couldn't process request.");
                }

                var addMovieReq = new AddToWatchListRequest
                { MediaId = Convert.ToInt32(movieId) };

                var res = await _profileClient.AddToWatchList(addMovieReq);

                if (res)
                {

                    return Ok();
                }
                else
                {
                    return BadRequest("Couldn't process request.");
                }
            }
            catch (Exception ex)
            {
                _errorVM.RequestId = ex.Message;

                return View(ERROR_PAGE_PATH, _errorVM);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddMovieToFavorites(string movieId)
        {
            try
            {
                if (_profileClient.IsSessionEmpty())
                {
                    return BadRequest("Couldn't process request.");
                }

                var addMovieReq = new AddToFavoriteRequest
                { MediaId = Convert.ToInt32(movieId) };

                var res = await _profileClient.AddToFavorites(addMovieReq);

                if (res)
                {

                    return Ok();
                }
                else
                {
                    return BadRequest("Couldn't process request.");
                }
            }
            catch (Exception ex)
            {

                _errorVM.RequestId = ex.Message;

                return View(ERROR_PAGE_PATH, _errorVM);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddMovieRating(string movieId,string rating)
        {
            try
            {
                if (_profileClient.IsSessionEmpty())
                {
                    return BadRequest("Couldn't process request.");
                }

                var decimalRating = Convert.ToDecimal(rating);

                var res = await _profileClient.AddMovieRating(movieId, decimalRating);

                if (res)
                {

                    return Ok();
                }
                else
                {
                    return BadRequest("Couldn't process request.");
                }
            }
            catch (Exception ex)
            {
                _errorVM.RequestId = ex.Message;

                return View(ERROR_PAGE_PATH, _errorVM);
            }
        }
    }
}
