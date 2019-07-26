using System.Threading.Tasks;
using Traveler.Types;
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
        }

        public void HandleTextMessage(Messaging messaging)
        {
        }
    }
}