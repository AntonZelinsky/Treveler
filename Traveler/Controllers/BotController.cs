using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Traveler.Models;
using Traveler.Services;

namespace Traveler.Controllers
{
//    [Route("api/[controller]")]
    [Route("")]
    [ApiController]
    public class BotController : ControllerBase
    {
        private readonly FacebookService _facebookService;

        public BotController(FacebookService facebookService)
        {
            _facebookService = facebookService;
        }

        // GET: api/Bot
        [HttpGet]
        public async Task<int> Get()
        {
            if (Request.Query["z"].FirstOrDefault() == "z")
            {
                var account = await _facebookService.GetAccountAsync();
                Console.WriteLine($"{account.Id} {account.Name}");

                var postOnWallTask = _facebookService.PostOnWallAsync("Hello world!");
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
//        [HttpPost]
//        public void Post([FromBody] RequestModels model)
//        {
////            foreach (var entry in model.Entry)
////            {
////                await _facebookService.SednMessage(entry);
////            }
////
////            return Ok();
//        }

//        // POST: api/Bot
        [HttpPost]
        public async Task Post([FromBody] RequestModels model)
        {
                await _facebookService.HandleMessage(model);
//
//            return Ok();
        }
//           [HttpPost]
//        public async Task<IActionResult> Post([FromBody] RequestModels model)
//        {
////            foreach (var entry in model.Entry)
////            {
////                await _facebookService.SednMessage(entry);
////            }
//
//            return Ok();
//        }

        
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