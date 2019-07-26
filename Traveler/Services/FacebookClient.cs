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
    public class FacebookClient
    {
        private readonly BotConfig _config;
        private readonly HttpClient _httpClient;

        public FacebookClient(IOptions<BotConfig> config)
        {
            _config = config.Value;
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(_config.BaseAddress)
            };
//            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _config.AuthToken);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
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
            var payload = GetPayload(data);

            return await _httpClient.PostAsync($"{endpoint}?access_token={_config.AuthToken}&{args}", payload);
        }


        private static StringContent GetPayload(object data)
        {
            var serializerSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore
            };

            var json = JsonConvert.SerializeObject(data, Formatting.None, serializerSettings);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}