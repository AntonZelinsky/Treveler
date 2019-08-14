using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Traveler.Services;
using Traveler.Types;
using Traveler.Types.Attachments;

namespace Traveler
{
    public class Examples
    {
        private readonly FacebookService _facebookService;

        public Examples(FacebookService facebookService)
        {
            _facebookService = facebookService;
        }
        public async Task ShowButtons()
        {
            await _facebookService.SendButtonTemplateMessageAsync(100039626505067, "Hiii", new List<MessageButton>
                {
                    new MessageButton
                    {
                        Title = "Hello world Postback",
                        Type = MessageButtonType.Postback,
                        Payload = "HI1"
                    },
                    new MessageButton
                    {
                        Title = "Hello world Web_Url",
                        Type = MessageButtonType.Web_Url,
                        Url = "https://www.messenger.com"
                    },
                    new MessageButton
                    {
                        Title = "Hello world 3",
                        Type = MessageButtonType.Postback,
                        Payload = "HI3"
                    }
                }
            );
        }
        public async Task ShowSenderAction(long id)
        {
            await _facebookService.SendSenderActionAsync(id, SenderAction.TYPING_INDICATOR_ON);
        }

        public async Task ShowQuickRelpy(long id)
        {
            var replies = new List<QuickReply>
            {
                new QuickReply {ContentType = QuickReplyContentType.text, Payload = "FIRE", Title = "Fire"},
                new QuickReply {ContentType = QuickReplyContentType.text, Payload = "WATER", Title = "Water"}
            };
            await _facebookService.SendQuickRepliesMessageAsync(id, "Hello World", replies);
        }

//        public async Task GenericsNotWork()
//        {
//            await _facebookService.SendGenericTemplateMessageAsync(123, new List<GenericTemplateElement>()
//            {
//                new GenericTemplateElement(
//                    "First title",
//                    new List<MessageButton>()
//                    {
//                        new MessageButton
//                        {
//                            Title = "Hello world Postback",
//                            Type = MessageButtonType.Postback,
//                            Payload = "HI1"
//                        },
//                        new MessageButton
//                        {
//                            Title = "Hello world Web_Url",
//                            Type = MessageButtonType.Web_Url,
//                            Url = "https://www.messenger.com"
//                        }
//                    }, "hahahon")
//                /*,
//                new GenericTemplateElement(
//                    "second title",
//                    new List<MessageButton>()
//                    {
//                        new MessageButton
//                        {
//                            Title = "Hello world Postback",
//                            Type = MessageButtonType.Postback,
//                            Payload = "HI1"
//                        },
//                        new MessageButton
//                        {
//                            Title = "facebook",
//                            Type = MessageButtonType.Web_Url,
//                            Url = "http://facebook.com"
//                        }
//                    }, "hahahon","http://facebook.com", "https://habrastorage.org/webt/cs/o5/zc/cso5zcp78nxxi31mspfvdat89w4.jpeg")*/
//            });
//        }
  }
}
