using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Traveler.Models;

namespace Traveler.Services
{
    public class FacebookService
    {
        private BotConfig _config;

        public FacebookService(IOptions<BotConfig> config)
        {
            _config = config.Value;
        }

        public async Task SednMessage(Entry entry)
        {
            using (var httpClient = new HttpClient())
            {
                var hostName = _config.SendMessageUrl + _config.AuthToken;
                var content = GenerateResponse(entry.Messaging[0].Recipient.Id, "I am god!");
                var result = await httpClient.PostAsJsonAsync(hostName, content);
//                return new Product { Name = result };
            }
        }

        private ResponseModels GenerateResponse(string id, string message)
        {
            var responceModel = new ResponseModels
            {
                Message = new Message { Text = message },
                Recipient = new Recipient { Id = id }
            };
            return responceModel;
        }
    }
}