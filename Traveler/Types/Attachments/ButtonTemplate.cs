﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace Traveler.Types.Attachments
{
    [JsonObject]
    public class ButtonTemplate : TemplatePayload
    {
        public ButtonTemplate(string text, IEnumerable<MessageButton> buttons)
        {
            TemplateType = TemplatePayloadType.button;
            Text = text;
            Buttons = buttons;
        }

        [JsonProperty(PropertyName = "text", Required = Required.Always)]
        public string Text { get; set; }

        [JsonProperty(PropertyName = "buttons", Required = Required.Always)]
        public IEnumerable<MessageButton> Buttons { get; set; }
    }
}