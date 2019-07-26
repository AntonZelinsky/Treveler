using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Traveler.Models
{
    public class ResponseModels
    {
//        public ResponseModels(int id, string message)
//        {
////            Recipient = new Recipient(id);
////            Message = new Message(message);
//        }
        [JsonProperty("recipient")]
        public Recipient Recipient { get; set; }

        [JsonProperty("message")]
        public MessageResponse Message { get; set; }
    }

    public partial class MessageResponse
    {
        [JsonProperty("text")]
        public string Text { get; set; }
    }

//    public partial class Recipient
//    {
//        [JsonProperty("id")]
//        public long Id { get; set; }
//    }

}
