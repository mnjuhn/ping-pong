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

    [HttpGet("{Id}")]
    public Player Get(int Id)
    {
      var context = new PingPongContext();
      var players = context.Players.ToList();
      var player = players.Where(i => i.Id == Id).FirstOrDefault<Player>();
      return player;
    }

    [HttpPut]
    public void Put(Player player)
    {
      var context = new PingPongContext();
      var players = context.Players.ToList();
      var entity = players.Find(i => i.Id == player.Id);
      Console.WriteLine(player.Id);
      // if player to update is not found return
      if (entity == null)
      {
        Console.WriteLine("TEST2");

        return;
      }
      Console.WriteLine("TEST3");
      // save updated player
      context.Entry(entity).CurrentValues.SetValues(player);
      context.SaveChanges();

    }

    [HttpPost]
    public void Post(Player player)
    {
      try
      {
        var context = new PingPongContext();

        // save new player
        context.Add(player);
        context.SaveChanges();
      }
      catch (Exception e)
      {
        Console.WriteLine(e.ToString());
      }
    }

    [HttpDelete]
    public void Delete(int id)
    {
      Console.WriteLine("TEST");
      Console.WriteLine(id);
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

