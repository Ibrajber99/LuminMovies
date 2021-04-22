using MovieDataBase.Models;
using MoviesDataBase.Models.Models.Profile_related_models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace MovieDataBase.ClientAPI
{
    public class ProfileClient : HttpClient, IProfileClient
    {
        private string SessionID;
        private readonly string basePath;
        private readonly string MEDIA_TYPE;
        private readonly string APIKey;

        public ProfileClient
        (string baseAddress, string basePath, string APIKey, string mediaType)
        {
            BaseAddress = new Uri(baseAddress);
            this.basePath = basePath;
            this.APIKey = APIKey;
            MEDIA_TYPE = mediaType;
        }

        public async Task<ProfileModel> GetProfile()
        {
            try
            {
                SetupHeaders();
                var response = await GetAsync
                    (basePath + $"?api_key={APIKey}&session_id={SessionID}");

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    var returnModel = JsonConvert.DeserializeObject
                        <ProfileModel>(result);

                    return returnModel;
                }
                else
                {
                    throw new Exception
                        ($"Failed to retrieve items. returned {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<MoviesResponseModel> GetWatchList()
        {
            try
            {
                SetupHeaders();
                var response = await GetAsync
                    (basePath +
                    $"/{22}/watchlist/movies?api_key={APIKey}&session_id={SessionID}&sort_by=created_at.asc&page=1");

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
                        ($"Failed to retrieve items. returned {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<MoviesResponseModel> GetFavorites()
        {
            try
            {
                SetupHeaders();
                var response = await GetAsync
                    (basePath +
                    $"/{22}/favorite/movies?api_key={APIKey}&session_id={SessionID}&sort_by=created_at.asc&page=1");

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
                        ($"Failed to retrieve items. returned {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<MoviesResponseModel> GetRated()
        {
            try
            {
                SetupHeaders();
                var response = await GetAsync
                    (basePath +
                    $"/{22}/rated/movies?api_key={APIKey}&session_id={SessionID}&sort_by=created_at.asc&page=1");

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
                        ($"Failed to retrieve items. returned {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> AddToWatchList(AddToWatchListRequest request)
        {
            try
            {
                SetupHeaders();
                var serializedJson = GetSerializedObject(request);
                var bodyContent = GetBodyContent(serializedJson);

                var response = await PostAsync
                    (basePath + $"/{00}/watchlist?api_key={APIKey}&session_id={SessionID}",
                    bodyContent);

                if (!response.IsSuccessStatusCode)
                {
                    return false;
                }
                else
                {
                    var result = await response.Content.ReadAsStringAsync();

                    return true;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> AddToFavorites(AddToFavoriteRequest request)
        {
            try
            {
                SetupHeaders();
                var serializedJson = GetSerializedObject(request);
                var bodyContent = GetBodyContent(serializedJson);

                var response = await PostAsync
                    (basePath + $"/{00}/favorite?api_key={APIKey}&session_id={SessionID}",
                    bodyContent);

                if (!response.IsSuccessStatusCode)
                {
                    return false;
                }
                else
                {
                    var result = await response.Content.ReadAsStringAsync();

                    return true;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> AddMovieRating(string movieId,decimal rating)
        {
            try
            {
                var request = new
                {
                    value = rating
                };

                SetupHeaders();
                var serializedJson = GetSerializedObject(request);
                var bodyContent = GetBodyContent(serializedJson);

                var response = await PostAsync
                    ($"/3/movie/{movieId}/rating?api_key={APIKey}&session_id={SessionID}",
                    bodyContent);

                if (!response.IsSuccessStatusCode)
                {
                    return false;
                }
                else
                {
                    var result = await response.Content.ReadAsStringAsync();

                    return true;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void SetSession(string sessionId)
        {
            SessionID = sessionId;
        }

        public bool IsSessionEmpty()
        {
            return string.IsNullOrEmpty(SessionID);
        }

        protected virtual void SetupHeaders()
        {
            DefaultRequestHeaders.Clear();
            //Define request data format  
            DefaultRequestHeaders.Accept.Add
                (new MediaTypeWithQualityHeaderValue
                (MEDIA_TYPE));
        }

        protected virtual string GetSerializedObject(object obj)
        {
            var serializedJson = JsonConvert.SerializeObject(obj);

            return serializedJson;
        }

        protected virtual StringContent GetBodyContent(string serializedJson)
        {
            var bodyContent = new StringContent
                (serializedJson, Encoding.UTF8, MEDIA_TYPE);

            return bodyContent;
        }

    }
}
