using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GosDumaApiIntegration.BL
{
    internal class JsonServices:IServices
    {
        private readonly string _apiToken;
        private readonly string _appToken;

        private static JsonServices _instance;
        public static JsonServices GetInstance(string apiToken, string appToken)
        {
            if (_instance == null) _instance = new JsonServices(apiToken, appToken);

            return _instance;
                        
        }
        private JsonServices(string apiToken, string appToken)
        {
            _apiToken = apiToken;
            _appToken = appToken;
        }

        public async Task<string> GetResponseFromApi(string request, IEnumerable<string> parametres)
        {
            const string apiRootUri = "http://api.duma.gov.ru/api";
            const string format = "json";
            var parametresString = String.Empty;
            if (parametres!=null)
            {
                
                foreach(var parameter in parametres)
                {
                    if (String.IsNullOrEmpty(parameter)) continue;

                    parametresString += $"&{parameter}";
                }
            }

            var responseString = $"{apiRootUri}/{_apiToken}/{request}.{format}?app_token={_appToken}{parametresString}";

            try
            {
                return await GetHttpResponseAsync(responseString);
            }
            catch(Exception)
            {
                throw;
                //TODO: Exception Handling.
            }

        }

        private static async Task<string> GetHttpResponseAsync(string Uri)
        {
            var http = new HttpClient();
            string result = null;

            try
            {
                var response = await http.GetAsync(new Uri(Uri));

                if (response.StatusCode != HttpStatusCode.OK)
                { 
                    throw new WebException("Server's response is " + response.StatusCode);
                    
                }
                
                result = await response.Content.ReadAsStringAsync();

            }
            catch (HttpRequestException ex)
            {

                Console.WriteLine(ex.Message);
                
            }
            
            return result;

        }

       
    }
}
