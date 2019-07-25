using System.Collections.Generic;
using Newtonsoft.Json;

namespace Traveler.Models
{
    public class RequestModels
    {
        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("entry")]
        public List<Entry> Entry { get; set; }
    }

    public class Entry
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("time")]
        public long Time { get; set; }

        [JsonProperty("messaging")]
        public List<Messaging> Messaging { get; set; }
    }

    public class Messaging
    {
        [JsonProperty("sender")]
        public Sender Sender { get; set; }

        [JsonProperty("recipient")]
        public Recipient Recipient { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("message")]
        public Message Message { get; set; }
    }

    public class Message
    {
        //        public Message()
        //        {
        //        }
        //
        //        public Message(string message)
        //        {
        //            Text = message;
        //        }

        [JsonProperty("mid")]
        public string Mid { get; set; }

        [JsonProperty("seq")]
        public long Seq { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }

    public class Recipient
    {
        //        public Recipient()
        //        {
        //        }
        //
        //        public Recipient(int id)
        //        {
        //            Id = id;
        //        }

        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class Sender
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("community")]
        public Recipient Community { get; set; }
    }
}