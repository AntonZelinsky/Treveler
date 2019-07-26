using System.Collections.Generic;
using System.Threading.Tasks;
using Traveler.Types;
using Traveler.Types.Attachments;
using Traveler.Types.In;

namespace Traveler.Services
{
    public class BotService
    {
        private readonly FacebookService _facebookService;

        public BotService(FacebookService facebookService)
        {
            _facebookService = facebookService;
        }

        public async Task HandleMessage(Messaging messaging)
        {
            await _facebookService.SendSenderActionAsync(messaging.Sender.Id, SenderAction.TYPING_INDICATOR_ON);
            if (messaging.Message != null)
            {
               await HandleTextMessage(messaging);
            }
            else if (messaging.Postback != null)
            {
                HandlePostbackMessage(messaging);
            }

        }

        public async Task HandleTextMessage(Messaging messaging)
        {
            await _facebookService.SendButtonTemplateMessageAsync(100039626505067, "Hiii", new List<MessageButton>
                {
                    new MessageButton
                    {
                        Title = "Hello world Postback",
                        Type = MessageButtonType.Postback,
                        Payload = "HI1"
                    },
                    new MessageButton
                    {
                        Title = "Hello world Web_Url",
                        Type = MessageButtonType.Web_Url,
                        Url = "https://www.messenger.com"
                    },
                    new MessageButton
                    {
                        Title = "Hello world 3",
                        Type = MessageButtonType.Postback,
                        Payload = "HI3"
                    }
                }
            );
        }

        public async Task HandlePostbackMessage(Messaging messaging)
        {
            var replies = new List<QuickReply>
            {
                new QuickReply {ContentType = QuickReplyContentType.text, Payload = "FIRE", Title = "Fire"},
                new QuickReply {ContentType = QuickReplyContentType.text, Payload = "WATER", Title = "Water"}
            };
            await _facebookService.SendQuickRepliesMessageAsync(messaging.Sender.Id, "Hello World", replies);
        }
    }
}