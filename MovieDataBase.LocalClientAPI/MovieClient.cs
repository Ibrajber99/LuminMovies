using MovieDataBase.Models;
using MoviesDataBase.Models.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MovieDataBase.LocalClientAPI
{
    public class MovieClient : HttpClient, IMovieClient
    {
        private string basePath;
        private const string MEDIA_TYPE = "application/json";

        public MovieClient(string baseAddress, string basePath)
        {
            BaseAddress = new Uri(baseAddress);
            this.basePath = basePath;
        }

        public async Task<MoviesResponseModel> GetNowPlaying(int page = 1)
        {
            try
            {
                SetupHeaders();
                var response = await GetAsync
                    (basePath + $"/nowPlaying?page={page}");

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var returnModel = JsonConvert.DeserializeObject
                        <MoviesResponseModel>(result);

                    return returnModel;
                }
                else
                {
                    throw new Exception
                        ($"Failed to retrieve items returned {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<MoviesResponseModel> GetPopular(int page = 1)
        {
            try
            {
                SetupHeaders();
                var response = await GetAsync
                    (basePath + $"/popular?page={page}");

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var returnModel = JsonConvert.DeserializeObject
                        <MoviesResponseModel>(result);

                    return returnModel;
                }
                else
                {
                    throw new Exception
                        ($"Failed to retrieve items returned {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<MoviesResponseModel> GetTopRated(int page = 1)
        {
            try
            {
                SetupHeaders();
                var response = await GetAsync
                    (basePath + $"/topRated?page={page}");

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var returnModel = JsonConvert.DeserializeObject
                        <MoviesResponseModel>(result);

                    return returnModel;
                }
                else
                {
                    throw new Exception
                        ($"Failed to retrieve items returned {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<MoviesResponseModel> GetUpcoming(int page = 1)
        {
            try
            {
                SetupHeaders();
                AppContext.SetSwitch("System.Net.Http.UseSocketsHttpHandler", false);
                var response = await GetAsync
                    (basePath + $"/upcoming?page={page}");

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var returnModel = JsonConvert.DeserializeObject
                        <MoviesResponseModel>(result);

                    return returnModel;
                }
                else
                {
                    throw new Exception
                        ($"Failed to retrieve items returned {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<FullMovieResponseModel> GetMovie(int id)
        {
            try
            {
                SetupHeaders();
                AppContext.SetSwitch("System.Net.Http.UseSocketsHttpHandler", false);
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                var response = await GetAsync
                    ("https://api.themoviedb.org/3/movie/upcoming?api_key=3058af638d5bfdb57ffe533f303bd7b2&language=en-US");

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    var movie = JsonConvert.DeserializeObject
                        <FullMovie>(result);

                    var returnModel = new FullMovieResponseModel { Movie = movie };

                    return returnModel;
                }
                else
                {
                    throw new Exception
                        ($"Failed to retrieve item returned {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<MovieReviewResponseModel> GetMovieReview(int id)
        {
            try
            {
                SetupHeaders();
                var response = await GetAsync
                    (basePath + $"/reviews/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    var returnModel = JsonConvert.DeserializeObject
                        <MovieReviewResponseModel>(result);

                    return returnModel;
                }
                else
                {
                    throw new Exception
                        ($"Failed to retrieve item returned {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected virtual void SetupHeaders()
        {
            DefaultRequestHeaders.Clear();
            DefaultRequestHeaders.Add("Connection", "Keep-alive");
            //Define request data format  
            DefaultRequestHeaders.Accept.Add
                (new MediaTypeWithQualityHeaderValue
                (MEDIA_TYPE));
        }
    }
}
