using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Configuration;
using PingPong.Models;

namespace PingPong.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Player> Get()
        {
      var context = new PingPongContext();
      var players = context.Players.ToList();
//      var foo = players.Where(s => s.FirstName == "Ted").FirstOrDefault<Player>();
      var foo = players.FirstOrDefault<Player>();
      return players;

        }
    }
}
