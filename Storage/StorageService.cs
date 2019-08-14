using System.Collections.Generic;
using Storage.Entities;

namespace Storage
{
    public class StorageService
    {
        public StorageService(TravelerContext context)
        {
            Context = context;
        }

        private TravelerContext Context { get; }

        public List<string> GetCountries()
        {
            var countries = new List<string> {"Беларусь", "Франция", "Италия"};
            return countries;
        }

        public List<string> GetCities(string country)
        {
            var countries = new List<string> {"Минск", "Париж", "Рим"};
            return countries;
        }

        public List<long> GetUsersByCity(string city)
        {
            var countries = new List<long> {100040014663737};
            return countries;
        }
    }
}