using System.ComponentModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Traveler.Types.Attachments
{
    public enum QuickReplyContentType
    {
        location,
        text
    }

    [JsonObject]
    public class QuickReply
    {
        [JsonConverter(typeof(StringEnumConverter))]
        [DefaultValue(null)]
        [JsonProperty(PropertyName = "content_type", Required = Required.Always)]
        public QuickReplyContentType ContentType { get; set; }

        [JsonProperty(PropertyName = "title", Required = Required.Default)]
        [DefaultValue("")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "payload", Required = Required.Default)]
        [DefaultValue("")]
        public string Payload { get; set; }

        [JsonProperty(PropertyName = "image_url", Required = Required.Default)]
        [DefaultValue("")]
        public string ImageUrl { get; set; }
    }
}