using MovieDataBase.Models;
using MoviesDataBase.Models.Models;
using MoviesDataBase.Models.Models.Formatted_Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MovieDataBase.ClientAPI
{
    public class MovieClient : HttpClient, IMovieClient
    {
        private string basePath;
        private const string MEDIA_TYPE = "application/json";
        private string APIKey;

        public MovieClient(string baseAddress, string basePath,string APIKey)
        {
            BaseAddress = new Uri(baseAddress);
            this.basePath = basePath;
            this.APIKey = APIKey;
        }

        public async Task<MoviesResponseModel> GetNowPlaying(int page = 1)
        {
            try
            {
                SetupHeaders();
                var response = await GetAsync
                    (basePath+$"/now_playing?api_key={APIKey}&language=en-US&page={page}");

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
                    (basePath + $"/popular?api_key={APIKey}&language=en-US&page={page}");

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
                    (basePath + $"/top_rated?api_key={APIKey}&language=en-US&page={page}");

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
                var response = await GetAsync
                    (basePath + $"/upcoming?api_key={APIKey}&language=en-US&page={page}");

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

        public async Task<MovieGenresResponseModel> GetMovieGenres()
        {
            try
            {
                SetupHeaders();
                var response = await GetAsync
                    ($"/3/genre/movie/list?api_key={APIKey}");

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    var returnModel = JsonConvert.DeserializeObject
                        <MovieGenresResponseModel>(result);

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

        public async Task<MoviesResponseModel> GetMovieSearch(string query, int page = 1)
        {
            try
            {
                SetupHeaders();
                var response = await GetAsync
                    ($"/3/search/movie?api_key={APIKey}&language=en-US&query={query}&page={page}&include_adult={true}");

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

        public async Task<MoviesResponseModel> GetMoviesByGenre(int id, int page =1)
        {
            try
            {
                SetupHeaders();
                var response = await GetAsync
                    ($@"/3/discover/movie?api_key={APIKey}&language=en-US&sort_by=popularity.desc&include_adult=false
                    &include_video=false&page={page}&with_genres={id}");

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
                var response = await GetAsync
                    (basePath + $"/{id}?api_key={APIKey}");

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

        public async Task<MovieVideoResponseModel> GetMovieVideos(int movieId)
        {
            try
            {
                SetupHeaders();
                var response = await GetAsync
                    (basePath + $"/{movieId}/videos?api_key={APIKey}");

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    var returnModel = JsonConvert.DeserializeObject
                        <MovieVideoResponseModel>(result);


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
                    (basePath + $"/{id}/reviews?api_key={APIKey}");

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

        public async Task<MoviesResponseModel> GetMoviesRecommendations(int id)
        {
            try
            {
                SetupHeaders();
                var response = await GetAsync
                    (basePath + $"/{id}/recommendations?api_key={APIKey}");

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

        public async Task<MovieCastResponseModel> GetMovieCast(int movieId)
        {
            try
            {
                SetupHeaders();
                var response = await GetAsync
                    (basePath + $"/{movieId}/credits?api_key={APIKey}");


                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var returnModel = JsonConvert.DeserializeObject
                        <MovieCastResponseModel>(result);

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

        protected virtual void SetupHeaders()
        {
            DefaultRequestHeaders.Clear();
            DefaultRequestHeaders.Add("Connection", "Keep-Alive");
            DefaultRequestHeaders.Add("Keep-Alive", "3600");
            //Define request data format  
            DefaultRequestHeaders.Accept.Add
                (new MediaTypeWithQualityHeaderValue
                (MEDIA_TYPE));
        }
    }
}
