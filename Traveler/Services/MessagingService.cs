using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Storage;
using Traveler.Models;
using Traveler.Types.Attachments;

namespace Traveler.Services
{
    public class MessagingService
    {
        private readonly FacebookService _facebookService;

        private readonly StorageService _storageService;

        public MessagingService(FacebookService facebookService, StorageService storageService)
        {
            _facebookService = facebookService;
            _storageService = storageService;
        }

        public async Task GetStarted(long id)
        {
            var buttons = new List<MessageButton>
            {
                new MessageButton
                {
                    Title = "Собираюсь",
                    Type = MessageButtonType.Postback,
                    Payload = "DEPARTURE_TO"
                },
                new MessageButton
                {
                    Title = "Вернулся",
                    Type = MessageButtonType.Postback,
                    Payload = "Arrived"
                }
            };

            await _facebookService.SendButtonTemplateMessageAsync(id, "Вы только собираетесь или уже вернулись из путешествия?", buttons);
        }

        #region Departure - отправление - сбираюсь

        /// <summary>
        /// Вывести список посещённых стран
        /// Команда: DEPARTURE_TO
        /// </summary>
        /// <param name="senderId"></param>
        /// <returns></returns>
        public async Task HandleDepartureTo(long senderId)
        {
            var countries = _storageService.GetCountries();
            var messageButtons = countries.Select(country => new MessageButton(MessageButtonType.Postback, country, payload: State.DEPARTURE_TO_COUNTRIES.ToString()));

            await _facebookService.SendButtonTemplateMessageAsync(senderId, "Страны в которых побывали наши сотрудники:", messageButtons);
        }

        /// <summary>
        /// Вывести список посещённых городов в этой стране
        /// Команда: DEPARTURE_TO_COUNTRIES
        /// </summary>
        /// <param name="senderId"></param>
        /// <param name="country"></param>
        /// <returns></returns>
        public async Task HandleDepartureToCountries(long senderId, string country)
        {
            var cities = _storageService.GetCities(country);
            var messageButtons = cities.Select(city => new MessageButton(MessageButtonType.Postback, city, payload: State.DEPARTURE_TO_CITIES.ToString()));

            await _facebookService.SendButtonTemplateMessageAsync(senderId, "Города в которых побывали наши сотрудники:", messageButtons);
        }

        /// <summary>
        /// Вывести список посещённых городов в этой стране
        /// Команда: DEPARTURE_TO_COUNTRIES
        /// </summary>
        /// <param name="senderId"></param>
        /// <param name="city"></param>
        /// <returns></returns>
        public async Task HandleDepartureToCities(long senderId, string city)
        {
            var users = _storageService.GetUsersByCity(city);
            var accounts = await _facebookService.GetAccountsAsync(users);

            var messageButtons = accounts.Select(account =>
                new MessageButton
                {
                    Title = account.Name,
                    Type = MessageButtonType.Web_Url,
                    Url = "https://workplace.facebook.com/chat/t/" + account.Id
                });

            await _facebookService.SendButtonTemplateMessageAsync(senderId, $"В {city} были:", messageButtons);
        }

        #endregion
    }
}