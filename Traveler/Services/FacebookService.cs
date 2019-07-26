using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Traveler.Models;
using Traveler.Types;
using Traveler.Types.Attachments;
using Traveler.Types.In;
using Traveler.Types.Out;

namespace Traveler.Services
{
    public class FacebookService
    {
        private readonly FacebookClient _facebookClient;

        public FacebookService(FacebookClient facebookClient)
        {
            _facebookClient = facebookClient;
        }

        public async Task SendTextMessageAsync(long userId, string text)
        {
            var message = new Message {Text = text};
            await SendApiMessagesParametersAsync(GenerateResponseModel(userId, message));
        }

        public async Task SendButtonTemplateMessageAsync(long userId, string text, List<MessageButton> buttons)
        {
            var message = new Message {Attachment = new Attachment(AttachmentType.template, new ButtonTemplate(text, buttons))};
            await SendApiMessagesParametersAsync(GenerateResponseModel(userId, message));
        }

        public async Task SendSenderActionAsync(long userId, string senderAction)
        {
            var senderActionObj = new SenderAction {ActionType = senderAction};
            await SendApiMessagesParametersAsync(GenerateResponseModel(userId, null, senderActionObj));
        }

        public async Task SendGenericTemplateMessageAsync(long userId, List<GenericTemplateElement> elements)
        {
            var message = new Message {Attachment = new Attachment(AttachmentType.template, new GenericTemplate(elements))};
            await SendApiMessagesParametersAsync(GenerateResponseModel(userId, message));
        }

        public async Task SendQuickRepliesMessageAsync(long userId, string text, List<QuickReply> replies)
        {
            var message = new Message { Text = text, QuickReplies = replies };
            await SendApiMessagesParametersAsync(GenerateResponseModel(userId, message));
        }

        private async Task SendApiMessagesParametersAsync(RequestModel requestModel)
        {
            var result = await _facebookClient.PostAsync("me/messages", requestModel);
            if (!result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                Debug.Fail(content);
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

        private RequestModel GenerateResponseModel(long id, Message message = null, SenderAction senderAction = null)
        {
            var responseModel = new RequestModel(id, message, senderAction);
            return responseModel;
        }
    }
}