using Newtonsoft.Json;
using Traveler.Types.Attachments;
using Traveler.Types.In;

namespace Traveler.Types.Out
{
    public class RequestModel
    {
        public RequestModel(long id, Message message)
        {
            Recipient = new Recipient(id);
            Message = message;
        }

        [JsonProperty("recipient")]
        public Recipient Recipient { get; set; }

        [JsonProperty("message")]
        public Message Message { get; set; }
    }
}