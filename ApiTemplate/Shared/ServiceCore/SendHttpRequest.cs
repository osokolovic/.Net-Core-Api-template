using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCore
{
    public static class SendHttpRequest<T>
    {
        public static IConfiguration Configuration { get; set; }
        private static string NedapUsername => Configuration.GetSection("NedapAPIUrl").GetSection("nedapUsername").Value;
        private static string NedapPassword => Configuration.GetSection("NedapAPIUrl").GetSection("nedapPassword").Value;
        private static readonly HttpClient _httpClient = new HttpClient();

        #region Send request and return list of T-s
        public async static Task<IEnumerable<T>> SendRequest(string api, HttpMethod method)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                   AuthenticationSchemes.Basic.ToString(),
                   Convert.ToBase64String(Encoding.ASCII.GetBytes($"{NedapUsername}:{NedapPassword}"))
                   );
            var request = new HttpRequestMessage(method, api);
            using var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

            if (response.IsSuccessStatusCode)
            {

                var result = await response.Content.ReadFromJsonAsync<IEnumerable<T>>();
                return result;
            }
            return null;
        }
        #endregion

        #region Send request and return one T
        public async static Task<T> SendRequestT(string api, HttpMethod method, T obj)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                   AuthenticationSchemes.Basic.ToString(),
                   Convert.ToBase64String(Encoding.ASCII.GetBytes($"{NedapUsername}:{NedapPassword}"))
                   );
            var request = new HttpRequestMessage(method, api);
            if( obj != null)
            {
                var serializerSettings = new Newtonsoft.Json.JsonSerializerSettings();
                serializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
                var jsonObject = Newtonsoft.Json.JsonConvert.SerializeObject(obj, serializerSettings);
                request.Content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
            }
            using var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
            if (typeof(T) == typeof(string))
            {
                return await response.Content.ReadFromJsonAsync<T>();
            }
            //if (!response.IsSuccessStatusCode)
            //{
            //    var stringMessage = response.Content.ReadAsStringAsync();
            //    var s = await response.Content.ReadFromJsonAsync<T>();
            //    return s.GetType().Name.;
            //}

            //if (response.IsSuccessStatusCode)
            //{
            var result = await response.Content.ReadFromJsonAsync<T>();
                return result;
            //}
           // return default(T);
        }
        #endregion
    }
}
