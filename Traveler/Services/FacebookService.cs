using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Traveler.Models;
using Traveler.Types.Attachments;
using Traveler.Types.In;
using Traveler.Types.Out;

namespace Traveler.Services
{
    public class FacebookService
    {
        private FacebookClient _facebookClient;

        public FacebookService(FacebookClient facebookClient)
        {
            _facebookClient = facebookClient;
        }

//        public async Task HandleMessage(RequestModels model)
//        {
//            var s = model.Entry[0].Messaging[0];
//            //            var content = GenerateResponseModel(s.Sender.Id, "I am god!");
//            //            var result = await _facebookClient.PostAsync("messages", content);
//            var message = new Message() { Text = "Hello world" };
//           await SendMessagesAsync(s.Sender.Id, message);
////            var sd = await result.Content.ReadAsStringAsync();
//            
//
//        }
        public async Task SendTextMessageAsync(long userId, string text)
        {
            var message = new Message() { Text = text };
            await SendApiMessagesParametersAsync(GenerateResponseModel(userId, message));
        }
        public async Task SendButtonTemplateMessageAsync(long userId, string text, List<MessageButton> buttons)
        {
            var message = new Message() { Attachment = new Attachment(AttachmentType.template, new ButtonTemplate(text, buttons)) };
            await SendApiMessagesParametersAsync(GenerateResponseModel(userId, message));
        }

        private async Task SendApiMessagesParametersAsync(RequestModel requestModel)
        {
//            Recipient recipient = new Recipient(userId);
//            Dictionary<string, object> parameters = new Dictionary<string, object>()
//            {
//                {"recipient", recipient},
//                {"message", message}
//            };
            
            var result = await _facebookClient.PostAsync("me/messages", requestModel);
            if (!result.IsSuccessStatusCode)
            {
                var sresult = await result.Content.ReadAsStringAsync();
                Debug.Fail(sresult);
            }
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

        public async Task SendMessage(Entry entry)
        {
//                var content = GenerateResponseModel(entry.Messaging[0].Recipient.Id, "I am god!");
//                var result = await _facebookClient.PostAsync("messages", content);
//                return new Product { Name = result };
            
        }

        private RequestModel GenerateResponseModel(long id, Message message)
        {
            var responseModel = new RequestModel(id, message);
            return responseModel;
        }
    }
}