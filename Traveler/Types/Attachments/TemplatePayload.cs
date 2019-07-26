using System.ComponentModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Traveler.Types.Attachments
{
    public enum TemplatePayloadType
    {
        Generic,
        button,
        Receipt
    }

    public abstract class TemplatePayload : IPayload
    {
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "template_type", Required = Required.Always)]
        [DefaultValue(null)]
        public TemplatePayloadType TemplateType { get; set; }
    }
}