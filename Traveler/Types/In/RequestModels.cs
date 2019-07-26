using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;
using Traveler.Types.Attachments;

namespace Traveler.Types.In
{
    public class RequestModels
    {
        [JsonProperty("object", Required = Required.Always)]
        public string Object { get; set; }

        [JsonProperty("entry", Required = Required.Always)]
        public List<Entry> Entry { get; set; }
    }

    public class Entry
    {
        [JsonProperty("id", Required = Required.Always)]
        public long Id { get; set; }

        [JsonProperty("time", Required = Required.Always)]
        public long Time { get; set; }

        [JsonProperty("messaging", Required = Required.Always)]
        public List<Messaging> Messaging { get; set; }
    }

    public class Messaging
    {
        [JsonProperty("sender", Required = Required.Always)]
        public Sender Sender { get; set; }

        [JsonProperty("recipient", Required = Required.Always)]
        public Recipient Recipient { get; set; }

        [JsonProperty("timestamp", Required = Required.Always)]
        public long Timestamp { get; set; }

        [JsonProperty("message", Required = Required.Default)]
        public Message Message { get; set; }

        [JsonProperty("postback", Required = Required.Default)]
        public Postback Postback { get; set; }
    }

    public class Postback
    {
        [JsonProperty("title", Required = Required.Always)]
        public string Title { get; set; }

        [JsonProperty("payload", Required = Required.Always)]
        public string Payload { get; set; }
    }


    [JsonObject]
    public class Recipient
    {
        public Recipient(long id, string phoneNumber = "")
        {
            Id = id;
            PhoneNumber = phoneNumber;
        }

        //id or phone_number must be set in request
        [JsonProperty(PropertyName = "id", Required = Required.Default)]
        public long Id { get; set; }

        [JsonProperty(PropertyName = "phone_number", Required = Required.Default)]
        [DefaultValue("")]
        public string PhoneNumber { get; set; }
    }

    public class Sender
    {
        [JsonProperty("id", Required = Required.Always)]
        public long Id { get; set; }

        [JsonProperty("community", Required = Required.Always)]
        public Recipient Community { get; set; }
    }
}