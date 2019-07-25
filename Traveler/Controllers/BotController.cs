using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Traveler.Models;
using Traveler.Services;

namespace Traveler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BotController : ControllerBase
    {
        private FacebookService _facebookService;
        public BotController(FacebookService facebookService)
        {
            this._facebookService = facebookService;
        }
        // GET: api/Bot
        [HttpGet]
        public int Get()
        {
            var mode = Request.Query["hub.mode"].FirstOrDefault();
            var challenge = Request.Query["hub.challenge"].FirstOrDefault();
            var token = Request.Query["hub.verify_token"].FirstOrDefault();
            Debug.WriteLine("challenge: "+ challenge);
            return int.Parse(challenge ?? "0");
        }

        // GET: api/Bot/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Bot
        [HttpPost]
        public async Task Post([FromBody] RequestModels model)
        {
            foreach (var entry in model.Entry)
            {

                await _facebookService.SednMessage(entry);
            }
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
