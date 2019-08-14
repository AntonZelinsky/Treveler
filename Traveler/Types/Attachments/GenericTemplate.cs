using System.Collections.Generic;
using Newtonsoft.Json;

namespace Traveler.Types.Attachments
{
    [JsonObject]
    public class GenericTemplate : TemplatePayload
    {
        [JsonProperty(PropertyName = "elements", Required = Required.Always)]
        public IList<GenericTemplateElement> Elements { get; set; }

        public GenericTemplate(List<GenericTemplateElement> elements)
        {
            Elements = elements;
            TemplateType = TemplatePayloadType.Generic;
        }
    }
}
