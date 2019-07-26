using Newtonsoft.Json;
using Traveler.Types.Attachments;
using Traveler.Types.In;

namespace Traveler.Types.Out
{
    public class RequestModel
    {
        public RequestModel(long id, Message message, SenderAction senderAction)
        {
            Recipient = new Recipient(id);
            Message = message;
            SenderAction = senderAction?.ActionType;
        }

        [JsonProperty("recipient", Required = Required.Always)]
        public Recipient Recipient { get; set; }

        [JsonProperty("message", Required = Required.Default)]
        public Message Message { get; set; }

        [JsonProperty(PropertyName = "sender_action", Required = Required.Default)]
        public string SenderAction { get; set; }
    }
}