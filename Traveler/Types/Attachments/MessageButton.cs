using System.ComponentModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Traveler.Types.Attachments
{
    public enum MessageButtonType
    {
        Web_Url,
        Postback,
        PhoneNumber,
        Element_Share,
        Payment
    }

    [JsonObject]
    public class MessageButton
    {
        public MessageButton(MessageButtonType type, string title, string url = "", string payload = "")
        {
            Type = type;
            Title = title;
            Url = url;
            Payload = payload;
        }

        public MessageButton()
        {
        }

        [JsonConverter(typeof(StringEnumConverter))]
        [DefaultValue(null)]
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        public MessageButtonType Type { get; set; }

        [DefaultValue("")]
        [JsonProperty(PropertyName = "url", Required = Required.Default)]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "title", Required = Required.Always)]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "payload", Required = Required.Default)]
        public string Payload { get; set; }
    }
}