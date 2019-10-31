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
  public class PlayerController : ControllerBase
    {
        private readonly ILogger<PlayerController> _logger;

        public PlayerController(ILogger<PlayerController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Player> Get()
        {
          var context = new PingPongContext();
          var players = context.Players.ToList();
          return players;

        }

        [HttpGet("{id}")]
        public Player Get(int id)
        {
          var context = new PingPongContext();
          var players = context.Players.ToList();
          var player = players.Where(i => i.Id == id).FirstOrDefault<Player>();
          return player;
        }

        [HttpPut]
        public void Put(Player player)
        {
          var context = new PingPongContext();
          var players = context.Players.ToList();
          var entity = players.Find(i => i.Id == player.Id);
          // if player to update is not found return
          if (entity == null)
          {
            return;
          }
          // save updated player
          context.Entry(entity).CurrentValues.SetValues(player);
        }

        [HttpPost]
        public void Post(Player player)
        {
          var context = new PingPongContext();
          var players = context.Players.ToList();
          var entity = players.Find(i => i.Id == player.Id);
        
          // save new player
          context.Entry(entity).CurrentValues.SetValues(player);
        }

        [HttpDelete]
        public void Delete(int id)
        {
          var context = new PingPongContext();
          var player = context.Players.ToList();
          player.Find(i => i.Id == id);

          if (player != null)
          {
            context.Remove(player);
            context.SaveChanges();
          }
        }
    }
}

