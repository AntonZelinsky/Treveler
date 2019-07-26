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
        private FacebookClient _facebookClient;

        public FacebookService(FacebookClient facebookClient)
        {
            _facebookClient = facebookClient;
        }

        public async Task HandleMessage(RequestModels model)
        {
            var s = model.Entry[0].Messaging[0];
            var content = GenerateResponseModel(s.Sender.Id, "I am god!");
            var result = await _facebookClient.PostAsync("messages", content);
            var sd = await result.Content.ReadAsStringAsync();
            

        }

        public async Task<Account> GetAccountAsync()
        {
            var result = await _facebookClient.GetAsync<Account>("100039626505067", "fields=id,name,email,first_name,last_name,age_range,birthday,gender,locale");
//
//            if (result == null)
//            {
//                return new Account();
//            }
//
//            var account = new Account
//            {
//                Id = result.id,
//                Email = result.email,
//                Name = result.name,
//                UserName = result.username,
//                FirstName = result.first_name,
//                LastName = result.last_name,
//                Locale = result.locale
//            };

            return result;
        }

        public async Task PostOnWallAsync(string message)
            => await _facebookClient.PostAsync("me/feed", new { message });

        public async Task SednMessage(Entry entry)
        {
                var content = GenerateResponseModel(entry.Messaging[0].Recipient.Id, "I am god!");
                var result = await _facebookClient.PostAsync("messages", content);
//                return new Product { Name = result };
            
        }

        private ResponseModels GenerateResponseModel(string id, string message)
        {
            var responseModel = new ResponseModels
            {
                Message = new MessageResponse { Text = message },
                Recipient = new Recipient { Id = id }
            };
            return responseModel;
        }
    }
}