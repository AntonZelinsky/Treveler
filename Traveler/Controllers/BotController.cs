﻿using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Traveler.Services;
using Traveler.Types.In;

namespace Traveler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BotController : ControllerBase
    {
        private readonly BotService _botService;

        private readonly FacebookService _facebookService;

        public BotController(FacebookService facebookService, BotService botService)
        {
            _facebookService = facebookService;
            _botService = botService;
        }

        // GET: api/Bot
        [HttpGet]
        public async Task<int> Get()
        {
            if (Request.Query["z"].FirstOrDefault() == "z")
            {
                return 1;
            }

            var mode = Request.Query["hub.mode"].FirstOrDefault();
            var challenge = Request.Query["hub.challenge"].FirstOrDefault();
            var token = Request.Query["hub.verify_token"].FirstOrDefault();
            Debug.WriteLine("challenge: " + challenge);
            return int.Parse(challenge ?? "0");
        }

        // GET: api/Bot/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

//        // POST: api/Bot
        [HttpPost]
        public async Task Post([FromBody] RequestModels model)
        {
            if (model.Entry.Count < 1 || model.Entry[0].Messaging.Count < 1)
            {
                Debugger.Break();
            }

            var message = model.Entry[0].Messaging[0];
            await _botService.HandleMessage(message);
        }

        // PUT: api/Bot/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}