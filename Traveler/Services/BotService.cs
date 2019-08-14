using System.Collections.Generic;
using System.Threading.Tasks;
using Storage;
using Traveler.Models;
using Traveler.Types;
using Traveler.Types.Attachments;
using Traveler.Types.In;

namespace Traveler.Services
{
    public class BotService
    {
        private readonly FacebookService _facebookService;
        private readonly MessagingService _messagingService;
        
        public BotService(FacebookService facebookService, MessagingService messagingService)
        {
            _facebookService = facebookService;
            _messagingService = messagingService;
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
                await HandlePostbackMessage(messaging);
            }
        }

        public async Task HandleTextMessage(Messaging messaging)
        {
            if (messaging.Message.QuickReply != null)
            {
                await HandleQuickReplayMessage(messaging);
                return;
            }

            var message = messaging.Message.Text;
            if (message.StartsWith("Я вернулся из "))
            {
                await ArrivedFrom(messaging, message.Substring(14));
            }
        }

        public async Task HandleQuickReplayMessage(Messaging messaging)
        {
            var senderId = messaging.Sender.Id;
            var payload = messaging.Message.QuickReply.Payload;
        }

        public async Task MakeActionByPayload(Postback postback, long senderId)
        {
            var state = StateHelper.GetState(postback.Payload);
            switch (state)
            {
                case State.START:
                    await _messagingService.GetStarted(senderId);
                    break;


                case State.DEPARTURE_TO:
                    await _messagingService.HandleDepartureTo(senderId);
                    break;

                case State.DEPARTURE_TO_COUNTRIES:
                    await _messagingService.HandleDepartureToCountries(senderId, postback.Title);
                    break;

                case State.DEPARTURE_TO_CITIES:
                    await _messagingService.HandleDepartureToCities(senderId, postback.Title);
                    break;
            }
        }

        public async Task HandlePostbackMessage(Messaging messaging)
        {
            var senderId = messaging.Sender.Id;
            var postback = messaging.Postback;

            await MakeActionByPayload(postback, senderId);
        }


        #region Arrived

        public async Task HandleArrived(Messaging messaging)
        {
            var buttons = new List<MessageButton>
            {
                new MessageButton
                {
                    Title = "Рим",
                    Type = MessageButtonType.Postback,
                    Payload = "Arrived[Рим"
                },
                new MessageButton
                {
                    Title = "Париж",
                    Type = MessageButtonType.Postback,
                    Payload = "Arrived[Париж"
                },
                new MessageButton
                {
                    Title = "Марсель",
                    Type = MessageButtonType.Postback,
                    Payload = "Arrived[Марсель"
                }
            };

            await _facebookService.SendButtonTemplateMessageAsync(messaging.Sender.Id, "Введите город в котором вы побывали или выбирите город в котором уже побывали наши сотрудники:", buttons);
        }

        public async Task ArrivedFrom(Messaging messaging)
        {
            await _facebookService.SendTextMessageAsync(messaging.Sender.Id, "ПОздравляем");
        }

        public async Task ArrivedFrom(Messaging messaging, string city)
        {
            await _facebookService.SendTextMessageAsync(messaging.Sender.Id, "ПОздравляем");
        }

        #endregion
    }
}