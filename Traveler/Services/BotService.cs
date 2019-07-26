using Traveler.Types.In;

namespace Traveler.Services
{
    public class BotService
    {
        private FacebookService _facebookService;

        public BotService(FacebookService facebookService)
        {
            _facebookService = facebookService;
        }

        public void HandleMessage(Messaging messaging)
        {
        }

        public void HandleTextMessage(Messaging messaging)
        {
        }
    }
}