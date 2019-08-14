using System;

namespace Traveler.Models
{
    public enum State
    {
        START,
        DEPARTURE_TO_COUNTRIES,
        DEPARTURE_TO_CITIES,
        DEPARTURE_TO,
        Arrived,
        ArrivedFrom,
    }

    public static class StateHelper{

        public static State GetState(string data)
        {
            if (Enum.TryParse<State>(data, out var state))
            {
                return state;
            }

            return State.START;
        }
    }
}