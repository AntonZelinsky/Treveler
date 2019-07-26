using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Traveler.Models;

namespace Traveler.Services
{
    public interface IFacebookClient
    {
        Task<T> GetAsync<T>(string accessToken, string endpoint, string args = null);
        Task PostAsync(string accessToken, string endpoint, object data, string args = null);
    }
    public class FacebookClient
    {
        private readonly HttpClient _httpClient;
        private readonly BotConfig _config;

        public FacebookClient(IOptions<BotConfig> config)
        {
            _config = config.Value;
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(_config.BaseAddress)
            };
            _httpClient.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<T> GetAsync<T>(string endpoint, string args = null)
        {
            var response = await _httpClient.GetAsync($"{endpoint}?access_token={_config.AuthToken}&{args}");
            if (!response.IsSuccessStatusCode)
                return default(T);

            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(result);
        }
        public async Task<HttpResponseMessage> PostAsync(string endpoint, object data, string args = null)
        {
//            var requestMessage = new HttpRequestMessage();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _config.AuthToken);
            var payload = GetPayload(data);

            return await _httpClient.PostAsync($"{endpoint}?access_token={_config.AuthToken}&{args}", payload);
        }


        private static StringContent GetPayload(object data)
        {
            var json = JsonConvert.SerializeObject(data);

            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}