using System.Collections.Generic;
using Newtonsoft.Json;

namespace Traveler.Types.Attachments
{
    [JsonObject]
    public class Message
    {
        [JsonProperty(PropertyName = "text", Required = Required.Default)]
        public string Text { get; set; }

        [JsonProperty(PropertyName = "attachment", Required = Required.Default)]
        public Attachment Attachment { get; set; }

        [JsonProperty(PropertyName = "quick_replies", Required = Required.Default)]
        public IList<QuickReply> QuickReplies { get; set; }

        [JsonProperty("mid", Required = Required.Default)]
        public string Mid { get; set; }

        [JsonProperty("seq", Required = Required.Default)]
        public long Seq { get; set; }
    }
}