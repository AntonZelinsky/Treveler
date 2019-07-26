using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Traveler.Types.Attachments
{
    public enum AttachmentType
    {
        Image,
        Audio,
        Video,
        File,
        template
    }

    public class Attachment
    {
        public Attachment(AttachmentType type, IPayload payload)
        {
            Type = type;
            Payload = payload;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        public AttachmentType Type { get; set; }

        [JsonProperty(PropertyName = "payload", Required = Required.Always)]
        public IPayload Payload { get; set; }
    }
}