using MoviesDataBase.Models.Models.Authentication_related_models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace MovieDataBase.ClientAPI
{
    public class AuthenticationClient : HttpClient, IAuthenticationClient
    {
        private readonly string basePath;
        private readonly string MEDIA_TYPE;
        private readonly string APIKey;
        private readonly string RedirectPath;

        public AuthenticationClient
            (string baseAddress, string basePath, string APIKey
            ,string RedirectPath,string mediaType)
        {
            BaseAddress = new Uri(baseAddress);
            this.basePath = basePath;
            this.APIKey = APIKey;
            this.RedirectPath = RedirectPath;
            MEDIA_TYPE = mediaType;
        }

        public async Task<ReqTokenResponseModel> GetRequestToken()
        {
            try
            {
                SetupHeaders();
                var response = await GetAsync
                    (basePath + $"/token/new?api_key={APIKey}");

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    var returnModel = JsonConvert.DeserializeObject
                        <ReqTokenResponseModel>(result);

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

        public async Task<SessionResponseModel> GetSession(string token)
        {


            try
            {
                var itemObj = new 
                {
                    request_token = token
                };

                SetupHeaders();
                var serializedJson = GetSerializedObject(itemObj);
                var bodyContent = GetBodyContent(serializedJson);

                var response = await PostAsync(basePath + $"/session/new?api_key={APIKey}", bodyContent);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception
                    ($"Failed to create the resource returned {response.StatusCode}");
                }
                else
                {
                    var result = await response.Content.ReadAsStringAsync();

                    var returnModel = JsonConvert.DeserializeObject
                       <SessionResponseModel>(result);

                    return returnModel;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public string GetRedirectPath(string token)
        {
            return $"https://www.themoviedb.org/authenticate/{token}?redirect_to={RedirectPath}";
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
